using static Lsj.Util.Win32.Enums.ToolbarControlStyles;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Button Check States
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/controls/bm-getstate"/>
    /// </para>
    /// </summary>
    public enum ButtonStates
    {
        /// <summary>
        /// The button is checked.
        /// </summary>
        BST_CHECKED = 0x0001,

        /// <summary>
        /// Windows Vista.
        /// The button is in the drop-down state. Applies only if the button has the <see cref="TBSTYLE_DROPDOWN"/> style.
        /// </summary>
        BST_DROPDOWNPUSHED = 0x0400,

        /// <summary>
        /// The button has the keyboard focus.
        /// </summary>
        BST_FOCUS = 0x0004,

        /// <summary>
        /// The button is hot; that is, the mouse is hovering over it.
        /// </summary>
        BST_HOT = 0x0200,

        /// <summary>
        /// The state of the button is indeterminate.
        /// Applies only if the button has the <see cref="ButtonStyles.BS_3STATE"/> or <see cref="ButtonStyles.BS_AUTO3STATE"/> style.
        /// </summary>
        BST_INDETERMINATE = 0x0002,

        /// <summary>
        /// The button is being shown in the pushed state.
        /// </summary>
        BST_PUSHED = 0x0004,

        /// <summary>
        /// No special state. Equivalent to zero.
        /// </summary>
        BST_UNCHECKED = 0x0000,
    }
}
