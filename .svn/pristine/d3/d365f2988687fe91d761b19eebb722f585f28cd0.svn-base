using EasyTools.Framework.Data;
using EasyTools.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities
{
    /// <summary>
    /// CONEquivalence object for mapped table CONEquivalences.
    /// </summary>
    [DataContract(IsReference = true)]
    public class CONEquivalence : BaseCONEquivalence
    {

       public CONEquivalence() : base()
       {
       }

       public CONEquivalence(CONEquivalence data, Options option) : base(data, option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light

             if (option == Options.Me || option == Options.All)
             {

                this.Company = (data.Company != null) ? new SECCompany(data.Company, Options.Light) : null; 
             }
          }
       }

       [DataMember]
       public virtual SECCompany Company { get; set; }

       [DataMember]
       public virtual List<CONEquivalence> Entities { get; set; }

       [DataMember]
       public virtual List<CONEquivalenceDetail> EquivalenceDetails { get; set; }

       [DataMember]
       public virtual List<CONSQLDetail> SQLDetails { get; set; }

       public override Int32 GetHashCode()
       {
           return this.Id.GetHashCode();
       }

       public override Boolean Equals(object obj)
       {
           if ((obj == null) || (obj.GetType() != this.GetType()))
               return false;
           CONEquivalence castObj = (CONEquivalence)obj;
           return (castObj != null) && (this.Id == castObj.Id);
       }
    }
 }
