using EasyTools.Framework.Data;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.ComponentModel;
using System.Windows;

namespace EasyTools.Framework.Composite
{
    public class MenuModel : BindableBase
    {
        public virtual string Code { get; set; }

        public virtual string Name { get; set; }

        public virtual Type TypeView { get; set; }

        public virtual int Id { get; set; }

        public virtual int ModuleId { get; set; }

        public virtual bool IsSelected { get; set; }

        public virtual bool IsPermission { get; set; }

        private Visibility visible;

        public virtual Visibility Visibility
        {
            get { return visible; }
            set { SetProperty(ref visible, value, "Visibility"); }
        }

        public override Int32 GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override Boolean Equals(object obj)
        {
            if ((obj == null) || (obj.GetType() != this.GetType()))
                return false;
            MenuModel castObj = (MenuModel)obj;
            return (castObj != null) && (this.Id == castObj.Id);
        }

        private BindingList<MenuModel> childMenus;

        public virtual BindingList<MenuModel> ChildMenus
        {
            get
            {
                if (childMenus == null)
                    childMenus = new BindingList<MenuModel>();
                return childMenus;
            }
            set
            {
                childMenus = value;
            }
        }

        private BindingList<Permission> permissions;

        public BindingList<Permission> Permissions
        {
            get
            {
                if (permissions == null)
                    permissions = new BindingList<Permission>();
                return permissions;
            }
            set { permissions = value; }
        }

    }
}