using Lsj.Util.Win32.Structs;
using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="WAVEHDR"/> flags
    /// </summary>
    [Flags]
    public enum WaveHeaderFlags : uint
    {
        /// <summary>
        /// WHDR_DONE
        /// </summary>
        WHDR_DONE = 0x00000001,

        /// <summary>
        /// WHDR_PREPARED
        /// </summary>
        WHDR_PREPARED = 0x00000002,

        /// <summary>
        /// WHDR_BEGINLOOP
        /// </summary>
        WHDR_BEGINLOOP = 0x00000004,

        /// <summary>
        /// WHDR_ENDLOOP
        /// </summary>
        WHDR_ENDLOOP = 0x00000008,

        /// <summary>
        /// WHDR_INQUEUE
        /// </summary>
        WHDR_INQUEUE = 0x00000010,
    }
}
