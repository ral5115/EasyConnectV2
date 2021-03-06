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
    public class SECCompanyBLL : BaseSECCompanyBLL
    {

        private CONEquivalenceBLL cONEquivalenceDl;

        private CONIntegratorConfigurationBLL cONIntegratorConfigurationDl;

        private CONSQLBLL cONSQLDl;

        private SECConnectionBLL sECConnectionDl;

        private SECUserCompanyBLL sECUserCompanyDl;


        public SECCompanyBLL(IUnitOfWork settings)
            : base(settings)
        {
        }

        public SECCompanyBLL(DatabaseSetting settings)
            : base(settings)
        {
        }

        public override SECCompany Execute(SECCompany data, Actions action, Options option, string token)
        {
            try
            {
                if (action == Actions.Add || action == Actions.Modify || action == Actions.Remove || (action == Actions.Find && (option == Options.Me || option == Options.Exist)))
                {
                    if ((action == Actions.Add || action == Actions.Modify) && option == Options.All)
                    {
                        BenginTransaction();
                        cONEquivalenceDl = new CONEquivalenceBLL(Work);
                        cONIntegratorConfigurationDl = new CONIntegratorConfigurationBLL(Work);
                        cONSQLDl = new CONSQLBLL(Work);
                        sECConnectionDl = new SECConnectionBLL(Work);
                        sECUserCompanyDl = new SECUserCompanyBLL(Work);
                    }
                    data = base.Execute(data, action, option, token);
                    if (action == Actions.Find && option == Options.Me)
                    {
                        cONEquivalenceDl = new CONEquivalenceBLL(this.Work.Settings);
                        cONIntegratorConfigurationDl = new CONIntegratorConfigurationBLL(this.Work.Settings);
                        cONSQLDl = new CONSQLBLL(this.Work.Settings);
                        sECConnectionDl = new SECConnectionBLL(this.Work.Settings);
                        sECUserCompanyDl = new SECUserCompanyBLL(this.Work.Settings);
                        data.Equivalences = cONEquivalenceDl.FindAll(new CONEquivalence { CompanyId = data.Id }, Options.All);
                        data.IntegratorConfigurations = cONIntegratorConfigurationDl.FindAll(new CONIntegratorConfiguration { CompanyId = data.Id }, Options.All);
                        data.SQLs = cONSQLDl.FindAll(new CONSQL { CompanyId = data.Id }, Options.All);
                        data.Connections = sECConnectionDl.FindAll(new SECConnection { CompanyId = data.Id }, Options.All);
                        data.UserCompanies = sECUserCompanyDl.FindAll(new SECUserCompany { CompanyId = data.Id }, Options.All);
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

        public void AddDetails(SECCompany data)
        {
            if (data.Equivalences != null && data.Equivalences.Count > 0)
            {
                for (int i = 0; i < data.Equivalences.Count; i++)
                {
                    data.Equivalences[i].CompanyId = data.Id;
                    data.Equivalences[i].LastUpdate = DateTime.Now;
                    data.Equivalences[i].UpdatedBy = data.UpdatedBy;
                    if (data.Equivalences[i].Id == 0)
                        data.Equivalences[i] = cONEquivalenceDl.Add(data.Equivalences[i]);
                    else
                        data.Equivalences[i] = cONEquivalenceDl.Modify(data.Equivalences[i]);
                }
            }
            if (data.IntegratorConfigurations != null && data.IntegratorConfigurations.Count > 0)
            {
                for (int i = 0; i < data.IntegratorConfigurations.Count; i++)
                {
                    data.IntegratorConfigurations[i].CompanyId = data.Id;
                    data.IntegratorConfigurations[i].LastUpdate = DateTime.Now;
                    data.IntegratorConfigurations[i].UpdatedBy = data.UpdatedBy;
                    if (data.IntegratorConfigurations[i].Integrator != null)
                        data.IntegratorConfigurations[i].IntegratorId = data.IntegratorConfigurations[i].Integrator.Id;
                    if (data.IntegratorConfigurations[i].Id == 0)
                        data.IntegratorConfigurations[i] = cONIntegratorConfigurationDl.Add(data.IntegratorConfigurations[i]);
                    else
                        data.IntegratorConfigurations[i] = cONIntegratorConfigurationDl.Modify(data.IntegratorConfigurations[i]);
                }
            }
            if (data.SQLs != null && data.SQLs.Count > 0)
            {
                for (int i = 0; i < data.SQLs.Count; i++)
                {
                    data.SQLs[i].CompanyId = data.Id;
                    data.SQLs[i].LastUpdate = DateTime.Now;
                    data.SQLs[i].UpdatedBy = data.UpdatedBy;
                    if (data.SQLs[i].MainSQL != null)
                        data.SQLs[i].MainSQLId = data.SQLs[i].MainSQL.Id;
                    if (data.SQLs[i].Structure != null)
                        data.SQLs[i].StructureId = data.SQLs[i].Structure.Id;
                    if (data.SQLs[i].Id == 0)
                        data.SQLs[i] = cONSQLDl.Add(data.SQLs[i]);
                    else
                        data.SQLs[i] = cONSQLDl.Modify(data.SQLs[i]);
                }
            }
            //if (data.Configurations != null && data.Configurations.Count > 0)
            //{
            //   for (int i = 0; i < data.Configurations.Count; i++)
            //   {
            //      data.Configurations[i].CompanyId = data.Id;
            //      data.Configurations[i].LastUpdate = DateTime.Now;
            //      data.Configurations[i].UpdatedBy = data.UpdatedBy;
            //      if (data.Configurations[i].Id == 0)
            //         data.Configurations[i] = sECConfigurationDl.Add(data.Configurations[i]);
            //      else
            //         data.Configurations[i] = sECConfigurationDl.Modify(data.Configurations[i]);
            //   }
            //}
            if (data.Connections != null && data.Connections.Count > 0)
            {
                for (int i = 0; i < data.Connections.Count; i++)
                {
                    data.Connections[i].CompanyId = data.Id;
                    data.Connections[i].LastUpdate = DateTime.Now;
                    data.Connections[i].UpdatedBy = data.UpdatedBy;
                    if (data.Connections[i].DbType != null)
                        data.Connections[i].DbType = data.Connections[i].DbType;
                    if (data.Connections[i].Id == 0)
                        data.Connections[i] = sECConnectionDl.Add(data.Connections[i]);
                    else
                        data.Connections[i] = sECConnectionDl.Modify(data.Connections[i]);
                }
            }
            if (data.UserCompanies != null && data.UserCompanies.Count > 0)
            {
                for (int i = 0; i < data.UserCompanies.Count; i++)
                {
                    data.UserCompanies[i].CompanyId = data.Id;
                    data.UserCompanies[i].LastUpdate = DateTime.Now;
                    data.UserCompanies[i].UpdatedBy = data.UpdatedBy;
                    if (data.UserCompanies[i].User != null)
                        data.UserCompanies[i].UserId = data.UserCompanies[i].User.Id;
                    if (data.UserCompanies[i].Id == 0)
                        data.UserCompanies[i] = sECUserCompanyDl.Add(data.UserCompanies[i]);
                    else
                        data.UserCompanies[i] = sECUserCompanyDl.Modify(data.UserCompanies[i]);
                }
            }
        }

        public override void CommonRules(SECCompany data)
        {
            base.CommonRules(data);
        }

        public override void AddRules(SECCompany data)
        {
            base.AddRules(data);
            data.LastUpdate = DateTime.Now;
        }

        public override void ModifyRules(SECCompany data)
        {
            base.ModifyRules(data);
            data.LastUpdate = DateTime.Now;
        }

        public override void RemoveRules(SECCompany data)
        {
            base.RemoveRules(data);
        }

        public override void FindByIdRules(SECCompany data)
        {
            base.FindByIdRules(data);
        }

    }
}