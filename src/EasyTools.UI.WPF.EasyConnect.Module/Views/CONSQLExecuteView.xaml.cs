using EasyTools.Framework.UI;
using EasyTools.Infrastructure.Entities;
using EasyTools.UI.Data;
using EasyTools.UI.WPF.EasyConnect.Module.ViewModels;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Unity;
using System;
using System.Linq.Expressions;
using Telerik.Windows.Controls;
using System.Linq;

namespace EasyTools.UI.WPF.EasyConnect.Module.Views
{
    /// <summary>
    /// Interaction logic for CONSQLExecute.xaml
    /// </summary>
    public partial class CONSQLExecuteView : BaseUserControl
    {

        public CONSQLExecuteView(IUnityContainer container)
        {
            InitializeComponent();
            ViewModel = new CONSQLExecuteViewModel(container, this);
            Expression<Func<CONSQLParameter, string>> expression = parm => parm.DateValue != null ? parm.DateValue.ToString() 
                : parm.DefaultDateValue != null ? EasyApp.Current.ListDefaultDateValues.FirstOrDefault(x => x.Int32Value == parm.DefaultDateValue).Name
                : parm.Int32Value != null ? parm.Int32Value.ToString() 
                : parm.StringValue;
            GridViewExpressionColumn column = this.ParameterGrid.Columns["Value"] as GridViewExpressionColumn;
            column.Expression = expression;

            Expression<Func<CONSQLSend, string>> expressionSend = parm => parm.CONIntegratorConfiguration != null  ? "Nro Conección: " + parm.CONIntegratorConfiguration.ConnectionNumber + " Servidor: " + parm.CONIntegratorConfiguration.Connection.Service + " DB: " + parm.CONIntegratorConfiguration.Connection.DB + " Usuario: " + parm.CONIntegratorConfiguration.Connection.Login : null;
            GridViewExpressionColumn columnSend = this.IntegratorConfigurationsGrid.Columns["ValueConnection"] as GridViewExpressionColumn;
            columnSend.Expression = expressionSend;
        }

        public event EventHandler<DataEventArgs<CONSQLParameter>> EditParameter;

        private void ParameterGrid_RowActivated(object sender, Telerik.Windows.Controls.GridView.RowEventArgs e)
        {
            if (EditParameter != null)
                EditParameter(sender, new DataEventArgs<CONSQLParameter>(e.Row.Item as CONSQLParameter));
        }

    }
}