using EasyTools.Framework.Resources;
using EasyTools.Framework.UI;
using EasyTools.Infrastructure.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EasyTools.UI.WPF.EasyConnect.Module.Models
{
    public class CONErrorModel : BaseModel
    {

        public BindingList<CONError> Details
        {
            get { return GetValue(() => Details); }
            set { SetValue(() => Details, value); }
        }

        public CONError SelectedCONError { get; set; }

        public CONError Entity
        {
            get
            {
                CONError data = new CONError();
                data.Id = this.Id;
                data.ErrorLevel = this.ErrorLevel;
                data.ErrorValue = this.ErrorValue;
                data.ErrorDetail = this.ErrorDetail;
                data.RecordNumber = this.RecordNumber;
                data.RecordType = this.RecordType;
                data.SubRecordType = this.SubRecordType;
                data.Version = this.Version;
                data.UpdatedBy = this.UpdatedBy;
                data.LastUpdate = this.LastUpdate;
                data.Record = this.Record;
                if (this.Record != null)
                    data.RecordId = this.Record.Id;
                return data;

            }
            set
            {
                this.Id = value.Id;
                this.ErrorLevel = value.ErrorLevel;
                this.ErrorValue = (String.IsNullOrWhiteSpace(value.ErrorValue) ? "" : value.ErrorValue);
                this.ErrorDetail = (String.IsNullOrWhiteSpace(value.ErrorDetail) ? "" : value.ErrorDetail);
                this.RecordNumber = value.RecordNumber;
                this.RecordType = value.RecordType;
                this.SubRecordType = value.SubRecordType;
                this.Version = value.Version;
                this.UpdatedBy = (String.IsNullOrWhiteSpace(value.UpdatedBy) ? "" : value.UpdatedBy);
                this.LastUpdate = value.LastUpdate;
                this.Record = value.Record;
                this.NotifyPropertyChanged("Entity");
            }
        }

        [Display(Name = "CONErrorViewErrorLevelField", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
        public virtual Int16 ErrorLevel
        {
            get { return GetValue(() => ErrorLevel); }
            set { SetValue(() => ErrorLevel, value); }
        }

        [Display(Name = "CONErrorViewErrorValueField", ResourceType = typeof(Language))]
        [StringLength(200, ErrorMessageResourceName = "ApplicationErrorStringOptional", ErrorMessageResourceType = typeof(Language), MinimumLength = 1)]
        public virtual String ErrorValue
        {
            get { return GetValue(() => ErrorValue); }
            set { SetValue(() => ErrorValue, value); }
        }

        [Display(Name = "CONErrorViewErrorDetailField", ResourceType = typeof(Language))]
        [StringLength(255, ErrorMessageResourceName = "ApplicationErrorStringOptional", ErrorMessageResourceType = typeof(Language), MinimumLength = 1)]
        public virtual String ErrorDetail
        {
            get { return GetValue(() => ErrorDetail); }
            set { SetValue(() => ErrorDetail, value); }
        }

        [Display(Name = "CONErrorViewRecordNumberField", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
        public virtual Int32 RecordNumber
        {
            get { return GetValue(() => RecordNumber); }
            set { SetValue(() => RecordNumber, value); }
        }

        [Display(Name = "CONErrorViewRecordTypeField", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
        public virtual Int32 RecordType
        {
            get { return GetValue(() => RecordType); }
            set { SetValue(() => RecordType, value); }
        }

        [Display(Name = "CONErrorViewSubRecordTypeField", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
        public virtual Int32 SubRecordType
        {
            get { return GetValue(() => SubRecordType); }
            set { SetValue(() => SubRecordType, value); }
        }

        [Display(Name = "CONErrorViewVersionField", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
        public virtual Int32 Version
        {
            get { return GetValue(() => Version); }
            set { SetValue(() => Version, value); }
        }

        [Display(Name = "CONErrorViewRecordField", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
        public virtual CONRecord Record
        {
            get { return GetValue(() => Record); }
            set { SetValue(() => Record, value); }
        }

    }
}