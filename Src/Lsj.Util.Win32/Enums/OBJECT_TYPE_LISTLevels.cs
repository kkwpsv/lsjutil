namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// OBJECT_TYPE_LIST Levels
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-object_type_list"/>
    /// </para>
    /// </summary>
    public enum OBJECT_TYPE_LISTLevels : ushort
    {
        /// <summary>
        /// Indicates the object itself at level zero.
        /// </summary>
        ACCESS_OBJECT_GUID = 0,

        /// <summary>
        /// Indicates a property set at level one.
        /// </summary>
        ACCESS_PROPERTY_SET_GUID = 1,

        /// <summary>
        /// Indicates a property at level two.
        /// </summary>
        ACCESS_PROPERTY_GUID = 2,
    }
}
