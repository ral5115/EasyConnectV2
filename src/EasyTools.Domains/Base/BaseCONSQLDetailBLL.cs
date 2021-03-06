using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure;
using EasyTools.Infrastructure.Entities;
using System;

namespace EasyTools.Domains.Base
{
    public class BaseCONSQLDetailBLL : IDomainLogic<CONSQLDetail>
    {

        public BaseCONSQLDetailBLL(IUnitOfWork settings)
        {
            Work = settings;
            CommitTransaction = false;
        }

        public BaseCONSQLDetailBLL(DatabaseSetting settings)
        {
            Work = new UnitOfWork(settings);
            CommitTransaction = true;
        }

        public override void CommonRules(CONSQLDetail data)
        {
            if (String.IsNullOrWhiteSpace(data.Field))
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "Field");
            if (!String.IsNullOrWhiteSpace(data.Field) && data.Field.Length > 30)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Field", "30");
            if (!String.IsNullOrWhiteSpace(data.Description) && data.Description.Length > 100)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Description", "100");
            if (String.IsNullOrWhiteSpace(data.DBType))
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "DBType");
            if (!String.IsNullOrWhiteSpace(data.DBType) && data.DBType.Length > 100)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "DBType", "100");
            if (!String.IsNullOrWhiteSpace(data.DefaultValue) && data.DefaultValue.Length > 255)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "DefaultValue", "255");
        }

        public override void AddRules(CONSQLDetail data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONSQLDetail", "CONSQLDetails");
            if (data.Id != 0)
                AddExceptionMessage(Language.DLTABLEIDNULL, "CONSQLDetail");
        }

        public override void ModifyRules(CONSQLDetail data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONSQLDetail", "CONSQLDetails");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONSQLDetail");
        }

        public override void RemoveRules(CONSQLDetail data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONSQLDetail", "CONSQLDetails");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONSQLDetail");
        }

        public override void FindByIdRules(CONSQLDetail data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONSQLDetail", "CONSQLDetails");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONSQLDetail");
        }

    }
}