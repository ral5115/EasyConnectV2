using EasyTools.Framework.UI;
using EasyTools.Infrastructure.Entities;
using EasyTools.UI.WPF.EasyConnect.Module.Models;
using EasyTools.UI.WPF.EasyConnect.Module.ViewModels;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Unity;
using System;
using Telerik.Windows.Controls;

namespace EasyTools.UI.WPF.EasyConnect.Module.Views
{
    /// <summary>
    /// Interaction logic for SECUserView.xaml
    /// </summary>
    public partial class CONIntegratorConfigurationView : BaseUserControl
    {
        public CONIntegratorConfigurationView(IUnityContainer container)
        {
            InitializeComponent();
            ViewModel = new CONIntegratorConfigurationViewModel(container, this);
        }

        public CONIntegratorConfigurationViewModel ViewModel
        {
            get { return DataContext as CONIntegratorConfigurationViewModel; }
            set { DataContext = value; }
        }

        public CONIntegratorConfigurationModel Model
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

        public event EventHandler<DataEventArgs<CONIntegratorConfiguration>> DataGridDetailSelectionChange;

        private void DetailsSelectedItemsChanged(object sender, SelectionChangeEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                if (DataGridDetailSelectionChange != null)
                    DataGridDetailSelectionChange(sender, new DataEventArgs<CONIntegratorConfiguration>(e.AddedItems[0] as CONIntegratorConfiguration));
            }
            else
                ViewModel.FormHeaderExpanded = false;
        }

    }
}