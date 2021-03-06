 using EasyTools.Framework.Resources;
using EasyTools.Framework.UI;
using EasyTools.Infrastructure.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EasyTools.UI.WPF.EasyConnect.Module.Models
{
    public class CONRecordModel : BaseModel
    {
        
        public BindingList<CONRecord> Details 
        {
           get { return GetValue(() => Details); }
           set { SetValue(() => Details, value); }
        }

        public CONRecord SelectedCONRecord { get; set; }

        public CONRecord Entity 
        {
            get
            {
                CONRecord data = new CONRecord();
                data.Id = this.Id;
                data.RecordNumber = this.RecordNumber;
                data.RecordType = this.RecordType;
                data.SubRecordType = this.SubRecordType;
                data.Version = (Int32?)this.Version;
                data.Company = this.Company;
                data.IsSend = this.IsSend;
                data.LogicalKey = this.LogicalKey;
                data.DocumentNumber = this.DocumentNumber;
                data.XMLData = this.XMLData;
                data.IsExternal = this.IsExternal;
                data.OperationCenter = this.OperationCenter;
                data.DocumentType = this.DocumentType;
                data.PlainText = this.PlainText;
                data.UpdatedBy = this.UpdatedBy;
                data.LastUpdate = this.LastUpdate;
                data.HasPaging = this.HasPaging;
                data.CurrentPage = this.CurrentPage;
                data.PageSize = this.PageSize;
                data.SQL = this.SQL;
                data.ParallelNumber = this.ParallelNumber;
                if (this.SQL != null)
                    data.SQLId = this.SQL.Id;
                if (this.Errors1 != null && this.Errors1.Count > 0)
                    data.Errors1 = this.Errors1.ToList<CONError>();
                if (this.RecordDetails != null && this.RecordDetails.Count > 0)
                    data.RecordDetails = this.RecordDetails.ToList<CONRecordDetail>();
                return data;

            }
           set
           {   
              this.Id = value.Id;
              this.RecordNumber = (Int32?)value.RecordNumber;
              this.RecordType = (Int32?)value.RecordType;
              this.SubRecordType = (Int32?)value.SubRecordType;
              this.Version = value.Version;
              this.Company = (String.IsNullOrWhiteSpace(value.Company) ? "" : value.Company ) ;
              this.IsSend = value.IsSend;
              this.LogicalKey = (String.IsNullOrWhiteSpace(value.LogicalKey) ? "" : value.LogicalKey ) ;
              this.DocumentNumber = value.DocumentNumber;
              this.XMLData = (String.IsNullOrWhiteSpace(value.XMLData) ? "" : value.XMLData ) ;
              this.IsExternal = value.IsExternal;
              this.OperationCenter = (String.IsNullOrWhiteSpace(value.OperationCenter) ? "" : value.OperationCenter ) ;
              this.DocumentType = (String.IsNullOrWhiteSpace(value.DocumentType) ? "" : value.DocumentType ) ;
              this.PlainText = (String.IsNullOrWhiteSpace(value.PlainText) ? "" : value.PlainText ) ;
              this.UpdatedBy = (String.IsNullOrWhiteSpace(value.UpdatedBy) ? "" : value.UpdatedBy ) ;
              this.LastUpdate = value.LastUpdate;
              this.HasPaging = value.HasPaging;
              this.CurrentPage = value.CurrentPage;
              this.PageSize = value.PageSize;
              this.SQL = value.SQL;
              this.ParallelNumber = value.ParallelNumber;
              if (value.Errors1 != null && value.Errors1.Count > 0)
                  this.Errors1 = new BindingList<CONError>(value.Errors1);
              if (value.RecordDetails != null && value.RecordDetails.Count > 0)
                  this.RecordDetails = new BindingList<CONRecordDetail>(value.RecordDetails);
              this.NotifyPropertyChanged("Entity"); 
           }
        }

        [Display(Name = "CONRecordViewRecordNumberField", ResourceType = typeof(Language))]
        //[Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
         public virtual Int32? RecordNumber
         {
             get { return GetValue(() => RecordNumber); }
             set { SetValue(() => RecordNumber, value); }
         }

        [Display(Name = "CONRecordViewRecordTypeField", ResourceType = typeof(Language))]
        //[Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
         public virtual Int32? RecordType
         {
             get { return GetValue(() => RecordType); }
             set { SetValue(() => RecordType, value); }
         }

        [Display(Name = "CONRecordViewSubRecordTypeField", ResourceType = typeof(Language))]
        //[Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
         public virtual Int32? SubRecordType
         {
             get { return GetValue(() => SubRecordType); }
             set { SetValue(() => SubRecordType, value); }
         }

        [Display(Name = "CONRecordViewVersionField", ResourceType = typeof(Language))]
        //[Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
         public virtual Int32? Version
         {
             get { return GetValue(() => Version); }
             set { SetValue(() => Version, value); }
         }

        [Display(Name = "CONRecordViewCompanyField", ResourceType = typeof(Language))]
        //[StringLength(3, ErrorMessageResourceName = "ApplicationErrorStringRequired", ErrorMessageResourceType = typeof(Language))]
         public virtual String Company
         {
             get { return GetValue(() => Company); }
             set { SetValue(() => Company, value); }
         }

        [Display(Name = "CONRecordViewIsSendField", ResourceType = typeof(Language))]
        //[Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
         public virtual Boolean IsSend
         {
             get { return GetValue(() => IsSend); }
             set { SetValue(() => IsSend, value); }
         }

        [Display(Name = "CONRecordViewLogicalKeyField", ResourceType = typeof(Language))]
        //[StringLength(50000, ErrorMessageResourceName = "ApplicationErrorStringRequired", ErrorMessageResourceType = typeof(Language))]
         public virtual String LogicalKey
         {
             get { return GetValue(() => LogicalKey); }
             set { SetValue(() => LogicalKey, value); }
         }

        [Display(Name = "CONRecordViewDocumentNumberField", ResourceType = typeof(Language))]
         public virtual Int32? DocumentNumber 
         {
             get { return GetValue(() => DocumentNumber); }
             set { SetValue(() => DocumentNumber, value); }
         }

        [Display(Name = "CONRecordViewXMLDataField", ResourceType = typeof(Language))]
        //[StringLength(100000, ErrorMessageResourceName = "ApplicationErrorStringRequired", ErrorMessageResourceType = typeof(Language))]
         public virtual String XMLData
         {
             get { return GetValue(() => XMLData); }
             set { SetValue(() => XMLData, value); }
         }

        [Display(Name = "CONRecordViewIsExternalField", ResourceType = typeof(Language))]
        //[Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
         public virtual Boolean IsExternal
         {
             get { return GetValue(() => IsExternal); }
             set { SetValue(() => IsExternal, value); }
         }

        [Display(Name = "CONRecordViewOperationCenterField", ResourceType = typeof(Language))]
        //[StringLength(3, ErrorMessageResourceName = "ApplicationErrorStringOptional", ErrorMessageResourceType = typeof(Language))]
         public virtual String OperationCenter
         {
             get { return GetValue(() => OperationCenter); }
             set { SetValue(() => OperationCenter, value); }
         }

        [Display(Name = "CONRecordViewDocumentTypeField", ResourceType = typeof(Language))]
        //[StringLength(3, ErrorMessageResourceName = "ApplicationErrorStringOptional", ErrorMessageResourceType = typeof(Language))]
         public virtual String DocumentType
         {
             get { return GetValue(() => DocumentType); }
             set { SetValue(() => DocumentType, value); }
         }

        [Display(Name = "CONRecordViewPlainTextField", ResourceType = typeof(Language))]
        //[StringLength(10000, ErrorMessageResourceName = "ApplicationErrorStringRequired", ErrorMessageResourceType = typeof(Language))]
         public virtual String PlainText
         {
             get { return GetValue(() => PlainText); }
             set { SetValue(() => PlainText, value); }
         }

        [Display(Name = "CONRecordViewSQLField", ResourceType = typeof(Language))]
        //[Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
         public virtual CONSQL SQL
         {
             get { return GetValue(() => SQL); }
             set { SetValue(() => SQL, value); }
         }

         public virtual BindingList<CONError> Errors1
         {
             get { return GetValue(() => Errors1); }
             set { SetValue(() => Errors1, value); }
         }

         public virtual BindingList<CONRecordDetail> RecordDetails
         {
             get { return GetValue(() => RecordDetails); }
             set { SetValue(() => RecordDetails, value); }
         }

         
    }
}
