using EasyTools.Framework.Data;
using System;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities.Base
{
    /// <summary>
    /// CONStructureDetail object for mapped table CONStructureDetails.
    /// </summary>
    [DataContract(IsReference = true)]
    public class BaseCONStructureDetail : BaseEntity
    {

        public BaseCONStructureDetail()
        {
        }

        public BaseCONStructureDetail(BaseCONStructureDetail data, Options option)
        {

            if (option == Options.Light || option == Options.Me || option == Options.All)
            {
                //OptionName.Light
                this.Id = data.Id;
                this.Field = data.Field;
                this.Description = data.Description;
                this.DBType = data.DBType;
                this.Sizes = data.Sizes;
                this.Ent = data.Ent;
                this.Dec = data.Dec;
                this.Visible = data.Visible;
                this.IsRequired = data.IsRequired;
                this.DefaultValue = data.DefaultValue;
                this.StructureId = data.StructureId;
                if (option == Options.Me || option == Options.All)
                {
                    this.Observations = data.Observations;
                    this.Secuence = data.Secuence;
                    this.InitialPosition = data.InitialPosition;
                    this.FinalPosition = data.FinalPosition;
                    this.UpdatedBy = data.UpdatedBy;
                    this.LastUpdate = data.LastUpdate;
                }
            }
        }

        [DataMember]
        public virtual String Field { get; set; }

        [DataMember]
        public virtual String Description { get; set; }

        [DataMember]
        public virtual Int16 DBType { get; set; }

        [DataMember]
        public virtual String Observations { get; set; }

        [DataMember]
        public virtual Boolean IsRequired { get; set; }

        [DataMember]
        public virtual Int16 Secuence { get; set; }

        [DataMember]
        public virtual Int16? InitialPosition { get; set; }

        [DataMember]
        public virtual Int16? Sizes { get; set; }

        [DataMember]
        public virtual Int16? FinalPosition { get; set; }

        [DataMember]
        public virtual Boolean Visible { get; set; }

        [DataMember]
        public virtual String DefaultValue { get; set; }

        [DataMember]
        public virtual Int16 Ent { get; set; }

        [DataMember]
        public virtual Int16 Dec { get; set; }

        [DataMember]
        public virtual Int32 StructureId { get; set; }


    }
}