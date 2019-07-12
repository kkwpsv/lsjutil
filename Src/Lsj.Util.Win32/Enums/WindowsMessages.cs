using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Windows Messages
    /// TODO: Finish Messages
    /// </para>
    /// <para>
    ///  From: https://docs.microsoft.com/zh-cn/windows/win32/winmsg/about-messages-and-message-queues
    /// </para>
    /// </summary>
    public enum WindowsMessages : uint
    {
        #region Window Notifications

        /// <summary>
        /// Sent when a window belonging to a different application than the active window is about to be activated.
        /// The message is sent to the application whose window is being activated and to the application whose window is being deactivated.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_ACTIVATEAPP = 0x001C,

        /// <summary>
        /// Sent to cancel certain modes, such as mouse capture.
        /// For example, the system sends this message to the active window when a dialog box or message box is displayed.
        /// Certain functions also send this message explicitly to the specified window regardless of whether it is the active window.
        /// For example, the EnableWindow function sends this message when disabling the specified window.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_CANCELMODE = 0x001F,

        /// <summary>
        /// Sent to a child window when the user clicks the window's title bar or when the window is activated, moved, or sized.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_CHILDACTIVATE = 0x0022,

        /// <summary>
        /// Sent as a signal that a window or an application should terminate.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_CLOSE = 0x0010,

        /// <summary>
        /// Sent to all top-level windows when the system detects more than 12.5 percent of system time over a 30- to 60-second interval is being spent compacting memory.
        /// This indicates that system memory is low.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_COMPACTING = 0x0041,

        /// <summary>
        /// Sent when an application requests that a window be created by calling 
        /// the <see cref="CreateWindowEx(WindowStylesEx, string, string, WindowStyles, int, int, int, int, IntPtr, IntPtr, IntPtr, IntPtr)"/> or CreateWindow function.
        /// (The message is sent before the function returns.)
        /// The window procedure of the new window receives this message after the window is created, but before the window becomes visible.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_CREATE = 0x0001,

        /// <summary>
        /// Sent when a window is being destroyed. It is sent to the window procedure of the window being destroyed after the window is removed from the screen.
        /// This message is sent first to the window being destroyed and then to the child windows (if any) as they are destroyed.
        /// During the processing of the message, it can be assumed that all child windows still exist.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_DESTROY = 0x0002,

        /// <summary>
        /// Sent when an application changes the enabled state of a window. It is sent to the window whose enabled state is changing.
        /// This message is sent before the EnableWindow function returns, but after the enabled state (<see cref="WindowStyles.WS_DISABLED"/> style bit) of the window has changed.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_ENABLE = 0x000A,

        /// <summary>
        /// Sent one time to a window after it enters the moving or sizing modal loop.
        /// The window enters the moving or sizing modal loop when the user clicks the window's title bar or sizing border, 
        /// or when the window passes the WM_SYSCOMMAND message to the <see cref="DefWindowProc"/> function and 
        /// the wParam parameter of the message specifies the SC_MOVE or SC_SIZE value.
        /// The operation is complete when <see cref="DefWindowProc"/> returns.
        /// The system sends the <see cref="WM_ENTERSIZEMOVE"/> message regardless of whether the dragging of full windows is enabled.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_ENTERSIZEMOVE = 0x0231,

        /// <summary>
        /// Sent one time to a window, after it has exited the moving or sizing modal loop.
        /// The window enters the moving or sizing modal loop when the user clicks the window's title bar or sizing border,
        /// or when the window passes the WM_SYSCOMMAND message to the <see cref="DefWindowProc"/> function and 
        /// the wParam parameter of the message specifies the SC_MOVE or SC_SIZE value.
        /// The operation is complete when DefWindowProc returns.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_EXITSIZEMOVE = 0x232,

        /// <summary>
        /// Sent to a window to retrieve a handle to the large or small icon associated with a window.
        /// The system displays the large icon in the ALT+TAB dialog, and the small icon in the window caption.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_GETICON = 0x007F,

        WM_GETMINMAXINFO = 0x0024,

        WM_INPUTLANGCHANGE = 0x0051,

        WM_INPUTLANGCHANGEREQUEST = 0x0050,

        WM_MOVE = 0x0003,

        WM_MOVING = 0x0216,

        WM_NCACTIVATE = 0x0086,

        WM_NCCALCSIZE = 0x0083,

        WM_NCCREATE = 0x0081,

        WM_NCDESTROY = 0x0082,

        WM_NULL = 0x0000,

        WM_QUERYDRAGICON = 0x0037,

        WM_QUERYOPEN = 0x0013,

        WM_QUIT = 0x0012,

        WM_SHOWWINDOW = 0x0018,

        WM_SIZE = 0x0005,

        WM_SIZING = 0x0214,

        WM_STYLECHANGED = 0x007D,

        WM_STYLECHANGING = 0x007C,

        WM_THEMECHANGED = 0x031A,

        WM_USERCHANGED = 0x0054,

        WM_WINDOWPOSCHANGED = 0x0047,

        WM_WINDOWPOSCHANGING = 0x0046,

        #endregion

        #region Clipboard Messages

        /// <summary>
        /// An application sends a <see cref="WM_CUT"/> message to an edit control or combo box to delete (cut) the current selection,
        /// if any, in the edit control and copy the deleted text to the clipboard in CF_TEXT format. 
        /// </summary>
        WM_CUT = 0x0300,

        /// <summary>
        /// An application sends the <see cref="WM_COPY"/> message to an edit control or combo box to copy the current selection to the clipboard in CF_TEXT format. 
        /// </summary>
        WM_COPY = 0x0301,

        /// <summary>
        /// An application sends a <see cref="WM_PASTE"/> message to an edit control or combo box to copy the current content of the clipboard to the edit control
        /// at the current caret position. Data is inserted only if the clipboard contains data in CF_TEXT format. 
        /// </summary>
        WM_PASTE = 0x0302,

        /// <summary>
        /// An application sends a <see cref="WM_CLEAR"/> message to an edit control or combo box to delete (clear) the current selection, if any, from the edit control. 
        /// </summary>
        WM_CLEAR = 0x0303,

        #endregion

        #region DPI

        /// <summary>
        /// <para>
        /// Sent when the effective dots per inch (dpi) for a window has changed. The DPI is the scale factor for a window.
        /// There are multiple events that can cause the DPI to change. The following list indicates the possible causes for the change in DPI.
        /// The window is moved to a new monitor that has a different DPI.
        /// The DPI of the monitor hosting the window changes.
        /// </para>
        /// <para>
        /// The current DPI for a window always equals the last DPI sent by <see cref="WM_DPICHANGED"/>.
        /// This is the scale factor that the window should be scaling to for threads that are aware of DPI changes.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/hidpi/wm-dpichanged
        /// </para>
        /// </summary>
        WM_DPICHANGED = 0x02E0,

        #endregion

        #region Mouse Input Notifications

        /// <summary>
        /// Sent to a window in order to determine what part of the window corresponds to a particular screen coordinate.
        /// This can happen, for example, when the cursor moves, when a mouse button is pressed or released, or in response to a call to a function such as WindowFromPoint.
        /// If the mouse is not captured, the message is sent to the window beneath the cursor. Otherwise, the message is sent to the window that has captured the mouse.
        /// </summary>
        WM_NCHITTEST = 0x0084,

        #endregion
    }
}
