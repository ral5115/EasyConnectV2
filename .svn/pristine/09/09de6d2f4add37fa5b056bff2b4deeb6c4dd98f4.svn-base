using EasyTools.Framework.Composite;
using EasyTools.Framework.Data;
using EasyTools.Framework.UI;
using EasyTools.Infrastructure.Entities;
using EasyTools.UI.Data;
using EasyTools.UI.WPF.EasyConnect.Module.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace EasyTools.UI.WPF.EasyConnect.Module
{
    public class EasyConnectModule : IModule, IModuleExt
    {
        private readonly IUnityContainer container;

        private readonly IShellView shellView;

        public int Id { get; set; }

        public EasyConnectModule(IUnityContainer container, IShellView shellView)
        {
            Id = 2;
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
            if (TypeView == typeof(CONEquivalenceView))
            {
                CONEquivalenceView view = container.Resolve<CONEquivalenceView>();
                CheckSecurity(view.ViewModel, menuId);
                return view;
            }
            else if (TypeView == typeof(CONErrorView))
            {
                CONErrorView view = container.Resolve<CONErrorView>();
                CheckSecurity(view.ViewModel, menuId);
                return view;
            }
            else if (TypeView == typeof(CONIntegratorConfigurationView))
            {
                CONIntegratorConfigurationView view = container.Resolve<CONIntegratorConfigurationView>();
                CheckSecurity(view.ViewModel, menuId);
                return view;
            }
            else if (TypeView == typeof(CONRecordView))
            {
                CONRecordView view = container.Resolve<CONRecordView>();
                CheckSecurity(view.ViewModel, menuId);
                return view;
            }
            else if (TypeView == typeof(CONSQLView))
            {
                CONSQLView view = container.Resolve<CONSQLView>();
                CheckSecurity(view.ViewModel, menuId);
                return view;
            }
            else if (TypeView == typeof(CONSQLExecuteView))
            {
                CONSQLExecuteView view = container.Resolve<CONSQLExecuteView>();
                return view;
            }
            else if (TypeView == typeof(WSEquivalenciasFormasPagoView))
            {
                WSEquivalenciasFormasPagoView view = container.Resolve<WSEquivalenciasFormasPagoView>();
                return view;
            }
            else if (TypeView == typeof(WSCONCESIONEView))
            {
                WSCONCESIONEView view = container.Resolve<WSCONCESIONEView>();
                return view;
            }
            else if (TypeView == typeof(WSCONCESIONESTIENDAView))
            {
                WSCONCESIONESTIENDAView view = container.Resolve<WSCONCESIONESTIENDAView>();
                return view;
            }
            return null;
        }

        public void RegisterMenus()
        {
            EasyApp.Current.ListMenuModels.Add(new MenuModel { ModuleId = this.Id, Id = 4, Code = "EasyTools.UI.WPF.EasyConnect.Module.Views.CONIntegratorConfigurationView", Name = "Configuración", TypeView = typeof(CONIntegratorConfigurationView), Permissions = container.Resolve<CONIntegratorConfigurationView>().ViewModel.Permisions, Visibility = Visibility.Collapsed });
            EasyApp.Current.ListMenuModels.Add(new MenuModel { ModuleId = this.Id, Id = 5, Code = "EasyTools.UI.WPF.EasyConnect.Module.Views.CONEquivalenceView", Name = "Equivalencias", TypeView = typeof(CONEquivalenceView), Permissions = container.Resolve<CONEquivalenceView>().ViewModel.Permisions, Visibility = Visibility.Collapsed });
            EasyApp.Current.ListMenuModels.Add(new MenuModel { ModuleId = this.Id, Id = 6, Code = "EasyTools.UI.WPF.EasyConnect.Module.Views.CONSQLView", Name = "Interfaces", TypeView = typeof(CONSQLView), Permissions = container.Resolve<CONSQLView>().ViewModel.Permisions, Visibility = Visibility.Collapsed });
            EasyApp.Current.ListMenuModels.Add(new MenuModel { ModuleId = this.Id, Id = 9, Code = "EasyTools.UI.WPF.EasyConnect.Module.Views.CONSQLExecuteView", Name = "Ejecución", TypeView = typeof(CONSQLExecuteView), Permissions = container.Resolve<CONSQLExecuteView>().ViewModel.Permisions, Visibility = Visibility.Collapsed });
            EasyApp.Current.ListMenuModels.Add(new MenuModel { ModuleId = this.Id, Id = 7, Code = "EasyTools.UI.WPF.EasyConnect.Module.Views.CONRecordView", Name = "Registros a Enviar", TypeView = typeof(CONRecordView), Permissions = container.Resolve<CONRecordView>().ViewModel.Permisions, Visibility = Visibility.Collapsed });
            EasyApp.Current.ListMenuModels.Add(new MenuModel { ModuleId = this.Id, Id = 8, Code = "EasyTools.UI.WPF.EasyConnect.Module.Views.CONErrorView", Name = "Errores", TypeView = typeof(CONErrorView), Permissions = container.Resolve<CONErrorView>().ViewModel.Permisions, Visibility = Visibility.Collapsed });
            EasyApp.Current.ListMenuModels.Add(new MenuModel { ModuleId = this.Id, Id = 8, Code = "EasyTools.UI.WPF.EasyConnect.Module.Views.WSEquivalenciasFormasPagoView", Name = "Matriz Formas Pago", TypeView = typeof(WSEquivalenciasFormasPagoView), Permissions = container.Resolve<WSEquivalenciasFormasPagoView>().ViewModel.Permisions, Visibility = Visibility.Collapsed });
            EasyApp.Current.ListMenuModels.Add(new MenuModel { ModuleId = this.Id, Id = 8, Code = "EasyTools.UI.WPF.EasyConnect.Module.Views.WSCONCESIONEView", Name = "Matriz Concesiones", TypeView = typeof(WSCONCESIONEView), Permissions = container.Resolve<WSCONCESIONEView>().ViewModel.Permisions, Visibility = Visibility.Collapsed });
            EasyApp.Current.ListMenuModels.Add(new MenuModel { ModuleId = this.Id, Id = 8, Code = "EasyTools.UI.WPF.EasyConnect.Module.Views.WSCONCESIONESTIENDAView", Name = "Matriz Concesiones Tiendas", TypeView = typeof(WSCONCESIONESTIENDAView), Permissions = container.Resolve<WSCONCESIONESTIENDAView>().ViewModel.Permisions, Visibility = Visibility.Collapsed });

            MenuModel menu = new MenuModel();
            menu.Id = 2;
            menu.Code = "1S1";
            menu.Name = "Integraciones";
            menu.Visibility = Visibility.Collapsed;
            menu.ChildMenus = new BindingList<MenuModel>(EasyApp.Current.ListMenuModels.Where(x => x.ModuleId == this.Id).ToList<MenuModel>());
            //menu.ChildMenus.Add(new MenuModel { ModuleId = this.Id, Id = 6, Code = "EasyTools.UI.WPF.EasyConnect.Module.Views.CONSQLParameterView", Name = "Parametros", TypeView = typeof(CONSQLParameterView) });
            shellView.ViewModel.Model.Menus.Add(menu);
        }

        public void RegisterTypes()
        {
            this.container.RegisterType<CONEquivalenceView, CONEquivalenceView>();
            this.container.RegisterType<CONErrorView, CONErrorView>();
            this.container.RegisterType<CONIntegratorConfigurationView, CONIntegratorConfigurationView>();
            this.container.RegisterType<CONRecordView, CONRecordView>();
            this.container.RegisterType<CONSQLView, CONSQLView>();
            this.container.RegisterType<CONSQLParameterView, CONSQLParameterView>();
            this.container.RegisterType<CONSQLExecuteView, CONSQLExecuteView>();
            this.container.RegisterType<WSEquivalenciasFormasPagoView, WSEquivalenciasFormasPagoView>();
            this.container.RegisterType<WSCONCESIONEView, WSCONCESIONEView>();
            this.container.RegisterType<WSCONCESIONESTIENDAView, WSCONCESIONESTIENDAView>();

        }
    }
}