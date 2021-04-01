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
    public partial class CONRecordView : BaseUserControl
    {
        public CONRecordView(IUnityContainer container)
        {
            InitializeComponent();
            ViewModel = new CONRecordViewModel(container, this);
        }

        public CONRecordViewModel ViewModel
        {
            get { return DataContext as CONRecordViewModel; }
            set { DataContext = value; }
        }

        public CONRecordModel Model
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

        public event EventHandler<DataEventArgs<CONRecord>> DataGridDetailSelectionChange;

        private void DetailsSelectedItemsChanged(object sender, SelectionChangeEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                if (DataGridDetailSelectionChange != null)
                    DataGridDetailSelectionChange(sender, new DataEventArgs<CONRecord>(e.AddedItems[0] as CONRecord));
            }
            else
                ViewModel.FormHeaderExpanded = false;
        }

    }
}