using Lsj.Util.Win32.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains extended memory statistics for a process.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/psapi/ns-psapi-process_memory_counters_ex"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PROCESS_MEMORY_COUNTERS_EX
    {
        /// <summary>
        /// The size of the structure, in bytes.
        /// </summary>
        public DWORD cb;

        /// <summary>
        /// The number of page faults.
        /// </summary>
        public DWORD PageFaultCount;

        /// <summary>
        /// The peak working set size, in bytes.
        /// </summary>
        public SIZE_T PeakWorkingSetSize;

        /// <summary>
        /// The current working set size, in bytes.
        /// </summary>
        public SIZE_T WorkingSetSize;

        /// <summary>
        /// The peak paged pool usage, in bytes.
        /// </summary>
        public SIZE_T QuotaPeakPagedPoolUsage;

        /// <summary>
        /// The current paged pool usage, in bytes.
        /// </summary>
        public SIZE_T QuotaPagedPoolUsage;

        /// <summary>
        /// The peak nonpaged pool usage, in bytes.
        /// </summary>
        public SIZE_T QuotaPeakNonPagedPoolUsage;

        /// <summary>
        /// The current nonpaged pool usage, in bytes.
        /// </summary>
        public SIZE_T QuotaNonPagedPoolUsage;

        /// <summary>
        /// <para>
        /// The Commit Charge value in bytes for this process.
        /// Commit Charge is the total amount of private memory that the memory manager has committed for a running process.
        /// </para>
        /// <para>
        /// Windows 7 and Windows Server 2008 R2 and earlier:
        /// <see cref="PagefileUsage"/> is always zero. Check <see cref="PrivateUsage"/> instead.
        /// </para>
        /// </summary>
        public SIZE_T PagefileUsage;

        /// <summary>
        /// The peak value in bytes of the Commit Charge during the lifetime of this process.
        /// </summary>
        public SIZE_T PeakPagefileUsage;

        /// <summary>
        /// Same as <see cref="PagefileUsage"/>.
        /// The Commit Charge value in bytes for this process.
        /// Commit Charge is the total amount of private memory that the memory manager has committed for a running process.
        /// </summary>
        public SIZE_T PrivateUsage;
    }
}
