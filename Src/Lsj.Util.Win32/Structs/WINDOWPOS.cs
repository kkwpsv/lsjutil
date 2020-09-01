using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about the size and position of a window.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-windowpos
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
        /// The window position.
        /// </summary>
        public SetWindowPosFlags flags;
    }
}
