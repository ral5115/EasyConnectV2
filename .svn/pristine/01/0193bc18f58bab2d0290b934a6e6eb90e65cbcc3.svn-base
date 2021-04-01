using System.ComponentModel;
using System.Globalization;

namespace EasyTools.Framework.Resources
{
    public class Languages : INotifyPropertyChanged
    {
        public static Languages Provider;

        public Languages()
        {
            Provider = this;
        }

        private readonly Language recursos = new Language();

        public Language Resources
        {
            get { return recursos; }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Change the culture for the application.
        /// </summary>
        /// <param name="culture">Full culture name</param>
        public void ChangeCulture(CultureInfo culture)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Threading.Thread.CurrentThread.CurrentUICulture;
            //Strings.Culture = System.Threading.Thread.CurrentThread.CurrentUICulture;

            // notify that the culture has changed
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
                handler(this, new PropertyChangedEventArgs("Resources"));
        }

        #endregion

    }
}