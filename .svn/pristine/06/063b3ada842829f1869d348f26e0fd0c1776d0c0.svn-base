using EasyTools.Framework.Data;
using System;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities.Base
{
    /// <summary>
    /// CONStructure object for mapped table CONStructures.
    /// </summary>
    [DataContract(IsReference = true)]
    public class BaseCONStructure : BaseEntity
    {

       public BaseCONStructure()
       {
       }

       public BaseCONStructure(BaseCONStructure data, Options option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light
             this.Id = data.Id;
                this.Code = data.Code;
                this.Name = data.Name;
                this.Active = data.Active;

             if (option == Options.Me || option == Options.All)
             {

                this.Code = data.Code;
                this.Name = data.Name;
                this.Version = data.Version;
                this.Main = data.Main;
                this.Active = data.Active;
                this.ColumnNumber = data.ColumnNumber;
                this.UpdatedBy = data.UpdatedBy;
                this.LastUpdate = data.LastUpdate;
                this.IntegratorId = data.IntegratorId;
             }
          }
       }

       [DataMember]
       public virtual String Code { get; set; }

       [DataMember]
       public virtual String Name { get; set; }

       [DataMember]
       public virtual Int32 Version { get; set; }

       [DataMember]
       public virtual Boolean Main { get; set; }

       [DataMember]
       public virtual Boolean Active { get; set; }

       [DataMember]
       public virtual Int16 ColumnNumber { get; set; }

       [DataMember]
       public virtual Int32 IntegratorId { get; set; }


    }
 }
