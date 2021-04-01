using EasyTools.Framework.Data;
using System;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities.Base
{
    /// <summary>
    /// CONSQLDetail object for mapped table CONSQLDetails.
    /// </summary>
    [DataContract(IsReference = true)]
    public class BaseCONSQLDetail : BaseEntity
    {

       public BaseCONSQLDetail()
       {
       }

       public BaseCONSQLDetail(BaseCONSQLDetail data, Options option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light
             this.Id = data.Id;
                this.Description = data.Description;

             if (option == Options.Me || option == Options.All)
             {

                this.Field = data.Field;
                this.Description = data.Description;
                this.Secuence = data.Secuence;
                this.DBType = data.DBType;
                this.DefaultValue = data.DefaultValue;
                this.EquivalenceColumnId = data.EquivalenceColumnId;
                this.UpdatedBy = data.UpdatedBy;
                this.LastUpdate = data.LastUpdate;
                this.EquivalenceId = data.EquivalenceId;
                //this.MainSQLDetailId = data.MainSQLDetailId;
                this.SQLId = data.SQLId;
                this.StructureDetailId = data.StructureDetailId;
             }
          }
       }

       [DataMember]
       public virtual String Field { get; set; }

       [DataMember]
       public virtual String Description { get; set; }

       [DataMember]
       public virtual Int16 Secuence { get; set; }

       [DataMember]
       public virtual String DBType { get; set; }

       [DataMember]
       public virtual String DefaultValue { get; set; }

       [DataMember]
       public virtual Int16? EquivalenceColumnId { get; set; }

       [DataMember]
       public virtual Int32? EquivalenceId { get; set; }

       //[DataMember]
       //public virtual Int32? MainSQLDetailId { get; set; }

       [DataMember]
       public virtual Int32 SQLId { get; set; }

       [DataMember]
       public virtual Int32? StructureDetailId { get; set; }

    }
 }
