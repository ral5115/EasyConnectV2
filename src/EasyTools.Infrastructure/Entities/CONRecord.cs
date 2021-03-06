using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities
{
    /// <summary>
    /// CONRecord object for mapped table CONRecords.
    /// </summary>
    [DataContract(IsReference = true)]
    public class CONRecord : BaseCONRecord
    {

       public CONRecord() : base()
       {
       }

       public CONRecord(CONRecord data, Options option) : base(data, option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light
              this.OperationCenter = data.OperationCenter;
              this.DocumentType = data.DocumentType;
              this.DocumentNumber = data.DocumentNumber;
              this.LogicalKey = data.LogicalKey;
              this.RecordType = data.RecordType;
              this.SubRecordType = data.SubRecordType;
              this.Version = data.Version;
             
             if (option == Options.Me || option == Options.All)
             {
                 this.RecordNumber = data.RecordNumber;
                 this.Fields = XMLSerializer.DeserializeFromString<Dictionary<string, string>>(data.XMLData);
                this.SQL = (data.SQL != null) ? new CONSQL(data.SQL, Options.Light) : null; 
             }
          }
       }

       [DataMember]
       public virtual CONSQL SQL { get; set; }

       [DataMember]
       public virtual List<CONRecord> Entities { get; set; }

       [DataMember]
       public virtual List<CONError> Errors1 { get; set; }

       [DataMember]
       public virtual List<CONRecordDetail> RecordDetails { get; set; }

       public override Int32 GetHashCode()
       {
           return this.Id.GetHashCode();
       }

       public override Boolean Equals(object obj)
       {
           if ((obj == null) || (obj.GetType() != this.GetType()))
               return false;
           CONRecord castObj = (CONRecord)obj;
           return (castObj != null) && (this.Id == castObj.Id);
       }

       [DataMember]
       public virtual Dictionary<string, string> Fields { get; set; }

       public virtual void GetPlaintText()
       {
           if (this.Fields != null && this.Fields.Count > 0)
           {
               PlainText = "";
               foreach (var item in Fields)
               {
                   PlainText += item.Value;
               }
           }
       }

       public virtual bool IsDocument()
       {
           for (int i = 0; i < GetDocumentNumberKeys().Count; i++)
           {
               if (GetDocumentNumberKeys()[i].Contains(RecordType.ToString()))
                   return true;
           }
           return false;
       }

       public static List<string> GetRecordNumberKeys()
       {
           List<string> keys = new List<string>();
           keys.Add("F_NUMERO_REG");
           return keys;
       }

       public static List<string> GetDocumentNumberKeys()
       {
           List<string> keys = new List<string>();
           keys.Add("F350_CONSEC_DOCTO");
           keys.Add("F420_CONSEC_DOCTO");
           keys.Add("F421_CONSEC_DOCTO");
           keys.Add("F422_CONSEC_DOCTO");
           keys.Add("F423_CONSEC_DOCTO");
           keys.Add("F470_CONSEC_DOCTO");
           keys.Add("F484_CONSEC_DOCTO");
           keys.Add("F479_CONSEC_DOCTO");
           keys.Add("F471_CONSEC_DOCTO");
           keys.Add("F479_CONSEC_DOCTO");
           keys.Add("F476_CONSEC_DOCTO");
           keys.Add("F440_CONSEC_DOCTO");
           keys.Add("F441_CONSEC_DOCTO");
           keys.Add("F450_CONSEC_DOCTO");
           keys.Add("F461_CONSEC_DOCTO");
           return keys;
       }

       private int? recordNumber;

       [DataMember]
       public virtual int? RecordNumber
       {
           get
           {
               return recordNumber;
           }
           set
           {
               recordNumber = value;
               for (int i = 0; i < CONRecord.GetRecordNumberKeys().Count; i++)
               {
                   if (Fields != null && Fields.ContainsKey(CONRecord.GetRecordNumberKeys()[i]))
                   {
                       Fields[CONRecord.GetRecordNumberKeys()[i]] = Utils.ValidateNumber(recordNumber, 7, CONRecord.GetRecordNumberKeys()[i]);
                       PlainText = "";
                       foreach (var item in Fields)
                       {
                           PlainText += item.Value;
                       }
                   }
                   
               }

           }
       }

       private int? documentNumber;

       [DataMember]
       public virtual Int32? DocumentNumber
       {
           get
           {
               return documentNumber;
           }
           set
           {
               documentNumber = value;
               for (int i = 0; i < CONRecord.GetDocumentNumberKeys().Count; i++)
               {
                   if (Fields != null && Fields.ContainsKey(CONRecord.GetDocumentNumberKeys()[i]))
                   {
                       Fields[CONRecord.GetDocumentNumberKeys()[i]] = Utils.ValidateNumber(documentNumber, 8, CONRecord.GetDocumentNumberKeys()[i]);
                       PlainText = "";
                       foreach (var item in Fields)
                       {
                           PlainText += item.Value;
                       }
                   }
                   return;
               }

           }
       }

    }
 }
