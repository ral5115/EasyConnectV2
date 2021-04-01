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
    public partial class CONEquivalenceView : BaseUserControl
    {
        public CONEquivalenceView(IUnityContainer container)
        {
            InitializeComponent();
            ViewModel = new CONEquivalenceViewModel(container, this);
        }

        public CONEquivalenceViewModel ViewModel
        {
            get { return DataContext as CONEquivalenceViewModel; }
            set { DataContext = value; }
        }

        public CONEquivalenceModel Model
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

        public event EventHandler<DataEventArgs<CONEquivalence>> DataGridDetailSelectionChange;

        private void DetailsSelectedItemsChanged(object sender, SelectionChangeEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                if (DataGridDetailSelectionChange != null)
                    DataGridDetailSelectionChange(sender, new DataEventArgs<CONEquivalence>(e.AddedItems[0] as CONEquivalence));
            }
            else
                ViewModel.FormHeaderExpanded = false;
        }

    }
}