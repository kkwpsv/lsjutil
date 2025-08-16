using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.GUIThreadStates;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about a GUI thread.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-guithreadinfo"/>
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
        /// <para>
        /// The thread state. This member can be one or more of the following values.
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
        /// <see cref="GUI_CARETBLINKING"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// The caret's blink state. This bit is set if the caret is visible.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GUI_INMENUMODE"/>
        /// </para>
        /// <para>
        /// 0x00000004
        /// </para>
        /// </term>
        /// <term>
        /// The thread's menu state. This bit is set if the thread is in menu mode.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GUI_INMOVESIZE"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// The thread's move state. This bit is set if the thread is in a move or size loop.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GUI_POPUPMENUMODE"/>
        /// </para>
        /// <para>
        /// 0x00000010
        /// </para>
        /// </term>
        /// <term>
        /// The thread's pop-up menu state. This bit is set if the thread has an active pop-up menu.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GUI_SYSTEMMENUMODE"/>
        /// </para>
        /// <para>
        /// 0x00000008
        /// </para>
        /// </term>
        /// <term>
        /// The thread's system menu state. This bit is set if the thread is in a system menu mode.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public GUIThreadStates flags;

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
