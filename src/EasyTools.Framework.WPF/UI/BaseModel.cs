using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace EasyTools.Framework.UI
{
    public class BaseModel : INotifyPropertyChanged, IDataErrorInfo
    {
        #region Fields

        private readonly Dictionary<string, object> _values = new Dictionary<string, object>();

        private readonly Dictionary<string, List<ValidationResult>> _errors = new Dictionary<string, List<ValidationResult>>();

        #endregion

        #region Protected

        /// <summary>
        /// Sets the value of a property.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="propertySelector">Expression tree contains the property definition.</param>
        /// <param name="value">The property value.</param>
        protected void SetValue<T>(Expression<Func<T>> propertySelector, T value)
        {
            string propertyName = GetPropertyName(propertySelector);

            SetValue<T>(propertyName, value);
        }

        /// <summary>
        /// Sets the value of a property.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The property value.</param>
        protected void SetValue<T>(string propertyName, T value)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentException("Invalid property name", propertyName);
            }

            _values[propertyName] = value;

            NotifyPropertyChanged(propertyName);
        }

        /// <summary>
        /// Gets the value of a property.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="propertySelector">Expression tree contains the property definition.</param>
        /// <returns>The value of the property or default value if not exist.</returns>
        protected T GetValue<T>(Expression<Func<T>> propertySelector)
        {
            string propertyName = GetPropertyName(propertySelector);

            return GetValue<T>(propertyName);
        }

        /// <summary>
        /// Gets the value of a property.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>The value of the property or default value if not exist.</returns>
        protected T GetValue<T>(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentException("Invalid property name", propertyName);
            }

            object value;
            if (!_values.TryGetValue(propertyName, out value))
            {
                value = default(T);
                _values.Add(propertyName, value);
            }

            return (T)value;
        }

        /// <summary>
        /// Validates current instance properties using Data Annotations.
        /// </summary>
        /// <param name="propertyName">This instance property to validate.</param>
        /// <returns>Relevant error string on validation failure or <see cref="System.String.Empty"/> on validation success.</returns>
        protected virtual string OnValidate(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentException("Invalid property name", propertyName);
            }

            string error = string.Empty;
            var value = GetValue(propertyName);
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>(1);
            var result = Validator.TryValidateProperty(
                value,
                new ValidationContext(this, null, null)
                {
                    MemberName = propertyName
                },
                results);

            if (!result)
            {
                var validationResult = results.First();
                error = validationResult.ErrorMessage;
                if (_errors.ContainsKey(propertyName))
                    _errors[propertyName] = results;
                else
                    _errors.Add(propertyName, results);

            }
            else
            {
                if (_errors.ContainsKey(propertyName))
                    _errors.Remove(propertyName);
            }
            Errors = GetErrors(_errors);
            IsValid = _errors.Count == 0;
            return error;
        }

        public void CheckAllRules()
        {
            _errors.Clear();
            if (_values != null && _values.Count > 0)
            {
                for (int i = 0; i < _values.Count; i++)
                {
                    OnValidate(_values.ElementAt(i).Key);
                }
            }
        }
        public bool IsValid
        {
            get { return GetValue(() => IsValid); }
            set { SetValue(() => IsValid, value); }
        }

        #endregion

        #region Change Notification

        /// <summary>
        /// Raised when a property on this object has a new value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected void NotifyPropertyChanged(string propertyName)
        {
            this.VerifyPropertyName(propertyName);

            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            //this.VerifyPropertyName(propertyName);

            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        protected void NotifyPropertyChanged<T>(Expression<Func<T>> propertySelector)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                string propertyName = GetPropertyName(propertySelector);
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion // INotifyPropertyChanged Members

        #region Data Validation

        string IDataErrorInfo.Error
        {

            get
            {
                throw new NotSupportedException("IDataErrorInfo.Error is not supported, use IDataErrorInfo.this[propertyName] instead.");
            }
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                if (!propertyName.Equals("IsValid") && !propertyName.Equals("Errors") && !propertyName.Equals("Entity"))
                    return OnValidate(propertyName);
                else
                    return string.Empty;
            }
        }

        #endregion

        #region Privates

        private string GetPropertyName(LambdaExpression expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new InvalidOperationException();
            }

            return memberExpression.Member.Name;
        }

        private object GetValue(string propertyName)
        {
            object value;
            if (!_values.TryGetValue(propertyName, out value))
            {
                var propertyDescriptor = TypeDescriptor.GetProperties(GetType()).Find(propertyName, false);
                if (propertyDescriptor == null)
                {
                    throw new ArgumentException("Invalid property name", propertyName);
                }

                value = propertyDescriptor.GetValue(this);
                _values.Add(propertyName, value);
            }

            return value;
        }

        #endregion

        #region Debugging

        /// <summary>
        /// Warns the developer if this object does not have
        /// a public property with the specified name. This 
        /// method does not exist in a Release build.
        /// </summary>
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public void VerifyPropertyName(string propertyName)
        {
            // Verify that the property name matches a real,  
            // public, instance property on this object.
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                string msg = "Invalid property name: " + propertyName;

                if (this.ThrowOnInvalidPropertyName)
                    throw new Exception(msg);
                else
                    Debug.Fail(msg);
            }
        }

        /// <summary>
        /// Returns whether an exception is thrown, or if a Debug.Fail() is used
        /// when an invalid property name is passed to the VerifyPropertyName method.
        /// The default value is false, but subclasses used by unit tests might 
        /// override this property's getter to return true.
        /// </summary>
        protected virtual bool ThrowOnInvalidPropertyName { get; private set; }

        #endregion // Debugging Aides

        public string GetErrors(Dictionary<string, List<ValidationResult>> perrors)
        {
            StringBuilder sb = new StringBuilder();
            if (perrors != null && perrors.Count > 0)
            {
                foreach (var error in perrors)
                {
                    if (error.Value != null && error.Value.Count > 0)
                    {
                        foreach (var errVal in error.Value)
                        {
                            sb.AppendLine(errVal.ErrorMessage);
                        }
                    }
                }
            }
            return sb.ToString();
        }

        public string Errors
        {
            get { return GetValue(() => Errors); }
            set { SetValue(() => Errors, value); }
        }

        #region Shares Properties



        public virtual int Id
        {
            get { return GetValue(() => Id); }
            set { SetValue(() => Id, value); }
        }

        public virtual DateTime LastUpdate
        {
            get { return GetValue(() => LastUpdate); }
            set { SetValue(() => LastUpdate, value); }
        }

        public virtual string UpdatedBy
        {
            get { return GetValue(() => UpdatedBy); }
            set { SetValue(() => UpdatedBy, value); }
        }

        public virtual bool HasPaging
        {
            get { return GetValue(() => HasPaging); }
            set { SetValue(() => HasPaging, value); }
        }

        public virtual int PageSize
        {
            get { return GetValue(() => PageSize); }
            set { SetValue(() => PageSize, value); }
        }

        public virtual int CurrentPage
        {
            get { return GetValue(() => CurrentPage); }
            set { SetValue(() => CurrentPage, value); }
        }

        public virtual int ParallelNumber
        {
            get { return GetValue(() => ParallelNumber); }
            set { SetValue(() => ParallelNumber, value); }
        }

        #endregion

        //public void AddStringLengthValidation(Type type, string propertyName, int maximunLength, string ErrorMessageResourceName, Type ErrorMessageResourceType, int minimumLength)
        //{
        //    var propDesc = TypeDescriptor.GetProperties(type)[propertyName];
        //    var methodInfo = propDesc.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).FirstOrDefault(m => m.IsFamily || m.IsPublic && m.Name == "FillAttributes");
        //    StringLengthAttribute attribute = new StringLengthAttribute(maximunLength);
        //    attribute.ErrorMessageResourceType = ErrorMessageResourceType;
        //    attribute.ErrorMessageResourceName = ErrorMessageResourceName;
        //    attribute.MinimumLength = minimumLength;
        //    var attributes = new ValidationAttribute[] { attribute };
        //    //var attributes = new ArrayList { attribute };
        //    //TypeDescriptor.AddAttributes(type, attributes);
        //    //methodInfo.Invoke(propDesc, new object[] { attributes });

        //    TypeDescriptor.CreateProperty(type, propertyName, typeof(string), attributes);

        //}
    }
}