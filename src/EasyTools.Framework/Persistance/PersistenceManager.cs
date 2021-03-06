using EasyTools.Framework.Application;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;

namespace EasyTools.Framework.Persistance
{
    public class PersistenceManager
    {
        protected static Dictionary<String, DatabaseContext> sesionFactories;

        //private static List<string> connectionStrings = new List<string>();

        private static Dictionary<string, string> dconnectionStrings = new Dictionary<string, string>();

        static PersistenceManager()
        {
            try
            {
                sesionFactories = new Dictionary<String, DatabaseContext>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Boolean IsValidSession(String sessionName)
        {
            return sesionFactories.ContainsKey(sessionName);
        }

        public static ISession GetCurrentSession(String session)
        {
            return sesionFactories[session].SessionFactory.OpenSession();
        }

        public static void CloseSessionFactory(String session)
        {
            sesionFactories[session].SessionFactory.Close();
        }

        public static void SetConfigure(DatabaseSetting confg)
        {
            try
            {
                DatabaseContext context = new DatabaseContext(confg);
                if (confg.DBType == DBType.SQLServer)
                {
                    context.SessionFactory = Fluently.Configure().Database(MsSqlConfiguration.MsSql2008.ConnectionString(confg.ConnectionString))
                                             .Mappings(m =>
                                             {
                                                 if (confg.Types.Count > 0)
                                                     foreach (Type item in confg.Types)
                                                         m.FluentMappings.Add(item);
                                             }).BuildSessionFactory();
                    sesionFactories.Add(confg.Name, context);
                }
                else if (confg.DBType == DBType.Oracle)
                {
                    context.SessionFactory = Fluently.Configure().Database(OracleDataClientConfiguration.Oracle10.ConnectionString(confg.ConnectionString))
                                             .Mappings(m =>
                                             {
                                                 if (confg.Types.Count > 0)
                                                     foreach (Type item in confg.Types)
                                                         m.FluentMappings.Add(item);
                                             }).BuildSessionFactory();
                    sesionFactories.Add(confg.Name, context);
                }
                if (!dconnectionStrings.ContainsKey(confg.GetConnectionStringWithOutPassword()))
                    dconnectionStrings.Add(confg.GetConnectionStringWithOutPassword(), confg.ConnectionString);
            }
            catch (Exception e)
            {
                throw new BusinessException(e).GetFaultException();
            }
        }

        public static string GetConnecttionString(string partConne)
        {
            string conn = "";
            foreach (string item in dconnectionStrings.Keys)
            {
                if (item.Contains(partConne))
                    conn = dconnectionStrings[item];

            }
            return conn;
        }
    }
}