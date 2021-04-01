using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Infrastructure.Entities;
using EasyTools.UI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTools.UI.Schedule
{
    public class Program
    {
        public static DatabaseSetting conf;

        public static void Main(string[] args)
        {


            //if (args == null)         [Nombre conexion]  [Tipo de Accion]   [ids de CONSQL]
            //args = new string[] { "Pruebas", "MA" }; 

                List<int> ids = new List<int>();
                List<string> documentType = new List<string>();
                try
                {
                    if (args != null && args.Length > 0)
                    {
                        //conf = EasyApp.Current.Configuration.DataBaseSettings.FirstOrDefault();
                        foreach (DatabaseSetting item in EasyApp.Current.Configuration.DataBaseSettings)
                        {
                            if (args[0].ToString() == item.Name)

                                conf = item;
                            else
                                conf = null;

                        }
                        if (conf == null)
                            throw new Exception("No se pudo recuperar una conexion de la base de datos");
                        if (args[1] == "F")
                        {
                            ReadFileOpera(conf);
                        }
                        else if(args[1] == "EI")
                        {
                            for (int i = 2; i < args.Length; i++)
                            {
                                ids.Add(Int32.Parse(args[i]));
                            }
                            SenRecords(conf, ids);
                        }
                        else if (args[1] == "E")
                        {
                            for (int i = 2; i < args.Length; i++)
                            {
                                ids.Add(Int32.Parse(args[i]));
                            }
                            ExecuteRecords(conf, ids);
                        }
                        else if (args[1] == "I")
                        {

                            OnlySendRecords(conf, args[2]);
                        }
                        else if (args[1] == "M")
                        {
                            SendMailErrors(conf);
                        }
                        else if (args[1] == "MA")
                        {
                            CreateMastersZapa(conf);
                        }
                    }



                }
                catch (Exception e)
                {
                    string error = "";
                    while (e != null)
                    {
                        error += e.Message + " \n";
                        e = e.InnerException;
                    }
                    Console.WriteLine(error);
                }
            }

        //lee el archivo de opera y lo guarda en las tablas del EasyConnect

        public static void ReadFileOpera(DatabaseSetting conf)
        {

            
            try
            {

                var opera = (EXTFileOpera)EasyApp.Current.eToolsServer().Execute(new EXTFileOpera(),Actions.Process, Options.All,conf.Name,"");
                Console.WriteLine("Archivo de Opera Leido y  Guardado Correctamente");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error al intentar guardar Archivo Opera " + e.Message);
            }
        }

        //Solo ejecutar
        public static void ExecuteRecords(DatabaseSetting conf, List<int> ids)
        {
            CONSQL param = new CONSQL();
            param.Entities = new List<CONSQL>();
            try
            {
                for (int i = 0; i < ids.Count; i++)
                {
                    CONSQL select = (CONSQL)EasyApp.Current.eToolsServer().Execute(new CONSQL { Active = true, Id = ids[i] }, Actions.Find, Options.Me, conf.Name, "");
                    param.Entities.Add(select);
                }
                param.AddAditionalProperty("Accounting", false);
                param.Description = "Schedule";
                CONSQL send = (CONSQL)EasyApp.Current.eToolsServer().Execute(param, Actions.Process, Options.All, conf.Name, "");
                Console.WriteLine("Tarea: Ejecutar correctamente");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error en el proceso de ejecucion " + e.Message);
            }
        }

        //Enviar
        public static void OnlySendRecords(DatabaseSetting conf, string documentType)
        {
            List<CONRecord> Rec = new List<CONRecord>();
            try
            {

                CONRecord select = (CONRecord)EasyApp.Current.eToolsServer().Execute(new CONRecord { IsSend = false, DocumentType = documentType }, Actions.Find, Options.All, conf.Name, "");
                   if(select != null)
                   Rec.AddRange(select.Entities);

                   if (Rec != null && Rec.Count > 0)
                   {
                       CONSQL send = (CONSQL)EasyApp.Current.eToolsServer().Execute(new CONSQL { Records = Rec }, Actions.Generate, Options.All, conf.Name, "");
                       Console.WriteLine("Tarea: Enviar correctamente");
                   }
                   else
                       Console.WriteLine("Tarea: No hay registros para enviar");


            }
            catch (Exception e)
            {
                Console.WriteLine("Error al ejecutar el proceso de envio " + e.Message);
            }
        }

        //Ejecutar y enviar
        public static void SenRecords(DatabaseSetting conf, List<int> ids)
        {
            CONSQL param = new CONSQL();
            param.Entities = new List<CONSQL>();
            try
            {
                for (int i = 0; i < ids.Count; i++)
                {
                    CONSQL select = (CONSQL)EasyApp.Current.eToolsServer().Execute(new CONSQL { Active = true, Id = ids[i] }, Actions.Find, Options.Me, conf.Name, "");
                    param.Entities.Add(select);
                }
                param.AddAditionalProperty("Accounting", true);
                param.Description = "Schedule";
                CONSQL send = (CONSQL)EasyApp.Current.eToolsServer().Execute(param, Actions.Process, Options.All, conf.Name, "");
                Console.WriteLine("Tarea: Ejecutar y enviar correctamente");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error en el proceso de ejecucion y envio " + e.Message);
            }
        }

        public static void  SendMailErrors(DatabaseSetting conf)
        {

            Mail mail = new Mail();
            MailConfiguration mconf = new MailConfiguration();
            mconf.EmailServer = "smtp.gmail.com";
            mconf.EmailPort = "25";
            mconf.EmailEnableSSL = true;
            mconf.EmailUser = "easyconnecterrores@gmail.com";
            mconf.EmailPassword = Crypto.EncrytedString("siesa-123");
            
            
            //Busca correos de los usuario registrados
            SECUser users = (SECUser)EasyApp.Current.eToolsServer().Execute(new SECUser { Active = true }, Actions.Find, Options.All, conf.Name, "");
            List<string> mails = users.Entities.Select(x => x.Email).ToList();
            string destiny = "";
            foreach (string item in mails)
            {
                destiny += item+";";
            }

            //Busca errores en la tabla 
            StringBuilder mailBody = new StringBuilder();
            CONError errors = (CONError)EasyApp.Current.eToolsServer().Execute(new CONError() , Actions.Find, Options.All, conf.Name, "");

            if (errors.Entities != null && errors.Entities.Count > 0)
            {

                mailBody.AppendFormat("<h1>Errores de Importacion</h1>");
                mailBody.AppendFormat("<br />");
                mailBody.AppendFormat("<table border=1 >");
                mailBody.AppendFormat("   <tr>");
                mailBody.AppendFormat("      <td><b>Compañia</b></td>");
                mailBody.AppendFormat("      <td><b>CO</b></td>");
                mailBody.AppendFormat("      <td><b>Tipo</b></td>");
                mailBody.AppendFormat("      <td><b>Consecutivo</b></td>");
                mailBody.AppendFormat("      <td><b>Version</b></td>");
                mailBody.AppendFormat("      <td><b>Valor Error</b></td>");
                mailBody.AppendFormat("      <td><b>Detalle Error</b></td>");
                mailBody.AppendFormat("      <td><b>Llavelogica</b></td>");
                mailBody.AppendFormat("   </tr>");
                for (int i = 0; i < errors.Entities.Count; i++)
                {
                    mailBody.AppendFormat("   <tr>");
                    mailBody.AppendFormat("      <td>{0}</td>", errors.Entities[i].Record.Company);
                    mailBody.AppendFormat("      <td>{0}</td>", errors.Entities[i].Record.OperationCenter);
                    mailBody.AppendFormat("      <td>{0}</td>", errors.Entities[i].Record.DocumentType);
                    mailBody.AppendFormat("      <td>{0}</td>", errors.Entities[i].Record.DocumentNumber);
                    mailBody.AppendFormat("      <td>{0}</td>", errors.Entities[i].Record.RecordType.ToString() + "-" + errors.Entities[i].Record.SubRecordType.ToString() + "-" + errors.Entities[i].Record.Version.ToString());
                    mailBody.AppendFormat("      <td>{0}</td>", errors.Entities[i].ErrorValue);
                    mailBody.AppendFormat("      <td>{0}</td>", errors.Entities[i].ErrorDetail);
                    mailBody.AppendFormat("      <td>{0}</td>", errors.Entities[i].Record.LogicalKey);
                    mailBody.AppendFormat("   </tr>");
                }
                mailBody.AppendFormat("</table>");
            }
                    
                
            try
            {
                mail.SendMail(mconf, destiny, "Informe Errores Importacion "+ DateTime.Now, mailBody.ToString(), true);
                Console.WriteLine("Correo con errores enviado correctamente...");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al enviar notificacion de errores: Detalles: " + e);
            }
        }

        public static void CreateMastersZapa(DatabaseSetting conf)
        {
            CONSQL errors = (CONSQL)EasyApp.Current.eToolsServer().Execute(new CONSQL(), Actions.Generate, Options.Me, conf.Name, "");
        }

    }
}

