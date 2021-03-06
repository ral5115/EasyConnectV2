using EasyTools.Framework.Resources;
using EasyTools.Framework.UI;
using EasyTools.Infrastructure.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EasyTools.UI.WPF.EasyConnect.Module.Models
{
    public class CONSQLModel : BaseModel
    {

        public BindingList<CONSQL> Details
        {
            get { return GetValue(() => Details); }
            set { SetValue(() => Details, value); }
        }

        public CONSQL SelectedCONSQL { get; set; }

        public CONSQL Entity
        {
            get
            {
                CONSQL data = new CONSQL();
                data.Id = this.Id;
                data.Active = this.Active;
                data.Description = this.Description;
                data.SQLSentence = this.SQLSentence;
                data.Automatic = this.Automatic;
                data.ExecuteStoreProcedure = this.ExecuteStoreProcedure;
                data.GenerateFile = this.GenerateFile;
                //data.FileName = this.FileName;
                data.Tag = this.Tag;
                //data.FileExtension = this.FileExtension;
                data.UpdatedBy = this.UpdatedBy;
                data.LastUpdate = this.LastUpdate;
                data.Connection = this.Connection;
                if (this.Connection != null)
                    data.ConnectionId = this.Connection.Id;
                data.StoreProcedureConnection = this.StoreProcedureConnection;
                if (this.StoreProcedureConnection != null)
                    data.StoreProcedureConnectionId = this.StoreProcedureConnection.Id;
                //data.DestinyConnection = this.DestinyConnection;
                //if (this.DestinyConnection != null)
                //    data.DestinyConnectionId = this.DestinyConnection.Id;
                data.Company = this.Company;
                if (this.Company != null)
                    data.CompanyId = this.Company.Id;
                data.MainSQL = this.MainSQL;
                if (this.MainSQL != null)
                    data.MainSQLId = this.MainSQL.Id;
                data.Structure = this.Structure;
                if (this.Structure != null)
                    data.StructureId = this.Structure.Id;
                if (this.SQLDetails != null && this.SQLDetails.Count > 0)
                    data.SQLDetails = this.SQLDetails.ToList<CONSQLDetail>();
                if (this.SQLParameters != null && this.SQLParameters.Count > 0)
                    data.SQLParameters = this.SQLParameters.ToList<CONSQLParameter>();
                if (this.ChildSQLs != null && this.ChildSQLs.Count > 0)
                    data.ChildSQLs = this.ChildSQLs.ToList<CONSQL>();
                if (this.SQLSends != null && this.SQLSends.Count > 0)
                    data.SQLSends = this.SQLSends.ToList<CONSQLSend>();
                return data;

            }
            set
            {
                this.Id = value.Id;
                this.Active = value.Active;
                this.Description = (String.IsNullOrWhiteSpace(value.Description) ? "" : value.Description);
                this.SQLSentence = (String.IsNullOrWhiteSpace(value.SQLSentence) ? "" : value.SQLSentence);
                this.Automatic = value.Automatic;
                this.ExecuteStoreProcedure = (String.IsNullOrWhiteSpace(value.ExecuteStoreProcedure) ? "" : value.ExecuteStoreProcedure);
                this.GenerateFile = value.GenerateFile;
                //this.FileName = (String.IsNullOrWhiteSpace(value.FileName) ? "" : value.FileName);
                this.Tag = (String.IsNullOrWhiteSpace(value.Tag) ? "" : value.Tag);
                //this.FileExtension = (String.IsNullOrWhiteSpace(value.FileExtension) ? "" : value.FileExtension);
                this.UpdatedBy = (String.IsNullOrWhiteSpace(value.UpdatedBy) ? "" : value.UpdatedBy);
                this.LastUpdate = value.LastUpdate;
                this.Connection = value.Connection;
                this.StoreProcedureConnection = value.StoreProcedureConnection;
                //this.DestinyConnection = value.DestinyConnection;
                this.Company = value.Company;
                this.MainSQL = value.MainSQL;
                this.Structure = value.Structure;
                if (value.SQLDetails != null && value.SQLDetails.Count > 0)
                    this.SQLDetails = new BindingList<CONSQLDetail>(value.SQLDetails);
                if (value.SQLParameters != null && value.SQLParameters.Count > 0)
                    this.SQLParameters = new BindingList<CONSQLParameter>(value.SQLParameters);
                if (value.ChildSQLs != null && value.ChildSQLs.Count > 0)
                    this.ChildSQLs = new BindingList<CONSQL>(value.ChildSQLs);
                if (value.SQLSends != null && value.SQLSends.Count > 0)
                    this.SQLSends = new BindingList<CONSQLSend>(value.SQLSends);

                this.NotifyPropertyChanged("Entity");
            }
        }

        [Display(Name = "CONSQLViewActiveField", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
        public virtual Boolean Active
        {
            get { return GetValue(() => Active); }
            set { SetValue(() => Active, value); }
        }

        [Display(Name = "CONSQLViewDescriptionField", ResourceType = typeof(Language))]
        [StringLength(255, ErrorMessageResourceName = "ApplicationErrorStringRequired", ErrorMessageResourceType = typeof(Language), MinimumLength = 1)]
        public virtual String Description
        {
            get { return GetValue(() => Description); }
            set { SetValue(() => Description, value); }
        }

        [Display(Name = "CONSQLViewSQLSentenceField", ResourceType = typeof(Language))]
        [StringLength(1000000, ErrorMessageResourceName = "ApplicationErrorStringOptional", ErrorMessageResourceType = typeof(Language), MinimumLength = 1)]
        public virtual String SQLSentence
        {
            get { return GetValue(() => SQLSentence); }
            set { SetValue(() => SQLSentence, value); }
        }

        [Display(Name = "CONSQLViewAutomaticField", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
        public virtual Boolean Automatic
        {
            get { return GetValue(() => Automatic); }
            set { SetValue(() => Automatic, value); }
        }

        [Display(Name = "CONSQLViewExecuteStoreProcedureField", ResourceType = typeof(Language))]
        //[StringLength(200, ErrorMessageResourceName = "ApplicationErrorStringOptional", ErrorMessageResourceType = typeof(Language), MinimumLength = 1)]
        public virtual String ExecuteStoreProcedure
        {
            get { return GetValue(() => ExecuteStoreProcedure); }
            set { SetValue(() => ExecuteStoreProcedure, value); }
        }

        [Display(Name = "CONSQLViewGenerateFileField", ResourceType = typeof(Language))]
        //[Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
        public virtual Boolean GenerateFile
        {
            get { return GetValue(() => GenerateFile); }
            set { SetValue(() => GenerateFile, value); }
        }

        //[Display(Name = "CONSQLViewFileNameField", ResourceType = typeof(Language))]
        ////[StringLength(255, ErrorMessageResourceName = "ApplicationErrorStringOptional", ErrorMessageResourceType = typeof(Language), MinimumLength = 1)]
        //public virtual String FileName
        //{
        //    get { return GetValue(() => FileName); }
        //    set { SetValue(() => FileName, value); }
        //}

        [Display(Name = "CONSQLViewTagField", ResourceType = typeof(Language))]
        //[StringLength(50, ErrorMessageResourceName = "ApplicationErrorStringOptional", ErrorMessageResourceType = typeof(Language), MinimumLength = 1)]
        public virtual String Tag
        {
            get { return GetValue(() => Tag); }
            set { SetValue(() => Tag, value); }
        }

        //[Display(Name = "CONSQLViewFileExtensionField", ResourceType = typeof(Language))]
        ////[StringLength(4, ErrorMessageResourceName = "ApplicationErrorStringOptional", ErrorMessageResourceType = typeof(Language), MinimumLength = 1)]
        //public virtual String FileExtension
        //{
        //    get { return GetValue(() => FileExtension); }
        //    set { SetValue(() => FileExtension, value); }
        //}

        [Display(Name = "CONSQLViewConnectionField", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
        public virtual SECConnection Connection
        {
            get { return GetValue(() => Connection); }
            set { SetValue(() => Connection, value); }
        }

        [Display(Name = "CONSQLViewStoreProcedureConnectionField", ResourceType = typeof(Language))]
        //[Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
        public virtual SECConnection StoreProcedureConnection
        {
            get { return GetValue(() => StoreProcedureConnection); }
            set { SetValue(() => StoreProcedureConnection, value); }
        }

        //[Display(Name = "CONSQLViewDestinyConnectionField", ResourceType = typeof(Language))]
        ////[Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
        //public virtual SECConnection DestinyConnection
        //{
        //    get { return GetValue(() => DestinyConnection); }
        //    set { SetValue(() => DestinyConnection, value); }
        //}

        [Display(Name = "CONSQLViewCompanyField", ResourceType = typeof(Language))]
        //[Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
        public virtual SECCompany Company
        {
            get { return GetValue(() => Company); }
            set { SetValue(() => Company, value); }
        }

        [Display(Name = "CONSQLViewMainSQLField", ResourceType = typeof(Language))]
       //[Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
        public virtual CONSQL MainSQL
        {
            get { return GetValue(() => MainSQL); }
            set { SetValue(() => MainSQL, value); }
        }

        [Display(Name = "CONSQLViewStructureField", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
        public virtual CONStructure Structure
        {
            get { return GetValue(() => Structure); }
            set { SetValue(() => Structure, value); }
        }

        public virtual BindingList<CONRecordDetail> RecordDetails
        {
            get { return GetValue(() => RecordDetails); }
            set { SetValue(() => RecordDetails, value); }
        }

        public virtual BindingList<CONRecord> Records
        {
            get { return GetValue(() => Records); }
            set { SetValue(() => Records, value); }
        }

        public virtual BindingList<CONSQLDetail> SQLDetails
        {
            get { return GetValue(() => SQLDetails); }
            set { SetValue(() => SQLDetails, value); }
        }

        public virtual BindingList<CONSQLParameter> SQLParameters
        {
            get { return GetValue(() => SQLParameters); }
            set { SetValue(() => SQLParameters, value); }
        }

        public virtual BindingList<CONSQL> ChildSQLs
        {
            get { return GetValue(() => ChildSQLs); }
            set { SetValue(() => ChildSQLs, value); }
        }

        public virtual BindingList<CONSQLSend> SQLSends
        {
            get { return GetValue(() => SQLSends); }
            set { SetValue(() => SQLSends, value); }
        }

    }
}