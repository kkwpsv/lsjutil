using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Error modes
    /// </summary>
    [Flags]
    public enum ErrorModes : uint
    {
        /// <summary>
        /// SEM_FAILCRITICALERRORS
        /// </summary>
        SEM_FAILCRITICALERRORS = 0x0001,

        /// <summary>
        ///SEM_NOALIGNMENTFAULTEXCEPT
        /// </summary>
        SEM_NOALIGNMENTFAULTEXCEPT = 0x0004,

        /// <summary>
        /// SEM_NOGPFAULTERRORBOX
        /// </summary>
        SEM_NOGPFAULTERRORBOX = 0x0002,

        /// <summary>
        /// SEM_NOOPENFILEERRORBOX
        /// </summary>
        SEM_NOOPENFILEERRORBOX = 0x8000,
    }
}
