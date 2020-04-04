using System;
using static Lsj.Util.Win32.Enums.WindowsMessages;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="ScrollWindowEx"/> Flags.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-scrollwindowex
    /// </para>
    /// </summary>
    [Flags]
    public enum ScrollWindowExFlags
    {
        /// <summary>
        /// Scrolls all child windows that intersect the rectangle pointed to by the prcScroll parameter.
        /// The child windows are scrolled by the number of pixels specified by the dx and dy parameters.
        /// The system sends a <see cref="WM_MOVE"/> message to all child windows that intersect the prcScroll rectangle, even if they do not move.
        /// </summary>
        SW_SCROLLCHILDREN = 0x0001,

        /// <summary>
        /// Invalidates the region identified by the hrgnUpdate parameter after scrolling.
        /// </summary>
        SW_INVALIDATE = 0x0002,

        /// <summary>
        /// Erases the newly invalidated region by sending a <see cref="WM_ERASEBKGND"/> message to the window
        /// when specified with the <see cref="SW_INVALIDATE"/> flag.
        /// </summary>
        SW_ERASE = 0x0004,

        /// <summary>
        /// Scrolls using smooth scrolling.
        /// Use the <see cref="HIWORD"/> portion of the flags parameter to indicate how much time,
        /// in milliseconds, the smooth-scrolling operation should take.
        /// </summary>
        SW_SMOOTHSCROLL = 0x0010,
    }
}
