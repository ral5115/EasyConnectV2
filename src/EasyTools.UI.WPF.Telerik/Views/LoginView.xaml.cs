using EasyTools.Framework.UI;
using EasyTools.UI.WPF.Models;
using EasyTools.UI.WPF.ViewModels;
using System;
using System.ComponentModel.Composition;

namespace EasyTools.UI.WPF.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : BaseUserControl
    {
        public LoginView()
            : base()
        {
            InitializeComponent();
        }

        public LoginViewModel ViewModel
        {
            get
            {
                return DataContext as LoginViewModel;
            }
            set
            {
                DataContext = value;
            }
        }

        public LoginModel Model
        {
            get
            {
                return ViewModel.Model;
            }
        }

    }

}
