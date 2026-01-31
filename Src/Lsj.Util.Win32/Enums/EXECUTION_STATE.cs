using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// EXECUTION_STATE
    /// </summary>
    [Flags]
    public enum EXECUTION_STATE : uint
    {
        /// <summary>
        /// ES_SYSTEM_REQUIRED
        /// </summary>
        ES_SYSTEM_REQUIRED = 0x00000001,

        /// <summary>
        /// ES_DISPLAY_REQUIRED
        /// </summary>
        ES_DISPLAY_REQUIRED = 0x00000002,

        /// <summary>
        /// ES_USER_PRESENT
        /// </summary>
        ES_USER_PRESENT = 0x00000004,

        /// <summary>
        /// ES_AWAYMODE_REQUIRED
        /// </summary>
        ES_AWAYMODE_REQUIRED = 0x00000040,

        /// <summary>
        /// ES_CONTINUOUS
        /// </summary>
        ES_CONTINUOUS = 0x80000000,
    }
}
