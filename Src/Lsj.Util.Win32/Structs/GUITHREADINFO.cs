using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.GUITHREADINFOFlags;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about a GUI thread.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-guithreadinfo
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is used with the <see cref="GetGUIThreadInfo"/> function to retrieve information about the active window or a specified GUI thread.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct GUITHREADINFO
    {
        /// <summary>
        /// The size of this structure, in bytes.
        /// The caller must set this member to <code>sizeof(GUITHREADINFO)</code>.
        /// </summary>
        public DWORD cbSize;

        /// <summary>
        /// The thread state. This member can be one or more of the following values.
        /// <see cref="GUI_CARETBLINKING"/>, <see cref="GUI_INMENUMODE"/>, <see cref="GUI_INMOVESIZE"/>, <see cref="GUI_POPUPMENUMODE"/>,
        /// <see cref="GUI_SYSTEMMENUMODE"/>
        /// </summary>
        public GUITHREADINFOFlags flags;

        /// <summary>
        /// A handle to the active window within the thread.
        /// </summary>
        public HWND hwndActive;

        /// <summary>
        /// A handle to the window that has the keyboard focus.
        /// </summary>
        public HWND hwndFocus;

        /// <summary>
        /// A handle to the window that has captured the mouse.
        /// </summary>
        public HWND hwndCapture;

        /// <summary>
        /// A handle to the window that owns any active menus.
        /// </summary>
        public HWND hwndMenuOwner;

        /// <summary>
        /// A handle to the window in a move or size loop.
        /// </summary>
        public HWND hwndMoveSize;

        /// <summary>
        /// A handle to the window that is displaying the caret.
        /// </summary>
        public HWND hwndCaret;

        /// <summary>
        /// The caret's bounding rectangle, in client coordinates, relative to the window specified by the <see cref="hwndCaret"/> member.
        /// </summary>
        public RECT rcCaret;
    }
}
