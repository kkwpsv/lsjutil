using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Lsj.Util.Logs;

namespace Lsj.Util.Data.Mssql
{
    /// <summary>
    /// SQL Obeject.
    /// </summary>
    public class SQLObeject : DisposableClass, IDisposable
    {
        /// <summary>
        /// Cleans up managed resources.
        /// </summary>
        protected override void CleanUpManagedResources()
        {
            base.CleanUpManagedResources();
            if (this.connection != null && this.connection.State != ConnectionState.Closed)
            {
                this.connection.Close();
            }
        }



        SqlConnection connection;
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Data.Mssql.SQLObeject"/> class.
        /// </summary>
        /// <param name="conn">Conn.</param>
        public SQLObeject(SqlConnection conn)
        {
            this.connection = conn;
            if (this.connection.State != ConnectionState.Open)
            {
                this.connection.Open();
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Data.Mssql.SQLObeject"/> class.
        /// </summary>
        /// <param name="conn">Conn.</param>
        public SQLObeject(string conn)
        {
            this.connection = new SqlConnection(conn);
            this.connection.Open();
        }
        /// <summary>
        /// Execs the procedure.
        /// </summary>
        /// <param name="name">Name.</param>
        public object ExecProcedure(string name) => ExecProcedure(name, null);


        /// <summary>
        /// Execs the procedure.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="para">Para.</param>
        public object ExecProcedure(string name, params SQLParam[] para)
        {
            try
            {
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = name,
                    CommandType = CommandType.StoredProcedure,
                    Connection = this.connection
                };
                if (para != null)
                {
                    foreach (var a in para)
                    {
                        cmd.Parameters.Add(a.name, a.type);
                        cmd.Parameters[a.name].Value = a.value;
                    }
                }
                return cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                LogProvider.Default.Error(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the sql data reader.
        /// </summary>
        /// <returns>The sql data reader.</returns>
        /// <param name="name">Name.</param>
        public SqlDataReader GetSqlDataReader(string name) => GetSqlDataReader(name, null);

        /// <summary>
        /// Gets the sql data reader.
        /// </summary>
        /// <returns>The sql data reader.</returns>
        /// <param name="name">Name.</param>
        /// <param name="para">Para.</param>
        public SqlDataReader GetSqlDataReader(string name, params SQLParam[] para)
        {
            try
            {
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = name,
                    CommandType = CommandType.StoredProcedure,
                    Connection = this.connection
                };
                if (para != null)
                {
                    foreach (var a in para)
                    {
                        cmd.Parameters.Add(a.name, a.type);
                        cmd.Parameters[a.name].Value = a.value;
                    }
                }
                return cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                LogProvider.Default.Error(e);
                throw;
            }
        }

    }
}
