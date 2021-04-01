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
   public partial class WSEquivalenciasFormasPagoView : BaseUserControl
   {
      public WSEquivalenciasFormasPagoView(IUnityContainer container)
      {
         InitializeComponent();
         ViewModel = new WSEquivalenciasFormasPagoViewModel(container, this);
      }

      public WSEquivalenciasFormasPagoViewModel ViewModel
      {
         get { return DataContext as WSEquivalenciasFormasPagoViewModel; }
         set { DataContext = value; }
      }

      public WSEquivalenciasFormasPagoModel Model
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

      public event EventHandler<DataEventArgs<CONWSEquivalenciasFormasPago>> DataGridDetailSelectionChange;

      private void DetailsSelectedItemsChanged(object sender, SelectionChangeEventArgs e)
      {
         if (e.AddedItems != null && e.AddedItems.Count > 0)
         {
            if (DataGridDetailSelectionChange != null)
                DataGridDetailSelectionChange(sender, new DataEventArgs<CONWSEquivalenciasFormasPago>(e.AddedItems[0] as CONWSEquivalenciasFormasPago));
         }
         else
            ViewModel.FormHeaderExpanded = false;
      }

   }
}
