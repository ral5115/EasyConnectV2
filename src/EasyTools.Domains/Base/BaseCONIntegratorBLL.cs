using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure;
using EasyTools.Infrastructure.Entities;
using System;

namespace EasyTools.Domains.Base
{
    public class BaseCONIntegratorBLL : IDomainLogic<CONIntegrator>
    {

        public BaseCONIntegratorBLL(IUnitOfWork settings)
        {
            Work = settings;
            CommitTransaction = false;
        }

        public BaseCONIntegratorBLL(DatabaseSetting settings)
        {
            Work = new UnitOfWork(settings);
            CommitTransaction = true;
        }

        public override void CommonRules(CONIntegrator data)
        {
            if (String.IsNullOrWhiteSpace(data.Name))
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "Name");
            if (!String.IsNullOrWhiteSpace(data.Name) && data.Name.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Name", "50");
            if (!String.IsNullOrWhiteSpace(data.XMLDefinition) && data.XMLDefinition.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "XMLDefinition", "50");
            if (!String.IsNullOrWhiteSpace(data.XMLRoot) && data.XMLRoot.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "XMLRoot", "50");
        }

        public override void AddRules(CONIntegrator data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONIntegrator", "CONIntegrators");
            if (data.Id != 0)
                AddExceptionMessage(Language.DLTABLEIDNULL, "CONIntegrator");
        }

        public override void ModifyRules(CONIntegrator data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONIntegrator", "CONIntegrators");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONIntegrator");
        }

        public override void RemoveRules(CONIntegrator data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONIntegrator", "CONIntegrators");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONIntegrator");
        }

        public override void FindByIdRules(CONIntegrator data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONIntegrator", "CONIntegrators");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONIntegrator");
        }

    }
}