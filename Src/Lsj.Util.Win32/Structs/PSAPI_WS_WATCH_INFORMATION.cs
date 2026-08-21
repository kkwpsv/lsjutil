using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about a page added to a process working set.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/psapi/ns-psapi-psapi_ws_watch_information"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PSAPI_WS_WATCH_INFORMATION
    {
        /// <summary>
        /// A pointer to the instruction that caused the page fault.
        /// </summary>
        public LPVOID FaultingPc;

        /// <summary>
        /// A pointer to the page that was added to the working set.
        /// </summary>
        public LPVOID FaultingVa;
    }
}
