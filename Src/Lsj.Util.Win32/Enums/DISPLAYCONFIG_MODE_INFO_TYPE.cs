using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="DISPLAYCONFIG_MODE_INFO_TYPE"/> enumeration specifies that the information
    /// that is contained within the <see cref="DISPLAYCONFIG_MODE_INFO"/> structure is either source or target mode.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ne-wingdi-displayconfig_mode_info_type"/>
    /// </para>
    /// </summary>
    public enum DISPLAYCONFIG_MODE_INFO_TYPE
    {
        /// <summary>
        /// Indicates that the <see cref="DISPLAYCONFIG_MODE_INFO"/> structure contains source mode information.
        /// </summary>
        DISPLAYCONFIG_MODE_INFO_TYPE_SOURCE = 1,

        /// <summary>
        /// Indicates that the <see cref="DISPLAYCONFIG_MODE_INFO"/> structure contains target mode information.
        /// </summary>
        DISPLAYCONFIG_MODE_INFO_TYPE_TARGET = 2,

        /// <summary>
        /// Indicates that the <see cref="DISPLAYCONFIG_MODE_INFO"/> structure contains a valid <see cref="DISPLAYCONFIG_DESKTOP_IMAGE_INFO"/> structure.
        /// Supported starting in Windows 10.
        /// </summary>
        DISPLAYCONFIG_MODE_INFO_TYPE_DESKTOP_IMAGE = 3,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// You should not use this value.
        /// </summary>
        DISPLAYCONFIG_MODE_INFO_TYPE_FORCE_UINT32 = unchecked((int)0xFFFFFFFF),
    }
}
