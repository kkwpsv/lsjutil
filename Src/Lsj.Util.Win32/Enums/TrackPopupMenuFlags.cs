using System;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="TrackPopupMenu"/> flags
    /// </summary>
    [Flags]
    public enum TrackPopupMenuFlags : uint
    {
        /// <summary>
        /// TPM_LEFTBUTTON
        /// </summary>
        TPM_LEFTBUTTON = 0x0000,

        /// <summary>
        /// TPM_RIGHTBUTTON
        /// </summary>
        TPM_RIGHTBUTTON = 0x0002,

        /// <summary>
        /// TPM_LEFTALIGN
        /// </summary>
        TPM_LEFTALIGN = 0x0000,

        /// <summary>
        /// TPM_CENTERALIGN
        /// </summary>
        TPM_CENTERALIGN = 0x0004,

        /// <summary>
        /// TPM_RIGHTALIGN
        /// </summary>
        TPM_RIGHTALIGN = 0x0008,

        /// <summary>
        /// TPM_TOPALIGN
        /// </summary>
        TPM_TOPALIGN = 0x0000,

        /// <summary>
        /// TPM_VCENTERALIGN
        /// </summary>
        TPM_VCENTERALIGN = 0x0010,

        /// <summary>
        /// TPM_BOTTOMALIGN
        /// </summary>
        TPM_BOTTOMALIGN = 0x0020,

        /// <summary>
        /// TPM_HORIZONTAL
        /// </summary>
        TPM_HORIZONTAL = 0x0000,

        /// <summary>
        /// TPM_VERTICAL
        /// </summary>
        TPM_VERTICAL = 0x0040,

        /// <summary>
        /// TPM_NONOTIFY
        /// </summary>
        TPM_NONOTIFY = 0x0080,

        /// <summary>
        /// TPM_RETURNCMD
        /// </summary>
        TPM_RETURNCMD = 0x0100,

        /// <summary>
        /// TPM_RECURSE
        /// </summary>
        TPM_RECURSE = 0x0001,

        /// <summary>
        /// TPM_HORPOSANIMATION
        /// </summary>
        TPM_HORPOSANIMATION = 0x0400,

        /// <summary>
        /// TPM_HORNEGANIMATION
        /// </summary>
        TPM_HORNEGANIMATION = 0x0800,

        /// <summary>
        /// TPM_VERPOSANIMATION
        /// </summary>
        TPM_VERPOSANIMATION = 0x1000,

        /// <summary>
        /// TPM_VERNEGANIMATION
        /// </summary>
        TPM_VERNEGANIMATION = 0x2000,

        /// <summary>
        /// TPM_NOANIMATION
        /// </summary>
        TPM_NOANIMATION = 0x4000,

        /// <summary>
        /// TPM_LAYOUTRTL
        /// </summary>
        TPM_LAYOUTRTL = 0x8000,

        /// <summary>
        /// TPM_WORKAREA
        /// </summary>
        TPM_WORKAREA = 0x10000,
    }
}
