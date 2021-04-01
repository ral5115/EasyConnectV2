using EasyTools.Framework.Data;
using System;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities.Base
{
    /// <summary>
    /// CONSQLParameter object for mapped table CONSQLParameters.
    /// </summary>
    [DataContract(IsReference = true)]
    public class BaseCONSQLParameter : BaseEntity
    {

       public BaseCONSQLParameter()
       {
       }

       public BaseCONSQLParameter(BaseCONSQLParameter data, Options option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light
             this.Id = data.Id;
                this.Name = data.Name;

             if (option == Options.Me || option == Options.All)
             {

                this.Name = data.Name;
                this.IsDate = data.IsDate;
                this.DateValue = data.DateValue;
                this.DefaultDateValue = data.DefaultDateValue;
                this.IsInt = data.IsInt;
                this.Int32Value = data.Int32Value;
                this.IsString = data.IsString;
                this.StringValue = data.StringValue;
                this.Secuence = data.Secuence;
                this.UpdatedBy = data.UpdatedBy;
                this.LastUpdate = data.LastUpdate;
                this.SQLId = data.SQLId;
             }
          }
       }

       [DataMember]
       public virtual String Name { get; set; }

       [DataMember]
       public virtual Boolean IsDate { get; set; }

       [DataMember]
       public virtual DateTime? DateValue { get; set; }

       [DataMember]
       public virtual Int32? DefaultDateValue { get; set; }

       [DataMember]
       public virtual Boolean IsInt { get; set; }

       [DataMember]
       public virtual Int32? Int32Value { get; set; }

       [DataMember]
       public virtual Boolean IsString { get; set; }

       [DataMember]
       public virtual String StringValue { get; set; }

       [DataMember]
       public virtual Int16 Secuence { get; set; }

       [DataMember]
       public virtual Int32 SQLId { get; set; }


    }
 }
