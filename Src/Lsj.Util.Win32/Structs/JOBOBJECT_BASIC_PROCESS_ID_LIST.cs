using Lsj.Util.Win32.BaseTypes;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains the process identifier list for a job object.
    /// If the job is nested, the process identifier list consists of all processes associated with the job and its child jobs.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-jobobject_basic_process_id_list
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct JOBOBJECT_BASIC_PROCESS_ID_LIST
    {
        /// <summary>
        /// The number of process identifiers to be stored in <see cref="ProcessIdList"/>.
        /// </summary>
        public DWORD NumberOfAssignedProcesses;

        /// <summary>
        /// The number of process identifiers returned in the <see cref="ProcessIdList"/> buffer.
        /// If this number is less than <see cref="NumberOfAssignedProcesses"/>, increase the size of the buffer to accommodate the complete list.
        /// </summary>
        public DWORD NumberOfProcessIdsInList;

        /// <summary>
        /// A variable-length array of process identifiers returned by this call.
        /// Array elements 0 through <see cref="NumberOfProcessIdsInList"/>– 1 contain valid process identifiers.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public ULONG_PTR[] ProcessIdList;
    }
}
