using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure;
using EasyTools.Infrastructure.Entities;
using System;

namespace EasyTools.Domains.Base
{
    public class BaseCONIntegratorConfigurationBLL : IDomainLogic<CONIntegratorConfiguration>
    {

        public BaseCONIntegratorConfigurationBLL(IUnitOfWork settings)
        {
            Work = settings;
            CommitTransaction = false;
        }

        public BaseCONIntegratorConfigurationBLL(DatabaseSetting settings)
        {
            Work = new UnitOfWork(settings);
            CommitTransaction = true;
        }

        public override void CommonRules(CONIntegratorConfiguration data)
        {
            //if (!String.IsNullOrWhiteSpace(data.WebServiceUrl) && data.WebServiceUrl.Length > 1024)
            //    AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "WebServiceUrl", "1024");
            if (String.IsNullOrWhiteSpace(data.InternalUser))
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "InternalUser");
            if (!String.IsNullOrWhiteSpace(data.InternalUser) && data.InternalUser.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "InternalUser", "50");
            if (String.IsNullOrWhiteSpace(data.InternalPassword))
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "InternalPassword");
            if (!String.IsNullOrWhiteSpace(data.InternalPassword) && data.InternalPassword.Length > 255)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "InternalPassword", "255");
            //if (!String.IsNullOrWhiteSpace(data.InternalConnectionName) && data.InternalConnectionName.Length > 10)
            //    AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "InternalConnectionName", "10");
            if (!String.IsNullOrWhiteSpace(data.ProgramPath) && data.ProgramPath.Length > 1024)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "ProgramPath", "1024");
        }

        public override void AddRules(CONIntegratorConfiguration data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONIntegratorConfiguration", "CONIntegratorConfigurations");
            if (data.Id != 0)
                AddExceptionMessage(Language.DLTABLEIDNULL, "CONIntegratorConfiguration");
        }

        public override void ModifyRules(CONIntegratorConfiguration data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONIntegratorConfiguration", "CONIntegratorConfigurations");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONIntegratorConfiguration");
        }

        public override void RemoveRules(CONIntegratorConfiguration data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONIntegratorConfiguration", "CONIntegratorConfigurations");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONIntegratorConfiguration");
        }

        public override void FindByIdRules(CONIntegratorConfiguration data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONIntegratorConfiguration", "CONIntegratorConfigurations");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONIntegratorConfiguration");
        }

    }
}