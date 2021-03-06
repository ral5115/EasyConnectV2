using EasyTools.Framework.Data;
using EasyTools.Framework.Resources;
using EasyTools.Framework.UI;
using EasyTools.Infrastructure.Entities;
using EasyTools.UI.Data;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EasyTools.UI.WPF.EasyConnect.Module.Models
{
    public class CONIntegratorConfigurationModel : BaseModel
    {

        public BindingList<CONIntegratorConfiguration> Details
        {
            get { return GetValue(() => Details); }
            set { SetValue(() => Details, value); }
        }

        public CONIntegratorConfiguration SelectedCONIntegratorConfiguration { get; set; }

        public CONIntegratorConfiguration Entity
        {
            get
            {
                CONIntegratorConfiguration data = new CONIntegratorConfiguration();
                data.Id = this.Id;
                //data.WebServiceUrl = this.WebServiceUrl;
                data.InternalUser = this.InternalUser;
                data.InternalPassword = String.IsNullOrWhiteSpace(this.InternalPassword) ? "" : Crypto.EncrytedString(this.InternalPassword);
                //data.InternalConnectionName = this.InternalConnectionName;
                data.Active = this.Active;
                //data.DirectImport = this.DirectImport;
                data.ProgramPath = this.ProgramPath;
                data.FileExtension = this.FileExtension;
                data.FileName = this.FileName;
                data.ConnectionNumber = this.ConnectionNumber;
                data.Connection = this.Connection;
                if (this.Connection != null)
                    data.ConnectionId = this.Connection.Id;
                data.UpdatedBy = this.UpdatedBy;
                data.LastUpdate = this.LastUpdate;
                data.Integrator = this.Integrator;
                if (this.Integrator != null)
                    data.IntegratorId = this.Integrator.Id;
                data.Company = this.Company;
                if (this.Company != null)
                    data.CompanyId = this.Company.Id;
                if (this.SQLSends != null && this.SQLSends.Count > 0)
                    data.SQLSends = this.SQLSends.ToList<CONSQLSend>();
                if (this.ExportType != null)
                    data.Type = this.ExportType.Key;
                return data;
            }
            set
            {
                this.Id = value.Id;
                //this.WebServiceUrl = (String.IsNullOrWhiteSpace(value.WebServiceUrl) ? "" : value.WebServiceUrl);
                this.InternalUser = (String.IsNullOrWhiteSpace(value.InternalUser) ? "" : value.InternalUser);
                this.InternalPassword = (String.IsNullOrWhiteSpace(value.InternalPassword) ? "" : Crypto.DecrytedString(value.InternalPassword));
                //this.InternalConnectionName = (String.IsNullOrWhiteSpace(value.InternalConnectionName) ? "" : value.InternalConnectionName);
                this.Active = value.Active;
                this.ConnectionNumber = value.ConnectionNumber;
                //this.DirectImport = value.DirectImport;
                this.ProgramPath = value.ProgramPath;
                this.Connection = value.Connection;
                this.UpdatedBy = (String.IsNullOrWhiteSpace(value.UpdatedBy) ? "" : value.UpdatedBy);
                this.LastUpdate = value.LastUpdate;
                this.Integrator = value.Integrator;
                this.FileExtension = value.FileExtension;
                this.FileName = value.FileName;
                this.Company = value.Company;
                if (value.SQLSends != null && value.SQLSends.Count > 0)
                    this.SQLSends = new BindingList<CONSQLSend>(value.SQLSends);
                if (!string.IsNullOrWhiteSpace(value.Type))
                    this.ExportType = EasyApp.Current.ListExportTypes.FirstOrDefault(x => x.Key == value.Type);
                this.NotifyPropertyChanged("Entity");
            }
        }

        //[Display(Name = "CONIntegratorConfigurationViewWebServiceUrlField", ResourceType = typeof(Language))]
        ////[StringLength(1024, ErrorMessageResourceName = "ApplicationErrorStringRequired", ErrorMessageResourceType = typeof(Language))]
        //public virtual String WebServiceUrl
        //{
        //    get { return GetValue(() => WebServiceUrl); }
        //    set { SetValue(() => WebServiceUrl, value); }
        //}

        [Display(Name = "CONIntegratorConfigurationViewInternalUserField", ResourceType = typeof(Language))]
        //[StringLength(50, ErrorMessageResourceName = "ApplicationErrorStringRequired", ErrorMessageResourceType = typeof(Language), MinimumLength = 1)]
        public virtual String InternalUser
        {
            get { return GetValue(() => InternalUser); }
            set { SetValue(() => InternalUser, value); }
        }

        [Display(Name = "CONIntegratorConfigurationViewInternalPasswordField", ResourceType = typeof(Language))]
        //[StringLength(255, ErrorMessageResourceName = "ApplicationErrorStringRequired", ErrorMessageResourceType = typeof(Language), MinimumLength = 1)]
        public virtual String InternalPassword
        {
            get { return GetValue(() => InternalPassword); }
            set { SetValue(() => InternalPassword, value); }
        }

        //[Display(Name = "CONIntegratorConfigurationViewInternalConnectionNameField", ResourceType = typeof(Language))]
        ////[StringLength(10, ErrorMessageResourceName = "ApplicationErrorStringRequired", ErrorMessageResourceType = typeof(Language))]
        //public virtual String InternalConnectionName
        //{
        //    get { return GetValue(() => InternalConnectionName); }
        //    set { SetValue(() => InternalConnectionName, value); }
        //}

        [Display(Name = "CONIntegratorConfigurationViewActiveField", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
        public virtual Boolean Active
        {
            get { return GetValue(() => Active); }
            set { SetValue(() => Active, value); }
        }

        [Display(Name = "CONIntegratorConfigurationViewIntegratorField", ResourceType = typeof(Language))]
        //[Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
        public virtual CONIntegrator Integrator
        {
            get { return GetValue(() => Integrator); }
            set { SetValue(() => Integrator, value); }
        }

        [Display(Name = "CONIntegratorConfigurationViewCompanyField", ResourceType = typeof(Language))]
        //[Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
        public virtual SECCompany Company
        {
            get { return GetValue(() => Company); }
            set { SetValue(() => Company, value); }
        }

        [Display(Name = "CONIntegratorConfigurationViewConnectionNumberField", ResourceType = typeof(Language))]
        //[Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
        public virtual Int32? ConnectionNumber
        {
            get { return GetValue(() => ConnectionNumber); }
            set { SetValue(() => ConnectionNumber, value); }
        }

        [Display(Name = "CONIntegratorConfigurationViewProgramPathField", ResourceType = typeof(Language))]
        //[StringLength(10, ErrorMessageResourceName = "ApplicationErrorStringRequired", ErrorMessageResourceType = typeof(Language))]
        public virtual String ProgramPath
        {
            get { return GetValue(() => ProgramPath); }
            set { SetValue(() => ProgramPath, value); }
        }

        //[Display(Name = "CONIntegratorConfigurationViewDirectImportField", ResourceType = typeof(Language))]
        //[Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
        //public virtual Boolean DirectImport
        //{
        //    get { return GetValue(() => DirectImport); }
        //    set { SetValue(() => DirectImport, value); }
        //}


        [Display(Name = "CONIntegratorConfigurationViewConnectionIdField", ResourceType = typeof(Language))]
        //[Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
        public virtual SECConnection Connection
        {
            get { return GetValue(() => Connection); }
            set { SetValue(() => Connection, value); }
        }

        public virtual BindingList<CONSQLSend> SQLSends
        {
            get { return GetValue(() => SQLSends); }
            set { SetValue(() => SQLSends, value); }
        }

        [Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
        public KeyValue ExportType
        {
            get { return GetValue(() => ExportType); }
            set { SetValue(() => ExportType, value); }
        }

        [Display(Name = "CONIntegratorConfigurationViewFileExtensionField", ResourceType = typeof(Language))]
        //[StringLength(10, ErrorMessageResourceName = "ApplicationErrorStringRequired", ErrorMessageResourceType = typeof(Language))]
        public virtual String FileExtension
        {
            get { return GetValue(() => FileExtension); }
            set { SetValue(() => FileExtension, value); }
        }

        [Display(Name = "CONIntegratorConfigurationViewFileNameField", ResourceType = typeof(Language))]
        //[StringLength(10, ErrorMessageResourceName = "ApplicationErrorStringRequired", ErrorMessageResourceType = typeof(Language))]
        public virtual String FileName
        {
            get { return GetValue(() => FileName); }
            set { SetValue(() => FileName, value); }
        }

    }
}