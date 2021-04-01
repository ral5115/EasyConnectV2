using EasyTools.Framework.Composite;
using EasyTools.Framework.Data;
using EasyTools.Framework.UI;
using EasyTools.Infrastructure.Entities;
using EasyTools.UI.Data;
using EasyTools.UI.WPF.Security.Module.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace EasyTools.UI.WPF.Security.Module
{
    public class SecurityModule : IModule, IModuleExt
    {
        private readonly IUnityContainer container;

        private readonly IShellView shellView;

        public int Id { get; set; }

        public SecurityModule(IUnityContainer container, IShellView shellView)
        {
            Id = 1;
            this.container = container;
            this.shellView = shellView;
        }

        public void Initialize()
        {
            RegisterTypes();
            RegisterMenus();
            shellView.ViewModel.Model.Modules.Add(Id, this);
        }

        private void CheckSecurity(BaseViewModel viewModel, int menuId)
        {
            if (viewModel.Permisions != null && viewModel.Permisions.Count > 0)
            {
                foreach (Permission perm in viewModel.Permisions)
                {
                    SECRolePermission exist = EasyApp.Current.User.Role.RolePermissions.FirstOrDefault(x => x.MenuId == menuId && x.RoleId == EasyApp.Current.User.Role.Id && x.PermissionId == perm.Id);
                    if (exist != null)
                        perm.Active = exist.Active;
                }
            }
        }

        public object Execute(Type TypeView, int menuId)
        {
            if (TypeView == typeof(SECUserView))
            {
                SECUserView view = container.Resolve<SECUserView>();
                CheckSecurity(view.ViewModel, menuId);
                return view;
            }
            else if (TypeView == typeof(SECRoleView))
            {
                SECRoleView view = container.Resolve<SECRoleView>();
                CheckSecurity(view.ViewModel, menuId);
                return view;
            }
            else if (TypeView == typeof(SECConnectionView))
            {
                SECConnectionView view = container.Resolve<SECConnectionView>();
                CheckSecurity(view.ViewModel, menuId);
                return view;
            }
            return null;
        }

        public void RegisterMenus()
        {
            EasyApp.Current.ListMenuModels.Add(new MenuModel { ModuleId = this.Id, Id = 1, Code = "EasyTools.UI.WPF.Security.Module.Views.SECRoleView", Name = "Roles", TypeView = typeof(SECRoleView), Permissions = container.Resolve<SECRoleView>().ViewModel.Permisions, Visibility = Visibility.Collapsed });
            EasyApp.Current.ListMenuModels.Add(new MenuModel { ModuleId = this.Id, Id = 2, Code = "EasyTools.UI.WPF.Security.Module.Views.SECUserView", Name = "Usuarios", TypeView = typeof(SECUserView), Permissions = container.Resolve<SECUserView>().ViewModel.Permisions, Visibility = Visibility.Collapsed });
            EasyApp.Current.ListMenuModels.Add(new MenuModel { ModuleId = this.Id, Id = 3, Code = "EasyTools.UI.WPF.Security.Module.Views.SECConnectionView", Name = "Conexiones", TypeView = typeof(SECConnectionView), Permissions = container.Resolve<SECConnectionView>().ViewModel.Permisions, Visibility = Visibility.Collapsed });
            
            MenuModel menu = new MenuModel();
            menu.Id = 1;
            menu.Code = "1S1";
            menu.Name = "Seguridad";
            menu.Visibility = Visibility.Collapsed;
            menu.ChildMenus = new BindingList<MenuModel>(EasyApp.Current.ListMenuModels.Where(x => x.ModuleId == this.Id).ToList<MenuModel>());
            shellView.ViewModel.Model.Menus.Add(menu);
        }

        public void RegisterTypes()
        {
            this.container.RegisterType<SECUserView, SECUserView>();
            this.container.RegisterType<SECRoleView, SECRoleView>();
            this.container.RegisterType<SECConnectionView, SECConnectionView>();
        }
    }
}