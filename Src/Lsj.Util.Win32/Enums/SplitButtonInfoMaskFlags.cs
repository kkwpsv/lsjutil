using Lsj.Util.Win32.Structs;
using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="BUTTON_SPLITINFO.mask"/> flags
    /// </summary>
    [Flags]
    public enum SplitButtonInfoMaskFlags : uint
    {
        /// <summary>
        /// BCSIF_GLYPH
        /// </summary>
        BCSIF_GLYPH = 0x0001,

        /// <summary>
        /// BCSIF_IMAGE
        /// </summary>
        BCSIF_IMAGE = 0x0002,

        /// <summary>
        /// BCSIF_SIZE
        /// </summary>
        BCSIF_SIZE = 0x0008,

        /// <summary>
        /// BCSIF_STYLE
        /// </summary>
        BCSIF_STYLE = 0x0004,
    }
}
