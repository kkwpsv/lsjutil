using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.LDB
{
    /// <summary>
    /// LDBFileConfig
    /// </summary>
    public class LDBFileConfig
    {
        /// <summary>
        /// Version
        /// </summary>
        public Version Version
        {
            get;
            internal set;
        } = new Version(1, 0);
        /// <summary>
        /// DBName
        /// </summary>
        public string DBName
        {
            get
            {
                return dbname;
            }
            set
            {
                var temp = value.ConvertToBytes(Encoding.UTF8);
                if (temp.Length > 28)
                {
                    throw new ArgumentException("DBName is too long");
                }
                else
                {
                    dbname = value;
                }
            }
        }
        string dbname;
    }
}
