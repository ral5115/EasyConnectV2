using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EasyTools.Framework.UI
{
    public class FormToolbar : UserControl
    {
        static FormToolbar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FormToolbar), new FrameworkPropertyMetadata(typeof(FormToolbar)));
        }

        #region Toolbar

        public static readonly DependencyProperty FormNewCommandProperty = DependencyProperty.Register("FormNewCommand", typeof(ICommand), typeof(FormToolbar));

        public ICommand FormNewCommand
        {
            get { return base.GetValue(FormNewCommandProperty) as ICommand; }
            set { base.SetValue(FormNewCommandProperty, value); }
        }

        public static readonly DependencyProperty FormEditCommandProperty = DependencyProperty.Register("FormEditCommand", typeof(ICommand), typeof(FormToolbar));

        public ICommand FormEditCommand
        {
            get { return base.GetValue(FormEditCommandProperty) as ICommand; }
            set { base.SetValue(FormEditCommandProperty, value); }
        }

        public static readonly DependencyProperty FormDeleteCommandProperty = DependencyProperty.Register("FormDeleteCommand", typeof(ICommand), typeof(FormToolbar));

        public ICommand FormDeleteCommand
        {
            get { return base.GetValue(FormDeleteCommandProperty) as ICommand; }
            set { base.SetValue(FormDeleteCommandProperty, value); }
        }

        public static readonly DependencyProperty FormSaveCommandProperty = DependencyProperty.Register("FormSaveCommand", typeof(ICommand), typeof(FormToolbar));

        public ICommand FormSaveCommand
        {
            get { return base.GetValue(FormSaveCommandProperty) as ICommand; }
            set { base.SetValue(FormSaveCommandProperty, value); }
        }

        public static readonly DependencyProperty FormSaveNewCommandProperty = DependencyProperty.Register("FormSaveNewCommand", typeof(ICommand), typeof(FormToolbar));

        public ICommand FormSaveNewCommand
        {
            get { return base.GetValue(FormSaveNewCommandProperty) as ICommand; }
            set { base.SetValue(FormSaveNewCommandProperty, value); }
        }

        public static readonly DependencyProperty FormFindCommandProperty = DependencyProperty.Register("FormFindCommand", typeof(ICommand), typeof(FormToolbar));

        public ICommand FormFindCommand
        {
            get { return base.GetValue(FormFindCommandProperty) as ICommand; }
            set { base.SetValue(FormFindCommandProperty, value); }
        }

        #endregion
    }
}
