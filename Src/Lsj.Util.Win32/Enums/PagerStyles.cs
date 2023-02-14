namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Pager Styles
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/controls/pager-control-styles"/>
    /// </para>
    /// </summary>
    public enum PagerStyles : uint
    {
        /// <summary>
        /// The pager control will scroll when the user hovers the mouse over one of the scroll buttons.
        /// </summary>
        PGS_AUTOSCROLL = 0x00000002,

        /// <summary>
        /// The contained window can be a drag-and-drop target.
        /// The pager control will automatically scroll if an item is dragged from outside the pager over one of the scroll buttons.
        /// </summary>
        PGS_DRAGNDROP = 0x00000004,

        /// <summary>
        /// Creates a pager control that can be scrolled horizontally. This style and the PGS_VERT style are mutually exclusive and cannot be combined.
        /// </summary>
        PGS_HORZ = 0x00000001,

        /// <summary>
        /// Creates a pager control that can be scrolled vertically.
        /// This is the default direction if no direction style is specified.
        /// This style and the <see cref="PGS_HORZ"/> style are mutually exclusive and cannot be combined.
        /// </summary>
        PGS_VERT = 0x00000000,
    }
}
