using EasyTools.Framework.Resources;
using EasyTools.Framework.UI;
using EasyTools.Infrastructure.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EasyTools.UI.WPF.EasyConnect.Module.Models
{
    public class CONEquivalenceModel : BaseModel
    {

        public BindingList<CONEquivalence> Details
        {
            get { return GetValue(() => Details); }
            set { SetValue(() => Details, value); }
        }

        public CONEquivalence SelectedCONEquivalence { get; set; }

        public CONEquivalence Entity
        {
            get
            {
                CONEquivalence data = new CONEquivalence();
                data.Id = this.Id;
                data.Name = this.Name;
                data.Active = this.Active;
                data.LabelValue1 = this.LabelValue1;
                data.LabelValue2 = this.LabelValue2;
                data.LabelValue3 = this.LabelValue3;
                data.LabelValue4 = this.LabelValue4;
                data.LabelValue5 = this.LabelValue5;
                data.LabelValue6 = this.LabelValue6;
                data.LabelValue7 = this.LabelValue7;
                data.LabelValue8 = this.LabelValue8;
                data.LabelValue9 = this.LabelValue9;
                data.LabelValue10 = this.LabelValue10;
                data.UpdatedBy = this.UpdatedBy;
                data.LastUpdate = this.LastUpdate;
                data.Company = this.Company;
                if (this.Company != null)
                    data.CompanyId = this.Company.Id;
                if (this.EquivalenceDetails != null && this.EquivalenceDetails.Count > 0)
                    data.EquivalenceDetails = this.EquivalenceDetails.ToList<CONEquivalenceDetail>();
                if (this.SQLDetails != null && this.SQLDetails.Count > 0)
                    data.SQLDetails = this.SQLDetails.ToList<CONSQLDetail>();
                return data;
            }
            set
            {
                this.Id = value.Id;
                this.Name = (String.IsNullOrWhiteSpace(value.Name) ? "" : value.Name);
                this.Active = value.Active;
                this.LabelValue1 = (String.IsNullOrWhiteSpace(value.LabelValue1) ? "" : value.LabelValue1);
                this.LabelValue2 = (String.IsNullOrWhiteSpace(value.LabelValue2) ? "" : value.LabelValue2);
                this.LabelValue3 = (String.IsNullOrWhiteSpace(value.LabelValue3) ? "" : value.LabelValue3);
                this.LabelValue4 = (String.IsNullOrWhiteSpace(value.LabelValue4) ? "" : value.LabelValue4);
                this.LabelValue5 = (String.IsNullOrWhiteSpace(value.LabelValue5) ? "" : value.LabelValue5);
                this.LabelValue6 = (String.IsNullOrWhiteSpace(value.LabelValue6) ? "" : value.LabelValue6);
                this.LabelValue7 = (String.IsNullOrWhiteSpace(value.LabelValue7) ? "" : value.LabelValue7);
                this.LabelValue8 = (String.IsNullOrWhiteSpace(value.LabelValue8) ? "" : value.LabelValue8);
                this.LabelValue9 = (String.IsNullOrWhiteSpace(value.LabelValue9) ? "" : value.LabelValue9);
                this.LabelValue10 = (String.IsNullOrWhiteSpace(value.LabelValue10) ? "" : value.LabelValue10);
                this.UpdatedBy = (String.IsNullOrWhiteSpace(value.UpdatedBy) ? "" : value.UpdatedBy);
                this.LastUpdate = value.LastUpdate;
                this.Company = value.Company;
                if (value.EquivalenceDetails != null && value.EquivalenceDetails.Count > 0)
                    this.EquivalenceDetails = new BindingList<CONEquivalenceDetail>(value.EquivalenceDetails);
                if (value.SQLDetails != null && value.SQLDetails.Count > 0)
                    this.SQLDetails = new BindingList<CONSQLDetail>(value.SQLDetails);
                this.NotifyPropertyChanged("Entity");
            }
        }

        [Display(Name = "CONEquivalenceViewNameField", ResourceType = typeof(Language))]
        [StringLength(50, ErrorMessageResourceName = "ApplicationErrorStringRequired", ErrorMessageResourceType = typeof(Language), MinimumLength = 1)]
        public virtual String Name
        {
            get { return GetValue(() => Name); }
            set { SetValue(() => Name, value); }
        }

        [Display(Name = "CONEquivalenceViewActiveField", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
        public virtual Boolean Active
        {
            get { return GetValue(() => Active); }
            set { SetValue(() => Active, value); }
        }

        [Display(Name = "CONEquivalenceViewLabelValue1Field", ResourceType = typeof(Language))]
        [StringLength(50, ErrorMessageResourceName = "ApplicationErrorStringOptional", ErrorMessageResourceType = typeof(Language), MinimumLength = 1)]
        public virtual String LabelValue1
        {
            get { return GetValue(() => LabelValue1); }
            set { SetValue(() => LabelValue1, value); }
        }

        [Display(Name = "CONEquivalenceViewLabelValue2Field", ResourceType = typeof(Language))]
        [StringLength(50, ErrorMessageResourceName = "ApplicationErrorStringOptional", ErrorMessageResourceType = typeof(Language))]
        public virtual String LabelValue2
        {
            get { return GetValue(() => LabelValue2); }
            set { SetValue(() => LabelValue2, value); }
        }

        [Display(Name = "CONEquivalenceViewLabelValue3Field", ResourceType = typeof(Language))]
        [StringLength(50, ErrorMessageResourceName = "ApplicationErrorStringOptional", ErrorMessageResourceType = typeof(Language))]
        public virtual String LabelValue3
        {
            get { return GetValue(() => LabelValue3); }
            set { SetValue(() => LabelValue3, value); }
        }

        [Display(Name = "CONEquivalenceViewLabelValue4Field", ResourceType = typeof(Language))]
        [StringLength(50, ErrorMessageResourceName = "ApplicationErrorStringOptional", ErrorMessageResourceType = typeof(Language))]
        public virtual String LabelValue4
        {
            get { return GetValue(() => LabelValue4); }
            set { SetValue(() => LabelValue4, value); }
        }

        [Display(Name = "CONEquivalenceViewLabelValue5Field", ResourceType = typeof(Language))]
        [StringLength(50, ErrorMessageResourceName = "ApplicationErrorStringOptional", ErrorMessageResourceType = typeof(Language))]
        public virtual String LabelValue5
        {
            get { return GetValue(() => LabelValue5); }
            set { SetValue(() => LabelValue5, value); }
        }

        [Display(Name = "CONEquivalenceViewLabelValue6Field", ResourceType = typeof(Language))]
        [StringLength(50, ErrorMessageResourceName = "ApplicationErrorStringOptional", ErrorMessageResourceType = typeof(Language))]
        public virtual String LabelValue6
        {
            get { return GetValue(() => LabelValue6); }
            set { SetValue(() => LabelValue6, value); }
        }

        [Display(Name = "CONEquivalenceViewLabelValue7Field", ResourceType = typeof(Language))]
        [StringLength(50, ErrorMessageResourceName = "ApplicationErrorStringOptional", ErrorMessageResourceType = typeof(Language))]
        public virtual String LabelValue7
        {
            get { return GetValue(() => LabelValue7); }
            set { SetValue(() => LabelValue7, value); }
        }

        [Display(Name = "CONEquivalenceViewLabelValue8Field", ResourceType = typeof(Language))]
        [StringLength(50, ErrorMessageResourceName = "ApplicationErrorStringOptional", ErrorMessageResourceType = typeof(Language))]
        public virtual String LabelValue8
        {
            get { return GetValue(() => LabelValue8); }
            set { SetValue(() => LabelValue8, value); }
        }

        [Display(Name = "CONEquivalenceViewLabelValue9Field", ResourceType = typeof(Language))]
        [StringLength(50, ErrorMessageResourceName = "ApplicationErrorStringOptional", ErrorMessageResourceType = typeof(Language))]
        public virtual String LabelValue9
        {
            get { return GetValue(() => LabelValue9); }
            set { SetValue(() => LabelValue9, value); }
        }

        [Display(Name = "CONEquivalenceViewLabelValue10Field", ResourceType = typeof(Language))]
        [StringLength(50, ErrorMessageResourceName = "ApplicationErrorStringOptional", ErrorMessageResourceType = typeof(Language))]
        public virtual String LabelValue10
        {
            get { return GetValue(() => LabelValue10); }
            set { SetValue(() => LabelValue10, value); }
        }

        //[Display(Name = "CONEquivalenceViewCompanyField", ResourceType = typeof(Language))]
        //[Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
        public virtual SECCompany Company
        {
            get { return GetValue(() => Company); }
            set { SetValue(() => Company, value); }
        }

        public virtual BindingList<CONEquivalenceDetail> EquivalenceDetails
        {
            get { return GetValue(() => EquivalenceDetails); }
            set { SetValue(() => EquivalenceDetails, value); }
        }

        public virtual BindingList<CONSQLDetail> SQLDetails
        {
            get { return GetValue(() => SQLDetails); }
            set { SetValue(() => SQLDetails, value); }
        }

    }
}