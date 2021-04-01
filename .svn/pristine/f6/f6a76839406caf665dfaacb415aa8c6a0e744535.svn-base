using EasyConnect.Infrastructure.Entities;
using EasyTools.Framework.Resources;
using EasyTools.Framework.UI;

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EasyTools.UI.WPF.EasyConnect.Module.Models
{
    public class WSCONCESIONEModel : BaseModel
    {
        
        public BindingList<WSCONCESIONE> Details 
        {
           get { return GetValue(() => Details); }
           set { SetValue(() => Details, value); }
        }

        public WSCONCESIONE SelectedWSCONCESIONE { get; set; }

        public WSCONCESIONE Entity 
        { 
           get
           {   
              WSCONCESIONE data = new WSCONCESIONE();
              data.Id = this.Id;
               data.RazonSocial = this.RazonSocial;
              data.NomComercial = this.NomComercial;
              data.Cif = this.Cif;
              data.FechaAlta = this.FechaAlta;
              data.FechaBaja = this.FechaBaja;
              data.Tratamiento = this.Tratamiento;
              data.FechaModificacion = this.FechaModificacion;
              return data;
                     
           }
           set
           {   
              this.Id = value.Id;
             
                this.RazonSocial = (String.IsNullOrWhiteSpace(value.RazonSocial) ? "" : value.RazonSocial ) ;
              this.NomComercial = (String.IsNullOrWhiteSpace(value.NomComercial) ? "" : value.NomComercial ) ;
              this.Cif = (String.IsNullOrWhiteSpace(value.Cif) ? "" : value.Cif ) ;
              this.FechaAlta = value.FechaAlta;
              this.FechaBaja = value.FechaBaja;
              this.Tratamiento = (String.IsNullOrWhiteSpace(value.Tratamiento) ? "" : value.Tratamiento ) ;
              this.FechaModificacion = value.FechaModificacion;
              this.NotifyPropertyChanged("Entity"); 
           }
        }

        [Display(Name = "WSCONCESIONEViewIdConcesionField", ResourceType = typeof(Language))]
        public virtual Int32 Id
        {
            get { return GetValue(() => Id); }
            set { SetValue(() => Id, value); }
        }

        [Display(Name = "WSCONCESIONEViewRazonSocialField", ResourceType = typeof(Language))]
        [StringLength(100, ErrorMessageResourceName = "ApplicationErrorStringRequired", ErrorMessageResourceType = typeof(Language), MinimumLength=1)]
         public virtual String RazonSocial
         {
             get { return GetValue(() => RazonSocial); }
             set { SetValue(() => RazonSocial, value); }
         }

        [Display(Name = "WSCONCESIONEViewNomComercialField", ResourceType = typeof(Language))]
        [StringLength(50, ErrorMessageResourceName = "ApplicationErrorStringOptional", ErrorMessageResourceType = typeof(Language), MinimumLength=1)]
         public virtual String NomComercial
         {
             get { return GetValue(() => NomComercial); }
             set { SetValue(() => NomComercial, value); }
         }

        [Display(Name = "WSCONCESIONEViewCifField", ResourceType = typeof(Language))]
        [StringLength(20, ErrorMessageResourceName = "ApplicationErrorStringOptional", ErrorMessageResourceType = typeof(Language), MinimumLength=1)]
         public virtual String Cif
         {
             get { return GetValue(() => Cif); }
             set { SetValue(() => Cif, value); }
         }

        [Display(Name = "WSCONCESIONEViewFechaAltaField", ResourceType = typeof(Language))]
         public virtual DateTime? FechaAlta 
         {
             get { return GetValue(() => FechaAlta); }
             set { SetValue(() => FechaAlta, value); }
         }

        [Display(Name = "WSCONCESIONEViewFechaBajaField", ResourceType = typeof(Language))]
         public virtual DateTime? FechaBaja 
         {
             get{ return GetValue(() => FechaBaja); }
             set{ SetValue(() => FechaBaja, value); }
         }

        [Display(Name = "WSCONCESIONEViewTratamientoField", ResourceType = typeof(Language))]
        [StringLength(15, ErrorMessageResourceName = "ApplicationErrorStringOptional", ErrorMessageResourceType = typeof(Language), MinimumLength=1)]
         public virtual String Tratamiento
         {
             get { return GetValue(() => Tratamiento); }
             set { SetValue(() => Tratamiento, value); }
         }

        [Display(Name = "WSCONCESIONEViewFechaModificacionField", ResourceType = typeof(Language))]
         public virtual DateTime? FechaModificacion 
         {
             get { return GetValue(() => FechaModificacion); }
             set { SetValue(() => FechaModificacion, value); }
         }

    }
}
