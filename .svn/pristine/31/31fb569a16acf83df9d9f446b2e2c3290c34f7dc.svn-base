using EasyTools.Framework.UI;
using EasyTools.Infrastructure.Entities;
using EasyTools.UI.Data;
using EasyTools.UI.WPF.EasyConnect.Module.ViewModels.Base;
using EasyTools.UI.WPF.EasyConnect.Module.Views;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Unity;
using Microsoft.Win32;
using System.Windows.Input;
using System.Linq;

namespace EasyTools.UI.WPF.EasyConnect.Module.ViewModels
{
   public class CONIntegratorConfigurationViewModel : BaseCONIntegratorConfigurationViewModel
   {

      public CONIntegratorConfigurationViewModel(IUnityContainer container,CONIntegratorConfigurationView view)  : base(container, view)
      {
          this.FindPathCommand = new RelayCommand(OnFindPathCommand);
          this.view.ExportTypeChanged += view_ExportTypeChanged;
      }

      void view_ExportTypeChanged(object sender, System.EventArgs e)
      {
          if (Model.ExportType.Key == "UNO")
          {
              view.ConectionNumber.Visibility = System.Windows.Visibility.Visible;
              view.ConectionNumberLabel.Visibility = System.Windows.Visibility.Visible;
              view.FileExtension.Visibility = System.Windows.Visibility.Collapsed;
              view.FileExtensionLabel.Visibility = System.Windows.Visibility.Collapsed;
              view.FileName.Visibility = System.Windows.Visibility.Collapsed;
              view.FileNameLabel.Visibility = System.Windows.Visibility.Collapsed;
              view.GridConfiguration.IsEnabled = true;
          }
          else {
              view.FileExtension.Visibility = System.Windows.Visibility.Visible;
              view.FileExtensionLabel.Visibility = System.Windows.Visibility.Visible;
              view.FileName.Visibility = System.Windows.Visibility.Visible;
              view.FileNameLabel.Visibility = System.Windows.Visibility.Visible;
              view.ConectionNumber.Visibility = System.Windows.Visibility.Collapsed;
              view.ConectionNumberLabel.Visibility = System.Windows.Visibility.Collapsed;
              view.GridConfiguration.IsEnabled = true;

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
         
         //Register new actions here!!!.
      }

      public override void SaveAction(bool createNew)
      {

          Model.Integrator = EasyApp.Current.ListIntegrators.FirstOrDefault(x => x.Id == 1);
             
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


      public ICommand FindPathCommand { get; protected set; }

      public void OnFindPathCommand(object obj)
      {
          OpenFileDialog openFile = new OpenFileDialog();
          openFile.ShowDialog();
          if (openFile.FileName != null && openFile.FileName != "")
          {
              Model.ProgramPath = openFile.FileName;
          }
      }

      #endregion

      #region Events

      public override void OnDataGridDetailSelectionChange(object sender, DataEventArgs<CONIntegratorConfiguration> e)
      {
         base.OnDataGridDetailSelectionChange(sender, e);

         //Register new actions here!!!.
      }

      #endregion
   }

}
