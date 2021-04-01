using EasyTools.Framework.Data;
using EasyTools.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities
{
    /// <summary>
    /// SECRolePermission object for mapped table SECRolePermissions.
    /// </summary>
    [DataContract(IsReference = true)]
    public class SECRolePermission : BaseSECRolePermission
    {

       public SECRolePermission() : base()
       {
       }

       public SECRolePermission(SECRolePermission data, Options option) : base(data, option)
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
       public virtual List<SECRolePermission> Entities { get; set; }


    }
 }
