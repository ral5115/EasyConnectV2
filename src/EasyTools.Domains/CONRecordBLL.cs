using EasyTools.Domains.Base;
using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace EasyTools.Domains
{
    public class CONRecordBLL : BaseCONRecordBLL
    {
        private CONErrorBLL cONErrorDl;

        private CONRecordDetailBLL cONRecordDetailDl;

        public CONRecordBLL(IUnitOfWork settings)
            : base(settings)
        {
        }

        public CONRecordBLL(DatabaseSetting settings)
            : base(settings)
        {
        }

        public override CONRecord Execute(CONRecord data, Actions action, Options option, string token)
        {
            try
            {
                if (action == Actions.Add || action == Actions.Modify || action == Actions.Remove || (action == Actions.Find && (option == Options.Me || option == Options.Exist)))
                {
                    if ((action == Actions.Add || action == Actions.Modify) && option == Options.All)
                    {
                        BenginTransaction();
                        cONErrorDl = new CONErrorBLL(Work);
                        cONRecordDetailDl = new CONRecordDetailBLL(Work);
                    }
                    data = base.Execute(data, action, option, token);
                    if (action == Actions.Find && option == Options.Me && data != null)
                    {
                        cONErrorDl = new CONErrorBLL(this.Work.Settings);
                        cONRecordDetailDl = new CONRecordDetailBLL(this.Work.Settings);
                        data.Errors1 = cONErrorDl.FindAll(new CONError { RecordId = data.Id }, Options.All);
                        data.RecordDetails = cONRecordDetailDl.FindAll(new CONRecordDetail { RecordId = data.Id }, Options.All);
                    }
                    //if ((action == Actions.Add || action == Actions.Modify) && option == Options.All)
                    //    AddDetails(data);
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
                else if (action == Actions.Process && (option == Options.All || option == Options.Light))
                {
                    //data = ExecuteSQL(data);
                    return data;
                }
                else if (action == Actions.Generate && (option == Options.All || option == Options.Light))
                {
                    if (option == Options.All)
                        data = GenerateOneFile(data);
                    //if (option == Options.Light)
                    //data = GenerateManyFiles(data);
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

        public void AddDetails(CONRecord data)
        {
            
        }

        public override void CommonRules(CONRecord data)
        {
            if (data.IsExternal)
                data.Fields = new Dictionary<string, string>();
            else
                data.GetPlaintText();
            data.XMLData = XMLSerializer.SerializeToString<Dictionary<string, string>>(data.Fields);
            base.CommonRules(data);
        }

        public override void AddRules(CONRecord data)
        {
            base.AddRules(data);
            data.LastUpdate = DateTime.Now;
        }

        public override void ModifyRules(CONRecord data)
        {
            base.ModifyRules(data);
            data.LastUpdate = DateTime.Now;
        }

        public override void RemoveRules(CONRecord data)
        {
            base.RemoveRules(data);
        }

        public override void FindByIdRules(CONRecord data)
        {
            
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONRecord", "CONRecords");
            if (data.Id == 0 && string.IsNullOrWhiteSpace(data.LogicalKey))
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONRecord");
        }

        public CONRecord GenerateOneFile(CONRecord param)
        {
            List<CONRecord> files = new List<CONRecord>();
            string idOperationCenter = "";
            string idDocumentType = "";
            StringBuilder stringXML = new StringBuilder();
            

            for (int i1 = 0; i1 < param.Entities.Count; i1++)
            {
                int j = 1;
                stringXML = new StringBuilder();
                CONInitial inicial = new CONInitial { RecordNumber = j.ToString(), RecordType = "0", SubRecordType = "0", Version = "01", Company = param.Entities[i1].Company + "" };
                stringXML.AppendLine(inicial.PlainText);
                j++;

                if (param.Entities[i1].IsDocument())
                {
                    int? recordType = null;
                    if (param.Entities[i1].RecordType == 450 || param.Entities[i1].RecordType == 461)
                        recordType = 350;
                    else
                        recordType = param.Entities[i1].RecordType;

                    idOperationCenter = "F" + recordType + "_ID_CO";
                    idDocumentType = "F" + recordType + "_ID_TIPO_DOCTO";
                    
                }
                
                if (param.Entities[i1].IsDocument() && param.Entities[i1].DocumentNumber == 0)
                {
                    param.Entities[i1].DocumentNumber = GetConsecutive(param.Entities[i1].Fields[idOperationCenter] + "" + param.Entities[i1].Fields[idDocumentType]);
                    
                }
               

                param.Entities[i1].RecordNumber = j;
                j++;
                stringXML.AppendLine(param.Entities[i1].PlainText.Replace("&", " "));
                if (param.Entities[i1].RecordDetails != null && param.Entities[i1].RecordDetails.Count > 0)
                    for (int i = 0; i < param.Entities[i1].RecordDetails.Count; i++)
                    {
                        param.Entities[i1].RecordDetails[i].RecordNumber = j;
                        param.Entities[i1].RecordDetails[i].DocumentNumber = param.Entities[i1].DocumentNumber;
                        stringXML.AppendLine(param.Entities[i1].RecordDetails[i].PlainText.Replace("&", " "));
                        j++;
                    }



                CONFinal final = new CONFinal { RecordNumber = j.ToString(), RecordType = "9999", SubRecordType = "0", Version = "01", Company = param.Entities[i1].Company + "" };
                stringXML.Append(final.PlainText);
                param.Entities[i1].PlainText = stringXML.ToString();
                j = 0;
                
            }
            return param;
        }
    }
}