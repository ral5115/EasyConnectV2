using System;
using System.Windows.Data;

namespace EasyTools.Framework.UI
{
    [ValueConversion(typeof(string), typeof(string), ParameterType = typeof(string))]
	public class FormNotificationErrorMessageConverter : IMultiValueConverter
	{

		#region " Methods "

		public object Convert(object[] values, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{

			System.Text.StringBuilder sb = new System.Text.StringBuilder(1024);

            foreach (object obj in values)
            {
                if (obj != null)
                    if (obj.ToString().Length > 0)
                    {
                        sb.AppendLine(obj.ToString());
                    }
            }

			return sb.ToString();
		}

		public object[] ConvertBack(object value, System.Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException();

		}

		#endregion

	}
}
