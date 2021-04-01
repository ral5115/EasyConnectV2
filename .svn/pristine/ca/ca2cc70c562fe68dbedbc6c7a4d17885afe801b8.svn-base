using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure;
using EasyTools.Infrastructure.Entities;
using System;

namespace EasyTools.Domains.Base
{
    public class BaseSECCompanyBLL : IDomainLogic<SECCompany>
    {

        public BaseSECCompanyBLL(IUnitOfWork settings)
        {
            Work = settings;
            CommitTransaction = false;
        }

        public BaseSECCompanyBLL(DatabaseSetting settings)
        {
            Work = new UnitOfWork(settings);
            CommitTransaction = true;
        }

        public override void CommonRules(SECCompany data)
        {
            if (String.IsNullOrWhiteSpace(data.IdentificationNumer))
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "IdentificationNumer");
            if (!String.IsNullOrWhiteSpace(data.IdentificationNumer) && data.IdentificationNumer.Length > 20)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "IdentificationNumer", "20");
            if (String.IsNullOrWhiteSpace(data.TradeName))
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "TradeName");
            if (!String.IsNullOrWhiteSpace(data.TradeName) && data.TradeName.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "TradeName", "50");
        }

        public override void AddRules(SECCompany data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "SECCompany", "SECCompanies");
            if (data.Id != 0)
                AddExceptionMessage(Language.DLTABLEIDNULL, "SECCompany");
        }

        public override void ModifyRules(SECCompany data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "SECCompany", "SECCompanies");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "SECCompany");
        }

        public override void RemoveRules(SECCompany data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "SECCompany", "SECCompanies");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "SECCompany");
        }

        public override void FindByIdRules(SECCompany data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "SECCompany", "SECCompanies");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "SECCompany");
        }

    }
}