using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Lsj.Util.CsBuilder
{
    /// <summary>
    /// ClassMember
    /// </summary>
    public abstract class ClassMember
    {
        internal static char NULL = ' ';
        /// <summary>
        /// Convert To String
        /// </summary>
        /// <param name="i">Count of blank</param>
        /// <returns></returns>
        public abstract string ToString(int i);
    }
}
