using EasyTools.Framework.Composite;
using EasyTools.UI.Data;
using EasyTools.UI.WPF.EasyConnect.Module;
using EasyTools.UI.WPF.Security.Module;
using EasyTools.UI.WPF.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using System.Windows;

namespace EasyTools.UI.WPF
{
    public class UICompositionBootstrapper : UnityBootstrapper
    {
        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            moduleCatalog.AddModule(typeof(SecurityModule));
            moduleCatalog.AddModule(typeof(EasyConnectModule));

        }

        protected override DependencyObject CreateShell()
        {
            // Use the container to create an instance of the shell.
            ShellView view = this.Container.TryResolve<ShellView>();
            return view;
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            ShellView shellView = Container.Resolve<ShellView>("ShellView");
            Container.RegisterInstance<IShellView>(shellView);
            shellView.ViewModel.Model.Version = "V " + "0.14.1123";
            shellView.ViewModel.Model.ApplicationName = "Easy Tools";
            this.Shell = shellView as DependencyObject;
            App.Current.MainWindow = (Window)this.Shell;
       
            EasyApp.Current.ServiceUrl = Properties.Settings.Default.ServiceUrl;
            EasyApp.Current.Container = this.Container;
            EasyApp.Current.Initialized();
           
            App.Current.MainWindow.Show();
            
        }

        protected override void ConfigureContainer()
        {
            Container.RegisterType<IShellView, ShellView>();
            base.ConfigureContainer();
        }
    }
}