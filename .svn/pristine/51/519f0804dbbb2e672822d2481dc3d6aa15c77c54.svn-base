using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure;
using EasyTools.Infrastructure.Entities;
using System;

namespace EasyTools.Domains.Base
{
    public class BaseSECUserCompanyBLL : IDomainLogic<SECUserCompany>
    {

        public BaseSECUserCompanyBLL(IUnitOfWork settings)
        {
            Work = settings;
            CommitTransaction = false;
        }

        public BaseSECUserCompanyBLL(DatabaseSetting settings)
        {
            Work = new UnitOfWork(settings);
            CommitTransaction = true;
        }

        public override void CommonRules(SECUserCompany data)
        {
        }

        public override void AddRules(SECUserCompany data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "SECUserCompany", "SECUserCompanies");
            if (data.Id != 0)
                AddExceptionMessage(Language.DLTABLEIDNULL, "SECUserCompany");
        }

        public override void ModifyRules(SECUserCompany data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "SECUserCompany", "SECUserCompanies");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "SECUserCompany");
        }

        public override void RemoveRules(SECUserCompany data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "SECUserCompany", "SECUserCompanies");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "SECUserCompany");
        }

        public override void FindByIdRules(SECUserCompany data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "SECUserCompany", "SECUserCompanies");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "SECUserCompany");
        }

    }
}