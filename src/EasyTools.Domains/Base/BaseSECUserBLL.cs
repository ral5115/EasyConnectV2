using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure;
using EasyTools.Infrastructure.Entities;
using System;

namespace EasyTools.Domains.Base
{
    public class BaseSECUserBLL : IDomainLogic<SECUser>
    {

        public BaseSECUserBLL(IUnitOfWork settings)
        {
            Work = settings;
            CommitTransaction = false;
        }

        public BaseSECUserBLL(DatabaseSetting settings)
        {
            Work = new UnitOfWork(settings);
            CommitTransaction = true;
        }

        public override void CommonRules(SECUser data)
        {
            if (String.IsNullOrWhiteSpace(data.Login))
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "Login");
            if (!String.IsNullOrWhiteSpace(data.Login) && data.Login.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Login", "50");
            if (String.IsNullOrWhiteSpace(data.Password))
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "Password");
            if (!String.IsNullOrWhiteSpace(data.Password) && data.Password.Length > 256)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Password", "256");
            if (String.IsNullOrWhiteSpace(data.Names))
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "Names");
            if (!String.IsNullOrWhiteSpace(data.Names) && data.Names.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Names", "50");
            if (String.IsNullOrWhiteSpace(data.FatherLastName))
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "FatherLastName");
            if (!String.IsNullOrWhiteSpace(data.FatherLastName) && data.FatherLastName.Length > 20)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "FatherLastName", "20");
            if (!String.IsNullOrWhiteSpace(data.MotherLastName) && data.MotherLastName.Length > 30)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "MotherLastName", "30");
            if (String.IsNullOrWhiteSpace(data.IdentificationNumber))
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "IdentificationNumber");
            if (!String.IsNullOrWhiteSpace(data.IdentificationNumber) && data.IdentificationNumber.Length > 16)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "IdentificationNumber", "16");
            if (String.IsNullOrWhiteSpace(data.Email))
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "Email");
            if (!String.IsNullOrWhiteSpace(data.Email) && data.Email.Length > 256)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Email", "256");
            if (String.IsNullOrWhiteSpace(data.RepeatPassword))
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "RepeatPassword");
            if (!String.IsNullOrWhiteSpace(data.RepeatPassword) && data.RepeatPassword.Length > 256)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "RepeatPassword", "256");
        }

        public override void AddRules(SECUser data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "SECUser", "SECUsers");
            if (data.Id != 0)
                AddExceptionMessage(Language.DLTABLEIDNULL, "SECUser");
        }

        public override void ModifyRules(SECUser data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "SECUser", "SECUsers");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "SECUser");
        }

        public override void RemoveRules(SECUser data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "SECUser", "SECUsers");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "SECUser");
        }

        public override void FindByIdRules(SECUser data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "SECUser", "SECUsers");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "SECUser");
        }

    }
}