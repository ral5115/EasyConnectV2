using EasyTools.Framework.Data;
using System;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities.Base
{
    /// <summary>
    /// SECConnection object for mapped table SECConnections.
    /// </summary>
    [DataContract(IsReference = true)]
    public class BaseSECConnection : BaseEntity
    {

       public BaseSECConnection()
       {
       }

       public BaseSECConnection(BaseSECConnection data, Options option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light
             this.Id = data.Id;
                this.Active = data.Active;
                this.Name = data.Name;
                this.DbType = data.DbType;

             if (option == Options.Me || option == Options.All)
             {

                this.Active = data.Active;
                this.Login = data.Login;
                this.Password = data.Password;
                this.Service = data.Service;
                this.DB = data.DB;
                this.LastUpdate = data.LastUpdate;
                this.UpdatedBy = data.UpdatedBy;
                this.Name = data.Name;
                this.CompanyId = data.CompanyId;
                    
             }
          }
       }

       [DataMember]
       public virtual Boolean Active { get; set; }

       [DataMember]
       public virtual String Login { get; set; }

       [DataMember]
       public virtual String Password { get; set; }

       [DataMember]
       public virtual String Service { get; set; }

       [DataMember]
       public virtual String DB { get; set; }

       [DataMember]
       public virtual String Name { get; set; }

       [DataMember]
       public virtual Int32 CompanyId { get; set; }

        [DataMember]
        public virtual string DbType { get; set; }


    }
 }
