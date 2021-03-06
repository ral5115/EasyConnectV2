using EasyTools.Framework.Composite;
using EasyTools.UI.WPF.ViewModels;
using Microsoft.Practices.Prism.PubSubEvents;
using System;
using System.Windows;
using System.Windows.Controls;

namespace EasyTools.UI.WPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class ShellView : Window, IShellView
    {
        public ShellView()
        {
            InitializeComponent();
            ViewModel = new ShellViewModel(this);
            LoginViewT.ViewModel = new LoginViewModel(this);
            LoginViewT.ViewModel.SetNormalMode();
        }

        public IShellViewModel ViewModel
        {
            get
            {
                return DataContext as IShellViewModel;
            }
            set
            {
                DataContext = value;
            }
        }

        public IShellModel Model
        {
            get
            {
                return ViewModel.Model;
            }
        }

        public event EventHandler<DataEventArgs<MenuModel>> OnShowTabMenu;

        public void ShowTabWindow(MenuModel menu)
        {
            if (OnShowTabMenu != null)
                OnShowTabMenu(this, new DataEventArgs<MenuModel>(menu));
        }

        public event EventHandler<DataEventArgs<String>> OnUserSelectionChange;

        private void ListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (OnUserSelectionChange != null)
                OnUserSelectionChange(sender, new DataEventArgs<string>(e.AddedItems[0].ToString()));
        }

        private void OnItemSelected(object sender, RoutedEventArgs e)
        {

            if (e.Source != null && e.Source.GetType() == typeof(TreeViewItem) && ((TreeViewItem)e.Source).Header != null && ((TreeViewItem)e.Source).Header.GetType() == typeof(MenuModel))
            {
                MenuModel menu = ((TreeViewItem)e.Source).Header as MenuModel;
                if (menu.ModuleId != 0)
                    OnShowTabMenu(sender, new DataEventArgs<MenuModel>(menu));
            }
        }

    }

}