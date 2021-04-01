using EasyTools.Framework.Data;
using EasyTools.Framework.UI;
using EasyTools.Infrastructure.Entities;
using EasyTools.UI.Data;
using EasyTools.UI.WPF.EasyConnect.Module.ViewModels.Base;
using EasyTools.UI.WPF.EasyConnect.Module.Views;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Diagnostics;
using System;
using EasyTools.Framework.Resources;
using System.ServiceModel;
using EasyTools.Framework.Application;

namespace EasyTools.UI.WPF.EasyConnect.Module.ViewModels
{
   public class CONRecordViewModel : BaseCONRecordViewModel
   {
       private StringBuilder stringXML = null;
      
       public CONRecordViewModel(IUnityContainer container,CONRecordView view)  : base(container, view)
      {
          this.SendCommand = new RelayCommand(OnSendCommand);
          this.GenerateFilesCommand = new RelayCommand(OnGenerateFilesCommand);
          this.MarkSendCommand = new RelayCommand(OnMarkSendCommand);
          this.MarkNotSendCommand = new RelayCommand(OnMarkNotSendCommand);
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
         //base.SaveAction(createNew);

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

      public ICommand SendCommand { get; protected set; }

      public async void OnSendCommand(object obj)
      {
            //FormIsBusy = true;
            //FormBusyMessage = "Procesando";
            try
            {
                view.RecordView.IsEnabled = false;
                Mouse.OverrideCursor = Cursors.Wait;
                if (view.RecordGrid.SelectedItems != null && view.RecordGrid.SelectedItems.Count > 0)
                {
                    List<CONRecord> records = new List<CONRecord>();



                    //foreach (CONRecord item in view.RecordGrid.SelectedItems)
                    //    records.Add(item);
                    //tiempo.Stop();
                    records.AddRange(view.RecordGrid.SelectedItems.Select(x => x as CONRecord).ToList<CONRecord>());
                    //Stopwatch tiempo = Stopwatch.StartNew();
                    //for (int i = 0; i < records.Count; i++) //104320
                    //    records[i] = (CONRecord)EasyApp.Current.eToolsServer().Execute(new CONRecord { Id = records[i].Id }, Actions.Find, Options.Me, EasyApp.Current.DefaultDatabaseSettingName, "");
                    //tiempo.Stop();
                    //22079
                    //Parallel.ForEach(records, currentElement =>
                    //{

                    //    currentElement = (CONRecord)EasyApp.Current.eToolsServer().Execute(new CONRecord { Id = currentElement.Id }, Actions.Find, Options.Me, EasyApp.Current.DefaultDatabaseSettingName, "");

                    //});

                    //Dictionary<string, List<CONRecord>> reg = new Dictionary<string, List<CONRecord>>();
                    //List<string> co = (from a in records select a.OperationCenter).Distinct().ToList();

                    //foreach (string item in co)
                    //{
                    //    List<CONRecord> rec = (from x in records where x.OperationCenter == item select x).ToList();
                    //    reg.Add(item, rec);
                    //}
                    //CONSQL send = null;

                    //Parallel.ForEach(reg.Keys, currentElement =>
                    //{

                    //     send = (CONSQL)EasyApp.Current.eToolsServer().Execute(new CONSQL { Records = reg[currentElement] }, Actions.Generate, Options.All, EasyApp.Current.DefaultDatabaseSettingName, "");
                    //    //var SqlSends = (CONSQLSend)EasyApp.Current.eToolsServer().Execute(new CONSQLSend { SQLId = currentElement.SQL.Id }, Actions.Find, Options.All, EasyApp.Current.DefaultDatabaseSettingName, "");
                    //    //currentElement.SQL.SQLSends = SqlSends.Entities;
                    //});



                    //tiempo.Stop();
                    CONSQL send = ((CONSQL)await EasyApp.Current.eToolsServer().ExecuteAsync(new CONSQL { Records = records, ParallelNumber = Model.ParallelNumber  }, Actions.Generate, Options.All, EasyApp.Current.DefaultDatabaseSettingName, ""));
                    if (!(bool)send.GetAditionalProperty("Result"))
                        MessageBox.Show("Proceso con Errores", "Proceso Terminado", MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                        MessageBox.Show("Procesado correctamente", "Proceso Terminado", MessageBoxButton.OK, MessageBoxImage.Information);
                    Model.Details = new BindingList<CONRecord>();
                    FindAction();
                    view.RecordView.IsEnabled = true;

                }
            }
            catch(Exception ex)
            {
                string a = ((FaultException<BusinessException>)ex).Detail.AppMessageDetails.FirstOrDefault();
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show(a, GetLocalizedMessage(Language.ApplicationError), MessageBoxButton.OK, MessageBoxImage.Error);
                view.RecordView.IsEnabled = true;

            }


        }

      public ICommand GenerateFilesCommand { get; protected set; }

      public void OnGenerateFilesCommand(object obj)
      {
          try
          {
              view.RecordView.IsEnabled = false;
              CONRecord file = new CONRecord();
              //CONRecordDetail filesDetails = new CONRecordDetail();
              //var option = MessageBox.Show("Si desea generar un archivo por cada documento, selecione Si\nSi desea generar un unico archivo por todos los documentos, seleccione No","Como Generar el Archivo?", MessageBoxButton.);
              //if (option.ToString() != "Cancel")
              //{
              if (view.RecordGrid.SelectedItems != null && view.RecordGrid.SelectedItems.Count > 0)
              {
                  if (stringXML == null)
                  {
                      List<CONRecord> records = new List<CONRecord>();
                      //stringXML = new StringBuilder();
                      foreach (var item in view.RecordGrid.SelectedItems)
                      {
                          records.Add((CONRecord)item);

                      }
                      //if (option.ToString() == "Yes")
                      //{
                      //    files = ((CONRecord)await EasyApp.Current.eToolsServer().ExecuteAsync(new CONRecord { Entities = records }, Actions.Generate, Options.Light, EasyApp.Current.DefaultDatabaseSettingName, ""));
                      //}
                      //else if (option.ToString() == "No")
                      //{
                      //files = ((CONRecord)await EasyApp.Current.eToolsServer().ExecuteAsync(new CONRecord { Entities = records }, Actions.Generate, Options.All, EasyApp.Current.DefaultDatabaseSettingName, ""));
                      foreach (CONRecord item in records)
                      {
                          item.RecordDetails = ((CONRecordDetail)EasyApp.Current.eToolsServer().Execute(new CONRecordDetail { Record = item }, Actions.Find, Options.All, EasyApp.Current.DefaultDatabaseSettingName, "")).Entities;

                      }
                      file = ((CONRecord)EasyApp.Current.eToolsServer().Execute(new CONRecord { Entities = records }, Actions.Generate, Options.All, EasyApp.Current.DefaultDatabaseSettingName, ""));
                      foreach (CONRecord item in file.Entities)
                      {
                          string archivo = item.PlainText;
                          System.IO.StreamWriter exp = new System.IO.StreamWriter("C:\\Users\\Public\\Documents\\" + item.LogicalKey.ToString() + ".txt");
                          exp.Write(archivo);
                          exp.Close();

                      }


                      //}
                  }

                  MessageBox.Show("Archivos Generados Correctamente en la ruta: C:\\Users\\Public\\Documents\\ ", "Proceso Terminado", MessageBoxButton.OK, MessageBoxImage.Information);
                  view.RecordView.IsEnabled = true;
              }
              else
                  MessageBox.Show("Seleccione al menos 1 registro", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);

              view.RecordView.IsEnabled = true;
          }
          catch (Exception ex)
          {
              string a = ((FaultException<BusinessException>)ex).Detail.AppMessageDetails.FirstOrDefault();
              Mouse.OverrideCursor = Cursors.Arrow;
              MessageBox.Show(a, GetLocalizedMessage(Language.ApplicationError), MessageBoxButton.OK, MessageBoxImage.Error);
              view.RecordView.IsEnabled = true;

          }
      }


      public ICommand MarkSendCommand { get; protected set; }

      public void OnMarkSendCommand(object obj)
      {
          try
          {
              view.RecordView.IsEnabled = false;
              CONRecord file = new CONRecord();
              //CONRecordDetail filesDetails = new CONRecordDetail();
              //var option = MessageBox.Show("Si desea generar un archivo por cada documento, selecione Si\nSi desea generar un unico archivo por todos los documentos, seleccione No","Como Generar el Archivo?", MessageBoxButton.);
              //if (option.ToString() != "Cancel")
              //{
              if (view.RecordGrid.SelectedItems != null && view.RecordGrid.SelectedItems.Count > 0)
              {
                  List<CONRecord> records = new List<CONRecord>();
                  foreach (var item in view.RecordGrid.SelectedItems)
                  {
                      records.Add((CONRecord)item);

                  }
                  foreach (CONRecord item2 in records)
                  {
                      item2.IsSend = true;
                      var a = ((CONRecord)EasyApp.Current.eToolsServer().Execute(item2, Actions.Modify, Options.Me, EasyApp.Current.DefaultDatabaseSettingName, ""));

                  }
                  MessageBox.Show("Archivos marcados como enviados correctamente ", "Proceso Terminado", MessageBoxButton.OK, MessageBoxImage.Information);
                  view.RecordView.IsEnabled = true;
                  this.NewAction();
              }
              else
                  MessageBox.Show("Seleccione al menos 1 registro", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
              view.RecordView.IsEnabled = true;
          }
          catch (Exception ex)
          {
              string a = ((FaultException<BusinessException>)ex).Detail.AppMessageDetails.FirstOrDefault();
              Mouse.OverrideCursor = Cursors.Arrow;
              MessageBox.Show(a, GetLocalizedMessage(Language.ApplicationError), MessageBoxButton.OK, MessageBoxImage.Error);
              view.RecordView.IsEnabled = true;

          }
      }

      public ICommand MarkNotSendCommand { get; protected set; }

      public void OnMarkNotSendCommand(object obj)
      {
          try
          {
              view.RecordView.IsEnabled = false;
              CONRecord file = new CONRecord();
              //CONRecordDetail filesDetails = new CONRecordDetail();
              //var option = MessageBox.Show("Si desea generar un archivo por cada documento, selecione Si\nSi desea generar un unico archivo por todos los documentos, seleccione No","Como Generar el Archivo?", MessageBoxButton.);
              //if (option.ToString() != "Cancel")
              //{
              if (view.RecordGrid.SelectedItems != null && view.RecordGrid.SelectedItems.Count > 0)
              {
                  List<CONRecord> records = new List<CONRecord>();
                  foreach (var item in view.RecordGrid.SelectedItems)
                  {
                      records.Add((CONRecord)item);

                  }
                  foreach (CONRecord item2 in records)
                  {
                      item2.IsSend = false;
                      var a = ((CONRecord)EasyApp.Current.eToolsServer().Execute(item2, Actions.Modify, Options.Me, EasyApp.Current.DefaultDatabaseSettingName, ""));

                  }
                  MessageBox.Show("Archivos marcados como no enviados correctamente ", "Proceso Terminado", MessageBoxButton.OK, MessageBoxImage.Information);
                  view.RecordView.IsEnabled = true;
                  this.NewAction();
              }
              else
                  MessageBox.Show("Seleccione al menos 1 registro", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
              view.RecordView.IsEnabled = true;
          }
          catch (Exception ex)
          {
              string a = ((FaultException<BusinessException>)ex).Detail.AppMessageDetails.FirstOrDefault();
              Mouse.OverrideCursor = Cursors.Arrow;
              MessageBox.Show(a, GetLocalizedMessage(Language.ApplicationError), MessageBoxButton.OK, MessageBoxImage.Error);
              view.RecordView.IsEnabled = true;

          }
      }
      #endregion

      #region Events

      public override void OnDataGridDetailSelectionChange(object sender, DataEventArgs<CONRecord> e)
      {
         //base.OnDataGridDetailSelectionChange(sender, e);

         //Register new actions here!!!.
      }

      #endregion
   }

}
