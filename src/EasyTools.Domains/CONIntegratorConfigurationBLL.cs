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
    public class CONIntegratorConfigurationBLL : BaseCONIntegratorConfigurationBLL
    {
        private CONSQLSendBLL cONSQLSendDl;

        public CONIntegratorConfigurationBLL(IUnitOfWork settings)
            : base(settings)
        {
        }

        public CONIntegratorConfigurationBLL(DatabaseSetting settings)
            : base(settings)
        {
        }

        public override CONIntegratorConfiguration Execute(CONIntegratorConfiguration data, Actions action, Options option, string token)
        {
            try
            {
                if (action == Actions.Add || action == Actions.Modify || action == Actions.Remove || (action == Actions.Find && (option == Options.Me || option == Options.Exist)))
                {
                    if ((action == Actions.Add || action == Actions.Modify) && option == Options.All)
                    {
                        BenginTransaction();
                        cONSQLSendDl = new CONSQLSendBLL(Work);
                    }
                    data = base.Execute(data, action, option, token);
                    if (action == Actions.Find && option == Options.Me)
                    {
                        cONSQLSendDl = new CONSQLSendBLL(this.Work.Settings);
                        data.SQLSends = cONSQLSendDl.FindAll(new CONSQLSend { CONIntegratorConfigurationId = data.Id }, Options.All);
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

        public void AddDetails(CONIntegratorConfiguration data)
        {
            if (data.SQLSends != null && data.SQLSends.Count > 0)
            {
                for (int i = 0; i < data.SQLSends.Count; i++)
                {
                    data.SQLSends[i].CONIntegratorConfigurationId = data.Id;
                    data.SQLSends[i].LastUpdate = DateTime.Now;
                    data.SQLSends[i].UpdatedBy = data.UpdatedBy;
                    if (data.SQLSends[i].SQL != null)
                        data.SQLSends[i].SQLId = data.SQLSends[i].SQL.Id;
                    if (data.SQLSends[i].Id == 0)
                        data.SQLSends[i] = cONSQLSendDl.Add(data.SQLSends[i]);
                    else
                        data.SQLSends[i] = cONSQLSendDl.Modify(data.SQLSends[i]);
                }
            }
        }

        public override void CommonRules(CONIntegratorConfiguration data)
        {
            base.CommonRules(data);
        }

        public override void AddRules(CONIntegratorConfiguration data)
        {
            base.AddRules(data);
            data.LastUpdate = DateTime.Now;
        }

        public override void ModifyRules(CONIntegratorConfiguration data)
        {
            base.ModifyRules(data);
            data.LastUpdate = DateTime.Now;
        }

        public override void RemoveRules(CONIntegratorConfiguration data)
        {
            base.RemoveRules(data);
        }

        public override void FindByIdRules(CONIntegratorConfiguration data)
        {
            base.FindByIdRules(data);
        }

    }
}