using EasyTools.Framework.UI;
using EasyTools.Infrastructure.Entities;
using EasyTools.UI.WPF.EasyConnect.Module.Models;
using EasyTools.UI.WPF.EasyConnect.Module.ViewModels;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Unity;
using System;
using System.ComponentModel;
using Telerik.Windows.Controls;
using System.Linq;
using System.Linq.Expressions;

namespace EasyTools.UI.WPF.EasyConnect.Module.Views
{
    public partial class CONSQLExecuteView : BaseUserControl
    {
        
        public CONSQLExecuteViewModel ViewModel
        {
            get { return DataContext as CONSQLExecuteViewModel; }
            set { DataContext = value; }
        }

        public CONSQLExecuteModel Model
        {
            get
            {
                return ViewModel.Model;
            }
        }

        public bool loaded { get; set; }

        private void UserControlLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!loaded)
            {
                ViewModel.NewCommand.Execute(new object());
                loaded = true;
            }
        }


        public event EventHandler<DataEventArgs<BindingList<CONSQL>>> DataGridDetailSelectionChanges;

        public event EventHandler ClearData;

        public virtual void DetailsSelectedItemsChanged(object sender, SelectionChangeEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                if (DataGridDetailSelectionChanges != null)
                {
                    BindingList<CONSQL> datas = new BindingList<CONSQL>();
                    foreach (var item in e.AddedItems)
                        datas.Add(item as CONSQL);
                    DataGridDetailSelectionChanges(sender, new DataEventArgs<BindingList<CONSQL>>(datas));
                }
            }
            else
            {
                if (ClearData != null)
                    ClearData(sender, new EventArgs());
            }
        }

    }
}