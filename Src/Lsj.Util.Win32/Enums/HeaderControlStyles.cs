using Lsj.Util.Win32.Structs;
using System;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Header controls have a number of styles, described in this section, that determine the control's appearance and behavior.
    /// You set the initial styles when you create the header control.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/controls/header-control-styles"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// To retrieve and change the styles after creating the control, use the <see cref="GetWindowLong"/> and <see cref="SetWindowLong"/> functions.
    /// </remarks>
    [Flags]
    public enum HeaderControlStyles : uint
    {
        /// <summary>
        /// Each item in the control looks and behaves like a push button.
        /// This style is useful if an application carries out a task when the user clicks an item in the header control.
        /// For example, an application could sort information in the columns differently depending on which item the user clicks.
        /// </summary>
        HDS_BUTTONS = 0x0002,

        /// <summary>
        /// Allows drag-and-drop reordering of header items.
        /// </summary>
        HDS_DRAGDROP = 0x0040,

        /// <summary>
        /// Include a filter bar as part of the standard header control.
        /// This bar allows users to conveniently apply a filter to the display.
        /// Calls to <see cref="HDM_LAYOUT"/> will yield a new size for the control and cause the list view to update.
        /// </summary>
        HDS_FILTERBAR = 0x0100,

        /// <summary>
        /// Version 6.0 and later.
        /// Causes the header control to be drawn flat when the operating system is running in classic mode.
        /// </summary>
        HDS_FLAT = 0x0200,

        /// <summary>
        /// Causes the header control to display column contents even while the user resizes a column.
        /// </summary>
        HDS_FULLDRAG = 0x0080,

        /// <summary>
        /// Indicates a header control that is intended to be hidden.
        /// This style does not hide the control.
        /// Instead, when you send the <see cref="HDM_LAYOUT"/> message to a header control with the <see cref="HDS_HIDDEN"/> style,
        /// the control returns zero in the <see cref="WINDOWPOS.cy"/> member of the <see cref="WINDOWPOS"/> structure.
        /// You would then hide the control by setting its height to zero.
        /// This can be useful when you want to use the control as an information container instead of a visual control.
        /// </summary>
        HDS_HIDDEN = 0x0008,

        /// <summary>
        /// Creates a header control with a horizontal orientation.
        /// </summary>
        HDS_HORZ = 0x0000,

        /// <summary>
        /// Enables hot tracking.
        /// </summary>
        HDS_HOTTRACK = 0x0004,

        /// <summary>
        /// Version 6.00 and later.
        /// Allows the placing of checkboxes on header items.
        /// For more information, see the <see cref="HDITEM.fmt"/> member of <see cref="HDITEM"/>.
        /// </summary>
        HDS_CHECKBOXES = 0x0400,

        /// <summary>
        /// Version 6.00 and later.
        /// The user cannot drag the divider on the header control.
        /// </summary>
        HDS_NOSIZING = 0x0800,

        /// <summary>
        /// Version 6.00 and later.
        /// A button is displayed when not all items can be displayed within the header control's rectangle.
        /// When clicked, this button sends an <see cref="HDN_OVERFLOWCLICK"/> notification.
        /// </summary>
        HDS_OVERFLOW = 0x1000,
    }
}
