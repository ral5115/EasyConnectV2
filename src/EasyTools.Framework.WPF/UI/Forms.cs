using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EasyTools.Framework.UI
{
    public class Forms : UserControl
    {
        static Forms()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Forms), new FrameworkPropertyMetadata(typeof(Forms)));
        }

        #region Contents

        // Using a DependencyProperty as the backing store for Footer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register("Header", typeof(object), typeof(Forms), new UIPropertyMetadata(null));
        public object Header
        {
            get { return (object)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Footer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BodyProperty = DependencyProperty.Register("Body", typeof(object), typeof(Forms), new UIPropertyMetadata(null));
        public object Body
        {
            get { return (object)GetValue(BodyProperty); }
            set { SetValue(BodyProperty, value); }
        }

        #endregion

        #region Toolbar

        public static readonly DependencyProperty FormNewCommandProperty = DependencyProperty.Register("FormNewCommand", typeof(ICommand), typeof(Forms));

        public ICommand FormNewCommand
        {
            get { return base.GetValue(FormNewCommandProperty) as ICommand; }
            set { base.SetValue(FormNewCommandProperty, value); }
        }

        public static readonly DependencyProperty FormEditCommandProperty = DependencyProperty.Register("FormEditCommand", typeof(ICommand), typeof(Forms));

        public ICommand FormEditCommand
        {
            get { return base.GetValue(FormEditCommandProperty) as ICommand; }
            set { base.SetValue(FormEditCommandProperty, value); }
        }

        public static readonly DependencyProperty FormDeleteCommandProperty = DependencyProperty.Register("FormDeleteCommand", typeof(ICommand), typeof(Forms));

        public ICommand FormDeleteCommand
        {
            get { return base.GetValue(FormDeleteCommandProperty) as ICommand; }
            set { base.SetValue(FormDeleteCommandProperty, value); }
        }

        public static readonly DependencyProperty FormSaveCommandProperty = DependencyProperty.Register("FormSaveCommand", typeof(ICommand), typeof(Forms));

        public ICommand FormSaveCommand
        {
            get { return base.GetValue(FormSaveCommandProperty) as ICommand; }
            set { base.SetValue(FormSaveCommandProperty, value); }
        }

        public static readonly DependencyProperty FormSaveNewCommandProperty = DependencyProperty.Register("FormSaveNewCommand", typeof(ICommand), typeof(Forms));

        public ICommand FormSaveNewCommand
        {
            get { return base.GetValue(FormSaveNewCommandProperty) as ICommand; }
            set { base.SetValue(FormSaveNewCommandProperty, value); }
        }

        public static readonly DependencyProperty FormFindCommandProperty = DependencyProperty.Register("FormFindCommand", typeof(ICommand), typeof(Forms));

        public ICommand FormFindCommand
        {
            get { return base.GetValue(FormFindCommandProperty) as ICommand; }
            set { base.SetValue(FormFindCommandProperty, value); }
        }

        #endregion

        #region Properties

        public static readonly DependencyProperty FormHeaderProperty = DependencyProperty.Register("FormHeader", typeof(object), typeof(Forms), new UIPropertyMetadata("Resultados"));
        public string FormHeader
        {
            get { return (string)GetValue(FormHeaderProperty); }
            set { SetValue(FormHeaderProperty, value); }
        }

        public static readonly DependencyProperty FormTitleProperty = DependencyProperty.Register("FormTitle", typeof(object), typeof(Forms), new UIPropertyMetadata(string.Empty));
        public string FormTitle
        {
            get { return (string)GetValue(FormTitleProperty); }
            set { SetValue(FormTitleProperty, value); }
        }

        public static readonly DependencyProperty FormWatermarkMessageProperty = DependencyProperty.Register("FormWatermarkMessage", typeof(object), typeof(Forms), new UIPropertyMetadata(string.Empty));
        public string FormWatermarkMessage
        {
            get { return (string)GetValue(FormWatermarkMessageProperty); }
            set { SetValue(FormWatermarkMessageProperty, value); }
        }

        public static readonly DependencyProperty FormErrorMessageProperty = DependencyProperty.Register("FormErrorMessage", typeof(object), typeof(Forms), new UIPropertyMetadata(string.Empty));
        public string FormErrorMessage
        {
            get { return (string)GetValue(FormErrorMessageProperty); }
            set { SetValue(FormErrorMessageProperty, value); }
        }

        public static readonly DependencyProperty FormNotificationMessageProperty = DependencyProperty.Register("FormNotificationMessage", typeof(object), typeof(Forms), new UIPropertyMetadata(string.Empty));
        public string FormNotificationMessage
        {

            get { return (string)GetValue(FormNotificationMessageProperty); }
            set { SetValue(FormNotificationMessageProperty, value); }
        }

        public static readonly DependencyProperty FormErrorsProperty = DependencyProperty.Register("FormErrors", typeof(object), typeof(Forms), new UIPropertyMetadata(string.Empty));
        public string FormErrors
        {

            get { return (string)GetValue(FormErrorsProperty); }
            set { SetValue(FormErrorsProperty, value); }
        }

        public static readonly DependencyProperty FormIsBusyProperty = DependencyProperty.Register("FormIsBusy", typeof(object), typeof(Forms), new UIPropertyMetadata(false));
        public bool FormIsBusy
        {

            get { return (bool)GetValue(FormIsBusyProperty); }
            set { SetValue(FormIsBusyProperty, value); }
        }

        public static readonly DependencyProperty FormBusyMessageProperty = DependencyProperty.Register("FormBusyMessage", typeof(object), typeof(Forms), new UIPropertyMetadata(string.Empty));
        public string FormBusyMessage
        {

            get { return (string)GetValue(FormBusyMessageProperty); }
            set { SetValue(FormBusyMessageProperty, value); }
        }

        public static readonly DependencyProperty FormHeaderVisibilityProperty = DependencyProperty.Register("FormHeaderVisibility", typeof(object), typeof(Forms), new UIPropertyMetadata(Visibility.Visible));
        public Visibility FormHeaderVisibility
        {

            get { return (Visibility)GetValue(FormHeaderVisibilityProperty); }
            set { SetValue(FormBusyMessageProperty, value); }
        }

        public static readonly DependencyProperty FormHeaderIsExpandedProperty = DependencyProperty.Register("FormHeaderIsExpanded", typeof(object), typeof(Forms), new UIPropertyMetadata(false));
        public bool FormHeaderIsExpanded
        {

            get { return (bool)GetValue(FormHeaderIsExpandedProperty); }
            set { SetValue(FormHeaderIsExpandedProperty, value); }
        }

        public static readonly DependencyProperty FormStatusMessageProperty = DependencyProperty.Register("FormStatusMessage", typeof(object), typeof(Forms), new UIPropertyMetadata(string.Empty));
        public string FormStatusMessage
        {

            get { return (string)GetValue(FormStatusMessageProperty); }
            set { SetValue(FormStatusMessageProperty, value); }
        }

        #endregion
    }
}
