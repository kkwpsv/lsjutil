using System;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="GetModuleHandleEx"/> flags
    /// </summary>
    [Flags]
    public enum GetModuleHandleExFlags : uint
    {
        /// <summary>
        /// GET_MODULE_HANDLE_EX_FLAG_FROM_ADDRESS
        /// </summary>
        GET_MODULE_HANDLE_EX_FLAG_FROM_ADDRESS = 0x00000004,

        /// <summary>
        /// GET_MODULE_HANDLE_EX_FLAG_PIN
        /// </summary>
        GET_MODULE_HANDLE_EX_FLAG_PIN = 0x00000001,

        /// <summary>
        /// GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT
        /// </summary>
        GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT = 0x00000002,
    }
}
