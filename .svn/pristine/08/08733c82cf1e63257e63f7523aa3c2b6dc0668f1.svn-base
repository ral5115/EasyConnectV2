using EasyTools.Framework.Data;
using EasyTools.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities
{
    /// <summary>
    /// SECConnection object for mapped table SECConnections.
    /// </summary>
    [DataContract(IsReference = true)]
    public class SECConnection : BaseSECConnection
    {

        public SECConnection() : base()
        {
        }

        public SECConnection(SECConnection data, Options option) : base(data, option)
        {

            if (option == Options.Light || option == Options.Me || option == Options.All)
            {
                //OptionName.Light
                this.DbType = data.DbType;
                this.Login = data.Login;
                this.Password = data.Password;
                this.Service = data.Service;
                this.DB = data.DB;
                this.Name = data.Name;

                if (option == Options.Me || option == Options.All)
                {

                    this.Company = (data.Company != null) ? new SECCompany(data.Company, Options.Light) : null;

                }
            }
        }

        [DataMember]
        public virtual SECCompany Company { get; set; }

        [DataMember]
        public virtual List<SECConnection> Entities { get; set; }

        public override Int32 GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public override Boolean Equals(object obj)
        {
            if ((obj == null) || (obj.GetType() != this.GetType()))
                return false;
            SECConnection castObj = (SECConnection)obj;
            return (castObj != null) && (this.Id == castObj.Id);
        }

    }
}