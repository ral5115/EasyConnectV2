using EasyTools.Framework.Data;
using System;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities.Base
{
    /// <summary>
    /// CONSQL object for mapped table CONSQLs.
    /// </summary>
    [DataContract(IsReference = true)]
    public class BaseCONSQL : BaseEntity
    {

       public BaseCONSQL()
       {
       }

       public BaseCONSQL(BaseCONSQL data, Options option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light
             this.Id = data.Id;
                this.Active = data.Active;
                this.Description = data.Description;
                //this.FileName = data.FileName;

             if (option == Options.Me || option == Options.All)
             {

                this.Active = data.Active;
                this.Description = data.Description;
                this.ConnectionId = data.ConnectionId;
                this.SQLSentence = data.SQLSentence;
                this.Automatic = data.Automatic;
                this.ExecuteStoreProcedure = data.ExecuteStoreProcedure;
                this.StoreProcedureConnectionId = data.StoreProcedureConnectionId;
                //this.DestinyConnectionId = data.DestinyConnectionId;
                this.GenerateFile = data.GenerateFile;
                //this.FileName = data.FileName;
                this.Tag = data.Tag;
                //this.FileExtension = data.FileExtension;
                this.UpdatedBy = data.UpdatedBy;
                this.LastUpdate = data.LastUpdate;
                this.CompanyId = data.CompanyId;
                this.MainSQLId = data.MainSQLId;
                this.StructureId = data.StructureId;
             }
          }
       }

       [DataMember]
       public virtual Boolean Active { get; set; }

       [DataMember]
       public virtual String Description { get; set; }

       [DataMember]
       public virtual Int32 ConnectionId { get; set; }

       [DataMember]
       public virtual String SQLSentence { get; set; }

       [DataMember]
       public virtual Boolean Automatic { get; set; }

       [DataMember]
       public virtual String ExecuteStoreProcedure { get; set; }

       [DataMember]
       public virtual Int32? StoreProcedureConnectionId { get; set; }

       //[DataMember]
       //public virtual Int32? DestinyConnectionId { get; set; }

       [DataMember]
       public virtual Boolean GenerateFile { get; set; }

       //[DataMember]
       //public virtual String FileName { get; set; }

       [DataMember]
       public virtual String Tag { get; set; }

       //[DataMember]
       //public virtual String FileExtension { get; set; }

       [DataMember]
       public virtual Int32 CompanyId { get; set; }

       [DataMember]
       public virtual Int32? MainSQLId { get; set; }

       [DataMember]
       public virtual Int32 StructureId { get; set; }


    }
 }
