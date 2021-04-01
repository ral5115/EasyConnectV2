using EasyTools.Framework.Data;
using EasyTools.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities
{
    /// <summary>
    /// CONIntegrator object for mapped table CONIntegrators.
    /// </summary>
    [DataContract(IsReference = true)]
    public class CONIntegrator : BaseCONIntegrator
    {

       public CONIntegrator() : base()
       {
       }

       public CONIntegrator(CONIntegrator data, Options option) : base(data, option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light

             if (option == Options.Me || option == Options.All)
             {

             }
          }
       }

       [DataMember]
       public virtual List<CONIntegrator> Entities { get; set; }

       [DataMember]
       public virtual List<CONIntegratorConfiguration> IntegratorConfigurations { get; set; }

       [DataMember]
       public virtual List<CONStructure> Structures { get; set; }

       public override Int32 GetHashCode()
       {
           return this.Id.GetHashCode();
       }

       public override Boolean Equals(object obj)
       {
           if ((obj == null) || (obj.GetType() != this.GetType()))
               return false;
           CONIntegrator castObj = (CONIntegrator)obj;
           return (castObj != null) && (this.Id == castObj.Id);
       }


    }
 }
