using EasyTools.Domains.Base;
using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure.Entities;
using System;
using System.ServiceModel;

namespace EasyTools.Domains
{
    public class CONEquivalenceBLL : BaseCONEquivalenceBLL
    {
        private CONEquivalenceDetailBLL cONEquivalenceDetailDl;

        private CONSQLDetailBLL cONSQLDetailDl;

        public CONEquivalenceBLL(IUnitOfWork settings)
            : base(settings)
        {
        }

        public CONEquivalenceBLL(DatabaseSetting settings)
            : base(settings)
        {
        }

        public override CONEquivalence Execute(CONEquivalence data, Actions action, Options option, string token)
        {
            try
            {
                if (action == Actions.Add || action == Actions.Modify || action == Actions.Remove || (action == Actions.Find && (option == Options.Me || option == Options.Exist)))
                {
                    if ((action == Actions.Add || action == Actions.Modify) && option == Options.All)
                    {
                        BenginTransaction();
                        cONEquivalenceDetailDl = new CONEquivalenceDetailBLL(Work);
                        cONSQLDetailDl = new CONSQLDetailBLL(Work);
                    }
                    data = base.Execute(data, action, option, token);
                    if (action == Actions.Find && option == Options.Me)
                    {
                        cONEquivalenceDetailDl = new CONEquivalenceDetailBLL(this.Work.Settings);
                        cONSQLDetailDl = new CONSQLDetailBLL(this.Work.Settings);
                        data.EquivalenceDetails = cONEquivalenceDetailDl.FindAll(new CONEquivalenceDetail { EquivalenceId = data.Id }, Options.All);
                        data.SQLDetails = cONSQLDetailDl.FindAll(new CONSQLDetail { EquivalenceId = data.Id }, Options.All);
                    }
                    if ((action == Actions.Add || action == Actions.Modify) && option == Options.All)
                        AddDetails(data);
                    return data;
                }
                else if (action == Actions.Find && (option == Options.All || option == Options.Light))
                {
                    if (option == Options.All)
                    {
                        data.Entities = FindAll(data, Options.All);
                        if (data.Entities != null && data.Entities.Count > 0)
                        {
                            cONEquivalenceDetailDl = new CONEquivalenceDetailBLL(Work);
                            foreach (var item in data.Entities)
                            {
                                item.EquivalenceDetails = cONEquivalenceDetailDl.FindAll(new CONEquivalenceDetail { Equivalence = data }, Options.All);
                            }
                        }
                    }
                    else if (option == Options.Light)
                        data.Entities = FindAll(data, Options.Light);
                    return data;
                }
                else
                    throw new NotImplementedException(GetLocalizedMessage(Language.DLACTIONNOTIMPLEMENT, action.ToString(), option.ToString()));
            }
            catch (FaultException<BusinessException> f)
            {
                Rollback();
                throw f;
            }
            catch (Exception e)
            {
                Rollback();
                throw new BusinessException(e).GetFaultException();
            }
            finally
            {
                Commit();
            }
        }

        public void AddDetails(CONEquivalence data)
        {
            if (data.EquivalenceDetails != null && data.EquivalenceDetails.Count > 0)
            {
                for (int i = 0; i < data.EquivalenceDetails.Count; i++)
                {
                    data.EquivalenceDetails[i].EquivalenceId = data.Id;
                    data.EquivalenceDetails[i].LastUpdate = DateTime.Now;
                    data.EquivalenceDetails[i].UpdatedBy = data.UpdatedBy;
                    if (data.EquivalenceDetails[i].Id == 0)
                        data.EquivalenceDetails[i] = cONEquivalenceDetailDl.Add(data.EquivalenceDetails[i]);
                    else
                        data.EquivalenceDetails[i] = cONEquivalenceDetailDl.Modify(data.EquivalenceDetails[i]);
                }
            }
            if (data.SQLDetails != null && data.SQLDetails.Count > 0)
            {
                for (int i = 0; i < data.SQLDetails.Count; i++)
                {
                    data.SQLDetails[i].EquivalenceId = data.Id;
                    data.SQLDetails[i].LastUpdate = DateTime.Now;
                    data.SQLDetails[i].UpdatedBy = data.UpdatedBy;
                    //if (data.SQLDetails[i].MainSQLDetail != null)
                    //   data.SQLDetails[i].MainSQLDetailId = data.SQLDetails[i].MainSQLDetail.Id;
                    if (data.SQLDetails[i].SQL != null)
                        data.SQLDetails[i].SQLId = data.SQLDetails[i].SQL.Id;
                    if (data.SQLDetails[i].StructureDetail != null)
                        data.SQLDetails[i].StructureDetailId = data.SQLDetails[i].StructureDetail.Id;
                    if (data.SQLDetails[i].Id == 0)
                        data.SQLDetails[i] = cONSQLDetailDl.Add(data.SQLDetails[i]);
                    else
                        data.SQLDetails[i] = cONSQLDetailDl.Modify(data.SQLDetails[i]);
                }
            }
        }

        public override void CommonRules(CONEquivalence data)
        {
            base.CommonRules(data);
        }

        public override void AddRules(CONEquivalence data)
        {
            base.AddRules(data);
            data.LastUpdate = DateTime.Now;
        }

        public override void ModifyRules(CONEquivalence data)
        {
            base.ModifyRules(data);
            data.LastUpdate = DateTime.Now;
        }

        public override void RemoveRules(CONEquivalence data)
        {
            base.RemoveRules(data);
        }

        public override void FindByIdRules(CONEquivalence data)
        {
            base.FindByIdRules(data);
        }

    }
}