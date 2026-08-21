using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.HeaderControlItemFilterTypes;
using static Lsj.Util.Win32.Enums.HeaderControlItemFormats;
using static Lsj.Util.Win32.Enums.HeaderControlItemMasks;
using static Lsj.Util.Win32.Enums.HeaderControlMessages;
using static Lsj.Util.Win32.Enums.HeaderControlNotifications;
using static Lsj.Util.Win32.Enums.HeaderControlStyles;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about an item in a header control.
    /// This structure supersedes the HD_ITEM structure.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commctrl/ns-commctrl-hditemw"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct HDITEM
    {
        /// <summary>
        /// HDIS_FOCUSED
        /// </summary>
        public const uint HDIS_FOCUSED = 0x00000001;

        /// <summary>
        /// <para>
        /// Flags indicating which other structure members contain valid data or must be filled in.
        /// This member can be a combination of the following values:
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
        /// <see cref="HDI_BITMAP"/>
        /// </term>
        /// <term>
        /// The hbm member is valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HDI_DI_SETITEM"/>
        /// </term>
        /// <term>
        /// While handling the message <see cref="HDM_GETITEM"/>, the header control may not have all the values needed to complete the request.
        /// In this case, the control must call the application back for the values via the <see cref="HDN_GETDISPINFO"/> notification.
        /// If <see cref="HDI_DI_SETITEM"/> has been passed in the <see cref="HDM_GETITEM"/> message,
        /// the control will cache any values returned from <see cref="HDN_GETDISPINFO"/> (otherwise the values remain unset.)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HDI_FORMAT"/>
        /// </term>
        /// <term>
        /// The <see cref="fmt"/> member is valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HDI_FILTER"/>
        /// </term>
        /// <term>
        /// The <see cref="type"/> and <see cref="pvFilter"/> members are valid.
        /// This is used to filter out the values specified in the <see cref="type"/> member.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HDI_HEIGHT"/>
        /// </term>
        /// <term>
        /// The same as <see cref="HDI_WIDTH"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HDI_IMAGE"/>
        /// </term>
        /// <term>
        /// The <see cref="iImage"/> member is valid and specifies the image to be displayed with the item.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HDI_LPARAM"/>
        /// </term>
        /// <term>
        /// The <see cref="lParam"/> member is valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HDI_ORDER"/>
        /// </term>
        /// <term>
        /// The <see cref="iOrder"/> member is valid and specifies the item's order value.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HDI_STATE"/>
        /// </term>
        /// <term>
        /// Version 6.00 and later. The state member is valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HDI_TEXT"/>
        /// </term>
        /// <term>
        /// The pszText and <see cref="cchTextMax"/> members are valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HDI_WIDTH"/>
        /// </term>
        /// <term>
        /// The cxy member is valid and specifies the item's width.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public HeaderControlItemMasks mask;

        /// <summary>
        /// The width or height of the item.
        /// </summary>
        public int cxy;

        /// <summary>
        /// A pointer to an item string.
        /// If the text is being retrieved from the control, this member must be initialized to point to a character buffer.
        /// If this member is set to <see cref="LPSTR_TEXTCALLBACK"/>, the control will request text information for this item
        /// by sending an <see cref="HDN_GETDISPINFO"/> notification code.
        /// Note that although the header control allows a string of any length to be stored as item text, only the first 260 TCHARs are displayed.
        /// </summary>
        public nint pszText;

        /// <summary>
        /// A handle to the item bitmap.
        /// </summary>
        public HBITMAP hbm;

        /// <summary>
        /// The length of the item string, in TCHARs.
        /// If the text is being retrieved from the control, this member must contain the number of TCHARs at the address specified by <see cref="pszText"/>.
        /// </summary>
        public int cchTextMax;

        /// <summary>
        /// <para>
        /// Flags that specify the item's format.
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
        /// Text Justification:
        /// </term>
        /// <term>
        /// Set one of the following flags to specify text justification:
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HDF_CENTER"/>
        /// </term>
        /// <term>
        /// The item's contents are centered.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HDF_LEFT"/>
        /// </term>
        /// <term>
        /// The item's contents are left-aligned.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HDF_RIGHT"/>
        /// </term>
        /// <term>
        /// The item's contents are right-aligned.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Display:
        /// </term>
        /// <term>
        /// Set one of the following flags to control the display:
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HDF_BITMAP"/>
        /// </term>
        /// <term>
        /// The item displays a bitmap.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HDF_BITMAP_ON_RIGHT"/>
        /// </term>
        /// <term>
        /// The bitmap appears to the right of text.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HDF_OWNERDRAW"/>
        /// </term>
        /// <term>
        /// The header control's owner draws the item.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HDF_STRING"/>
        /// </term>
        /// <term>
        /// The item displays a string.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Combining Flags:
        /// </term>
        /// <term>
        /// The preceding value can be combined with:
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HDF_IMAGE"/>
        /// </term>
        /// <term>
        /// Display an image from an image list. Specify the image list by sending an <see cref="HDM_SETIMAGELIST"/> message.
        /// Specify the index of the image in the <see cref="iImage"/> member of this structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HDF_JUSTIFYMASK"/>
        /// </term>
        /// <term>
        /// Isolate the bits corresponding to the three justification flags listed in the preceding table.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HDF_RTLREADING"/>
        /// </term>
        /// <term>
        /// Typically, windows displays text left-to-right (LTR).
        /// Windows can be mirrored to display languages such as Hebrew or Arabic that read right-to-left (RTL).
        /// Usually, header text is read in the same direction as the text in its parent window.
        /// If <see cref="HDF_RTLREADING"/> is set, header text will read in the opposite direction from the text in the parent window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HDF_SORTDOWN"/>
        /// </term>
        /// <term>
        /// Version 6.00 and later.
        /// Draws a down-arrow on this item.
        /// This is typically used to indicate that information in the current window is sorted on this column in descending order.
        /// This flag cannot be combined with <see cref="HDF_IMAGE"/> or <see cref="HDF_BITMAP"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HDF_SORTUP"/>
        /// </term>
        /// <term>
        /// Version 6.00 and later.
        /// Draws an up-arrow on this item.
        /// This is typically used to indicate that information in the current window is sorted on this column in ascending order.
        /// This flag cannot be combined with <see cref="HDF_IMAGE"/> or <see cref="HDF_BITMAP"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HDF_CHECKBOX"/>
        /// </term>
        /// <term>
        /// Version 6.00 and later.
        /// The item displays a checkbox.
        /// The flag is only valid when the <see cref="HDS_CHECKBOXES"/> style is first set on the header control.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HDF_CHECKED"/>
        /// </term>
        /// <term>
        /// Version 6.00 and later.
        /// The item displays a checked checkbox. The flag is only valid when HDF_CHECKBOX is also set.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HDF_FIXEDWIDTH"/>
        /// </term>
        /// <term>
        /// Version 6.00 and later.
        /// The width of the item cannot be modified by a user action to resize it.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HDF_SPLITBUTTON"/>
        /// </term>
        /// <term>
        /// Version 6.00 and later.
        /// The item displays a split button.
        /// The <see cref="HDN_DROPDOWN"/> notification is sent when the split button is clicked.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public HeaderControlItemFormats fmt;

        /// <summary>
        /// Application-defined item data.
        /// </summary>
        public LPARAM lParam;

        /// <summary>
        /// The zero-based index of an image within the image list.
        /// The specified image will be displayed in the header item in addition to any image specified in the hbm field.
        /// If <see cref="iImage"/> is set to <see cref="I_IMAGECALLBACK"/>,
        /// the control requests text information for this item by using an <see cref="HDN_GETDISPINFO"/> notification code.
        /// To clear the image, set this value to <see cref="I_IMAGENONE"/>.
        /// </summary>
        public int iImage;

        /// <summary>
        /// The order in which the item appears within the header control, from left to right.
        /// That is, the value for the far left item is 0. The value for the next item to the right is 1, and so on.
        /// </summary>
        public int iOrder;

        /// <summary>
        /// <para>
        /// The type of filter specified by pvFilter. The possible types include:
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
        /// <see cref="HDFT_ISSTRING"/>
        /// </term>
        /// <term>
        /// String data.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HDFT_ISNUMBER"/>
        /// </term>
        /// <term>
        /// Numerical data.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HDFT_HASNOVALUE"/>
        /// </term>
        /// <term>
        /// Ignore <see cref="pvFilter"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HDFT_ISDATE"/>
        /// </term>
        /// <term>
        /// Version 6.00 and later.
        /// Date data.
        /// The <see cref="pvFilter"/> member is a pointer to a <see cref="SYSTEMTIME"/> structure.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public HeaderControlItemFilterTypes type;

        /// <summary>
        /// The address of an application-defined data item.
        /// The data filter type is determined by setting the flag value of the member.
        /// Use the <see cref="HDFT_ISSTRING"/> flag to indicate a string and <see cref="HDFT_ISNUMBER"/> to indicate an integer.
        /// When the <see cref="HDFT_ISSTRING"/> flag is used <see cref="pvFilter"/> is a pointer to a <see cref="HDTEXTFILTER"/> structure.
        /// </summary>
        public nint pvFilter;

        /// <summary>
        /// <para>
        /// The state.
        /// The only valid, supported value for this member is the following:
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
        /// HDIS_FOCUSED
        /// </term>
        /// <term>
        /// The item has keyboard focus.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public UINT state;
    }
}
