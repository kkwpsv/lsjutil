using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.COMBOBOXEXITEMFlags;
using static Lsj.Util.Win32.Enums.ComboBoxExNotifications;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about an item in a ComboBoxEx control.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/ns-commctrl-comboboxexitemw"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct COMBOBOXEXITEM
    {
        /// <summary>
        /// A set of bit flags that specify attributes of this structure or of an operation that is using this structure.
        /// The flags specify members that are valid or must be filled in.
        /// This member can be a combination of the following values.
        /// <see cref="CBEIF_TEXT"/>, <see cref="CBEIF_IMAGE"/>, <see cref="CBEIF_SELECTEDIMAGE"/>, <see cref="CBEIF_OVERLAY"/>,
        /// <see cref="CBEIF_INDENT"/>, <see cref="CBEIF_LPARAM"/>, <see cref="CBEIF_DI_SETITEM"/>
        /// </summary>
        public COMBOBOXEXITEMFlags mask;

        /// <summary>
        /// The zero-based index of the item.
        /// </summary>
        public INT_PTR iItem;

        /// <summary>
        /// A pointer to a character buffer that contains or receives the item's text.
        /// If text information is being retrieved, this member must be set to the address of a character buffer that will receive the text.
        /// The size of this buffer must also be indicated in <see cref="cchTextMax"/>.
        /// If this member is set to <see cref="LPSTR_TEXTCALLBACK"/>,
        /// the control will request the information by using the <see cref="CBEN_GETDISPINFO"/> notification codes.
        /// </summary>
        public IntPtr pszText;

        /// <summary>
        /// The length of <see cref="pszText"/>, in TCHARs.
        /// If text information is being set, this member is ignored.
        /// </summary>
        public int cchTextMax;

        /// <summary>
        /// The zero-based index of an image within the image list.
        /// The specified image will be displayed for the item when it is not selected.
        /// If this member is set to <see cref="I_IMAGECALLBACK"/>,
        /// the control will request the information by using <see cref="CBEN_GETDISPINFO"/> notification codes.
        /// </summary>
        public int iImage;

        /// <summary>
        /// The zero-based index of an image within the image list.
        /// The specified image will be displayed for the item when it is selected.
        /// If this member is set to <see cref="I_IMAGECALLBACK"/>,
        /// the control will request the information by using <see cref="CBEN_GETDISPINFO"/> notification codes.
        /// </summary>
        public int iSelectedImage;

        /// <summary>
        /// The one-based index of an overlay image within the image list.
        /// If this member is set to <see cref="I_IMAGECALLBACK"/>,
        /// the control will request the information by using <see cref="CBEN_GETDISPINFO"/> notification codes.
        /// </summary>
        public int iOverlay;

        /// <summary>
        /// The number of indent spaces to display for the item.
        /// Each indentation equals 10 pixels. 
        /// If this member is set to <see cref="I_INDENTCALLBACK"/>,
        /// the control will request the information by using <see cref="CBEN_GETDISPINFO"/> notification codes.
        /// </summary>
        public int iIndent;

        /// <summary>
        /// A value specific to the item.
        /// </summary>
        public LPARAM lParam;
    }
}
