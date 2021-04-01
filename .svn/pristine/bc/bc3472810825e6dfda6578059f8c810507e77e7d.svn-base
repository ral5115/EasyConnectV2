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
    public partial class CONErrorView : BaseUserControl
    {
        //public CONErrorView(IUnityContainer container)
        //{
        //    InitializeComponent();
        //    ViewModel = new CONErrorViewModel(container, this);
        //}

        public CONErrorViewModel ViewModel
        {
            get { return DataContext as CONErrorViewModel; }
            set { DataContext = value; }
        }

        public CONErrorModel Model
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

        public event EventHandler<DataEventArgs<CONError>> DataGridDetailSelectionChange;

        private void DetailsSelectedItemsChanged(object sender, SelectionChangeEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                if (DataGridDetailSelectionChange != null)
                    DataGridDetailSelectionChange(sender, new DataEventArgs<CONError>(e.AddedItems[0] as CONError));
            }
            else
                ViewModel.FormHeaderExpanded = false;
        }

    }
}