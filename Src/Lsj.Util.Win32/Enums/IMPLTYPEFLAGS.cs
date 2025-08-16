using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Specifies implementation type flags.
    /// </para>
    /// </summary>
    [Flags]
    public enum IMPLTYPEFLAGS
    {
        /// <summary>
        /// The interface or dispinterface represents the default for the source or sink.
        /// </summary>
        IMPLTYPEFLAG_FDEFAULT = 0x1,

        /// <summary>
        /// This member of a coclass is called rather than implemented.
        /// </summary>
        IMPLTYPEFLAG_FSOURCE = 0x2,

        /// <summary>
        /// The member should not be displayed or programmable by users.
        /// </summary>
        IMPLTYPEFLAG_FRESTRICTED = 0x4,

        /// <summary>
        /// Sinks receive events through the VTBL.
        /// </summary>
        IMPLTYPEFLAG_FDEFAULTVTABLE = 0x8,
    }
}
