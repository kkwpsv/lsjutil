using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Lsj.Util.CsBuilder
{
    /// <summary>
    /// Statemetn
    /// </summary>
    public abstract class Statement
    {
        internal static char BLANK = ' ';
        /// <summary>
        /// Convert To String
        /// </summary>
        /// <param name="i">Count of blank</param>
        /// <returns></returns>
        public abstract string ToString(int i);
    }
}
