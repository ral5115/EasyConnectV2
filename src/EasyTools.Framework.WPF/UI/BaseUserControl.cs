using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace EasyTools.Framework.UI
{
    public class BaseUserControl : UserControl, IView
    {

        public virtual void SaveClick(Object sender, RoutedEventArgs e)
        {
        }


    }
}