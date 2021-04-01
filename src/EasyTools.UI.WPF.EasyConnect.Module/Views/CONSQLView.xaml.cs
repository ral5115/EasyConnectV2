using EasyTools.Framework.UI;
using EasyTools.Infrastructure.Entities;
using EasyTools.UI.WPF.EasyConnect.Module.ViewModels;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Unity;
using System;
using System.Linq.Expressions;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace EasyTools.UI.WPF.EasyConnect.Module.Views
{
    /// <summary>
    /// Interaction logic for SECUserView.xaml
    /// </summary>
    public partial class CONSQLView : BaseUserControl
    {
        public CONSQLView(IUnityContainer container, FormWindow window)
        {
            InitializeComponent();
            ViewModel = new CONSQLViewModel(container, this);
            ViewModel.Window = window;
            Expression<Func<CONSQLSend, string>> expression = parm => parm.CONIntegratorConfiguration != null ? "Nro Conección: " + parm.CONIntegratorConfiguration.ConnectionNumber + " Servidor: " + parm.CONIntegratorConfiguration.Connection.Service + " DB: " + parm.CONIntegratorConfiguration.Connection.DB + " Usuario: " + parm.CONIntegratorConfiguration.Connection.Login :null;
            GridViewExpressionColumn column = this.IntegratorConfigurationsGrid.Columns["ValueConnection"] as GridViewExpressionColumn;
            column.Expression = expression;
        }

        public event EventHandler<EventArgs> StructureChanged;

        private void FormFieldComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (StructureChanged != null)
                StructureChanged(sender, e);
        }

        public event EventHandler<DataEventArgs<CONSQLParameter>> EditParameter;

        //private void FormButton_EditParameter(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    if (EditParameter != null)
        //        EditParameter(sender, e);
        //}

        public event EventHandler<DataEventArgs<CONSQL>> EditChildSQL;

        private void GridChildSQL_RowActivated(object sender, RowEventArgs e)
        {
            if (EditChildSQL != null)
            {
                EditChildSQL(sender, new DataEventArgs<CONSQL>(e.Row.Item as CONSQL));
            }
        }

        private void ParameterGrid_RowActivated(object sender, RowEventArgs e)
        {
            if (EditParameter != null)
                EditParameter(sender, new DataEventArgs<CONSQLParameter>(e.Row.Item as CONSQLParameter));
        }

        public event EventHandler<EventArgs> GenerateFileChecked;
        private void FormFieldCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (GenerateFileChecked != null)
                GenerateFileChecked(sender, e);
        }

    }
}