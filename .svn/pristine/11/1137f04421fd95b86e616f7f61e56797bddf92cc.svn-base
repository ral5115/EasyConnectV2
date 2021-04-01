using EasyTools.Framework.UI;
using System;

namespace EasyTools.UI.WPF.EasyConnect.Module.Views
{
    /// <summary>
    /// Interaction logic for SECUserView.xaml
    /// </summary>
    public partial class CONIntegratorConfigurationView : BaseUserControl
    {
        protected CONIntegratorConfigurationView view;


        private void FormFieldCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            
        }

        private void FormButton_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        public event EventHandler<EventArgs> ExportTypeChanged;
        private void FormFieldComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ExportTypeChanged != null)
                ExportTypeChanged(sender, e);
        }


    }
}