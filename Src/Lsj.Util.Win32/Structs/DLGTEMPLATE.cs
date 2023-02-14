using Lsj.Util.Win32.Enums;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Defines the dimensions and style of a dialog box.
    /// This structure, always the first in a standard template for a dialog box,
    /// also specifies the number of controls in the dialog box and therefore specifies
    /// the number of subsequent <see cref="DLGITEMTEMPLATE"/> structures in the template.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-dlgtemplate"/>
    /// </para>
    /// </summary>
    public struct DLGTEMPLATE
    {
        /// <summary>
        /// The style of the dialog box.
        /// This member can be a combination of window style values (such as <see cref="WindowStyles.WS_CAPTION"/> and <see cref="WindowStyles.WS_SYSMENU"/>)
        /// and dialog box style values (such as <see cref="DialogBoxStyles.DS_CENTER"/>).
        /// If the style member includes the <see cref="DialogBoxStyles.DS_SETFONT"/> style,
        /// the header of the dialog box template contains additional data specifying the font to use for text in the client area and
        /// controls of the dialog box.
        /// The font data begins on the WORD boundary that follows the title array.
        /// The font data specifies a 16-bit point size value and a Unicode font name string.
        /// If possible, the system creates a font according to the specified values.
        /// Then the system sends a <see cref="WindowMessages.WM_SETFONT"/> message to the dialog box and to each control to provide a handle to the font.
        /// If <see cref="DialogBoxStyles.DS_SETFONT"/> is not specified, the dialog box template does not include the font data.
        /// The <see cref="DialogBoxStyles.DS_SHELLFONT"/> style is not supported in the <see cref="DLGTEMPLATE"/> header.
        /// </summary>
        /// <remarks>
        /// In a standard template for a dialog box, the <see cref="DLGTEMPLATE"/> structure is always immediately
        /// followed by three variable-length arrays that specify the menu, class, and title for the dialog box.
        /// When the <see cref="DialogBoxStyles.DS_SETFONT"/> style is specified, these arrays are also followed
        /// by a 16-bit value specifying point size and another variable-length array specifying a typeface name.
        /// Each array consists of one or more 16-bit elements.
        /// The menu, class, title, and font arrays must be aligned on WORD boundaries.
        /// Immediately following the <see cref="DLGTEMPLATE"/> structure is a menu array that identifies a menu resource for the dialog box.
        /// If the first element of this array is 0x0000, the dialog box has no menu and the array has no other elements.
        /// If the first element is 0xFFFF, the array has one additional element that specifies the ordinal value of a menu resource in an executable file.
        /// If the first element has any other value, the system treats the array as a null-terminated Unicode string that specifies
        /// the name of a menu resource in an executable file.
        /// Following the menu array is a class array that identifies the window class of the control.
        /// If the first element of the array is 0x0000, the system uses the predefined dialog box class for the dialog box and
        /// the array has no other elements.
        /// If the first element is 0xFFFF, the array has one additional element that specifies the ordinal value of a predefined system window class.
        /// If the first element has any other value, the system treats the array as a null-terminated Unicode string that specifies
        /// the name of a registered window class.
        /// Following the class array is a title array that specifies a null-terminated Unicode string that contains the title of the dialog box.
        /// If the first element of this array is 0x0000, the dialog box has no title and the array has no other elements.
        /// The 16-bit point size value and the typeface array follow the title array,
        /// but only if the style member specifies the <see cref="DialogBoxStyles.DS_SETFONT"/> style.
        /// The point size value specifies the point size of the font to use for the text in the dialog box and its controls.
        /// The typeface array is a null-terminated Unicode string specifying the name of the typeface for the font.
        /// When these values are specified, the system creates a font having the specified size and typeface (if possible) and
        /// sends a <see cref="WindowMessages.WM_SETFONT"/> message to the dialog box procedure and the control window procedures
        /// as it creates the dialog box and controls.
        /// Following the <see cref="DLGTEMPLATE"/> header in a standard dialog box template are
        /// one or more <see cref="DLGITEMTEMPLATE"/> structures that define the dimensions and style of the controls in the dialog box.
        /// The cdit member specifies the number of <see cref="DLGITEMTEMPLATE"/> structures in the template.
        /// These <see cref="DLGITEMTEMPLATE"/> structures must be aligned on DWORD boundaries.
        /// If you specify character strings in the menu, class, title, or typeface arrays, you must use Unicode strings.
        /// The <see cref="x"/>, <see cref="y"/>, <see cref="cx"/>, and <see cref="cy"/> members specify values in dialog box units.
        /// You can convert these values to screen units (pixels) by using the <see cref="MapDialogRect"/> function.
        /// </remarks>
        public WindowStyles style;

        /// <summary>
        /// The extended styles for a window.
        /// This member is not used to create dialog boxes, but applications that use dialog box templates can use it to create other types of windows.
        /// For a list of values, see Extended Window Styles.
        /// </summary>
        public WindowStylesEx dwExtendedStyle;

        /// <summary>
        /// The number of items in the dialog box.
        /// </summary>
        public ushort cdit;

        /// <summary>
        /// The x-coordinate, in dialog box units, of the upper-left corner of the dialog box.
        /// </summary>
        public short x;

        /// <summary>
        /// The y-coordinate, in dialog box units, of the upper-left corner of the dialog box.
        /// </summary>
        public short y;

        /// <summary>
        /// The width, in dialog box units, of the dialog box.
        /// </summary>
        public short cx;

        /// <summary>
        /// The height, in dialog box units, of the dialog box.
        /// </summary>
        public short cy;
    }
}
