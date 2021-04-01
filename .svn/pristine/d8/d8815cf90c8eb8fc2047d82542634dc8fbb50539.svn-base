using EasyTools.Framework.Data;
using System;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities.Base
{
    /// <summary>
    /// CONRecord object for mapped table CONRecords.
    /// </summary>
    [DataContract(IsReference = true)]
    public class BaseCONRecord : BaseEntity
    {

       public BaseCONRecord()
       {
       }

        public BaseCONRecord(BaseCONRecord data, Options option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light
             this.Id = data.Id;
             this.Company = data.Company;
             this.LogicalKey = data.LogicalKey;
             this.OperationCenter = data.OperationCenter;
             this.DocumentType = data.DocumentType;
             
              if (option == Options.Me || option == Options.All)
             {

                //this.RecordNumber = data.RecordNumber;
                this.RecordType = data.RecordType;
                this.SubRecordType = data.SubRecordType;
                this.Version = data.Version;
                
                this.IsSend = data.IsSend;
                
                //this.DocumentNumber = data.DocumentNumber;
                this.XMLData = data.XMLData;
                this.IsExternal = data.IsExternal;
                
                this.PlainText = data.PlainText;
                this.UpdatedBy = data.UpdatedBy;
                this.LastUpdate = data.LastUpdate;
                this.SQLId = data.SQLId;
             }
          }
       }

       //[DataMember]
       //public virtual Int32? RecordNumber { get; set; }



       [DataMember]
       public virtual Int32? RecordType { get; set; }

       [DataMember]
       public virtual Int32? SubRecordType { get; set; }

       [DataMember]
       public virtual Int32? Version { get; set; }

       [DataMember]
       public virtual String Company { get; set; }

       [DataMember]
       public virtual Boolean IsSend { get; set; }

       [DataMember]
       public virtual String LogicalKey { get; set; }

       //[DataMember]
       //public virtual Int32? DocumentNumber { get; set; }

       [DataMember]
       public virtual String XMLData { get; set; }

       [DataMember]
       public virtual Boolean IsExternal { get; set; }

       [DataMember]
       public virtual String OperationCenter { get; set; }

       [DataMember]
       public virtual String DocumentType { get; set; }

       [DataMember]
       public virtual String PlainText { get; set; }

       [DataMember]
       public virtual Int32? SQLId { get; set; }


    }

      
 }
