using static Lsj.Util.Win32.Dwmapi;
using static Lsj.Util.Win32.Enums.DWMWINDOWATTRIBUTE;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Flags used by the <see cref="DwmSetWindowAttribute"/> function to specify the Flip3D window policy.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/dwmapi/ne-dwmapi-dwmflip3dwindowpolicy
    /// </para>
    /// </summary>
    /// <remarks>
    /// To use a <see cref="DWMFLIP3DWINDOWPOLICY"/> value,
    /// set the dwAttribute parameter of the <see cref="DwmSetWindowAttribute"/> function to <see cref="DWMWA_FLIP3D_POLICY"/>.
    /// Set the pvAttribute parameter to the <see cref="DWMFLIP3DWINDOWPOLICY"/> value.
    /// </remarks>
    public enum DWMFLIP3DWINDOWPOLICY
    {
        /// <summary>
        /// Use the window's style and visibility settings to determine whether to hide or include the window in Flip3D rendering.
        /// </summary>
        DWMFLIP3D_DEFAULT,

        /// <summary>
        /// Exclude the window from Flip3D and display it below the Flip3D rendering.
        /// </summary>
        DWMFLIP3D_EXCLUDEBELOW,

        /// <summary>
        /// Exclude the window from Flip3D and display it above the Flip3D rendering.
        /// </summary>
        DWMFLIP3D_EXCLUDEABOVE,

        /// <summary>
        /// 	The maximum recognized DWMFLIP3DWINDOWPOLICY value, used for validation purposes.
        /// </summary>
        DWMFLIP3D_LAST
    }
}
