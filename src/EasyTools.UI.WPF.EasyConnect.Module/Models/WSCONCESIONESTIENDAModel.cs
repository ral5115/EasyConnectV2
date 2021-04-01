using EasyConnect.Infrastructure.Entities;
using EasyTools.Framework.Resources;
using EasyTools.Framework.UI;

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EasyTools.UI.WPF.EasyConnect.Module.Models
{
    public class WSCONCESIONESTIENDAModel : BaseModel
    {
        
        public BindingList<WSCONCESIONESTIENDA> Details 
        {
           get { return GetValue(() => Details); }
           set { SetValue(() => Details, value); }
        }

        public WSCONCESIONESTIENDA SelectedWSCONCESIONESTIENDA { get; set; }

        public WSCONCESIONESTIENDA Entity 
        { 
           get
           {   
              WSCONCESIONESTIENDA data = new WSCONCESIONESTIENDA();
              data.Id = this.Id;
              data.IdConcesion = this.IdConcesion;
              data.IdTienda = this.IdTienda;
              data.NickName = this.NickName;
              data.FechaAlta = this.FechaAlta;
              data.CreationDate = this.CreationDate;
              return data;
                     
           }
           set
           {   
              this.Id = value.Id;
              this.IdConcesion = value.IdConcesion;
              this.IdTienda = (String.IsNullOrWhiteSpace(value.IdTienda) ? "" : value.IdTienda ) ;
              this.NickName = (String.IsNullOrWhiteSpace(value.NickName) ? "" : value.NickName ) ;
              this.FechaAlta = value.FechaAlta ;
              this.CreationDate = value.CreationDate;
              this.NotifyPropertyChanged("Entity"); 
           }
        }

        [Display(Name = "WSCONCESIONESTIENDAViewIdConcesionField", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
         public virtual Int32 IdConcesion
         {
             get { return GetValue(() => IdConcesion); }
             set { SetValue(() => IdConcesion, value); }
         }

        [Display(Name = "WSCONCESIONESTIENDAViewIdTiendaField", ResourceType = typeof(Language))]
        [StringLength(10, ErrorMessageResourceName = "ApplicationErrorStringRequired", ErrorMessageResourceType = typeof(Language), MinimumLength=1)]
         public virtual String IdTienda
         {
             get { return GetValue(() => IdTienda); }
             set { SetValue(() => IdTienda, value); }
         }

        [Display(Name = "WSCONCESIONESTIENDAViewNickNameField", ResourceType = typeof(Language))]
        [StringLength(40, ErrorMessageResourceName = "ApplicationErrorStringOptional", ErrorMessageResourceType = typeof(Language))]
         public virtual String NickName
         {
             get { return GetValue(() => NickName); }
             set { SetValue(() => NickName, value); }
         }

        [Display(Name = "WSCONCESIONESTIENDAViewFechaAltaField", ResourceType = typeof(Language))]
        public virtual DateTime? FechaAlta
         {
             get { return GetValue(() => FechaAlta); }
             set { SetValue(() => FechaAlta, value); }
         }

        [Display(Name = "WSCONCESIONESTIENDAViewCreationDateField", ResourceType = typeof(Language))]
         public virtual DateTime? CreationDate 
         {
             get { return GetValue(() => CreationDate); }
             set { SetValue(() => CreationDate, value); }
         }

    }
}
