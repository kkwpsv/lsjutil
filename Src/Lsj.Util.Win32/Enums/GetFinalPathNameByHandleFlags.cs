using System;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="GetFinalPathNameByHandle"/> flags
    /// </summary>
    [Flags]
    public enum GetFinalPathNameByHandleFlags : uint
    {
        /// <summary>
        /// FILE_NAME_NORMALIZED
        /// </summary>
        FILE_NAME_NORMALIZED = 0x0,

        /// <summary>
        /// FILE_NAME_OPENED
        /// </summary>
        FILE_NAME_OPENED = 0x8,

        /// <summary>
        /// VOLUME_NAME_DOS
        /// </summary>
        VOLUME_NAME_DOS = 0x0,

        /// <summary>
        /// VOLUME_NAME_GUID
        /// </summary>
        VOLUME_NAME_GUID = 0x1,

        /// <summary>
        /// VOLUME_NAME_NONE
        /// </summary>
        VOLUME_NAME_NONE = 0x4,

        /// <summary>
        /// VOLUME_NAME_NT
        /// </summary>
        VOLUME_NAME_NT = 0x2,
    }
}
