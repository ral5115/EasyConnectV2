using EasyTools.Framework.Data;
using System;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities.Base
{
    /// <summary>
    /// CONIntegrator object for mapped table CONIntegrators.
    /// </summary>
    [DataContract(IsReference = true)]
    public class BaseCONIntegrator : BaseEntity
    {

       public BaseCONIntegrator()
       {
       }

       public BaseCONIntegrator(BaseCONIntegrator data, Options option)
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
                this.XMLDefinition = data.XMLDefinition;
                this.XMLRoot = data.XMLRoot;
                this.UpdatedBy = data.UpdatedBy;
                this.LastUpdate = data.LastUpdate;
             }
          }
       }

       [DataMember]
       public virtual String Name { get; set; }

       [DataMember]
       public virtual Boolean Active { get; set; }

       [DataMember]
       public virtual String XMLDefinition { get; set; }

       [DataMember]
       public virtual String XMLRoot { get; set; }


    }
 }
