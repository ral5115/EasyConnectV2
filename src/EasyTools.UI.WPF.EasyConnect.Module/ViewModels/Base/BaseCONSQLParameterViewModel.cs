using EasyTools.Framework.Application;
using EasyTools.Framework.UI;
using EasyTools.UI.Data;
//using EasyTools.UI.Data.Server;
using EasyTools.UI.WPF.EasyConnect.Module.Models;
using EasyTools.UI.WPF.EasyConnect.Module.Views;
using System;
using System.ServiceModel;
using System.Windows;
using System.Linq;
using Microsoft.Practices.Prism.PubSubEvents;
using EasyTools.Infrastructure.Entities;
using System.ComponentModel;
using EasyTools.Framework.Data;
using Microsoft.Practices.Unity;
using EasyTools.Framework.Resources;

namespace EasyTools.UI.WPF.EasyConnect.Module.ViewModels.Base
{
   public class BaseCONSQLParameterViewModel : BaseViewModel
   {

      private readonly CONSQLParameterView view;

      private readonly IUnityContainer container;

      public FormWindow Window { get; set; }

      public BaseCONSQLParameterViewModel(IUnityContainer container, CONSQLParameterView view)
          : base()
      {
         this.view = view;
         this.container = container;
         Model = new CONSQLParameterModel();
         this.view.DataGridDetailSelectionChange += OnDataGridDetailSelectionChange;
      }

      #region Model

      private CONSQLParameterModel model;

      public CONSQLParameterModel Model
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
            Model.Entity = new CONSQLParameter();
            Model.Details = new BindingList<CONSQLParameter>();
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
               CONSQLParameter data = ((CONSQLParameter) await EasyApp.Current.eToolsServer().ExecuteAsync(Model.Entity, (Model.Id == 0 ? Actions.Add : Actions.Modify), Options.Me, EasyApp.Current.DefaultDatabaseSettingName, ""));
               if (data != null)
               {
                  if (Model.Details.IndexOf(data) != -1)
                     Model.Details[Model.Details.IndexOf(data)] = data;
                  else
                     Model.Details.Add(data);
                  Model.Entity = data;
               }
               PostSaveAction("");
               if (createNew)
               {
                  MessageBoxResult result = MessageBox.Show("Registro guardado correctamente, desea crear un nuevo registro", "Nuevo Registro", MessageBoxButton.YesNo, MessageBoxImage.Question);
                  if (result == MessageBoxResult.Yes)
                     OnNewCommand(new object());
               }
            }
            else
            {
               MessageBox.Show("Hay validaciones pendientes por favor verifique.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
               PostSaveAction("Hay validaciones pendientes por favor verifique.");
            }
         }
         catch (FaultException ex)
         {
            MessageBox.Show(new BusinessException(ex).GetExceptionMessage(), "Error", MessageBoxButton.OK);
            PostSaveAction(new BusinessException(ex).GetExceptionMessage());
         }
         catch (Exception ex)
         {
            MessageBox.Show(new BusinessException(ex).GetExceptionMessage(), "Error", MessageBoxButton.OK);
            PostSaveAction(new BusinessException(ex).GetExceptionMessage());
         }
      }

      public override async void DeleteAction()
      {
         try
         {
            if (Model.IsValid)
            {
               Model.UpdatedBy = EasyApp.Current.User.Login;
               CONSQLParameter data = ((CONSQLParameter) await EasyApp.Current.eToolsServer().ExecuteAsync(Model.Entity, Actions.Remove, Options.Me, EasyApp.Current.DefaultDatabaseSettingName, ""));
               if (data != null)
                  Model.Details.Remove(data);
               PostDeleteAction("");
               MessageBoxResult result = MessageBox.Show("Registro eliminado correctamente", "Eliminando", MessageBoxButton.OK, MessageBoxImage.Question);
               OnNewCommand(new object());
            }
            else
            {
               MessageBox.Show("Hay validaciones pendientes por favor verifique.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
               PostDeleteAction("Hay validaciones pendientes por favor verifique.");
            }
         }
         catch (FaultException ex)
         {
            MessageBox.Show(new BusinessException(ex).GetExceptionMessage(), "Error", MessageBoxButton.OK);
            PostDeleteAction(new BusinessException(ex).GetExceptionMessage());
         }
         catch (Exception ex)
         {
            MessageBox.Show(new BusinessException(ex).GetExceptionMessage(), "Error", MessageBoxButton.OK);
            PostDeleteAction(new BusinessException(ex).GetExceptionMessage());
         }
      }

      public override async void FindAction()
      {
         try
         {
            CONSQLParameter data = ((CONSQLParameter) await EasyApp.Current.eToolsServer().ExecuteAsync(Model.Entity, Actions.Find, Options.All, EasyApp.Current.DefaultDatabaseSettingName, ""));
            //Model.Details = data.Entities;
            PostFindAction("CONSQLParameters", Model.Details.Count, "");
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

      public virtual void OnDataGridDetailSelectionChange(object sender, DataEventArgs<CONSQLParameter> e)
      {
         if (e.Value != null)
            Model.Entity = e.Value;
      }

      #endregion
   }

}
