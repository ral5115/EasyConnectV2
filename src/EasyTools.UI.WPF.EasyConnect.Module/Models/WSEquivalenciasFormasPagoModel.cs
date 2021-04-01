using EasyConnect.Infrastructure.Entities;
using EasyTools.Framework.Resources;
using EasyTools.Framework.UI;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EasyTools.UI.WPF.EasyConnect.Module.Models
{
    public class WSEquivalenciasFormasPagoModel : BaseModel
    {

        public BindingList<CONWSEquivalenciasFormasPago> Details 
        {
           get { return GetValue(() => Details); }
           set { SetValue(() => Details, value); }
        }

        public CONWSEquivalenciasFormasPago SelectedWSEquivalenciasFormasPago { get; set; }

        public CONWSEquivalenciasFormasPago Entity 
        { 
           get
           {
               CONWSEquivalenciasFormasPago data = new CONWSEquivalenciasFormasPago();
              data.Id = this.Id;
              data.FormaPagoZapa = this.FormaPagoZapa;
              data.FPagoDet_Zapa = this.FPagoDet_Zapa;
              data.FormaPagoUNOEE = this.FormaPagoUNOEE;
              data.RefFP = this.RefFP;
              data.CuentaContable = this.CuentaContable;
              return data;
                     
           }
           set
           {   
              this.Id = value.Id;
              this.FormaPagoZapa = (String.IsNullOrWhiteSpace(value.FormaPagoZapa) ? "" : value.FormaPagoZapa ) ;
              this.FPagoDet_Zapa = (String.IsNullOrWhiteSpace(value.FPagoDet_Zapa) ? "" : value.FPagoDet_Zapa ) ;
              this.FormaPagoUNOEE = (String.IsNullOrWhiteSpace(value.FormaPagoUNOEE) ? "" : value.FormaPagoUNOEE ) ;
              this.RefFP = (String.IsNullOrWhiteSpace(value.RefFP) ? "" : value.RefFP ) ;
              this.CuentaContable = (String.IsNullOrWhiteSpace(value.CuentaContable) ? "" : value.CuentaContable ) ;
              this.NotifyPropertyChanged("Entity"); 
           }
        }

        [Display(Name = "WSEquivalenciasFormasPagoViewFormaPagoZapaField", ResourceType = typeof(Language))]
        [StringLength(50, ErrorMessageResourceName = "ApplicationErrorStringOptional", ErrorMessageResourceType = typeof(Language))]
         public virtual String FormaPagoZapa
         {
             get { return GetValue(() => FormaPagoZapa); }
             set { SetValue(() => FormaPagoZapa, value); }
         }

        [Display(Name = "WSEquivalenciasFormasPagoViewFPagoDet_ZapaField", ResourceType = typeof(Language))]
        [StringLength(50, ErrorMessageResourceName = "ApplicationErrorStringOptional", ErrorMessageResourceType = typeof(Language))]
         public virtual String FPagoDet_Zapa
         {
             get { return GetValue(() => FPagoDet_Zapa); }
             set { SetValue(() => FPagoDet_Zapa, value); }
         }

        [Display(Name = "WSEquivalenciasFormasPagoViewFormaPagoUNOEEField", ResourceType = typeof(Language))]
        [StringLength(50, ErrorMessageResourceName = "ApplicationErrorStringOptional", ErrorMessageResourceType = typeof(Language))]
         public virtual String FormaPagoUNOEE
         {
             get { return GetValue(() => FormaPagoUNOEE); }
             set { SetValue(() => FormaPagoUNOEE, value); }
         }

        [Display(Name = "WSEquivalenciasFormasPagoViewRefFPField", ResourceType = typeof(Language))]
        [StringLength(50, ErrorMessageResourceName = "ApplicationErrorStringOptional", ErrorMessageResourceType = typeof(Language))]
         public virtual String RefFP
         {
             get { return GetValue(() => RefFP); }
             set { SetValue(() => RefFP, value); }
         }

        [Display(Name = "WSEquivalenciasFormasPagoViewCuentaContableField", ResourceType = typeof(Language))]
        [StringLength(50, ErrorMessageResourceName = "ApplicationErrorStringOptional", ErrorMessageResourceType = typeof(Language))]
         public virtual String CuentaContable
         {
             get { return GetValue(() => CuentaContable); }
             set { SetValue(() => CuentaContable, value); }
         }

    }
}
