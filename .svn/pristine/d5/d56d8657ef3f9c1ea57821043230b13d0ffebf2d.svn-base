using EasyTools.Framework.Data;
using System;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities.Base
{
    /// <summary>
    /// SECLanguage object for mapped table SECLanguages.
    /// </summary>
    [DataContract(IsReference = true)]
    public class BaseSECLanguage : BaseEntity
    {

       public BaseSECLanguage()
       {
       }

       public BaseSECLanguage(BaseSECLanguage data, Options option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light
             this.Id = data.Id;
                this.Name = data.Name;
                this.UniqueSeoCode = data.UniqueSeoCode;

             if (option == Options.Me || option == Options.All)
             {

                this.Name = data.Name;
                this.Culture = data.Culture;
                this.UniqueSeoCode = data.UniqueSeoCode;
                this.UpdatedBy = data.UpdatedBy;
                this.LastUpdate = data.LastUpdate;
             }
          }
       }

       [DataMember]
       public virtual String Name { get; set; }

       [DataMember]
       public virtual String Culture { get; set; }

       [DataMember]
       public virtual String UniqueSeoCode { get; set; }


    }
 }
