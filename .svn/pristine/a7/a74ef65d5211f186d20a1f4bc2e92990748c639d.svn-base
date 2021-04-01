using EasyTools.Framework.Data;
using System;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities.Base
{
    /// <summary>
    /// SECUserCompany object for mapped table SECUserCompanies.
    /// </summary>
    [DataContract(IsReference = true)]
    public class BaseSECUserCompany : BaseEntity
    {

       public BaseSECUserCompany()
       {
       }

       public BaseSECUserCompany(BaseSECUserCompany data, Options option)
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
                this.CompanyId = data.CompanyId;
                this.UserId = data.UserId;
             }
          }
       }

       [DataMember]
       public virtual Boolean Active { get; set; }

       [DataMember]
       public virtual Int32 CompanyId { get; set; }

       [DataMember]
       public virtual Int32 UserId { get; set; }


    }
 }
