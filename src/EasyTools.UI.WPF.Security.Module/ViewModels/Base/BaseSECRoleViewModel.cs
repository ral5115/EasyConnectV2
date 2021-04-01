using EasyTools.Framework.Application;
using EasyTools.Framework.Composite;
using EasyTools.Framework.Data;
using EasyTools.Framework.Resources;
using EasyTools.Framework.UI;
using EasyTools.Infrastructure.Entities;
using EasyTools.UI.Data;
using EasyTools.UI.WPF.Security.Module.Models;
using EasyTools.UI.WPF.Security.Module.Views;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Windows;
using System.Windows.Input;

namespace EasyTools.UI.WPF.Security.Module.ViewModels.Base
{
    public class BaseSECRoleViewModel : BaseViewModel
    {

        private readonly SECRoleView view;

        private readonly IUnityContainer container;

        public BaseSECRoleViewModel(IUnityContainer container, SECRoleView view)
            : base()
        {
            this.view = view;
            this.container = container;
            Model = new SECRoleModel();
            this.view.DataGridDetailSelectionChange += OnDataGridDetailSelectionChange;
            this.RefreshSecurityCommand = new RelayCommand(OnRefreshSecurityCommand);
        }

        public override void RegisterPermisions()
        {
            //Save
            Permisions.Add(new Permission { Id = EasyApp.Current.GetPermission(1).Id, Description = EasyApp.Current.GetPermission(1).Description, EnDescription = EasyApp.Current.GetPermission(1).EnDescription, EsDescripcion = EasyApp.Current.GetPermission(1).EsDescripcion, Active = false });
            //Update
            Permisions.Add(new Permission { Id = EasyApp.Current.GetPermission(2).Id, Description = EasyApp.Current.GetPermission(2).Description, EnDescription = EasyApp.Current.GetPermission(2).EnDescription, EsDescripcion = EasyApp.Current.GetPermission(2).EsDescripcion, Active = false });
            //Delete
            Permisions.Add(new Permission { Id = EasyApp.Current.GetPermission(3).Id, Description = EasyApp.Current.GetPermission(3).Description, EnDescription = EasyApp.Current.GetPermission(3).EnDescription, EsDescripcion = EasyApp.Current.GetPermission(3).EsDescripcion, Active = false });
            //Query
            Permisions.Add(new Permission { Id = EasyApp.Current.GetPermission(4).Id, Description = EasyApp.Current.GetPermission(4).Description, EnDescription = EasyApp.Current.GetPermission(4).EnDescription, EsDescripcion = EasyApp.Current.GetPermission(4).EsDescripcion, Active = false });
        }

        #region Model

        private SECRoleModel model;

        public SECRoleModel Model
        {
            get { return model; }
            set { SetProperty(ref model, value, "Model"); }
        }

        #endregion

        #region Commands

        public override void NewAction()
        {
            try
            {
                Model.Entity = new SECRole();
                Model.Details = new BindingList<SECRole>();
                Model.RolePermissions = new BindingList<SECRolePermission>();
                Model.RoleMenuPermissions = new BindingList<MenuModel>();
                Model.CheckAllRules();
                PostNewAction();
            }
            catch (Exception ex)
            {
                PostNewAction(errorTitle: GetLocalizedMessage(Language.ApplicationError), errorMessage: new BusinessException(ex).GetExceptionMessage(), showMessageError: true, image: MessageBoxImage.Error);
            }
        }

        public override async void SaveAction(bool createNew)
        {
            try
            {
                if (Model.IsValid)
                {
                    Model.UpdatedBy = EasyApp.Current.User.Login;
                    if (Model.RoleMenuPermissions != null && Model.RoleMenuPermissions.Count > 0)
                    {
                        foreach (MenuModel menu in Model.RoleMenuPermissions)
                        {
                            if (menu.Permissions != null && menu.Permissions.Count > 0)
                            {
                                foreach (Permission perm in menu.Permissions)
                                {
                                    SECRolePermission exist = Model.RolePermissions.FirstOrDefault(x => x.MenuId == menu.Id && x.RoleId == Model.Id && x.PermissionId == perm.Id);
                                    if (exist != null)
                                        exist.Active = perm.Active;
                                    else
                                    {
                                        exist = new SECRolePermission();
                                        exist.Active = perm.Active;
                                        exist.MenuId = menu.Id;
                                        exist.RoleId = Model.Id;
                                        exist.PermissionId = perm.Id;
                                        Model.RolePermissions.Add(exist);
                                    }
                                }
                            }
                        }
                    }
                    SECRole data = null;
                    if (Model.Id == 0 && Permisions.FirstOrDefault(x => x.Id == 1).Active)
                        data = ((SECRole)await EasyApp.Current.eToolsServer().ExecuteAsync(Model.Entity, Actions.Add, Options.All, EasyApp.Current.DefaultDatabaseSettingName, ""));
                    else if (Model.Id != 0 && Permisions.FirstOrDefault(x => x.Id == 2).Active)
                        data = ((SECRole)await EasyApp.Current.eToolsServer().ExecuteAsync(Model.Entity, Actions.Modify, Options.All, EasyApp.Current.DefaultDatabaseSettingName, ""));
                    else
                        throw new Exception(GetLocalizedMessage(Language.ApplicationValidateSaveModified, ((Model.Id == 0) ? GetLocalizedMessage(Language.ApplicationAdd) : GetLocalizedMessage(Language.ApplicationModified))));
                    if (data != null)
                    {
                        if (Model.Details.IndexOf(data) != -1)
                            Model.Details[Model.Details.IndexOf(data)] = data;
                        else
                            Model.Details.Add(data);
                        Model.Entity = data;
                        PostSaveAction(createNew: true);
                    }
                }
                else
                    PostSaveAction(errorTitle: GetLocalizedMessage(Language.ApplicationInformation), errorMessage: GetLocalizedMessage(Language.ApplicationPendingValidations), showMessageError: true, createNew: false, image: MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                PostSaveAction(errorTitle: GetLocalizedMessage(Language.ApplicationError), errorMessage: new BusinessException(ex).GetExceptionMessage(), showMessageError: true, createNew: false, image: MessageBoxImage.Error);
            }
        }

              public override async void DeleteAction()
      {
         try
         {
            if (Model.IsValid)
            {
               Model.UpdatedBy = EasyApp.Current.User.Login;
               SECRole data = null;
               if (Permisions.FirstOrDefault(x => x.Id == 3).Active)
                  data = ((SECRole)await EasyApp.Current.eToolsServer().ExecuteAsync(Model.Entity, Actions.Remove, Options.Me, EasyApp.Current.DefaultDatabaseSettingName, ""));
               else
                  throw new Exception(GetLocalizedMessage(Language.ApplicationValidateSaveModified, GetLocalizedMessage(Language.ApplicationDelete)));
               if (data != null)
               {
                  Model.Details.Remove(data);
                  PostDeleteAction();
               }
            }
            else
               PostDeleteAction(errorTitle: GetLocalizedMessage(Language.ApplicationInformation), errorMessage: GetLocalizedMessage(Language.ApplicationPendingValidations), showMessageError: true, image: MessageBoxImage.Information);
         }
         catch (Exception ex)
         {
            PostDeleteAction(errorTitle: GetLocalizedMessage(Language.ApplicationError), errorMessage: new BusinessException(ex).GetExceptionMessage(),showMessageError:true, image:MessageBoxImage.Error);
         }
      }

      public override async void FindAction()
      {
         try
         {
            SECRole data = ((SECRole)await EasyApp.Current.eToolsServer().ExecuteAsync(Model.Entity, Actions.Find, Options.All, EasyApp.Current.DefaultDatabaseSettingName, ""));
            if (data.Entities != null && data.Entities.Count > 0)
               Model.Details = new BindingList<SECRole>(data.Entities);
            else
               Model.Details = new BindingList<SECRole>();
            PostFindAction(queryName: "SECRols", recordNumber: Model.Details.Count, errorMessage: "");
         }
         catch (Exception ex)
         {
            PostFindAction("", 0, new BusinessException(ex).GetExceptionMessage());
         }
      }



        //public override async void SaveAction(bool createNew)
        //{
        //    try
        //    {
        //        if (Model.IsValid)
        //        {
        //            Model.UpdatedBy = EasyApp.Current.User.Login;
        //            if (Model.RoleMenuPermissions != null && Model.RoleMenuPermissions.Count > 0)
        //            {
        //                foreach (MenuModel menu in Model.RoleMenuPermissions)
        //                {
        //                    if (menu.Permissions != null && menu.Permissions.Count > 0)
        //                    {
        //                        foreach (Permission perm in menu.Permissions)
        //                        {
        //                            SECRolePermission exist = Model.RolePermissions.FirstOrDefault(x => x.MenuId == menu.Id && x.RoleId == Model.Id && x.PermissionId == perm.Id);
        //                            if (exist != null)
        //                                exist.Active = perm.Active;
        //                            else
        //                            {
        //                                exist = new SECRolePermission();
        //                                exist.Active = perm.Active;
        //                                exist.MenuId = menu.Id;
        //                                exist.RoleId = Model.Id;
        //                                exist.PermissionId = perm.Id;
        //                                Model.RolePermissions.Add(exist);
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            SECRole data = ((SECRole)await EasyApp.Current.eToolsServer().ExecuteAsync(Model.Entity, (Model.Id == 0 ? Actions.Add : Actions.Modify), Options.All, EasyApp.Current.DefaultDatabaseSettingName, ""));
        //            if (data != null)
        //            {
        //                if (Model.Details.IndexOf(data) != -1)
        //                    Model.Details[Model.Details.IndexOf(data)] = data;
        //                else
        //                    Model.Details.Add(data);
        //                Model.Entity = data;
        //            }
        //            PostSaveAction("",false, createNew);
        //        }
        //        else
        //        {
        //            PostSaveAction("Hay validaciones pendientes por favor verifique.");
        //        }
        //    }
        //    catch (FaultException ex)
        //    {
        //        MessageBox.Show(new BusinessException(ex).GetExceptionMessage(), "Error", MessageBoxButton.OK);
        //        PostSaveAction(new BusinessException(ex).GetExceptionMessage());
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(new BusinessException(ex).GetExceptionMessage(), "Error", MessageBoxButton.OK);
        //        PostSaveAction(new BusinessException(ex).GetExceptionMessage());
        //    }
        //}

        //public override async void DeleteAction()
        //{
        //    try
        //    {
        //        if (Model.IsValid)
        //        {
        //            Model.UpdatedBy = EasyApp.Current.User.Login;
        //            SECRole data = ((SECRole)await EasyApp.Current.eToolsServer().ExecuteAsync(Model.Entity, Actions.Remove, Options.Me, EasyApp.Current.DefaultDatabaseSettingName, ""));
        //            if (data != null)
        //                Model.Details.Remove(data);
        //            PostDeleteAction("");
        //            MessageBoxResult result = MessageBox.Show("Registro eliminado correctamente", "Eliminando", MessageBoxButton.OK, MessageBoxImage.Question);
        //            OnNewCommand(new object());
        //        }
        //        else
        //        {
        //            MessageBox.Show("Hay validaciones pendientes por favor verifique.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
        //            PostDeleteAction("Hay validaciones pendientes por favor verifique.");
        //        }
        //    }
        //    catch (FaultException ex)
        //    {
        //        MessageBox.Show(new BusinessException(ex).GetExceptionMessage(), "Error", MessageBoxButton.OK);
        //        PostDeleteAction(new BusinessException(ex).GetExceptionMessage());
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(new BusinessException(ex).GetExceptionMessage(), "Error", MessageBoxButton.OK);
        //        PostDeleteAction(new BusinessException(ex).GetExceptionMessage());
        //    }
        //}

        //public override async void FindAction()
        //{
        //    try
        //    {
        //        SECRole data = ((SECRole)await EasyApp.Current.eToolsServer().ExecuteAsync(Model.Entity, Actions.Find, Options.All, EasyApp.Current.DefaultDatabaseSettingName, ""));
        //        if (data.Entities != null && data.Entities.Count > 0)
        //            Model.Details = new BindingList<SECRole>(data.Entities);
        //        else
        //            Model.Details = new BindingList<SECRole>();
        //        PostFindAction("SECRols", Model.Details.Count, "");
        //    }
        //    catch (FaultException ex)
        //    {
        //        MessageBox.Show(new BusinessException(ex).GetExceptionMessage(), "Error", MessageBoxButton.OK);
        //        FormIsBusy = false;
        //        PostFindAction("", 0, new BusinessException(ex).GetExceptionMessage());
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(new BusinessException(ex).GetExceptionMessage(), "Error", MessageBoxButton.OK);
        //        FormIsBusy = false;
        //        PostFindAction("", 0, new BusinessException(ex).GetExceptionMessage());
        //    }
        //}

        public ICommand RefreshSecurityCommand { get; protected set; }

        public void OnRefreshSecurityCommand(object obj)
        {
            try
            {
                var shell = container.Resolve<IShellView>();
                if (shell.ViewModel.Model.Menus != null && shell.ViewModel.Model.Menus.Count > 0)
                {
                    SECRolePermission permissions = new SECRolePermission();
                    permissions.UpdatedBy = EasyApp.Current.User.Login;
                    permissions.Entities = new List<SECRolePermission>();
                    foreach (MenuModel menu in shell.ViewModel.Model.Menus)
                    {
                        if (menu != null && menu.Permissions != null && menu.Permissions.Count > 0)
                            foreach (var item in menu.Permissions)
                                permissions.Entities.Add(new SECRolePermission { MenuId = menu.Id, PermissionId = item.Id, RoleId = Model.Id, Active = true });
                        if (menu.ChildMenus != null && menu.ChildMenus.Count > 0)
                            foreach (MenuModel child in menu.ChildMenus)
                                foreach (var item in child.Permissions)
                                    permissions.Entities.Add(new SECRolePermission { MenuId = child.Id, PermissionId = item.Id, RoleId = Model.Id, Active = true });

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

        #region Events

        public virtual void OnDataGridDetailSelectionChange(object sender, DataEventArgs<SECRole> e)
        {
            Model.Entity = new SECRole();
            Model.RolePermissions = new BindingList<SECRolePermission>();
            if (e.Value != null)
            {
                Model.Entity = (SECRole)EasyApp.Current.eToolsServer().Execute(new SECRole { Id = e.Value.Id }, Actions.Find, Options.Me, EasyApp.Current.DefaultDatabaseSettingName, "");
                Model.RoleMenuPermissions = new BindingList<MenuModel>();
                if (EasyApp.Current.ListMenuModels != null && EasyApp.Current.ListMenuModels.Count > 0)
                {
                    foreach (MenuModel menu in EasyApp.Current.ListMenuModels)
                    {
                        MenuModel add = new MenuModel { Id = menu.Id, Code = menu.Code, Name = menu.Name };
                        add.Permissions = new BindingList<Permission>();
                        if (menu != null && menu.Permissions != null && menu.Permissions.Count > 0)
                        {
                            foreach (Permission perm in menu.Permissions)
                            {
                                add.Permissions.Add(new Permission { Id = perm.Id, Description = perm.Description, EnDescription = perm.EnDescription, EsDescripcion = perm.EsDescripcion, Active = false });
                            }
                        }
                        Model.RoleMenuPermissions.Add(add);
                    }
                    if (Model.RoleMenuPermissions != null && Model.RoleMenuPermissions.Count > 0)
                    {
                        foreach (MenuModel menu in Model.RoleMenuPermissions)
                        {
                            if (menu.Permissions != null && menu.Permissions.Count > 0)
                            {
                                foreach (Permission perm in menu.Permissions)
                                {
                                    var rolPerm = Model.RolePermissions.FirstOrDefault(x => x.MenuId == menu.Id && x.PermissionId == perm.Id && x.Active == true);
                                    perm.Active = rolPerm == null ? false : true;
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion
    }
}