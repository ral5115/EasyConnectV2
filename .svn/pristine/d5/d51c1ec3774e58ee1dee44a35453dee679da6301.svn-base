using EasyTools.Framework.Data;
using Microsoft.Practices.Prism.Mvvm;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using System.Linq;
using System.Windows;
using EasyTools.Framework.Resources;

namespace EasyTools.Framework.UI
{
    public class BaseViewModel : BindableBase
    {
        public BaseViewModel()
        {
            this.NewCommand = new RelayCommand(OnNewCommand);
            this.SaveCommand = new RelayCommand(OnSaveCommand);
            this.SaveNewCommand = new RelayCommand(OnSaveNewCommand);
            this.DeleteCommand = new RelayCommand(OnDeleteCommand);
            this.FindCommand = new RelayCommand(OnFindCommand);
            RegisterPermisions();
        }

        public virtual void RegisterPermisions()
        {
        }

        #region Commands

        public ICommand NewCommand { get; protected set; }

        public void OnNewCommand(object obj)
        {
            //FormIsBusy = true;
            //FormBusyMessage = "Procesando";
            //FormStatusMessage = "Ingrese un nuevo registro";
            FormHeaderExpanded = false;
            Mouse.OverrideCursor = Cursors.Wait;
            NewAction();

        }

        public virtual void NewAction() { }

        public virtual void PostNewAction(string errorTitle = "", string errorMessage = "", bool showMessageError = false, MessageBoxImage image = MessageBoxImage.None)
        {
            if (!string.IsNullOrWhiteSpace(errorMessage))
                FormStatusMessage = errorMessage;
            if(showMessageError)
                MessageBox.Show(errorMessage, errorTitle, MessageBoxButton.OK, image);
            //FormIsBusy = false;
            //FormHeaderExpanded = false;
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        public ICommand SaveCommand { get; protected set; }

        public void OnSaveCommand(object obj)
        {
            //FormIsBusy = true;
            //FormBusyMessage = "Procesando...";
            Mouse.OverrideCursor = Cursors.Wait;
            SaveAction(false);

        }

        public virtual void SaveAction(bool createNew)
        {
        }

        public virtual void PostSaveAction(string errorTitle = "", string errorMessage = "", bool showMessageError = false, bool createNew = false, MessageBoxImage image = MessageBoxImage.None)
        {
            if (string.IsNullOrWhiteSpace(errorMessage))
                errorMessage = "Registro guardado correctamente";
            if (showMessageError)
                MessageBox.Show(errorMessage, errorTitle, MessageBoxButton.OK, image);
            if (createNew)
            {
                MessageBoxResult result = MessageBox.Show(GetLocalizedMessage(Language.ApplicationSaveAndNew), GetLocalizedMessage(Language.ApplicationNewRecord), MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                    OnNewCommand(new object());
            }

            //FormStatusMessage = errorMessage;
            //FormIsBusy = false;
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        public ICommand DeleteCommand { get; protected set; }

        public void OnDeleteCommand(object obj)
        {
            //FormIsBusy = true;
            //FormBusyMessage = "Procesando";
            Mouse.OverrideCursor = Cursors.Wait;
            DeleteAction();
        }

        public virtual void DeleteAction() { }

        public virtual void PostDeleteAction(string errorTitle = "", string errorMessage = "", bool showMessageError = false, MessageBoxImage image = MessageBoxImage.None)
        {
            if (string.IsNullOrWhiteSpace(errorMessage))
                errorMessage = "Registro eliminado correctamente";
            if(showMessageError)
                MessageBox.Show(errorMessage, errorTitle, MessageBoxButton.OK, image);
            MessageBoxResult result = MessageBox.Show(GetLocalizedMessage(Language.ApplicationRecordDeletedSuccessfully), GetLocalizedMessage(Language.ApplicationDeleting), MessageBoxButton.OK, MessageBoxImage.Question);
            OnNewCommand(new object());
            //FormStatusMessage = errorMessage;
            //FormIsBusy = false;
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        public ICommand FindCommand { get; protected set; }

        public void OnFindCommand(object obj)
        {
            //FormIsBusy = true;
            //FormBusyMessage = "Procesando...";
            //FormStatusMessage = "Ejecutando consulta...";
            Mouse.OverrideCursor = Cursors.Wait;
            FormHeaderExpanded = true;
            FindAction();
        }

        public virtual void FindAction() { }

        public virtual void PostFindAction(string queryName = "", int recordNumber = 0, string errorMessage = "", bool showMessageError = false, string errorTitle = "", MessageBoxImage image = MessageBoxImage.None )
        {
            if (string.IsNullOrWhiteSpace(errorMessage))
                FormStatusMessage = "La consulta de " + queryName + " se ejecuto exitosamente, registros consultados: " + recordNumber;
            else
                FormStatusMessage = errorMessage;
            if (showMessageError)
                MessageBox.Show(errorMessage, errorTitle, MessageBoxButton.OK, image);
            //FormIsBusy = false;
            //FormHeaderExpanded = true;
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        public ICommand SaveNewCommand { get; protected set; }

        public void OnSaveNewCommand(object parameter)
        {
            FormIsBusy = true;
            FormBusyMessage = "Procesando...";
            SaveAction(true);
        }

        public ICommand EditCommand { get; protected set; }

        #endregion

        public bool formIsBusy;

        public bool FormIsBusy
        {
            get { return formIsBusy; }
            set { SetProperty(ref formIsBusy, value, "formIsBusy"); }
        }

        private string formBusyMessage;

        public string FormBusyMessage
        {
            get { return formBusyMessage; }
            set { SetProperty(ref formBusyMessage, value, "FormBusyMessage"); }
        }

        private bool formHeaderExpanded;

        public bool FormHeaderExpanded
        {
            get { return formHeaderExpanded; }
            set { SetProperty(ref formHeaderExpanded, value, "FormHeaderExpanded"); }
        }

        private string formStatusMessage;

        public string FormStatusMessage
        {
            get { return formStatusMessage; }
            set { SetProperty(ref formStatusMessage, value, "FormStatusMessage"); }
        }

        private BindingList<Permission> permisions;

        public BindingList<Permission> Permisions
        {
            get
            {
                if (permisions == null)
                    permisions = new BindingList<Permission>();
                return permisions;
            }
            set { SetProperty(ref permisions, value, "Permisions"); }
        }

        public Permission GetPermission(int id)
        {
            return Permisions.FirstOrDefault(x => x.Id == id);
        }

        public string GetLocalizedMessage(string message, params string[] args)
        {
            return string.Format(message, args);
        }
    }
}