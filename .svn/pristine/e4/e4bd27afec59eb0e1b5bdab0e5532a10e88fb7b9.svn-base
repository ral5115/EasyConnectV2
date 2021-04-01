using EasyTools.Framework.UI;
using EasyTools.Infrastructure.Entities;
using EasyTools.UI.WPF.Security.Module.Models;
using EasyTools.UI.WPF.Security.Module.ViewModels;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Unity;
using System;
using Telerik.Windows.Controls;

namespace EasyTools.UI.WPF.Security.Module.Views
{
    public partial class SECRoleView : BaseUserControl
    {
        public SECRoleView(IUnityContainer container)
        {
            InitializeComponent();
            ViewModel = new SECRoleViewModel(container, this);
        }

        public SECRoleViewModel ViewModel
        {
            get { return DataContext as SECRoleViewModel; }
            set { DataContext = value; }
        }

        public SECRoleModel Model
        {
            get
            {
                return ViewModel.Model;
            }
        }

        bool isLoaded = false;

        private void UserControlLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!isLoaded)
            {
                ViewModel.NewCommand.Execute(new object());
                isLoaded = true;
            }
        }

        public event EventHandler<DataEventArgs<SECRole>> DataGridDetailSelectionChange;

        //private void DetailsSelectedItemsChanged(object sender, Telerik.Windows.Controls.GridView.RowEventArgs e)
        //{
        //    if (DataGridDetailSelectionChange != null && e.Row.Item != null)
        //    {
        //        DataGridDetailSelectionChange(sender, new DataEventArgs<SECRole>(e.Row.Item as SECRole));
        //    }

        //}

        private void DetailsSelectedItemsChanged(object sender, SelectionChangeEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                if (DataGridDetailSelectionChange != null)
                    DataGridDetailSelectionChange(sender, new DataEventArgs<SECRole>(e.AddedItems[0] as SECRole));
            }
            else
                ViewModel.FormHeaderExpanded = false;
        }
    }
}