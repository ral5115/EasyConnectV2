using EasyTools.Framework.UI;
using EasyTools.Infrastructure.Entities;
using EasyTools.UI.WPF.EasyConnect.Module.Models;
//using EasyTools.UI.Data.Server;
using EasyTools.UI.WPF.EasyConnect.Module.ViewModels;
//using Infragistics.Windows.DataPresenter;
//using Infragistics.Windows.DataPresenter.Events;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Unity;
using System;
using Telerik.Windows.Controls;

namespace EasyTools.UI.WPF.EasyConnect.Module.Views
{
    /// <summary>
    /// Interaction logic for SECUserView.xaml
    /// </summary>
    public partial class CONSQLParameterView : BaseUserControl
    {
        public CONSQLParameterView(IUnityContainer container)
        {
            InitializeComponent();
            ViewModel = new CONSQLParameterViewModel(container, this);
        }

        //public CONSQLParameterView(FormWindow window)
        //{
        //    InitializeComponent();
        //    ViewModel = new CONSQLParameterViewModel(this);
        //    ViewModel.Window = window;
        //}

        public CONSQLParameterViewModel ViewModel
        {
            get { return DataContext as CONSQLParameterViewModel; }
            set { DataContext = value; }
        }

        public CONSQLParameterModel Model
        {
            get
            {
                return ViewModel.Model;
            }
        }

        public bool isLoaded = false;

        private void UserControlLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!isLoaded)
            {
                ViewModel.NewCommand.Execute(new object());
                isLoaded = true;
            }
        }

        public event EventHandler<DataEventArgs<CONSQLParameter>> DataGridDetailSelectionChange;

        private void DetailsSelectedItemsChanged(object sender, SelectionChangeEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                if (DataGridDetailSelectionChange != null)
                    DataGridDetailSelectionChange(sender, new DataEventArgs<CONSQLParameter>(e.AddedItems[0] as CONSQLParameter));
            }
            else
                ViewModel.FormHeaderExpanded = false;
        }
    }
}