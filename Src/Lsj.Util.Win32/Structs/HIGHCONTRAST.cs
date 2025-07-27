using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.HIGHCONTRASTFlags;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Enums.SystemParametersInfoParameters;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about the high contrast accessibility feature.
    /// This feature sets the appearance scheme of the user interface for maximum visibility for a visually-impaired user,
    /// and advises applications to comply with this appearance scheme.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-highcontrastw"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// An application uses this structure when calling the <see cref="SystemParametersInfo"/> function
    /// with the <see cref="SPI_GETHIGHCONTRAST"/> or <see cref="SPI_SETHIGHCONTRAST"/> value.
    /// When using <see cref="SPI_GETHIGHCONTRAST"/>, an application must specify the <see cref="cbSize"/> member of the <see cref="HIGHCONTRAST"/> structure;
    /// the <see cref="SystemParametersInfo"/> function fills the remaining members.
    /// An application must specify all structure members when using the <see cref="SPI_SETHIGHCONTRAST"/> value.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct HIGHCONTRAST
    {
        /// <summary>
        /// Specifies the size, in bytes, of this structure.
        /// </summary>
        public UINT cbSize;

        /// <summary>
        /// <para>
        /// Specifies a combination of the following values:
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HCF_HIGHCONTRASTON"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// The high contrast feature is on.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HCF_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// The high contrast feature is available.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HCF_HOTKEYACTIVE"/>
        /// </para>
        /// <para>
        /// 0x00000004
        /// </para>
        /// </term>
        /// <term>
        /// The user can turn the high contrast feature on and off by simultaneously pressing the left ALT, left SHIFT, and PRINT SCREEN keys.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HCF_CONFIRMHOTKEY"/>
        /// </para>
        /// <para>
        /// 0x00000008
        /// </para>
        /// </term>
        /// <term>
        /// A confirmation dialog appears when the high contrast feature is activated by using the hot key.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HCF_HOTKEYSOUND"/>
        /// </para>
        /// <para>
        /// 0x00000010
        /// </para>
        /// </term>
        /// <term>
        /// A siren is played when the user turns the high contrast feature on or off by using the hot key.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HCF_INDICATOR"/>
        /// </para>
        /// <para>
        /// 0x00000020
        /// </para>
        /// </term>
        /// <term>
        /// A visual indicator is displayed when the high contrast feature is on. This value is not currently used and is ignored.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HCF_HOTKEYAVAILABLE"/>
        /// </para>
        /// <para>
        /// 0x00000040
        /// </para>
        /// </term>
        /// <term>
        /// The hot key associated with the high contrast feature can be enabled. An application can retrieve this value, but cannot set it.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HCF_OPTION_NOTHEMECHANGE"/>
        /// </para>
        /// <para>
        /// 0x00001000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Passing <see cref="HIGHCONTRASTSTRUCTURE"/> in calls to <see cref="SystemParametersInfo"/>
        /// can cause theme change effects even if the theme isn't being changed.
        /// For example, the <see cref="WM_THEMECHANGED"/> message is sent to Windows even if the only change is to <see cref="HCF_HOTKEYSOUND"/>.
        /// </para>
        /// <para>
        /// To prevent this, include the <see cref="HCF_OPTION_NOTHEMECHANGE"/> flag in the call to <see cref="SystemParametersInfo"/>.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// The <see cref="HCF_OPTION_NOTHEMECHANGE"/> flag should not be used when toggling the high contrast mode (<see cref="HCF_HIGHCONTRASTON"/>).
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HCF_OPTION_NOTHEMECHANGE"/>
        /// </para>
        /// <para>
        /// 0x00001000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Passing <see cref="HIGHCONTRASTSTRUCTURE"/> in calls to <see cref="SystemParametersInfo"/>
        /// can cause theme change effects even if the theme isn't being changed.
        /// For example, the <see cref="WM_THEMECHANGED"/> message is sent to Windows even if the only change is to <see cref="HCF_HOTKEYSOUND"/>.
        /// </para>
        /// <para>
        /// To prevent this, include the <see cref="HCF_OPTION_NOTHEMECHANGE"/> flag in the call to <see cref="SystemParametersInfo"/>.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// The <see cref="HCF_OPTION_NOTHEMECHANGE"/> flag should not be used when toggling the high contrast mode (<see cref="HCF_HIGHCONTRASTON"/>).
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public HIGHCONTRASTFlags dwFlags;

        /// <summary>
        /// Points to a string that contains the name of the color scheme that will be set to the default scheme.
        /// </summary>
        public IntPtr lpszDefaultScheme;
    }
}
