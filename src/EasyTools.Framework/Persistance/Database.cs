using EasyTools.Framework.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace EasyTools.Framework.Persistance
{
    public class Database
    {
        private readonly string connectionString;

        private DBType dbType;

        public Database(string connectionString, DBType dbType)
        {
            if (string.IsNullOrEmpty(connectionString)) throw new ArgumentException("connectionString");

            this.connectionString = connectionString;
            this.dbType = dbType;
        }

        public DbConnection CreateConnection()
        {
            DbConnection connection = DbProviderFactories.GetFactory(GetProvider()).CreateConnection();
            connection.ConnectionString = connectionString;
            return connection;
        }

        public DbTransaction CreateTransaction(DbConnection connection)
        {
            return connection.BeginTransaction();
        }

        public void ExecuteNonQuery(Dictionary<string, List<SQLParameter>> parameters)
        {
            using (DbConnection connection = CreateConnection())
            {
                try
                {
                    connection.Open();
                    using (DbTransaction transaction = CreateTransaction(connection))
                    {
                        try
                        {
                            foreach (string sql in parameters.Keys)
                                ExecuteNonQuery(transaction, CommandType.Text, sql, parameters[sql]);
                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            if (transaction != null)
                                transaction.Rollback();
                            throw;
                        }
                    }
                }
                catch (Exception)
                {
                    if (connection != null && connection.State != ConnectionState.Closed)
                        connection.Close();
                    throw;
                }
            }
        }

        public void ExecuteNonQuery(string sqlSentence, List<SQLParameter> parameters)
        {
            using (DbConnection connection = CreateConnection())
            {
                try
                {
                    connection.Open();
                    using (DbTransaction transaction = CreateTransaction(connection))
                    {
                        try
                        {
                            ExecuteNonQuery(transaction, CommandType.Text, sqlSentence, parameters);
                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            if (transaction != null)
                                transaction.Rollback();
                            throw;
                        }
                    }
                }
                catch (Exception)
                {
                    if (connection != null && connection.State != ConnectionState.Closed)
                        connection.Close();
                    throw;
                }
            }
        }

        public Dictionary<string, object> ExecuteStoreProcedure(string sqlSentence, List<SQLParameter> parameters)
        {
            Dictionary<string, object> outParm = new Dictionary<string, object>();

            using (DbConnection connection = CreateConnection())
            {
                try
                {
                    connection.Open();
                    using (DbTransaction transaction = CreateTransaction(connection))
                    {
                        try
                        {
                            outParm = ExecuteNonQuery(transaction, CommandType.StoredProcedure, sqlSentence, parameters);
                            transaction.Commit();

                        }
                        catch (Exception)
                        {
                            if (transaction != null)
                                transaction.Rollback();
                            throw;
                        }
                    }
                }
                catch (Exception)
                {
                    if (connection != null && connection.State != ConnectionState.Closed)
                        connection.Close();
                    throw;
                }
            }
            return outParm;
        }

        public ResultList ExecuteQuery(string sqlSentence, List<SQLParameter> parameters)
        {
            return ExecuteQuery(sqlSentence, parameters, 0);
        }

        public ResultList ExecuteQuery(string sqlSentence, List<SQLParameter> parameters, int recordNumber)
        {
            DbDataReader dataReader = null;
            ResultList result = null;

            using (DbConnection connection = CreateConnection())
            {
                try
                {
                    connection.Open();
                    dataReader = ExecuteReader(connection, sqlSentence, parameters);
                    result = new ResultList(dataReader, recordNumber);
                }
                catch (Exception)
                {
                    if (dataReader != null && !dataReader.IsClosed)
                        dataReader.Close();
                    if (connection != null && connection.State != ConnectionState.Closed)
                        connection.Close();
                    throw;
                }
                finally
                {
                    if (dataReader != null && !dataReader.IsClosed)
                        dataReader.Close();
                    if (connection != null && connection.State != System.Data.ConnectionState.Closed)
                        connection.Close();
                }
            }
            return result;
        }

        public ResultList ExecuteQuery(string sqlSentence)
        {
            DbDataReader dataReader = null;
            ResultList result = null;

            using (DbConnection connection = CreateConnection())
            {
                try
                {
                    connection.Open();
                    dataReader = ExecuteReader(connection, sqlSentence, null);
                    result = new ResultList(dataReader);
                }
                catch (Exception)
                {
                    if (dataReader != null && !dataReader.IsClosed)
                        dataReader.Close();
                    if (connection != null && connection.State != ConnectionState.Closed)
                        connection.Close();
                    throw;
                }
                finally
                {
                    if (dataReader != null && !dataReader.IsClosed)
                        dataReader.Close();
                    if (connection != null && connection.State != System.Data.ConnectionState.Closed)
                        connection.Close();
                }
            }
            return result;
        }

        #region Private Methods

        private DbDataReader ExecuteReader(DbConnection connection, string sqlSentence, List<SQLParameter> parameters)
        {
            DbCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandTimeout = 0;
            command.CommandText = sqlSentence;
            if (parameters != null && parameters.Count > 0)
                AddParameters(command, parameters, dbType);
            return command.ExecuteReader();
        }

        private Dictionary<string, object> ExecuteNonQuery(DbTransaction transaction, CommandType commandType, string sqlSentence, List<SQLParameter> parameters)
        {
            DbCommand command = transaction.Connection.CreateCommand();
            command.CommandType = commandType;
            command.Transaction = transaction;
            command.CommandTimeout = 0;
            command.CommandText = sqlSentence;
            Dictionary<string, object> outParams = new Dictionary<string,object>();
            if (parameters != null && parameters.Count > 0)
                AddParameters(command, parameters, dbType);
            command.ExecuteNonQuery();
            for (int i = 0; i < command.Parameters.Count; i++)
			{
			 if(command.Parameters[i].Direction == ParameterDirection.InputOutput || command.Parameters[i].Direction == ParameterDirection.Output)
                 outParams.Add(command.Parameters[i].ParameterName, command.Parameters[i].Value);
			}
            return outParams;
        }

        private string GetProvider()
        {
            if (dbType == DBType.SQLServer)
                return "System.Data.SqlClient";
            else if (dbType == DBType.Oracle)
                return "System.Data.OracleClient";
            else if (dbType == DBType.PostgreSQL)
                return "Npgsql";
            else if (dbType == DBType.MySQL)
                return "MySql.Data.MySqlClient";
            else
                return "System.Data.SqlClient";

        }

        private DateTime GetDateValue(Int16? data)
        {
            if (data == 1)
            {
                //Hoy
                return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            }
            else if (data == 2)
            {
                //Ayer
                return new DateTime(DateTime.Now.AddDays(-1).Year, DateTime.Now.AddDays(-1).Month, DateTime.Now.AddDays(-1).Day);
            }
            else if (data == 3)
            {
                //Primer dia de la semana
                DateTime date = DateTime.Now;
                date = date.AddDays(1 - Convert.ToDouble(date.DayOfWeek));
                return new DateTime(date.Year, date.Month, date.Day);
            }
            else if (data == 4)
            {
                //Primer dia del mes
                return new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            }
            else if (data == 5)
            {
                //Ultimo dia del mes
                return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            }
            else if (data == 6)
            {
                //Primer dia del mes anterior
                return new DateTime(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month, 1);
            }
            else if (data == 7)
            {
                //Ultimo dia del mes anterior
                return new DateTime(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month, DateTime.DaysInMonth(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month));
            }
            else
                return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }

        private void AddParameters(DbCommand command, List<SQLParameter> parameters, DBType type)
        {
            foreach (var item in parameters)
            {
                DbParameter param = command.CreateParameter();
                if (type == DBType.Oracle)
                    param.ParameterName = item.Name.Replace("@", "");
                else
                    param.ParameterName = item.Name;
                if (item.IsDate)
                {
                    param.DbType = DbType.Date;
                    if (item.DateValue != null)
                        param.Value = item.DateValue;
                    else
                        param.Value = GetDateValue(item.DefaultDateValue);
                }
                else if (item.IsInt)
                {
                    param.DbType = DbType.Int32;
                    param.Value = item.Int32Value;
                }
                else if (item.IsString)
                {
                    param.DbType = DbType.String;
                    param.Value = item.StringValue;
                }
                if (item.Direction == ParameterDirection.Output.ToString())
                    param.Direction = ParameterDirection.Output;
                command.Parameters.Add(param);

            }
        }

        #endregion

    }

}