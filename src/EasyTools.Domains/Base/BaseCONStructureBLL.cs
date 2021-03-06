using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure;
using EasyTools.Infrastructure.Entities;
using System;

namespace EasyTools.Domains.Base
{
    public class BaseCONStructureBLL : IDomainLogic<CONStructure>
    {

        public BaseCONStructureBLL(IUnitOfWork settings)
        {
            Work = settings;
            CommitTransaction = false;
        }

        public BaseCONStructureBLL(DatabaseSetting settings)
        {
            Work = new UnitOfWork(settings);
            CommitTransaction = true;
        }

        public override void CommonRules(CONStructure data)
        {
            if (String.IsNullOrWhiteSpace(data.Code))
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "Code");
            if (!String.IsNullOrWhiteSpace(data.Code) && data.Code.Length > 10)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Code", "10");
            if (String.IsNullOrWhiteSpace(data.Name))
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "Name");
            if (!String.IsNullOrWhiteSpace(data.Name) && data.Name.Length > 80)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Name", "80");
        }

        public override void AddRules(CONStructure data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONStructure", "CONStructures");
            if (data.Id != 0)
                AddExceptionMessage(Language.DLTABLEIDNULL, "CONStructure");
        }

        public override void ModifyRules(CONStructure data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONStructure", "CONStructures");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONStructure");
        }

        public override void RemoveRules(CONStructure data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONStructure", "CONStructures");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONStructure");
        }

        public override void FindByIdRules(CONStructure data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONStructure", "CONStructures");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONStructure");
        }

    }
}