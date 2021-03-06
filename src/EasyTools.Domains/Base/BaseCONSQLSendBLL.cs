using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure;
using EasyTools.Infrastructure.Entities;
using System;

namespace EasyTools.Domains.Base
{
    public class BaseCONSQLSendBLL : IDomainLogic<CONSQLSend>
    {

        public BaseCONSQLSendBLL(IUnitOfWork settings)
        {
            Work = settings;
            CommitTransaction = false;
        }

        public BaseCONSQLSendBLL(DatabaseSetting settings)
        {
            Work = new UnitOfWork(settings);
            CommitTransaction = true;
        }

        public override void CommonRules(CONSQLSend data)
        {
        }

        public override void AddRules(CONSQLSend data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONSQLSend", "CONSQLSends");
            if (data.Id != 0)
                AddExceptionMessage(Language.DLTABLEIDNULL, "CONSQLSend");
        }

        public override void ModifyRules(CONSQLSend data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONSQLSend", "CONSQLSends");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONSQLSend");
        }

        public override void RemoveRules(CONSQLSend data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONSQLSend", "CONSQLSends");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONSQLSend");
        }

        public override void FindByIdRules(CONSQLSend data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONSQLSend", "CONSQLSends");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONSQLSend");
        }

    }
}