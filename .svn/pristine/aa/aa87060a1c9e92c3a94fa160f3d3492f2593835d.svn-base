using EasyTools.Framework.Data;
using EasyTools.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities
{
    /// <summary>
    /// CONEquivalenceDetail object for mapped table CONEquivalenceDetails.
    /// </summary>
    [DataContract(IsReference = true)]
    public class CONEquivalenceDetail : BaseCONEquivalenceDetail
    {

       public CONEquivalenceDetail() : base()
       {
       }

       public CONEquivalenceDetail(CONEquivalenceDetail data, Options option) : base(data, option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light

             if (option == Options.Me || option == Options.All)
             {

                this.Equivalence = (data.Equivalence != null) ? new CONEquivalence(data.Equivalence, Options.Light) : null; 
             }
          }
       }

       [DataMember]
       public virtual CONEquivalence Equivalence { get; set; }

       [DataMember]
       public virtual List<CONEquivalenceDetail> Entities { get; set; }

        public override Int32 GetHashCode()
       {
          return this.Id.GetHashCode();
       }

       public override Boolean Equals(object obj)
       {
          if ((obj == null) || (obj.GetType() != this.GetType()))
             return false;
             CONEquivalenceDetail castObj = (CONEquivalenceDetail)obj;
          return (castObj != null) && (this.Id == castObj.Id);
       }
    }
 }
