using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
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
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EasyTools.UI.WPF.EasyConnect.Module.ViewModels
{
    public class CONSQLExecuteViewModel : BaseCONSQLExecuteViewModel
    {
        public FormWindow WindowParmeter { get; set; }

        private CONSQLParameterView viewNewSQLParameter;

        public CONSQLExecuteViewModel(IUnityContainer container, CONSQLExecuteView view)
            : base(container, view)
        {
            this.view.EditParameter += view_EditParameter;
            this.ExecuteCommand = new RelayCommand(OnExecuteCommand);
            this.view.DataGridDetailSelectionChanges += view_DataGridDetailSelectionChanges;
            this.view.ClearData += view_ClearData;
        }

        void view_ClearData(object sender, EventArgs e)
        {
            Model.SQLParameters = new BindingList<CONSQLParameter>();
        }

        void view_DataGridDetailSelectionChanges(object sender, DataEventArgs<BindingList<CONSQL>> e)
        {
            if (e.Value != null && e.Value.Count > 0)
            {
                if (Model.SQLParameters == null)
                    Model.SQLParameters = new BindingList<CONSQLParameter>();
                if (Model.SQLSends == null)
                    Model.SQLSends = new BindingList<CONSQLSend>();
                foreach (CONSQL sql in e.Value)
                {
                    List<CONSQLParameter> param = new List<CONSQLParameter>();
                    param = ((CONSQLParameter)EasyApp.Current.eToolsServer().Execute(new CONSQLParameter { SQLId = sql.Id }, Actions.Find, Options.All, EasyApp.Current.DefaultDatabaseSettingName, "")).Entities;

                    if (param != null && param.Count > 0)
                    {
                        for (int i = 0; i < param.Count; i++)
                        {
                            var exist = Model.SQLParameters.FirstOrDefault(x => x.Name == param[i].Name);
                            if (exist == null)
                                Model.SQLParameters.Add(param[i]);
                        }
                    }
                    //else
                    //    Model.SQLParameters = new BindingList<CONSQLParameter>();

                    List<CONSQLSend> sends = new List<CONSQLSend>();
                    sends = ((CONSQLSend)EasyApp.Current.eToolsServer().Execute(new CONSQLSend { SQLId = sql.Id, Active = true }, Actions.Find, Options.All, EasyApp.Current.DefaultDatabaseSettingName, "")).Entities;

                    if (sends != null && sends.Count > 0)
                    {
                        for (int i = 0; i < sends.Count; i++)
                        {
                            var exist = Model.SQLSends.FirstOrDefault(x => x.CONIntegratorConfiguration.Id == sends[i].CONIntegratorConfiguration.Id);
                            if (exist == null)
                                Model.SQLSends.Add(sends[i]);
                        }

                    }
                }
            }
            FindWebServices();
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
            FindAction();


            //Register new actions here!!!.
        }

        public override void SaveAction(bool createNew)
        {
            //base.SaveAction(createNew);

            //Register new actions here!!!.
        }

        public override void DeleteAction()
        {
            //base.DeleteAction();

            //Register new actions here!!!.
        }

        public override void FindAction()
        {
            base.FindAction();

            //Register new actions here!!!.
        }

        public ICommand ExecuteCommand { get; protected set; }

        public async void OnExecuteCommand(object obj)
        {
            view.ExecuteView.IsEnabled = false;
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                CONSQL sqls = new CONSQL();
                sqls.Entities = new List<CONSQL>();
                sqls.SQLParameters = new List<CONSQLParameter>();
                sqls.SQLSends = new List<CONSQLSend>();
                if (Model.SQLParameters != null && Model.SQLParameters.Count > 0)
                {
                    foreach (var item in Model.SQLParameters)
                    {
                        if (item.DateValue != null || item.Int32Value != null || !string.IsNullOrWhiteSpace(item.StringValue)||item.DefaultDateValue!= null)
                            sqls.SQLParameters.Add(new CONSQLParameter { SQLId = item.SQLId, Name = item.Name, IsDate = item.IsDate, IsInt = item.IsInt, IsString = item.IsString, DateValue = item.DateValue, DefaultDateValue = item.DefaultDateValue, Int32Value = item.Int32Value, StringValue = item.StringValue });
                        else
                            throw new Exception("El parametro :" + item.Name + " no tiene valor registrado");
                    }
                }
                if (view.SQLsGrid.SelectedItems != null && view.SQLsGrid.SelectedItems.Count > 0)
                {
                    foreach (var item in view.SQLsGrid.SelectedItems)
                        sqls.Entities.Add((CONSQL)item);
                }
                if (view.Accounting.IsChecked == true)
                {
                    if (view.IntegratorConfigurationsGrid.SelectedItems != null && view.IntegratorConfigurationsGrid.SelectedItems.Count > 0)
                    {
                        foreach (var item in view.IntegratorConfigurationsGrid.SelectedItems)
                            sqls.SQLSends.Add((CONSQLSend)item);
                    }
                    else
                        throw new Exception("No se ha seleccionado ningun Web Service para hacer el envio de los datos...");
                }
                sqls.AddAditionalProperty("Accounting", Model.Accounting);
                CONSQL data = ((CONSQL)await EasyApp.Current.eToolsServer().ExecuteAsync(sqls, Actions.Process, Options.All, EasyApp.Current.DefaultDatabaseSettingName, ""));
                MessageBox.Show("Registro ejecutado y guardado correctamente", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            view.ExecuteView.IsEnabled = true;
        }

        #endregion

        

        #region Events


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
            viewNewSQLParameter.CheckIsDate.Visibility = Visibility.Collapsed;
            viewNewSQLParameter.CheckIsInt.Visibility = Visibility.Collapsed;
            viewNewSQLParameter.CheckIsString.Visibility = Visibility.Collapsed;
            viewNewSQLParameter.DefaultDate.Visibility = Visibility.Collapsed;
            viewNewSQLParameter.DefaultDateLabel.Visibility = Visibility.Collapsed;
            //viewNewSQLParameter.ViewModel.Model.SelectedDefaultDateValue = EasyApp.Current.ListDefaultDateValues.FirstOrDefault(x => x.Int32Value == viewNewSQLParameter.ViewModel.Model.DefaultDateValue);
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


        public override void OnDataGridDetailSelectionChange(object sender, DataEventArgs<CONSQL> e)
        {
           // base.OnDataGridDetailSelectionChange(sender, e);

            //Register new actions here!!!.
        }

        #endregion

        public async void FindWebServices()
        {
            try
            {
                
                CONIntegratorConfiguration data = ((CONIntegratorConfiguration)await EasyApp.Current.eToolsServer().ExecuteAsync(new CONIntegratorConfiguration { Active = true }, Actions.Find, Options.All, EasyApp.Current.DefaultDatabaseSettingName, ""));
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(new BusinessException(ex).GetExceptionMessage(), "Error", MessageBoxButton.OK);
                FormIsBusy = false;
                PostFindAction("", 0, new BusinessException(ex).GetExceptionMessage());
            }
        }
    }
}