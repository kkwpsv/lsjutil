using System;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="AnimateWindow"/> flags
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-animatewindow"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum AnimateWindowFlags
    {
        /// <summary>
        /// AW_ACTIVATE
        /// </summary>
        AW_ACTIVATE = 0x00020000,

        /// <summary>
        /// AW_BLEND
        /// </summary>
        AW_BLEND = 0x00080000,

        /// <summary>
        /// AW_CENTER
        /// </summary>
        AW_CENTER = 0x00000010,

        /// <summary>
        /// AW_HIDE
        /// </summary>
        AW_HIDE = 0x00010000,

        /// <summary>
        /// AW_HOR_POSITIVE
        /// </summary>
        AW_HOR_POSITIVE = 0x00000001,

        /// <summary>
        /// AW_HOR_NEGATIVE
        /// </summary>
        AW_HOR_NEGATIVE = 0x00000002,

        /// <summary>
        /// AW_SLIDE
        /// </summary>
        AW_SLIDE = 0x00040000,

        /// <summary>
        /// AW_VER_POSITIVE
        /// </summary>
        AW_VER_POSITIVE = 0x00000004,

        /// <summary>
        /// AW_VER_NEGATIVE
        /// </summary>
        AW_VER_NEGATIVE = 0x00000008,
    }
}
