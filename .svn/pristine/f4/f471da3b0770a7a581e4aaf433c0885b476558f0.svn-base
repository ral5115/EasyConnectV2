
using EasyConnect.Infrastructure.Entities.Base;
using EasyTools.Framework.Data;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EasyConnect.Infrastructure.Entities
{
    /// <summary>
    /// WSCONCESIONESTIENDA object for mapped table WS_CONCESIONES_TIENDAS.
    /// </summary>
    [DataContract(IsReference = true)]
    public class WSCONCESIONESTIENDA : BaseWSCONCESIONESTIENDA
    {

       public WSCONCESIONESTIENDA() : base()
       {
       }

       public WSCONCESIONESTIENDA(WSCONCESIONESTIENDA data, Options option) : base(data, option)
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
       public virtual List<WSCONCESIONESTIENDA> Entities { get; set; }

       public override Int32 GetHashCode()
       {
          return this.Id.GetHashCode();
       }

       public override Boolean Equals(object obj)
       {
          if ((obj == null) || (obj.GetType() != this.GetType()))
             return false;
             WSCONCESIONESTIENDA castObj = (WSCONCESIONESTIENDA)obj;
          return (castObj != null) && (this.Id == castObj.Id);
       }

    }
 }
