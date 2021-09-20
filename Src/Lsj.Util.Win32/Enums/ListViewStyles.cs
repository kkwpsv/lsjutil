using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Enums.WindowMessages;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// List View Styles
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/controls/list-view-window-styles"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// For the <see cref="LVS_SORTASCENDING"/> and <see cref="LVS_SORTDESCENDING"/> styles,
    /// item indexes are sorted based on item text in ascending or descending order, respectively.
    /// Because the <see cref="LVS_LIST"/> and <see cref="LVS_REPORT"/> views display items in the same order as their indexes,
    /// the results of sorting are immediately visible to the user.
    /// The <see cref="LVS_ICON"/> and <see cref="LVS_SMALLICON"/> views do not use item indexes to determine the position of icons.
    /// With those views, the results of sorting are not visible to the user.
    /// You can use the <see cref="LVS_TYPEMASK"/> mask to isolate the window styles that correspond to the current view:
    /// <see cref="LVS_ICON"/>, <see cref="LVS_LIST"/>, <see cref="LVS_REPORT"/>, and <see cref="LVS_SMALLICON"/>.
    /// You can use the <see cref="LVS_ALIGNMASK"/> mask to isolate the window styles that specify the alignment of items:
    /// <see cref="LVS_ALIGNLEFT"/> and <see cref="LVS_ALIGNTOP"/>.
    /// You can use the <see cref="LVS_TYPESTYLEMASK"/> mask to isolate the window styles
    /// that control item alignment (<see cref="LVS_ALIGNLEFT"/> and <see cref="LVS_ALIGNTOP"/>) and
    /// those that control header appearance and behavior (<see cref="LVS_NOCOLUMNHEADER"/> and <see cref="LVS_NOSORTHEADER"/>).
    /// </remarks>
    public enum ListViewStyles : uint
    {
        /// <summary>
        /// Items are left-aligned in icon and small icon view.
        /// </summary>
        LVS_ALIGNLEFT = 0x0800,

        /// <summary>
        /// The control's current alignment.
        /// </summary>
        LVS_ALIGNMASK = 0x0c00,

        /// <summary>
        /// Items are aligned with the top of the list-view control in icon and small icon view.
        /// </summary>
        LVS_ALIGNTOP = 0x0000,

        /// <summary>
        /// Icons are automatically kept arranged in icon and small icon view.
        /// </summary>
        LVS_AUTOARRANGE = 0x0100,

        /// <summary>
        /// Item text can be edited in place.
        /// The parent window must process the <see cref="LVN_ENDLABELEDIT"/> notification code.
        /// </summary>
        LVS_EDITLABELS = 0x0200,

        /// <summary>
        /// This style specifies icon view.
        /// </summary>
        LVS_ICON = 0x0000,

        /// <summary>
        /// This style specifies list view.
        /// </summary>
        LVS_LIST = 0x0003,

        /// <summary>
        /// Column headers are not displayed in report view.
        /// By default, columns have headers in report view.
        /// </summary>
        LVS_NOCOLUMNHEADER = 0x4000,

        /// <summary>
        /// Item text is displayed on a single line in icon view.
        /// By default, item text may wrap in icon view.
        /// </summary>
        LVS_NOLABELWRAP = 0x0080,

        /// <summary>
        /// Scrolling is disabled.
        /// All items must be within the client area.
        /// This style is not compatible with the <see cref="LVS_LIST"/> or <see cref="LVS_REPORT"/> styles.
        /// See Knowledge Base Article Q137520 for further discussion.
        /// </summary>
        LVS_NOSCROLL = 0x2000,

        /// <summary>
        /// Column headers do not work like buttons.
        /// This style can be used if clicking a column header in report view does not carry out an action, such as sorting.
        /// </summary>
        LVS_NOSORTHEADER = 0x8000,

        /// <summary>
        /// Version 4.70. 
        /// This style specifies a virtual list-view control.
        /// For more information about this list control style, see About List-View Controls.
        /// </summary>
        LVS_OWNERDATA = 0x1000,

        /// <summary>
        /// The owner window can paint items in report view.
        /// The list-view control sends a <see cref="WM_DRAWITEM"/> message to paint each item; it does not send separate messages for each subitem.
        /// The <see cref="DRAWITEMSTRUCT.itemData"/> member of the <see cref="DRAWITEMSTRUCT"/> structure
        /// contains the item data for the specified list-view item.
        /// </summary>
        LVS_OWNERDRAWFIXED = 0x0400,

        /// <summary>
        /// This style specifies report view.
        /// When using the <see cref="LVS_REPORT"/> style with a list-view control, the first column is always left-aligned.
        /// You cannot use <see cref="LVCFMT_RIGHT"/> to change this alignment.
        /// See <see cref="LVCOLUMN"/> for further information on column alignment.
        /// </summary>
        LVS_REPORT = 0x0001,

        /// <summary>
        /// The image list will not be deleted when the control is destroyed.
        /// This style enables the use of the same image lists with multiple list-view controls.
        /// </summary>
        LVS_SHAREIMAGELISTS = 0x0040,

        /// <summary>
        /// The selection, if any, is always shown, even if the control does not have the focus.
        /// </summary>
        LVS_SHOWSELALWAYS = 0x0008,

        /// <summary>
        /// Only one item at a time can be selected. By default, multiple items may be selected.
        /// </summary>
        LVS_SINGLESEL = 0x0004,

        /// <summary>
        /// This style specifies small icon view.
        /// </summary>
        LVS_SMALLICON = 0x0002,

        /// <summary>
        /// Item indexes are sorted based on item text in ascending order.
        /// </summary>
        LVS_SORTASCENDING = 0x0010,

        /// <summary>
        /// Item indexes are sorted based on item text in descending order.
        /// </summary>
        LVS_SORTDESCENDING = 0x0020,

        /// <summary>
        /// Determines the control's current window style.
        /// </summary>
        LVS_TYPEMASK = 0x0003,

        /// <summary>
        /// Determines the window styles that control item alignment and header appearance and behavior.
        /// </summary>
        LVS_TYPESTYLEMASK = 0xfc00,

    }
}
