
using EasyTools.Framework.Data;
using EasyTools.Infrastructure.Entities.Base;
using System;
using System.Runtime.Serialization;

namespace EasyConnect.Infrastructure.Entities.Base
{
    /// <summary>
    /// WSCONCESIONE object for mapped table WS_CONCESIONES.
    /// </summary>
    [DataContract(IsReference = true)]
    public class BaseWSCONCESIONE : BaseEntity
    {

       public BaseWSCONCESIONE()
       {
       }

       public BaseWSCONCESIONE(BaseWSCONCESIONE data, Options option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light
             this.Id = data.Id;

             if (option == Options.Me || option == Options.All)
             {

                this.RazonSocial = data.RazonSocial;
                this.NomComercial = data.NomComercial;
                this.Cif = data.Cif;
                this.FechaAlta = data.FechaAlta;
                this.FechaBaja = data.FechaBaja;
                this.Tratamiento = data.Tratamiento;
                this.FechaModificacion = data.FechaModificacion;
             }
          }
       }

       [DataMember]
       public virtual String RazonSocial { get; set; }

       [DataMember]
       public virtual String NomComercial { get; set; }

       [DataMember]
       public virtual String Cif { get; set; }

       [DataMember]
       public virtual DateTime? FechaAlta { get; set; }

       [DataMember]
       public virtual DateTime? FechaBaja { get; set; }

       [DataMember]
       public virtual String Tratamiento { get; set; }

       [DataMember]
       public virtual DateTime? FechaModificacion { get; set; }

    }
 }
