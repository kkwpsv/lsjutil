using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains window information.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-windowinfo"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WINDOWINFO
    {
        /// <summary>
        /// The size of the structure, in bytes.
        /// The caller must set this member to <code>sizeof(WINDOWINFO)</code>.
        /// </summary>
        public DWORD cbSize;

        /// <summary>
        /// The coordinates of the window.
        /// </summary>
        public RECT rcWindow;

        /// <summary>
        /// The coordinates of the client area.
        /// </summary>
        public RECT rcClient;

        /// <summary>
        /// The window styles.
        /// For a table of window styles, see Window Styles.
        /// </summary>
        public WindowStyles dwStyle;

        /// <summary>
        /// The extended window styles.
        /// For a table of extended window styles, see Extended Window Styles.
        /// </summary>
        public WindowStylesEx dwExStyle;

        /// <summary>
        /// The window status.
        /// If this member is <see cref="WS_ACTIVECAPTION"/> (0x0001), the window is active.
        /// Otherwise, this member is zero.
        /// </summary>
        public DWORD dwWindowStatus;

        /// <summary>
        /// The width of the window border, in pixels.
        /// </summary>
        public UINT cxWindowBorders;

        /// <summary>
        /// The height of the window border, in pixels.
        /// </summary>
        public UINT cyWindowBorders;

        /// <summary>
        /// The window class atom (see <see cref="RegisterClass"/>).
        /// </summary>
        public ATOM atomWindowType;

        /// <summary>
        /// The Windows version of the application that created the window.
        /// </summary>
        public WORD wCreatorVersion;
    }
}
