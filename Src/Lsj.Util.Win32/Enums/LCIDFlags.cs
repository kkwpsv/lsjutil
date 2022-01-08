using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// LCID Flags
    /// </summary>
    [Flags]
    public enum LCIDFlags : uint
    {
        /// <summary>
        /// LCID_INSTALLED
        /// </summary>
        LCID_INSTALLED = 0x00000001,

        /// <summary>
        /// LCID_SUPPORTED
        /// </summary>
        LCID_SUPPORTED = 0x00000002,

        /// <summary>
        /// LCID_ALTERNATE_SORTS
        /// </summary>
        LCID_ALTERNATE_SORTS = 0x00000004,
    }
}
