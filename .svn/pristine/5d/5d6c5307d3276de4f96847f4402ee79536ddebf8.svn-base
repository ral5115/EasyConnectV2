using EasyTools.Framework.Data;
using System;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities.Base
{
    /// <summary>
    /// EXTFileOpera object for mapped table EXTFileOpera.
    /// </summary>
    [DataContract(IsReference = true)]
    public class BaseEXTFileOpera : BaseEntity
    {

       public BaseEXTFileOpera()
       {
       }

       public BaseEXTFileOpera(BaseEXTFileOpera data, Options option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light
             this.Id = data.Id;
                this.Name = data.Name;

             if (option == Options.Me || option == Options.All)
             {

                this.Name = data.Name;
                this.UpdatedBy = data.UpdatedBy;
                this.LastUpdate = data.LastUpdate;
             }
          }
       }

       [DataMember]
       public virtual String Name { get; set; }


    }
 }
