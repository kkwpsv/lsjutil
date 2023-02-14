namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="DISPLAYCONFIG_ROTATION"/> enumeration specifies the clockwise rotation of the display.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ne-wingdi-displayconfig_rotation"/>
    /// </para>
    /// </summary>
    public enum DISPLAYCONFIG_ROTATION : uint
    {
        /// <summary>
        /// Indicates that rotation is 0 degrees—landscape mode.
        /// </summary>
        DISPLAYCONFIG_ROTATION_IDENTITY = 1,

        /// <summary>
        /// Indicates that rotation is 90 degrees clockwise—portrait mode.
        /// </summary>
        DISPLAYCONFIG_ROTATION_ROTATE90 = 2,

        /// <summary>
        /// Indicates that rotation is 180 degrees clockwise—inverted landscape mode.
        /// </summary>
        DISPLAYCONFIG_ROTATION_ROTATE180 = 3,

        /// <summary>
        /// Indicates that rotation is 270 degrees clockwise—inverted portrait mode.
        /// </summary>
        DISPLAYCONFIG_ROTATION_ROTATE270 = 4,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// You should not use this value.
        /// </summary>
        DISPLAYCONFIG_ROTATION_FORCE_UINT32 = 0xFFFFFFFF
    }
}
