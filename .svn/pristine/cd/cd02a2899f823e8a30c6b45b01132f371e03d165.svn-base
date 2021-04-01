using EasyTools.Framework.Application;
using EasyTools.Framework.UI;
using EasyTools.UI.Data;
using EasyTools.Framework.Resources;

using EasyTools.UI.WPF.EasyConnect.Module.Models;
using EasyTools.UI.WPF.EasyConnect.Module.Views;
using System;

using System.Windows;
using System.Linq;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Unity;
using EasyTools.Framework.Data;
using EasyConnect.Infrastructure.Entities;
using System.ComponentModel;

namespace EasyTools.UI.WPF.EasyConnect.Module.ViewModels.Base
{
   public class BaseWSCONCESIONESTIENDAViewModel : BaseViewModel
   {

      protected readonly WSCONCESIONESTIENDAView view;

      protected readonly IUnityContainer container;

      public BaseWSCONCESIONESTIENDAViewModel(IUnityContainer container,WSCONCESIONESTIENDAView view)  : base()
      {
         this.view = view;
         this.container = container;
         Model = new WSCONCESIONESTIENDAModel();
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

      private WSCONCESIONESTIENDAModel model;

      public WSCONCESIONESTIENDAModel Model
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
            Model.Entity = new WSCONCESIONESTIENDA();
            Model.Details = new BindingList<WSCONCESIONESTIENDA>();
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
               WSCONCESIONESTIENDA data  = ((WSCONCESIONESTIENDA)await EasyApp.Current.eToolsServer().ExecuteAsync(Model.Entity, (Model.Id == 0 ? Actions.Add : Actions.Modify), Options.Me, EasyApp.Current.DefaultDatabaseSettingName, ""));
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
               WSCONCESIONESTIENDA data  = ((WSCONCESIONESTIENDA)await EasyApp.Current.eToolsServer().ExecuteAsync(Model.Entity, Actions.Remove, Options.Me, EasyApp.Current.DefaultDatabaseSettingName, ""));
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
            WSCONCESIONESTIENDA data = ((WSCONCESIONESTIENDA)await EasyApp.Current.eToolsServer().ExecuteAsync(Model.Entity, Actions.Find, Options.All, EasyApp.Current.DefaultDatabaseSettingName, ""));
            if (data.Entities != null && data.Entities.Count > 0)
               Model.Details = new BindingList<WSCONCESIONESTIENDA>(data.Entities);
            else
               Model.Details = new BindingList<WSCONCESIONESTIENDA>();
            PostFindAction(queryName: "WS_CONCESIONES_TIENDAS", recordNumber: Model.Details.Count, errorMessage: "");
         }
         catch (Exception ex)
         {
            PostFindAction("", 0, new BusinessException(ex).GetExceptionMessage());
         }
      }

      #endregion

      #region Events

      public virtual void OnDataGridDetailSelectionChange(object sender, DataEventArgs<WSCONCESIONESTIENDA> e)
      {
         if (e.Value != null)
            Model.Entity = e.Value;
      }

      #endregion
   }

}
