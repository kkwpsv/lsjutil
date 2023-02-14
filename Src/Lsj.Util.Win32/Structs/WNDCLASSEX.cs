using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains window class information. It is used with the <see cref="RegisterClassEx"/> and <see cref="GetClassInfoEx"/> functions.
    /// The <see cref="WNDCLASSEX"/> structure is similar to the <see cref="WNDCLASS"/> structure. There are two differences.
    /// <see cref="WNDCLASSEX"/> includes the <see cref="cbSize"/> member, which specifies the size of the structure, 
    /// and the <see cref="hIconSm"/> member, which contains a handle to a small icon associated with the window class.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-tagwndclassexw"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WNDCLASSEX
    {
        /// <summary>
        /// The size, in bytes, of this structure. Set this member to sizeof(WNDCLASSEX).
        /// Be sure to set this member before calling the <see cref="GetClassInfoEx"/> function.
        /// </summary>
        public UINT cbSize;

        /// <summary>
        /// The class style(s). This member can be any combination of the <see cref="ClassStyles"/>.
        /// </summary>
        public ClassStyles style;

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
        /// If an application uses <see cref="WNDCLASSEX"/> to register a dialog box created by using the CLASS directive in the resource file,
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
        /// A handle to the class background brush.
        /// This member can be a handle to the brush to be used for painting the background, or it can be a color value.
        /// The system automatically deletes class background brushes when the class is unregistered by using <see cref="UnregisterClass"/>.
        /// An application should not delete these brushes.
        /// When this member is <see cref="IntPtr.Zero"/>, an application must paint its own background whenever
        /// it is requested to paint in its client area.
        /// To determine whether the background must be painted, an application can either process
        /// the <see cref="WindowMessages.WM_ERASEBKGND"/> message or test the fErase member of the <see cref="PAINTSTRUCT"/> structure
        /// filled by the <see cref="BeginPaint"/> function.
        /// </summary>
        public HBRUSH hbrBackground;

        /// <summary>
        /// Pointer to a null-terminated character string that specifies the resource name of the class menu, as the name appears in the resource file.
        /// Or an Integer to identify the menu.
        /// If this member is <see cref="IntPtr.Zero"/>, windows belonging to this class have no default menu.
        /// </summary>
        public IntPtr lpszMenuName;

        /// <summary>
        /// A pointer to a null-terminated string or is an atom.
        /// If this parameter is an atom, it must be a class atomcreated by a previous call to
        /// the <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/> function.
        /// The atom must be in the low-order word of <see cref="lpszClassName"/>; the high-order word must be zero.
        /// If <see cref="lpszClassName"/> is a string, it specifies the window class name.
        /// The class name can be any name registered with <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/>,
        /// or any of the predefined control-class names.
        /// The maximum length for <see cref="lpszClassName"/> is 256.
        /// If <see cref="lpszClassName"/> is greater than the maximum length, the <see cref="RegisterClassEx"/> function will fail.
        /// </summary>
        public IntPtr lpszClassName;

        /// <summary>
        /// A handle to a small icon that is associated with the window class.
        /// If this member is NULL, the system searches the icon resource specified by the hIcon member fo
        /// r an icon of the appropriate size to use as the small icon.
        /// </summary>
        public HICON hIconSm;
    }


}
