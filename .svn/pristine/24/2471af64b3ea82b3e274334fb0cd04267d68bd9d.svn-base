using EasyTools.Framework.Data;
using System;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities.Base
{
    /// <summary>
    /// CONError object for mapped table CONErrors.
    /// </summary>
    [DataContract(IsReference = true)]
    public class BaseCONError : BaseEntity
    {

       public BaseCONError()
       {
       }

       public BaseCONError(BaseCONError data, Options option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light
             this.Id = data.Id;

             if (option == Options.Me || option == Options.All)
             {

                this.ErrorLevel = data.ErrorLevel;
                this.ErrorValue = data.ErrorValue;
                this.ErrorDetail = data.ErrorDetail;
                //this.CreatedBy = data.CreatedBy;
                //this.CreationDate = data.CreationDate;
                //this.UpdateBy = data.UpdateBy;
                //this.UpdateDate = data.UpdateDate;
                this.UpdatedBy = data.UpdatedBy;
                this.LastUpdate = data.LastUpdate;
                this.RecordNumber = data.RecordNumber;
                this.RecordType = data.RecordType;
                this.SubRecordType = data.SubRecordType;
                this.Version = data.Version;
                this.RecordId = data.RecordId;
             }
          }
       }

       [DataMember]
       public virtual Int16 ErrorLevel { get; set; }

       [DataMember]
       public virtual String ErrorValue { get; set; }

       [DataMember]
       public virtual String ErrorDetail { get; set; }

       //[DataMember]
       //public virtual String CreatedBy { get; set; }

       //[DataMember]
       //public virtual DateTime CreationDate { get; set; }

       //[DataMember]
       //public virtual String UpdateBy { get; set; }

       //[DataMember]
       //public virtual DateTime UpdateDate { get; set; }

       [DataMember]
       public virtual Int32 RecordNumber { get; set; }

       [DataMember]
       public virtual Int32 RecordType { get; set; }

       [DataMember]
       public virtual Int32 SubRecordType { get; set; }

       [DataMember]
       public virtual Int32 Version { get; set; }

       [DataMember]
       public virtual Int32 RecordId { get; set; }


    }
 }
