using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Framework.UI;
using EasyTools.Infrastructure.Entities;
using EasyTools.UI.Data;
using EasyTools.UI.WPF.Security.Module.Models;
using EasyTools.UI.WPF.Security.Module.Views;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Unity;
using System;
using System.ComponentModel;
using System.ServiceModel;
using System.Windows;
using System.Linq;
using EasyTools.Framework.Resources;

namespace EasyTools.UI.WPF.Security.Module.ViewModels.Base
{
    public class BaseSECUserViewModel : BaseViewModel
    {

        private readonly SECUserView view;

        private readonly IUnityContainer container;

        public BaseSECUserViewModel(IUnityContainer container, SECUserView view)
            : base()
        {
            this.view = view;
            this.container = container;
            Model = new SECUserModel();
            this.view.DataGridDetailSelectionChange += OnDataGridDetailSelectionChange;
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

        private SECUserModel model;

        public SECUserModel Model
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
                Model.Entity = new SECUser();
                Model.Details = new BindingList<SECUser>();
                Model.CheckAllRules();
                EasyApp.Current.GetRoles();
                PostNewAction();
            }
            catch (Exception ex)
            {
                PostNewAction(errorTitle: GetLocalizedMessage(Language.ApplicationError), errorMessage: new BusinessException(ex).GetExceptionMessage(), showMessageError: true, image: MessageBoxImage.Error);
            }
        }

        //public override void SaveAction(bool createNew)
        //{
        //    try
        //    {
        //        if (Model.IsValid)
        //        {
        //            //if (Permisions.FirstOrDefault(x => x.Id == 1).Active)
        //            //{
        //                Model.UpdatedBy = EasyApp.Current.User.Login;
        //                SECUser data = ((SECUser)EasyApp.Current.eToolsServer().Execute(Model.Entity, (Model.Id == 0 ? Actions.Add : Actions.Modify), Options.Me, EasyApp.Current.DefaultDatabaseSettingName, ""));
        //                if (data != null)
        //                {
        //                    if (Model.Details.IndexOf(data) != -1)
        //                        Model.Details[Model.Details.IndexOf(data)] = data;
        //                    else
        //                        Model.Details.Add(data);
        //                    Model.Entity = data;
        //                }
        //                PostSaveAction("");
        //                if (createNew)
        //                {
        //                    MessageBoxResult result = MessageBox.Show("Registro guardado correctamente, desea crear un nuevo registro", "Nuevo Registro", MessageBoxButton.YesNo, MessageBoxImage.Question);
        //                    if (result == MessageBoxResult.Yes)
        //                        OnNewCommand(new object());
        //                }
        //            //}
        //        }
        //        else
        //        {
        //            MessageBox.Show("Hay validaciones pendientes por favor verifique.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
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

        //public override void DeleteAction()
        //{
        //    try
        //    {
        //        if (Model.IsValid)
        //        {
        //            Model.UpdatedBy = EasyApp.Current.User.Login;
        //            SECUser data = ((SECUser)EasyApp.Current.eToolsServer().Execute(Model.Entity, Actions.Remove, Options.Me, EasyApp.Current.DefaultDatabaseSettingName, ""));
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

        //public override void FindAction()
        //{
        //    try
        //    {
        //        SECUser data = ((SECUser)EasyApp.Current.eToolsServer().Execute(Model.Entity, Actions.Find, Options.All, EasyApp.Current.DefaultDatabaseSettingName, ""));
        //        if (data.Entities != null && data.Entities.Count > 0)
        //            Model.Details = new BindingList<SECUser>(data.Entities);
        //        else
        //            Model.Details = new BindingList<SECUser>();
        //        PostFindAction("SECUsers", Model.Details.Count, "");
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

        public override async void SaveAction(bool createNew)
        {
            try
            {
                if (Model.IsValid)
                {
                    Model.UpdatedBy = EasyApp.Current.User.Login;
                    SECUser data = null;
                    if (Model.Id == 0 && Permisions.FirstOrDefault(x => x.Id == 1).Active)
                    {
                        data = ((SECUser)await EasyApp.Current.eToolsServer().ExecuteAsync(Model.Entity, Actions.Add, Options.Me, EasyApp.Current.DefaultDatabaseSettingName, ""));
                        var a = ((SECUserCompany)await EasyApp.Current.eToolsServer().ExecuteAsync(new SECUserCompany { UserId = data.Id, Active = data.Active, CompanyId = EasyApp.Current.Company.Id, UpdatedBy = data.UpdatedBy }, Actions.Add, Options.Me, EasyApp.Current.DefaultDatabaseSettingName, ""));
                        
                    }
                    else if (Model.Id != 0 && Permisions.FirstOrDefault(x => x.Id == 2).Active)
                        data = ((SECUser)await EasyApp.Current.eToolsServer().ExecuteAsync(Model.Entity, Actions.Modify, Options.Me, EasyApp.Current.DefaultDatabaseSettingName, ""));
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
                    SECUser data = null;
                    if (Permisions.FirstOrDefault(x => x.Id == 3).Active)
                        data = ((SECUser)await EasyApp.Current.eToolsServer().ExecuteAsync(Model.Entity, Actions.Remove, Options.Me, EasyApp.Current.DefaultDatabaseSettingName, ""));
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
                PostDeleteAction(errorTitle: GetLocalizedMessage(Language.ApplicationError), errorMessage: new BusinessException(ex).GetExceptionMessage(), showMessageError: true, image: MessageBoxImage.Error);
            }
        }

        public override async void FindAction()
        {
            try
            {
                SECUser data = ((SECUser)await EasyApp.Current.eToolsServer().ExecuteAsync(Model.Entity, Actions.Find, Options.All, EasyApp.Current.DefaultDatabaseSettingName, ""));
                if (data.Entities != null && data.Entities.Count > 0)
                    Model.Details = new BindingList<SECUser>(data.Entities);
                else
                    Model.Details = new BindingList<SECUser>();
                PostFindAction(queryName: "SECUsers", recordNumber: Model.Details.Count, errorMessage: "");
            }
            catch (Exception ex)
            {
                PostFindAction("", 0, new BusinessException(ex).GetExceptionMessage());
            }
        }
        #endregion

        #region Events

        public virtual void OnDataGridDetailSelectionChange(object sender, DataEventArgs<SECUser> e)
        {
            if (e.Value != null)
                Model.Entity = e.Value;
        }

        #endregion
    }

}