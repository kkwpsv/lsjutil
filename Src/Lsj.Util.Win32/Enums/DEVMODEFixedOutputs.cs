using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="DEVMODE"/> FixedOutput
    /// </summary>
    public enum DEVMODEFixedOutputs : uint
    {
        /// <summary>
        /// DMDFO_DEFAULT
        /// </summary>
        DMDFO_DEFAULT =  0,

        /// <summary>
        /// DMDFO_STRETCH
        /// </summary>
        DMDFO_STRETCH =  1,

        /// <summary>
        /// DMDFO_CENTER
        /// </summary>
        DMDFO_CENTER =  2,
    }
}