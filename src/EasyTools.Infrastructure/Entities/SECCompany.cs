using EasyTools.Framework.Data;
using EasyTools.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities
{
    /// <summary>
    /// SECCompany object for mapped table SECCompanies.
    /// </summary>
    [DataContract(IsReference = true)]
    public class SECCompany : BaseSECCompany
    {

       public SECCompany() : base()
       {
       }

       public SECCompany(SECCompany data, Options option) : base(data, option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light

             if (option == Options.Me || option == Options.All)
             {

             }
          }
       }

       [DataMember]
       public virtual List<SECCompany> Entities { get; set; }

       [DataMember]
       public virtual List<CONEquivalence> Equivalences { get; set; }

       [DataMember]
       public virtual List<CONIntegratorConfiguration> IntegratorConfigurations { get; set; }

       [DataMember]
       public virtual List<CONSQL> SQLs { get; set; }

       [DataMember]
       public virtual List<SECConnection> Connections { get; set; }

       [DataMember]
       public virtual List<SECUserCompany> UserCompanies { get; set; }

       public override Int32 GetHashCode()
       {
           return this.Id.GetHashCode();
       }

       public override Boolean Equals(object obj)
       {
           if ((obj == null) || (obj.GetType() != this.GetType()))
               return false;
           SECCompany castObj = (SECCompany)obj;
           return (castObj != null) && (this.Id == castObj.Id);
       }
    }
 }
