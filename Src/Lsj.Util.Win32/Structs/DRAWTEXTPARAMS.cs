using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.DrawTextFormatFlags;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="DRAWTEXTPARAMS"/> structure contains extended formatting options for the <see cref="DrawTextEx"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-drawtextparams"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DRAWTEXTPARAMS
    {
        /// <summary>
        /// The structure size, in bytes.
        /// </summary>
        public UINT cbSize;

        /// <summary>
        /// The size of each tab stop, in units equal to the average character width.
        /// </summary>
        public int iTabLength;

        /// <summary>
        /// The left margin, in units equal to the average character width.
        /// </summary>
        public int iLeftMargin;

        /// <summary>
        /// The right margin, in units equal to the average character width.
        /// </summary>
        public int iRightMargin;

        /// <summary>
        /// Receives the number of characters processed by <see cref="DrawTextEx"/>, including white-space characters.
        /// The number can be the length of the string or the index of the first line that falls below the drawing area.
        /// Note that <see cref="DrawTextEx"/> always processes the entire string if the <see cref="DT_NOCLIP"/> formatting flag is specified.
        /// </summary>
        public UINT uiLengthDrawn;
    }
}
