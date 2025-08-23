using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="DEVMODE"/> color flags
    /// </summary>
    public enum DeviceModeColorFlags : short
    {
        /// <summary>
        /// DMCOLOR_MONOCHROME
        /// </summary>
        DMCOLOR_MONOCHROME = 1,

        /// <summary>
        /// DMCOLOR_COLOR
        /// </summary>
        DMCOLOR_COLOR = 2,
    }
}