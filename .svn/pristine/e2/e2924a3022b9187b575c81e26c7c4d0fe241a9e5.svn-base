using EasyConnect.Infrastructure.Entities.Base;
using EasyTools.Framework.Data;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EasyConnect.Infrastructure.Entities
{
    /// <summary>
    /// WSEquivalenciasFormasPago object for mapped table WS_Equivalencias_Formas_Pago.
    /// </summary>
    [DataContract(IsReference = true)]
    public class CONWSEquivalenciasFormasPago : BaseCONWSEquivalenciasFormasPago
    {

       public CONWSEquivalenciasFormasPago() : base()
       {
       }

       public CONWSEquivalenciasFormasPago(CONWSEquivalenciasFormasPago data, Options option)
           : base(data, option)
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
       public virtual List<CONWSEquivalenciasFormasPago> Entities { get; set; }

       public override Int32 GetHashCode()
       {
          return this.Id.GetHashCode();
       }

       public override Boolean Equals(object obj)
       {
          if ((obj == null) || (obj.GetType() != this.GetType()))
             return false;
          CONWSEquivalenciasFormasPago castObj = (CONWSEquivalenciasFormasPago)obj;
          return (castObj != null) && (this.Id == castObj.Id);
       }

    }
 }
