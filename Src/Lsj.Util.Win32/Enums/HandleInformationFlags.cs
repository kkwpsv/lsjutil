using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// HandleInformation Flags
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/handleapi/nf-handleapi-gethandleinformation"/>
    /// </para>
    /// </summary>
    public enum HandleInformationFlags : uint
    {
        /// <summary>
        /// If this flag is set, a child process created with the bInheritHandles parameter of <see cref="CreateProcess"/>
        /// set to <see cref="TRUE"/> will inherit the object handle.
        /// </summary>
        HANDLE_FLAG_INHERIT = 0x00000001,

        /// <summary>
        /// If this flag is set, calling the <see cref="CloseHandle"/> function will not close the object handle.
        /// </summary>
        HANDLE_FLAG_PROTECT_FROM_CLOSE = 0x00000002,
    }
}
