using EasyTools.Framework.Data;
using System;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities.Base
{
    /// <summary>
    /// SECRol object for mapped table SECRols.
    /// </summary>
    [DataContract(IsReference = true)]
    public class BaseSECRol : BaseEntity
    {

       public BaseSECRol()
       {
       }

       public BaseSECRol(BaseSECRol data, Options option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light
             this.Id = data.Id;
                this.Name = data.Name;
                this.Active = data.Active;

             if (option == Options.Me || option == Options.All)
             {

                this.Name = data.Name;
                this.Active = data.Active;
                this.UpdatedBy = data.UpdatedBy;
                this.LastUpdate = data.LastUpdate;
             }
          }
       }

       [DataMember]
       public virtual String Name { get; set; }

       [DataMember]
       public virtual Boolean Active { get; set; }


    }
 }
