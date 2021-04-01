using EasyTools.Framework.Data;
using EasyTools.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities
{
    /// <summary>
    /// CONError object for mapped table CONErrors.
    /// </summary>
    [DataContract(IsReference = true)]
    public class CONError : BaseCONError
    {

       public CONError() : base()
       {
       }

       public CONError(CONError data, Options option) : base(data, option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light

             if (option == Options.Me || option == Options.All)
             {

                this.Record = (data.Record != null) ? new CONRecord(data.Record, Options.Light) : null; 
             }
          }
       }

       [DataMember]
       public virtual CONRecord Record { get; set; }

       [DataMember]
       public virtual List<CONError> Entities { get; set; }

       public override Int32 GetHashCode()
       {
           return this.Id.GetHashCode();
       }

       public override Boolean Equals(object obj)
       {
           if ((obj == null) || (obj.GetType() != this.GetType()))
               return false;
           CONError castObj = (CONError)obj;
           return (castObj != null) && (this.Id == castObj.Id);
       }
    }
 }
