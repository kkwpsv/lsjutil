using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Lsj.Util.Logs;

namespace Lsj.Util.Data.Mssql
{
    public class SQLObeject : DisposableClass, IDisposable
    {
        protected override void CleanUpManagedResources()
        {
            base.CleanUpManagedResources();
            if (this.connection != null && this.connection.State != ConnectionState.Closed)
            {
                this.connection.Close();
            }
        }



        SqlConnection connection;
        public SQLObeject(SqlConnection conn)
        {
            this.connection = conn;
            if (this.connection.State != ConnectionState.Open)
            {
                this.connection.Open();
            }
        }
        public SQLObeject(string conn)
        {
            this.connection = new SqlConnection(conn);
            this.connection.Open();
        }
        public object ExecProcedure(string name, params SQLParam[] para)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = name;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = this.connection;
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
                return null;
            }
        }
    }
}
