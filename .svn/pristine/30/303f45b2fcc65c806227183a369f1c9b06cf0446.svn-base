using EasyTools.Framework.Data;
using System;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities.Base
{
    /// <summary>
    /// CONEquivalenceDetail object for mapped table CONEquivalenceDetails.
    /// </summary>
    [DataContract(IsReference = true)]
    public class BaseCONEquivalenceDetail : BaseEntity
    {

       public BaseCONEquivalenceDetail()
       {
       }

       public BaseCONEquivalenceDetail(BaseCONEquivalenceDetail data, Options option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light
             this.Id = data.Id;
                this.Code = data.Code;
                this.Name = data.Name;

             if (option == Options.Me || option == Options.All)
             {

                this.Code = data.Code;
                this.Name = data.Name;
                this.Value1 = data.Value1;
                this.Value2 = data.Value2;
                this.Value3 = data.Value3;
                this.Value4 = data.Value4;
                this.Value5 = data.Value5;
                this.Value6 = data.Value6;
                this.Value7 = data.Value7;
                this.Value8 = data.Value8;
                this.Value9 = data.Value9;
                this.Value10 = data.Value10;
                this.LastUpdate = data.LastUpdate;
                this.UpdatedBy = data.UpdatedBy;
                this.EquivalenceId = data.EquivalenceId;
             }
          }
       }

       [DataMember]
       public virtual String Code { get; set; }

       [DataMember]
       public virtual String Name { get; set; }

       [DataMember]
       public virtual String Value1 { get; set; }

       [DataMember]
       public virtual String Value2 { get; set; }

       [DataMember]
       public virtual String Value3 { get; set; }

       [DataMember]
       public virtual String Value4 { get; set; }

       [DataMember]
       public virtual String Value5 { get; set; }

       [DataMember]
       public virtual String Value6 { get; set; }

       [DataMember]
       public virtual String Value7 { get; set; }

       [DataMember]
       public virtual String Value8 { get; set; }

       [DataMember]
       public virtual String Value9 { get; set; }

       [DataMember]
       public virtual String Value10 { get; set; }

       [DataMember]
       public virtual Int32 EquivalenceId { get; set; }


    }
 }
