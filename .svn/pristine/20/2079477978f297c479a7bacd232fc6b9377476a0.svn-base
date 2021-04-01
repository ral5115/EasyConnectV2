using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTools.Framework.Persistance
{
    public class DbFactory
    {

        private DBType dbType;

        private string connectionString;

        private string GetProvider()
        {
            if (dbType == DBType.SQLServer)
                return "System.Data.SqlClient";
            else if (dbType == DBType.Oracle)
                return "System.Data.OracleClient";
            else
                return "System.Data.SqlClient";
        }

        public DbFactory(DBType dbType, string connectionString)
        {
            this.dbType = dbType;
            this.connectionString = connectionString;

       }
    }
}
