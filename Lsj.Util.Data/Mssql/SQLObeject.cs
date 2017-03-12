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
    /// SQL对象
    /// </summary>
    public class SQLObeject : DisposableClass, IDisposable
    {
        /// <summary>
        /// 
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
        /// 通过<see cref="SqlConnection"/>来初始化一个SQL对象
        /// </summary>
        /// <param name="conn"></param>
        public SQLObeject(SqlConnection conn)
        {
            this.connection = conn;
            if (this.connection.State != ConnectionState.Open)
            {
                this.connection.Open();
            }
        }
        /// <summary>
        /// 通过SQL连接字符串来初始化一个SQL对象
        /// </summary>
        /// <param name="conn"></param>
        public SQLObeject(string conn)
        {
            this.connection = new SqlConnection(conn);
            this.connection.Open();
        }
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="name"></param>
        /// <returns>返回第一行第一列</returns>
        public object ExecProcedure(string name) => ExecProcedure(name, null);


        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="name"></param>
        /// <param name="para"></param>
        /// <returns>返回第一行第一列</returns>
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
        /// GetSqlDataReader
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public SqlDataReader GetSqlDataReader(string name) => GetSqlDataReader(name, null);

        /// <summary>
        /// GetSqlDataReader
        /// </summary>
        /// <param name="name"></param>
        /// <param name="para"></param>
        /// <returns></returns>
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
