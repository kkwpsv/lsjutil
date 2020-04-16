using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="DEVMODE"/> Display Orientations
    /// </summary>
    public enum DEVMODEDisplayOrientations : uint
    {
        /// <summary>
        /// DMDO_DEFAULT
        /// </summary>
        DMDO_DEFAULT =  0,

        /// <summary>
        /// DMDO_90
        /// </summary>
        DMDO_90 =  1,

        /// <summary>
        /// DMDO_180
        /// </summary>
        DMDO_180 =  2,

        /// <summary>
        /// DMDO_270
        /// </summary>
        DMDO_270 = 3,
    }
}