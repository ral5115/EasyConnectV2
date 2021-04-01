using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Framework.Resources;
using EasyTools.Framework.UI;
using EasyTools.Infrastructure.Entities;
using EasyTools.UI.Data;
using EasyTools.UI.WPF.EasyConnect.Module.ViewModels.Base;
using EasyTools.UI.WPF.EasyConnect.Module.Views;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Windows;
using System.Windows.Input;

namespace EasyTools.UI.WPF.EasyConnect.Module.ViewModels
{
    public class CONSQLViewModel : BaseCONSQLViewModel
    {
        public FormWindow Window { get; set; }

        public FormWindow WindowParmeter { get; set; }

        private CONSQLView viewNewSQL;

        private CONSQLParameterView viewNewSQLParameter;

        

        public bool childModify;

        public CONSQLViewModel(IUnityContainer container, CONSQLView view)
            : base(container, view)
        {
            this.view.StructureChanged += view_StructureChanged;
            //this.view.MouseDoubleClick += view_MouseDoubleClick;
            this.ParameterCommand = new RelayCommand(OnParameterCommand);
            //this.EditParameterCommand = new RelayCommand(OnEditParameterCommand);
            this.view.EditParameter += view_EditParameter;
            this.MappingCommand = new RelayCommand(OnMappingCommand);
            this.NewSQLDetailCommand = new RelayCommand(OnNewSQLDetailCommand);
            this.OkCommand = new RelayCommand(OnOkCommand);
            this.CancelCommand = new RelayCommand(OnCancelCommand);
            //this.EditDetailCommand = new RelayCommand(OnEditDetailCommand);
            view.EditChildSQL += view_EditChildSQL;
            this.view.GenerateFileChecked += view_GenerateFileChecked;
            childModify = false;
        }

        void view_GenerateFileChecked(object sender, EventArgs e)
        {
            if (Model.Structure == null)
                Model.Structure = ((EasyApp)view.FindResource("dataProvider")).ListStructures.FirstOrDefault(x => x.Id == 1);
        }

        void view_EditParameter(object sender, DataEventArgs<CONSQLParameter> e)
        {
            WindowParmeter = new FormWindow();
            WindowParmeter.Header = "Ingrese Parametro";
            WindowParmeter.CanClose = true;
            WindowParmeter.CanMove = true;
            WindowParmeter.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            WindowParmeter.Owner = view;
            WindowParmeter.Closed += WindowParmeter_Closed;
            viewNewSQLParameter = container.Resolve<CONSQLParameterView>();
            viewNewSQLParameter.ViewModel.Window = Window;
            viewNewSQLParameter.ViewModel.Model.Entity = e.Value;
            viewNewSQLParameter.ViewModel.Model.SelectedDefaultDateValue = EasyApp.Current.ListDefaultDateValues.FirstOrDefault(x => x.Int32Value == viewNewSQLParameter.ViewModel.Model.DefaultDateValue);
            //viewNewSQLParameter.ViewModel.childModify = false;SelectedDefaultDateValue
            //viewNewSQLParameter.Toolbar.Visibility = Visibility.Collapsed;
            //viewNewSQLParameter.Expander.Visibility = Visibility.Collapsed;
            //viewNewSQLParameter.TabItemChilsSQls.Visibility = Visibility.Collapsed;
            //viewNewSQLParameter.TabItemParameters.Visibility = Visibility.Collapsed;
            //viewNewSQLParameter.DialogToolbar.Visibility = Visibility.Visible;
            //viewNewSQLParameter.ViewModel.OnNewCommand(new Object());
            //viewNewSQLParameter.ViewModel.Model.Connection = Model.Connection;
            //viewNewSQLParameter.ViewModel.Model.Company = Model.Company;
            //((EasyApp)viewNewSQL.FindResource("dataProvider")).ListStructures = EasyApp.Current.GetChildStructures(Model.Structure);

            //Se coloca en true para que no ejecute el metodo new al abrir la ventana por primera vez
            viewNewSQLParameter.isLoaded = true;
            viewNewSQLParameter.ViewModel.OkParameterCommand = new RelayCommand(OnOkParameterCommand);
            viewNewSQLParameter.ViewModel.CancelParameterCommand = new RelayCommand(OnCancelParameterCommand);
            WindowParmeter.Content = viewNewSQLParameter;
            WindowParmeter.ShowDialog();
        }

        public void OnOkParameterCommand(object obj)
        {
            WindowParmeter.DialogResult = true;
            WindowParmeter.Close();
        }

        public void OnCancelParameterCommand(object obj)
        {
            WindowParmeter.DialogResult = false;
            WindowParmeter.Close();
        }

        void WindowParmeter_Closed(object sender, Telerik.Windows.Controls.WindowClosedEventArgs e)
        {
            if (WindowParmeter.DialogResult != null)
            {
                if ((bool)WindowParmeter.DialogResult)
                {

                    for (int i = 0; i < Model.SQLParameters.Count; i++)
                    {
                        if (viewNewSQLParameter.ViewModel.Model.Id == Model.SQLParameters[i].Id)
                        {
                            Model.SQLParameters[i] = viewNewSQLParameter.ViewModel.Model.Entity;
                            //Model.SQLParameters[i].SQLDetails = viewNewSQL.ViewModel.Model.Entity.SQLDetails;
                        }
                    }
                }
            }
        }

        void view_EditChildSQL(object sender, DataEventArgs<CONSQL> e)
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                Window = new FormWindow();
                Window.Header = "Ingrese una nueva interfaz SQL";
                Window.CanClose = true;
                Window.CanMove = true;
                Window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                Window.Owner = view;
                Window.Closed += window_Closed;
                viewNewSQL = container.Resolve<CONSQLView>();
                viewNewSQL.ViewModel.Window = Window;
                viewNewSQL.Toolbar.Visibility = Visibility.Collapsed;
                viewNewSQL.Expander.Visibility = Visibility.Collapsed;
                viewNewSQL.TabItemChilsSQls.Visibility = Visibility.Collapsed;
                viewNewSQL.TabItemParameters.Visibility = Visibility.Collapsed;
                viewNewSQL.DialogToolbar.Visibility = Visibility.Visible;
                viewNewSQL.ViewModel.childModify = true;
                viewNewSQL.ViewModel.Model.Entity = e.Value;
                ((EasyApp)viewNewSQL.FindResource("dataProvider")).ListStructures = EasyApp.Current.GetChildStructures(Model.Structure);
                ((EasyApp)viewNewSQL.FindResource("dataProvider")).ListEquivalences = EasyApp.Current.GetEquivalences();
                //Se coloca en true para que no ejecute el metodo new al abrir la ventana por primera vez
                viewNewSQL.IsLoaded = true;
                Window.Content = viewNewSQL;
                Mouse.OverrideCursor = Cursors.Arrow;
                Window.ShowDialog();

            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show(ex.Message, GetLocalizedMessage(Language.ApplicationError), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override void RegisterPermisions()
        {
            base.RegisterPermisions();

            //Register additional permission here!!!.
        }

        #region Commands

        public override void NewAction()
        {
            base.NewAction();
            Mouse.OverrideCursor = Cursors.Wait;
            FindWebServices();
            Model.Active = true;
            //Register new actions here!!!.
        }

        public override void SaveAction(bool createNew)
        {
            if (!Model.GenerateFile)
            {
                int c = 0;
                if (Model.Entity.SQLSends != null && Model.Entity.SQLSends.Count > 0)
                {
                    foreach (var item in Model.Entity.SQLSends)
                    {
                        if (item.Active == true)
                            c++;
                    }
                    if (c == 1)
                        base.SaveAction(createNew);
                    else
                        MessageBox.Show("Debe seleccionar maximo 1 Configuracion de Importacion");
                }
                else
                    MessageBox.Show("Debe Crear una configuracion de importacion antes de crear el la interfaz");
            }
            else
                base.SaveAction(createNew);
                //Register new actions here!!!.
           
        }

        public override void DeleteAction()
        {
            base.DeleteAction();

            //Register new actions here!!!.
        }

        public override void FindAction()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            base.FindAction();
            //FindWebServices();
            //Register new actions here!!!.
        }

        public ICommand ParameterCommand { get; protected set; }

        public void OnParameterCommand(object obj)
        {

            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                if (Model.IsValid)
                {
                    Model.SQLParameters = new BindingList<CONSQLParameter>(((CONSQLParameter)EasyApp.Current.eToolsServer().Execute(new CONSQLParameter { SQL = Model.Entity }, Actions.Process, Options.All, EasyApp.Current.DefaultDatabaseSettingName, "")).Entities);
                }
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            catch (Exception e)
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show(new BusinessException(e).GetExceptionMessage(), "Error", MessageBoxButton.OK);
            }
        }

        public ICommand MappingCommand { get; protected set; }

        public void OnMappingCommand(object obj)
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                if (Model.IsValid)
                {
                    CONSQLDetail data = ((CONSQLDetail)EasyApp.Current.eToolsServer().Execute(new CONSQLDetail { SQL = Model.Entity }, Actions.Process, Options.All, EasyApp.Current.DefaultDatabaseSettingName, ""));
                    Model.SQLDetails = new BindingList<CONSQLDetail>(data.Entities);
                    //if(!string.IsNullOrWhiteSpace( data.ServerMessage))
                    //    MessageBox.Show(data.ServerMessage, "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                }
                
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            catch (Exception e)
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show(new BusinessException(e).GetExceptionMessage(), "Error", MessageBoxButton.OK);
            }
        }

        public ICommand NewSQLDetailCommand { get; protected set; }

        public void OnNewSQLDetailCommand(object obj)
        {
            Window = new FormWindow();
            Window.Header = "Ingrese una nueva interfaz SQL";
            Window.CanClose = true;
            Window.CanMove = true;
            Window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            Window.Owner = view;
            Window.Closed += window_Closed;
            viewNewSQL = container.Resolve<CONSQLView>();
            viewNewSQL.ViewModel.Window = Window;
            viewNewSQL.ViewModel.childModify = false;
            viewNewSQL.Toolbar.Visibility = Visibility.Collapsed;
            viewNewSQL.Expander.Visibility = Visibility.Collapsed;
            viewNewSQL.TabItemChilsSQls.Visibility = Visibility.Collapsed;
            viewNewSQL.TabItemParameters.Visibility = Visibility.Collapsed;
            viewNewSQL.DialogToolbar.Visibility = Visibility.Visible;
            viewNewSQL.ViewModel.OnNewCommand(new Object());
            viewNewSQL.ViewModel.Model.Connection = Model.Connection;
            viewNewSQL.ViewModel.Model.Company = Model.Company;
            ((EasyApp)viewNewSQL.FindResource("dataProvider")).ListStructures = EasyApp.Current.GetChildStructures(Model.Structure);
            ((EasyApp)viewNewSQL.FindResource("dataProvider")).ListEquivalences = EasyApp.Current.GetEquivalences();
            //Se coloca en true para que no ejecute el metodo new al abrir la ventana por primera vez
            viewNewSQL.IsLoaded = true;

            Window.Content = viewNewSQL;
            Window.ShowDialog();
        }

        void window_Closed(object sender, Telerik.Windows.Controls.WindowClosedEventArgs e)
        {
            if (Window.DialogResult != null)
            {
                if ((bool)Window.DialogResult)
                {
                    if (!viewNewSQL.ViewModel.childModify)
                    {
                        if (Model.ChildSQLs == null)
                            Model.ChildSQLs = new BindingList<CONSQL>();
                        Model.ChildSQLs.Add(viewNewSQL.ViewModel.Model.Entity);
                    }
                    else
                    {
                        for (int i = 0; i < Model.ChildSQLs.Count; i++)
                        {
                            if (viewNewSQL.Model.Id == Model.ChildSQLs[i].Id && viewNewSQL.Model.Description == Model.ChildSQLs[i].Description)
                            {
                                Model.ChildSQLs[i] = viewNewSQL.ViewModel.Model.Entity;
                                Model.ChildSQLs[i].SQLDetails = viewNewSQL.ViewModel.Model.Entity.SQLDetails;
                            }
                        }
                    }
                }
            }
        }

        public ICommand OkCommand { get; protected set; }

        public void OnOkCommand(object obj)
        {
            Window.DialogResult = true;
            Window.Close();
        }

        public ICommand CancelCommand { get; protected set; }

        public void OnCancelCommand(object obj)
        {
            Window.DialogResult = false;
            Window.Close();
        }

        //public ICommand EditDetailCommand { get; protected set; }

        //public void OnEditDetailCommand(object obj)
        //{
        //    var a = view.GridChildSQL.SelectedItem;
        //}

        public  void FindWebServices()
        {
            try
            {
                CONIntegratorConfiguration data = (CONIntegratorConfiguration)EasyApp.Current.eToolsServer().Execute(new CONIntegratorConfiguration { Active = true }, Actions.Find, Options.All, EasyApp.Current.DefaultDatabaseSettingName, "");
                if (data.Entities != null && data.Entities.Count > 0)
                {
                    foreach (CONIntegratorConfiguration item in data.Entities)
                    {
                        if (Model.SQLSends == null || Model.SQLSends.Count == 0)
                            Model.SQLSends = new BindingList<CONSQLSend>();
                        CONSQLSend exists = Model.SQLSends.FirstOrDefault(x => x.CONIntegratorConfiguration.Id == item.Id);
                        if (exists == null)
                            Model.SQLSends.Add(new CONSQLSend { CONIntegratorConfiguration = item });
                    }
                }
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            catch (FaultException ex)
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show(new BusinessException(ex).GetExceptionMessage(), "Error", MessageBoxButton.OK);
                FormIsBusy = false;
                PostFindAction("", 0, new BusinessException(ex).GetExceptionMessage());
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show(new BusinessException(ex).GetExceptionMessage(), "Error", MessageBoxButton.OK);
                FormIsBusy = false;
                PostFindAction("", 0, new BusinessException(ex).GetExceptionMessage());
            }
        }

        #endregion

        #region Events

        public override void OnDataGridDetailSelectionChange(object sender, DataEventArgs<CONSQL> e)
        {
            Model.SQLSends = new BindingList<CONSQLSend>();
            base.OnDataGridDetailSelectionChange(sender, e);
            FindWebServices();
            //Register new actions here!!!.
        }

        void view_MouseDoubleClick(object sender, EventArgs e)
        {


        }

        private void view_StructureChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(Model.Description) && Model.Structure != null && Model.Connection != null)
            {
                BindingList<CONStructureDetail> details = EasyApp.Current.GetStructureDetails(Model.Structure);
                ((EasyApp)view.FindResource("dataProvider")).ListStructureDetails = details;
                if (details != null && details.Count > 0 && String.IsNullOrWhiteSpace(Model.SQLSentence))
                {
                    String sql = "SELECT ";
                    for (int i = 0; i < details.Count; i++)
                    {
                        if (details[i].Visible)
                        {
                            if (i == details.Count - 1)
                                sql = sql + ((details[i].DBType == 1 || details[i].DBType == 4 || details[i].DBType == 5) ? " 0 " : " '' ") + details[i].Field + "\n";
                            else
                                sql = sql + ((details[i].DBType == 1 || details[i].DBType == 4 || details[i].DBType == 5) ? " 0 " : " '' ") + details[i].Field + ", \n";
                        }
                    }
                    sql += " FROM Tabla ";
                    Model.SQLSentence = sql;
                }
            }
            
        }
        #endregion
    }
}