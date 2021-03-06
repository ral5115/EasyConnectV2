using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure;
using EasyTools.Infrastructure.Entities;
using System;

namespace EasyTools.Domains.Base
{
    public class BaseCONStructureAssociationBLL : IDomainLogic<CONStructureAssociation>
    {

        public BaseCONStructureAssociationBLL(IUnitOfWork settings)
        {
            Work = settings;
            CommitTransaction = false;
        }

        public BaseCONStructureAssociationBLL(DatabaseSetting settings)
        {
            Work = new UnitOfWork(settings);
            CommitTransaction = true;
        }

        public override void CommonRules(CONStructureAssociation data)
        {
        }

        public override void AddRules(CONStructureAssociation data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONStructureAssociation", "CONStructureAssociations");
            if (data.Id != 0)
                AddExceptionMessage(Language.DLTABLEIDNULL, "CONStructureAssociation");
        }

        public override void ModifyRules(CONStructureAssociation data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONStructureAssociation", "CONStructureAssociations");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONStructureAssociation");
        }

        public override void RemoveRules(CONStructureAssociation data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONStructureAssociation", "CONStructureAssociations");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONStructureAssociation");
        }

        public override void FindByIdRules(CONStructureAssociation data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONStructureAssociation", "CONStructureAssociations");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONStructureAssociation");
        }

    }
}