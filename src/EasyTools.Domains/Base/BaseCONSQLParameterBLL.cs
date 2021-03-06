using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure;
using EasyTools.Infrastructure.Entities;
using System;

namespace EasyTools.Domains.Base
{
    public class BaseCONSQLParameterBLL : IDomainLogic<CONSQLParameter>
    {

        public BaseCONSQLParameterBLL(IUnitOfWork settings)
        {
            Work = settings;
            CommitTransaction = false;
        }

        public BaseCONSQLParameterBLL(DatabaseSetting settings)
        {
            Work = new UnitOfWork(settings);
            CommitTransaction = true;
        }

        public override void CommonRules(CONSQLParameter data)
        {
            if (String.IsNullOrWhiteSpace(data.Name))
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "Name");
            if (!String.IsNullOrWhiteSpace(data.Name) && data.Name.Length > 30)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Name", "30");
            if (!String.IsNullOrWhiteSpace(data.StringValue) && data.StringValue.Length > 100)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "StringValue", "100");
        }

        public override void AddRules(CONSQLParameter data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONSQLParameter", "CONSQLParameters");
            if (data.Id != 0)
                AddExceptionMessage(Language.DLTABLEIDNULL, "CONSQLParameter");
        }

        public override void ModifyRules(CONSQLParameter data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONSQLParameter", "CONSQLParameters");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONSQLParameter");
        }

        public override void RemoveRules(CONSQLParameter data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONSQLParameter", "CONSQLParameters");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONSQLParameter");
        }

        public override void FindByIdRules(CONSQLParameter data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONSQLParameter", "CONSQLParameters");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONSQLParameter");
        }

    }
}