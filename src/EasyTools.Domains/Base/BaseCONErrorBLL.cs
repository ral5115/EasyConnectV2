using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure;
using EasyTools.Infrastructure.Entities;
using System;

namespace EasyTools.Domains.Base
{
    public class BaseCONErrorBLL : IDomainLogic<CONError>
    {

        public BaseCONErrorBLL(IUnitOfWork settings)
        {
            Work = settings;
            CommitTransaction = false;
        }

        public BaseCONErrorBLL(DatabaseSetting settings)
        {
            Work = new UnitOfWork(settings);
            CommitTransaction = true;
        }

        public override void CommonRules(CONError data)
        {
            if (!String.IsNullOrWhiteSpace(data.ErrorValue) && data.ErrorValue.Length > 200)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "ErrorValue", "200");
            if (!String.IsNullOrWhiteSpace(data.ErrorDetail) && data.ErrorDetail.Length > 255)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "ErrorDetail", "255");
        }

        public override void AddRules(CONError data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONError", "CONErrors");
            if (data.Id != 0)
                AddExceptionMessage(Language.DLTABLEIDNULL, "CONError");
        }

        public override void ModifyRules(CONError data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONError", "CONErrors");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONError");
        }

        public override void RemoveRules(CONError data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONError", "CONErrors");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONError");
        }

        public override void FindByIdRules(CONError data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONError", "CONErrors");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONError");
        }

    }
}