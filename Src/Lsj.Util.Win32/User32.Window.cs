using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using System.Text;
using static Lsj.Util.Win32.Enums.AnimateWindowFlags;
using static Lsj.Util.Win32.Enums.ComboBoxControlMessages;
using static Lsj.Util.Win32.Enums.GetWindowLongIndexes;
using static Lsj.Util.Win32.Enums.ShowWindowCommands;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.WindowsMessages;
using static Lsj.Util.Win32.Enums.WindowStyles;
using static Lsj.Util.Win32.Enums.WindowStylesEx;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32
{
    public static partial class User32
    {
        /// <summary>
        /// CW_USEDEFAULT
        /// </summary>
        public const int CW_USEDEFAULT = unchecked((int)0x80000000);

        /// <summary>
        /// <para>
        /// Places the window above all non-topmost windows (that is, behind all topmost windows). 
        /// This flag has no effect if the window is already a non-topmost window.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setwindowpos
        /// </para>
        /// </summary>
        public static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);

        /// <summary>
        /// <para>
        /// Places the window above all non-topmost windows. The window maintains its topmost position even when it is deactivated.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setwindowpos
        /// </para>
        /// </summary>
        public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);

        /// <summary>
        /// <para>
        /// Places the window at the top of the Z order.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setwindowpos
        /// </para>
        /// </summary>
        public static readonly IntPtr HWND_TOP = new IntPtr(0);

        /// <summary>
        /// <para>
        /// Places the window at the bottom of the Z order.
        /// If the hWnd parameter identifies a topmost window, the window loses its topmost status and is placed at the bottom of all other windows.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setwindowpos
        /// </para>
        /// </summary>
        public static readonly IntPtr HWND_BOTTOM = new IntPtr(1);

        /// <summary>
        /// <para>
        /// An application-defined function that processes messages sent to a window.
        /// The <see cref="WNDPROC"/> type defines a pointer to this callback function.
        /// WindowProc is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/previous-versions/windows/desktop/legacy/ms633573(v=vs.85)
        /// </para>
        /// </summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="uMsg">The message.</param>
        /// <param name="wParam">Additional message information. The contents of this parameter depend on the value of the uMsg parameter.</param>
        /// <param name="lParam">Additional message information. The contents of this parameter depend on the value of the uMsg parameter.</param>
        /// <returns>The return value is the result of the message processing and depends on the message sent.</returns>
        public delegate IntPtr WNDPROC([In]IntPtr hWnd, [In]WindowsMessages uMsg, [In]UIntPtr wParam, [In]IntPtr lParam);

        /// <summary>
        /// <para>
        /// An application-defined callback function used with the <see cref="EnumWindows"/> or <see cref="EnumDesktopWindows"/> function.
        /// It receives top-level window handles. The <see cref="WNDENUMPROC"/> type defines a pointer to this callback function.
        /// EnumWindowsProc is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/previous-versions/windows/desktop/legacy/ms633498(v%3Dvs.85)
        /// </para>
        /// </summary>
        /// <param name="hWnd">A handle to a top-level window.</param>
        /// <param name="lParam">The application-defined value given in <see cref="EnumWindows"/> or <see cref="EnumDesktopWindows"/>.</param>
        /// <returns></returns>
        [return: MarshalAs(UnmanagedType.Bool)]
        public delegate bool WNDENUMPROC([In]IntPtr hWnd, [In]IntPtr lParam);

        /// <summary>
        /// <para>
        /// Enables you to produce special effects when showing or hiding windows.
        /// There are four types of animation: roll, slide, collapse or expand, and alpha-blended fade.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-animatewindow
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window to animate. The calling thread must own this window.
        /// </param>
        /// <param name="dwTime">
        /// The time it takes to play the animation, in milliseconds. Typically, an animation takes 200 milliseconds to play.
        /// </param>
        /// <param name="dwFlags">
        /// The type of animation.
        /// This parameter can be one or more of the following values.
        /// Note that, by default, these flags take effect when showing a window.
        /// To take effect when hiding a window, use <see cref="AW_HIDE"/> and a logical OR operator with the appropriate flags.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// The function will fail in the following situations:
        /// If the window is already visible and you are trying to show the window.
        /// If the window is already hidden and you are trying to hide the window.
        /// If there is no direction specified for the slide or roll animation.
        /// When trying to animate a child window with <see cref="AW_BLEND"/>.
        /// If the thread does not own the window. 
        /// Note that, in this case, <see cref="AnimateWindow"/> fails
        /// but <see cref="GetLastError"/> returns <see cref="ERROR_SUCCESS"/>.
        /// To get extended error information, call the <see cref="GetLastError"/> function.
        /// </returns>
        /// <remarks>
        /// To show or hide a window without special effects, use <see cref="ShowWindow"/>.
        /// When using slide or roll animation, you must specify the direction.
        /// It can be either <see cref="AW_HOR_POSITIVE"/>, <see cref="AW_HOR_NEGATIVE"/>,
        /// <see cref="AW_VER_POSITIVE"/>, or <see cref="AW_VER_NEGATIVE"/>.
        /// You can combine <see cref="AW_HOR_POSITIVE"/> or <see cref="AW_HOR_NEGATIVE"/>
        /// with <see cref="AW_VER_POSITIVE"/> or <see cref="AW_VER_NEGATIVE"/> to animate a window diagonally.
        /// The window procedures for the window and its child windows should handle
        /// any <see cref="WM_PRINT"/> or <see cref="WM_PRINTCLIENT"/> messages.
        /// Dialog boxes, controls, and common controls already handle <see cref="WM_PRINTCLIENT"/>.
        /// The default window procedure already handles <see cref="WM_PRINT"/>.
        /// If a child window is displayed partially clipped, when it is animated it will have holes where it is clipped.
        /// <see cref="AnimateWindow"/> supports RTL windows.
        /// Avoid animating a window that has a drop shadow because it produces visually distracting, jerky animations.
        /// </remarks>
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "AnimateWindow", SetLastError = true)]
        public static extern bool AnimateWindow([In]IntPtr hWnd, [In]uint dwTime, [In]AnimateWindowFlags dwFlags);

        /// <summary>
        /// <para>
        /// Passes message information to the specified window procedure.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-callwindowprocw
        /// </para>
        /// </summary>
        /// <param name="lpPrevWndFunc">
        /// The previous window procedure.
        /// If this value is obtained by calling the <see cref="GetWindowLong"/> function with the nIndex parameter
        /// set to <see cref="GWL_WNDPROC"/> or <see cref="DWL_DLGPROC"/>,
        /// it is actually either the address of a window or dialog box procedure,
        /// or a special internal value meaningful only to <see cref="CallWindowProc"/>.
        /// </param>
        /// <param name="hWnd">
        /// A handle to the window procedure to receive the message.
        /// </param>
        /// <param name="Msg">
        /// The message.
        /// </param>
        /// <param name="wParam">
        /// Additional message-specific information.
        /// The contents of this parameter depend on the value of the <paramref name="Msg"/> parameter.
        /// </param>
        /// <param name="lParam">
        /// Additional message-specific information.
        /// The contents of this parameter depend on the value of the <paramref name="Msg"/> parameter.
        /// </param>
        /// <returns>
        /// The return value specifies the result of the message processing and depends on the message sent.
        /// </returns>
        /// <remarks>
        /// Use the <see cref="CallWindowProc"/> function for window subclassing.
        /// Usually, all windows with the same class share one window procedure.
        /// A subclass is a window or set of windows with the same class whose messages are intercepted and processed
        /// by another window procedure (or procedures) before being passed to the window procedure of the class.
        /// The <see cref="SetWindowLong"/> function creates the subclass by changing the window procedure associated with a particular window,
        /// causing the system to call the new window procedure instead of the previous one.
        /// An application must pass any messages not processed by the new window procedure
        /// to the previous window procedure by calling <see cref="CallWindowProc"/>.
        /// This allows the application to create a chain of window procedures.
        /// The <see cref="CallWindowProc"/> function handles Unicode-to-ANSI conversion.
        /// You cannot take advantage of this conversion if you call the window procedure directly.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallWindowProcW", SetLastError = true)]
        public static extern int CallWindowProc([MarshalAs(UnmanagedType.FunctionPtr)][In]WNDPROC lpPrevWndFunc, [In]IntPtr hWnd,
            [In]WindowsMessages Msg, [In]UIntPtr wParam, [In]IntPtr lParam);

        /// <summary>
        /// <para>
        /// Creates an overlapped, pop-up, or child window.
        /// It specifies the window class, window title, window style, and (optionally) the initial position and size of the window.
        /// The function also specifies the window's parent or owner, if any, and the window's menu.
        /// To use extended window styles in addition to the styles supported by <see cref="CreateWindow"/>, use the <see cref="CreateWindowEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-createwindoww
        /// </para>
        /// </summary>
        /// <param name="lpClassName">
        /// A null-terminated string or a class atom created by a previous call to the <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/> function.
        /// The atom must be in the low-order word of <paramref name="lpClassName"/>; the high-order word must be zero.
        /// If <paramref name="lpClassName"/> is a string, it specifies the window class name.
        /// The class name can be any name registered with <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/>,
        /// provided that the module that registers the class is also the module that creates the window.
        /// The class name can also be any of the predefined system class names.
        /// For a list of system class names, see the Remarks section.
        /// </param>
        /// <param name="lpWindowName">
        /// The window name.
        /// If the window style specifies a title bar, the window title pointed to by <paramref name="lpWindowName"/> is displayed in the title bar.
        /// When using <see cref="CreateWindow"/> to create controls, such as buttons, check boxes, and static controls,
        /// use <paramref name="lpWindowName"/> to specify the text of the control.
        /// When creating a static control with the <see cref="SS_ICON"/> style, use <paramref name="lpWindowName"/> to specify the icon name or identifier.
        /// To specify an identifier, use the syntax "#num".
        /// </param>
        /// <param name="dwStyle">
        /// The style of the window being created.
        /// This parameter can be a combination of the window style values, plus the control styles indicated in the Remarks section.
        /// </param>
        /// <param name="x">
        /// The initial horizontal position of the window.
        /// For an overlapped or pop-up window, the x parameter is the initial x-coordinate of the window's upper-left corner, in screen coordinates.
        /// For a child window, x is the x-coordinate of the upper-left corner of the window relative
        /// to the upper-left corner of the parent window's client area.
        /// If this parameter is set to <see cref="CW_USEDEFAULT"/>, the system selects the default position for the window's upper-left corner
        /// and ignores the y parameter.
        /// <see cref="CW_USEDEFAULT"/> is valid only for overlapped windows;
        /// if it is specified for a pop-up or child window, the x and y parameters are set to zero.
        /// </param>
        /// <param name="y">
        /// The initial vertical position of the window.
        /// For an overlapped or pop-up window, the y parameter is the initial y-coordinate of the window's upper-left corner, in screen coordinates.
        /// For a child window, y is the initial y-coordinate of the upper-left corner of the child window relative
        /// to the upper-left corner of the parent window's client area.
        /// For a list box, y is the initial y-coordinate of the upper-left corner of the list box's client area relative to the upper-left corner
        /// of the parent window's client area.
        /// If an overlapped window is created with the <see cref="WS_VISIBLE"/> style bit set and
        /// the x parameter is set to <see cref="CW_USEDEFAULT"/>, then the y parameter determines how the window is shown.
        /// If the y parameter is <see cref="CW_USEDEFAULT"/>, then the window manager calls <see cref="ShowWindow"/>
        /// with the <see cref="SW_SHOW"/> flag after the window has been created.
        /// If the y parameter is some other value, then the window manager calls <see cref="ShowWindow"/> with that value as the nCmdShow parameter.
        /// </param>
        /// <param name="nWidth">
        /// The width, in device units, of the window.
        /// For overlapped windows, <paramref name="nWidth"/> is either the window's width, in screen coordinates, or <see cref="CW_USEDEFAULT"/>.
        /// If <paramref name="nWidth"/> is <see cref="CW_USEDEFAULT"/>, the system selects a default width and height for the window;
        /// the default width extends from the initial x-coordinate to the right edge of the screen,
        /// and the default height extends from the initial y-coordinate to the top of the icon area.
        /// <see cref="CW_USEDEFAULT"/> is valid only for overlapped windows;
        /// if <see cref="CW_USEDEFAULT"/> is specified for a pop-up or child window,
        /// <paramref name="nWidth"/> and <paramref name="nHeight"/> are set to zero.
        /// </param>
        /// <param name="nHeight">
        /// The height, in device units, of the window.
        /// For overlapped windows, <paramref name="nHeight"/> is the window's height, in screen coordinates.
        /// If <paramref name="nWidth"/> is set to <see cref="CW_USEDEFAULT"/>, the system ignores nHeight.
        /// </param>
        /// <param name="hWndParent">
        /// A handle to the parent or owner window of the window being created.
        /// To create a child window or an owned window, supply a valid window handle.
        /// This parameter is optional for pop-up windows.
        /// To create a message-only window, supply <see cref="HWND_MESSAGE"/> or a handle to an existing message-only window.
        /// </param>
        /// <param name="hMenu">
        /// A handle to a menu, or specifies a child-window identifier depending on the window style.
        /// For an overlapped or pop-up window, <paramref name="hMenu"/> identifies the menu to be used with the window;
        /// it can be <see cref="IntPtr.Zero"/> if the class menu is to be used.
        /// For a child window, <paramref name="hMenu"/> specifies the child-window identifier,
        /// an integer value used by a dialog box control to notify its parent about events.
        /// The application determines the child-window identifier; it must be unique for all child windows with the same parent window.
        /// </param>
        /// <param name="hInstance">
        /// A handle to the instance of the module to be associated with the window.
        /// </param>
        /// <param name="lpParam">
        /// A pointer to a value to be passed to the window through the <see cref="CREATESTRUCT"/> structure
        /// (<see cref="CREATESTRUCT.lpCreateParams"/> member) pointed to by the <paramref name="lpParam"/> param
        /// of the <see cref="WM_CREATE"/> message.
        /// This message is sent to the created window by this function before it returns.
        /// If an application calls <see cref="CreateWindow"/> to create a MDI client window,
        /// <paramref name="lpParam"/> should point to a <see cref="CLIENTCREATESTRUCT"/> structure.
        /// If an MDI client window calls <see cref="CreateWindow"/> to create an MDI child window,
        /// <paramref name="lpParam"/> should point to a <see cref="MDICREATESTRUCT"/> structure.
        /// <paramref name="lpParam"/> may be <see cref="IntPtr.Zero"/> if no additional data is needed.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// Before returning, <see cref="CreateWindow"/> sends a <see cref="WM_CREATE"/> message to the window procedure.
        /// For overlapped, pop-up, and child windows, <see cref="CreateWindow"/> sends <see cref="WM_CREATE"/>,
        /// <see cref="WM_GETMINMAXINFO"/>, and <see cref="WM_NCCREATE"/> messages to the window.
        /// The <paramref name="lpParam"/> parameter of the <see cref="WM_CREATE"/> message contains
        /// a pointer to a <see cref="CREATESTRUCT"/> structure.
        /// If the <see cref="WS_VISIBLE"/> style is specified,
        /// <see cref="CreateWindow"/> sends the window all the messages required to activate and show the window.
        /// If the created window is a child window, its default position is at the bottom of the Z-order.
        /// If the created window is a top-level window, its default position is at the top of the Z-order
        /// (but beneath all topmost windows unless the created window is itself topmost).
        /// For information on controlling whether the Taskbar displays a button for the created window, see Managing Taskbar Buttons.
        /// For information on removing a window, see the <see cref="DestroyWindow"/> function.
        /// The following predefined system classes can be specified in the <paramref name="lpClassName"/> parameter.
        /// Note the corresponding control styles you can use in the <paramref name="dwStyle"/>/> parameter.
        /// BUTTON:
        /// Designates a small rectangular child window that represents a button the user can click to turn it on or off.
        /// Button controls can be used alone or in groups, and they can either be labeled or appear without text.
        /// Button controls typically change appearance when the user clicks them.
        /// For more information, see Buttons
        /// For a table of the button styles you can specify in the <paramref name="dwStyle"/> parameter, see Button Styles.
        /// COMBOBOX:
        /// Designates a control consisting of a list box and a selection field similar to an edit control.
        /// When using this style, an application should either display the list box at all times or enable a drop-down list box.
        /// If the list box is visible, typing characters into the selection field highlights the first list box entry that matches the characters typed.
        /// Conversely, selecting an item in the list box displays the selected text in the selection field.
        /// For more information, see Combo Boxes.
        /// For a table of the combo box styles you can specify in the <paramref name="dwStyle"/> parameter, see Combo Box Styles.
        /// EDIT:
        /// Designates a rectangular child window into which the user can type text from the keyboard.
        /// The user selects the control and gives it the keyboard focus by clicking it or moving to it by pressing the TAB key.
        /// The user can type text when the edit control displays a flashing caret; use the mouse to move the cursor, select characters to be replaced,
        /// or position the cursor for inserting characters; or use the BACKSPACE key to delete characters. For more information, see Edit Controls.
        /// For a table of the edit control styles you can specify in the dwStyle parameter, see Edit Control Styles.
        /// LISTBOX:
        /// Designates a list of character strings. Specify this control whenever an application must present a list of names,
        /// such as file names, from which the user can choose.
        /// The user can select a string by clicking it. A selected string is highlighted, and a notification message is passed to the parent window.
        /// For more information, see List Boxes.
        /// For a table of the list box styles you can specify in the <paramref name="dwStyle"/> parameter, see List Box Styles.
        /// MDICLIENT:
        /// Designates an MDI client window. This window receives messages that control the MDI application's child windows.
        /// The recommended style bits are <see cref="WS_CLIPCHILDREN"/> and <see cref="WS_CHILD"/>.
        /// Specify the <see cref="WS_HSCROLL"/> and <see cref="WS_VSCROLL"/> styles to create an MDI client window
        /// that allows the user to scroll MDI child windows into view.
        /// For more information, see Multiple Document Interface.
        /// RichEdit:
        /// Designates a Microsoft Rich Edit 1.0 control.
        /// This window lets the user view and edit text with character and paragraph formatting,
        /// and can include embedded Component Object Model (COM) objects.
        /// For more information, see Rich Edit Controls.
        /// For a table of the rich edit control styles you can specify in the <paramref name="dwStyle"/> parameter, see Rich Edit Control Styles.
        /// RICHEDIT_CLASS:
        /// Designates a Microsoft Rich Edit 2.0 control.
        /// This controls let the user view and edit text with character and paragraph formatting, and can include embedded COM objects.
        /// For more information, see Rich Edit Controls.
        /// For a table of the rich edit control styles you can specify in the <paramref name="dwStyle"/> parameter, see Rich Edit Control Styles.
        /// SCROLLBAR:
        /// Designates a rectangle that contains a scroll box and has direction arrows at both ends.
        /// The scroll bar sends a notification message to its parent window whenever the user clicks the control.
        /// The parent window is responsible for updating the position of the scroll box, if necessary.
        /// For more information, see Scroll Bars.
        /// For a table of the scroll bar control styles you can specify in the <paramref name="dwStyle"/> parameter, see Scroll Bar Control Styles.
        /// STATIC:
        /// Designates a simple text field, box, or rectangle used to label, box, or separate other controls.
        /// Static controls take no input and provide no output.
        /// For more information, see Static Controls.
        /// For a table of the static control styles you can specify in the <paramref name="dwStyle"/> parameter, see Static Control Styles.
        /// </remarks>
        public static IntPtr CreateWindow(StringHandle lpClassName, string lpWindowName, WindowStyles dwStyle,
            int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam) =>
            CreateWindowEx(0, lpClassName, lpWindowName, dwStyle, x, y, nWidth, nHeight, hWndParent, hMenu, hInstance, lpParam);

        /// <summary>
        /// <para>
        /// Creates an overlapped, pop-up, or child window with an extended window style; 
        /// otherwise, this function is identical to the <see cref="CreateWindow"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-createwindowexw
        /// </para>
        /// </summary>
        /// <param name="dwExStyle">The extended window style of the window being created.</param>
        /// <param name="lpClassName">
        /// A null-terminated string or a class atom created by a previous call 
        /// to the <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/> function.
        /// It specifies the window class name. 
        /// The class name can be any name registered with <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/>,
        /// provided that the module that registers the class is also the module that creates the window.
        /// The class name can also be any of the predefined system class names.
        /// </param>
        /// <param name="lpWindowName">
        /// The window name.
        /// If the window style specifies a title bar, the window title pointed to by <paramref name="lpWindowName"/> is displayed in the title bar.
        /// When using <see cref="CreateWindowEx"/> to create controls, such as buttons, check boxes, and static controls,
        /// use <paramref name="lpWindowName"/> to specify the text of the control.
        /// When creating a static control with the <see cref="SS_ICON"/> style,
        /// use <paramref name="lpWindowName"/> to specify the icon name or identifier.
        /// To specify an identifier, use the syntax "#num".
        /// </param>
        /// <param name="dwStyle">
        /// The style of the window being created. This parameter can be a combination of the <see cref="WindowStyles"/>, plus the control styles.
        /// </param>
        /// <param name="x">
        /// The initial horizontal position of the window.
        /// For an overlapped or pop-up window, the <paramref name="x"/> parameter is the initial x-coordinate of the window's upper-left corner,
        /// in screen coordinates.
        /// For a child window, <paramref name="x"/> is the x-coordinate of the upper-left corner of the window relative 
        /// to the upper-left corner of the parent window's client area.
        /// If <paramref name="x"/> is set to <see cref="CW_USEDEFAULT"/>, the system selects the default position
        /// for the window's upper-left corner and ignores the y parameter.
        /// <see cref="CW_USEDEFAULT"/> is valid only for overlapped windows; if it is specified for a pop-up or child window,
        /// the <paramref name="x"/> and <paramref name="y"/> parameters are set to zero.
        /// </param>
        /// <param name="y">
        /// The initial vertical position of the window.
        /// For an overlapped or pop-up window, the <paramref name="y"/> parameter is the initial y-coordinate of the window's upper-left corner,
        /// in screen coordinates.
        /// For a child window, <paramref name="y"/> is the initial y-coordinate of the upper-left corner of the child window relative
        /// to the upper-left corner of the parent window's client area.
        /// For a list box <paramref name="y"/> is the initial y-coordinate of the upper-left corner of the list box's client area relative
        /// to the upper-left corner of the parent window's client area.
        /// If an overlapped window is created with the <see cref="WS_VISIBLE"/> style bit set and
        /// the <paramref name="x"/> parameter is set to <see cref="CW_USEDEFAULT"/>, then the y parameter determines how the window is shown.
        /// If the <paramref name="y"/> parameter is <see cref="CW_USEDEFAULT"/>, then the window manager calls
        /// <see cref="ShowWindow"/> with the <see cref="SW_SHOW"/> flag after the window has been created.
        /// If the <paramref name="y"/> parameter is some other value, then the window manager calls 
        /// <see cref="ShowWindow"/> with that value as the nCmdShow parameter.
        /// </param>
        /// <param name="nWidth">
        /// The width, in device units, of the window.
        /// For overlapped windows, nWidth is the window's width, in screen coordinates, or <see cref="CW_USEDEFAULT"/>.
        /// If nWidth is <see cref="CW_USEDEFAULT"/>, the system selects a default width and height for the window;
        /// the default width extends from the initial x-coordinates to the right edge of the screen;
        /// the default height extends from the initial y-coordinate to the top of the icon area.
        /// <see cref="CW_USEDEFAULT"/> is valid only for overlapped windows;
        /// if <see cref="CW_USEDEFAULT"/> is specified for a pop-up or child window, the nWidth and nHeight parameter are set to zero.
        /// </param>
        /// <param name="nHeight">
        /// The height, in device units, of the window. For overlapped windows, nHeight is the window's height, in screen coordinates.
        /// If the nWidth parameter is set to <see cref="CW_USEDEFAULT"/>, the system ignores nHeight.
        /// </param>
        /// <param name="hWndParent">
        /// A handle to the parent or owner window of the window being created. To create a child window or an owned window, supply a valid window handle.
        /// This parameter is optional for pop-up windows.
        /// To create a message-only window, supply <see cref="HWND_MESSAGE"/> or a handle to an existing message-only window.
        /// </param>
        /// <param name="hMenu">
        /// A handle to a menu, or specifies a child-window identifier, depending on the window style. For an overlapped or pop-up window,
        /// <paramref name="hMenu"/> identifies the menu to be used with the window; it can be <see cref="IntPtr.Zero"/> if the class menu is to be used.
        /// For a child window, <paramref name="hMenu"/>  specifies the child-window identifier, an integer value used by a dialog box control
        /// to notify its parent about events.
        /// The application determines the child-window identifier; it must be unique for all child windows with the same parent window.
        /// </param>
        /// <param name="hInstance">A handle to the instance of the module to be associated with the window.</param>
        /// <param name="lpParam">
        /// Pointer to a value to be passed to the window through the <see cref="CREATESTRUCT"/> structure (lpCreateParams member)
        /// pointed to by the <paramref name="lpParam"/> param of the <see cref="WM_CREATE"/> message.
        /// This message is sent to the created window by this function before it returns.
        /// If an application calls <see cref="CreateWindowEx"/> to create a MDI client window,
        /// <paramref name="lpParam"/> should point to a <see cref="CLIENTCREATESTRUCT"/> structure.
        /// If an MDI client window calls <see cref="CreateWindowEx"/> to create an MDI child window,
        /// <paramref name="lpParam"/> should point to a <see cref="MDICREATESTRUCT"/> structure.
        /// <paramref name="lpParam"/> may be <see cref="IntPtr.Zero"/> if no additional data is needed.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the new window.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// This function typically fails for one of the following reasons:
        /// an invalid parameter value
        /// the system class was registered by a different module
        /// the <see cref="WH_CBT"/> hook is installed and returns a failure code
        /// if one of the controls in the dialog template is not registered,
        /// or its window window procedure fails <see cref="WM_CREATE"/> or <see cref="WM_NCCREATE"/>
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateWindowExW", SetLastError = true)]
        public static extern IntPtr CreateWindowEx([In]WindowStylesEx dwExStyle, [In]StringHandle lpClassName,
            [MarshalAs(UnmanagedType.LPWStr)][In] string lpWindowName, [In]WindowStyles dwStyle, [In]int x, [In]int y, [In]int nWidth, [In]int nHeight,
            [In]IntPtr hWndParent, [In]IntPtr hMenu, [In]IntPtr hInstance, [In]IntPtr lpParam);

        /// <summary>
        /// <para>
        /// Calls the default window procedure to provide default processing for any window messages that an application does not process.
        /// This function ensures that every message is processed. DefWindowProc is called with the same parameters received by the window procedure.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-defwindowprocw
        /// </para>
        /// </summary>
        /// <param name="hWnd">A handle to the window procedure that received the message.</param>
        /// <param name="uMsg">The message.</param>
        /// <param name="wParam">Additional message information. The content of this parameter depends on the value of the Msg parameter.</param>
        /// <param name="lParam">Additional message information. The content of this parameter depends on the value of the Msg parameter.</param>
        /// <returns>The return value is the result of the message processing and depends on the message.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DefWindowProcW", SetLastError = true)]
        public static extern IntPtr DefWindowProc([In]IntPtr hWnd, [In]WindowsMessages uMsg, [In]UIntPtr wParam, [In]IntPtr lParam);

        /// <summary>
        /// <para>
        /// Destroys the specified window.
        /// The function sends <see cref="WM_DESTROY"/> and <see cref="WM_NCDESTROY"/> messages 
        /// to the window to deactivate it and remove the keyboard focus from it.
        /// The function also destroys the window's menu, flushes the thread message queue, destroys timers, removes clipboard ownership,
        /// and breaks the clipboard viewer chain (if the window is at the top of the viewer chain).
        /// If the specified window is a parent or owner window, <see cref="DestroyWindow"/> automatically destroys
        /// the associated child or owned windows when it destroys the parent or owner window.
        /// The function first destroys child or owned windows, and then it destroys the parent or owner window.
        /// <see cref="DestroyWindow"/> also destroys modeless dialog boxes created by the <see cref="CreateDialog"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-destroywindow
        /// </para>
        /// </summary>
        /// <param name="hwnd">A handle to the window to be destroyed.</param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DestroyWindow", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DestroyWindow([In]IntPtr hwnd);

        /// <summary>
        /// <para>
        /// Enables or disables mouse and keyboard input to the specified window or control.
        /// When input is disabled, the window does not receive input such as mouse clicks and key presses.
        /// When input is enabled, the window receives all input.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-enablewindow
        /// </para>
        /// </summary>
        /// <param name="hWnd">A handle to the window to be enabled or disabled.</param>
        /// <param name="bEnable">
        /// Indicates whether to enable or disable the window.
        /// If this parameter is <see langword="true"/>, the window is enabled.
        /// If the parameter is <see langword="false"/>, the window is disabled.
        /// </param>
        /// <returns>
        /// If the window was previously disabled, the return value is <see langword="true"/>.
        /// If the window was not previously disabled, the return value is <see langword="false"/>.
        /// </returns>
        /// <remarks>
        /// If the window is being disabled, the system sends a <see cref="WM_CANCELMODE"/> message.
        /// If the enabled state of a window is changing,
        /// the system sends a <see cref="WM_ENABLE"/> message after the <see cref="WM_CANCELMODE"/> message.
        /// (These messages are sent before <see cref="EnableWindow"/> returns.)
        /// If a window is already disabled, its child windows are implicitly disabled,
        /// although they are not sent a <see cref="WM_ENABLE"/> message.
        /// A window must be enabled before it can be activated.
        /// For example, if an application is displaying a modeless dialog box and has disabled its main window,
        /// the application must enable the main window before destroying the dialog box.
        /// Otherwise, another window will receive the keyboard focus and be activated.
        /// If a child window is disabled, it is ignored when the system tries to determine which window should receive mouse messages.
        /// By default, a window is enabled when it is created.
        /// To create a window that is initially disabled, an application can specify the <see cref="WS_DISABLED"/> style
        /// in the <see cref="CreateWindow"/> or <see cref="CreateWindowEx"/> function.
        /// After a window has been created, an application can use <see cref="EnableWindow"/> to enable or disable the window.
        /// An application can use this function to enable or disable a control in a dialog box.
        /// A disabled control cannot receive the keyboard focus, nor can a user gain access to it.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnableWindow", SetLastError = true)]
        public static extern bool EnableWindow([In]IntPtr hWnd, [In]bool bEnable);

        /// <summary>
        /// <para>
        /// Enumerates all top-level windows on the screen by passing the handle to each window, in turn, to an application-defined callback function.
        /// EnumWindows continues until the last top-level window is enumerated or the callback function returns <see langword="false"/>.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-enumwindows
        /// </para>
        /// </summary>
        /// <param name="lpEnumFunc">A pointer to an application-defined callback function. For more information, see <see cref="WNDENUMPROC"/>.</param>
        /// <param name="lParam">An application-defined value to be passed to the callback function.</param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If <see cref="WNDENUMPROC"/> returns <see langword="false"/>, the return value is also <see langword="false"/>. 
        /// In this case, the callback function should call <see cref="SetLastError"/> to obtain a meaningful error code
        /// to be returned to the caller of <see cref="EnumWindows"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumWindows", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumWindows([In]WNDENUMPROC lpEnumFunc, [In]IntPtr lParam);

        /// <summary>
        /// <para>
        /// Retrieves a handle to the top-level window whose class name and window name match the specified strings.
        /// This function does not search child windows.
        /// This function does not perform a case-sensitive search.
        /// To search child windows, beginning with a specified child window, use the <see cref="FindWindowEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-findwindoww
        /// </para>
        /// </summary>
        /// <param name="lpClassName">
        /// The class name or a class atom created by a previous call to the <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/> function.
        /// The atom must be in the low-order word of <paramref name="lpClassName"/>; the high-order word must be zero.
        /// If <paramref name="lpClassName"/> points to a string, it specifies the window class name.
        /// The class name can be any name registered with <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/>,
        /// or any of the predefined control-class names.
        /// If <paramref name="lpClassName"/> is <see langword="null"/>, it finds any window
        /// whose title matches the <paramref name="lpClassName"/> parameter.
        /// </param>
        /// <param name="lpWindowName">
        /// The window name (the window's title). If this parameter is <see langword="null"/>, all window names match.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the window that has the specified class name and window name.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the <paramref name="lpClassName"/> parameter is not <see langword="null"/>,
        /// <see cref="FindWindow"/> calls the <see cref="GetWindowText"/> function to retrieve the window name for comparison.
        /// For a description of a potential problem that can arise, see the Remarks for <see cref="GetWindowText"/>.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindWindowW", SetLastError = true)]
        private static extern IntPtr FindWindow([In]StringHandle lpClassName, [MarshalAs(UnmanagedType.LPWStr)][In]string lpWindowName);

        /// <summary>
        /// <para>
        /// Retrieves a handle to a window whose class name and window name match the specified strings.
        /// The function searches child windows, beginning with the one following the specified child window.
        /// This function does not perform a case-sensitive search.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-findwindowexw
        /// </para>
        /// </summary>
        /// <param name="hWndParent">
        /// A handle to the parent window whose child windows are to be searched.
        /// If <paramref name="hWndParent"/> is <see cref="IntPtr.Zero"/>, the function uses the desktop window as the parent window.
        /// The function searches among windows that are child windows of the desktop.
        /// If <paramref name="hWndParent"/> is <see cref="HWND_MESSAGE"/>, the function searches all message-only windows.
        /// </param>
        /// <param name="hWndChildAfter">
        /// A handle to a child window.
        /// The search begins with the next child window in the Z order.
        /// The child window must be a direct child window of <paramref name="hWndParent"/>, not just a descendant window.
        /// If <paramref name="hWndChildAfter"/> is <see cref="IntPtr.Zero"/>, the search begins with the first child window of <paramref name="hWndParent"/>.
        /// Note that if both <paramref name="hWndParent"/> and <paramref name="hWndChildAfter"/> are <see cref="IntPtr.Zero"/>,
        /// the function searches all top-level and message-only windows.
        /// </param>
        /// <param name="lpszClass">
        /// The class name or a class atom created by a previous call to the <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/> function.
        /// The atom must be placed in the low-order word of lpszClass; the high-order word must be zero.
        /// If <paramref name="lpszClass"/> is a string, it specifies the window class name.
        /// The class name can be any name registered with <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/>,
        /// or any of the predefined control-class names, or it can be MAKEINTATOM(0x8000).
        /// In this latter case, 0x8000 is the atom for a menu class.
        /// For more information, see the Remarks section of this topic.
        /// </param>
        /// <param name="lpszWindow">
        /// The window name (the window's title). If this parameter is <see langword="null"/>, all window names match.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the window that has the specified class and window names.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the <paramref name="lpszWindow"/> parameter is not <see langword="null"/>,
        /// <see cref="FindWindowEx"/> calls the <see cref="GetWindowText"/> function to retrieve the window name for comparison.
        /// For a description of a potential problem that can arise, see the Remarks section of <see cref="GetWindowText"/>.
        /// An application can call this function in the following way.
        /// FindWindowEx(NULL, NULL, MAKEINTATOM(0x8000), NULL);
        /// Note that 0x8000 is the atom for a menu class.
        /// When an application calls this function, the function checks whether a context menu is being displayed that the application created.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindWindowExW", SetLastError = true)]
        private static extern IntPtr FindWindowEx([In]IntPtr hWndParent, [In]IntPtr hWndChildAfter, [In]StringHandle lpszClass,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpszWindow);

        /// <summary>
        /// <para>
        /// Retrieves information about a window class.
        /// The <see cref="GetClassInfo"/> function has been superseded by the <see cref="GetClassInfoEx"/> function.
        /// You can still use <see cref="GetClassInfo"/>, however, if you do not need information about the class small icon.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getclassinfow
        /// </para>
        /// </summary>
        /// <param name="hInstance">
        /// A handle to the instance of the application that created the class. 
        /// To retrieve information about classes defined by the system (such as buttons or list boxes), set this parameter to <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <param name="lpClassName">
        /// The class name.
        /// The name must be that of a preregistered class or a class registered
        /// by a previous call to the <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/> function.
        /// Alternatively, this parameter can be an atom. If so, it must be a class atom created by a previous call
        /// to <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/>.
        /// The atom must be in the low-order word of <paramref name="lpClassName"/>; the high-order word must be zero.
        /// </param>
        /// <param name="lpWndClass">
        /// A pointer to a <see cref="WNDCLASS"/> structure that receives the information about the class.
        /// </param>
        /// <returns>
        /// If the function finds a matching class and successfully copies the data, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetClassInfoW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetClassInfo([In]IntPtr hInstance, [In]StringHandle lpClassName, [Out]out WNDCLASS lpWndClass);

        /// <summary>
        /// <para>
        /// Retrieves information about a window class, including a handle to the small icon associated with the window class.
        /// The <see cref="GetClassInfo"/> function does not retrieve a handle to the small icon.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getclassinfoexw
        /// </para>
        /// </summary>
        /// <param name="hInstance">
        /// A handle to the instance of the application that created the class.
        /// To retrieve information about classes defined by the system (such as buttons or list boxes), set this parameter to <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <param name="lpszClass">
        /// The class name.
        /// The name must be that of a preregistered class or a class registered by a previous call to
        /// the <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/> function.
        /// Alternatively, this parameter can be a class atom created by a previous call to <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/>.
        /// The atom must be in the low-order word of <paramref name="lpszClass"/>; the high-order word must be zero.
        /// </param>
        /// <param name="lpWndClass">
        /// A pointer to a <see cref="WNDCLASSEX"/> structure that receives the information about the class.
        /// </param>
        /// <returns>
        /// If the function finds a matching class and successfully copies the data, the return value is <see langword="true"/>.
        /// If the function does not find a matching class and successfully copy the data, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Class atoms are created using the <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/> function,
        /// not the <see cref="GlobalAddAtom"/> function.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetClassInfoExW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetClassInfoEx([In]IntPtr hInstance, [In]StringHandle lpszClass, out WNDCLASSEX lpWndClass);

        /// <summary>
        /// <para>
        /// Retrieves the name of the class to which the specified window belongs.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getclassnamew
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window and, indirectly, the class to which the window belongs.
        /// </param>
        /// <param name="lpClassName">
        /// The class name string.
        /// </param>
        /// <param name="nMaxCount">
        /// The length of the <paramref name="lpClassName"/> buffer, in characters.
        /// The buffer must be large enough to include the terminating null character;
        /// otherwise, the class name string is truncated to <paramref name="nMaxCount"/>-1 characters.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the number of characters copied to the buffer, not including the terminating null character.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetClassName", SetLastError = true)]
        public static extern int GetClassName([In]IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)][In][Out]StringBuilder lpClassName, [In]int nMaxCount);

        /// <summary>
        /// Retrieves information about the specified window.
        /// The function also retrieves the 32-bit (DWORD) value at the specified offset into the extra window memory.
        /// </summary>
        /// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
        /// <param name="nIndex">
        /// The zero-based offset to the value to be retrieved. 
        /// Valid values are in the range zero through the number of bytes of extra window memory, minus four;
        /// for example, if you specified 12 or more bytes of extra memory, a value of 8 would be an index to the third 32-bit integer.
        /// To retrieve any other value, specify one of the following values.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the requested value.
        /// If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.
        /// If <see cref="SetWindowLong"/> has not been called previously,
        /// <see cref="GetWindowLong"/> returns zero for values in the extra window or class memory.
        /// </returns>   
        public static IntPtr GetWindowLong([In]IntPtr hWnd, [In]GetWindowLongIndexes nIndex) =>
            IntPtr.Size > 4 ? GetWindowLongPtrImp(hWnd, nIndex) : GetWindowLongImp(hWnd, nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongW", SetLastError = true)]
        private static extern IntPtr GetWindowLongImp(IntPtr hWnd, GetWindowLongIndexes nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtrW", SetLastError = true)]
        private static extern IntPtr GetWindowLongPtrImp(IntPtr hWnd, GetWindowLongIndexes nIndex);

        /// <summary>
        /// Retrieves the show state and the restored, minimized, and maximized positions of the specified window.
        /// </summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="lpwndpl">
        /// A pointer to a <see cref="WINDOWPLACEMENT"/> structure that specifies the new show state and window positions.
        /// Before calling <see cref="GetWindowPlacement"/>, set the <see cref="WINDOWPLACEMENT.length"/> member of
        /// the <see cref="WINDOWPLACEMENT"/> structure to <code>sizeof(WINDOWPLACEMENT)</code>.
        /// <see cref="SetWindowPlacement"/> fails if the <see cref="WINDOWPLACEMENT.length"/> member is not set correctly.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowPlacement", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowPlacement([In] IntPtr hWnd, [In][Out]ref WINDOWPLACEMENT lpwndpl);

        /// <summary>
        /// <para>
        /// Retrieves the identifier of the thread that created the specified window and, optionally, 
        /// the identifier of the process that created the window.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getwindowthreadprocessid
        /// </para>
        /// </summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="lpdwProcessId">
        /// A pointer to a variable that receives the process identifier. 
        /// If this parameter is not NULL, GetWindowThreadProcessId copies the identifier of the process to the variable; 
        /// otherwise, it does not.
        /// </param>
        /// <returns>The return value is the identifier of the thread that created the window.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowThreadProcessId", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, [Out]out uint lpdwProcessId);

        /// <summary>
        /// <para>
        /// Retrieves the dimensions of the bounding rectangle of the specified window.
        /// The dimensions are given in screen coordinates that are relative to the upper-left corner of the screen.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getwindowrect
        /// </para>
        /// </summary>
        /// <param name="hwnd">A handle to the window.</param>
        /// <param name="lpRect"
        /// >A <see cref="RECT"/> structure that receives the screen coordinates of the upper-left and lower-right corners of the window.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowRect", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect([In]IntPtr hwnd, [Out]out RECT lpRect);

        /// <summary>
        /// <para>
        /// Copies the text of the specified window's title bar (if it has one) into a buffer. 
        /// If the specified window is a control, the text of the control is copied. 
        /// However, <see cref="GetWindowText"/> cannot retrieve the text of a control in another application.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getwindowtextw
        /// </para>
        /// </summary>
        /// <param name="hWnd">A handle to the window or control containing the text.</param>
        /// <param name="lpString">
        /// The buffer that will receive the text.
        /// If the string is as long or longer than the buffer, the string is truncated and terminated with a null character.
        /// </param>
        /// <param name="nMaxCount">
        /// The maximum number of characters to copy to the buffer, including the null character.
        /// If the text exceeds this limit, it is truncated.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the length, in characters, of the copied string, not including the terminating null character.
        /// If the window has no title bar or text, if the title bar is empty, or if the window or control handle is invalid, 
        /// the return value is zero. To get extended error information, call <see cref="GetLastError"/>.
        /// This function cannot retrieve the text of an edit control in another application.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowTextW", SetLastError = true)]
        public static extern int GetWindowText([In]IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)][Out]StringBuilder lpString, [In]int nMaxCount);

        /// <summary>
        /// <para>
        /// Retrieves the length, in characters, of the specified window's title bar text (if the window has a title bar).
        /// If the specified window is a control, the function retrieves the length of the text within the control.
        /// However, <see cref="GetWindowTextLength"/> cannot retrieve the length of the text of an edit control in another application.
        /// </para>
        /// </summary>
        /// <param name="hWnd">A handle to the window or control.</param>
        /// <returns>
        /// If the function succeeds, the return value is the length, in characters, of the text.
        /// Under certain conditions, this value might be greater than the length of the text (see Remarks).
        /// If the window has no text, the return value is zero.
        /// Function failure is indicated by a return value of zero and a <see cref="GetLastError"/> result that is nonzero.
        /// This function does not clear the most recent error information.
        /// To determine success or failure, clear the most recent error information 
        /// by calling <see cref="SetLastError"/> with 0, then call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the target window is owned by the current process, <see cref="GetWindowTextLength"/> causes
        /// a <see cref="WM_GETTEXTLENGTH"/> message to be sent to the specified window or control.
        /// Under certain conditions, the <see cref="GetWindowTextLength"/> function may return a value that is larger than the actual length of the text.
        /// This occurs with certain mixtures of ANSI and Unicode, and is due to the system allowing for the possible existence
        /// of double-byte character set (DBCS) characters within the text.
        /// The return value, however, will always be at least as large as the actual length of the text;
        /// you can thus always use it to guide buffer allocation.
        /// This behavior can occur when an application uses both ANSI functions and common dialogs, which use Unicode.
        /// It can also occur when an application uses the ANSI version of <see cref="GetWindowTextLength"/> with a window whose window procedure is Unicode,
        /// or the Unicode version of <see cref="GetWindowTextLength"/> with a window whose window procedure is ANSI.
        /// For more information on ANSI and ANSI functions, see Conventions for Function Prototypes.
        /// To obtain the exact length of the text, use the <see cref="WM_GETTEXT"/>, <see cref="LB_GETTEXT"/>,
        /// or <see cref="CB_GETLBTEXT"/> messages, or the <see cref="GetWindowText"/> function.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowTextLength", SetLastError = true)]
        public static extern int GetWindowTextLength([In]IntPtr hWnd);

        /// <summary>
        /// <para>
        /// Registers a window class for subsequent use in calls to the <see cref="CreateWindow"/> or <see cref="CreateWindowEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-registerclassexw
        /// </para>
        /// </summary>
        /// <param name="Arg1">
        /// A pointer to a <see cref="WNDCLASSEX"/> structure.
        /// You must fill the structure with the appropriate class attributes before passing it to the function.</param>
        /// <returns>
        /// If the function succeeds, the return value is a class atom that uniquely identifies the class being registered.
        /// This atom can only be used by the <see cref="CreateWindow"/>, <see cref="CreateWindowEx"/>, <see cref="GetClassInfo"/>,
        /// <see cref="GetClassInfoEx"/>, <see cref="FindWindow"/>, <see cref="FindWindowEx"/>, and 
        /// <see cref="UnregisterClass"/> functions and the IActiveIMMap::FilterClientWindows method.
        /// If the function fails, the return value is zero.To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegisterClassExW", SetLastError = true)]
        public static extern ushort RegisterClassEx([In] ref WNDCLASSEX Arg1);

        /// <summary>
        /// <para>
        /// Brings the thread that created the specified window into the foreground and activates the window.
        /// Keyboard input is directed to the window, and various visual cues are changed for the user.
        /// The system assigns a slightly higher priority to the thread that created the foreground window than it does to other threads.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setforegroundwindow
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window that should be activated and brought to the foreground.
        /// </param>
        /// <returns>
        /// If the window was brought to the foreground, the return value is <see langword="true"/>.
        /// If the window was not brought to the foreground, the return value is <see langword="false"/>.
        /// </returns>
        /// <remarks>
        /// The system restricts which processes can set the foreground window.
        /// A process can set the foreground window only if one of the following conditions is true:
        /// The process is the foreground process.
        /// The process was started by the foreground process.
        /// The process received the last input event.
        /// There is no foreground process.
        /// The process is being debugged.
        /// The foreground process is not a Modern Application or the Start Screen.
        /// The foreground is not locked (see <see cref="LockSetForegroundWindow"/>).
        /// The foreground lock time-out has expired (see <see cref="SPI_GETFOREGROUNDLOCKTIMEOUT"/> in <see cref="SystemParametersInfo"/>).
        /// No menus are active.
        /// An application cannot force a window to the foreground while the user is working with another window
        /// Instead, Windows flashes the taskbar button of the window to notify the user.
        /// A process that can set the foreground window can enable another process to set the foreground window
        /// by calling the <see cref="AllowSetForegroundWindow"/> function.
        /// The process specified by dwProcessId loses the ability to set the foreground window the next time the user generates input,
        /// unless the input is directed at that process, or the next time a process calls <see cref="AllowSetForegroundWindow"/>,
        /// unless that process is specified.
        /// The foreground process can disable calls to <see cref="SetForegroundWindow"/> by calling the <see cref="LockSetForegroundWindow"/> function.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetForegroundWindow", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow([In]IntPtr hWnd);

        /// <summary>
        /// Changes an attribute of the specified window.
        /// The function also sets the 32-bit (long) value at the specified offset into the extra window memory.
        /// </summary>
        /// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
        /// <param name="nIndex">
        /// The zero-based offset to the value to be retrieved. 
        /// Valid values are in the range zero through the number of bytes of extra window memory, minus four;
        /// for example, if you specified 12 or more bytes of extra memory, a value of 8 would be an index to the third 32-bit integer.
        /// To retrieve any other value, specify one of the following values.
        /// </param>
        /// <param name="dwNewLong">The replacement value.</param>
        /// <returns>
        /// If the function succeeds, the return value is the previous value of the specified 32-bit integer.
        /// If the function fails, the return value is zero.To get extended error information, call <see cref="GetLastError"/>.
        /// If the previous value of the specified 32-bit integer is zero, and the function succeeds, the return value is zero, 
        /// but the function does not clear the last error information. This makes it difficult to determine success or failure.
        /// To deal with this, you should clear the last error information by calling SetLastError with 0 before calling <see cref="SetWindowLong"/>.
        /// Then, function failure will be indicated by a return value of zero and a <see cref="GetLastError"/> result that is nonzero.
        /// </returns>
        public static IntPtr SetWindowLong([In]IntPtr hWnd, [In]GetWindowLongIndexes nIndex, [In]IntPtr dwNewLong)
            => IntPtr.Size > 4 ? SetWindowLongPtrImp(hWnd, nIndex, dwNewLong) : SetWindowLongImp(hWnd, nIndex, dwNewLong);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongW", SetLastError = true)]
        private static extern IntPtr SetWindowLongImp(IntPtr hWnd, GetWindowLongIndexes nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtrW", SetLastError = true)]
        private static extern IntPtr SetWindowLongPtrImp(IntPtr hWnd, GetWindowLongIndexes nIndex, IntPtr dwNewLong);

        /// <summary>
        /// Sets the show state and the restored, minimized, and maximized positions of the specified window.
        /// </summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="lpwndpl">
        /// A pointer to a <see cref="WINDOWPLACEMENT"/> structure that specifies the new show state and window positions.
        /// Before calling <see cref="SetWindowPlacement"/>, set the <see cref="WINDOWPLACEMENT.length"/> member of
        /// the <see cref="WINDOWPLACEMENT"/> structure  to <code>sizeof(WINDOWPLACEMENT)</code>.
        /// <see cref="SetWindowPlacement"/> fails if the <see cref="WINDOWPLACEMENT.length"/> member is not set correctly.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowPlacement", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPlacement([In] IntPtr hWnd, [In] ref WINDOWPLACEMENT lpwndpl);

        /// <summary>
        /// <para>
        /// Changes the size, position, and Z order of a child, pop-up, or top-level window.
        /// These windows are ordered according to their appearance on the screen.
        /// The topmost window receives the highest rank and is the first window in the Z order.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setwindowpos
        /// </para>
        /// </summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="hWndInsertAfter">A handle to the window to precede the positioned window in the Z order.</param>
        /// <param name="X">The new position of the left side of the window, in client coordinates.</param>
        /// <param name="Y">The new position of the top of the window, in client coordinates.</param>
        /// <param name="cx">The new width of the window, in pixels.</param>
        /// <param name="cy">The new height of the window, in pixels.</param>
        /// <param name="uFlags">The window sizing and positioning flags. This parameter can be a combination of the following values.</param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowPos", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos([In]IntPtr hWnd, [In]IntPtr hWndInsertAfter, [In]int X, [In]int Y,
            [In]int cx, [In]int cy, [In]SetWindowPosFlags uFlags);

        /// <summary>
        /// <para>
        /// Changes the text of the specified window's title bar (if it has one). 
        /// If the specified window is a control, the text of the control is changed. 
        /// However, <see cref="SetWindowText"/> cannot change the text of a control in another application.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setwindowtextw
        /// </para>
        /// </summary>
        /// <param name="hWnd">A handle to the window or control whose text is to be changed.</param>
        /// <param name="lpString">The new title or control text.</param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowTextW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowText([In]IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)][In]string lpString);

        /// <summary>
        /// <para>
        /// Sets the specified window's show state.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-showwindow
        /// </para>
        /// </summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="nCmdShow">
        /// Controls how the window is to be shown. This parameter is ignored the first time an application calls <see cref="ShowWindow"/>,
        /// if the program that launched the application provides a <see cref="STARTUPINFO"/> structure.
        /// Otherwise, the first time <see cref="ShowWindow"/> is called, the value should be the value obtained by
        /// the WinMain function in its nCmdShow parameter.
        /// In subsequent calls, this parameter can be one of the following values.
        /// </param>
        /// <returns>
        /// If the window was previously visible, the return value is <see langword="true"/>.
        /// If the window was previously hidden, the return value is <see langword="false"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShowWindow", SetLastError = true)]
        public static extern bool ShowWindow([In]IntPtr hWnd, [In]ShowWindowCommands nCmdShow);

        /// <summary>
        /// <para>
        /// Updates the position, size, shape, content, and translucency of a layered window.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-updatelayeredwindow
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to a layered window. 
        /// A layered window is created by specifying <see cref="WS_EX_LAYERED"/> when creating the window
        /// with the <see cref="CreateWindowEx"/> function.
        /// Windows 8: <see cref="WS_EX_LAYERED"/> style is supported for top-level windows and child windows.
        /// Previous Windows versions support <see cref="WS_EX_LAYERED"/> only for top-level windows.
        /// </param>
        /// <param name="hdcDst">
        /// A handle to a DC for the screen. This handle is obtained by specifying <see cref="IntPtr.Zero"/> when calling the function.
        /// It is used for palette color matching when the window contents are updated.
        /// If <paramref name="hdcDst"/> is <see cref="IntPtr.Zero"/>, the default palette will be used.
        /// If <paramref name="hdcSrc"/> is <see cref="IntPtr.Zero"/>, <paramref name="hdcDst"/> must be <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <param name="pptDst">
        /// A structure that specifies the new screen position of the layered window.
        /// If the current position is not changing, <paramref name="pptDst"/> can be <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <param name="psize">
        /// A structure that specifies the new size of the layered window.
        /// If the size of the window is not changing, <paramref name="psize"/> can be <see cref="IntPtr.Zero"/>.
        /// If <paramref name="hdcSrc"/> is <see cref="IntPtr.Zero"/>, <paramref name="psize"/> must be <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <param name="hdcSrc">
        /// A handle to a DC for the surface that defines the layered window.
        /// This handle can be obtained by calling the <see cref="CreateCompatibleDC"/> function. 
        /// If the shape and visual context of the window are not changing, <paramref name="hdcSrc"/> can be <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <param name="pptSrc">
        /// A structure that specifies the location of the layer in the device context.
        /// If <paramref name="hdcSrc"/> is <see cref="IntPtr.Zero"/>, <paramref name="pptSrc"/> should be <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <param name="crKey">
        /// A structure that specifies the color key to be used when composing the layered window. 
        /// </param>
        /// <param name="pblend">
        /// A pointer to a structure that specifies the transparency value to be used when composing the layered window.
        /// </param>
        /// <param name="dwFlags">
        /// Flags. If <paramref name="hdcSrc"/> is <see cref="IntPtr.Zero"/>, <paramref name="dwFlags"/> should be zero.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "UpdateLayeredWindow", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UpdateLayeredWindow([In]IntPtr hwnd, [In]IntPtr hdcDst, [In]ref POINT pptDst, [In]ref SIZE psize,
            [In]IntPtr hdcSrc, [In]ref POINT pptSrc, [In]uint crKey, [In] ref BLENDFUNCTION pblend, [In]UpdateLayeredWindowFlags dwFlags);
    }
}
