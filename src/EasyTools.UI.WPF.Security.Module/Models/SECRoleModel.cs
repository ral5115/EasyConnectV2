using EasyTools.Framework.Composite;
using EasyTools.Framework.Resources;
using EasyTools.Framework.UI;
using EasyTools.Infrastructure.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EasyTools.UI.WPF.Security.Module.Models
{
    public class SECRoleModel : BaseModel
    {

        public BindingList<SECRole> Details
        {
            get { return GetValue(() => Details); }
            set { SetValue(() => Details, value); }
        }

        public SECRole SelectedSECRole { get; set; }

        public SECRole Entity
        {
            get
            {
                SECRole data = new SECRole();
                data.Id = this.Id;
                data.Name = this.Name;
                data.Active = this.Active;
                data.UpdatedBy = this.UpdatedBy;
                data.LastUpdate = this.LastUpdate;
                if (this.RolePermissions != null && this.RolePermissions.Count > 0)
                    data.RolePermissions = this.RolePermissions.ToList<SECRolePermission>();
                if (this.Users != null && this.Users.Count > 0)
                    data.Users = this.Users.ToList<SECUser>();
                return data;

            }
            set
            {
                this.Id = value.Id;
                this.Name = (String.IsNullOrWhiteSpace(value.Name) ? "" : value.Name);
                this.Active = value.Active;
                this.UpdatedBy = (String.IsNullOrWhiteSpace(value.UpdatedBy) ? "" : value.UpdatedBy);
                this.LastUpdate = value.LastUpdate;
                if (value.RolePermissions != null && value.RolePermissions.Count > 0)
                    this.RolePermissions = new BindingList<SECRolePermission>(value.RolePermissions);
                if (value.Users != null && value.Users.Count > 0)
                    this.Users = new BindingList<SECUser>(value.Users);
                this.NotifyPropertyChanged("Entity");
            }
        }

        [Display(Name = "SECRoleViewNameField", ResourceType = typeof(Language))]
        [StringLength(50, ErrorMessageResourceName = "ApplicationErrorStringRequired", ErrorMessageResourceType = typeof(Language), MinimumLength = 1)]
        public virtual String Name
        {
            get { return GetValue(() => Name); }
            set { SetValue(() => Name, value); }
        }

        [Display(Name = "SECRoleViewActiveField", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
        public virtual Boolean Active
        {
            get { return GetValue(() => Active); }
            set { SetValue(() => Active, value); }
        }

        public virtual BindingList<SECRolePermission> RolePermissions
        {
            get { return GetValue(() => RolePermissions); }
            set { SetValue(() => RolePermissions, value); }
        }

        public virtual BindingList<MenuModel> RoleMenuPermissions
        {
            get { return GetValue(() => RoleMenuPermissions); }
            set { SetValue(() => RoleMenuPermissions, value); }
        }

        public virtual BindingList<SECUser> Users
        {
            get { return GetValue(() => Users); }
            set { SetValue(() => Users, value); }
        }

    }
}