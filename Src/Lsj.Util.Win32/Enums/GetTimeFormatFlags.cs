using System;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="GetTimeFormat"/> flags
    /// </summary>
    [Flags]
    public enum GetTimeFormatFlags : uint
    {
        /// <summary>
        /// TIME_NOMINUTESORSECONDS
        /// </summary>
        TIME_NOMINUTESORSECONDS = 0x00000001,

        /// <summary>
        /// TIME_NOSECONDS
        /// </summary>
        TIME_NOSECONDS = 0x00000002,

        /// <summary>
        /// TIME_NOTIMEMARKER
        /// </summary>
        TIME_NOTIMEMARKER = 0x00000004,

        /// <summary>
        /// TIME_FORCE24HOURFORMAT
        /// </summary>
        TIME_FORCE24HOURFORMAT = 0x00000008,
    }
}
