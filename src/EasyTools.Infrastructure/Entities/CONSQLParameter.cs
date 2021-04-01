using EasyTools.Framework.Data;
using EasyTools.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities
{
    /// <summary>
    /// CONSQLParameter object for mapped table CONSQLParameters.
    /// </summary>
    [DataContract(IsReference = true)]
    public class CONSQLParameter : BaseCONSQLParameter
    {

       public CONSQLParameter() : base()
       {
       }

       public CONSQLParameter(CONSQLParameter data, Options option) : base(data, option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light

             if (option == Options.Me || option == Options.All)
             {

                this.SQL = (data.SQL != null) ? new CONSQL(data.SQL, Options.Light) : null; 
             }
          }
       }

       [DataMember]
       public virtual CONSQL SQL { get; set; }

       [DataMember]
       public virtual List<CONSQLParameter> Entities { get; set; }

       public override Int32 GetHashCode()
       {
           return this.Id.GetHashCode();
       }

       public override Boolean Equals(object obj)
       {
           if ((obj == null) || (obj.GetType() != this.GetType()))
               return false;
           CONSQLParameter castObj = (CONSQLParameter)obj;
           return (castObj != null) && (this.Id == castObj.Id);
       }
    }
 }
