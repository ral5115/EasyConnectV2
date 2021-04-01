using EasyTools.Framework.Data;
using System;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities.Base
{
    /// <summary>
    /// SECUser object for mapped table SECUsers.
    /// </summary>
    [DataContract(IsReference = true)]
    public class BaseSECUser : BaseEntity
    {

       public BaseSECUser()
       {
       }

       public BaseSECUser(BaseSECUser data, Options option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light
             this.Id = data.Id;
                this.Active = data.Active;
                this.Names = data.Names;
                this.FatherLastName = data.FatherLastName;
                this.MotherLastName = data.MotherLastName;

             if (option == Options.Me || option == Options.All)
             {

                this.Login = data.Login;
                this.Password = data.Password;
                this.Active = data.Active;
                this.Names = data.Names;
                this.FatherLastName = data.FatherLastName;
                this.MotherLastName = data.MotherLastName;
                this.IdentificationNumber = data.IdentificationNumber;
                this.Email = data.Email;
                this.UpdatedBy = data.UpdatedBy;
                this.LastUpdate = data.LastUpdate;
                this.Locked = data.Locked;
                this.RequiresVerification = data.RequiresVerification;
                this.RepeatPassword = data.RepeatPassword;
                this.RoleId = data.RoleId;
             }
          }
       }

       [DataMember]
       public virtual String Login { get; set; }

       [DataMember]
       public virtual String Password { get; set; }

       [DataMember]
       public virtual Boolean Active { get; set; }

       [DataMember]
       public virtual String Names { get; set; }

       [DataMember]
       public virtual String FatherLastName { get; set; }

       [DataMember]
       public virtual String MotherLastName { get; set; }

       [DataMember]
       public virtual String IdentificationNumber { get; set; }

       [DataMember]
       public virtual String Email { get; set; }

       [DataMember]
       public virtual Boolean Locked { get; set; }

       [DataMember]
       public virtual Boolean RequiresVerification { get; set; }

       [DataMember]
       public virtual String RepeatPassword { get; set; }

       [DataMember]
       public virtual Int32? RoleId { get; set; }


    }
 }
