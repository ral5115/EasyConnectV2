using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure;
using EasyTools.Infrastructure.Entities;
using System;

namespace EasyTools.Domains.Base
{
    public class BaseCONEquivalenceBLL : IDomainLogic<CONEquivalence>
    {

        public BaseCONEquivalenceBLL(IUnitOfWork settings)
        {
            Work = settings;
            CommitTransaction = false;
        }

        public BaseCONEquivalenceBLL(DatabaseSetting settings)
        {
            Work = new UnitOfWork(settings);
            CommitTransaction = true;
        }

        public override void CommonRules(CONEquivalence data)
        {
            if (String.IsNullOrWhiteSpace(data.Name))
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "Name");
            if (!String.IsNullOrWhiteSpace(data.Name) && data.Name.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Name", "50");
            if (!String.IsNullOrWhiteSpace(data.LabelValue1) && data.LabelValue1.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "LabelValue1", "50");
            if (!String.IsNullOrWhiteSpace(data.LabelValue2) && data.LabelValue2.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "LabelValue2", "50");
            if (!String.IsNullOrWhiteSpace(data.LabelValue3) && data.LabelValue3.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "LabelValue3", "50");
            if (!String.IsNullOrWhiteSpace(data.LabelValue4) && data.LabelValue4.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "LabelValue4", "50");
            if (!String.IsNullOrWhiteSpace(data.LabelValue5) && data.LabelValue5.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "LabelValue5", "50");
            if (!String.IsNullOrWhiteSpace(data.LabelValue6) && data.LabelValue6.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "LabelValue6", "50");
            if (!String.IsNullOrWhiteSpace(data.LabelValue7) && data.LabelValue7.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "LabelValue7", "50");
            if (!String.IsNullOrWhiteSpace(data.LabelValue8) && data.LabelValue8.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "LabelValue8", "50");
            if (!String.IsNullOrWhiteSpace(data.LabelValue9) && data.LabelValue9.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "LabelValue9", "50");
            if (!String.IsNullOrWhiteSpace(data.LabelValue10) && data.LabelValue10.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "LabelValue10", "50");
        }

        public override void AddRules(CONEquivalence data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONEquivalence", "CONEquivalences");
            if (data.Id != 0)
                AddExceptionMessage(Language.DLTABLEIDNULL, "CONEquivalence");
        }

        public override void ModifyRules(CONEquivalence data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONEquivalence", "CONEquivalences");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONEquivalence");
        }

        public override void RemoveRules(CONEquivalence data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONEquivalence", "CONEquivalences");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONEquivalence");
        }

        public override void FindByIdRules(CONEquivalence data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONEquivalence", "CONEquivalences");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONEquivalence");
        }

    }
}