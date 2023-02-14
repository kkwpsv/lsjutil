using System;
using static Lsj.Util.Win32.Enums.WindowMessages;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// QueueStatus
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getqueuestatus"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum QueueStatus : uint
    {
        /// <summary>
        /// An input, <see cref="WM_TIMER"/>, <see cref="WM_PAINT"/>, <see cref="WM_HOTKEY"/>, or posted message is in the queue.
        /// </summary>
        QS_ALLEVENTS = QS_INPUT | QS_POSTMESSAGE | QS_TIMER | QS_PAINT | QS_HOTKEY,

        /// <summary>
        /// Any message is in the queue.
        /// </summary>
        QS_ALLINPUT = QS_INPUT | QS_POSTMESSAGE | QS_TIMER | QS_PAINT | QS_HOTKEY | QS_SENDMESSAGE,

        /// <summary>
        /// A posted message (other than those listed here) is in the queue.
        /// </summary>
        QS_ALLPOSTMESSAGE = 0x0100,

        /// <summary>
        /// A <see cref="WM_HOTKEY"/> message is in the queue.
        /// </summary>
        QS_HOTKEY = 0x0080,

        /// <summary>
        /// An input message is in the queue.
        /// </summary>
        QS_INPUT = QS_MOUSE | QS_KEY | QS_RAWINPUT,

        /// <summary>
        /// A <see cref="WM_KEYUP"/>, <see cref="WM_KEYDOWN"/>,  <see cref="WM_SYSKEYUP"/>, or <see cref="WM_SYSKEYDOWN"/> message is in the queue.
        /// </summary>
        QS_KEY = 0x0001,

        /// <summary>
        /// A <see cref="WM_MOUSEMOVE"/> message or mouse-button message (<see cref="WM_LBUTTONUP"/>, <see cref="WM_RBUTTONDOWN"/>, and so on).
        /// </summary>
        QS_MOUSE = QS_MOUSEMOVE | QS_MOUSEBUTTON,

        /// <summary>
        /// A mouse-button message <see cref="WM_LBUTTONUP"/>, <see cref="WM_RBUTTONDOWN"/>, and so on).
        /// </summary>
        QS_MOUSEBUTTON = 0x0004,

        /// <summary>
        /// A <see cref="WM_MOUSEMOVE"/> message is in the queue.
        /// </summary>
        QS_MOUSEMOVE = 0x0002,

        /// <summary>
        /// A <see cref="WM_PAINT"/> message is in the queue.
        /// </summary>
        QS_PAINT = 0x0020,

        /// <summary>
        /// A posted message (other than those listed here) is in the queue.
        /// </summary>
        QS_POSTMESSAGE = 0x0008,

        /// <summary>
        /// A raw input message is in the queue. For more information, see Raw Input.
        /// Windows 2000:  This flag is not supported.
        /// </summary>
        QS_RAWINPUT = 0x0400,

        /// <summary>
        /// A message sent by another thread or application is in the queue.
        /// </summary>
        QS_SENDMESSAGE = 0x0040,

        /// <summary>
        /// A <see cref="WM_TIMER"/> message is in the queue.
        /// </summary>
        QS_TIMER = 0x0010,

    }
}
