using EasyTools.Framework.Data;
using EasyTools.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities
{
    /// <summary>
    /// SECUser object for mapped table SECUsers.
    /// </summary>
    [DataContract(IsReference = true)]
    public class SECUser : BaseSECUser
    {

       public SECUser() : base()
       {
       }

       public SECUser(SECUser data, Options option) : base(data, option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light

             if (option == Options.Me || option == Options.All)
             {

                this.Role = (data.Role != null) ? new SECRole(data.Role, Options.Light) : null; 
             }
          }
       }

       [DataMember]
       public virtual SECRole Role { get; set; }

       [DataMember]
       public virtual List<SECUser> Entities { get; set; }

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
           SECUser castObj = (SECUser)obj;
           return (castObj != null) && (this.Id == castObj.Id);
       }

    }
 }
