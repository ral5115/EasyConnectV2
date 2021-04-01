using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace EasyTools.Framework.UI
{
    public class FormButton : UserControl
    {
        static FormButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FormButton), new FrameworkPropertyMetadata(typeof(FormButton)));
        }

        public static readonly DependencyProperty FormButtonToolTipProperty = DependencyProperty.Register("FormButtonToolTip", typeof(object), typeof(FormButton), new UIPropertyMetadata(string.Empty));
        
        public string FormButtonToolTip
        {

            get { return (string)GetValue(FormButtonToolTipProperty); }
            set { SetValue(FormButtonToolTipProperty, value); }
        }

        public static readonly DependencyProperty FormButtonLabelProperty = DependencyProperty.Register("FormButtonLabel", typeof(object), typeof(FormButton), new UIPropertyMetadata(string.Empty));
        
        public string FormButtonLabel
        {

            get { return (string)GetValue(FormButtonLabelProperty); }
            set { SetValue(FormButtonLabelProperty, value); }
        }

        public static readonly DependencyProperty FormButtonCommandProperty = DependencyProperty.Register("FormButtonCommand", typeof(ICommand), typeof(FormButton));

        public ICommand FormButtonCommand
        {
            get { return base.GetValue(FormButtonCommandProperty) as ICommand; }
            set { base.SetValue(FormButtonCommandProperty, value); }
        }

        public static readonly DependencyProperty FormButtonIsEnableProperty = DependencyProperty.Register("FormButtonIsEnable", typeof(object), typeof(FormButton), new UIPropertyMetadata(true));
        
        public bool FormButtonIsEnable
        {

            get { return (bool)GetValue(FormButtonIsEnableProperty); }
            set { SetValue(FormButtonIsEnableProperty, value); }
        }

        public static readonly DependencyProperty FormButtonImageProperty = DependencyProperty.Register("FormButtonImage", typeof(object), typeof(FormButton), new UIPropertyMetadata(string.Empty));
        
        public ImageSource FormButtonImage
        {

            get { return (ImageSource)GetValue(FormButtonImageProperty); }
            set { SetValue(FormButtonImageProperty, value); }
        }

        public static readonly DependencyProperty FormButtonLabelVisibleProperty = DependencyProperty.Register("FormButtonLabelVisible", typeof(object), typeof(FormButton), new UIPropertyMetadata(Visibility.Visible));

        public Visibility FormButtonLabelVisible
        {

            get { return (Visibility)GetValue(FormButtonLabelVisibleProperty); }
            set { SetValue(FormButtonLabelVisibleProperty, value); }
        }
    }
}
