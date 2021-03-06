using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure;
using EasyTools.Infrastructure.Entities;
using System;

namespace EasyTools.Domains.Base
{
    public class BaseSECRolePermissionBLL : IDomainLogic<SECRolePermission>
    {

        public BaseSECRolePermissionBLL(IUnitOfWork settings)
        {
            Work = settings;
            CommitTransaction = false;
        }

        public BaseSECRolePermissionBLL(DatabaseSetting settings)
        {
            Work = new UnitOfWork(settings);
            CommitTransaction = true;
        }

        public override void CommonRules(SECRolePermission data)
        {
        }

        public override void AddRules(SECRolePermission data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "SECRolePermission", "SECRolePermissions");
            if (data.Id != 0)
                AddExceptionMessage(Language.DLTABLEIDNULL, "SECRolePermission");
        }

        public override void ModifyRules(SECRolePermission data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "SECRolePermission", "SECRolePermissions");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "SECRolePermission");
        }

        public override void RemoveRules(SECRolePermission data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "SECRolePermission", "SECRolePermissions");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "SECRolePermission");
        }

        public override void FindByIdRules(SECRolePermission data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "SECRolePermission", "SECRolePermissions");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "SECRolePermission");
        }

    }
}