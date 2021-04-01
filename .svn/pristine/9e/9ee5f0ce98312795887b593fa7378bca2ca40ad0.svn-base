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
    public partial class SECUserView : BaseUserControl
    {
        public SECUserView(IUnityContainer container)
        {
            InitializeComponent();
            ViewModel = new SECUserViewModel(container, this);
        }

        public SECUserViewModel ViewModel
        {
            get
            {
                return DataContext as SECUserViewModel;
            }
            set
            {
                DataContext = value;
            }
        }

        public SECUserModel Model
        {
            get
            {
                return ViewModel.Model;
            }
        }

        private bool isLoaded = false;

        private void UserControlLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!isLoaded)
            {
                ViewModel.NewCommand.Execute(new object());
                isLoaded = true;
            }
        }

        public event EventHandler<DataEventArgs<SECUser>> DataGridDetailSelectionChange;

        private void DetailsSelectedItemsChanged(object sender, SelectionChangeEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                if (DataGridDetailSelectionChange != null)
                    DataGridDetailSelectionChange(sender, new DataEventArgs<SECUser>(e.AddedItems[0] as SECUser));
            }
            else
                ViewModel.FormHeaderExpanded = false;
        }

    }
}
