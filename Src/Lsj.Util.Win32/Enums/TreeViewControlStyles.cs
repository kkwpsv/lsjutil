using System;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// TreeView Control Styles
    /// </para>
    /// <para>
    /// <see href="https://learn.microsoft.com/en-us/windows/win32/controls/tree-view-control-window-styles"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum TreeViewControlStyles : uint
    {
        /// <summary>
        /// Version 4.70.
        /// Enables check boxes for items in a tree-view control.
        /// A check box is displayed only if an image is associated with the item.
        /// When set to this style, the control effectively uses <see cref="DrawFrameControl"/> to create and set a state image list containing two images.
        /// State image 1 is the unchecked box and state image 2 is the checked box.
        /// Setting the state image to zero removes the check box altogether.
        /// For more information, see Working with state image indexes.
        /// Version 5.80.
        /// Displays a check box even if no image is associated with the item.
        /// Once a tree-view control is created with this style, the style cannot be removed.
        /// Instead, you must destroy the control and create a new one in its place.
        /// Destroying the tree-view control does not destroy the check box state image list.
        /// You must destroy it explicitly. Get the handle to the state image list by sending the tree-view control a <see cref="TVM_GETIMAGELIST"/> message.
        /// Then destroy the image list with ImageList_Destroy.
        /// If you want to use this style, you must set the <see cref="TVS_CHECKBOXES"/> style with <see cref="SetWindowLong"/> after you create the treeview control,
        /// and before you populate the tree.
        /// Otherwise, the checkboxes might appear unchecked, depending on timing issues.
        /// </summary>
        TVS_CHECKBOXES = 0x0100,

        /// <summary>
        /// Prevents the tree-view control from sending <see cref="TVN_BEGINDRAG"/> notification codes.
        /// </summary>
        TVS_DISABLEDRAGDROP = 0x0010,

        /// <summary>
        /// Allows the user to edit the labels of tree-view items.
        /// </summary>
        TVS_EDITLABELS = 0x0008,

        /// <summary>
        /// Version 4.71.
        /// Enables full-row selection in the tree view.
        /// The entire row of the selected item is highlighted, and clicking anywhere on an item's row causes it to be selected.
        /// This style cannot be used in conjunction with the <see cref="TVS_HASLINES"/> style.
        /// </summary>
        TVS_FULLROWSELECT = 0x1000,

        /// <summary>
        /// Displays plus (+) and minus (-) buttons next to parent items.
        /// The user clicks the buttons to expand or collapse a parent item's list of child items.
        /// To include buttons with items at the root of the tree view, <see cref="TVS_LINESATROOT"/> must also be specified.
        /// </summary>
        TVS_HASBUTTONS = 0x0001,

        /// <summary>
        /// Uses lines to show the hierarchy of items.
        /// </summary>
        TVS_HASLINES = 0x0002,

        /// <summary>
        /// Version 4.71.
        /// Obtains tooltip information by sending the <see cref="TVN_GETINFOTIP"/> notification.
        /// </summary>
        TVS_INFOTIP = 0x0800,

        /// <summary>
        /// Uses lines to link items at the root of the tree-view control. 
        /// This value is ignored if <see cref="TVS_HASLINES"/> is not also specified.
        /// </summary>
        TVS_LINESATROOT = 0x0004,

        /// <summary>
        /// Version 5.80.
        /// Disables horizontal scrolling in the control.
        /// The control will not display any horizontal scroll bars.
        /// </summary>
        TVS_NOHSCROLL = 0x8000,

        /// <summary>
        /// Version 4.71 
        /// Sets the height of the items to an odd height with the <see cref="TVM_SETITEMHEIGHT"/> message.
        /// By default, the height of items must be an even value.
        /// </summary>
        TVS_NONEVENHEIGHT = 0x4000,

        /// <summary>
        /// Version 4.71.
        /// Disables both horizontal and vertical scrolling in the control. The control will not display any scroll bars.
        /// </summary>
        TVS_NOSCROLL = 0x2000,

        /// <summary>
        /// Version 4.70.
        /// Disables tooltips.
        /// </summary>
        TVS_NOTOOLTIPS = 0x0080,

        /// <summary>
        /// Version 4.70.
        /// Causes text to be displayed from right-to-left (RTL).
        /// Usually, windows display text left-to-right (LTR).
        /// Windows can be mirrored to display languages such as Hebrew or Arabic that read RTL.
        /// Typically, tree-view text is displayed in the same direction as the text in its parent window.
        /// If <see cref="TVS_RTLREADING"/> is set, tree-view text reads in the opposite direction from the text in the parent window.
        /// </summary>
        TVS_RTLREADING = 0x0040,

        /// <summary>
        /// Causes a selected item to remain selected when the tree-view control loses focus.
        /// </summary>
        TVS_SHOWSELALWAYS = 0x0020,

        /// <summary>
        /// Version 4.71.
        /// Causes the item being selected to expand and the item being unselected to collapse upon selection in the tree view.
        /// If the mouse is used to single-click the selected item and that item is closed, it will be expanded.
        /// If the user holds down the CTRL key while selecting an item, the item being unselected will not be collapsed.
        /// Version 5.80.
        /// Causes the item being selected to expand and the item being unselected to collapse upon selection in the tree view.
        /// If the user holds down the CTRL key while selecting an item, the item being unselected will not be collapsed.
        /// </summary>
        TVS_SINGLEEXPAND = 0x0400,

        /// <summary>
        /// Version 4.70.
        /// Enables hot tracking in a tree-view control.
        /// </summary>
        TVS_TRACKSELECT = 0x0200,
    }
}
