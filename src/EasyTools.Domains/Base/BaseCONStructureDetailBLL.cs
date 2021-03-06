using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure;
using EasyTools.Infrastructure.Entities;
using System;

namespace EasyTools.Domains.Base
{
    public class BaseCONStructureDetailBLL : IDomainLogic<CONStructureDetail>
    {

        public BaseCONStructureDetailBLL(IUnitOfWork settings)
        {
            Work = settings;
            CommitTransaction = false;
        }

        public BaseCONStructureDetailBLL(DatabaseSetting settings)
        {
            Work = new UnitOfWork(settings);
            CommitTransaction = true;
        }

        public override void CommonRules(CONStructureDetail data)
        {
            if (String.IsNullOrWhiteSpace(data.Field))
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "Field");
            if (!String.IsNullOrWhiteSpace(data.Field) && data.Field.Length > 30)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Field", "30");
            if (!String.IsNullOrWhiteSpace(data.Description) && data.Description.Length > 255)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Description", "255");
            if (!String.IsNullOrWhiteSpace(data.Observations) && data.Observations.Length > 500)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Observations", "500");
            if (!String.IsNullOrWhiteSpace(data.DefaultValue) && data.DefaultValue.Length > 10)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "DefaultValue", "10");
        }

        public override void AddRules(CONStructureDetail data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONStructureDetail", "CONStructureDetails");
            if (data.Id != 0)
                AddExceptionMessage(Language.DLTABLEIDNULL, "CONStructureDetail");
        }

        public override void ModifyRules(CONStructureDetail data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONStructureDetail", "CONStructureDetails");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONStructureDetail");
        }

        public override void RemoveRules(CONStructureDetail data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONStructureDetail", "CONStructureDetails");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONStructureDetail");
        }

        public override void FindByIdRules(CONStructureDetail data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONStructureDetail", "CONStructureDetails");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONStructureDetail");
        }

    }
}