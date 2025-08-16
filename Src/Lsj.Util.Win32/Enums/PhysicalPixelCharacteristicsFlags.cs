using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Physical pixel characteristics flags
    /// </summary>
    [Flags]
    public enum PhysicalPixelCharacteristicsFlags : uint
    {
        /// <summary>
        /// PPC_DEFAULT
        /// </summary>
        PPC_DEFAULT = 0x0,

        /// <summary>
        /// PPC_UNDEFINED
        /// </summary>
        PPC_UNDEFINED = 0x1,

        /// <summary>
        /// PPC_RGB_ORDER_VERTICAL_STRIPES
        /// </summary>
        PPC_RGB_ORDER_VERTICAL_STRIPES = 0x2,

        /// <summary>
        /// PPC_BGR_ORDER_VERTICAL_STRIPES
        /// </summary>
        PPC_BGR_ORDER_VERTICAL_STRIPES = 0x3,

        /// <summary>
        /// PPC_RGB_ORDER_HORIZONTAL_STRIPES
        /// </summary>
        PPC_RGB_ORDER_HORIZONTAL_STRIPES = 0x4,

        /// <summary>
        /// PPC_BGR_ORDER_HORIZONTAL_STRIPES
        /// </summary>
        PPC_BGR_ORDER_HORIZONTAL_STRIPES = 0x5,
    }

}
