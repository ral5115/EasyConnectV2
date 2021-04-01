using System;
using System.Windows.Data;

namespace EasyTools.Framework.UI
{
    [ValueConversion(typeof(string), typeof(bool))]
    public class StringLengthToBooleanConverter : IValueConverter
    {

        #region " Methods "

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();

        }

        #endregion

    }

}