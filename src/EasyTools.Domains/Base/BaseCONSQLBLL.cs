using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure;
using EasyTools.Infrastructure.Entities;
using System;

namespace EasyTools.Domains.Base
{
    public class BaseCONSQLBLL : IDomainLogic<CONSQL>
    {

        public BaseCONSQLBLL(IUnitOfWork settings)
        {
            Work = settings;
            CommitTransaction = false;
        }

        public BaseCONSQLBLL(DatabaseSetting settings)
        {
            Work = new UnitOfWork(settings);
            CommitTransaction = true;
        }

        public override void CommonRules(CONSQL data)
        {
            if (String.IsNullOrWhiteSpace(data.Description))
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "Description");
            if (!String.IsNullOrWhiteSpace(data.Description) && data.Description.Length > 255)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Description", "255");
            if (!String.IsNullOrWhiteSpace(data.SQLSentence) && data.SQLSentence.Length > Int32.MaxValue)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "SQLSentence", Int32.MaxValue.ToString());
            if (!String.IsNullOrWhiteSpace(data.ExecuteStoreProcedure) && data.ExecuteStoreProcedure.Length > 200)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "ExecuteStoreProcedure", "200");
            //if (!String.IsNullOrWhiteSpace(data.FileName) && data.FileName.Length > 255)
            //   AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "FileName", "255");
            if (!String.IsNullOrWhiteSpace(data.Tag) && data.Tag.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Tag", "50");
            //if (!String.IsNullOrWhiteSpace(data.FileExtension) && data.FileExtension.Length > 4)
            //   AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "FileExtension", "4");
        }

        public override void AddRules(CONSQL data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONSQL", "CONSQLs");
            if (data.Id != 0)
                AddExceptionMessage(Language.DLTABLEIDNULL, "CONSQL");
        }

        public override void ModifyRules(CONSQL data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONSQL", "CONSQLs");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONSQL");
        }

        public override void RemoveRules(CONSQL data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONSQL", "CONSQLs");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONSQL");
        }

        public override void FindByIdRules(CONSQL data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONSQL", "CONSQLs");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONSQL");
        }

    }
}