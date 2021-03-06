using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure;
using EasyTools.Infrastructure.Entities;
using System;

namespace EasyTools.Domains.Base
{
    public class BaseSECRoleBLL : IDomainLogic<SECRole>
    {

        public BaseSECRoleBLL(IUnitOfWork settings)
        {
            Work = settings;
            CommitTransaction = false;
        }

        public BaseSECRoleBLL(DatabaseSetting settings)
        {
            Work = new UnitOfWork(settings);
            CommitTransaction = true;
        }

        public override void CommonRules(SECRole data)
        {
            if (String.IsNullOrWhiteSpace(data.Name))
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "Name");
            if (!String.IsNullOrWhiteSpace(data.Name) && data.Name.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Name", "50");
        }

        public override void AddRules(SECRole data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "SECRole", "SECRols");
            if (data.Id != 0)
                AddExceptionMessage(Language.DLTABLEIDNULL, "SECRole");
        }

        public override void ModifyRules(SECRole data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "SECRole", "SECRols");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "SECRole");
        }

        public override void RemoveRules(SECRole data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "SECRole", "SECRols");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "SECRole");
        }

        public override void FindByIdRules(SECRole data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "SECRole", "SECRols");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "SECRole");
        }

    }
}