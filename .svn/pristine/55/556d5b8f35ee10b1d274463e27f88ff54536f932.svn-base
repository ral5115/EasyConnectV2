using EasyTools.Framework.Data;
using EasyTools.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities
{
    /// <summary>
    /// EXTFileOperaDetail object for mapped table EXTFileOperaDetails.
    /// </summary>
    [DataContract(IsReference = true)]
    public class EXTFileOperaDetail : BaseEXTFileOperaDetail
    {

       public EXTFileOperaDetail() : base()
       {
       }

       public EXTFileOperaDetail(EXTFileOperaDetail data, Options option) : base(data, option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light

             if (option == Options.Me || option == Options.All)
             {

                this.FileOpera = (data.FileOpera != null) ? new EXTFileOpera(data.FileOpera, Options.Light) : null; 
             }
          }
       }

       [DataMember]
       public virtual EXTFileOpera FileOpera { get; set; }

       [DataMember]
       public virtual List<EXTFileOperaDetail> Entities { get; set; }

       public override Int32 GetHashCode()
       {
          return this.Id.GetHashCode();
       }

       public override Boolean Equals(object obj)
       {
          if ((obj == null) || (obj.GetType() != this.GetType()))
             return false;
             EXTFileOperaDetail castObj = (EXTFileOperaDetail)obj;
          return (castObj != null) && (this.Id == castObj.Id);
       }

    }
 }
