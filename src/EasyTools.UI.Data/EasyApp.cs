using EasyTools.Framework.Application;
using EasyTools.Framework.Composite;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Infrastructure.Entities;
using EasyTools.Infrastructure.Entities.Base;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.IO;

namespace EasyTools.UI.Data
{
    public class EasyApp : INotifyPropertyChanged
    {
        public EasyApp()
        {
        }

        public EasyApp Initialized()
        {
            if (Current != null)
            {
                ServiceUrl = Current.ServiceUrl;
                ListDatabaseSettings = Current.ListDatabaseSettings;
                DefaultDatabaseSetting = Current.DefaultDatabaseSetting;
                
                
            }
            return this;
        }

        #region Contants

        //Id de las listas para los tipos de base de datos
        public const int DbTypeKey = 2;

        #endregion

        #region Notificacion cambio de propiedades

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        #endregion

        #region Properties

        public String ServiceUrl { get; set; }

        private static EasyApp app;

        public static EasyApp Current
        {
            get
            {
                if (app == null)
                {
                    app = new EasyApp();
                    app.GetAvailablePermissions();
                }
                return app;
            }
        }

        private Configuration configuration;

        public Configuration Configuration
        {
            get
            {
                if (configuration == null)
                {
                    try
                    {
                        
                        configuration = XMLSerializer.ReadFileToDataContract<Configuration>(GetType().Assembly.Location.Substring(0, GetType().Assembly.Location.LastIndexOf("\\")) + @"\Configurations.xml");
                        
                        if (configuration.AppSettings["PasswordsAreEncrypted"] == "false" && configuration.AppSettings["PasswordsNeedBeEncrypted"] == "true")
                            if (configuration.DataBaseSettings.Count > 0)
                            {
                                foreach (DatabaseSetting item in configuration.DataBaseSettings)
                                {
                                    item.Password = Crypto.EncrytedString(item.Password);
                                }
                                configuration.AppSettings["PasswordsAreEncrypted"] = "true";
                                configuration.AppSettings["PasswordsNeedBeEncrypted"] = "false";
                                XMLSerializer.WriteDataContractToFile<Configuration>(configuration, "Configurations.xml");
                            }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                if (App.Current.Configuration == null)
                    App.AddCurrentConfiguration(configuration);
                return configuration;
            }
        }

        public IUnityContainer Container { get; set; }

        private SECUser user;

        public SECUser User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                NotifyPropertyChanged("User");
            }
        }

        private SECCompany company;

        public SECCompany Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
                NotifyPropertyChanged("Company");
            }
        }

        private BindingList<SECCompany> listCompanies;

        public BindingList<SECCompany> ListCompanies
        {
            get
            {
                return listCompanies;
            }
            set
            {
                listCompanies = value;
                NotifyPropertyChanged("ListCompanies");
            }
        }


        public DatabaseSetting DefaultDatabaseSetting { get; set; }

        public string DefaultDatabaseSettingName
        {
            get
            {
                return DefaultDatabaseSetting != null ? DefaultDatabaseSetting.Name : "";
            }
        }


        private BindingList<DatabaseSetting> listDatabaseSettings;

        public BindingList<DatabaseSetting> ListDatabaseSettings
        {
            get
            {
                return listDatabaseSettings;
            }
            set
            {
                listDatabaseSettings = value;
                NotifyPropertyChanged("ListDatabaseSettings");
            }
        }

        public ToolsServiceClient eToolsServer()
        {
            try
            {
                return new ToolsServiceClient();
            }
           
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Listas de Valores

        private BindingList<CONEquivalenceDetail> listEquivalenceDetails;

        public BindingList<CONEquivalenceDetail> ListEquivalenceDetails
        {
            get
            {
                return listEquivalenceDetails;
            }
            set
            {
                listEquivalenceDetails = value;
                NotifyPropertyChanged("ListEquivalenceDetails");
            }
        }

        private BindingList<CONEquivalence> listEquivalences;

        public BindingList<CONEquivalence> ListEquivalences
        {
            get
            {
                return listEquivalences;
            }
            set
            {
                listEquivalences = value;
                NotifyPropertyChanged("ListEquivalences");
            }
        }

        private BindingList<CONError> listErrors;

        public BindingList<CONError> ListErrors
        {
            get
            {
                return listErrors;
            }
            set
            {
                listErrors = value;
                NotifyPropertyChanged("ListErrors");
            }
        }

        private BindingList<CONIntegratorConfiguration> listIntegratorConfigurations;

        public BindingList<CONIntegratorConfiguration> ListIntegratorConfigurations
        {
            get
            {
                return listIntegratorConfigurations;
            }
            set
            {
                listIntegratorConfigurations = value;
                NotifyPropertyChanged("ListIntegratorConfigurations");
            }
        }

        private BindingList<CONIntegrator> listIntegrators;

        public BindingList<CONIntegrator> ListIntegrators
        {
            get
            {
                return listIntegrators;
            }
            set
            {
                listIntegrators = value;
                NotifyPropertyChanged("ListIntegrators");
            }
        }

        private BindingList<CONRecordDetail> listRecordDetails;

        public BindingList<CONRecordDetail> ListRecordDetails
        {
            get
            {
                return listRecordDetails;
            }
            set
            {
                listRecordDetails = value;
                NotifyPropertyChanged("ListRecordDetails");
            }
        }

        private BindingList<CONRecord> listRecords;

        public BindingList<CONRecord> ListRecords
        {
            get
            {
                return listRecords;
            }
            set
            {
                listRecords = value;
                NotifyPropertyChanged("ListRecords");
            }
        }

        private BindingList<CONSQLDetail> listSQLDetails;

        public BindingList<CONSQLDetail> ListSQLDetails
        {
            get
            {
                return listSQLDetails;
            }
            set
            {
                listSQLDetails = value;
                NotifyPropertyChanged("ListSQLDetails");
            }
        }

        private BindingList<CONSQLParameter> listSQLParameters;

        public BindingList<CONSQLParameter> ListSQLParameters
        {
            get
            {
                return listSQLParameters;
            }
            set
            {
                listSQLParameters = value;
                NotifyPropertyChanged("ListSQLParameters");
            }
        }

        private BindingList<CONSQL> listSQLs;

        public BindingList<CONSQL> ListSQLs
        {
            get
            {
                return listSQLs;
            }
            set
            {
                listSQLs = value;
                NotifyPropertyChanged("ListSQLs");
            }
        }

        private BindingList<CONSQLSend> listSQLSends;

        public BindingList<CONSQLSend> ListSQLSends
        {
            get
            {
                return listSQLSends;
            }
            set
            {
                listSQLSends = value;
                NotifyPropertyChanged("ListSQLSends");
            }
        }

        private BindingList<CONStructureAssociation> listStructureAssociations;

        public BindingList<CONStructureAssociation> ListStructureAssociations
        {
            get
            {
                return listStructureAssociations;
            }
            set
            {
                listStructureAssociations = value;
                NotifyPropertyChanged("ListStructureAssociations");
            }
        }

        private BindingList<CONStructureDetail> listStructureDetails;

        public BindingList<CONStructureDetail> ListStructureDetails
        {
            get
            {
                return listStructureDetails;
            }
            set
            {
                listStructureDetails = value;
                NotifyPropertyChanged("ListStructureDetails");
            }
        }

        private BindingList<CONStructure> listStructures;

        public BindingList<CONStructure> ListStructures
        {
            get
            {
                return listStructures;
            }
            set
            {
                listStructures = value;
                NotifyPropertyChanged("ListStructures");
            }
        }

        private BindingList<CONStructure> listChildStructures;

        public BindingList<CONStructure> ListChildStructures
        {
            get
            {
                return listChildStructures;
            }
            set
            {
                listChildStructures = value;
                NotifyPropertyChanged("ListChildStructures");
            }
        }

        private BindingList<SECConnection> listConnections;

        public BindingList<SECConnection> ListConnections
        {
            get
            {
                return listConnections;
            }
            set
            {
                listConnections = value;
                NotifyPropertyChanged("ListConnections");
            }
        }

        private BindingList<SECConnection> listSQLConnections;

        public BindingList<SECConnection> ListSQLConnections
        {
            get
            {
                return listSQLConnections;
            }
            set
            {
                listSQLConnections = value;
                NotifyPropertyChanged("ListSQLConnections");
            }
        }

        private BindingList<SECConnection> listORCLConnections;

        public BindingList<SECConnection> ListORCLConnections
        {
            get
            {
                return listORCLConnections;
            }
            set
            {
                listORCLConnections = value;
                NotifyPropertyChanged("ListORCLConnections");
            }
        }

        private BindingList<SECRolePermission> listRolePermissions;

        public BindingList<SECRolePermission> ListRolePermissions
        {
            get
            {
                return listRolePermissions;
            }
            set
            {
                listRolePermissions = value;
                NotifyPropertyChanged("ListRolePermissions");
            }
        }

        private BindingList<SECRole> listRoles;

        public BindingList<SECRole> ListRoles
        {
            get
            {
                return listRoles;
            }
            set
            {
                listRoles = value;
                NotifyPropertyChanged("ListRoles");
            }
        }

        private BindingList<SECUserCompany> listUserCompanies;

        public BindingList<SECUserCompany> ListUserCompanies
        {
            get
            {
                return listUserCompanies;
            }
            set
            {
                listUserCompanies = value;
                NotifyPropertyChanged("ListUserCompanies");
            }
        }

        private BindingList<SECUser> listUsers;

        public BindingList<SECUser> ListUsers
        {
            get
            {
                return listUsers;
            }
            set
            {
                listUsers = value;
                NotifyPropertyChanged("ListUsers");
            }
        }

        private BindingList<MenuModel> listMenuModels;

        public BindingList<MenuModel> ListMenuModels
        {
            get
            {
                if (listMenuModels == null)
                    listMenuModels = new BindingList<MenuModel>();
                return listMenuModels;
            }
            set
            {
                listMenuModels = value;
                NotifyPropertyChanged("ListMenuModels");
            }
        }

        private BindingList<OptionValue> listDefaultDateValues;

        public BindingList<OptionValue> ListDefaultDateValues
        {
            get
            {
                if (listDefaultDateValues == null)
                {
                    listDefaultDateValues = new BindingList<OptionValue>();
                    listDefaultDateValues.Add(new OptionValue { Int32Value = 1, Code = "1", Name = "Hoy" });
                    listDefaultDateValues.Add(new OptionValue { Int32Value = 2, Code = "2", Name = "Ayer" });
                    listDefaultDateValues.Add(new OptionValue { Int32Value = 3, Code = "3", Name = "Primer Dia de la Semana" });
                    listDefaultDateValues.Add(new OptionValue { Int32Value = 4, Code = "4", Name = "Primer Dia del Mes" });
                    listDefaultDateValues.Add(new OptionValue { Int32Value = 5, Code = "5", Name = "Ultimo Dia del Mes" });
                    listDefaultDateValues.Add(new OptionValue { Int32Value = 6, Code = "6", Name = "Primer Dia del Mes Anterior" });
                    listDefaultDateValues.Add(new OptionValue { Int32Value = 7, Code = "7", Name = "Ultimo Dia del Mes Anterior" });
                }
                return listDefaultDateValues;
            }
            set
            {
                listDefaultDateValues = value;
                NotifyPropertyChanged("ListDefaultDateValues");
            }
        }

        private BindingList<string> listDBTypes;

        public BindingList<string> ListDBTypes
        {
            get
            {
                return listDBTypes;
            }
            set
            {
                listDBTypes = value;
                NotifyPropertyChanged("ListDBTypes");
            }
        }

        private BindingList<KeyValue> listExportTypes;

        public BindingList<KeyValue> ListExportTypes
        {
            get
            {
                if (listExportTypes == null)
                {
                    listExportTypes = new BindingList<KeyValue>();
                    listExportTypes.Add(new KeyValue { Key = "UNO", Value = "Siesa Enterprise" });
                    listExportTypes.Add(new KeyValue { Key = "TXT", Value = "Archivo Plano" });
                    listExportTypes.Add(new KeyValue { Key = "XML", Value = "Archivo XML" });
                }
                return listExportTypes;
            }
            set { listExportTypes = value; }
        }


        #endregion

        #region Metodos
        public BindingList<CONEquivalence> GetEquivalences()
        {
            ListEquivalences = new BindingList<CONEquivalence>(((CONEquivalence) eToolsServer().Execute(new CONEquivalence { Active = true, Company = Current.Company }, Actions.Find, Options.Light, DefaultDatabaseSettingName, "")).Entities);
            return ListEquivalences;
        }
        
        public void GetDBTypes()
        {
            ListDBTypes = new BindingList<string>();
            ListDBTypes.Add(DBType.SQLServer.ToString());
            ListDBTypes.Add(DBType.Oracle.ToString());
        }

        public async void GetIntegrators()
        {
            ListIntegrators = new BindingList<CONIntegrator>(((CONIntegrator)await eToolsServer().ExecuteAsync(new CONIntegrator(), Actions.Find, Options.All, DefaultDatabaseSettingName, "")).Entities);
        }

        public async void GetRoles()
        {
            ListRoles = new BindingList<SECRole>(((SECRole)await eToolsServer().ExecuteAsync(new SECRole(), Actions.Find, Options.All, DefaultDatabaseSettingName, "")).Entities);
        }


        public void GetConnections()
        {
            ListConnections = new BindingList<SECConnection>(((SECConnection)eToolsServer().Execute(new SECConnection { Active = true, CompanyId = Current.Company.Id }, Actions.Find, Options.All, DefaultDatabaseSettingName, "")).Entities);
        }

        public BindingList<CONStructure> GetMainStructures()
        {
            return new BindingList<CONStructure>(((CONStructure)eToolsServer().Execute(new CONStructure { Active = true, Main = true }, Actions.Find, Options.Light, DefaultDatabaseSettingName, "")).Entities);
        }

        public BindingList<CONStructure> GetChildStructures(CONStructure structure)
        {
            return new BindingList<CONStructure>(((CONStructureAssociation)eToolsServer().Execute(new CONStructureAssociation { MainStructure = structure }, Actions.Find, Options.All, DefaultDatabaseSettingName, "")).Entities.Select(x => x.ChildStructure).ToList<CONStructure>());
        }

        public BindingList<CONStructureDetail> GetStructureDetails(CONStructure structure)
        {
            return new BindingList<CONStructureDetail>(((CONStructureDetail)eToolsServer().Execute(new CONStructureDetail { Structure = structure }, Actions.Find, Options.Light, DefaultDatabaseSettingName, "")).Entities);
        }

        #endregion

        #region Security

        public BindingList<Permission> AvailablePermissions { get; private set; }

        private void GetAvailablePermissions()
        {
            AvailablePermissions = new BindingList<Permission>();
            AvailablePermissions.Add(new Permission { Id = 1, Description = "Save", EsDescripcion = "Guardar", EnDescription = "Save" });
            AvailablePermissions.Add(new Permission { Id = 2, Description = "Update", EsDescripcion = "Modificar", EnDescription = "Update" });
            AvailablePermissions.Add(new Permission { Id = 3, Description = "Delete", EsDescripcion = "Eliminar", EnDescription = "Delete" });
            AvailablePermissions.Add(new Permission { Id = 4, Description = "Query", EsDescripcion = "Consultar", EnDescription = "Query" });
        }

        public Permission GetPermission(int id)
        {
            if (AvailablePermissions == null)
                GetAvailablePermissions();
            return AvailablePermissions.FirstOrDefault(x => x.Id == id);
        }

        #endregion
    }
}