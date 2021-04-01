using EasyTools.Framework.Data;
using System;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities.Base
{
    /// <summary>
    /// SECRolePermission object for mapped table SECRolePermissions.
    /// </summary>
    [DataContract(IsReference = true)]
    public class BaseSECRolePermission : BaseEntity
    {

        public BaseSECRolePermission()
        {
        }

        public BaseSECRolePermission(BaseSECRolePermission data, Options option)
        {

            if (option == Options.Light || option == Options.Me || option == Options.All)
            {
                //OptionName.Light
                this.Id = data.Id;
                this.Active = data.Active;
                this.MenuId = data.MenuId;
                this.RoleId = data.RoleId;
                this.PermissionId = data.PermissionId;
                if (option == Options.Me || option == Options.All)
                {
                    this.Active = data.Active;
                    this.UpdatedBy = data.UpdatedBy;
                    this.LastUpdate = data.LastUpdate;
                    this.MenuId = data.MenuId;
                    this.RoleId = data.RoleId;
                }
            }
        }

        [DataMember]
        public virtual Boolean Active { get; set; }

        [DataMember]
        public virtual Int32 MenuId { get; set; }

        [DataMember]
        public virtual Int32 PermissionId { get; set; }

        [DataMember]
        public virtual Int32 RoleId { get; set; }


    }
}