using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// BoundsAccumulationFlags
    /// </summary>
    [Flags]
    public enum BoundsAccumulationFlags
    {
        /// <summary>
        /// DCB_RESET
        /// </summary>
        DCB_RESET = 0x0001,

        /// <summary>
        /// DCB_ACCUMULATE
        /// </summary>
        DCB_ACCUMULATE = 0x0002,

        /// <summary>
        /// DCB_DIRTY
        /// </summary>
        DCB_DIRTY = DCB_ACCUMULATE,

        /// <summary>
        /// DCB_SET
        /// </summary>
        DCB_SET = (DCB_RESET | DCB_ACCUMULATE),

        /// <summary>
        /// DCB_ENABLE
        /// </summary>
        DCB_ENABLE = 0x0004,

        /// <summary>
        /// DCB_DISABLE
        /// </summary>
        DCB_DISABLE = 0x0008,
    }
}
