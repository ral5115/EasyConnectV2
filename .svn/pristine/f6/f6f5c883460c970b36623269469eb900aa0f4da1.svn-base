using EasyTools.Framework.Data;
using System;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities.Base
{
    /// <summary>
    /// CONStructureAssociation object for mapped table CONStructureAssociations.
    /// </summary>
    [DataContract(IsReference = true)]
    public class BaseCONStructureAssociation : BaseEntity
    {

       public BaseCONStructureAssociation()
       {
       }

       public BaseCONStructureAssociation(BaseCONStructureAssociation data, Options option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light
             this.Id = data.Id;
                this.Active = data.Active;

             if (option == Options.Me || option == Options.All)
             {

                this.Active = data.Active;
                this.UpdatedBy = data.UpdatedBy;
                this.LastUpdate = data.LastUpdate;
                this.MainStructureId = data.MainStructureId;
                this.ChildStructureId = data.ChildStructureId;
             }
          }
       }

       [DataMember]
       public virtual Boolean Active { get; set; }

       [DataMember]
       public virtual Int32 MainStructureId { get; set; }

       [DataMember]
       public virtual Int32 ChildStructureId { get; set; }


    }
 }
