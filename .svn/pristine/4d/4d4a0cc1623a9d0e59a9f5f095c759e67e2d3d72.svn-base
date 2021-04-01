using EasyTools.Framework.Data;
using System;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities.Base
{
    /// <summary>
    /// CONIntegratorConfiguration object for mapped table CONIntegratorConfigurations.
    /// </summary>
    [DataContract(IsReference = true)]
    public class BaseCONIntegratorConfiguration : BaseEntity
    {

        public BaseCONIntegratorConfiguration()
        {
        }

        public BaseCONIntegratorConfiguration(BaseCONIntegratorConfiguration data, Options option)
        {

            if (option == Options.Light || option == Options.Me || option == Options.All)
            {
                //OptionName.Light
                this.Id = data.Id;
                this.Active = data.Active;
             
                if (option == Options.Me || option == Options.All)
                {

                    this.InternalUser = data.InternalUser;
                    this.InternalPassword = data.InternalPassword;
                    this.Active = data.Active;
                    this.UpdatedBy = data.UpdatedBy;
                    this.LastUpdate = data.LastUpdate;
                    this.ConnectionNumber = data.ConnectionNumber;
                    this.ProgramPath = data.ProgramPath;
                    this.IntegratorId = data.IntegratorId;
                    this.ConnectionId = data.ConnectionId;
                    this.CompanyId = data.CompanyId;
                    this.FileName = data.FileName;
                    this.FileExtension = data.FileExtension;
                    this.Type = data.Type;
                }
            }
        }

        [DataMember]
        public virtual String InternalUser { get; set; }

        [DataMember]
        public virtual String InternalPassword { get; set; }

        [DataMember]
        public virtual Boolean Active { get; set; }

        [DataMember]
        public virtual Int32? ConnectionNumber { get; set; }

        [DataMember]
        public virtual String ProgramPath { get; set; }

        [DataMember]
        public virtual Int32 IntegratorId { get; set; }

        [DataMember]
        public virtual Int32? ConnectionId { get; set; }

        [DataMember]
        public virtual Int32 CompanyId { get; set; }

        [DataMember]
        public virtual String FileName { get; set; }

        [DataMember]
        public virtual String FileExtension { get; set; }

        [DataMember]
        public virtual String Type { get; set; }

    }
}
