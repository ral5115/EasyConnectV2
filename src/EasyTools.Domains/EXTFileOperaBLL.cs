using EasyTools.Domains.Base;
using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;

namespace EasyTools.Domains
{
    public class EXTFileOperaBLL : BaseEXTFileOperaBLL
    {
        private EXTFileOperaDetailBLL eXTFileOperaDetailDl;

        public EXTFileOperaBLL(IUnitOfWork settings)
            : base(settings)
        {
        }

        public EXTFileOperaBLL(DatabaseSetting settings)
            : base(settings)
        {
        }

        public override EXTFileOpera Execute(EXTFileOpera data, Actions action, Options option, string token)
        {
            try
            {
                if (action == Actions.Add || action == Actions.Modify || action == Actions.Remove || (action == Actions.Find && (option == Options.Me || option == Options.Exist)))
                {
                    if ((action == Actions.Add || action == Actions.Modify) && option == Options.All)
                    {
                        BenginTransaction();
                        eXTFileOperaDetailDl = new EXTFileOperaDetailBLL(Work);
                    }
                    data = base.Execute(data, action, option, token);
                    if (action == Actions.Find && option == Options.Me)
                    {
                        eXTFileOperaDetailDl = new EXTFileOperaDetailBLL(this.Work.Settings);
                        data.FileOperaDetails = eXTFileOperaDetailDl.FindAll(new EXTFileOperaDetail { FileOperaId = data.Id }, Options.All);
                    }
                    if ((action == Actions.Add || action == Actions.Modify) && option == Options.All)
                        AddDetails(data);
                    //if (option == Options.All)
                    //    Work.Commit();
                    return data;
                }
                else if (action == Actions.Find && (option == Options.All || option == Options.Light))
                {
                    if (option == Options.All)
                        data.Entities = FindAll(data, Options.All);
                    else if (option == Options.Light)
                        data.Entities = FindAll(data, Options.Light);
                    return data;
                }
                else if (action == Actions.Process && option == Options.All)
                {
                    data = SaveFileOpera();
                    return data;
                }
                else
                    throw new NotImplementedException(GetLocalizedMessage(Language.DLACTIONNOTIMPLEMENT, action.ToString(), option.ToString()));
            }
            catch (FaultException<BusinessException> f)
            {
                Rollback();
                throw f;
            }
            catch (Exception e)
            {
                Rollback();
                throw new BusinessException(e).GetFaultException();
            }
            finally
            {
                Commit();
            }
        }

        public void AddDetails(EXTFileOpera data)
        {
            if (data.FileOperaDetails != null && data.FileOperaDetails.Count > 0)
            {
                for (int i = 0; i < data.FileOperaDetails.Count; i++)
                {
                    data.FileOperaDetails[i].FileOperaId = data.Id;
                    data.FileOperaDetails[i].LastUpdate = DateTime.Now;
                    data.FileOperaDetails[i].UpdatedBy = data.UpdatedBy;
                    if (data.FileOperaDetails[i].Id == 0)
                        data.FileOperaDetails[i] = eXTFileOperaDetailDl.Add(data.FileOperaDetails[i]);
                    else
                        data.FileOperaDetails[i] = eXTFileOperaDetailDl.Modify(data.FileOperaDetails[i]);
                }
            }
        }

        public override void CommonRules(EXTFileOpera data)
        {
            base.CommonRules(data);
        }

        public override void AddRules(EXTFileOpera data)
        {
            base.AddRules(data);
            data.LastUpdate = DateTime.Now;
        }

        public override void ModifyRules(EXTFileOpera data)
        {
            base.ModifyRules(data);
            data.LastUpdate = DateTime.Now;
        }

        public override void RemoveRules(EXTFileOpera data)
        {
            base.RemoveRules(data);
        }

        public override void FindByIdRules(EXTFileOpera data)
        {
            base.FindByIdRules(data);
        }

        public EXTFileOpera SaveFileOpera()
        {
            List<EXTFileOpera> filetxt = new List<EXTFileOpera>();

            String dateOpera = Convert.ToString(DateTime.Now);
            String Yeartxt = dateOpera.Substring(8, 2);
            String Monthtxt = dateOpera.Substring(3, 2);
            String Daytxt = dateOpera.Substring(0, 2);
            dateOpera = Yeartxt + Monthtxt + Daytxt;
            String Operatxt = "trial_spiwak" + dateOpera + ".txt";

            //String Operatxt = "trial_spiwak140709.txt";
            EXTFileOpera data = new EXTFileOpera();
            data.Name = Operatxt;
            filetxt = FindAll(data, Options.Light);

            if (filetxt == null || filetxt.Count == 0)
            {
                data = FileOpera(data);
                data.UpdatedBy = "archivo Diario";
                data = Execute(data, Actions.Add, Options.All, "");
                data.AddAditionalProperty("mensaje", "Archivo de Opera Cargado exitosamente...");
            }
            else
            {
                data.AddAditionalProperty("mensaje", "Opera ya fue Cargado el dia de hoy...");
            }

            return data;


        }

        public EXTFileOpera FileOpera(EXTFileOpera data1)
        {


            try
            {
                //String dateOpera = Convert.ToString(DateTime.Now);
                //String Yeartxt = dateOpera.Substring(8, 2);
                //String Monthtxt = dateOpera.Substring(3, 2);
                //String Daytxt = dateOpera.Substring(0, 2);
                //dateOpera = Yeartxt + Monthtxt + Daytxt;

                StreamReader file = new StreamReader("C:\\Users\\Public\\Documents\\Operatxt\\exportation_test.txt");

                string line = "";
                List<String> arrText = new List<String>();
                while (line != null)
                {
                    line = file.ReadLine();
                    if (line != null && line != "")
                        arrText.Add(line);
                }
                file.Close();

                List<EXTFileOperaDetail> fileData = new List<EXTFileOperaDetail>();

                for (int i = 1; i < arrText.Count; i++)
                {

                    var datas = arrText[i].Split(char.Parse("|"));
                    //datas.Split(char.Parse("|"));
                    EXTFileOperaDetail data = new EXTFileOperaDetail();
                    data.COD_D = datas[0];
                    data.HAB = datas[1];
                    data.RESERVA = datas[2];
                    data.VALOR = datas[3];
                    data.FECHA = datas[4];
                    data.DIA = datas[5];
                    data.IVA = datas[6];
                    data.PAGO = datas[7];
                    data.IMP1 = datas[8];
                    data.NIT = datas[9];
                    data.TIPO_DOC = datas[10];
                    data.TRX_NO = datas[11];
                    data.BILL_NO = datas[12];
                    data.FACT_ASOC = datas[13];
                    data.ORIGINAL_ROOM = datas[14];
                    data.ORIGINAL_RESV = datas[15];
                    data.RESV_ACTUAL = datas[16];
                    data.SUC = datas[17];
                    data.CAJERO = datas[18];
                    data.FVENCIMIENTO = datas[19];
                    data.REFERENCIA = datas[20];
                    data.VTARJETA = datas[21];
                    data.TASACAMBIO = datas[22];
                    data.CURRENCY = datas[23];
                    data.TIPO_FAC = datas[24];

                    //data.FileOpera = new INTFileOpera();

                    fileData.Add(data);



                }


                data1.FileOperaDetails = fileData;
                return data1;

            }
            catch (Exception e)
            {

                throw new Exception("El archivo Opera no existe, por favor revise el directorio e inicie de nuevo la aplicacion", e);

            }

        }
    }
}