using EasyTools.Framework.Resources;
using EasyTools.Framework.UI;
using EasyTools.Infrastructure.Entities;
using EasyTools.Infrastructure.Entities.Base;
//using EasyTools.UI.Data.Server;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EasyTools.UI.WPF.EasyConnect.Module.Models
{
    public class CONSQLParameterModel : BaseModel
    {
        
        public BindingList<CONSQLParameter> Details 
        {
           get { return GetValue(() => Details); }
           set { SetValue(() => Details, value); }
        }

        public CONSQLParameter SelectedCONSQLParameter { get; set; }

        public CONSQLParameter Entity 
        { 
           get
           {   
              CONSQLParameter data = new CONSQLParameter();
              data.Id = this.Id;
              data.Name = this.Name;
              data.IsDate = this.IsDate;
              data.DateValue = this.DateValue;
              data.DefaultDateValue = this.DefaultDateValue;
              data.IsInt = this.IsInt;
              data.Int32Value = this.Int32Value;
              data.IsString = this.IsString;
              data.StringValue = this.StringValue;
              data.Secuence = this.Secuence;
              data.UpdatedBy = this.UpdatedBy;
              data.LastUpdate = this.LastUpdate;
              data.SQL = this.SQL;
              if (this.SQL != null)
                 data.SQLId = this.SQL.Id;
              return data;
                     
           }
           set
           {   
              this.Id = value.Id;
              this.Name = (String.IsNullOrWhiteSpace(value.Name) ? "" : value.Name ) ;
              this.IsDate = value.IsDate;
              this.DateValue = value.DateValue;
              this.DefaultDateValue = value.DefaultDateValue;
              this.IsInt = value.IsInt;
              this.Int32Value = value.Int32Value;
              this.IsString = value.IsString;
              this.StringValue = (String.IsNullOrWhiteSpace(value.StringValue) ? "" : value.StringValue ) ;
              this.Secuence = value.Secuence;
              this.UpdatedBy = (String.IsNullOrWhiteSpace(value.UpdatedBy) ? "" : value.UpdatedBy ) ;
              this.LastUpdate = value.LastUpdate;
              this.SQL = value.SQL;
              this.NotifyPropertyChanged("Entity"); 
           }
        }

        [Display(Name = "CONSQLParameterViewNameField", ResourceType = typeof(Language))]
        [StringLength(30, ErrorMessageResourceName = "ApplicationErrorStringRequired", ErrorMessageResourceType = typeof(Language), MinimumLength=1)]
         public virtual String Name
         {
             get { return GetValue(() => Name); }
             set { SetValue(() => Name, value); }
         }

        [Display(Name = "CONSQLParameterViewIsDateField", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
         public virtual Boolean IsDate
         {
             get { return GetValue(() => IsDate); }
             set { SetValue(() => IsDate, value); }
         }

        [Display(Name = "CONSQLParameterViewDateValueField", ResourceType = typeof(Language))]
         public virtual DateTime? DateValue {
         
             get { return GetValue(() => DateValue); }
             set { SetValue(() => DateValue, value); }
         }

        [Display(Name = "CONSQLParameterViewDefaultDateValueField", ResourceType = typeof(Language))]
         public virtual Int32? DefaultDateValue {
         
             get { return GetValue(() => DefaultDateValue); }
             set { SetValue(() => DefaultDateValue, value); }
         }

        [Display(Name = "CONSQLParameterViewDefaultDateValueField", ResourceType = typeof(Language))]
        public virtual OptionValue SelectedDefaultDateValue
        {

            get { return GetValue(() => SelectedDefaultDateValue); }
            set { SetValue(() => SelectedDefaultDateValue, value); }
        }

        [Display(Name = "CONSQLParameterViewIsIntField", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
         public virtual Boolean IsInt
         {
             get { return GetValue(() => IsInt); }
             set { SetValue(() => IsInt, value); }
         }

        [Display(Name = "CONSQLParameterViewInt32ValueField", ResourceType = typeof(Language))]
         public virtual Int32? Int32Value {
         
             get { return GetValue(() => Int32Value); }
             set { SetValue(() => Int32Value, value); }
         }

        [Display(Name = "CONSQLParameterViewIsStringField", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
         public virtual Boolean IsString
         {
             get { return GetValue(() => IsString); }
             set { SetValue(() => IsString, value); }
         }

        [Display(Name = "CONSQLParameterViewStringValueField", ResourceType = typeof(Language))]
        //[StringLength(100, ErrorMessageResourceName = "ApplicationErrorStringOptional", ErrorMessageResourceType = typeof(Language), MinimumLength=1)]
         public virtual String StringValue
         {
             get { return GetValue(() => StringValue); }
             set { SetValue(() => StringValue, value); }
         }

        [Display(Name = "CONSQLParameterViewSecuenceField", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
         public virtual Int16 Secuence
         {
             get { return GetValue(() => Secuence); }
             set { SetValue(() => Secuence, value); }
         }

        [Display(Name = "CONSQLParameterViewSQLField", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "ApplicationErrorFieldRequired", ErrorMessageResourceType = typeof(Language))]
         public virtual CONSQL SQL
         {
             get { return GetValue(() => SQL); }
             set { SetValue(() => SQL, value); }
         }

}
}
