using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace EasyTools.Framework.UI
{

    [TemplatePart(Name = "PART_Expander", Type = typeof(Expander))]
    public sealed class FormNotification : System.Windows.Controls.Control
    {

        #region " Declarations "

        private Expander withEventsField__objErrorsExpander;

        private Expander _objErrorsExpander
        {
            get { return withEventsField__objErrorsExpander; }
            set
            {
                if (withEventsField__objErrorsExpander != null)
                {
                    withEventsField__objErrorsExpander.Collapsed -= _objErrorsExpander_Collapsed;
                    withEventsField__objErrorsExpander.Expanded -= _objErrorsExpander_Expanded;
                    withEventsField__objErrorsExpander.MouseEnter -= _objErrorsExpander_MouseEnter;
                    withEventsField__objErrorsExpander.MouseLeave -= _objErrorsExpander_MouseLeave;
                }
                withEventsField__objErrorsExpander = value;
                if (withEventsField__objErrorsExpander != null)
                {
                    withEventsField__objErrorsExpander.Collapsed += _objErrorsExpander_Collapsed;
                    withEventsField__objErrorsExpander.Expanded += _objErrorsExpander_Expanded;
                    withEventsField__objErrorsExpander.MouseEnter += _objErrorsExpander_MouseEnter;
                    withEventsField__objErrorsExpander.MouseLeave += _objErrorsExpander_MouseLeave;
                }
            }
        }
        private AdornerLayer _objErrorsExpanderAdornerLayer;

        private System.Timers.Timer withEventsField__objExpandedTimer;

        private System.Timers.Timer _objExpandedTimer
        {
            get { return withEventsField__objExpandedTimer; }
            set
            {
                if (withEventsField__objExpandedTimer != null)
                {
                    withEventsField__objExpandedTimer.Elapsed -= _objExpandedTimer_Elapsed;
                }
                withEventsField__objExpandedTimer = value;
                if (withEventsField__objExpandedTimer != null)
                {
                    withEventsField__objExpandedTimer.Elapsed += _objExpandedTimer_Elapsed;
                }
            }
        }
        private TextBlockAdorner withEventsField__objTextBlockAdorner;

        private TextBlockAdorner _objTextBlockAdorner
        {
            get { return withEventsField__objTextBlockAdorner; }
            set
            {
                if (withEventsField__objTextBlockAdorner != null)
                {
                    withEventsField__objTextBlockAdorner.MouseEnter -= _objTextBlockAdorner_MouseEnter;
                    withEventsField__objTextBlockAdorner.MouseLeave -= _objTextBlockAdorner_MouseLeave;
                }
                withEventsField__objTextBlockAdorner = value;
                if (withEventsField__objTextBlockAdorner != null)
                {
                    withEventsField__objTextBlockAdorner.MouseEnter += _objTextBlockAdorner_MouseEnter;
                    withEventsField__objTextBlockAdorner.MouseLeave += _objTextBlockAdorner_MouseLeave;
                }
            }
        }
        private delegate void ExpanderDelegate();

        #endregion

        #region " Shared Properties "

        public static DependencyProperty AutoCollapseTimeoutProperty = DependencyProperty.Register("AutoCollapseTimeout", typeof(double), typeof(FormNotification), new PropertyMetadata(2.0), new ValidateValueCallback(IsAutoCollapseTimeoutValid));
        public static DependencyProperty ErrorHeaderForegroundProperty = DependencyProperty.Register("ErrorHeaderForeground", typeof(Brush), typeof(FormNotification), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 208, 0, 0))));
        public static DependencyProperty ErrorHeaderTextProperty = DependencyProperty.Register("ErrorHeaderText", typeof(string), typeof(FormNotification), new PropertyMetadata("Edit Errors"));
        public static DependencyProperty ErrorMessageProperty = DependencyProperty.Register("ErrorMessage", typeof(string), typeof(FormNotification), new PropertyMetadata(string.Empty, new PropertyChangedCallback(OnErrorMessageChanged)));
        public static DependencyProperty ErrorPopUpBackgroundProperty = DependencyProperty.Register("ErrorPopUpBackground", typeof(Brush), typeof(FormNotification), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 253, 240, 151))));
        public static DependencyProperty ErrorPopUpForegroundProperty = DependencyProperty.Register("ErrorPopUpForeground", typeof(Brush), typeof(FormNotification), new PropertyMetadata(new SolidColorBrush(Colors.Black)));
        public static DependencyProperty NotificationMessageBackgroundProperty = DependencyProperty.Register("NotificationMessageBackground", typeof(Brush), typeof(FormNotification), new PropertyMetadata(new SolidColorBrush(Colors.LightGray)));
        public static DependencyProperty NotificationMessageForegroundProperty = DependencyProperty.Register("NotificationMessageForeground", typeof(Brush), typeof(FormNotification), new PropertyMetadata(new SolidColorBrush(Colors.Blue)));
        public static DependencyProperty NotificationMessageProperty = DependencyProperty.Register("NotificationMessage", typeof(string), typeof(FormNotification), new PropertyMetadata(string.Empty, new PropertyChangedCallback(OnNotificationMessageChanged)));
        public static DependencyProperty WatermarkMessageBackgroundProperty = DependencyProperty.Register("WatermarkMessageBackground", typeof(Brush), typeof(FormNotification));
        public static DependencyProperty WatermarkMessageForegroundProperty = DependencyProperty.Register("WatermarkMessageForeground", typeof(Brush), typeof(FormNotification), new PropertyMetadata(new SolidColorBrush(Colors.Gray)));

        public static DependencyProperty WatermarkMessageProperty = DependencyProperty.Register("WatermarkMessage", typeof(string), typeof(FormNotification), new PropertyMetadata(string.Empty));
        #endregion

        #region " Properties "

        [Category("Custom"), Description("Number of seconds the error pop remains expanded after the mouse leaves.  Default is 2 seconds.  Example 2.5 is 2 1/2 seconds.  Valid range is 0 - 100.  Zero means Auto Collapse is turned off.")]
        public double AutoCollapseTimeout
        {
            get { return Convert.ToDouble(GetValue(AutoCollapseTimeoutProperty)); }
            set
            {
                SetValue(AutoCollapseTimeoutProperty, value);

                if (_objExpandedTimer != null)
                {
                    _objExpandedTimer.Interval = value;
                }

            }
        }

        [Category("Custom"), Description("Error header text foreground brush.")]
        public Brush ErrorHeaderForeground
        {
            get { return (Brush)GetValue(ErrorHeaderForegroundProperty); }
            set { SetValue(ErrorHeaderForegroundProperty, value); }
        }

        [Category("Custom"), Description("Error header text that is displayed when there is an error on the form.  Setting this text property causes it to be displayed.  Normally this property is data bound to the Error property on an object data implements the IDataErrorInfo interface.")]
        public string ErrorHeaderText
        {
            get { return Convert.ToString(GetValue(ErrorHeaderTextProperty)); }
            set { SetValue(ErrorHeaderTextProperty, value); }
        }

        [Category("Custom"), Description("Error message that is displayed in the expander pop up.")]
        public string ErrorMessage
        {
            get { return Convert.ToString(GetValue(ErrorMessageProperty)); }
            set { SetValue(ErrorMessageProperty, value); }
        }

        [Category("Custom"), Description("Error message pop up background brush.")]
        public Brush ErrorPopUpBackground
        {
            get { return (Brush)GetValue(ErrorPopUpBackgroundProperty); }
            set { SetValue(ErrorPopUpBackgroundProperty, value); }
        }

        [Category("Custom"), Description("Error message pop up forground brush.")]
        public Brush ErrorPopUpForeground
        {
            get { return (Brush)GetValue(ErrorPopUpForegroundProperty); }
            set { SetValue(ErrorPopUpForegroundProperty, value); }
        }

        [Category("Custom"), Description("Notification message text.  If this property is set and their is no error message text, this text will be displayed.  This is normally set in after successful write or delete operations by the host form.")]
        public string NotificationMessage
        {
            get { return Convert.ToString(GetValue(NotificationMessageProperty)); }
            set { SetValue(NotificationMessageProperty, value); }
        }

        [Category("Custom"), Description("Notification message pop up background brush.")]
        public Brush NotificationMessageBackground
        {
            get { return (Brush)GetValue(NotificationMessageBackgroundProperty); }
            set { SetValue(NotificationMessageBackgroundProperty, value); }
        }

        [Category("Custom"), Description("Notification message pop up foreground brush.")]
        public Brush NotificationMessageForeground
        {
            get { return (Brush)GetValue(NotificationMessageForegroundProperty); }
            set { SetValue(NotificationMessageForegroundProperty, value); }
        }

        [Category("Custom"), Description("Watermark text message.  This is displayed if there is no error message text or notification message text.")]
        public string WatermarkMessage
        {
            get { return Convert.ToString(GetValue(WatermarkMessageProperty)); }
            set { SetValue(WatermarkMessageProperty, value); }
        }

        [Category("Custom"), Description("Watermark message pop up background brush.")]
        public Brush WatermarkMessageBackground
        {
            get { return (Brush)GetValue(WatermarkMessageBackgroundProperty); }
            set { SetValue(WatermarkMessageBackgroundProperty, value); }
        }

        [Category("Custom"), Description("Watermark message pop up foreground brush.")]
        public Brush WatermarkMessageForeground
        {
            get { return (Brush)GetValue(WatermarkMessageForegroundProperty); }
            set { SetValue(WatermarkMessageForegroundProperty, value); }
        }

        #endregion

        #region " Constructor and Initializer "

        static FormNotification()
        {
            //this.
            //Initialized += FormNotification_Initialized;
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FormNotification), new FrameworkPropertyMetadata(typeof(FormNotification)));

            
        }

        public FormNotification()
        {
            Initialized+=FormNotification_Initialized;
        }

        private void FormNotification_Initialized(object sender, System.EventArgs e) 
        {
            _objExpandedTimer = new System.Timers.Timer(AutoCollapseTimeout * 1000);
            _objExpandedTimer.Enabled = false;
            _objExpandedTimer.AutoReset = false;

        }

        #endregion

        #region " Methods "

        /// <summary>
        /// When the expander collapses, need to remove the TextBlock adorner
        /// </summary>

        private void _objErrorsExpander_Collapsed(object sender, System.Windows.RoutedEventArgs e)
        {
            if (_objErrorsExpanderAdornerLayer != null)
            {
                _objErrorsExpanderAdornerLayer.Remove(_objTextBlockAdorner);
                _objTextBlockAdorner = null;
                _objErrorsExpanderAdornerLayer = null;
            }

        }


        /// <summary>
        /// When the expander expands, need to put the error message in the
        /// adorner layer because the controls below it, may have their own
        /// adorner validation error messages, this places the expander
        /// popup on top of all other adorder layer elements. 
        /// </summary>

        private void _objErrorsExpander_Expanded(object sender, System.Windows.RoutedEventArgs e)
        {
            //this forces the ErrorMessage to be reread from it's source
            this.InvalidateProperty(ErrorMessageProperty);

            Grid objExpanderGrid = FindChilden.FindVisualChild<Grid>(_objErrorsExpander);
            //
            _objErrorsExpanderAdornerLayer = AdornerLayer.GetAdornerLayer(objExpanderGrid);

            string[] aryDelimiter = { "\r\n"};
            string[] aryErrorMessages = this.ErrorMessage.Split(aryDelimiter, StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(aryErrorMessages);

            TextBlock txt = new TextBlock();
            var _with1 = txt;
            _with1.Width = this.Width;
            _with1.TextWrapping = TextWrapping.Wrap;
            _with1.Text = string.Join("\r\n" + "\r\n", aryErrorMessages);
            _with1.Padding = new Thickness(5);
            _with1.Foreground = this.ErrorPopUpForeground;
            _with1.Background = this.ErrorPopUpBackground;
            _with1.BitmapEffect = new System.Windows.Media.Effects.DropShadowBitmapEffect();
            //
            //need to move the TextBlock down below the expander and indent a little
            TranslateTransform obj = new TranslateTransform(5, _objErrorsExpander.ActualHeight + 2);
            _with1.RenderTransform = obj;

            //
            _objTextBlockAdorner = new TextBlockAdorner(objExpanderGrid, txt);
            //
            _objErrorsExpanderAdornerLayer.Add(_objTextBlockAdorner);

        }

        private void _objErrorsExpander_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _objExpandedTimer.Stop();

        }


        private void _objErrorsExpander_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_objExpandedTimer.Interval > 0)
            {
                _objExpandedTimer.Start();
            }

        }

        /// <summary>
        /// Since WPF uses the STA threading model, another thread like a timer
        /// can not update the UI.  WPF provides a very simple technique for
        /// updating the UI from another thread.
        /// </summary>
        private void _objExpandedTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new ExpanderDelegate(CloseExpander));

        }

        private void _objTextBlockAdorner_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _objExpandedTimer.Stop();

        }


        private void _objTextBlockAdorner_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_objExpandedTimer.Interval > 0)
            {
                _objExpandedTimer.Start();
            }

        }

        /// <summary>
        /// This method is called when the error message or notification message
        /// property values are set and when the Time.Elapsed event fires.
        /// This ensures that the expander region is closed and the adorner layer
        /// is removed.
        /// </summary>
        /// <remarks></remarks>

        private void CloseExpander()
        {
            if (_objErrorsExpander != null && _objErrorsExpander.IsExpanded)
            {
                _objErrorsExpander.IsExpanded = false;
            }

        }

        /// <summary>
        /// This is the call back that gets called when the ErrorMessage
        /// dependency property is changed.
        /// </summary>

        private static void OnErrorMessageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FormNotification obj = (FormNotification)d;

            if (!string.IsNullOrEmpty(e.NewValue.ToString()))
            {
                obj.NotificationMessage = string.Empty;
            }

            obj.CloseExpander();

        }

        /// <summary>
        /// This is the call back that gets called when the NotificationMessage
        /// dependency property is changed.
        /// </summary>
        private static void OnNotificationMessageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((FormNotification)d).CloseExpander();
        }

        /// <summary>
        /// This method is called by the WPF Dependency Property system when the
        /// AutoCollapseTimeout value is set.
        /// </summary>
        public static bool IsAutoCollapseTimeoutValid(object value)
        {

            double dbl = Convert.ToDouble(value);

            if (dbl < 0 || dbl > 100)
            {
                return false;

            }
            else
            {
                return true;
            }

        }

        /// <summary>
        /// This is where you can get a reference to a control 
        /// inside the control template.  Notice the PART_ naming convention.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            //
            //Each object that you are getting a reference to here is also
            //listed in a TemplatePart attribute on the class.
            //
            //<TemplatePart(Name:="PART_Expander", Type:=GetType(Expander))> _
            //
            _objErrorsExpander = (Expander)GetTemplateChild("PART_Expander");

        }

        #endregion

    }

}
