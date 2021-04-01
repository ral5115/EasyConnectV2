using EasyTools.Framework.Data;
using EasyTools.Framework.Resources;
using EasyTools.Framework.UI;
using EasyTools.Infrastructure.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EasyTools.UI.WPF.Security.Module.Models
{
    public class SECUserModel : BaseModel
    {

        public BindingList<SECUser> Details
        {
            get { return GetValue(() => Details); }
            set { SetValue(() => Details, value); }
        }

        public SECUser SelectedSECUser { get; set; }

        public SECUser Entity
        {
            get
            {
                SECUser data = new SECUser();
                data.Id = this.Id;
                data.Login = this.Login;
                data.Password = String.IsNullOrWhiteSpace(this.Password) ? "" : Crypto.EncrytedString(this.Password);
                data.RepeatPassword = String.IsNullOrWhiteSpace(this.RepeatPassword) ? "" : Crypto.EncrytedString(this.RepeatPassword);
                data.Active = this.Active;
                data.Names = this.Names;
                data.FatherLastName = this.FatherLastName;
                data.MotherLastName = this.MotherLastName;
                data.IdentificationNumber = this.IdentificationNumber;
                data.Email = this.Email;
                data.UpdatedBy = this.UpdatedBy;
                data.LastUpdate = this.LastUpdate;
                data.Locked = this.Locked;
                data.RequiresVerification = this.RequiresVerification;
                data.Role = this.Role;
                if (data.Role != null)
                    data.RoleId = data.Role.Id;
                return data;

            }
            set
            {
                this.Id = value.Id;
                this.Login = (String.IsNullOrWhiteSpace(value.Login) ? "" : value.Login);
                this.Password = (String.IsNullOrWhiteSpace(value.Password) ? "" : Crypto.DecrytedString(value.Password));
                this.RepeatPassword = (String.IsNullOrWhiteSpace(value.RepeatPassword) ? "" : Crypto.DecrytedString(value.RepeatPassword));
                this.Active = value.Active;
                this.Names = (String.IsNullOrWhiteSpace(value.Names) ? "" : value.Names);
                this.FatherLastName = (String.IsNullOrWhiteSpace(value.FatherLastName) ? "" : value.FatherLastName);
                this.MotherLastName = (String.IsNullOrWhiteSpace(value.MotherLastName) ? "" : value.MotherLastName);
                this.IdentificationNumber = (String.IsNullOrWhiteSpace(value.IdentificationNumber) ? "" : value.IdentificationNumber);
                this.Email = (String.IsNullOrWhiteSpace(value.Email) ? "" : value.Email);
                this.UpdatedBy = (String.IsNullOrWhiteSpace(value.UpdatedBy) ? "" : value.UpdatedBy);
                this.LastUpdate = value.LastUpdate;
                this.Locked = value.Locked;
                this.RequiresVerification = value.RequiresVerification;
                this.Role = value.Role;
                this.NotifyPropertyChanged("Entity");
            }
        }

        [Display(Name = "SECUserViewLoginField", ResourceType = typeof(Language))]
        [StringLength(50, ErrorMessageResourceName = "ApplicationErrorStringRequired", ErrorMessageResourceType = typeof(Language), MinimumLength = 1)]
        public virtual String Login
        {
            get { return GetValue(() => Login); }
            set { SetValue(() => Login, value); }
        }

        [Display(Name = "SECUserViewPasswordField", ResourceType = typeof(Language))]
        [StringLength(256, ErrorMessageResourceName = "ApplicationErrorStringRequired", ErrorMessageResourceType = typeof(Language), MinimumLength = 1)]
        public virtual String Password
        {
            get { return GetValue(() => Password); }
            set
            {
                SetValue(() => Password, value);
                RaisePropertyChanged("RepeatPassword");
            }
        }

        [Display(Name = "SECUserViewRepeatPasswordField", ResourceType = typeof(Language))]
        [Compare("Password", ErrorMessageResourceName = "SECUserViewRepeatPasswordCompareField", ErrorMessageResourceType = typeof(Language))]
        public virtual String RepeatPassword
        {
            get { return GetValue(() => RepeatPassword); }
            set { SetValue(() => RepeatPassword, value); }
        }

        [Display(Name = "SECUserViewActiveField", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
        public virtual Boolean Active
        {
            get { return GetValue(() => Active); }
            set { SetValue(() => Active, value); }
        }

        [Display(Name = "SECUserViewNamesField", ResourceType = typeof(Language))]
        [StringLength(50, ErrorMessageResourceName = "ApplicationErrorStringRequired", ErrorMessageResourceType = typeof(Language), MinimumLength = 1)]
        public virtual String Names
        {
            get { return GetValue(() => Names); }
            set { SetValue(() => Names, value); }
        }

        [Display(Name = "SECUserViewFatherLastNameField", ResourceType = typeof(Language))]
        [StringLength(20, ErrorMessageResourceName = "ApplicationErrorStringRequired", ErrorMessageResourceType = typeof(Language), MinimumLength = 1)]
        public virtual String FatherLastName
        {
            get { return GetValue(() => FatherLastName); }
            set { SetValue(() => FatherLastName, value); }
        }

        [Display(Name = "SECUserViewMotherLastNameField", ResourceType = typeof(Language))]
        [StringLength(30, ErrorMessageResourceName = "ApplicationErrorStringOptional", ErrorMessageResourceType = typeof(Language))]
        public virtual String MotherLastName
        {
            get { return GetValue(() => MotherLastName); }
            set { SetValue(() => MotherLastName, value); }
        }

        [Display(Name = "SECUserViewIdentificationNumberField", ResourceType = typeof(Language))]
        [StringLength(16, ErrorMessageResourceName = "ApplicationErrorStringRequired", ErrorMessageResourceType = typeof(Language), MinimumLength = 1)]
        public virtual String IdentificationNumber
        {
            get { return GetValue(() => IdentificationNumber); }
            set { SetValue(() => IdentificationNumber, value); }
        }

        [Display(Name = "SECUserViewEmailField", ResourceType = typeof(Language))]
        [EmailAddress(ErrorMessageResourceName = "ApplicationErrorEmailValid", ErrorMessageResourceType = typeof(Language), ErrorMessage = null)]
        public virtual String Email
        {
            get { return GetValue(() => Email); }
            set { SetValue(() => Email, value); }
        }

        [Display(Name = "SECUserViewLockedField", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
        public virtual Boolean Locked
        {
            get { return GetValue(() => Locked); }
            set { SetValue(() => Locked, value); }
        }

        [Display(Name = "SECUserViewRequiresVerificationField", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
        public virtual Boolean RequiresVerification
        {
            get { return GetValue(() => RequiresVerification); }
            set { SetValue(() => RequiresVerification, value); }
        }

        [Display(Name = "SECRoleViewRoleField", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
        public virtual SECRole Role
        {
            get { return GetValue(() => Role); }
            set { SetValue(() => Role, value); }
        }

        //public virtual BindingList<SECUserCustomer> SECUserCustomers
        //{
        //    get { return GetValue(() => SECUserCustomers); }
        //    set { SetValue(() => SECUserCustomers, value); }
        //}

    }
}