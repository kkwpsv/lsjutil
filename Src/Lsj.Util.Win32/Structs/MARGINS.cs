using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Returned by the <see cref="GetThemeMargins"/> function to define the margins of windows that have visual styles applied.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/uxtheme/ns-uxtheme-margins"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct MARGINS
    {
        /// <summary>
        /// Width of the left border that retains its size.
        /// </summary>
        public int cxLeftWidth;

        /// <summary>
        /// Width of the right border that retains its size.
        /// </summary>
        public int cxRightWidth;

        /// <summary>
        /// Height of the top border that retains its size.
        /// </summary>
        public int cyTopHeight;

        /// <summary>
        /// Height of the bottom border that retains its size.
        /// </summary>
        public int cyBottomHeight;
    }
}
