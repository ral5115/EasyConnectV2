using EasyTools.Framework.UI;
using EasyTools.Infrastructure.Entities;
using EasyTools.UI.WPF.EasyConnect.Module.ViewModels;
using Microsoft.Practices.Unity;
using System;
using System.Linq.Expressions;
using Telerik.Windows.Controls;

namespace EasyTools.UI.WPF.EasyConnect.Module.Views
{
    /// <summary>
    /// Interaction logic for SECUserView.xaml
    /// </summary>
    public partial class CONErrorView : BaseUserControl
    {
        public CONErrorView(IUnityContainer container)
        {
            InitializeComponent();
            ViewModel = new CONErrorViewModel(container, this);
            Expression<Func<CONError, string>> expression = parm => parm != null ? parm.RecordType.ToString() + parm.SubRecordType.ToString() + parm.Version.ToString() : null;
            GridViewExpressionColumn column = this.CONErrorViewGrid.Columns["ValueVersion"] as GridViewExpressionColumn;
            column.Expression = expression;

            Expression<Func<CONError, string>> expressionRecord = parm => parm != null ? parm.Record.Company.ToString() + "-" + parm.Record.OperationCenter.ToString() + "-" + parm.Record.DocumentType.ToString() + "-" + parm.Record.DocumentNumber.ToString() : null;
            GridViewExpressionColumn columnRecord = this.CONErrorViewGrid.Columns["ValueDocument"] as GridViewExpressionColumn;
            columnRecord.Expression = expressionRecord;
        }
    }
}