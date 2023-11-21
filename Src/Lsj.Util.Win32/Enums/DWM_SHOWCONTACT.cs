using System;
using static Lsj.Util.Win32.Dwmapi;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the input operations for which visual feedback should be provided.
    /// This enumeration is used by the <see cref="DwmShowContact"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/ne-dwmapi-dwm_showcontact"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum DWM_SHOWCONTACT : uint
    {
        /// <summary>
        /// Down.
        /// </summary>
        DWMSC_DOWN = 0x00000001,

        /// <summary>
        /// Up.
        /// </summary>
        DWMSC_UP = 0x00000002,

        /// <summary>
        /// Drag.
        /// </summary>
        DWMSC_DRAG = 0x00000004,

        /// <summary>
        /// Hold.
        /// </summary>
        DWMSC_HOLD = 0x00000008,

        /// <summary>
        /// Pen barrel.
        /// </summary>
        DWMSC_PENBARREL = 0x00000010,

        /// <summary>
        /// None.
        /// </summary>
        DWMSC_NONE = 0x00000000,

        /// <summary>
        /// All.
        /// </summary>
        DWMSC_ALL = 0xFFFFFFFF,
    }
}
