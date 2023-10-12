using static Lsj.Util.Win32.Dwmapi;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Identifies the target.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/ne-dwmapi-dwmtransition_ownedwindow_target"/>
    /// </para>
    /// </summary>
    public enum DWMTRANSITION_OWNEDWINDOW_TARGET
    {
        /// <summary>
        /// Indicates no animation.
        /// </summary>
        DWMTRANSITION_OWNEDWINDOW_NULL = -1,

        /// <summary>
        /// Indicates that the window is repositioned.
        /// </summary>
        DWMTRANSITION_OWNEDWINDOW_REPOSITION = 0
    }
}
