using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// IMPLTYPEFLAGS
    /// </summary>
    [Flags]
    public enum IMPLTYPEFLAGS
    {
        /// <summary>
        /// IMPLTYPEFLAG_FDEFAULT
        /// </summary>
        IMPLTYPEFLAG_FDEFAULT = 0x1,

        /// <summary>
        /// IMPLTYPEFLAG_FSOURCE
        /// </summary>
        IMPLTYPEFLAG_FSOURCE = 0x2,

        /// <summary>
        /// IMPLTYPEFLAG_FRESTRICTED
        /// </summary>
        IMPLTYPEFLAG_FRESTRICTED = 0x4,

        /// <summary>
        /// IMPLTYPEFLAG_FDEFAULTVTABLE
        /// </summary>
        IMPLTYPEFLAG_FDEFAULTVTABLE = 0x8,
    }
}
