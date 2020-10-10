using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains message information from a thread's message queue.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-msg
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct MSG
    {
        /// <summary>
        /// A handle to the window whose window procedure receives the message.
        /// This member is <see cref="IntPtr.Zero"/> when the message is a thread message.
        /// </summary>
        public HWND hwnd;

        /// <summary>
        /// The message identifier. Applications can only use the low word; the high word is reserved by the system.
        /// </summary>
        public WindowsMessages message;

        /// <summary>
        /// Additional information about the message. The exact meaning depends on the value of the message member.
        /// </summary>
        public WPARAM wParam;

        /// <summary>
        /// Additional information about the message. The exact meaning depends on the value of the message member.
        /// </summary>
        public LPARAM lParam;

        /// <summary>
        /// The time at which the message was posted.
        /// </summary>
        public DWORD time;

        /// <summary>
        /// The cursor position, in screen coordinates, when the message was posted.
        /// </summary>
        public POINT pt;

        /// <summary>
        /// lPrivate
        /// </summary>
        public DWORD lPrivate;
    }
}
