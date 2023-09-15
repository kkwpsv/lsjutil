using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="DISPLAYCONFIG_PIXELFORMAT"/> enumeration specifies pixel format in various bits per pixel (BPP) values.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ne-wingdi-displayconfig_pixelformat"/>
    /// </para>
    /// </summary>
    public enum DISPLAYCONFIG_PIXELFORMAT
    {
        /// <summary>
        /// Indicates 8 BPP format.
        /// </summary>
        DISPLAYCONFIG_PIXELFORMAT_8BPP = 1,

        /// <summary>
        /// Indicates 16 BPP format.
        /// </summary>
        DISPLAYCONFIG_PIXELFORMAT_16BPP = 2,

        /// <summary>
        /// Indicates 24 BPP format.
        /// </summary>
        DISPLAYCONFIG_PIXELFORMAT_24BPP = 3,

        /// <summary>
        /// Indicates 32 BPP format.
        /// </summary>
        DISPLAYCONFIG_PIXELFORMAT_32BPP = 4,

        /// <summary>
        /// Indicates that the current display is not an 8, 16, 24, or 32 BPP GDI desktop mode.
        /// For example, a call to the <see cref="QueryDisplayConfig"/> function returns <see cref="DISPLAYCONFIG_PIXELFORMAT_NONGDI"/>
        /// if a DirectX application previously set the desktop to A2R10G10B10 format.
        /// A call to the <see cref="SetDisplayConfig"/> function fails
        /// if any pixel formats for active paths are set to <see cref="DISPLAYCONFIG_PIXELFORMAT_NONGDI"/>.
        /// </summary>
        DISPLAYCONFIG_PIXELFORMAT_NONGDI = 5,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// You should not use this value.
        /// </summary>
        DISPLAYCONFIG_PIXELFORMAT_FORCE_UINT32 = unchecked((int)0xffffffff),
    }
}
