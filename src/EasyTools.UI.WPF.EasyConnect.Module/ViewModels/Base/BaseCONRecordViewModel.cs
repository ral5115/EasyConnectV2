using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Framework.Resources;
using EasyTools.Framework.UI;
using EasyTools.Infrastructure.Entities;
using EasyTools.UI.Data;
using EasyTools.UI.WPF.EasyConnect.Module.Models;
using EasyTools.UI.WPF.EasyConnect.Module.Views;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Unity;
using System;
using System.ComponentModel;
using System.ServiceModel;
using System.Windows;

namespace EasyTools.UI.WPF.EasyConnect.Module.ViewModels.Base
{
   public class BaseCONRecordViewModel : BaseViewModel
   {

      protected readonly CONRecordView view;

      private readonly IUnityContainer container;

      public BaseCONRecordViewModel(IUnityContainer container, CONRecordView view)
          : base()
      {
         this.view = view;
         this.container = container;
         Model = new CONRecordModel();
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

      private CONRecordModel model;

      public CONRecordModel Model
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
            Model.Entity = new CONRecord();
            Model.Details = new BindingList<CONRecord>();
            Model.CheckAllRules();
            Model.PageSize = 1000;
            Model.CurrentPage = 1;
            Model.ParallelNumber = 5;
            PostNewAction();
         }
         catch (Exception ex)
         {
             PostNewAction(errorTitle: GetLocalizedMessage(Language.ApplicationError), errorMessage: new BusinessException(ex).GetExceptionMessage(), showMessageError: true, image: MessageBoxImage.Error);
         }
      }

      public override async void SaveAction(bool createNew)
      {
         //try
         //{
         //   if (Model.IsValid)
         //   {
         //      Model.UpdatedBy = EasyApp.Current.User.Login;
         //      CONRecord data = ((CONRecord) await EasyApp.Current.eToolsServer().ExecuteAsync(Model.Entity, (Model.Id == 0 ? Actions.Add : Actions.Modify), Options.Me, EasyApp.Current.DefaultDatabaseSettingName, ""));
         //      if (data != null)
         //      {
         //         if (Model.Details.IndexOf(data) != -1)
         //            Model.Details[Model.Details.IndexOf(data)] = data;
         //         else
         //            Model.Details.Add(data);
         //         Model.Entity = data;
         //      }
         //      PostSaveAction("");
         //      if (createNew)
         //      {
         //         MessageBoxResult result = MessageBox.Show("Registro guardado correctamente, desea crear un nuevo registro", "Nuevo Registro", MessageBoxButton.YesNo, MessageBoxImage.Question);
         //         if (result == MessageBoxResult.Yes)
         //            OnNewCommand(new object());
         //      }
         //   }
         //   else
         //   {
         //      MessageBox.Show("Hay validaciones pendientes por favor verifique.", "Informaci??n", MessageBoxButton.OK, MessageBoxImage.Information);
         //      PostSaveAction("Hay validaciones pendientes por favor verifique.");
         //   }
         //}
         //catch (FaultException ex)
         //{
         //   MessageBox.Show(new BusinessException(ex).GetExceptionMessage(), "Error", MessageBoxButton.OK);
         //   PostSaveAction(new BusinessException(ex).GetExceptionMessage());
         //}
         //catch (Exception ex)
         //{
         //   MessageBox.Show(new BusinessException(ex).GetExceptionMessage(), "Error", MessageBoxButton.OK);
         //   PostSaveAction(new BusinessException(ex).GetExceptionMessage());
         //}
      }

      public override async void DeleteAction()
      {
         //try
         //{
         //   if (Model.IsValid)
         //   {
         //      Model.UpdatedBy = EasyApp.Current.User.Login;
         //      CONRecord data = ((CONRecord) await EasyApp.Current.eToolsServer().ExecuteAsync(Model.Entity, Actions.Remove, Options.Me, EasyApp.Current.DefaultDatabaseSettingName, ""));
         //      if (data != null)
         //         Model.Details.Remove(data);
         //      PostDeleteAction("");
         //      MessageBoxResult result = MessageBox.Show("Registro eliminado correctamente", "Eliminando", MessageBoxButton.OK, MessageBoxImage.Question);
         //      OnNewCommand(new object());
         //   }
         //   else
         //   {
         //      MessageBox.Show("Hay validaciones pendientes por favor verifique.", "Informaci??n", MessageBoxButton.OK, MessageBoxImage.Information);
         //      PostDeleteAction("Hay validaciones pendientes por favor verifique.");
         //   }
         //}
         //catch (FaultException ex)
         //{
         //   MessageBox.Show(new BusinessException(ex).GetExceptionMessage(), "Error", MessageBoxButton.OK);
         //   PostDeleteAction(new BusinessException(ex).GetExceptionMessage());
         //}
         //catch (Exception ex)
         //{
         //   MessageBox.Show(new BusinessException(ex).GetExceptionMessage(), "Error", MessageBoxButton.OK);
         //   PostDeleteAction(new BusinessException(ex).GetExceptionMessage());
         //}
      }

      public override async void FindAction()
      {
          try
          {
              FormBusyMessage = "Buscando...";
              FormIsBusy = true;
              if (Model.PageSize > 0)
                  Model.HasPaging = true;
              CONRecord data = ((CONRecord)await EasyApp.Current.eToolsServer().ExecuteAsync(Model.Entity, Actions.Find, Options.All, EasyApp.Current.DefaultDatabaseSettingName, ""));
              if (data.Entities != null && data.Entities.Count > 0)
                  Model.Details = new BindingList<CONRecord>(data.Entities);
              PostFindAction("CONRecords", Model.Details.Count, "");
          }
          catch (FaultException ex)
          {
              MessageBox.Show(new BusinessException(ex).GetExceptionMessage(), "Error", MessageBoxButton.OK);
              FormIsBusy = false;
              PostFindAction("", 0, new BusinessException(ex).GetExceptionMessage());
          }
          catch (Exception ex)
          {
              MessageBox.Show(new BusinessException(ex).GetExceptionMessage(), "Error", MessageBoxButton.OK);
              FormIsBusy = false;
              PostFindAction("", 0, new BusinessException(ex).GetExceptionMessage());
          }
      }

      #endregion

      #region Events

      public virtual void OnDataGridDetailSelectionChange(object sender, DataEventArgs<CONRecord> e)
      {
         if (e.Value != null)
            Model.Entity = e.Value;
      }

      #endregion
   }

}
