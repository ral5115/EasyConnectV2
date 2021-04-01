using System.Windows;
using System.Windows.Controls;

namespace EasyTools.Framework.UI
{
    public class FormTitle : UserControl
    {
        static FormTitle()
        {

        }

        #region Contents

        // Using a DependencyProperty as the backing store for Footer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(object), typeof(FormTitle), new UIPropertyMetadata(null));
        public object Title
        {
            get { return (object)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }


        #endregion
    }
}
