using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using static Lsj.Util.Win32.Enums.ExtendedWindowStyles;
using static Lsj.Util.Win32.Enums.ShowWindowCommands;
using static Lsj.Util.Win32.Enums.WindowPlacementFlags;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about the placement of a window on the screen.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-windowplacement"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// If the window is a top-level window that does not have the <see cref="WS_EX_TOOLWINDOW"/> window style,
    /// then the coordinates represented by the following members are in workspace coordinates:
    /// <see cref="ptMinPosition"/>, <see cref="ptMaxPosition"/>, and <see cref="rcNormalPosition"/>.
    /// Otherwise, these members are in screen coordinates.
    /// </para>
    /// <para>
    /// Workspace coordinates differ from screen coordinates in that
    /// they take the locations and sizes of application toolbars (including the taskbar) into account.
    /// Workspace coordinate (0,0) is the upper-left corner of the workspace area,
    /// the area of the screen not being used by application toolbars.
    /// </para>
    /// <para>
    /// The coordinates used in a <see cref="WINDOWPLACEMENT"/> structure
    /// should be used only by the <see cref="GetWindowPlacement"/> and <see cref="SetWindowPlacement"/> functions.
    /// Passing workspace coordinates to functions which expect screen coordinates (such as <see cref="SetWindowPos"/>)
    /// will result in the window appearing in the wrong location.
    /// For example, if the taskbar is at the top of the screen,
    /// saving window coordinates using <see cref="GetWindowPlacement"/>
    /// and restoring them using <see cref="SetWindowPos"/> causes the window to appear to "creep" up the screen.
    /// </para>
    /// </remarks>
    public struct WINDOWPLACEMENT
    {
        /// <summary>
        /// <para>
        /// The length of the structure, in bytes.
        /// Before calling the <see cref="GetWindowPlacement"/> or <see cref="SetWindowPlacement"/> functions, set this member to .
        /// </para>
        /// <para>
        /// <see cref="GetWindowPlacement"/> and <see cref="SetWindowPlacement"/> fail if this member is not set correctly.
        /// </para>
        /// </summary>
        public UINT length;

        /// <summary>
        /// <para>
        /// The flags that control the position of the minimized window and the method by which the window is restored.
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
        /// <see cref="WPF_ASYNCWINDOWPLACEMENT"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// If the calling thread and the thread that owns the window are attached to different input queues,
        /// the system posts the request to the thread that owns the window.
        /// This prevents the calling thread from blocking its execution while other threads process the request.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WPF_RESTORETOMAXIMIZED"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The restored window will be maximized, regardless of whether it was maximized before it was minimized.
        /// This setting is only valid the next time the window is restored.
        /// It does not change the default restoration behavior.
        /// </para>
        /// <para>
        /// This flag is only valid when the <see cref="SW_SHOWMINIMIZED"/> value is specified for the <see cref="showCmd"/> member.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WPF_SETMINPOSITION"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The coordinates of the minimized window may be specified.
        /// </para>
        /// <para>
        /// This flag must be specified if the coordinates are set in the <see cref="ptMinPosition"/> member.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public WindowPlacementFlags flags;

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
