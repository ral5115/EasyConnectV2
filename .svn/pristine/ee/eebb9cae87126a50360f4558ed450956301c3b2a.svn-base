using EasyTools.Framework.Data;
using EasyTools.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities
{
    /// <summary>
    /// EXTFileOpera object for mapped table EXTFileOpera.
    /// </summary>
    [DataContract(IsReference = true)]
    public class EXTFileOpera : BaseEXTFileOpera
    {

       public EXTFileOpera() : base()
       {
       }

       public EXTFileOpera(EXTFileOpera data, Options option) : base(data, option)
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
       public virtual List<EXTFileOpera> Entities { get; set; }

       [DataMember]
       public virtual List<EXTFileOperaDetail> FileOperaDetails { get; set; }

       public override Int32 GetHashCode()
       {
          return this.Id.GetHashCode();
       }

       public override Boolean Equals(object obj)
       {
          if ((obj == null) || (obj.GetType() != this.GetType()))
             return false;
             EXTFileOpera castObj = (EXTFileOpera)obj;
          return (castObj != null) && (this.Id == castObj.Id);
       }

    }
 }
