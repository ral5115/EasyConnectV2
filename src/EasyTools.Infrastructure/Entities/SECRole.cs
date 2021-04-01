using EasyTools.Framework.Data;
using EasyTools.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities
{
    /// <summary>
    /// SECRole object for mapped table SECRols.
    /// </summary>
    [DataContract(IsReference = true)]
    public class SECRole : BaseSECRole
    {

       public SECRole() : base()
       {
       }

       public SECRole(SECRole data, Options option) : base(data, option)
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
       public virtual List<SECRole> Entities { get; set; }

       [DataMember]
       public virtual List<SECRolePermission> RolePermissions { get; set; }

       [DataMember]
       public virtual List<SECUser> Users { get; set; }

       public override Int32 GetHashCode()
       {
           return this.Id.GetHashCode();
       }

       public override Boolean Equals(object obj)
       {
           if ((obj == null) || (obj.GetType() != this.GetType()))
               return false;
           SECRole castObj = (SECRole)obj;
           return (castObj != null) && (this.Id == castObj.Id);
       }

    }
 }
