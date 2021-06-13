namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Owner draw control types
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-drawitemstruct"/>
    /// </para>
    /// </summary>
    public enum OwnerDrawControlTypes : uint
    {
        /// <summary>
        /// Owner-drawn button
        /// </summary>
        ODT_BUTTON = 4,

        /// <summary>
        /// Owner-drawn combo box
        /// </summary>
        ODT_COMBOBOX = 3,

        /// <summary>
        /// Owner-drawn list box
        /// </summary>
        ODT_LISTBOX = 2,

        /// <summary>
        /// List-view control
        /// </summary>
        ODT_LISTVIEW = 102,

        /// <summary>
        /// Owner-drawn menu item
        /// </summary>
        ODT_MENU = 1,

        /// <summary>
        /// Owner-drawn static control
        /// </summary>
        ODT_STATIC = 5,

        /// <summary>
        /// Tab control
        /// </summary>
        ODT_TAB = 101,
    }
}
