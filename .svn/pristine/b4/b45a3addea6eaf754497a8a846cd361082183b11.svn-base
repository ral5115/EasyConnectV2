using EasyTools.Framework.UI;
using EasyTools.Infrastructure.Entities;
using EasyTools.UI.WPF.Security.Module.Models;
using EasyTools.UI.WPF.Security.Module.ViewModels;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;

namespace EasyTools.UI.WPF.Security.Module.Views
{
    public partial class SECConnectionView : BaseUserControl
    {
        public SECConnectionView(IUnityContainer container)
            : base()
        {
            InitializeComponent();
            ViewModel = new SECConnectionViewModel(container, this);
        }

        public SECConnectionViewModel ViewModel
        {
            get { return DataContext as SECConnectionViewModel; }
            set { DataContext = value; }
        }

        public SECConnectionModel Model
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

        public event EventHandler<DataEventArgs<SECConnection>> DataGridDetailSelectionChange;

        private void DetailsSelectedItemsChanged(object sender, SelectionChangeEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                if (DataGridDetailSelectionChange != null)
                    DataGridDetailSelectionChange(sender, new DataEventArgs<SECConnection>(e.AddedItems[0] as SECConnection));
            }
            else
                ViewModel.FormHeaderExpanded = false;
        }
    }
}
