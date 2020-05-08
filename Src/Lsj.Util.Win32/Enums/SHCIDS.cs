using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// SHCIDS
    /// </summary>
    public enum SHCIDS : uint
    {
        /// <summary>
        /// SHCIDS_ALLFIELDS
        /// </summary>
        SHCIDS_ALLFIELDS = 0x80000000,

        /// <summary>
        /// SHCIDS_CANONICALONLY
        /// </summary>
        SHCIDS_CANONICALONLY = 0x10000000,

        /// <summary>
        /// SHCIDS_BITMASK
        /// </summary>
        SHCIDS_BITMASK = 0xFFFF0000,

        /// <summary>
        /// SHCIDS_COLUMNMASK
        /// </summary>
        SHCIDS_COLUMNMASK = 0x0000FFFF,
    }
}
