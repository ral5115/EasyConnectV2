using EasyTools.Framework.Data;
using EasyTools.Framework.Resources;
using EasyTools.Framework.UI;
using EasyTools.Infrastructure.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EasyTools.UI.WPF.Security.Module.Models
{
    public class SECConnectionModel : BaseModel
    {

        public BindingList<SECConnection> Details
        {
            get { return GetValue(() => Details); }
            set { SetValue(() => Details, value); }
        }

        public SECConnection SelectedSECConnection { get; set; }

        public virtual SECConnection Entity
        {
            get
            {
                SECConnection data = new SECConnection();
                data.Id = this.Id;
                data.Active = this.Active;
                data.Login = this.Login;
                data.Password = String.IsNullOrWhiteSpace(this.Password) ? "" : Crypto.EncrytedString(this.Password);
                data.Service = this.Service;
                data.DB = this.DB;
                data.LastUpdate = this.LastUpdate;
                data.UpdatedBy = this.UpdatedBy;
                data.Name = this.Name;
                data.Company = this.Company;
                if (this.Company != null)
                    data.CompanyId = this.Company.Id;
                data.DbType = this.DbType;
                return data;

            }
            set
            {
                this.Id = value.Id;
                this.Active = value.Active;
                this.Login = (String.IsNullOrWhiteSpace(value.Login) ? "" : value.Login);
                this.Password = (String.IsNullOrWhiteSpace(value.Password) ? "" : Crypto.DecrytedString(value.Password));
                this.Service = (String.IsNullOrWhiteSpace(value.Service) ? "" : value.Service);
                this.DB = (String.IsNullOrWhiteSpace(value.DB) ? "" : value.DB);
                this.LastUpdate = value.LastUpdate;
                this.UpdatedBy = (String.IsNullOrWhiteSpace(value.UpdatedBy) ? "" : value.UpdatedBy);
                this.Name = (String.IsNullOrWhiteSpace(value.Name) ? "" : value.Name);
                this.Company = value.Company;
                this.DbType = value.DbType;
                this.NotifyPropertyChanged("Entity");
            }
        }

        [Display(Name = "SECConnectionViewActiveField", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
        public virtual Boolean Active
        {
            get { return GetValue(() => Active); }
            set { SetValue(() => Active, value); }
        }

        [Display(Name = "SECConnectionViewLoginField", ResourceType = typeof(Language))]
        [StringLength(50, ErrorMessageResourceName = "ApplicationErrorStringRequired", ErrorMessageResourceType = typeof(Language), MinimumLength = 1)]
        public virtual String Login
        {
            get { return GetValue(() => Login); }
            set { SetValue(() => Login, value); }
        }

        [Display(Name = "SECConnectionViewPasswordField", ResourceType = typeof(Language))]
        [StringLength(255, ErrorMessageResourceName = "ApplicationErrorStringRequired", ErrorMessageResourceType = typeof(Language), MinimumLength = 1)]
        public virtual String Password
        {
            get { return GetValue(() => Password); }
            set { SetValue(() => Password, value); }
        }

        [Display(Name = "SECConnectionViewServiceField", ResourceType = typeof(Language))]
        [StringLength(50, ErrorMessageResourceName = "ApplicationErrorStringRequired", ErrorMessageResourceType = typeof(Language), MinimumLength = 1)]
        public virtual String Service
        {
            get { return GetValue(() => Service); }
            set { SetValue(() => Service, value); }
        }

        [Display(Name = "SECConnectionViewDBField", ResourceType = typeof(Language))]
        //[StringLength(50, ErrorMessageResourceName = "ApplicationErrorStringOptional", ErrorMessageResourceType = typeof(Language), MinimumLength = 1)]
        public virtual String DB
        {
            get { return GetValue(() => DB); }
            set { SetValue(() => DB, value); }
        }

        [Display(Name = "SECConnectionViewNameField", ResourceType = typeof(Language))]
        [StringLength(50, ErrorMessageResourceName = "ApplicationErrorStringRequired", ErrorMessageResourceType = typeof(Language), MinimumLength = 1)]
        public virtual String Name
        {
            get { return GetValue(() => Name); }
            set { SetValue(() => Name, value); }
        }

        [Display(Name = "SECConnectionViewCompanyField", ResourceType = typeof(Language))]
        //[Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
        public virtual SECCompany Company
        {
            get { return GetValue(() => Company); }
            set { SetValue(() => Company, value); }
        }

        [Display(Name = "SECConnectionViewDbTypeField", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
        public virtual string DbType
        {
            get { return GetValue(() => DbType); }
            set { SetValue(() => DbType, value); }
        }

    }
}