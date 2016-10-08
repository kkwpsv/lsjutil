using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Data.LDB
{
    /// <summary>
    /// LDBTable
    /// </summary>
    public class LDBTable
    {
        private int length;
        private long position;
        private LDBFile ldb;
        /// <summary>
        /// LDBTable
        /// </summary>
        /// <param name="position"></param>
        /// <param name="length"></param>
        public LDBTable(long position, int length, LDBFile ldb)
        {
            this.position = position;
            this.length = length;
            this.ldb = ldb;

        }
        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get;
            private set;
        }
    }
}
