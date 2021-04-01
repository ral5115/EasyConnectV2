using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EasyTools.Framework.Persistance
{
    [DataContract(IsReference = true)]
    public class DatabaseSetting
    {
        [DataMember]
        public Boolean Default { get; set; }

        [DataMember]
        public String Name { get; set; }

        [DataMember]
        public DBType DBType { get; set; }

        [DataMember]
        public String Server { get; set; }

        [DataMember]
        public String DbName { get; set; }

        [DataMember]
        public String UserName { get; set; }

        [DataMember]
        public String Password { get; set; }

        public String AdditionalOptions { get; set; }
        
        private String connectionString;

        public String ConnectionString
        {
            get
            {
                //string sPassword = App.Current.Configuration.AppSettings["PasswordsAreEncrypted"] == "true" ? Crypto.DecrytedString(Password) : Password;
                //AdditionalOptions = "; Integrated Security = False; Persist Security Info = False; Enlist=False; Pooling=True; Min Pool Size=1; Max Pool Size=100; MultipleActiveResultSets=True; Connect Timeout=15; User Instance=False";
                //connectionString = "Data Source =" + Server + "; Initial Catalog=" + DbName + "; User ID=" + UserName + "; Password=" + sPassword + " ";
                //connectionString += AdditionalOptions;
                //return connectionString;
                string sPassword = App.Current.Configuration.AppSettings["PasswordsAreEncrypted"] == "true" ? Crypto.DecrytedString(Password) : Password;
                if (DBType == DBType.SQLServer)
                {
                    AdditionalOptions = "; Integrated Security = False; Persist Security Info = False; Enlist=False; Pooling=True; Min Pool Size=5; Max Pool Size=1000; MultipleActiveResultSets=True; Connect Timeout=600; User Instance=False";
                    connectionString = "Data Source =" + Server + "; Initial Catalog=" + DbName + "; User ID=" + UserName + "; Password=" + sPassword + " ";
                    connectionString += AdditionalOptions;
                }
                else if (DBType == DBType.Oracle)
                {
                    connectionString = "Data Source=" + Server + ";User ID=" + UserName + "; Password=" + sPassword + " ";
                }
                return connectionString;
            }
        }

        public string GetConnectionStringWithOutPassword()
        {
            string sPassword = App.Current.Configuration.AppSettings["PasswordsAreEncrypted"] == "true" ? Crypto.DecrytedString(Password) : Password;
            return ConnectionString.Replace("; Password=" + sPassword + " ", "");
        }

        [DataMember]
        public String Language { get; set; }

        private List<Type> types;

        public List<Type> Types
        {
            get
            {
                if (types == null)
                    types = new List<Type>();
                return types;
            }
            set
            {
                types = value;
            }
        }
    }
}