using EasyTools.Framework.Application;
using EasyTools.Framework.Composite;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.UI;
using EasyTools.Infrastructure.Entities;
using EasyTools.UI.Data;
using EasyTools.UI.WPF.Models;
using EasyTools.UI.WPF.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Windows;
using System.Windows.Input;

namespace EasyTools.UI.WPF.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly ShellView shellView;

        public LoginViewModel(ShellView shellView)
        {
            this.shellView = shellView;
            this.OkCommand = new RelayCommand(OnOkCommand, CanOkCommand);
            this.CancelCommand = new RelayCommand(OnCancelCommand);
            this.LoadDatabaseSettingsCommand = new RelayCommand(OnLoadDatabaseSettingsCommand);
            this.Model = new LoginModel();
        }

        private LoginModel model;

        public LoginModel Model
        {
            get { return model; }
            set { SetProperty(ref model, value, "Model"); }
        }

        #region Properties

        private Visibility loginVisibility;

        public Visibility LoginVisibility
        {
            get { return loginVisibility; }
            set { SetProperty(ref loginVisibility, value, "LoginVisibility"); }
        }


        private bool isEnableControl;

        public bool IsEnableControl
        {
            get
            {
                return isEnableControl;
            }
            set
            {
                SetProperty(ref isEnableControl, value, "IsEnableControl");
            }
        }

        #endregion

        #region Commands

        public ICommand OkCommand { get; private set; }

        public ICommand CancelCommand { get; private set; }

        public ICommand LoadDatabaseSettingsCommand { get; private set; }

        #endregion

        #region Implemented Commands

        private void OnOkCommand(object obj)
        {
            try
            {
                Model.CheckAllRules();
                if (Model.IsValid)
                {
                    Mouse.OverrideCursor = Cursors.Wait;
                    SECUser auth = null;
                    if (shellView.ViewModel.Model.IsLogged && EasyApp.Current.User.Password == Crypto.EncrytedString(Model.Password))
                        auth = EasyApp.Current.User;
                    else if (shellView.ViewModel.Model.IsLogged && EasyApp.Current.User.Password != Crypto.EncrytedString(Model.Password))
                        auth = null;
                    else
                        auth = EasyApp.Current.eToolsServer().Authentication("", Model.Login, Crypto.EncrytedString(Model.Password), Model.DatabaseSetting.Name);
                    EasyApp.Current.DefaultDatabaseSetting = Model.DatabaseSetting;

                    if (auth != null)
                    {
                        if (auth.Role.Id == 1 && (auth.Role.RolePermissions == null || auth.Role.RolePermissions.Count == 0))
                        {
                            OnRefreshSecurity(auth.Role.Id);
                            auth = EasyApp.Current.eToolsServer().Authentication("", Model.Login, Crypto.EncrytedString(Model.Password), Model.DatabaseSetting.Name);
                        }
                        EasyApp.Current.User = auth;
                        //EasyApp.Current.User.UserCompanies = ((SECUserCompany)EasyApp.Current.eToolsServer().Execute(new SECUserCompany { UserId = auth.Id }, Actions.Find, Options.All, Model.DatabaseSetting.Name, "")).Entities;
                        if (EasyApp.Current.User.UserCompanies != null && EasyApp.Current.User.UserCompanies.Count > 0)
                            EasyApp.Current.ListCompanies = new BindingList<SECCompany>(EasyApp.Current.User.UserCompanies.Select(x => x.Company).ToList<SECCompany>());
                        if (EasyApp.Current.ListCompanies != null && EasyApp.Current.ListCompanies.Count > 0)
                            EasyApp.Current.Company = EasyApp.Current.ListCompanies[0];
                        shellView.ViewModel.Model.IsLogged = true;
                        shellView.ViewModel.Model.UserName = EasyApp.Current.User.Names + " " + EasyApp.Current.User.FatherLastName;
                        shellView.LoginViewT.Visibility = Visibility.Hidden;
                        if (shellView.Model.Menus != null && shellView.Model.Menus.Count > 0)
                        {
                            foreach (MenuModel menu in shellView.Model.Menus)
                            {
                                ActiveMenu(menu);
                                //if (menu.Permissions != null && menu.Permissions.Count > 0)
                                //{
                                //    foreach (Permission perm in menu.Permissions)
                                //    {
                                //        SECRolePermission exist = EasyApp.Current.User.Role.RolePermissions.FirstOrDefault(x => x.MenuId == menu.Id && x.PermissionId == perm.Id && x.Active == true);
                                //        if (exist != null)
                                //            menu.Visibility = Visibility.Visible;
                                //    }
                                //}
                            }
                        }
                        Mouse.OverrideCursor = Cursors.Arrow;
                    }
                    else
                    {
                        Mouse.OverrideCursor = Cursors.Arrow;
                        MessageBox.Show("Usuario o contraseña invalida", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    Mouse.OverrideCursor = Cursors.Arrow;
                    MessageBox.Show("Hay validaciones pendientes de verificar", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                //EasyApp.Current.GetTypes();
            }
            catch (FaultException ex)
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show(new BusinessException(ex).GetExceptionMessage(), "Error", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show(new BusinessException(ex).GetExceptionMessage(), "Error", MessageBoxButton.OK);
            }
        }

        private void ActiveMenu(MenuModel data)
        {
            foreach (MenuModel menu in data.ChildMenus)
            {
                if (menu.ChildMenus != null && menu.ChildMenus.Count > 0)
                {
                    foreach (MenuModel menuChild in menu.ChildMenus)
                    {
                        ActiveMenu(menuChild);
                    }
                }
                else if (menu.Permissions != null && menu.Permissions.Count > 0)
                {
                    foreach (Permission perm in menu.Permissions)
                    {
                        SECRolePermission exist = EasyApp.Current.User.Role.RolePermissions.FirstOrDefault(x => x.MenuId == menu.Id && x.PermissionId == perm.Id && x.Active == true);
                        if (exist != null)
                            menu.Visibility = Visibility.Visible;
                    }
                }
                if (menu.Visibility == Visibility.Visible)
                    data.Visibility = Visibility.Visible;
            }
        }

        private bool CanOkCommand(object obj)
        {
            return !string.IsNullOrWhiteSpace(Model.Login) && !string.IsNullOrWhiteSpace(Model.Password) && Model.DatabaseSetting != null;
        }

        private void OnCancelCommand(object obj)
        {
            shellView.Close();
        }
        private void OnLoadDatabaseSettingsCommand(object obj)
        {
            try
            {
                
                //EasyApp.Current.eToolsServer().InstallLocalData();
                if (EasyApp.Current.ListDatabaseSettings == null || EasyApp.Current.ListDatabaseSettings.Count == 0)
                    EasyApp.Current.ListDatabaseSettings = new BindingList<DatabaseSetting>(EasyApp.Current.Configuration.DataBaseSettings);
                //EasyApp.Current.GetTypes();
            }
            catch (Exception e)
            {
                MessageBox.Show(new BusinessException(e).GetExceptionMessage(), "Error", MessageBoxButton.OK);
            }
        }

        #endregion

        #region Methods

        public void SetLockedMode()
        {
            IsEnableControl = false;
        }

        public void SetNormalMode()
        {
            IsEnableControl = true;
        }

        public void OnRefreshSecurity(int roleId)
        {
            try
            {
                if (shellView.ViewModel.Model.Menus != null && shellView.ViewModel.Model.Menus.Count > 0)
                {
                    SECRolePermission permissions = new SECRolePermission();
                    permissions.UpdatedBy = "admin";
                    permissions.Entities = new List<SECRolePermission>();
                    foreach (MenuModel menu in shellView.ViewModel.Model.Menus)
                    {
                        if (menu != null && menu.Permissions != null && menu.Permissions.Count > 0)
                            foreach (var item in menu.Permissions)
                                permissions.Entities.Add(new SECRolePermission { MenuId = menu.Id, PermissionId = item.Id, RoleId = roleId, Active = true });
                        if (menu.ChildMenus != null && menu.ChildMenus.Count > 0)
                            foreach (MenuModel child in menu.ChildMenus)
                                foreach (var item in child.Permissions)
                                    permissions.Entities.Add(new SECRolePermission { MenuId = child.Id, PermissionId = item.Id, RoleId = roleId, Active = true });

                    }
                    EasyApp.Current.eToolsServer().Execute(permissions, Actions.Process, Options.All, EasyApp.Current.DefaultDatabaseSettingName, "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(new BusinessException(ex).GetExceptionMessage(), "Error", MessageBoxButton.OK);
                FormIsBusy = false;
            }
        }

        #endregion

    }
}
