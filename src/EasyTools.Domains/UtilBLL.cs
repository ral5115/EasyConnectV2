using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Infrastructure.Entities;
using System;

namespace EasyTools.Domains
{
    public static class UtilBLL
    {
        public static String GetConnectionString(SECConnection conn)
        {
            string sPassword = Crypto.DecrytedString(conn.Password);

            string connectionString = "";
            if (conn.DbType == DBType.SQLServer.ToString())
            {
                string AdditionalOptions = "; Integrated Security = False; Persist Security Info = False; Enlist=False; Pooling=True; Min Pool Size=1; Max Pool Size=1000; MultipleActiveResultSets=True; Connect Timeout=15; User Instance=False";
                connectionString = "Data Source =" + conn.Service + "; Initial Catalog=" + conn.DB + "; User ID=" + conn.Login + "; Password=" + sPassword ;
                connectionString += AdditionalOptions;
            }
            else
            {
                connectionString = "Data Source=" + conn.Service + ";User ID=" + conn.Login + "; Password=" + sPassword + " ";
            }
            return connectionString;
        }

        public static DBType GetConnectionDBType(string dbType)
        {
            if (dbType == DBType.SQLServer.ToString())
                return DBType.SQLServer;
            if (dbType == DBType.Oracle.ToString())
                return DBType.Oracle;
            else
                return DBType.SQLServer;
        }


    }
}
