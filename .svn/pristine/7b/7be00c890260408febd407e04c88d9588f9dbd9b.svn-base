using EasyTools.Framework.Persistance;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EasyTools.Framework.Application
{
    [DataContract(IsReference = true)]
    public class Configuration
    {
        private Dictionary<string,string> appSettings;

        [DataMember]
        public Dictionary<string, string> AppSettings
        {
            get
            {
                if (appSettings == null)
                    appSettings = new Dictionary<string, string>();
                return appSettings;
            }
            set
            {
                appSettings = value;
            }
        }

        private List<DatabaseSetting> dataBaseSettings;

        [DataMember]
        public List<DatabaseSetting> DataBaseSettings
        {
            get
            {
                if (dataBaseSettings == null)
                    dataBaseSettings = new List<DatabaseSetting>();
                return dataBaseSettings;
            }
            set
            {
                dataBaseSettings = value;
            }
        }

        public DatabaseSetting GetDatabaseSetting(string settingName)
        {
            DatabaseSetting setting = DataBaseSettings.Find(x => x.Name == settingName);
            if (setting == null)
                throw new ArgumentException("La configuración " + settingName + " no existe");
            return setting;
        }
    }
}