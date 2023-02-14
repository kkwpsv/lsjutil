namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Identifies the pointer device types.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ne-winuser-pointer_device_type"/>
    /// </para>
    /// </summary>
    public enum POINTER_DEVICE_TYPE
    {
        /// <summary>
        /// Direct pen digitizer (integrated into display).
        /// </summary>
        POINTER_DEVICE_TYPE_INTEGRATED_PEN = 0x00000001,

        /// <summary>
        /// Indirect pen digitizer (not integrated into display).
        /// </summary>
        POINTER_DEVICE_TYPE_EXTERNAL_PEN = 0x00000002,

        /// <summary>
        /// Touch digitizer.
        /// </summary>
        POINTER_DEVICE_TYPE_TOUCH = 0x00000003,

        /// <summary>
        /// Touchpad digitizer (Windows 8.1 and later).
        /// </summary>
        POINTER_DEVICE_TYPE_TOUCH_PAD = 0x00000004,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// You should not use this value.
        /// </summary>
        POINTER_DEVICE_TYPE_MAX = unchecked((int)0xFFFFFFFF),
    }
}
