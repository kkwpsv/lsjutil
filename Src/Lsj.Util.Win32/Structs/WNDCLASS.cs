using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.SystemColors;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains the window class attributes that are registered by the <see cref="RegisterClass"/> function.
    /// </para>
    /// <para>
    /// This structure has been superseded by the <see cref="WNDCLASSEX"/> structure used with the <see cref="RegisterClassEx"/> function.
    /// You can still use <see cref="WNDCLASS"/> and <see cref="RegisterClass"/>
    /// if you do not need to set the small icon associated with the window class.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-wndclassw"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WNDCLASS
    {
        /// <summary>
        /// The class style(s). This member can be any combination of the <see cref="WindowClassStyles"/>.
        /// </summary>
        public WindowClassStyles style;

        /// <summary>
        /// A pointer to the window procedure. You must use the <see cref="CallWindowProc"/> function to call the window procedure.
        /// For more information, see <see cref="WNDPROC"/>.
        /// </summary>
        public WNDPROC lpfnWndProc;

        /// <summary>
        /// The number of extra bytes to allocate following the window-class structure. The system initializes the bytes to zero.
        /// </summary>
        public int cbClsExtra;

        /// <summary>
        /// The number of extra bytes to allocate following the window instance. The system initializes the bytes to zero.
        /// If an application uses <see cref="WNDCLASS"/> to register a dialog box created by using the CLASS directive in the resource file,
        /// it must set this member to <see cref="DLGWINDOWEXTRA"/>.
        /// </summary>
        public int cbWndExtra;

        /// <summary>
        /// A handle to the instance that contains the window procedure for the class.
        /// </summary>
        public HINSTANCE hInstance;

        /// <summary>
        /// A handle to the class icon. This member must be a handle to an icon resource.
        /// If this member is <see cref="IntPtr.Zero"/>, the system provides a default icon.
        /// </summary>
        public HICON hIcon;

        /// <summary>
        /// A handle to the class cursor. This member must be a handle to a cursor resource.
        /// If this member is <see cref="IntPtr.Zero"/>,
        /// an application must explicitly set the cursor shape whenever the mouse moves into the application's window.
        /// </summary>
        public HCURSOR hCursor;

        /// <summary>
        /// <para>
        /// A handle to the class background brush.
        /// This member can be a handle to the physical brush to be used for painting the background, or it can be a color value.
        /// A color value must be one of the following standard system colors (the value 1 must be added to the chosen color).
        /// If a color value is given, you must convert it to one of the following <see cref="HBRUSH"/> types:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="COLOR_ACTIVEBORDER"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="COLOR_ACTIVECAPTION"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="COLOR_APPWORKSPACE"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="COLOR_BACKGROUND"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="COLOR_BTNFACE"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="COLOR_BTNSHADOW"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="COLOR_BTNTEXT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="COLOR_CAPTIONTEXT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="COLOR_GRAYTEXT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="COLOR_HIGHLIGHT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="COLOR_HIGHLIGHTTEXT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="COLOR_INACTIVEBORDER"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="COLOR_INACTIVECAPTION"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="COLOR_MENU"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="COLOR_MENUTEXT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="COLOR_SCROLLBAR"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="COLOR_WINDOW"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="COLOR_WINDOWFRAME"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="COLOR_WINDOWTEXT"/>
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// The system automatically deletes class background brushes when the class is unregistered by using <see cref="UnregisterClass"/>.
        /// An application should not delete these brushes.
        /// </para>
        /// <para>
        /// When this member is <see cref="NULL"/>,
        /// an application must paint its own background whenever it is requested to paint in its client area.
        /// To determine whether the background must be painted,
        /// an application can either process the <see cref="WM_ERASEBKGND"/> message
        /// or test the <see cref="PAINTSTRUCT.fErase"/> member of the <see cref="PAINTSTRUCT"/> structure
        /// filled by the <see cref="BeginPaint"/> function.
        /// </para>
        /// </summary>
        public HBRUSH hbrBackground;

        /// <summary>
        /// The resource name of the class menu, as the name appears in the resource file.
        /// If you use an integer to identify the menu, use the <see cref="MAKEINTRESOURCE"/> macro.
        /// If this member is <see cref="NULL"/>, windows belonging to this class have no default menu.
        /// </summary>
        public IntPtr lpszMenuName;

        /// <summary>
        /// <para>
        /// A pointer to a null-terminated string or is an atom.
        /// If this parameter is an atom, it must be a class atom created
        /// by a previous call to the <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/> function.
        /// The atom must be in the low-order word of lpszClassName; the high-order word must be zero.
        /// </para>
        /// <para>
        /// If <see cref="lpszClassName"/> is a string, it specifies the window class name.
        /// The class name can be any name registered with <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/>,
        /// or any of the predefined control-class names.
        /// </para>
        /// <para>
        /// The maximum length for <see cref="lpszClassName"/> is 256.
        /// If <see cref="lpszClassName"/> is greater than the maximum length, the <see cref="RegisterClass"/> function will fail.
        /// </para>
        /// </summary>
        public IntPtr lpszClassName;
    }
}
