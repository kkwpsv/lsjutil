using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains extended information about a page added to a process working set.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/psapi/ns-psapi-psapi_ws_watch_information_ex"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PSAPI_WS_WATCH_INFORMATION_EX
    {
        /// <summary>
        /// A <see cref="PSAPI_WS_WATCH_INFORMATION"/> structure.
        /// </summary>
        public PSAPI_WS_WATCH_INFORMATION BasicInfo;

        /// <summary>
        /// The identifier of the thread that caused the page fault.
        /// </summary>
        public ULONG_PTR FaultingThreadId;

        /// <summary>
        /// This member is reserved for future use.
        /// </summary>
        public ULONG_PTR Flags;
    }
}
