using EasyTools.Framework.Composite;
using EasyTools.Framework.UI;
using EasyTools.UI.Data;
using EasyTools.UI.WPF.Models;
using EasyTools.UI.WPF.Views;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.PubSubEvents;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EasyTools.UI.WPF.ViewModels
{
    public class ShellViewModel : BaseViewModel, IShellViewModel
    {

        private readonly ShellView shellView;

        public ShellViewModel(ShellView shellView)
        {
            this.shellView = shellView;
            this.LockSesionCommand = new RelayCommand(OnLLockSesionCommand);
            this.LogOutCommand = new RelayCommand(OnLogOutCommand);
            this.Model = new ShellModel();
            ((ShellModel)Model).Tabs = new BindingList<TabModel>();
            shellView.OnShowTabMenu += OnShowTabMenu;
        }


        private IShellModel model;

        public IShellModel Model
        {
            get { return model; }
            set { SetProperty(ref model, value, "Model"); }
        }

        #region Commands

        public ICommand LogOutCommand { get; private set; }

        public ICommand LockSesionCommand { get; private set; }

        #endregion

        #region Implemented Commands

        private void OnLLockSesionCommand(object obj)
        {
            shellView.LoginViewT.ViewModel = new ViewModels.LoginViewModel(shellView);
            shellView.LoginViewT.ViewModel.SetLockedMode();
            shellView.LoginViewT.ViewModel.Model.DatabaseSetting = EasyApp.Current.DefaultDatabaseSetting;
            shellView.LoginViewT.ViewModel.Model.Login = EasyApp.Current.User.Login;
            shellView.LoginViewT.Visibility = Visibility.Visible;
        }

        private void OnLogOutCommand(object obj)
        {
            EasyApp.Current.User = null;
            shellView.ViewModel.Model.UserName = "Iniciar Sesión";
            shellView.ViewModel.Model.IsLogged = false;
            App.Current.MainWindow.Close();
        }

        #endregion

        #region MyRegion

        private void OnShowTabMenu(object sender, DataEventArgs<MenuModel> e)
        {
            TabModel newTabItem = new TabModel();
            newTabItem.Header = e.Value.Name;
            newTabItem.IsSelected = true;
            //newTabItem.Content = new UserControl1();
            IModuleExt module = shellView.ViewModel.Model.Modules[e.Value.ModuleId];
            var usb = (module != null ? (BaseUserControl)module.Execute(e.Value.TypeView, e.Value.Id) : null);
            if (usb != null)
                newTabItem.Content = usb;
            newTabItem.IsSelected = true;
            
            //if (sender != null)
            //{
            //    int insertIndex = ((ShellModel)Model).Tabs.IndexOf(sender) + 1;
            //    this.Tabs.Insert(insertIndex, newTabItem);
            //}
            //else
            //{

            newTabItem.RemoveItemCommand = new DelegateCommand(
               delegate
               {
                   ((ShellModel)Model).Tabs.Remove(((ShellModel)Model).SelectedTab);
               },
               delegate
               {
                   return true;//((ShellModel)Model).Tabs != null && ((ShellModel)Model).SelectedTab != null;
               });
            ((ShellModel)Model).Tabs.Add(newTabItem);
            //}
            //Grid gridWindow = new Grid();
            //FormTabItem tabItem = new FormTabItem();

            //tabItem.Header = e.Value.Name;
            //IModuleExt module = shellView.ViewModel.Model.Modules[e.Value.ModuleId];

            //var usb = (module != null ? (BaseUserControl)module.Execute(e.Value.TypeView, e.Value.Id) : null);

            //if (usb != null)
            //    gridWindow.Children.Add(usb);
            //tabItem.Content = gridWindow;

            //tabItem.IsSelected = true;
            //shellView.TabMainContainer.Items.Add(tabItem);


        }

        #endregion
    }
}
