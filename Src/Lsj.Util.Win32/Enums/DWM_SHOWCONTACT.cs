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
    public enum DWM_SHOWCONTACT
    {
        /// <summary>
        /// Down.
        /// </summary>
        DWMSC_DOWN,

        /// <summary>
        /// Up.
        /// </summary>
        DWMSC_UP,

        /// <summary>
        /// Drag.
        /// </summary>
        DWMSC_DRAG,

        /// <summary>
        /// Hold.
        /// </summary>
        DWMSC_HOLD,

        /// <summary>
        /// Pen barrel.
        /// </summary>
        DWMSC_PENBARREL,

        /// <summary>
        /// None.
        /// </summary>
        DWMSC_NONE,

        /// <summary>
        /// All.
        /// </summary>
        DWMSC_ALL
    }
}
