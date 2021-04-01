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
   public class BaseCONEquivalenceViewModel : BaseViewModel
   {

      private readonly CONEquivalenceView view;

      private readonly IUnityContainer container;

      public BaseCONEquivalenceViewModel(IUnityContainer container, CONEquivalenceView view)
          : base()
      {
         this.view = view;
         this.container = container;
         Model = new CONEquivalenceModel();
         this.view.DataGridDetailSelectionChange += OnDataGridDetailSelectionChange;
         this.view.Value1Changed += view_Value1Changed;
         this.view.Value2Changed += view_Value2Changed;
         this.view.Value3Changed += view_Value3Changed;
         this.view.Value4Changed += view_Value4Changed;
         this.view.Value5Changed += view_Value5Changed;
         this.view.Value6Changed += view_Value6Changed;
         this.view.Value7Changed += view_Value7Changed;
         this.view.Value8Changed += view_Value8Changed;
         this.view.Value9Changed += view_Value9Changed;
         this.view.Value10Changed += view_Value10Changed;
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

      void view_Value10Changed(object sender, EventArgs e)
      {
          if (!String.IsNullOrEmpty(((FormFieldTextBox)sender).Text))
          {
              view.DataGridEquivalenceDetail.Columns["Value10"].IsVisible = true;
              view.DataGridEquivalenceDetail.Columns["Value10"].Header = ((FormFieldTextBox)sender).Text;
          }
          else
          view.DataGridEquivalenceDetail.Columns["Value10"].IsVisible = false;
      }

      void view_Value9Changed(object sender, EventArgs e)
      {
          if (!String.IsNullOrEmpty(((FormFieldTextBox)sender).Text))
          {
              view.DataGridEquivalenceDetail.Columns["Value9"].IsVisible = true;
              view.DataGridEquivalenceDetail.Columns["Value9"].Header = ((FormFieldTextBox)sender).Text;
          }
          else
          view.DataGridEquivalenceDetail.Columns["Value9"].IsVisible = false;
      }

      void view_Value8Changed(object sender, EventArgs e)
      {
          if (!String.IsNullOrEmpty(((FormFieldTextBox)sender).Text))
          {
              view.DataGridEquivalenceDetail.Columns["Value8"].IsVisible = true;
              view.DataGridEquivalenceDetail.Columns["Value8"].Header = ((FormFieldTextBox)sender).Text;
          }
          else
          view.DataGridEquivalenceDetail.Columns["Value8"].IsVisible = false;
      }

      void view_Value7Changed(object sender, EventArgs e)
      {
          if (!String.IsNullOrEmpty(((FormFieldTextBox)sender).Text))
          {
              view.DataGridEquivalenceDetail.Columns["Value7"].IsVisible = true;
              view.DataGridEquivalenceDetail.Columns["Value7"].Header = ((FormFieldTextBox)sender).Text;
          }
          else
              view.DataGridEquivalenceDetail.Columns["Value7"].IsVisible = false;
      }

      void view_Value6Changed(object sender, EventArgs e)
      {
          if (!String.IsNullOrEmpty(((FormFieldTextBox)sender).Text))
          {
              view.DataGridEquivalenceDetail.Columns["Value6"].IsVisible = true;
              view.DataGridEquivalenceDetail.Columns["Value6"].Header = ((FormFieldTextBox)sender).Text;
          }
          else
              view.DataGridEquivalenceDetail.Columns["Value6"].IsVisible = false;
      }

      void view_Value5Changed(object sender, EventArgs e)
      {
          if (!String.IsNullOrEmpty(((FormFieldTextBox)sender).Text))
          {
              view.DataGridEquivalenceDetail.Columns["Value5"].IsVisible = true;
              view.DataGridEquivalenceDetail.Columns["Value5"].Header = ((FormFieldTextBox)sender).Text;
          }
          else
              view.DataGridEquivalenceDetail.Columns["Value5"].IsVisible = false;
      }

      void view_Value4Changed(object sender, EventArgs e)
      {
          if (!String.IsNullOrEmpty(((FormFieldTextBox)sender).Text))
          {
              view.DataGridEquivalenceDetail.Columns["Value4"].IsVisible = true;
              view.DataGridEquivalenceDetail.Columns["Value4"].Header = ((FormFieldTextBox)sender).Text;
          }
          else
              view.DataGridEquivalenceDetail.Columns["Value4"].IsVisible = false;
      }

      void view_Value3Changed(object sender, EventArgs e)
      {
          if (!String.IsNullOrEmpty(((FormFieldTextBox)sender).Text))
          {
              view.DataGridEquivalenceDetail.Columns["Value3"].IsVisible = true;
              view.DataGridEquivalenceDetail.Columns["Value3"].Header = ((FormFieldTextBox)sender).Text;
          }
          else
              view.DataGridEquivalenceDetail.Columns["Value3"].IsVisible = false;
      }

      void view_Value2Changed(object sender, EventArgs e)
      {
          if (!String.IsNullOrEmpty(((FormFieldTextBox)sender).Text))
          {
              view.DataGridEquivalenceDetail.Columns["Value2"].IsVisible = true;
              view.DataGridEquivalenceDetail.Columns["Value2"].Header = ((FormFieldTextBox)sender).Text;
          }
          else
              view.DataGridEquivalenceDetail.Columns["Value2"].IsVisible = false;
      }

      void view_Value1Changed(object sender, EventArgs e)
      {
          if (!String.IsNullOrEmpty(((FormFieldTextBox)sender).Text))
          {
             
              view.DataGridEquivalenceDetail.Columns["Value1"].Header = ((FormFieldTextBox)sender).Text;
              view.DataGridEquivalenceDetail.Columns["Value1"].IsVisible = true;
          }
          else
              view.DataGridEquivalenceDetail.Columns["Value1"].IsVisible =false;
      }

      #region Model

      private CONEquivalenceModel model;

      public CONEquivalenceModel Model
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
            Model.Entity = new CONEquivalence();
            Model.Details = new BindingList<CONEquivalence>();
            Model.EquivalenceDetails = new BindingList<CONEquivalenceDetail>();
            Model.CheckAllRules();
            Model.Company = EasyApp.Current.Company;
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
               CONEquivalence data = ((CONEquivalence) await EasyApp.Current.eToolsServer().ExecuteAsync(Model.Entity, (Model.Id == 0 ? Actions.Add : Actions.Modify), Options.All, EasyApp.Current.DefaultDatabaseSettingName, ""));
               if (data != null)
               {
                  if (Model.Details.IndexOf(data) != -1)
                     Model.Details[Model.Details.IndexOf(data)] = data;
                  else
                     Model.Details.Add(data);
                  Model.Entity = data;
               }
               PostSaveAction("");
               MessageBox.Show("Archivos guardados correctamente ", "Proceso Terminado", MessageBoxButton.OK, MessageBoxImage.Information);
               //if (createNew)
               //{
               //   MessageBoxResult result = MessageBox.Show("Registro guardado correctamente, desea crear un nuevo registro", "Nuevo Registro", MessageBoxButton.YesNo, MessageBoxImage.Question);
               //   if (result == MessageBoxResult.Yes)
               //      OnNewCommand(new object());
               //}
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
               CONEquivalence data = ((CONEquivalence) await EasyApp.Current.eToolsServer().ExecuteAsync(Model.Entity, Actions.Remove, Options.Me, EasyApp.Current.DefaultDatabaseSettingName, ""));
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
            CONEquivalence data = ((CONEquivalence) await EasyApp.Current.eToolsServer().ExecuteAsync(Model.Entity, Actions.Find, Options.Light, EasyApp.Current.DefaultDatabaseSettingName, ""));
            if (data.Entities != null && data.Entities.Count > 0)
                Model.Details = new BindingList<CONEquivalence>(data.Entities);
            if (!String.IsNullOrWhiteSpace(Model.LabelValue1))
            {
                view.DataGridEquivalenceDetail.Columns["Value1"].IsVisible = true;
                view.DataGridEquivalenceDetail.Columns["Value1"].Header = model.LabelValue1;
            }

            if (!String.IsNullOrWhiteSpace(Model.LabelValue2))
            {
                view.DataGridEquivalenceDetail.Columns["Value2"].IsVisible = true;
                view.DataGridEquivalenceDetail.Columns["Value2"].Header = model.LabelValue2;
            }
            if (!String.IsNullOrWhiteSpace(Model.LabelValue3))
            {
                view.DataGridEquivalenceDetail.Columns["Value3"].IsVisible = true;
                view.DataGridEquivalenceDetail.Columns["Value3"].Header = model.LabelValue3;
            }
            if (!String.IsNullOrWhiteSpace(Model.LabelValue4))
            {
                view.DataGridEquivalenceDetail.Columns["Value4"].IsVisible = true;
                view.DataGridEquivalenceDetail.Columns["Value4"].Header = model.LabelValue4;
            }
            if (!String.IsNullOrWhiteSpace(Model.LabelValue5))
            {
                view.DataGridEquivalenceDetail.Columns["Value5"].IsVisible = true;
                view.DataGridEquivalenceDetail.Columns["Value5"].Header = model.LabelValue5;
            }
            if (!String.IsNullOrWhiteSpace(Model.LabelValue6))
            {
                view.DataGridEquivalenceDetail.Columns["Value6"].IsVisible = true;
                view.DataGridEquivalenceDetail.Columns["Value6"].Header = model.LabelValue6;
            }
            if (!String.IsNullOrWhiteSpace(Model.LabelValue7))
            {
                view.DataGridEquivalenceDetail.Columns["Value7"].IsVisible = true;
                view.DataGridEquivalenceDetail.Columns["Value7"].Header = model.LabelValue7;
            }
            if (!String.IsNullOrWhiteSpace(Model.LabelValue8))
            {
                view.DataGridEquivalenceDetail.Columns["Value8"].IsVisible = true;
                view.DataGridEquivalenceDetail.Columns["Value8"].Header = model.LabelValue8;
            }
            if (!String.IsNullOrWhiteSpace(Model.LabelValue9))
            {
                view.DataGridEquivalenceDetail.Columns["Value9"].IsVisible = true;
                view.DataGridEquivalenceDetail.Columns["Value9"].Header = model.LabelValue9;
            }
            if (!String.IsNullOrWhiteSpace(Model.LabelValue10))
            {
                view.DataGridEquivalenceDetail.Columns["Value10"].IsVisible = true;
                view.DataGridEquivalenceDetail.Columns["Value10"].Header = model.LabelValue10;
            }
            PostFindAction("CONEquivalences", Model.Details.Count, "");
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

      public virtual void OnDataGridDetailSelectionChange(object sender, DataEventArgs<CONEquivalence> e)
      {

          if (e.Value != null)
          {
              Model.EquivalenceDetails = new BindingList<CONEquivalenceDetail>();
              model.LabelValue1 = null;
              view.DataGridEquivalenceDetail.Columns["Value1"].Header = null;
              view.DataGridEquivalenceDetail.Columns["Value1"].IsVisible = false;
              model.LabelValue2 = null;
              view.DataGridEquivalenceDetail.Columns["Value2"].Header = null;
              view.DataGridEquivalenceDetail.Columns["Value2"].IsVisible = false;
              model.LabelValue3 = null;
              view.DataGridEquivalenceDetail.Columns["Value3"].Header = null;
              view.DataGridEquivalenceDetail.Columns["Value3"].IsVisible = false;
              model.LabelValue4 = null;
              view.DataGridEquivalenceDetail.Columns["Value4"].Header = null;
              view.DataGridEquivalenceDetail.Columns["Value4"].IsVisible = false;
              model.LabelValue5 = null;
              view.DataGridEquivalenceDetail.Columns["Value5"].Header = null;
              view.DataGridEquivalenceDetail.Columns["Value5"].IsVisible = false;
              model.LabelValue6 = null;
              view.DataGridEquivalenceDetail.Columns["Value6"].Header = null;
              view.DataGridEquivalenceDetail.Columns["Value6"].IsVisible = false;
              model.LabelValue7 = null;
              view.DataGridEquivalenceDetail.Columns["Value7"].Header = null;
              view.DataGridEquivalenceDetail.Columns["Value7"].IsVisible = false;
              model.LabelValue8 = null;
              view.DataGridEquivalenceDetail.Columns["Value8"].Header = null;
              view.DataGridEquivalenceDetail.Columns["Value8"].IsVisible = false;
              model.LabelValue9 = null;
              view.DataGridEquivalenceDetail.Columns["Value9"].Header = null;
              view.DataGridEquivalenceDetail.Columns["Value9"].IsVisible = false;
              model.LabelValue10 = null;
              view.DataGridEquivalenceDetail.Columns["Value10"].Header = null;
              view.DataGridEquivalenceDetail.Columns["Value10"].IsVisible = false;
              Model.Entity = (CONEquivalence)EasyApp.Current.eToolsServer().Execute(new CONEquivalence { Id = e.Value.Id }, Actions.Find, Options.Me, EasyApp.Current.DefaultDatabaseSettingName, "");
              if (!String.IsNullOrWhiteSpace(Model.LabelValue1))
              {
                  view.DataGridEquivalenceDetail.Columns["Value1"].IsVisible = true;
                  view.DataGridEquivalenceDetail.Columns["Value1"].Header = model.LabelValue1;
              }

              if (!String.IsNullOrWhiteSpace(Model.LabelValue2))
              {
                  view.DataGridEquivalenceDetail.Columns["Value2"].IsVisible = true;
                  view.DataGridEquivalenceDetail.Columns["Value2"].Header = model.LabelValue2;
              }
              if (!String.IsNullOrWhiteSpace(Model.LabelValue3))
              {
                  view.DataGridEquivalenceDetail.Columns["Value3"].IsVisible = true;
                  view.DataGridEquivalenceDetail.Columns["Value3"].Header = model.LabelValue3;
              }
              if (!String.IsNullOrWhiteSpace(Model.LabelValue4))
              {
                  view.DataGridEquivalenceDetail.Columns["Value4"].IsVisible = true;
                  view.DataGridEquivalenceDetail.Columns["Value4"].Header = model.LabelValue4;
              }
              if (!String.IsNullOrWhiteSpace(Model.LabelValue5))
              {
                  view.DataGridEquivalenceDetail.Columns["Value5"].IsVisible = true;
                  view.DataGridEquivalenceDetail.Columns["Value5"].Header = model.LabelValue5;
              }
              if (!String.IsNullOrWhiteSpace(Model.LabelValue6))
              {
                  view.DataGridEquivalenceDetail.Columns["Value6"].IsVisible = true;
                  view.DataGridEquivalenceDetail.Columns["Value6"].Header = model.LabelValue6;
              }
              if (!String.IsNullOrWhiteSpace(Model.LabelValue7))
              {
                  view.DataGridEquivalenceDetail.Columns["Value7"].IsVisible = true;
                  view.DataGridEquivalenceDetail.Columns["Value7"].Header = model.LabelValue7;
              }
              if (!String.IsNullOrWhiteSpace(Model.LabelValue8))
              {
                  view.DataGridEquivalenceDetail.Columns["Value8"].IsVisible = true;
                  view.DataGridEquivalenceDetail.Columns["Value8"].Header = model.LabelValue8;
              }
              if (!String.IsNullOrWhiteSpace(Model.LabelValue9))
              {
                  view.DataGridEquivalenceDetail.Columns["Value9"].IsVisible = true;
                  view.DataGridEquivalenceDetail.Columns["Value9"].Header = model.LabelValue9;
              }
              if (!String.IsNullOrWhiteSpace(Model.LabelValue10))
              {
                  view.DataGridEquivalenceDetail.Columns["Value10"].IsVisible = true;
                  view.DataGridEquivalenceDetail.Columns["Value10"].Header = model.LabelValue10;
              }
          }
         //if (model.EquivalenceDetails == null)
         //{
         //    Model.EquivalenceDetails = new BindingList<CONEquivalenceDetail>();
         //}
      }

      #endregion
   }

}
