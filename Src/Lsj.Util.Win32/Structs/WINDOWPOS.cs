using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using static Lsj.Util.Win32.User32;
using static Lsj.Util.Win32.Enums.SetWindowPosFlags;
using static Lsj.Util.Win32.Enums.WindowMessages;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about the size and position of a window.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-windowpos"/>
    /// </para>
    /// </summary>
    public struct WINDOWPOS
    {
        /// <summary>
        /// The position of the window in Z order (front-to-back position).
        /// This member can be a handle to the window behind which this window is placed,
        /// or can be one of the special values listed with the <see cref="SetWindowPos"/> function.
        /// </summary>
        public HWND hwndInsertAfter;

        /// <summary>
        /// A handle to the window.
        /// </summary>
        public HWND hwnd;

        /// <summary>
        /// The position of the left edge of the window.
        /// </summary>
        public int x;

        /// <summary>
        /// The position of the top edge of the window.
        /// </summary>
        public int y;

        /// <summary>
        /// The window width, in pixels.
        /// </summary>
        public int cx;

        /// <summary>
        /// The window height, in pixels.
        /// </summary>
        public int cy;

        /// <summary>
        /// <para>
        /// The window position.
        /// This member can be one or more of the following values.
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
        /// <see cref="SWP_DRAWFRAME"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// Draws a frame (defined in the window's class description) around the window.
        /// Same as the <see cref="SWP_FRAMECHANGED"/> flag.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_FRAMECHANGED"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// Sends a <see cref="WM_NCCALCSIZE"/> message to the window, even if the window's size is not being changed.
        /// If this flag is not specified, <see cref="WM_NCCALCSIZE"/> is sent only when the window's size is being changed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_HIDEWINDOW"/>
        /// </para>
        /// <para>
        /// 0x0080
        /// </para>
        /// </term>
        /// <term>
        /// Hides the window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_NOACTIVATE"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// Does not activate the window.
        /// If this flag is not set, the window is activated and moved to the top of either the topmost or non-topmost group
        /// (depending on the setting of the <see cref="hwndInsertAfter"/> member).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_NOCOPYBITS"/>
        /// </para>
        /// <para>
        /// 0x0100
        /// </para>
        /// </term>
        /// <term>
        /// Discards the entire contents of the client area.
        /// If this flag is not specified, the valid contents of the client area are saved and copied back
        /// into the client area after the window is sized or repositioned.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_NOMOVE"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// Retains the current position (ignores the x and y members).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_NOOWNERZORDER"/>
        /// </para>
        /// <para>
        /// 0x0200
        /// </para>
        /// </term>
        /// <term>
        /// Does not change the owner window's position in the Z order.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_NOREDRAW"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// Does not redraw changes.
        /// If this flag is set, no repainting of any kind occurs.
        /// This applies to the client area, the nonclient area (including the title bar and scroll bars),
        /// and any part of the parent window uncovered as a result of the window being moved.
        /// When this flag is set, the application must explicitly invalidate or redraw any parts of the window and parent window that need redrawing.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_NOREPOSITION"/>
        /// </para>
        /// <para>
        /// 0x0200
        /// </para>
        /// </term>
        /// <term>
        /// Does not change the owner window's position in the Z order.
        /// Same as the <see cref="SWP_NOOWNERZORDER"/> flag.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_NOSENDCHANGING"/>
        /// </para>
        /// <para>
        /// 0x0400
        /// </para>
        /// </term>
        /// <term>
        /// Prevents the window from receiving the <see cref="WM_WINDOWPOSCHANGING"/> message.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_NOSIZE"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// Retains the current size (ignores the cx and cy members).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_NOZORDER"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// Retains the current Z order (ignores the <see cref="hwndInsertAfter"/> member).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_SHOWWINDOW"/>
        /// </para>
        /// <para>
        /// 0x0040
        /// </para>
        /// </term>
        /// <term>
        /// Displays the window.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public SetWindowPosFlags flags;
    }
}
