using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Defines the initialization parameters passed to the window procedure of an application.
    /// These members are identical to the parameters of the <see cref="CreateWindowEx"/> function.
    /// </para>
    /// </summary>
    /// <remarks>
    /// Because the <see cref="lpszClass"/> member can contain a pointer to a local (and thus inaccessable) atom,
    /// do not obtain the class name by using this member.
    /// Use the <see cref="GetClassName"/> function instead.
    /// You should access the data represented by the <see cref="lpCreateParams"/> member using a pointer that
    /// has been declared using the UNALIGNED type, because the pointer may not be DWORD aligned.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CREATESTRUCT
    {
        /// <summary>
        /// Contains additional data which may be used to create the window.
        /// If the window is being created as a result of a call to the <see cref="CreateWindow"/> or <see cref="CreateWindowEx"/> function,
        /// this member contains the value of the lpParam parameter specified in the function call.
        /// If the window being created is a MDI client window, this member contains a pointer to a <see cref="CLIENTCREATESTRUCT"/> structure.
        /// If the window being created is a MDI child window, this member contains a pointer to an <see cref="MDICREATESTRUCT"/> structure.
        /// If the window is being created from a dialog template, this member is the address of a SHORT value that specifies the size,
        /// in bytes, of the window creation data.
        /// The value is immediately followed by the creation data.
        /// For more information, see the following Remarks section.
        /// </summary>
        public IntPtr lpCreateParams;

        /// <summary>
        /// A handle to the module that owns the new window.
        /// </summary>
        public IntPtr hInstance;

        /// <summary>
        /// A handle to the menu to be used by the new window.
        /// </summary>
        public IntPtr hMenu;

        /// <summary>
        /// A handle to the parent window, if the window is a child window.
        /// If the window is owned, this member identifies the owner window.
        /// If the window is not a child or owned window, this member is <see cref="IntPtr.Zero"/>.
        /// </summary>
        public IntPtr hwndParent;

        /// <summary>
        /// The height of the new window, in pixels.
        /// </summary>
        public int cy;

        /// <summary>
        /// The width of the new window, in pixels.
        /// </summary>
        public int cx;

        /// <summary>
        /// The y-coordinate of the upper left corner of the new window.
        /// If the new window is a child window, coordinates are relative to the parent window.
        /// Otherwise, the coordinates are relative to the screen origin.
        /// </summary>
        public int y;

        /// <summary>
        /// The x-coordinate of the upper left corner of the new window.
        /// If the new window is a child window, coordinates are relative to the parent window.
        /// Otherwise, the coordinates are relative to the screen origin.
        /// </summary>
        public int x;

        /// <summary>
        /// The style for the new window. For a list of possible values, see Window Styles.
        /// </summary>
        public WindowStyles style;

        /// <summary>
        /// The name of the new window.
        /// </summary>
        public IntPtr lpszName;

        /// <summary>
        /// A pointer to a null-terminated string or an atom that specifies the class name of the new window.
        /// </summary>
        public IntPtr lpszClass;

        /// <summary>
        /// The extended window style for the new window. For a list of possible values, see Extended Window Styles.
        /// </summary>
        public WindowStylesEx dwExStyle;
    }
}
