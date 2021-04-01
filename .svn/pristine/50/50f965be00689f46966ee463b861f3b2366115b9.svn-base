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
    public partial class CONSQLView : BaseUserControl
    {
       

        //public CONSQLView(IUnityContainer container, FormWindow window)
        //{
        //    InitializeComponent();
        //    ViewModel = new CONSQLViewModel(container, this);
        //    ViewModel.Window = window;
        //}

        public CONSQLViewModel ViewModel
        {
            get { return DataContext as CONSQLViewModel; }
            set { DataContext = value; }
        }

        public CONSQLModel Model
        {
            get
            {
                return ViewModel.Model;
            }
        }

        public bool IsLoaded { get; set; }

        private void UserControlLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!IsLoaded)
            {
                ViewModel.NewCommand.Execute(new object());
                IsLoaded = true;
            }
        }

        public event EventHandler<DataEventArgs<CONSQL>> DataGridDetailSelectionChange;

        private void DetailsSelectedItemsChanged(object sender, SelectionChangeEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                if (DataGridDetailSelectionChange != null)
                    DataGridDetailSelectionChange(sender, new DataEventArgs<CONSQL>(e.AddedItems[0] as CONSQL));
            }
            else
                ViewModel.FormHeaderExpanded = false;
        }

        
    }
}