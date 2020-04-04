using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.HIGHCONTRASTFlags;
using static Lsj.Util.Win32.Enums.WindowsMessages;
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
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-highcontrastw
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct HIGHCONTRAST
    {
        /// <summary>
        /// Specifies the size, in bytes, of this structure.
        /// </summary>
        public uint cbSize;

        /// <summary>
        /// Specifies a combination of the following values:
        /// <see cref="HCF_HIGHCONTRASTON"/>, <see cref="HCF_AVAILABLE"/>, <see cref="HCF_HOTKEYACTIVE"/>, <see cref="HCF_CONFIRMHOTKEY"/>,
        /// <see cref="HCF_HOTKEYSOUND"/>, <see cref="HCF_INDICATOR"/>, <see cref="HCF_HOTKEYAVAILABLE"/>,
        /// 0x00001000:
        /// Passing <see cref="HIGHCONTRAST"/> structure in calls to the <see cref="SystemParametersInfo"/> function can cause theme change effects
        /// even if the theme isn't being changed. 
        /// For example, the <see cref="WM_THEMECHANGED"/> message is sent to Windows even if the only change is to <see cref="HCF_HOTKEYSOUND"/>.
        /// To prevent this, include this flag value in the call to <see cref="SystemParametersInfo"/>.
        /// </summary>
        public HIGHCONTRASTFlags dwFlags;

        /// <summary>
        /// Points to a string that contains the name of the color scheme that will be set to the default scheme.
        /// </summary>
        public IntPtr lpszDefaultScheme;
    }
}
