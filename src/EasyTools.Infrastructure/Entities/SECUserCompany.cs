using EasyTools.Framework.Data;
using EasyTools.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities
{
    /// <summary>
    /// SECUserCompany object for mapped table SECUserCompanies.
    /// </summary>
    [DataContract(IsReference = true)]
    public class SECUserCompany : BaseSECUserCompany
    {

       public SECUserCompany() : base()
       {
       }

       public SECUserCompany(SECUserCompany data, Options option) : base(data, option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light

             if (option == Options.Me || option == Options.All)
             {

                this.Company = (data.Company != null) ? new SECCompany(data.Company, Options.Light) : null; 
                this.User = (data.User != null) ? new SECUser(data.User, Options.Light) : null; 
             }
          }
       }

       [DataMember]
       public virtual SECCompany Company { get; set; }

       [DataMember]
       public virtual SECUser User { get; set; }

       [DataMember]
       public virtual List<SECUserCompany> Entities { get; set; }

       public override Int32 GetHashCode()
       {
           return this.Id.GetHashCode();
       }

       public override Boolean Equals(object obj)
       {
           if ((obj == null) || (obj.GetType() != this.GetType()))
               return false;
           SECUserCompany castObj = (SECUserCompany)obj;
           return (castObj != null) && (this.Id == castObj.Id);
       }
    }
 }
