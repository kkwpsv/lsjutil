using static Lsj.Util.Win32.Dwmapi;
using static Lsj.Util.Win32.Enums.DWMWINDOWATTRIBUTE;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Flags used by the <see cref="DwmSetWindowAttribute"/> function to specify the non-client area rendering policy.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/ne-dwmapi-dwmncrenderingpolicy"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// To use a <see cref="DWMNCRENDERINGPOLICY"/> value, set the dwAttribute parameter
    /// of the <see cref="DwmSetWindowAttribute"/> function to <see cref="DWMWA_NCRENDERING_POLICY"/>.
    /// Set the pvAttribute parameter to the <see cref="DWMNCRENDERINGPOLICY"/> value.
    /// </remarks>
    public enum DWMNCRENDERINGPOLICY
    {
        /// <summary>
        /// The non-client rendering area is rendered based on the window style.
        /// </summary>
        DWMNCRP_USEWINDOWSTYLE,

        /// <summary>
        /// The non-client area rendering is disabled; the window style is ignored.
        /// </summary>
        DWMNCRP_DISABLED,

        /// <summary>
        /// The non-client area rendering is enabled; the window style is ignored.
        /// </summary>
        DWMNCRP_ENABLED,

        /// <summary>
        /// The maximum recognized <see cref="DWMNCRENDERINGPOLICY"/> value, used for validation purposes.
        /// </summary>
        DWMNCRP_LAST
    }
}
