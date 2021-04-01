using EasyTools.Framework.Data;
using EasyTools.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities
{
    /// <summary>
    /// CONStructureAssociation object for mapped table CONStructureAssociations.
    /// </summary>
    [DataContract(IsReference = true)]
    public class CONStructureAssociation : BaseCONStructureAssociation
    {

       public CONStructureAssociation() : base()
       {
       }

       public CONStructureAssociation(CONStructureAssociation data, Options option) : base(data, option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light

             if (option == Options.Me || option == Options.All)
             {

                this.MainStructure = (data.MainStructure != null) ? new CONStructure(data.MainStructure, Options.All) : null;
                this.ChildStructure = (data.ChildStructure != null) ? new CONStructure(data.ChildStructure, Options.All) : null; 
             }
          }
       }

       [DataMember]
       public virtual CONStructure MainStructure { get; set; }

       [DataMember]
       public virtual CONStructure ChildStructure { get; set; }

       [DataMember]
       public virtual List<CONStructureAssociation> Entities { get; set; }

       public override Int32 GetHashCode()
       {
           return this.Id.GetHashCode();
       }

       public override Boolean Equals(object obj)
       {
           if ((obj == null) || (obj.GetType() != this.GetType()))
               return false;
           CONStructureAssociation castObj = (CONStructureAssociation)obj;
           return (castObj != null) && (this.Id == castObj.Id);
       }
    }
 }
