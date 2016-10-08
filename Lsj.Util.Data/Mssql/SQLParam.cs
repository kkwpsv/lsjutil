using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Lsj.Util.Data.Mssql
{
    public struct SQLParam
    {
        public string name;
        public SqlDbType type;
        public object value;
    }
}
