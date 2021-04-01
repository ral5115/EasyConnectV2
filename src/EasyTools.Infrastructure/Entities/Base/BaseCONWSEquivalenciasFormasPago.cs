using EasyTools.Framework.Data;
using EasyTools.Infrastructure.Entities.Base;
using System;
using System.Runtime.Serialization;

namespace EasyConnect.Infrastructure.Entities.Base
{
    /// <summary>
    /// WSEquivalenciasFormasPago object for mapped table WS_Equivalencias_Formas_Pago.
    /// </summary>
    [DataContract(IsReference = true)]
    public class BaseCONWSEquivalenciasFormasPago : BaseEntity
    {

       public BaseCONWSEquivalenciasFormasPago()
       {
       }

       public BaseCONWSEquivalenciasFormasPago(BaseCONWSEquivalenciasFormasPago data, Options option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light
             this.Id = data.Id;

             if (option == Options.Me || option == Options.All)
             {

                this.FormaPagoZapa = data.FormaPagoZapa;
                this.FPagoDet_Zapa = data.FPagoDet_Zapa;
                this.FormaPagoUNOEE = data.FormaPagoUNOEE;
                this.RefFP = data.RefFP;
                this.CuentaContable = data.CuentaContable;
                //this.UpdatedBy = data.UpdatedBy;
                //this.LastUpdate = data.LastUpdate;
             }
          }
       }

       [DataMember]
       public virtual String FormaPagoZapa { get; set; }

       [DataMember]
       public virtual String FPagoDet_Zapa { get; set; }

       [DataMember]
       public virtual String FormaPagoUNOEE { get; set; }

       [DataMember]
       public virtual String RefFP { get; set; }

       [DataMember]
       public virtual String CuentaContable { get; set; }

    }
 }
