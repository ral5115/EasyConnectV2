using EasyConnect.Infrastructure.Entities;
using EasyTools.Framework.UI;
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
   public partial class WSCONCESIONESTIENDAView : BaseUserControl
   {
      public WSCONCESIONESTIENDAView(IUnityContainer container)
      {
         InitializeComponent();
         ViewModel = new WSCONCESIONESTIENDAViewModel(container, this);
      }

      public WSCONCESIONESTIENDAViewModel ViewModel
      {
         get { return DataContext as WSCONCESIONESTIENDAViewModel; }
         set { DataContext = value; }
      }

      public WSCONCESIONESTIENDAModel Model
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

      public event EventHandler<DataEventArgs<WSCONCESIONESTIENDA>> DataGridDetailSelectionChange;

      private void DetailsSelectedItemsChanged(object sender, SelectionChangeEventArgs e)
      {
         if (e.AddedItems != null && e.AddedItems.Count > 0)
         {
            if (DataGridDetailSelectionChange != null)
               DataGridDetailSelectionChange(sender, new DataEventArgs<WSCONCESIONESTIENDA>(e.AddedItems[0] as WSCONCESIONESTIENDA));
         }
         else
            ViewModel.FormHeaderExpanded = false;
      }

   }
}
