using Lsj.Util.Win32.Structs;
using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="COMBOBOXEXITEM"/> Flags
    /// </summary>
    [Flags]
    public enum ComboxBoxExItemFlags : uint
    {
        /// <summary>
        /// CBEIF_TEXT
        /// </summary>
        CBEIF_TEXT = 0x00000001,

        /// <summary>
        /// CBEIF_IMAGE
        /// </summary>
        CBEIF_IMAGE = 0x00000002,

        /// <summary>
        /// CBEIF_SELECTEDIMAGE
        /// </summary>
        CBEIF_SELECTEDIMAGE = 0x00000004,

        /// <summary>
        /// CBEIF_OVERLAY
        /// </summary>
        CBEIF_OVERLAY = 0x00000008,

        /// <summary>
        /// CBEIF_INDENT
        /// </summary>
        CBEIF_INDENT = 0x00000010,

        /// <summary>
        /// CBEIF_LPARAM
        /// </summary>
        CBEIF_LPARAM = 0x00000020,

        /// <summary>
        /// CBEIF_DI_SETITEM
        /// </summary>
        CBEIF_DI_SETITEM = 0x10000000,
    }
}
