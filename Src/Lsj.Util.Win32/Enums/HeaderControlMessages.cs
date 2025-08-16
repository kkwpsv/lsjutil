using Lsj.Util.Win32.Structs;
using System;
using static Lsj.Util.Win32.Enums.ControlMessages;
using static Lsj.Util.Win32.Enums.HeaderControlItemFormats;
using static Lsj.Util.Win32.Enums.HeaderControlItemMasks;
using static Lsj.Util.Win32.Enums.HeaderControlNotifications;
using static Lsj.Util.Win32.Enums.HeaderControlStyles;
using static Lsj.Util.Win32.Macros.HeaderControlMacros;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Header control messages
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/controls/bumper-header-control-reference-messages"/>
    /// </para>
    /// </summary>
    public enum HeaderControlMessages : uint
    {
        /// <summary>
        /// Clears the filter for a given header control.
        /// You can send this message explicitly or use the <see cref="Header_ClearFilter"/> macro.
        /// </summary>
        /// <remarks>
        /// If the column value is specified as -1, all the filters are cleared,
        /// and the <see cref="HDN_FILTERCHANGE"/> notification is sent only once.
        /// </remarks>
        HDM_CLEARFILTER = 0x1224,

        /// <summary>
        /// Creates a semi-transparent version of an item's image for use as a dragging image.
        /// You can send this message explicitly or use the <see cref="Header_CreateDragImage"/> macro.
        /// </summary>
        HDM_CREATEDRAGIMAGE = 0x1216,

        /// <summary>
        /// Deletes an item from a header control.
        /// You can send this message explicitly or use the <see cref="Header_DeleteItem"/> macro.
        /// </summary>
        HDM_DELETEITEM = 0x1202,

        /// <summary>
        /// Moves the input focus to the edit box when a filter button has the focus.
        /// </summary>
        HDM_EDITFILTER = 0x1223,

        /// <summary>
        /// Gets the width of the bitmap margin for a header control.
        /// You can send this message explicitly or use the <see cref="Header_GetBitmapMargin"/> macro.
        /// </summary>
        HDM_GETBITMAPMARGIN = 0x1221,

        /// <summary>
        /// Gets the item in a header control that has the focus.
        /// Send this message explicitly or by using the <see cref="Header_GetFocusedItem"/> macro.
        /// </summary>
        HDM_GETFOCUSEDITEM = 0x1227,

        /// <summary>
        /// Gets the handle to the image list that has been set for an existing header control.
        /// You can send this message explicitly or use the <see cref="Header_GetImageList"/> or <see cref="Header_GetStateImageList"/> macro.
        /// </summary>
        HDM_GETIMAGELIST = 0x1209,

        /// <summary>
        /// Gets information about an item in a header control.
        /// You can send this message explicitly or use the <see cref="Header_GetItem"/> macro.
        /// </summary>
        /// <remarks>
        /// If the <see cref="HDI_TEXT"/> flag is set in the mask member of the <see cref="HDITEM"/> structure,
        /// the control may change the <see cref="HDITEM.pszText"/> member of the structure to point to the new text
        /// instead of filling the buffer with the requested text.
        /// Applications should not assume that the text will always be placed in the requested buffer.
        /// </remarks>
        HDM_GETITEM = 0x1211,

        /// <summary>
        /// Gets a count of the items in a header control.
        /// You can send this message explicitly or use the <see cref="Header_GetItemCount"/> macro.
        /// </summary>
        HDM_GETITEMCOUNT = 0x1200,

        /// <summary>
        /// Gets the bounding rectangle of the split button for a header item with style <see cref="HDF_SPLITBUTTON"/>.
        /// Send this message explicitly or by using the <see cref="Header_GetItemDropDownRect"/> macro.
        /// </summary>
        /// <remarks>
        /// The header item must have style <see cref="HDF_SPLITBUTTON"/>.
        /// </remarks>
        HDM_GETITEMDROPDOWNRECT = 0x1225,

        /// <summary>
        /// Gets the bounding rectangle for a given item in a header control.
        /// You can send this message explicitly or use the <see cref="Header_GetItemRect"/> macro.
        /// </summary>
        HDM_GETITEMRECT = 0x1207,

        /// <summary>
        /// Gets the current left-to-right order of items in a header control.
        /// You can send this message explicitly or use the <see cref="Header_GetOrderArray"/> macro.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The number of elements in lParam is specified in wParam and must be equal to the number of items in the control.
        /// For example, the following code fragment will reserve enough memory to hold the index values.
        /// </para>
        /// <code>
        /// int iItems,
        /// 
        ///     *lpiArray;
        /// 
        /// 
        /// 
        /// // Get memory for buffer.
        /// 
        /// (iItems = SendMessage(hwndHD, HDM_GETITEMCOUNT, 0,0))!=-1)
        /// 
        ///     if(!(lpiArray = calloc(iItems,sizeof(int))))
        /// 
        /// MessageBox(hwnd, "Out of memory.","Error", MB_OK);
        /// </code>
        /// </remarks>
        HDM_GETORDERARRAY = 0x1217,

        /// <summary>
        /// Gets the bounding rectangle of the overflow button
        /// when the <see cref="HDS_OVERFLOW"/> style is set on the header control and the overflow button is visible.
        /// Send this message explicitly or by using the <see cref="Header_GetOverflowRect"/> macro.
        /// </summary>
        /// <remarks>
        /// The header control must have style <see cref="HDF_SPLITBUTTON"/>.
        /// </remarks>
        HDM_GETOVERFLOWRECT = 0x1226,

        /// <summary>
        /// Gets the Unicode character format flag for the control.
        /// You can send this message explicitly or use the <see cref="Header_GetUnicodeFormat"/> macro.
        /// </summary>
        /// <remarks>
        /// See the remarks for <see cref="CCM_GETUNICODEFORMAT"/> for a discussion of this message.
        /// </remarks>
        HDM_GETUNICODEFORMAT = 0x2006,

        /// <summary>
        /// Tests a point to determine which header item, if any, is at the specified point.
        /// </summary>
        HDM_HITTEST = 0x1206,

        /// <summary>
        /// Inserts a new item into a header control.
        /// You can send this message explicitly or use the <see cref="Header_InsertItem"/> macro.
        /// </summary>
        HDM_INSERTITEM = 0x1210,

        /// <summary>
        /// Retrieves information used to set the size and position of the header control within the target rectangle of the parent window.
        /// You can send this message explicitly or use the <see cref="Header_Layout"/> macro.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="HDLAYOUT.pwpos"/> member of the lParam structure receives size and position values 
        /// appropriate for positioning the control along the top of the specified rectangle.
        /// The height value is the sum of the heights of the control's horizontal borders and the average height of characters
        /// in the font currently selected into the control's device context.
        /// </para>
        /// <para>
        /// To use <see cref="HDM_LAYOUT"/> to set the initial size and position of a header control,
        /// set the initial visibility state of the control so that it is hidden.
        /// After sending <see cref="HDM_LAYOUT"/> to retrieve the size and position values,
        /// use the <see cref="SetWindowPos"/> function to set the new size, position, and visibility state.
        /// </para>
        /// </remarks>
        HDM_LAYOUT = 0x1205,

        /// <summary>
        /// Retrieves an index value for an item based on its order in the header control.
        /// You can send this message explicitly or use the <see cref="Header_OrderToIndex"/> macro.
        /// </summary>
        HDM_ORDERTOINDEX = 0x1215,

        /// <summary>
        /// Sets the width of the margin, specified in pixels, of a bitmap in an existing header control.
        /// You can send this message explicitly or use the <see cref="Header_SetBitmapMargin"/> macro.
        /// </summary>
        HDM_SETBITMAPMARGIN = 0x1220,

        /// <summary>
        /// Sets the timeout interval between the time a change takes place in the filter attributes
        /// and the posting of an <see cref="HDN_FILTERCHANGE"/> notification.
        /// You can send this message explicitly or use the <see cref="Header_SetFilterChangeTimeout"/> macro.
        /// </summary>
        HDM_SETFILTERCHANGETIMEOUT = 0x1222,

        /// <summary>
        /// Sets the focus to a specified item in a header control.
        /// Send this message explicitly or by using the <see cref="Header_SetFocusedItem"/> macro.
        /// </summary>
        HDM_SETFOCUSEDITEM = 0x1228,

        /// <summary>
        /// Changes the color of a divider between header items to indicate the destination of an external drag-and-drop operation.
        /// You can send this message explicitly or use the <see cref="Header_SetHotDivider"/> macro.
        /// </summary>
        /// <remarks>
        /// This message creates an effect that a header control automatically produces when it has the <see cref="HDS_DRAGDROP"/> style.
        /// The <see cref="HDM_SETHOTDIVIDER"/> message is intended to be used
        /// when the owner of the control handles drag-and-drop operations manually.
        /// </remarks>
        HDM_SETHOTDIVIDER = 0x1219,

        /// <summary>
        /// Assigns an image list to an existing header control.
        /// You can send this message explicitly or use the <see cref="Header_SetImageList"/> or <see cref="Header_SetStateImageList"/> macro.
        /// </summary>
        HDM_SETIMAGELIST = 0x1208,

        /// <summary>
        /// Sets the attributes of the specified item in a header control.
        /// You can send this message explicitly or use the <see cref="Header_SetItem"/> macro.
        /// </summary>
        /// <remarks>
        /// The HDITEM structure that supports this message supports item order and image list information.
        /// By using these members, you can control the order in which items are displayed and specify images to appear with items.
        /// </remarks>
        HDM_SETITEM = 0x1212,

        /// <summary>
        /// Sets the left-to-right order of header items.
        /// You can send this message explicitly or use the <see cref="Header_SetOrderArray"/> macro.
        /// </summary>
        HDM_SETORDERARRAY = 0x1218,

        /// <summary>
        /// Sets the UNICODE character format flag for the control.
        /// This message allows you to change the character set used by the control at run time rather than having to re-create the control.
        /// You can send this message explicitly or use the <see cref="Header_SetUnicodeFormat"/> macro.
        /// </summary>
        /// <remarks>
        /// See the remarks for <see cref="CCM_SETUNICODEFORMAT"/> for a discussion of this message.
        /// </remarks>
        HDM_SETUNICODEFORMAT = 0x2005,

        /// <summary>
        /// This message is not implemented.
        /// </summary>
        HDM_TRANSLATEACCELERATOR = 0, // Not defined
    }
}
