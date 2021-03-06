using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure;
using EasyTools.Infrastructure.Entities;
using System;

namespace EasyTools.Domains.Base
{
    public class BaseCONEquivalenceDetailBLL : IDomainLogic<CONEquivalenceDetail>
    {

        public BaseCONEquivalenceDetailBLL(IUnitOfWork settings)
        {
            Work = settings;
            CommitTransaction = false;
        }

        public BaseCONEquivalenceDetailBLL(DatabaseSetting settings)
        {
            Work = new UnitOfWork(settings);
            CommitTransaction = true;
        }

        public override void CommonRules(CONEquivalenceDetail data)
        {
            if (String.IsNullOrWhiteSpace(data.Code))
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "Code");
            if (!String.IsNullOrWhiteSpace(data.Code) && data.Code.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Code", "50");
            if (String.IsNullOrWhiteSpace(data.Name))
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "Name");
            if (!String.IsNullOrWhiteSpace(data.Name) && data.Name.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Name", "50");
            if (!String.IsNullOrWhiteSpace(data.Value1) && data.Value1.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Value1", "50");
            if (!String.IsNullOrWhiteSpace(data.Value2) && data.Value2.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Value2", "50");
            if (!String.IsNullOrWhiteSpace(data.Value3) && data.Value3.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Value3", "50");
            if (!String.IsNullOrWhiteSpace(data.Value4) && data.Value4.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Value4", "50");
            if (!String.IsNullOrWhiteSpace(data.Value5) && data.Value5.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Value5", "50");
            if (!String.IsNullOrWhiteSpace(data.Value6) && data.Value6.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Value6", "50");
            if (!String.IsNullOrWhiteSpace(data.Value7) && data.Value7.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Value7", "50");
            if (!String.IsNullOrWhiteSpace(data.Value8) && data.Value8.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Value8", "50");
            if (!String.IsNullOrWhiteSpace(data.Value9) && data.Value9.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Value9", "50");
            if (!String.IsNullOrWhiteSpace(data.Value10) && data.Value10.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Value10", "50");
        }

        public override void AddRules(CONEquivalenceDetail data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONEquivalenceDetail", "CONEquivalenceDetails");
            if (data.Id != 0)
                AddExceptionMessage(Language.DLTABLEIDNULL, "CONEquivalenceDetail");
        }

        public override void ModifyRules(CONEquivalenceDetail data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONEquivalenceDetail", "CONEquivalenceDetails");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONEquivalenceDetail");
        }

        public override void RemoveRules(CONEquivalenceDetail data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONEquivalenceDetail", "CONEquivalenceDetails");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONEquivalenceDetail");
        }

        public override void FindByIdRules(CONEquivalenceDetail data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONEquivalenceDetail", "CONEquivalenceDetails");
            if (data.Code == null)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONEquivalenceDetail");
        }

    }
}