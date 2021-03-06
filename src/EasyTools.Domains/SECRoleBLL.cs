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
    public class SECRoleBLL : BaseSECRoleBLL
    {
        private SECRolePermissionBLL sECRolePermissionDl;

        private SECUserBLL sECUserDl;

        public SECRoleBLL(IUnitOfWork settings)
            : base(settings)
        {
        }

        public SECRoleBLL(DatabaseSetting settings)
            : base(settings)
        {
        }

        public override SECRole Execute(SECRole data, Actions action, Options option, string token)
        {
            try
            {
                if (action == Actions.Add || action == Actions.Modify || action == Actions.Remove || (action == Actions.Find && (option == Options.Me || option == Options.Exist)))
                {
                    if ((action == Actions.Add || action == Actions.Modify) && option == Options.All)
                    {
                        BenginTransaction();
                        sECRolePermissionDl = new SECRolePermissionBLL(Work);
                        sECUserDl = new SECUserBLL(Work);
                    }
                    data = base.Execute(data, action, option, token);
                    if (action == Actions.Find && option == Options.Me)
                    {
                        sECRolePermissionDl = new SECRolePermissionBLL(this.Work.Settings);
                        sECUserDl = new SECUserBLL(this.Work.Settings);
                        data.RolePermissions = sECRolePermissionDl.FindAll(new SECRolePermission { RoleId = data.Id }, Options.All);
                    }
                    if ((action == Actions.Add || action == Actions.Modify) && option == Options.All)
                        AddDetails(data);
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

        public void AddDetails(SECRole data)
        {
            if (data.RolePermissions != null && data.RolePermissions.Count > 0)
            {
                for (int i = 0; i < data.RolePermissions.Count; i++)
                {
                    data.RolePermissions[i].RoleId = data.Id;
                    data.RolePermissions[i].LastUpdate = DateTime.Now;
                    data.RolePermissions[i].UpdatedBy = data.UpdatedBy;
                    if (data.RolePermissions[i].Id == 0)
                        data.RolePermissions[i] = sECRolePermissionDl.Add(data.RolePermissions[i]);
                    else
                        data.RolePermissions[i] = sECRolePermissionDl.Modify(data.RolePermissions[i]);
                }
            }
        }

        public override void CommonRules(SECRole data)
        {
            base.CommonRules(data);
        }

        public override void AddRules(SECRole data)
        {
            base.AddRules(data);
            data.LastUpdate = DateTime.Now;
        }

        public override void ModifyRules(SECRole data)
        {
            base.ModifyRules(data);
            data.LastUpdate = DateTime.Now;
        }

        public override void RemoveRules(SECRole data)
        {
            base.RemoveRules(data);
        }

        public override void FindByIdRules(SECRole data)
        {
            base.FindByIdRules(data);
        }

    }
}