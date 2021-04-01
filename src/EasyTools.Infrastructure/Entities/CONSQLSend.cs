using EasyTools.Framework.Data;
using EasyTools.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities
{
    /// <summary>
    /// CONSQLSend object for mapped table CONSQLSends.
    /// </summary>
    [DataContract(IsReference = true)]
    public class CONSQLSend : BaseCONSQLSend
    {

       public CONSQLSend() : base()
       {
       }

       public CONSQLSend(CONSQLSend data, Options option) : base(data, option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light

             if (option == Options.Me || option == Options.All)
             {

                 this.CONIntegratorConfiguration = (data.CONIntegratorConfiguration != null) ? new CONIntegratorConfiguration(data.CONIntegratorConfiguration, Options.All) : null; 
                this.SQL = (data.SQL != null) ? new CONSQL(data.SQL, Options.Light) : null; 
             }
          }
       }

       [DataMember]
       public virtual CONIntegratorConfiguration CONIntegratorConfiguration { get; set; }

       [DataMember]
       public virtual CONSQL SQL { get; set; }

       [DataMember]
       public virtual List<CONSQLSend> Entities { get; set; }

       public override Int32 GetHashCode()
       {
           return this.Id.GetHashCode();
       }

       public override Boolean Equals(object obj)
       {
           if ((obj == null) || (obj.GetType() != this.GetType()))
               return false;
           CONSQLSend castObj = (CONSQLSend)obj;
           return (castObj != null) && (this.Id == castObj.Id);
       }
    }
 }
