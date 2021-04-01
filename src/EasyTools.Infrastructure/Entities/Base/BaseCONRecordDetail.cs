using EasyTools.Framework.Data;
using System;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities.Base
{
    /// <summary>
    /// CONRecordDetail object for mapped table CONRecordDetails.
    /// </summary>
    [DataContract(IsReference = true)]
    public class BaseCONRecordDetail : BaseEntity
    {

       public BaseCONRecordDetail()
       {
       }

       public BaseCONRecordDetail(BaseCONRecordDetail data, Options option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light
             this.Id = data.Id;

             if (option == Options.Me || option == Options.All)
             {

                //this.RecordNumber = data.RecordNumber;
                this.RecordType = data.RecordType;
                this.SubRecordType = data.SubRecordType;
                this.Version = data.Version;
                this.Company = data.Company;
                this.UpdatedBy = data.UpdatedBy;
                this.LastUpdate = data.LastUpdate;
                this.LogicalKey = data.LogicalKey;
                //this.DocumentNumber = data.DocumentNumber;
                this.XMLData = data.XMLData;
                this.OperationCenter = data.OperationCenter;
                this.DocumentType = data.DocumentType;
                this.PlainText = data.PlainText;
                this.SQLId = data.SQLId;
                this.RecordId = data.RecordId;
             }
          }
       }

       //[DataMember]
       //public virtual Int32 RecordNumber { get; set; }

       [DataMember]
       public virtual Int32 RecordType { get; set; }

       [DataMember]
       public virtual Int32 SubRecordType { get; set; }

       [DataMember]
       public virtual Int32 Version { get; set; }

       [DataMember]
       public virtual String Company { get; set; }

       
       [DataMember]
       public virtual String LogicalKey { get; set; }

       //[DataMember]
       //public virtual Int32? DocumentNumber { get; set; }

       [DataMember]
       public virtual String XMLData { get; set; }

       [DataMember]
       public virtual String OperationCenter { get; set; }

       [DataMember]
       public virtual String DocumentType { get; set; }

       [DataMember]
       public virtual String PlainText { get; set; }

       [DataMember]
       public virtual Int32? SQLId { get; set; }

       [DataMember]
       public virtual Int32 RecordId { get; set; }


    }
 }
