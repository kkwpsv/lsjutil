using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains the exit code for a terminating process.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/minwinbase/ns-minwinbase-exit_process_debug_info"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct EXIT_PROCESS_DEBUG_INFO
    {
        /// <summary>
        /// The exit code for the process.
        /// </summary>
        public DWORD dwExitCode;
    }
}
