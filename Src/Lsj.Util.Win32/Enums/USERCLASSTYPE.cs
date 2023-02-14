namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Indicates the different variants of the display name associated with a class of objects.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oleidl/ne-oleidl-userclasstype"/>
    /// </para>
    /// </summary>
    public enum USERCLASSTYPE : uint
    {
        /// <summary>
        /// The full type name of the class.
        /// </summary>
        USERCLASSTYPE_FULL = 1,

        /// <summary>
        /// A short name (maximum of 15 characters) that is used for popup menus and the Links dialog box.
        /// </summary>
        USERCLASSTYPE_SHORT = 2,

        /// <summary>
        /// The name of the application servicing the class and is used in the result text in dialog boxes.
        /// </summary>
        USERCLASSTYPE_APPNAME = 3
    }
}
