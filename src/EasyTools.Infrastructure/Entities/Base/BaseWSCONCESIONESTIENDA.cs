
using EasyTools.Framework.Data;
using EasyTools.Infrastructure.Entities.Base;
using System;
using System.Runtime.Serialization;

namespace EasyConnect.Infrastructure.Entities.Base
{
    /// <summary>
    /// WSCONCESIONESTIENDA object for mapped table WS_CONCESIONES_TIENDAS.
    /// </summary>
    [DataContract(IsReference = true)]
    public class BaseWSCONCESIONESTIENDA : BaseEntity
    {

       public BaseWSCONCESIONESTIENDA()
       {
       }

       public BaseWSCONCESIONESTIENDA(BaseWSCONCESIONESTIENDA data, Options option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light
             this.Id = data.Id;
                this.NickName = data.NickName;

             if (option == Options.Me || option == Options.All)
             {

                this.IdConcesion = data.IdConcesion;
                this.IdTienda = data.IdTienda;
                this.NickName = data.NickName;
                this.FechaAlta = data.FechaAlta;
                this.CreationDate = data.CreationDate;
             }
          }
       }

       [DataMember]
       public virtual Int32 IdConcesion { get; set; }

       [DataMember]
       public virtual String IdTienda { get; set; }

       [DataMember]
       public virtual String NickName { get; set; }

       [DataMember]
       public virtual DateTime? FechaAlta { get; set; }

       [DataMember]
       public virtual DateTime? CreationDate { get; set; }

    }
 }
