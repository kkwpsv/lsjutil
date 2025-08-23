using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="DEVMODE"/> Duplex flags
    /// </summary>
    public enum DeviceModeDuplexFlags : short
    {
        /// <summary>
        /// DMDUP_SIMPLEX
        /// </summary>
        DMDUP_SIMPLEX = 1,

        /// <summary>
        /// DMDUP_VERTICAL
        /// </summary>
        DMDUP_VERTICAL = 2,

        /// <summary>
        /// DMDUP_HORIZONTAL
        /// </summary>
        DMDUP_HORIZONTAL = 3,
    }
}