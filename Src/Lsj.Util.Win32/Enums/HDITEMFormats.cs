using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Enums.HeaderControlMessages;
using static Lsj.Util.Win32.Enums.HeaderControlStyles;
using static Lsj.Util.Win32.Enums.HeaderControlNotifications;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="HDITEM"/> Formats
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commctrl/ns-commctrl-hditemw"/>
    /// </para>
    /// </summary>
    public enum HDITEMFormats : uint
    {
        /// <summary>
        /// The item's contents are centered.
        /// </summary>
        HDF_CENTER = 0x0002,

        /// <summary>
        /// The item's contents are left-aligned.
        /// </summary>
        HDF_LEFT = 0x0000,

        /// <summary>
        /// The item's contents are right-aligned.
        /// </summary>
        HDF_RIGHT = 0x0001,

        /// <summary>
        /// The item displays a bitmap.
        /// </summary>
        HDF_BITMAP = 0x2000,

        /// <summary>
        /// The bitmap appears to the right of text.
        /// </summary>
        HDF_BITMAP_ON_RIGHT = 0x1000,

        /// <summary>
        /// The header control's owner draws the item.
        /// </summary>
        HDF_OWNERDRAW = 0x8000,

        /// <summary>
        /// The item displays a string.
        /// </summary>
        HDF_STRING = 0x4000,

        /// <summary>
        /// Display an image from an image list.
        /// Specify the image list by sending an <see cref="HDM_SETIMAGELIST"/> message.
        /// Specify the index of the image in the iImage member of this structure.
        /// </summary>
        HDF_IMAGE = 0x0800,

        /// <summary>
        /// Isolate the bits corresponding to the three justification flags listed in the preceding table.
        /// </summary>
        HDF_JUSTIFYMASK = 0x0003,

        /// <summary>
        /// Typically, windows displays text left-to-right (LTR).
        /// Windows can be mirrored to display languages such as Hebrew or Arabic that read right-to-left (RTL).
        /// Usually, header text is read in the same direction as the text in its parent window.
        /// If <see cref="HDF_RTLREADING"/> is set, header text will read in the opposite direction from the text in the parent window.
        /// </summary>
        HDF_RTLREADING = 0x0004,

        /// <summary>
        /// Version 6.00 and later.
        /// Draws a down-arrow on this item.
        /// This is typically used to indicate that information in the current window is sorted on this column in descending order.
        /// This flag cannot be combined with <see cref="HDF_IMAGE"/> or <see cref="HDF_BITMAP"/>.
        /// </summary>
        HDF_SORTDOWN = 0x0200,

        /// <summary>
        /// Version 6.00 and later.
        /// Draws an up-arrow on this item.
        /// This is typically used to indicate that information in the current window is sorted on this column in ascending order.
        /// This flag cannot be combined with <see cref="HDF_IMAGE"/> or <see cref="HDF_BITMAP"/>.
        /// </summary>
        HDF_SORTUP = 0x0400,

        /// <summary>
        /// Version 6.00 and later.
        /// The item displays a checkbox.
        /// The flag is only valid when the <see cref="HDS_CHECKBOXES"/> style is first set on the header control.
        /// </summary>
        HDF_CHECKBOX = 0x0040,

        /// <summary>
        /// Version 6.00 and later.
        /// The item displays a checked checkbox.
        /// The flag is only valid when <see cref="HDF_CHECKBOX"/> is also set.
        /// </summary>
        HDF_CHECKED = 0x0080,

        /// <summary>
        /// Version 6.00 and later.
        /// The width of the item cannot be modified by a user action to resize it.
        /// </summary>
        HDF_FIXEDWIDTH = 0x0100,

        /// <summary>
        /// Version 6.00 and later.
        /// The item displays a split button.
        /// The <see cref="HDN_DROPDOWN"/> notification is sent when the split button is clicked.
        /// </summary>
        HDF_SPLITBUTTON = 0x1000000,
    }
}
