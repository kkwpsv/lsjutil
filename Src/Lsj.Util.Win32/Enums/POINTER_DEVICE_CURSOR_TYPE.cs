namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Identifies the pointer device cursor types.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ne-winuser-pointer_device_cursor_type"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Cursor objects represent pointing and selecting devices used with digitizer devices,
    /// most commonly tactile contacts on touch digitizers and tablet pens on pen digitizers.
    /// Physical pens may have multiple tips (such as normal and eraser ends), with each pen tip representing a different cursor object.
    /// Each cursor object has an associated cursor identifier.
    /// </remarks>
    public enum POINTER_DEVICE_CURSOR_TYPE
    {
        /// <summary>
        /// Unidentified cursor.
        /// </summary>
        POINTER_DEVICE_CURSOR_TYPE_UNKNOWN = 0x00000000,

        /// <summary>
        /// Pen tip.
        /// </summary>
        POINTER_DEVICE_CURSOR_TYPE_TIP = 0x00000001,

        /// <summary>
        /// Pen eraser.
        /// </summary>
        POINTER_DEVICE_CURSOR_TYPE_ERASER = 0x00000002,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// You should not use this value.
        /// </summary>
        POINTER_DEVICE_CURSOR_TYPE_MAX = unchecked((int)0xFFFFFFFF),
    }
}
