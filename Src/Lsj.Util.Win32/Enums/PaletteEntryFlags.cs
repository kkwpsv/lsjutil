using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="PALETTEENTRY"/> flags
    /// </summary>
    public enum PaletteEntryFlags : byte
    {
        /// <summary>
        /// PC_RESERVED
        /// </summary>
        PC_RESERVED = 0x01,

        /// <summary>
        /// PC_EXPLICIT
        /// </summary>
        PC_EXPLICIT = 0x02,

        /// <summary>
        /// PC_NOCOLLAPSE
        /// </summary>
        PC_NOCOLLAPSE = 0x04,
    }
}
