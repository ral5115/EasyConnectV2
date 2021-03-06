using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure;
using EasyTools.Infrastructure.Entities;
using System;

namespace EasyTools.Domains.Base
{
    public class BaseEXTFileOperaBLL : IDomainLogic<EXTFileOpera>
    {

        public BaseEXTFileOperaBLL(IUnitOfWork settings)
        {
            Work = settings;
            CommitTransaction = false;
        }

        public BaseEXTFileOperaBLL(DatabaseSetting settings)
        {
            Work = new UnitOfWork(settings);
            CommitTransaction = true;
        }

        public override void CommonRules(EXTFileOpera data)
        {
            if (String.IsNullOrWhiteSpace(data.Name))
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "Name");
            if (!String.IsNullOrWhiteSpace(data.Name) && data.Name.Length > 25)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Name", "25");
        }

        public override void AddRules(EXTFileOpera data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "EXTFileOpera", "EXTFileOpera");
            if (data.Id != 0)
                AddExceptionMessage(Language.DLTABLEIDNULL, "EXTFileOpera");
        }

        public override void ModifyRules(EXTFileOpera data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "EXTFileOpera", "EXTFileOpera");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "EXTFileOpera");
        }

        public override void RemoveRules(EXTFileOpera data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "EXTFileOpera", "EXTFileOpera");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "EXTFileOpera");
        }

        public override void FindByIdRules(EXTFileOpera data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "EXTFileOpera", "EXTFileOpera");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "EXTFileOpera");
        }

    }
}