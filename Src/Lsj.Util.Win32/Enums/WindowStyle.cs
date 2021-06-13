using System;
using static Lsj.Util.Win32.Enums.WindowsMessages;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>Window Styles</para>
    /// <para>
    /// The following styles can be specified wherever a window style is required.
    /// After the control has been created, these styles cannot be modified, except as noted.</para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/winmsg/window-styles"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum WindowStyles : uint
    {
        /// <summary>
        /// The window has a thin-line border.
        /// </summary>
        WS_BORDER = 0x800000,

        /// <summary>
        /// The window has a title bar (includes the <see cref="WS_BORDER"/> style).
        /// </summary>
        WS_CAPTION = 0xc00000,

        /// <summary>
        /// The window is a child window. A window with this style cannot have a menu bar. 
        /// This style cannot be used with the <see cref="WS_POPUP"/> style.
        /// </summary>
        WS_CHILD = 0x40000000,

        /// <summary>
        /// Same as the WS_CHILD style.
        /// </summary>
        WS_CHILDWINDOW = 0x40000000,

        /// <summary>
        /// Excludes the area occupied by child windows when drawing occurs within the parent window.
        /// This style is used when creating the parent window.
        /// </summary>
        WS_CLIPCHILDREN = 0x2000000,

        /// <summary>
        /// Clips child windows relative to each other;
        /// that is, when a particular child window receives a <see cref="WM_PAINT"/> message,
        /// the <see cref="WS_CLIPSIBLINGS"/> style clips all other overlapping child windows out of the region of the child window to be updated.
        /// If <see cref="WS_CLIPSIBLINGS"/> is not specified and child windows overlap,
        /// it is possible, when drawing within the client area of a child window, to draw within the client area of a neighboring child window.
        /// </summary>
        WS_CLIPSIBLINGS = 0x4000000,

        /// <summary>
        /// The window is initially disabled. A disabled window cannot receive input from the user.
        /// To change this after a window has been created, use the <see cref="EnableWindow"/> function.
        /// </summary>
        WS_DISABLED = 0x8000000,

        /// <summary>
        /// The window has a border of a style typically used with dialog boxes. A window with this style cannot have a title bar.
        /// </summary>
        WS_DLGFRAME = 0x400000,

        /// <summary>
        /// The window is the first control of a group of controls.
        /// The group consists of this first control and all controls defined after it,
        /// up to the next control with the <see cref="EnableWindow"/> style.
        /// The first control in each group usually has the <see cref="WS_TABSTOP"/> style so that the user can move from group to group.
        /// The user can subsequently change the keyboard focus from one control in the group to the next control in the group
        /// by using the direction keys.
        /// You can turn this style on and off to change dialog box navigation.
        /// To change this style after a window has been created, use the <see cref="SetWindowLong"/> function.
        /// </summary>
        WS_GROUP = 0x20000,

        /// <summary>
        /// The window has a horizontal scroll bar.
        /// </summary>
        WS_HSCROLL = 0x100000,

        /// <summary>
        /// The window is initially minimized. Same as the <see cref="WS_MINIMIZE"/> style.
        /// </summary>
        WS_ICONIC = 0x20000000,

        /// <summary>
        /// The window is initially maximized.
        /// </summary> 
        WS_MAXIMIZE = 0x1000000,

        /// <summary>
        /// The window has a maximize button.
        /// Cannot be combined with the <see cref="WindowStylesEx.WS_EX_CONTEXTHELP"/> style.
        /// The <see cref="WS_SYSMENU"/> style must also be specified.
        /// </summary> 
        WS_MAXIMIZEBOX = 0x10000,

        /// <summary>
        /// The window is initially minimized. Same as the <see cref="WS_ICONIC"/> style.
        /// </summary>
        WS_MINIMIZE = 0x20000000,

        /// <summary>
        /// The window has a minimize button. Cannot be combined with the <see cref="WindowStylesEx.WS_EX_CONTEXTHELP"/> style.
        /// The <see cref="WS_SYSMENU"/> style must also be specified.
        /// </summary>
        WS_MINIMIZEBOX = 0x20000,

        /// <summary>
        /// The window is an overlapped window. An overlapped window has a title bar and a border. Same as the <see cref="WS_TILED"/> style.
        /// </summary>
        WS_OVERLAPPED = 0x0,

        /// <summary>
        /// The window is an overlapped window. Same as the <see cref="WS_TILEDWINDOW"/> style. 
        /// </summary>
        WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX,

        /// <summary>
        /// The window is a pop-up window. This style cannot be used with the <see cref="WS_CHILD"/> style.
        /// </summary>
        WS_POPUP = 0x80000000u,

        /// <summary>
        /// The window is a pop-up window.
        /// The <see cref="WS_CAPTION"/> and <see cref="WS_POPUPWINDOW"/> styles must be combined to make the window menu visible.
        /// </summary>
        WS_POPUPWINDOW = WS_POPUP | WS_BORDER | WS_SYSMENU,

        /// <summary>
        /// The window has a sizing border. Same as the <see cref="WS_THICKFRAME"/> style.
        /// </summary>
        WS_SIZEBOX = 0x40000,

        /// <summary>
        /// The window has a window menu on its title bar. The <see cref="WS_CAPTION"/> style must also be specified.
        /// </summary>
        WS_SYSMENU = 0x80000,

        /// <summary>
        /// The window is a control that can receive the keyboard focus when the user presses the TAB key.
        /// Pressing the TAB key changes the keyboard focus to the next control with the <see cref="WS_TABSTOP"/> style.  
        /// You can turn this style on and off to change dialog box navigation.
        /// To change this style after a window has been created, use the <see cref="SetWindowLong"/> function.
        /// For user-created windows and modeless dialogs to work with tab stops,
        /// alter the message loop to call the <see cref="IsDialogMessage"/> function.
        /// </summary>
        WS_TABSTOP = 0x10000,

        /// <summary>
        /// The window has a sizing border. Same as the <see cref="WS_SIZEBOX"/> style.
        /// </summary>
        WS_THICKFRAME = 0x40000,

        /// <summary>
        /// The window is an overlapped window.
        /// An overlapped window has a title bar and a border. Same as the <see cref="WS_OVERLAPPED"/> style. 
        /// </summary>
        WS_TILED = 0,

        /// <summary>
        /// The window is an overlapped window. Same as the <see cref="WS_OVERLAPPEDWINDOW"/> style. 
        /// </summary>
        WS_TILEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX,

        /// <summary>
        /// The window is initially visible.
        /// This style can be turned on and off by using the <see cref="ShowWindow"/> or <see cref="SetWindowPos"/> function.
        /// </summary>
        WS_VISIBLE = 0x10000000,

        /// <summary>
        /// The window has a vertical scroll bar.
        /// </summary>
        WS_VSCROLL = 0x200000
    }
}
