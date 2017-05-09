using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Lsj.Util.Data.Mssql
{
    /// <summary>
    /// SQL Param.
    /// </summary>
    public struct SQLParam
    {
        /// <summary>
        /// The name.
        /// </summary>
        public string name;
        /// <summary>
        /// The type.
        /// </summary>
        public SqlDbType type;
        /// <summary>
        /// The value.
        /// </summary>
        public object value;
    }
}
