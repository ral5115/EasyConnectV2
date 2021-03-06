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
    public class CONIntegratorBLL : BaseCONIntegratorBLL
    {
        private CONIntegratorConfigurationBLL cONIntegratorConfigurationDl;

        private CONStructureBLL cONStructureDl;

        public CONIntegratorBLL(IUnitOfWork settings)
            : base(settings)
        {
        }

        public CONIntegratorBLL(DatabaseSetting settings)
            : base(settings)
        {
        }

        public override CONIntegrator Execute(CONIntegrator data, Actions action, Options option, string token)
        {
            try
            {
                if (action == Actions.Add || action == Actions.Modify || action == Actions.Remove || (action == Actions.Find && (option == Options.Me || option == Options.Exist)))
                {
                    if ((action == Actions.Add || action == Actions.Modify) && option == Options.All)
                    {
                        BenginTransaction();
                        cONIntegratorConfigurationDl = new CONIntegratorConfigurationBLL(Work);
                        cONStructureDl = new CONStructureBLL(Work);
                    }
                    data = base.Execute(data, action, option, token);
                    if (action == Actions.Find && option == Options.Me)
                    {
                        cONIntegratorConfigurationDl = new CONIntegratorConfigurationBLL(this.Work.Settings);
                        cONStructureDl = new CONStructureBLL(this.Work.Settings);
                        data.IntegratorConfigurations = cONIntegratorConfigurationDl.FindAll(new CONIntegratorConfiguration { IntegratorId = data.Id }, Options.All);
                        data.Structures = cONStructureDl.FindAll(new CONStructure { IntegratorId = data.Id }, Options.All);
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

        public void AddDetails(CONIntegrator data)
        {
            if (data.IntegratorConfigurations != null && data.IntegratorConfigurations.Count > 0)
            {
                for (int i = 0; i < data.IntegratorConfigurations.Count; i++)
                {
                    data.IntegratorConfigurations[i].IntegratorId = data.Id;
                    data.IntegratorConfigurations[i].LastUpdate = DateTime.Now;
                    data.IntegratorConfigurations[i].UpdatedBy = data.UpdatedBy;
                    if (data.IntegratorConfigurations[i].Company != null)
                        data.IntegratorConfigurations[i].CompanyId = data.IntegratorConfigurations[i].Company.Id;
                    if (data.IntegratorConfigurations[i].Id == 0)
                        data.IntegratorConfigurations[i] = cONIntegratorConfigurationDl.Add(data.IntegratorConfigurations[i]);
                    else
                        data.IntegratorConfigurations[i] = cONIntegratorConfigurationDl.Modify(data.IntegratorConfigurations[i]);
                }
            }
            if (data.Structures != null && data.Structures.Count > 0)
            {
                for (int i = 0; i < data.Structures.Count; i++)
                {
                    data.Structures[i].IntegratorId = data.Id;
                    data.Structures[i].LastUpdate = DateTime.Now;
                    data.Structures[i].UpdatedBy = data.UpdatedBy;
                    if (data.Structures[i].Id == 0)
                        data.Structures[i] = cONStructureDl.Add(data.Structures[i]);
                    else
                        data.Structures[i] = cONStructureDl.Modify(data.Structures[i]);
                }
            }
        }

        public override void CommonRules(CONIntegrator data)
        {
            base.CommonRules(data);
        }

        public override void AddRules(CONIntegrator data)
        {
            base.AddRules(data);
            data.LastUpdate = DateTime.Now;
        }

        public override void ModifyRules(CONIntegrator data)
        {
            base.ModifyRules(data);
            data.LastUpdate = DateTime.Now;
        }

        public override void RemoveRules(CONIntegrator data)
        {
            base.RemoveRules(data);
        }

        public override void FindByIdRules(CONIntegrator data)
        {
            base.FindByIdRules(data);
        }

    }
}