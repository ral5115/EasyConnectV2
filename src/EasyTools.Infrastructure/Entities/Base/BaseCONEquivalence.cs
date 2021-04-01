using EasyTools.Framework.Data;
using System;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities.Base
{
    /// <summary>
    /// CONEquivalence object for mapped table CONEquivalences.
    /// </summary>
    [DataContract(IsReference = true)]
    public class BaseCONEquivalence : BaseEntity
    {

        public BaseCONEquivalence()
        {
        }

        public BaseCONEquivalence(BaseCONEquivalence data, Options option)
        {

            if (option == Options.Light || option == Options.Me || option == Options.All)
            {
                //OptionName.Light
                this.Id = data.Id;
                this.Name = data.Name;
                this.Active = data.Active;
                if (option == Options.Me || option == Options.All)
                {

                    this.Name = data.Name;
                    this.Active = data.Active;
                    this.LabelValue1 = data.LabelValue1;
                    this.LabelValue2 = data.LabelValue2;
                    this.LabelValue3 = data.LabelValue3;
                    this.LabelValue4 = data.LabelValue4;
                    this.LabelValue5 = data.LabelValue5;
                    this.LabelValue6 = data.LabelValue6;
                    this.LabelValue7 = data.LabelValue7;
                    this.LabelValue8 = data.LabelValue8;
                    this.LabelValue9 = data.LabelValue9;
                    this.LabelValue10 = data.LabelValue10;
                    this.UpdatedBy = data.UpdatedBy;
                    this.LastUpdate = data.LastUpdate;
                    this.CompanyId = data.CompanyId;
                }
            }
        }

        [DataMember]
        public virtual String Name { get; set; }

        [DataMember]
        public virtual Boolean Active { get; set; }

        [DataMember]
        public virtual String LabelValue1 { get; set; }

        [DataMember]
        public virtual String LabelValue2 { get; set; }

        [DataMember]
        public virtual String LabelValue3 { get; set; }

        [DataMember]
        public virtual String LabelValue4 { get; set; }

        [DataMember]
        public virtual String LabelValue5 { get; set; }

        [DataMember]
        public virtual String LabelValue6 { get; set; }

        [DataMember]
        public virtual String LabelValue7 { get; set; }

        [DataMember]
        public virtual String LabelValue8 { get; set; }

        [DataMember]
        public virtual String LabelValue9 { get; set; }

        [DataMember]
        public virtual String LabelValue10 { get; set; }

        [DataMember]
        public virtual Int32 CompanyId { get; set; }

    }
}