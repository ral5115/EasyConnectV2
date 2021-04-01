using EasyTools.Framework.Data;
using System;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities.Base
{
    /// <summary>
    /// SECCompany object for mapped table SECCompanies.
    /// </summary>
    [DataContract(IsReference = true)]
    public class BaseSECCompany : BaseEntity
    {

        public BaseSECCompany()
        {
        }

        public BaseSECCompany(BaseSECCompany data, Options option)
        {

            if (option == Options.Light || option == Options.Me || option == Options.All)
            {
                //OptionName.Light
                this.Id = data.Id;
                this.IdentificationNumer = data.IdentificationNumer;
                this.TradeName = data.TradeName;
                this.Active = data.Active;
                this.EmailServer = data.EmailServer;
                this.EmailUser = data.EmailUser;
                this.EmailPassword = data.EmailPassword;
                this.EmailPort = data.EmailPort;
                this.EmailEnableSSL = data.EmailEnableSSL;

                if (option == Options.Me || option == Options.All)
                {
                    this.LastUpdate = data.LastUpdate;
                    this.UpdatedBy = data.UpdatedBy;
                }
            }
        }

        [DataMember]
        public virtual String IdentificationNumer { get; set; }

        [DataMember]
        public virtual String TradeName { get; set; }

        [DataMember]
        public virtual Boolean Active { get; set; }

        [DataMember]
        public virtual String EmailServer { get; set; }

        [DataMember]
        public virtual String EmailUser { get; set; }

        [DataMember]
        public virtual String EmailPassword { get; set; }

        [DataMember]
        public virtual String EmailPort { get; set; }

        [DataMember]
        public virtual Boolean EmailEnableSSL { get; set; }

    }
}