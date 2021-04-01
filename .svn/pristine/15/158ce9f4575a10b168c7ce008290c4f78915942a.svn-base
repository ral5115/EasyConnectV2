using EasyTools.Infrastructure.Entities;
using EasyTools.UI.WPF.EasyConnect.Module.ViewModels.Base;
using EasyTools.UI.WPF.EasyConnect.Module.Views;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Unity;
using System.Windows.Input;

namespace EasyTools.UI.WPF.EasyConnect.Module.ViewModels
{
   public class CONSQLParameterViewModel : BaseCONSQLParameterViewModel
   {

      public CONSQLParameterViewModel(IUnityContainer container,CONSQLParameterView view)  : base(container, view)
      {
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

         //Register new actions here!!!.
      }

      public override void SaveAction(bool createNew)
      {
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
         base.FindAction();

         //Register new actions here!!!.
      }

      public ICommand OkParameterCommand { get; set; }

      public ICommand CancelParameterCommand { get; set; }

      //public void OnOkCommand(object obj)
      //{
      //    Window.DialogResult = true;
      //    Window.Close();
      //}

      //public ICommand CancelCommand { get; protected set; }

      //public void OnCancelCommand(object obj)
      //{
      //    Window.DialogResult = false;
      //    Window.Close();
      //}

      #endregion

      #region Events

      public override void OnDataGridDetailSelectionChange(object sender, DataEventArgs<CONSQLParameter> e)
      {
         base.OnDataGridDetailSelectionChange(sender, e);

         //Register new actions here!!!.
      }

      #endregion
   }

}
