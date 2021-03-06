using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure;
using EasyTools.Infrastructure.Entities;
using System;

namespace EasyTools.Domains.Base
{
    public class BaseCONRecordDetailBLL : IDomainLogic<CONRecordDetail>
    {

        public BaseCONRecordDetailBLL(IUnitOfWork settings)
        {
            Work = settings;
            CommitTransaction = false;
        }

        public BaseCONRecordDetailBLL(DatabaseSetting settings)
        {
            Work = new UnitOfWork(settings);
            CommitTransaction = true;
        }

        public override void CommonRules(CONRecordDetail data)
        {
            if (String.IsNullOrWhiteSpace(data.Company))
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "Company");
            if (!String.IsNullOrWhiteSpace(data.Company) && data.Company.Length > 3)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Company", "3");
            if (String.IsNullOrWhiteSpace(data.LogicalKey))
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "LogicalKey");
            if (!String.IsNullOrWhiteSpace(data.LogicalKey) && data.LogicalKey.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "LogicalKey", "50");
            if (String.IsNullOrWhiteSpace(data.XMLData))
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "XMLData");
            if (!String.IsNullOrWhiteSpace(data.XMLData) && data.XMLData.Length > Int32.MaxValue)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "XMLData", "0");
            if (!String.IsNullOrWhiteSpace(data.OperationCenter) && data.OperationCenter.Length > 3)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "OperationCenter", "3");
            if (!String.IsNullOrWhiteSpace(data.DocumentType) && data.DocumentType.Length > 3)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "DocumentType", "3");
            if (String.IsNullOrWhiteSpace(data.PlainText))
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "PlainText");
            if (!String.IsNullOrWhiteSpace(data.PlainText) && data.PlainText.Length > Int32.MaxValue)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "PlainText", "0");
        }

        public override void AddRules(CONRecordDetail data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONRecordDetail", "CONRecordDetails");
            if (data.Id != 0)
                AddExceptionMessage(Language.DLTABLEIDNULL, "CONRecordDetail");
        }

        public override void ModifyRules(CONRecordDetail data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONRecordDetail", "CONRecordDetails");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONRecordDetail");
        }

        public override void RemoveRules(CONRecordDetail data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONRecordDetail", "CONRecordDetails");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONRecordDetail");
        }

        public override void FindByIdRules(CONRecordDetail data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONRecordDetail", "CONRecordDetails");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONRecordDetail");
        }

    }
}