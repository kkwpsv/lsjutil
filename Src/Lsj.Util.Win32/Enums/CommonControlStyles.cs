using static Lsj.Util.Win32.Enums.WindowsMessages;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// This section lists common control styles.
    /// Except where noted, these styles apply to rebar controls, toolbar controls, and status windows.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/controls/common-control-styles"/>
    /// </para>
    /// </summary>
    public enum CommonControlStyles
    {
        /// <summary>
        /// Causes the control to position itself at the top of the parent window's client area
        /// and sets the width to be the same as the parent window's width.
        /// Toolbars have this style by default.
        /// </summary>
        CCS_TOP = 0x00000001,

        /// <summary>
        /// Causes the control to resize and move itself horizontally, but not vertically, in response to a <see cref="WM_SIZE"/> message.
        /// If <see cref="CCS_NORESIZE"/> is used, this style does not apply.
        /// Header windows have this style by default.
        /// </summary>
        CCS_NOMOVEY = 0x00000002,

        /// <summary>
        /// Causes the control to position itself at the bottom of the parent window's client area
        /// and sets the width to be the same as the parent window's width.
        /// Status windows have this style by default.
        /// </summary>
        CCS_BOTTOM = 0x00000003,

        /// <summary>
        /// Prevents the control from using the default width and height when setting its initial size or a new size.
        /// Instead, the control uses the width and height specified in the request for creation or sizing.
        /// </summary>
        CCS_NORESIZE = 0x00000004,

        /// <summary>
        /// Prevents the control from automatically moving to the top or bottom of the parent window.
        /// Instead, the control keeps its position within the parent window despite changes to the size of the parent.
        /// If <see cref="CCS_TOP"/> or <see cref="CCS_BOTTOM"/> is also used,
        /// the height is adjusted to the default, but the position and width remain unchanged.
        /// </summary>
        CCS_NOPARENTALIGN = 0x00000008,

        /// <summary>
        /// Enables a toolbar's built-in customization features,
        /// which let the user to drag a button to a new position or to remove a button by dragging it off the toolbar.
        /// In addition, the user can double-click the toolbar to display the Customize Toolbar dialog box,
        /// which enables the user to add, delete, and rearrange toolbar buttons.
        /// </summary>
        CCS_ADJUSTABLE = 0x00000020,

        /// <summary>
        /// Prevents a two-pixel highlight from being drawn at the top of the control.
        /// </summary>
        CCS_NODIVIDER = 0x00000040,

        /// <summary>
        /// Version 4.70.
        /// Causes the control to be displayed vertically.
        /// </summary>
        CCS_VERT = 0x00000080,

        /// <summary>
        /// Version 4.70.
        /// Causes the control to be displayed vertically on the left side of the parent window.
        /// </summary>
        CCS_LEFT = CCS_VERT | CCS_TOP,

        /// <summary>
        /// Version 4.70.
        /// Causes the control to be displayed vertically on the right side of the parent window.
        /// </summary>
        CCS_RIGHT = CCS_VERT | CCS_BOTTOM,

        /// <summary>
        /// Version 4.70.
        /// Causes the control to resize and move itself vertically, but not horizontally, in response to a <see cref="WM_SIZE"/> message.
        /// If <see cref="CCS_NORESIZE"/> is used, this style does not apply.
        /// </summary>
        CCS_NOMOVEX = CCS_VERT | CCS_NOMOVEY,
    }
}
