using EasyTools.Framework.Application;
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
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Windows;

namespace EasyTools.UI.WPF.Security.Module.ViewModels.Base
{
    public class BaseSECConnectionViewModel : BaseViewModel
    {

        private readonly SECConnectionView view;

        private readonly IUnityContainer container;

        public BaseSECConnectionViewModel(IUnityContainer container, SECConnectionView view)
            : base()
        {
            this.view = view;
            this.container = container;
            Model = new SECConnectionModel();
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

        private SECConnectionModel model;

        public SECConnectionModel Model
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
                Model.Entity = new SECConnection();
                Model.Details = new BindingList<SECConnection>();
                Model.CheckAllRules();
                EasyApp.Current.GetDBTypes();
                Model.Company = EasyApp.Current.Company;
                PostNewAction();
            }
            catch (Exception ex)
            {
                PostNewAction(errorTitle:GetLocalizedMessage(Language.ApplicationError), errorMessage: new BusinessException(ex).GetExceptionMessage(), showMessageError: true, image: MessageBoxImage.Error);
            }
        }

        public override async void SaveAction(bool createNew)
        {
            try
            {
                if (Model.IsValid)
                {
                    Model.UpdatedBy = EasyApp.Current.User.Login;
                    SECConnection data = null;
                    if (Model.Id == 0 && Permisions.FirstOrDefault(x => x.Id == 1).Active)
                        data = ((SECConnection)await EasyApp.Current.eToolsServer().ExecuteAsync(Model.Entity, Actions.Add, Options.Me, EasyApp.Current.DefaultDatabaseSettingName, ""));
                    else if (Model.Id != 0 && Permisions.FirstOrDefault(x => x.Id == 2).Active)
                        data = ((SECConnection)await EasyApp.Current.eToolsServer().ExecuteAsync(Model.Entity, Actions.Modify, Options.Me, EasyApp.Current.DefaultDatabaseSettingName, ""));
                    else
                        throw new Exception(GetLocalizedMessage(Language.ApplicationValidateSaveModified, ((Model.Id == 0) ? GetLocalizedMessage(Language.ApplicationAdd) : GetLocalizedMessage(Language.ApplicationModified))));
                    if (data != null)
                    {
                        if (Model.Details.IndexOf(data) != -1)
                            Model.Details[Model.Details.IndexOf(data)] = data;
                        else
                            Model.Details.Add(data);
                        Model.Entity = data;
                        PostSaveAction(createNew:true);
                    }
                }
                else
                    PostSaveAction(errorTitle:GetLocalizedMessage(Language.ApplicationInformation), errorMessage: GetLocalizedMessage(Language.ApplicationPendingValidations), showMessageError: true, createNew: false, image: MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                PostSaveAction(errorTitle:GetLocalizedMessage(Language.ApplicationError), errorMessage: new BusinessException(ex).GetExceptionMessage(), showMessageError: true, createNew: false, image : MessageBoxImage.Error );
            }
        }

        public override async void DeleteAction()
        {
            try
            {
                if (Model.IsValid)
                {
                    Model.UpdatedBy = EasyApp.Current.User.Login;
                    SECConnection data = null;
                    if (Permisions.FirstOrDefault(x => x.Id == 3).Active)
                        data = ((SECConnection)await EasyApp.Current.eToolsServer().ExecuteAsync(Model.Entity, Actions.Remove, Options.Me, EasyApp.Current.DefaultDatabaseSettingName, ""));
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
                SECConnection data = ((SECConnection)await EasyApp.Current.eToolsServer().ExecuteAsync(Model.Entity, Actions.Find, Options.All, EasyApp.Current.DefaultDatabaseSettingName, ""));
                if (data.Entities != null && data.Entities.Count > 0)
                    Model.Details = new BindingList<SECConnection>(data.Entities);
                else
                    Model.Details = new BindingList<SECConnection>();
                PostFindAction(queryName: "SECConnections", recordNumber: Model.Details.Count, errorMessage: "");
            }
            catch (Exception ex)
            {
                PostFindAction("", 0, new BusinessException(ex).GetExceptionMessage());
            }
        }

        #endregion

        #region Events

        public virtual void OnDataGridDetailSelectionChange(object sender, DataEventArgs<SECConnection> e)
        {
            if (e.Value != null)
                Model.Entity = e.Value;
        }

        #endregion
    }

}