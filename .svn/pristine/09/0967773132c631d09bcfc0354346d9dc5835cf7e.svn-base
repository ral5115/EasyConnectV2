using EasyTools.Framework.Data;
using EasyTools.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities
{
    /// <summary>
    /// CONStructure object for mapped table CONStructures.
    /// </summary>
    [DataContract(IsReference = true)]
    public class CONStructure : BaseCONStructure
    {

       public CONStructure() : base()
       {
       }

       public CONStructure(CONStructure data, Options option) : base(data, option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light

             if (option == Options.Me || option == Options.All)
             {

                this.Integrator = (data.Integrator != null) ? new CONIntegrator(data.Integrator, Options.Light) : null; 
             }
          }
       }

       [DataMember]
       public virtual CONIntegrator Integrator { get; set; }

       [DataMember]
       public virtual List<CONStructure> Entities { get; set; }

       [DataMember]
       public virtual List<CONSQL> SQLs { get; set; }

       [DataMember]
       public virtual List<CONStructureAssociation> MainStructures { get; set; }

       [DataMember]
       public virtual List<CONStructureAssociation> ChildStructures { get; set; }

       [DataMember]
       public virtual List<CONStructureDetail> StructureDetails { get; set; }

       public override Int32 GetHashCode()
       {
           return this.Id.GetHashCode();
       }

       public override Boolean Equals(object obj)
       {
           if ((obj == null) || (obj.GetType() != this.GetType()))
               return false;
           CONStructure castObj = (CONStructure)obj;
           return (castObj != null) && (this.Id == castObj.Id);
       }
    }
 }
