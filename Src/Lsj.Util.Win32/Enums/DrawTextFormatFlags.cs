using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Draw text format flags
    /// </summary>
    [Flags]
    public enum DrawTextFormatFlags : uint
    {
        /// <summary>
        /// DT_TOP
        /// </summary>
        DT_TOP = 0x00000000,

        /// <summary>
        /// DT_LEFT
        /// </summary>
        DT_LEFT = 0x00000000,

        /// <summary>
        /// DT_CENTER
        /// </summary>
        DT_CENTER = 0x00000001,

        /// <summary>
        /// DT_RIGHT
        /// </summary>
        DT_RIGHT = 0x00000002,

        /// <summary>
        /// DT_VCENTER
        /// </summary>
        DT_VCENTER = 0x00000004,

        /// <summary>
        /// DT_BOTTOM
        /// </summary>
        DT_BOTTOM = 0x00000008,

        /// <summary>
        /// DT_WORDBREAK
        /// </summary>
        DT_WORDBREAK = 0x00000010,

        /// <summary>
        /// DT_SINGLELINE
        /// </summary>
        DT_SINGLELINE = 0x00000020,

        /// <summary>
        /// DT_EXPANDTABS
        /// </summary>
        DT_EXPANDTABS = 0x00000040,

        /// <summary>
        /// DT_TABSTOP
        /// </summary>
        DT_TABSTOP = 0x00000080,

        /// <summary>
        /// DT_NOCLIP
        /// </summary>
        DT_NOCLIP = 0x00000100,

        /// <summary>
        /// DT_EXTERNALLEADING
        /// </summary>
        DT_EXTERNALLEADING = 0x00000200,

        /// <summary>
        /// DT_CALCRECT
        /// </summary>
        DT_CALCRECT = 0x00000400,

        /// <summary>
        /// DT_NOPREFIX
        /// </summary>
        DT_NOPREFIX = 0x00000800,

        /// <summary>
        /// DT_INTERNAL
        /// </summary>
        DT_INTERNAL = 0x00001000,

        /// <summary>
        /// DT_EDITCONTROL
        /// </summary>
        DT_EDITCONTROL = 0x00002000,

        /// <summary>
        /// DT_PATH_ELLIPSIS
        /// </summary>
        DT_PATH_ELLIPSIS = 0x00004000,

        /// <summary>
        /// DT_END_ELLIPSIS
        /// </summary>
        DT_END_ELLIPSIS = 0x00008000,

        /// <summary>
        /// DT_MODIFYSTRING
        /// </summary>
        DT_MODIFYSTRING = 0x00010000,

        /// <summary>
        /// DT_RTLREADING
        /// </summary>
        DT_RTLREADING = 0x00020000,

        /// <summary>
        /// DT_WORD_ELLIPSIS
        /// </summary>
        DT_WORD_ELLIPSIS = 0x00040000,

        /// <summary>
        /// DT_NOFULLWIDTHCHARBREAK
        /// </summary>
        DT_NOFULLWIDTHCHARBREAK = 0x00080000,

        /// <summary>
        /// DT_HIDEPREFIX
        /// </summary>
        DT_HIDEPREFIX = 0x00100000,

        /// <summary>
        /// DT_PREFIXONLY
        /// </summary>
        DT_PREFIXONLY = 0x00200000,
    }
}
