using EasyTools.Framework.UI;
using System;

namespace EasyTools.UI.WPF.EasyConnect.Module.Views
{
    /// <summary>
    /// Interaction logic for SECUserView.xaml
    /// </summary>
    public partial class CONSQLParameterView : BaseUserControl
    {

        private void IsDateChecked(object sender, System.Windows.RoutedEventArgs e)
        {
            Model.IsInt = false;
            Model.Int32Value = null;
            Model.IsString = false;
            Model.StringValue = null;
        }

        private void IsIntChecked(object sender, System.Windows.RoutedEventArgs e)
        {
            Model.IsDate = false;
            Model.DateValue = null;
            Model.DefaultDateValue = null;
            Model.IsString = false;
            Model.StringValue = null;
        }

        private void IsStringChecked(object sender, System.Windows.RoutedEventArgs e)
        {
            Model.IsDate = false;
            Model.DateValue = null;
            Model.DefaultDateValue = null;
            Model.IsInt = false;
            Model.Int32Value = null;
        }

        private void FormFieldComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Model.DefaultDateValue = Model.SelectedDefaultDateValue.Int32Value;
        }
    }
}