using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Enums.HDITEMFormats;
using static Lsj.Util.Win32.Enums.HDITEMMMasks;
using static Lsj.Util.Win32.Enums.HeaderControlMessages;
using static Lsj.Util.Win32.Enums.HeaderControlNotifications;
using static Lsj.Util.Win32.Enums.HeaderControlStyles;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Macros
{
    /// <summary>
    /// Header Control Macros
    /// </summary>
    public static class HeaderControlMacros
    {
        /// <summary>
        /// <para>
        /// Clears the filter for a given header control.
        /// You can use this macro or send the <see cref="HDM_CLEARFILTER"/> message explicitly.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/nf-commctrl-header_clearfilter"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the header control.
        /// </param>
        /// <param name="i">
        /// A value specifying the column of the filter to be cleared. Specifying -1 will clear all of the filters.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// If the column value is specified as -1, all the filters will be cleared and the <see cref="HDN_FILTERCHANGE"/> notification will be sent only once.
        /// </remarks>
        public static int Header_ClearFilter(HWND hwnd, int i) => (int)SendMessage(hwnd, (WindowMessages)HDM_CLEARFILTER, i, 0);

        /// <summary>
        /// <para>
        /// Creates a transparent version of an item image within an existing header control.
        /// You can use this macro or send the <see cref="HDM_CREATEDRAGIMAGE"/> message explicitly.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/nf-commctrl-header_createdragimage"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to a header control.
        /// </param>
        /// <param name="i">
        /// A zero-based index of the item within the header control.
        /// The image assigned to this item is used as the basis for the transparent image.
        /// </param>
        /// <returns></returns>
        public static HIMAGELIST Header_CreateDragImage(HWND hwnd, int i) => (IntPtr)SendMessage(hwnd, (WindowMessages)HDM_CREATEDRAGIMAGE, i, 0);

        /// <summary>
        /// <para>
        /// Deletes an item from a header control.
        /// You can use this macro or send the <see cref="HDM_DELETEITEM"/> message explicitly.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/nf-commctrl-header_deleteitem"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to a header control.
        /// </param>
        /// <param name="i">
        /// An index of the item to delete.
        /// </param>
        /// <returns></returns>
        public static BOOL Header_DeleteItem(HWND hwnd, int i) => (int)SendMessage(hwnd, (WindowMessages)HDM_DELETEITEM, i, 0);

        /// <summary>
        /// <para>
        /// Gets the width of the margin (in pixels) of a bitmap in an existing header control.
        /// You can use this macro or send the <see cref="HDM_GETBITMAPMARGIN"/> message explicitly.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/nf-commctrl-header_getbitmapmargin"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to a header control.
        /// </param>
        /// <returns></returns>
        public static int Header_GetBitmapMargin(HWND hwnd) => (int)SendMessage(hwnd, (WindowMessages)HDM_GETBITMAPMARGIN, 0, 0);

        /// <summary>
        /// <para>
        /// Gets the item in a header control that has the focus.
        /// Use this macro or send the <see cref="HDM_GETFOCUSEDITEM"/> message explicitly.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/nf-commctrl-header_getfocuseditem"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to a header control.
        /// </param>
        /// <returns></returns>
        public static int Header_GetFocusedItem(HWND hwnd) => (int)SendMessage(hwnd, (WindowMessages)HDM_GETFOCUSEDITEM, 0, 0);

        /// <summary>
        /// <para>
        /// Gets the handle to the image list that has been set for an existing header control.
        /// You can use this macro or send the <see cref="HDM_GETIMAGELIST"/> message explicitly.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/nf-commctrl-header_getimagelist"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to a header control.
        /// </param>
        /// <returns></returns>
        public static HIMAGELIST Header_GetImageList(HWND hwnd) => (IntPtr)SendMessage(hwnd, (WindowMessages)HDM_GETIMAGELIST, 0, 0);

        /// <summary>
        /// <para>
        /// Gets information about an item in a header control.
        /// You can use this macro or send the <see cref="HDM_GETITEM"/> message explicitly.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/nf-commctrl-header_getitem"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to a header control.
        /// </param>
        /// <param name="iItem">
        /// The index of the item for which information is to be retrieved.
        /// </param>
        /// <param name="phdi">
        /// A pointer to an <see cref="HDITEM"/> structure.
        /// When the message is sent, the mask member indicates the type of information being requested.
        /// When the message returns, the other members receive the requested information.
        /// If the <see cref="HDITEM.mask"/> member specifies zero, the message returns <see cref="TRUE"/> but copies no information to the structure.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// If the <see cref="HDI_TEXT"/> flag is set in the <see cref="HDITEM.mask"/> member of the <see cref="HDITEM"/> structure,
        /// the control may change the <see cref="HDITEM.pszText"/> member of the structure to point to the new text instead of filling the buffer with the requested text.
        /// Applications should not assume that the text will always be placed in the requested buffer.
        /// </remarks>
        public static BOOL Header_GetItem(HWND hwnd, int iItem, ref HDITEM phdi) => (int)SendMessage(hwnd, (WindowMessages)HDM_GETITEM, iItem, AsPointer(ref phdi));

        /// <summary>
        /// <para>
        /// Gets a count of the items in a header control.
        /// You can use this macro or send the <see cref="HDM_GETITEMCOUNT"/> message explicitly.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/nf-commctrl-header_getitemcount"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to a header control.
        /// </param>
        /// <returns></returns>
        public static int Header_GetItemCount(HWND hwnd) => (int)SendMessage(hwnd, (WindowMessages)HDM_GETITEMCOUNT, 0, 0);

        /// <summary>
        /// <para>
        /// Gets the coordinates of the drop-down button for a specified item in a header control.
        /// The header control must be of type <see cref="HDF_SPLITBUTTON"/>.
        /// Use this macro or send the <see cref="HDM_GETITEMDROPDOWNRECT"/> message explicitly.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/nf-commctrl-header_getitemdropdownrect"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to a header control.
        /// </param>
        /// <param name="iItem">
        /// The zero-based index of the header control item for which to retrieve the bounding rectangle.
        /// </param>
        /// <param name="lprc">
        /// A pointer to a <see cref="RECT"/> structure to receive the bounding rectangle information.
        /// The message sender is responsible for allocating this structure.
        /// The coordinates returned in the <see cref="RECT"/> structure are expressed as screen coordinates.
        /// </param>
        /// <returns></returns>
        public static BOOL Header_GetItemDropDownRect(HWND hwnd, int iItem, ref RECT lprc) => (int)SendMessage(hwnd, (WindowMessages)HDM_GETITEMDROPDOWNRECT, iItem, AsPointer(ref lprc));

        /// <summary>
        /// <para>
        /// Gets the bounding rectangle for a given item in a header control.
        /// You can use this macro or send the <see cref="HDM_GETITEMRECT"/> message explicitly.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/nf-commctrl-header_getitemrect"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to a header control.
        /// </param>
        /// <param name="iItem">
        /// The zero-based index of the header control item for which to retrieve the bounding rectangle.
        /// </param>
        /// <param name="lprc">
        /// A pointer to a <see cref="RECT"/> structure that receives the bounding rectangle information.
        /// </param>
        /// <returns></returns>
        public static BOOL Header_GetItemRect(HWND hwnd, int iItem, ref RECT lprc) => (int)SendMessage(hwnd, (WindowMessages)HDM_GETITEMRECT, iItem, AsPointer(ref lprc));

        /// <summary>
        /// <para>
        /// Gets the current left-to-right order of items in a header control.
        /// You can use this macro or send the <see cref="HDM_GETORDERARRAY"/> message explicitly.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/nf-commctrl-header_getorderarray"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to a header control.
        /// </param>
        /// <param name="iCount">
        /// The number of integer elements that <paramref name="lpi"/> can hold.
        /// This value must be equal to the number of items in the control (see <see cref="HDM_GETITEMCOUNT"/>).
        /// </param>
        /// <param name="lpi">
        /// A pointer to an array of integers that receive the index values for items in the header.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// The number of elements in <paramref name="lpi"/> is specified in iSize and must be equal to the number of items in the control.
        /// For example, the following code fragment will reserve enough memory to hold the index values.
        /// <code>
        /// int iItems, *lpiArray;
        /// Get memory for buffer
        /// if((iItems = SendMessage(hwndHD, HDM_GETITEMCOUNT, 0,0))!=-1)
        /// if(!(lpiArray = calloc(iItems,sizeof(int))))
        /// MessageBox(hwnd, "Out of memory.","Error", MB_OK);
        /// </code>
        /// </remarks>
        public unsafe static BOOL Header_GetOrderArray(HWND hwnd, int iCount, int[] lpi)
        {
            fixed (int* ptr = lpi)
            {
                return (int)SendMessage(hwnd, (WindowMessages)HDM_GETORDERARRAY, iCount, (IntPtr)ptr);
            }
        }

        /// <summary>
        /// <para>
        /// Gets the coordinates of the drop-down overflow area for a specified header control.
        /// The header control must be of type <see cref="HDF_SPLITBUTTON"/>.
        /// Use this macro or send the <see cref="HDM_GETOVERFLOWRECT"/> message explicitly.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/nf-commctrl-header_getoverflowrect"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to a header control.
        /// </param>
        /// <param name="lprc">
        /// A pointer to a <see cref="RECT"/> structure to receive the bounding rectangle information.
        /// The message sender is responsible for allocating this structure.
        /// The coordinates returned in the <see cref="RECT"/> structure are expressed as screen coordinates.
        /// </param>
        /// <returns></returns>
        public static BOOL Header_GetOverflowRect(HWND hwnd, ref RECT lprc) => (int)SendMessage(hwnd, (WindowMessages)HDM_GETOVERFLOWRECT, 0, AsPointer(ref lprc));

        /// <summary>
        /// <para>
        /// Gets the handle to the image list that has been set for an existing header control state.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/nf-commctrl-header_getstateimagelist"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to a header control.
        /// </param>
        /// <returns></returns>
        public static HIMAGELIST Header_GetStateImageList(HWND hwnd) => (IntPtr)SendMessage(hwnd, (WindowMessages)HDM_GETIMAGELIST, 1, 0);

        /// <summary>
        /// <para>
        /// Gets the Unicode character format flag for the control.
        /// You can use this macro or send the <see cref="HDM_GETUNICODEFORMAT"/> message explicitly.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/nf-commctrl-header_getunicodeformat"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to a header control.
        /// </param>
        /// <returns></returns>
        public static BOOL Header_GetUnicodeFormat(HWND hwnd) => (int)SendMessage(hwnd, (WindowMessages)HDM_GETUNICODEFORMAT, 0, 0);

        /// <summary>
        /// <para>
        /// Inserts a new item into a header control.
        /// You can use this macro or send the <see cref="HDM_INSERTITEM"/> message explicitly.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/nf-commctrl-header_insertitem"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to a header control.
        /// </param>
        /// <param name="i">
        /// The index of the item after which the new item is to be inserted.
        /// The new item is inserted at the end of the header control if index is greater than or equal to the number of items in the control.
        /// If index is zero, the new item is inserted at the beginning of the header control.
        /// </param>
        /// <param name="phdi">
        /// A pointer to an <see cref="HDITEM"/> structure that contains information about the new item.
        /// </param>
        /// <returns></returns>
        public static int Header_InsertItem(HWND hwnd, int i, ref HDITEM phdi) => (int)SendMessage(hwnd, (WindowMessages)HDM_INSERTITEM, i, AsPointer(ref phdi));

        /// <summary>
        /// <para>
        /// Retrieves the correct size and position of a header control within the parent window.
        /// You can use this macro or send the <see cref="HDM_LAYOUT"/> message explicitly.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/nf-commctrl-header_layout"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to a header control.
        /// </param>
        /// <param name="playout">
        /// A pointer to an <see cref="HDLAYOUT"/> structure.
        /// The <see cref="HDLAYOUT.prc"/> member specifies the coordinates of a rectangle,
        /// and the <see cref="HDLAYOUT.pwpos"/> member receives the size and position for the header control within the rectangle.
        /// </param>
        /// <returns></returns>
        public static int Header_Layout(HWND hwnd, ref HDLAYOUT playout) => (int)SendMessage(hwnd, (WindowMessages)HDM_LAYOUT, 0, AsPointer(ref playout));

        /// <summary>
        /// <para>
        /// Retrieves an index value for an item based on its order in the header control.
        /// You can use this macro or send the <see cref="HDM_ORDERTOINDEX"/> message explicitly.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/nf-commctrl-header_ordertoindex"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to a header control.
        /// </param>
        /// <param name="i">
        /// The order that the item appears within the header control, from left to right.
        /// The index value of the item in the far left column would be 0, the next item to the right would be 1, and so on.
        /// </param>
        /// <returns></returns>
        public static int Header_OrderToIndex(HWND hwnd, int i) => (int)SendMessage(hwnd, (WindowMessages)HDM_ORDERTOINDEX, i, 0);

        /// <summary>
        /// <para>
        /// Sets the width of the margin for a bitmap in an existing header control.
        /// You can use this macro or send the <see cref="HDM_SETBITMAPMARGIN"/> message explicitly.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/nf-commctrl-header_setbitmapmargin"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to a header control.
        /// </param>
        /// <param name="iWidth">
        /// The width, specified in pixels, of the margin that surrounds a bitmap within an existing header control.
        /// </param>
        /// <returns></returns>
        public static int Header_SetBitmapMargin(HWND hwnd, int iWidth) => (int)SendMessage(hwnd, (WindowMessages)HDM_SETBITMAPMARGIN, iWidth, 0);

        /// <summary>
        /// <para>
        /// Sets the timeout interval between the time a change takes place in the filter attributes
        /// and the posting of an <see cref="HDN_FILTERCHANGE"/> notification.
        /// You can use this macro or send the <see cref="HDM_SETFILTERCHANGETIMEOUT"/> message explicitly.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/nf-commctrl-header_setfilterchangetimeout"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to a header control.
        /// </param>
        /// <param name="i">
        /// The timeout value, in milliseconds.
        /// </param>
        /// <returns></returns>
        public static int Header_SetFilterChangeTimeout(HWND hwnd, int i) => (int)SendMessage(hwnd, (WindowMessages)HDM_SETFILTERCHANGETIMEOUT, 0, i);

        /// <summary>
        /// <para>
        /// Sets the focus to a specified item in a header control. Use this macro or send the <see cref="HDM_SETFOCUSEDITEM"/> message explicitly.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/nf-commctrl-header_setfocuseditem"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to a header control.
        /// </param>
        /// <param name="iItem">
        /// The index of item.
        /// </param>
        /// <returns></returns>
        public static BOOL Header_SetFocusedItem(HWND hwnd, int iItem) => (int)SendMessage(hwnd, (WindowMessages)HDM_SETFOCUSEDITEM, 0, iItem);

        /// <summary>
        /// <para>
        /// Changes the color of a divider between header items to indicate the destination of an external drag-and-drop operation.
        /// You can use this macro or send the <see cref="HDM_SETHOTDIVIDER"/> message explicitly.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/nf-commctrl-header_sethotdivider"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to a header control.
        /// </param>
        /// <param name="fPos">
        /// A value specifying how <paramref name="dw"/> is to be interpreted.
        /// The value in this field can be one of the following:
        /// <see cref="TRUE"/>: Indicates that <paramref name="dw"/> holds client coordinates of the pointer.
        /// <see cref="FALSE"/>: Indicates that <paramref name="dw"/> holds a divider index value.
        /// </param>
        /// <param name="dw">
        /// The value held here is interpreted depending on the value of flag.
        /// If <paramref name="fPos"/> is <see cref="TRUE"/>, <paramref name="dw"/> represents the x- and y- client coordinates of the pointer.
        /// The x-coordinate is in the low word, and the y-coordinate is in the high word.
        /// Upon receiving the message, the header control highlights the appropriate divider based on the <paramref name="dw"/> coordinates.
        /// If <paramref name="fPos"/> is <see cref="FALSE"/>, <paramref name="dw"/> represents the integer index of the divider that will be highlighted.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// A header control set to the <see cref="HDS_DRAGDROP"/> style produces this effect automatically.
        /// This message is intended to be used when the owner of the control handles drag-and-drop operations manually.
        /// </remarks>
        public static int Header_SetHotDivider(HWND hwnd, BOOL fPos, DWORD dw) => (int)SendMessage(hwnd, (WindowMessages)HDM_SETHOTDIVIDER, (int)fPos, (int)dw);

        /// <summary>
        /// <para>
        /// Assigns an image list to an existing header control.
        /// You can use this macro or send the <see cref="HDM_SETIMAGELIST"/> message explicitly.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/nf-commctrl-header_setimagelist"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to a header control.
        /// </param>
        /// <param name="himl">
        /// A handle to an image list.
        /// </param>
        /// <returns></returns>
        public static HIMAGELIST Header_SetImageList(HWND hwnd, HIMAGELIST himl) => (IntPtr)SendMessage(hwnd, (WindowMessages)HDM_SETIMAGELIST, 0, (IntPtr)himl);

        /// <summary>
        /// <para>
        /// Sets the attributes of the specified item in a header control.
        /// You can use this macro or send the <see cref="HDM_SETITEM"/> message explicitly.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/nf-commctrl-header_setitem"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to a header control.
        /// </param>
        /// <param name="i">
        /// The current index of the item whose attributes are to be changed.
        /// </param>
        /// <param name="phdi">
        /// A pointer to an <see cref="HDITEM"/> structure that contains item information.
        /// When this message is sent, the <see cref="HDITEM.mask"/> member of the structure must be set to indicate which attributes are being set.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// The <see cref="HDITEM"/> structure that supports this macro supports item order and image list information.
        /// By using these members, you can control the order in which items are displayed and specify images to appear with items.
        /// </remarks>
        public static BOOL Header_SetItem(HWND hwnd, int i, ref HDITEM phdi) => (int)SendMessage(hwnd, (WindowMessages)HDM_SETITEM, i, AsPointer(ref phdi));

        /// <summary>
        /// <para>
        /// Sets the left-to-right order of header items. 
        /// You can use this macro or send the <see cref="HDM_SETORDERARRAY"/> message explicitly.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/nf-commctrl-header_setorderarray"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to a header control.
        /// </param>
        /// <param name="iCount">
        /// The size of the buffer at <paramref name="lpi"/>, in elements.
        /// This value must equal the value returned by <see cref="HDM_GETITEMCOUNT"/>.
        /// </param>
        /// <param name="lpi">
        /// A pointer to an array that specifies the order in which items should be displayed, from left to right.
        /// For example, if the contents of the array are {2,0,1}, the control displays item 2, item 0, and item 1, from left to right.
        /// </param>
        public unsafe static BOOL Header_SetOrderArray(HWND hwnd, int iCount, int[] lpi)
        {
            fixed (int* ptr = lpi)
            {
                return (int)SendMessage(hwnd, (WindowMessages)HDM_SETORDERARRAY, iCount, (IntPtr)ptr);
            }
        }

        /// <summary>
        /// <para>
        /// Assigns an image list to an existing header control state.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/nf-commctrl-header_setstateimagelist"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to a header control.
        /// </param>
        /// <param name="himl">
        /// A handle to an image list.
        /// </param>
        /// <returns></returns>
        public static HIMAGELIST Header_SetStateImageList(HWND hwnd, HIMAGELIST himl) => (IntPtr)SendMessage(hwnd, (WindowMessages)HDM_SETIMAGELIST, 1, (IntPtr)himl);

        /// <summary>
        /// <para>
        /// Sets the UNICODE character format flag for the control.
        /// This message allows you to change the character set used by the control at run time rather than having to re-create the control.
        /// You can use this macro or send the <see cref="HDM_SETUNICODEFORMAT"/> message explicitly.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/nf-commctrl-header_setunicodeformat"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to a header control.
        /// </param>
        /// <param name="fUnicode">
        /// Determines the character set that is used by the control.
        /// If this value is <see cref="TRUE"/>, the control will use Unicode characters.
        /// If this value is <see cref="FALSE"/>, the control will use ANSI characters.
        /// </param>
        /// <returns></returns>
        public static BOOL Header_SetUnicodeFormat(HWND hwnd, BOOL fUnicode) => (int)SendMessage(hwnd, (WindowMessages)HDM_SETUNICODEFORMAT, (int)fUnicode, 0);
    }
}
