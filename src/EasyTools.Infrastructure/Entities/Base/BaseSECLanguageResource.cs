using EasyTools.Framework.Data;
using System;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities.Base
{
    /// <summary>
    /// SECLanguageResource object for mapped table SECLanguageResources.
    /// </summary>
    [DataContract(IsReference = true)]
    public class BaseSECLanguageResource : BaseEntity
    {

       public BaseSECLanguageResource()
       {
       }

       public BaseSECLanguageResource(BaseSECLanguageResource data, Options option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light
             this.Id = data.Id;
                this.ResourceName = data.ResourceName;

             if (option == Options.Me || option == Options.All)
             {

                this.ResourceName = data.ResourceName;
                this.ResourceValue = data.ResourceValue;
                this.UpdatedBy = data.UpdatedBy;
                this.LastUpdate = data.LastUpdate;
                this.LanguageId = data.LanguageId;
             }
          }
       }

       [DataMember]
       public virtual String ResourceName { get; set; }

       [DataMember]
       public virtual String ResourceValue { get; set; }

       [DataMember]
       public virtual Int32 LanguageId { get; set; }


    }
 }
