using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.ButtonStyles;
using static Lsj.Util.Win32.Enums.EditControlStyles;
using static Lsj.Util.Win32.Enums.WindowStyles;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Defines the dimensions and style of a control in a dialog box.
    /// One or more of these structures are combined with a <see cref="DLGTEMPLATE"/> structure to form a standard template for a dialog box.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-dlgitemtemplate
    /// </para>
    /// </summary>
    /// <remarks>
    /// In a standard template for a dialog box, the <see cref="DLGITEMTEMPLATE"/> structure is always immediately followed
    /// by three variable-length arrays specifying the class, title, and creation data for the control.
    /// Each array consists of one or more 16-bit elements.
    /// Each <see cref="DLGITEMTEMPLATE"/> structure in the template must be aligned on a DWORD boundary.
    /// The class and title arrays must be aligned on WORD boundaries.
    /// The creation data array must be aligned on a WORD boundary.
    /// Immediately following each <see cref="DLGITEMTEMPLATE"/> structure is a class array that specifies the window class of the control.
    /// If the first element of this array is any value other than 0xFFFF, the system treats the array as a null-terminated Unicode string
    /// that specifies the name of a registered window class.
    /// If the first element is 0xFFFF, the array has one additional element that specifies the ordinal value of a predefined system class.
    /// The ordinal can be one of the following atom values.
    /// 0x0080: Button
    /// 0x0081: Edit
    /// 0x0082: Static
    /// 0x0083: List box
    /// 0x0084: Scroll bar
    /// 0x0085: Combo box
    /// Following the class array is a title array that contains the initial text or resource identifier of the control.
    /// If the first element of this array is 0xFFFF, the array has one additional element that specifies an ordinal value of a resource,
    /// such as an icon, in an executable file.
    /// You can use a resource identifier for controls, such as static icon controls, that load and display an icon or other resource rather than text.
    /// If the first element is any value other than 0xFFFF, the system treats the array as a null-terminated Unicode string
    /// that specifies the initial text.
    /// The creation data array begins at the next WORD boundary after the title array.
    /// This creation data can be of any size and format.
    /// If the first word of the creation data array is nonzero, it indicates the size, in bytes, of the creation data (including the size word).
    /// The control's window procedure must be able to interpret the data.
    /// When the system creates the control, it passes a pointer to this data in the lParam parameter
    /// of the <see cref="WindowsMessages.WM_CREATE"/> message that it sends to the control.
    /// If you specify character strings in the class and title arrays, you must use Unicode strings.
    /// Use the <see cref="MultiByteToWideChar"/> function to generate Unicode strings from ANSI strings.
    /// The <see cref="x"/>, <see cref="y"/>, <see cref="cx"/>, and <see cref="cy"/> members specify values in dialog box units.
    /// You can convert these values to screen units (pixels) by using the <see cref="MapDialogRect"/> function.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DLGITEMTEMPLATE
    {
        /// <summary>
        /// The style of the control. This member can be a combination of window style values (such as <see cref="WS_BORDER"/>) and
        /// one or more of the control style values (such as <see cref="BS_PUSHBUTTON"/> and <see cref="ES_LEFT"/>).
        /// </summary>
        public WindowStyles style;

        /// <summary>
        /// The extended styles for a window. This member is not used to create controls in dialog boxes,
        /// but applications that use dialog box templates can use it to create other types of windows.
        /// For a list of values, see Extended Window Styles.
        /// </summary>
        public WindowStylesEx dwExtendedStyle;

        /// <summary>
        /// The x-coordinate, in dialog box units, of the upper-left corner of the control.
        /// This coordinate is always relative to the upper-left corner of the dialog box's client area.
        /// </summary>
        public short x;

        /// <summary>
        /// The y-coordinate, in dialog box units, of the upper-left corner of the control.
        /// This coordinate is always relative to the upper-left corner of the dialog box's client area.
        /// </summary>
        public short y;

        /// <summary>
        /// The width, in dialog box units, of the control.
        /// </summary>
        public short cx;

        /// <summary>
        /// The height, in dialog box units, of the control.
        /// </summary>
        public short cy;

        /// <summary>
        /// The control identifier.
        /// </summary>
        public WORD id;
    }
}
