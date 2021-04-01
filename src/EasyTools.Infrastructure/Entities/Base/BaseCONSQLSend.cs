using EasyTools.Framework.Data;
using System;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities.Base
{
    /// <summary>
    /// CONSQLSend object for mapped table CONSQLSends.
    /// </summary>
    [DataContract(IsReference = true)]
    public class BaseCONSQLSend : BaseEntity
    {

       public BaseCONSQLSend()
       {
       }

       public BaseCONSQLSend(BaseCONSQLSend data, Options option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light
             this.Id = data.Id;
                this.Active = data.Active;

             if (option == Options.Me || option == Options.All)
             {

                this.Active = data.Active;
                this.UpdatedBy = data.UpdatedBy;
                this.LastUpdate = data.LastUpdate;
                this.CONIntegratorConfigurationId = data.CONIntegratorConfigurationId;
                this.SQLId = data.SQLId;
             }
          }
       }

       [DataMember]
       public virtual Boolean Active { get; set; }

       [DataMember]
       public virtual Int32 CONIntegratorConfigurationId { get; set; }

       [DataMember]
       public virtual Int32 SQLId { get; set; }


    }
 }
