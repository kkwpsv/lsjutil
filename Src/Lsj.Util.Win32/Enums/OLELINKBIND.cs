namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Controls binding operations to a link source.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oleidl/ne-oleidl-olelinkbind"/>
    /// </para>
    /// </summary>
    public enum OLELINKBIND
    {
        /// <summary>
        /// The binding operation should proceed even if the current class of the link source is different from the last time the link was bound.
        /// For example, the link source could be a Lotus spreadsheet that was converted to an Excel spreadsheet.
        /// </summary>
        OLELINKBIND_EVENIFCLASSDIFF = 1,
    }
}
