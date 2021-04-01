using EasyTools.Domains.Base;
using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure.Entities;
using System;
using System.ServiceModel;

namespace EasyTools.Domains
{
    public class SECRolePermissionBLL : BaseSECRolePermissionBLL
    {
        public SECRolePermissionBLL(IUnitOfWork settings)
            : base(settings)
        {
        }

        public SECRolePermissionBLL(DatabaseSetting settings)
            : base(settings)
        {
        }

        public override SECRolePermission Execute(SECRolePermission data, Actions action, Options option, string token)
        {
            try
            {
                if (action == Actions.Add || action == Actions.Modify || action == Actions.Remove || (action == Actions.Find && (option == Options.Me || option == Options.Exist)))
                {
                    if ((action == Actions.Add || action == Actions.Modify) && option == Options.All)
                    {
                        BenginTransaction();
                    }
                    data = base.Execute(data, action, option, token);
                    if (action == Actions.Find && option == Options.Me)
                    {
                    }
                    if ((action == Actions.Add || action == Actions.Modify) && option == Options.All)
                        AddDetails(data);
                    //if (option == Options.All)
                    //    Work.Commit();
                    return data;
                }
                else if (action == Actions.Find && (option == Options.All || option == Options.Light))
                {
                    if (option == Options.All)
                        data.Entities = FindAll(data, Options.All);
                    else if (option == Options.Light)
                        data.Entities = FindAll(data, Options.Light);
                    return data;
                }
                else if (action == Actions.Process)
                {
                    return Process(data);
                }
                else
                    throw new NotImplementedException(GetLocalizedMessage(Language.DLACTIONNOTIMPLEMENT, action.ToString(), option.ToString()));
            }
            catch (FaultException<BusinessException> f)
            {
                Rollback();
                throw f;
            }
            catch (Exception e)
            {
                Rollback();
                throw new BusinessException(e).GetFaultException();
            }
            finally
            {
                Commit();
            }
        }

        public SECRolePermission Process(SECRolePermission data)
        {
            if (data != null && data.Entities != null && data.Entities.Count > 0)
            {
                foreach (SECRolePermission item in data.Entities)
                {
                    SECRolePermission exis = Execute(item, Actions.Find, Options.Me, "");
                    if (exis == null)
                    {
                        item.UpdatedBy = data.UpdatedBy;
                        item.LastUpdate = DateTime.Now;
                        Execute(item, Actions.Add, Options.Me, "");
                    }
                }
            }
            return data;
        }

        public void AddDetails(SECRolePermission data)
        {
        }

        public override void CommonRules(SECRolePermission data)
        {
            base.CommonRules(data);
        }

        public override void AddRules(SECRolePermission data)
        {
            base.AddRules(data);
            data.LastUpdate = DateTime.Now;
        }

        public override void ModifyRules(SECRolePermission data)
        {
            base.ModifyRules(data);
            data.LastUpdate = DateTime.Now;
        }

        public override void RemoveRules(SECRolePermission data)
        {
            base.RemoveRules(data);
        }

        public override void FindByIdRules(SECRolePermission data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "SECRolePermission", "SECRolePermissions");
            if (data.RoleId == 0 && data.PermissionId == 0 && data.MenuId == 0 && data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "SECRolePermission");
        }

    }
}