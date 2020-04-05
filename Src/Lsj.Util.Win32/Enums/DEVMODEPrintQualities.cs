using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="DEVMODE"/> PrintQualities
    /// </summary>
    public enum DEVMODEPrintQualities : short
    {
        /// <summary>
        /// DMRES_DRAFT
        /// </summary>
        DMRES_DRAFT = -1,

        /// <summary>
        /// DMRES_LOW
        /// </summary>
        DMRES_LOW = -2,

        /// <summary>
        /// DMRES_MEDIUM
        /// </summary>
        DMRES_MEDIUM = -3,

        /// <summary>
        /// DMRES_HIGH
        /// </summary>
        DMRES_HIGH = -4,
    }
}
