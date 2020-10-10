using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.SystemParametersInfoParameters;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains the scalable metrics associated with icons.
    /// This structure is used with the <see cref="SystemParametersInfo"/> function
    /// when the <see cref="SPI_GETICONMETRICS"/> or <see cref="SPI_SETICONMETRICS"/> action is specified.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-iconmetricsw
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ICONMETRICS
    {
        /// <summary>
        /// The size of the structure, in bytes.
        /// </summary>
        public UINT cbSize;

        /// <summary>
        /// The horizontal space, in pixels, for each arranged icon.
        /// </summary>
        public int iHorzSpacing;

        /// <summary>
        /// The vertical space, in pixels, for each arranged icon.
        /// </summary>
        public int iVertSpacing;

        /// <summary>
        /// If this member is nonzero, icon titles wrap to a new line. If this member is zero, titles do not wrap.
        /// </summary>
        public int iTitleWrap;

        /// <summary>
        /// The font to use for icon titles.
        /// </summary>
        public LOGFONT lfFont;
    }
}
