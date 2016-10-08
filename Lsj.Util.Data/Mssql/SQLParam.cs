using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Lsj.Util.Data.Mssql
{
    /// <summary>
    /// SQL参数
    /// </summary>
    public struct SQLParam
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string name;
        /// <summary>
        /// 类型
        /// </summary>
        public SqlDbType type;
        /// <summary>
        /// 值
        /// </summary>
        public object value;
    }
}
