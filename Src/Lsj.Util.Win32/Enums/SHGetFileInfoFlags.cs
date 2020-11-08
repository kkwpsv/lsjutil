using System;
using static Lsj.Util.Win32.Shell32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="SHGetFileInfo"/> Flags
    /// </summary>
    [Flags]
    public enum SHGetFileInfoFlags : uint
    {
        /// <summary>
        /// SHGFI_ICON
        /// </summary>
        SHGFI_ICON = 0x000000100,

        /// <summary>
        /// SHGFI_DISPLAYNAME
        /// </summary>
        SHGFI_DISPLAYNAME = 0x000000200,

        /// <summary>
        /// SHGFI_TYPENAME
        /// </summary>
        SHGFI_TYPENAME = 0x000000400,

        /// <summary>
        /// SHGFI_ATTRIBUTES
        /// </summary>
        SHGFI_ATTRIBUTES = 0x000000800,

        /// <summary>
        /// SHGFI_ICONLOCATION
        /// </summary>
        SHGFI_ICONLOCATION = 0x000001000,

        /// <summary>
        /// SHGFI_EXETYPE
        /// </summary>
        SHGFI_EXETYPE = 0x000002000,

        /// <summary>
        /// SHGFI_SYSICONINDEX
        /// </summary>
        SHGFI_SYSICONINDEX = 0x000004000,

        /// <summary>
        /// SHGFI_LINKOVERLAY
        /// </summary>
        SHGFI_LINKOVERLAY = 0x000008000,

        /// <summary>
        /// SHGFI_SELECTED
        /// </summary>
        SHGFI_SELECTED = 0x000010000,

        /// <summary>
        /// SHGFI_ATTR_SPECIFIED
        /// </summary>
        SHGFI_ATTR_SPECIFIED = 0x000020000,

        /// <summary>
        /// SHGFI_LARGEICON
        /// </summary>
        SHGFI_LARGEICON = 0x000000000,

        /// <summary>
        /// SHGFI_SMALLICON
        /// </summary>
        SHGFI_SMALLICON = 0x000000001,

        /// <summary>
        /// SHGFI_OPENICON
        /// </summary>
        SHGFI_OPENICON = 0x000000002,

        /// <summary>
        /// SHGFI_SHELLICONSIZE
        /// </summary>
        SHGFI_SHELLICONSIZE = 0x000000004,

        /// <summary>
        /// SHGFI_PIDL
        /// </summary>
        SHGFI_PIDL = 0x000000008,

        /// <summary>
        /// SHGFI_USEFILEATTRIBUTES
        /// </summary>
        SHGFI_USEFILEATTRIBUTES = 0x000000010,

        /// <summary>
        /// SHGFI_ADDOVERLAYS
        /// </summary>
        SHGFI_ADDOVERLAYS = 0x000000020,

        /// <summary>
        /// SHGFI_OVERLAYINDEX
        /// </summary>
        SHGFI_OVERLAYINDEX = 0x000000040,
    }
}
