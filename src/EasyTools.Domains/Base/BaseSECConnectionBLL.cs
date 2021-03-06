using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure;
using EasyTools.Infrastructure.Entities;
using System;

namespace EasyTools.Domains.Base
{
    public class BaseSECConnectionBLL : IDomainLogic<SECConnection>
    {

        public BaseSECConnectionBLL(IUnitOfWork settings)
        {
            Work = settings;
            CommitTransaction = false;
        }

        public BaseSECConnectionBLL(DatabaseSetting settings)
        {
            Work = new UnitOfWork(settings);
            CommitTransaction = true;
        }

        public override void CommonRules(SECConnection data)
        {
            if (String.IsNullOrWhiteSpace(data.Login))
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "Login");
            if (!String.IsNullOrWhiteSpace(data.Login) && data.Login.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Login", "50");
            if (String.IsNullOrWhiteSpace(data.Password))
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "Password");
            if (!String.IsNullOrWhiteSpace(data.Password) && data.Password.Length > 255)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Password", "255");
            if (String.IsNullOrWhiteSpace(data.Service))
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "Service");
            if (!String.IsNullOrWhiteSpace(data.Service) && data.Service.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Service", "50");
            if (!String.IsNullOrWhiteSpace(data.DB) && data.DB.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "DB", "50");
            if (String.IsNullOrWhiteSpace(data.Name))
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "Name");
            if (!String.IsNullOrWhiteSpace(data.Name) && data.Name.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Name", "50");
        }

        public override void AddRules(SECConnection data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "SECConnection", "SECConnections");
            if (data.Id != 0)
                AddExceptionMessage(Language.DLTABLEIDNULL, "SECConnection");
        }

        public override void ModifyRules(SECConnection data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "SECConnection", "SECConnections");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "SECConnection");
        }

        public override void RemoveRules(SECConnection data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "SECConnection", "SECConnections");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "SECConnection");
        }

        public override void FindByIdRules(SECConnection data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "SECConnection", "SECConnections");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "SECConnection");
        }

    }
}