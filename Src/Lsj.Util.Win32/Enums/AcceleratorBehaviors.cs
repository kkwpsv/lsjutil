using Lsj.Util.Win32.Structs;
using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="ACCEL"/> accelerator behaviors.
    /// </summary>
    [Flags]
    public enum AcceleratorBehaviors : byte
    {
        /// <summary>
        /// FALT
        /// </summary>
        FALT = 0x10,

        /// <summary>
        /// FCONTROL
        /// </summary>
        FCONTROL = 0x08,

        /// <summary>
        /// FNOINVERT
        /// </summary>
        FNOINVERT = 0x02,

        /// <summary>
        /// FSHIFT
        /// </summary>
        FSHIFT = 0x04,

        /// <summary>
        /// FVIRTKEY
        /// </summary>
        FVIRTKEY = 0x01,
    }
}
