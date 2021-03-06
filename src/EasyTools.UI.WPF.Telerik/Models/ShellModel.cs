using EasyTools.Framework.Composite;
using EasyTools.Framework.UI;
using EasyTools.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace EasyTools.UI.WPF.Models
{
    public class ShellModel : BaseModel, IShellModel
    {
        public ShellModel()
        {
            Menus = new BindingList<MenuModel>();
            Modules = new Dictionary<int, IModuleExt>();
        }

        public String ApplicationName
        {
            get { return GetValue(() => ApplicationName); }
            set { SetValue(() => ApplicationName, value); }
        }

        public bool IsLogged
        {
            get { return GetValue(() => IsLogged); }
            set { SetValue(() => IsLogged, value); }
        }

        public bool IsLocked
        {
            get { return GetValue(() => IsLocked); }
            set { SetValue(() => IsLocked, value); }
        }


        public Dictionary<int, IModuleExt> Modules
        {
            get { return GetValue(() => Modules); }
            set { SetValue(() => Modules, value); }
        }


        public string Version
        {
            get { return GetValue(() => Version); }
            set { SetValue(() => Version, value); }
        }

        public string UserName
        {
            get { return GetValue(() => UserName); }
            set { SetValue(() => UserName, value); }
        }


        public virtual BindingList<MenuModel> Menus
        {
            get { return GetValue(() => Menus); }
            set { SetValue(() => Menus, value); }
        }

        public SECUser User
        {
            get { return GetValue(() => User); }
            set { SetValue(() => User, value); }
        }

        public virtual BindingList<SECCompany> Companies
        {
            get { return GetValue(() => Companies); }
            set { SetValue(() => Companies, value); }
        }

        public virtual BindingList<TabModel> Tabs
        {
            get { return GetValue(() => Tabs); }
            set { SetValue(() => Tabs, value); }
        }

        public virtual TabModel SelectedTab
        {
            get { return GetValue(() => SelectedTab); }
            set { SetValue(() => SelectedTab, value); }
        }
    }

}