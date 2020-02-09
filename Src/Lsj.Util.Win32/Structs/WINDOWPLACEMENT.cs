using Lsj.Util.Win32.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about the placement of a window on the screen.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-windowplacement
    /// </para>
    /// </summary>
    public struct WINDOWPLACEMENT
    {
        /// <summary>
        /// The length of the structure, in bytes. 
        /// Before calling the <see cref="GetWindowPlacement"/> or <see cref="SetWindowPlacement"/> functions, 
        /// set this member to <code>sizeof(WINDOWPLACEMENT)</code>.
        /// <see cref="GetWindowPlacement"/> and <see cref="SetWindowPlacement"/> fail if this member is not set correctly.
        /// </summary>
        public uint length;

        /// <summary>
        /// The flags that control the position of the minimized window and the method by which the window is restored.
        /// </summary>
        public WINDOWPLACEMENTFlags flags;

        /// <summary>
        /// The current show state of the window. 
        /// </summary>
        public ShowWindowCommands showCmd;

        /// <summary>
        /// The coordinates of the window's upper-left corner when the window is minimized.
        /// </summary>
        public POINT ptMinPosition;

        /// <summary>
        /// The coordinates of the window's upper-left corner when the window is maximized.
        /// </summary>
        public POINT ptMaxPosition;

        /// <summary>
        /// The window's coordinates when the window is in the restored position.
        /// </summary>
        public RECT rcNormalPosition;

        /// <summary>
        /// 
        /// </summary>
        public RECT rcDevice;
    }
}
