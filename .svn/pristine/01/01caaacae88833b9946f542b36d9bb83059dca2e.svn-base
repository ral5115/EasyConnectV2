using System;
using System.Windows.Controls;
using System.Windows.Data;

namespace EasyTools.Framework.UI
{

    [ValueConversion(typeof(ValidationError), typeof(string))]
    public class ValdiationErrorGetErrorMessageConverter : IValueConverter
    {

        #region " Methods "

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            System.Text.StringBuilder sb = new System.Text.StringBuilder(1024);

            foreach (ValidationError objVB in (System.Collections.ObjectModel.ReadOnlyObservableCollection<ValidationError>)value)
            {
                if (objVB.Exception == null || objVB.Exception.InnerException == null)
                {
                    sb.AppendLine(objVB.ErrorContent.ToString());

                }
                else
                {
                    sb.AppendLine(objVB.Exception.InnerException.Message);
                }

            }

            //remove the last line feed
            if (sb.Length > 2)
            {
                sb.Length -= 2;
            }

            return sb.ToString();
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion

    }
}
