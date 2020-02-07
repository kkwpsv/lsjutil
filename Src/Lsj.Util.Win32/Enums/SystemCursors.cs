using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// System Cursors
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-loadcursorw
    /// </para>
    /// </summary>
    public enum SystemCursors
    {
        /// <summary>
        /// IDC_APPSTARTING
        /// </summary>
        IDC_APPSTARTING = 32650,

        /// <summary>
        /// Standard arrow
        /// </summary>
        IDC_ARROW = 32512,

        /// <summary>
        /// Crosshair
        /// </summary>
        IDC_CROSS = 32515,

        /// <summary>
        /// Hand
        /// </summary>
        IDC_HAND = 32649,

        /// <summary>
        /// Arrow and question mark
        /// </summary>
        IDC_HELP = 32651,

        /// <summary>
        /// I-beam
        /// </summary>
        IDC_IBEAM = 32513,

        /// <summary>
        /// Obsolete for applications marked version 4.0 or later.
        /// </summary>
        [Obsolete]
        IDC_ICON = 32641,

        /// <summary>
        /// Slashed circle
        /// </summary>
        IDC_NO = 32648,

        /// <summary>
        /// Obsolete for applications marked version 4.0 or later. Use <see cref="SystemCursors.IDC_SIZEALL"/>.
        /// </summary>
        [Obsolete]
        IDC_SIZE = 32640,

        /// <summary>
        /// Four-pointed arrow pointing north, south, east, and west
        /// </summary>
        IDC_SIZEALL = 32646,

        /// <summary>
        /// Double-pointed arrow pointing northeast and southwest
        /// </summary>
        IDC_SIZENESW = 32643,

        /// <summary>
        /// Double-pointed arrow pointing north and south
        /// </summary>
        IDC_SIZENS = 32645,

        /// <summary>
        /// Double-pointed arrow pointing northwest and southeast
        /// </summary>
        IDC_SIZENWSE = 32642,

        /// <summary>
        /// Double-pointed arrow pointing west and east
        /// </summary>
        IDC_SIZEWE = 32644,

        /// <summary>
        /// Vertical arrow
        /// </summary>
        IDC_UPARROW = 32516,

        /// <summary>
        /// Hourglass
        /// </summary>
        IDC_WAIT = 32514,
    }
}
