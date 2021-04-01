
using EasyConnect.Infrastructure.Entities.Base;
using EasyTools.Framework.Data;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EasyConnect.Infrastructure.Entities
{
    /// <summary>
    /// WSCONCESIONE object for mapped table WS_CONCESIONES.
    /// </summary>
    [DataContract(IsReference = true)]
    public class WSCONCESIONE : BaseWSCONCESIONE
    {

       public WSCONCESIONE() : base()
       {
       }

       public WSCONCESIONE(WSCONCESIONE data, Options option) : base(data, option)
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
       public virtual List<WSCONCESIONE> Entities { get; set; }

       public override Int32 GetHashCode()
       {
          return this.Id.GetHashCode();
       }

       public override Boolean Equals(object obj)
       {
          if ((obj == null) || (obj.GetType() != this.GetType()))
             return false;
             WSCONCESIONE castObj = (WSCONCESIONE)obj;
          return (castObj != null) && (this.Id == castObj.Id);
       }

    }
 }
