using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Lsj.Util.Data.Mssql
{
    /// <summary>
    /// SQL Param
    /// </summary>
    public struct SQLParam
    {
        /// <summary>
        /// Name
        /// </summary>
        public string name;
        /// <summary>
        /// Type
        /// </summary>
        public SqlDbType type;
        /// <summary>
        /// Value
        /// </summary>
        public object value;
    }
}
