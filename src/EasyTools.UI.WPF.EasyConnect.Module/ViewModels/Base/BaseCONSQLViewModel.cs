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
using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceModel;
using System.Windows;

namespace EasyTools.UI.WPF.EasyConnect.Module.ViewModels.Base
{
    public class BaseCONSQLViewModel : BaseViewModel
    {

        protected readonly CONSQLView view;

        protected readonly IUnityContainer container;

        public BaseCONSQLViewModel(IUnityContainer container, CONSQLView view)
            : base()
        {
            this.view = view;
            this.container = container;
            Model = new CONSQLModel();
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

        private CONSQLModel model;

        public CONSQLModel Model
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
                EasyApp.Current.GetConnections();
                ((EasyApp)view.FindResource("dataProvider")).ListStructures = EasyApp.Current.GetMainStructures();
                ((EasyApp)view.FindResource("dataProvider")).ListEquivalences = EasyApp.Current.GetEquivalences();
                
                Model.Entity = new CONSQL();
                Model.Details = new BindingList<CONSQL>();
                Model.Company = EasyApp.Current.Company;
                Model.SQLDetails = new BindingList<CONSQLDetail>();
                Model.SQLParameters = new BindingList<CONSQLParameter>();
                Model.ChildSQLs = new BindingList<CONSQL>();
                Model.SQLSends = new BindingList<CONSQLSend>();
                view.DetailTabControl.SelectedIndex = 0;
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
                    CONSQL data = ((CONSQL)await EasyApp.Current.eToolsServer().ExecuteAsync(Model.Entity, (Model.Id == 0 ? Actions.Add : Actions.Modify), Options.All, EasyApp.Current.DefaultDatabaseSettingName, ""));
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
                    else
                        MessageBox.Show("Registro guardado correctamente", "Registro", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Hay validaciones pendientes por favor verifique.", "Informaci??n", MessageBoxButton.OK, MessageBoxImage.Information);
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
                    CONSQL data = ((CONSQL)await EasyApp.Current.eToolsServer().ExecuteAsync(Model.Entity, Actions.Remove, Options.Me, EasyApp.Current.DefaultDatabaseSettingName, ""));
                    if (data != null)
                        Model.Details.Remove(data);
                    PostDeleteAction("");
                    MessageBoxResult result = MessageBox.Show("Registro eliminado correctamente", "Eliminando", MessageBoxButton.OK, MessageBoxImage.Question);
                    OnNewCommand(new object());
                }
                else
                {
                    MessageBox.Show("Hay validaciones pendientes por favor verifique.", "Informaci??n", MessageBoxButton.OK, MessageBoxImage.Information);
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

        public override  void FindAction()
        {
            try
            {
               //Model.SQLSends = new BindingList<CONSQLSend>();
               CONSQL data = ((CONSQL)EasyApp.Current.eToolsServer().Execute(Model.Entity, Actions.Find, Options.Light, EasyApp.Current.DefaultDatabaseSettingName, ""));
                if (data.Entities != null && data.Entities.Count > 0)
                    Model.Details = new BindingList<CONSQL>(data.Entities);
                PostFindAction("CONSQLs", Model.Details.Count, "");
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

        public virtual void OnDataGridDetailSelectionChange(object sender, DataEventArgs<CONSQL> e)
        {
            if (e.Value != null)
            {
                Model.ChildSQLs = new BindingList<CONSQL>();
                Model.SQLParameters = new BindingList<CONSQLParameter>();
                Model.Entity = (CONSQL)EasyApp.Current.eToolsServer().Execute(new CONSQL { Id = e.Value.Id }, Actions.Find, Options.Me, EasyApp.Current.DefaultDatabaseSettingName, "");
            }
            
        }

        #endregion
    }

}