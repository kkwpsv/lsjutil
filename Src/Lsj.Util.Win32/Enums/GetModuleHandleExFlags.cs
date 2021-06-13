using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="GetModuleHandleEx"/> Flags
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/libloaderapi/nf-libloaderapi-getmodulehandleexw"/>
    /// </para>
    /// </summary>
    public enum GetModuleHandleExFlags : uint
    {
        /// <summary>
        /// The lpModuleName parameter is an address in the module.
        /// </summary>
        GET_MODULE_HANDLE_EX_FLAG_FROM_ADDRESS = 0x00000004,

        /// <summary>
        /// The module stays loaded until the process is terminated, no matter how many times <see cref="FreeLibrary"/> is called.
        /// This option cannot be used with <see cref="GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT"/>.
        /// </summary>
        GET_MODULE_HANDLE_EX_FLAG_PIN = 0x00000001,

        /// <summary>
        /// The reference count for the module is not incremented.
        /// This option is equivalent to the behavior of <see cref="GetModuleHandle"/>.
        /// Do not pass the retrieved module handle to the FreeLibrary function; doing so can cause the DLL to be unmapped prematurely.
        /// For more information, see Remarks.
        /// This option cannot be used with <see cref="GET_MODULE_HANDLE_EX_FLAG_PIN"/>.
        /// </summary>
        GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT = 0x00000002,
    }
}
