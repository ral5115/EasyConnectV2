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
    public class CONStructureDetailBLL : BaseCONStructureDetailBLL
    {
        private CONSQLDetailBLL cONSQLDetailDl;

        public CONStructureDetailBLL(IUnitOfWork settings)
            : base(settings)
        {
        }

        public CONStructureDetailBLL(DatabaseSetting settings)
            : base(settings)
        {
        }

        public override CONStructureDetail Execute(CONStructureDetail data, Actions action, Options option, string token)
        {
            try
            {
                if (action == Actions.Add || action == Actions.Modify || action == Actions.Remove || (action == Actions.Find && (option == Options.Me || option == Options.Exist)))
                {
                    if ((action == Actions.Add || action == Actions.Modify) && option == Options.All)
                    {
                        BenginTransaction();
                        cONSQLDetailDl = new CONSQLDetailBLL(Work);
                    }
                    data = base.Execute(data, action, option, token);
                    if (action == Actions.Find && option == Options.Me)
                    {
                        cONSQLDetailDl = new CONSQLDetailBLL(this.Work.Settings);
                        data.SQLDetails = cONSQLDetailDl.FindAll(new CONSQLDetail { StructureDetailId = data.Id }, Options.All);
                    }
                    if ((action == Actions.Add || action == Actions.Modify) && option == Options.All)
                        AddDetails(data);
                    //if (option == Options.All)
                    //    Work.Commit();
                    return data;
                }
                else if (action == Actions.Find && (option == Options.All || option == Options.Light))
                {
                    if (option == Options.All)
                        data.Entities = FindAll(data, Options.All);
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

        public void AddDetails(CONStructureDetail data)
        {
            if (data.SQLDetails != null && data.SQLDetails.Count > 0)
            {
                for (int i = 0; i < data.SQLDetails.Count; i++)
                {
                    data.SQLDetails[i].StructureDetailId = data.Id;
                    data.SQLDetails[i].LastUpdate = DateTime.Now;
                    data.SQLDetails[i].UpdatedBy = data.UpdatedBy;
                    if (data.SQLDetails[i].Equivalence != null)
                        data.SQLDetails[i].EquivalenceId = data.SQLDetails[i].Equivalence.Id;
                    //if (data.SQLDetails[i].MainSQLDetail != null)
                    //   data.SQLDetails[i].MainSQLDetailId = data.SQLDetails[i].MainSQLDetail.Id;
                    if (data.SQLDetails[i].SQL != null)
                        data.SQLDetails[i].SQLId = data.SQLDetails[i].SQL.Id;
                    if (data.SQLDetails[i].Id == 0)
                        data.SQLDetails[i] = cONSQLDetailDl.Add(data.SQLDetails[i]);
                    else
                        data.SQLDetails[i] = cONSQLDetailDl.Modify(data.SQLDetails[i]);
                }
            }
        }

        public override void CommonRules(CONStructureDetail data)
        {
            base.CommonRules(data);
        }

        public override void AddRules(CONStructureDetail data)
        {
            base.AddRules(data);
            data.LastUpdate = DateTime.Now;
        }

        public override void ModifyRules(CONStructureDetail data)
        {
            base.ModifyRules(data);
            data.LastUpdate = DateTime.Now;
        }

        public override void RemoveRules(CONStructureDetail data)
        {
            base.RemoveRules(data);
        }

        public override void FindByIdRules(CONStructureDetail data)
        {
            base.FindByIdRules(data);
        }

    }
}