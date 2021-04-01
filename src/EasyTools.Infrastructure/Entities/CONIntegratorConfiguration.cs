using EasyTools.Framework.Data;
using EasyTools.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities
{
    /// <summary>
    /// CONIntegratorConfiguration object for mapped table CONIntegratorConfigurations.
    /// </summary>
    [DataContract(IsReference = true)]
    public class CONIntegratorConfiguration : BaseCONIntegratorConfiguration
    {

        public CONIntegratorConfiguration()
            : base()
        {
        }

        public CONIntegratorConfiguration(CONIntegratorConfiguration data, Options option)
            : base(data, option)
        {

            if (option == Options.Light || option == Options.Me || option == Options.All)
            {
                //OptionName.Light

                if (option == Options.Me || option == Options.All)
                {

                    this.Integrator = (data.Integrator != null) ? new CONIntegrator(data.Integrator, Options.Light) : null;
                    this.Connection = (data.Connection != null) ? new SECConnection(data.Connection, Options.Light) : null;
                    this.Company = (data.Company != null) ? new SECCompany(data.Company, Options.Light) : null;
                }
            }
        }

        [DataMember]
        public virtual CONIntegrator Integrator { get; set; }

        [DataMember]
        public virtual SECConnection Connection { get; set; }

        [DataMember]
        public virtual SECCompany Company { get; set; }

        [DataMember]
        public virtual List<CONIntegratorConfiguration> Entities { get; set; }

        [DataMember]
        public virtual List<CONSQLSend> SQLSends { get; set; }

        public override Int32 GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public override Boolean Equals(object obj)
        {
            if ((obj == null) || (obj.GetType() != this.GetType()))
                return false;
            CONIntegratorConfiguration castObj = (CONIntegratorConfiguration)obj;
            return (castObj != null) && (this.Id == castObj.Id);
        }

    }
}
