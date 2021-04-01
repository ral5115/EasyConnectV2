using EasyTools.Framework.UI;
using System;

namespace EasyTools.UI.WPF.EasyConnect.Module.Views
{
    /// <summary>
    /// Interaction logic for SECUserView.xaml
    /// </summary>
    public partial class CONEquivalenceView : BaseUserControl
    {
        public event EventHandler<EventArgs> Value1Changed;

        private void FormFieldTextBox_Value1Changed(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (Value1Changed != null)
                Value1Changed(sender, e);
        }

        public event EventHandler<EventArgs> Value2Changed;

        private void FormFieldTextBox_Value2Changed(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (Value2Changed != null)
                Value2Changed(sender, e);
        }

        public event EventHandler<EventArgs> Value3Changed;

        private void FormFieldTextBox_Value3Changed(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (Value3Changed != null)
                Value3Changed(sender, e);
        }

        public event EventHandler<EventArgs> Value4Changed;

        private void FormFieldTextBox_Value4Changed(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (Value4Changed != null)
                Value4Changed(sender, e);
        }

        public event EventHandler<EventArgs> Value5Changed;

        private void FormFieldTextBox_Value5Changed(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (Value5Changed != null)
                Value5Changed(sender, e);
        }

        public event EventHandler<EventArgs> Value6Changed;

        private void FormFieldTextBox_Value6Changed(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (Value6Changed != null)
                Value6Changed(sender, e);
        }

        public event EventHandler<EventArgs> Value7Changed;

        private void FormFieldTextBox_Value7Changed(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (Value7Changed != null)
                Value7Changed(sender, e);
        }

        public event EventHandler<EventArgs> Value8Changed;

        private void FormFieldTextBox_Value8Changed(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (Value8Changed != null)
                Value8Changed(sender, e);
        }

        public event EventHandler<EventArgs> Value9Changed;

        private void FormFieldTextBox_Value9Changed(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (Value9Changed != null)
                Value9Changed(sender, e);
        }

        public event EventHandler<EventArgs> Value10Changed;

        private void FormFieldTextBox_Value10Changed(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (Value10Changed != null)
                Value10Changed(sender, e);
        }
    }
}