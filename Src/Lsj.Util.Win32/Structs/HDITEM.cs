using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.HDITEMFilterType;
using static Lsj.Util.Win32.Enums.HDITEMFormats;
using static Lsj.Util.Win32.Enums.HDITEMMMasks;
using static Lsj.Util.Win32.Enums.HeaderControlNotifications;

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
        /// Flags indicating which other structure members contain valid data or must be filled in.
        /// This member can be a combination of the following values:
        /// <see cref="HDI_BITMAP"/>, <see cref="HDI_DI_SETITEM"/>, <see cref="HDI_FORMAT"/>, <see cref="HDI_FILTER"/>,
        /// <see cref="HDI_HEIGHT"/>, <see cref="HDI_IMAGE"/>, <see cref="HDI_LPARAM"/>, <see cref="HDI_ORDER"/>,
        /// <see cref="HDI_STATE"/>, <see cref="HDI_TEXT"/>, <see cref="HDI_WIDTH"/>
        /// </summary>
        public HDITEMMMasks mask;

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
        public IntPtr pszText;

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
        /// Flags that specify the item's format.
        /// Text Justification:
        /// Set one of the following flags to specify text justification:
        /// <see cref="HDF_CENTER"/>, <see cref="HDF_LEFT"/>, <see cref="HDF_RIGHT"/>
        /// Display:
        /// Set one of the following flags to control the display:
        /// <see cref="HDF_BITMAP"/>, <see cref="HDF_BITMAP_ON_RIGHT"/>, <see cref="HDF_OWNERDRAW"/>, <see cref="HDF_STRING"/>
        /// Combining Flags:
        /// The preceding value can be combined with:
        /// <see cref="HDF_IMAGE"/>, <see cref="HDF_JUSTIFYMASK"/>, <see cref="HDF_RTLREADING"/>, <see cref="HDF_SORTDOWN"/>,
        /// <see cref="HDF_SORTUP"/>, <see cref="HDF_CHECKBOX"/>, <see cref="HDF_CHECKED"/>, <see cref="HDF_FIXEDWIDTH"/>, <see cref="HDF_SPLITBUTTON"/>
        /// </summary>
        public HDITEMFormats fmt;

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
        /// The type of filter specified by <see cref="pvFilter"/>.
        /// The possible types include:
        /// <see cref="HDFT_ISSTRING"/>, <see cref="HDFT_ISNUMBER"/>, <see cref="HDFT_HASNOVALUE"/>, <see cref="HDFT_ISDATE"/>
        /// </summary>
        public HDITEMFilterType type;

        /// <summary>
        /// The address of an application-defined data item.
        /// The data filter type is determined by setting the flag value of the member.
        /// Use the <see cref="HDFT_ISSTRING"/> flag to indicate a string and <see cref="HDFT_ISNUMBER"/> to indicate an integer.
        /// When the <see cref="HDFT_ISSTRING"/> flag is used <see cref="pvFilter"/> is a pointer to a <see cref="HDTEXTFILTER"/> structure.
        /// </summary>
        public IntPtr pvFilter;

        /// <summary>
        /// The state.
        /// The only valid, supported value for this member is the following:
        /// <see cref="HDIS_FOCUSED"/>: The item has keyboard focus.
        /// </summary>
        public UINT state;
    }
}
