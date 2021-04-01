using EasyTools.Framework.Data;
using System;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities.Base
{
    /// <summary>
    /// EXTFileOperaDetail object for mapped table EXTFileOperaDetails.
    /// </summary>
    [DataContract(IsReference = true)]
    public class BaseEXTFileOperaDetail : BaseEntity
    {

       public BaseEXTFileOperaDetail()
       {
       }

       public BaseEXTFileOperaDetail(BaseEXTFileOperaDetail data, Options option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light
             this.Id = data.Id;

             if (option == Options.Me || option == Options.All)
             {

                this.COD_D = data.COD_D;
                this.HAB = data.HAB;
                this.RESERVA = data.RESERVA;
                this.VALOR = data.VALOR;
                this.FECHA = data.FECHA;
                this.DIA = data.DIA;
                this.IVA = data.IVA;
                this.PAGO = data.PAGO;
                this.IMP1 = data.IMP1;
                this.NIT = data.NIT;
                this.TIPO_DOC = data.TIPO_DOC;
                this.TRX_NO = data.TRX_NO;
                this.BILL_NO = data.BILL_NO;
                this.ORIGINAL_ROOM = data.ORIGINAL_ROOM;
                this.ORIGINAL_RESV = data.ORIGINAL_RESV;
                this.RESV_ACTUAL = data.RESV_ACTUAL;
                this.SUC = data.SUC;
                this.CAJERO = data.CAJERO;
                this.FVENCIMIENTO = data.FVENCIMIENTO;
                this.REFERENCIA = data.REFERENCIA;
                this.VTARJETA = data.VTARJETA;
                this.TASACAMBIO = data.TASACAMBIO;
                this.CURRENCY = data.CURRENCY;
                this.TIPO_FAC = data.TIPO_FAC;
                this.FACT_ASOC = data.FACT_ASOC;
                this.UpdatedBy = data.UpdatedBy;
                this.LastUpdate = data.LastUpdate;
                this.FileOperaId = data.FileOperaId;
             }
          }
       }

       [DataMember]
       public virtual String COD_D { get; set; }

       [DataMember]
       public virtual String HAB { get; set; }

       [DataMember]
       public virtual String RESERVA { get; set; }

       [DataMember]
       public virtual String VALOR { get; set; }

       [DataMember]
       public virtual String FECHA { get; set; }

       [DataMember]
       public virtual String DIA { get; set; }

       [DataMember]
       public virtual String IVA { get; set; }

       [DataMember]
       public virtual String PAGO { get; set; }

       [DataMember]
       public virtual String IMP1 { get; set; }

       [DataMember]
       public virtual String NIT { get; set; }

       [DataMember]
       public virtual String TIPO_DOC { get; set; }

       [DataMember]
       public virtual String TRX_NO { get; set; }

       [DataMember]
       public virtual String BILL_NO { get; set; }

       [DataMember]
       public virtual String ORIGINAL_ROOM { get; set; }

       [DataMember]
       public virtual String ORIGINAL_RESV { get; set; }

       [DataMember]
       public virtual String RESV_ACTUAL { get; set; }

       [DataMember]
       public virtual String SUC { get; set; }

       [DataMember]
       public virtual String CAJERO { get; set; }

       [DataMember]
       public virtual String FVENCIMIENTO { get; set; }

       [DataMember]
       public virtual String REFERENCIA { get; set; }

       [DataMember]
       public virtual String VTARJETA { get; set; }

       [DataMember]
       public virtual String TASACAMBIO { get; set; }

       [DataMember]
       public virtual String CURRENCY { get; set; }

       [DataMember]
       public virtual String TIPO_FAC { get; set; }

       [DataMember]
       public virtual String FACT_ASOC { get; set; }

       [DataMember]
       public virtual Int32 FileOperaId { get; set; }


    }
 }
