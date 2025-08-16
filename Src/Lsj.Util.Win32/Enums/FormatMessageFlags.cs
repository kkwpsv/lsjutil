using System;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="FormatMessage"/> flags
    /// </summary>
    [Flags]
    public enum FormatMessageFlags : uint
    {
        /// <summary>
        /// FORMAT_MESSAGE_ALLOCATE_BUFFER
        /// </summary>
        FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x00000100,

        /// <summary>
        /// FORMAT_MESSAGE_ARGUMENT_ARRAY
        /// </summary>
        FORMAT_MESSAGE_ARGUMENT_ARRAY = 0x00002000,

        /// <summary>
        /// FORMAT_MESSAGE_FROM_HMODULE
        /// </summary>
        FORMAT_MESSAGE_FROM_HMODULE = 0x00000800,

        /// <summary>
        /// FORMAT_MESSAGE_FROM_STRING
        /// </summary>
        FORMAT_MESSAGE_FROM_STRING = 0x00000400,

        /// <summary>
        /// FORMAT_MESSAGE_FROM_SYSTEM
        /// </summary>
        FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000,

        /// <summary>
        /// FORMAT_MESSAGE_IGNORE_INSERTS
        /// </summary>
        FORMAT_MESSAGE_IGNORE_INSERTS = 0x00000200,

        /// <summary>
        /// FORMAT_MESSAGE_MAX_WIDTH_MASK
        /// </summary>
        FORMAT_MESSAGE_MAX_WIDTH_MASK = 0x000000FF,
    }
}
