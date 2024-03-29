﻿using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Represents information about a NUMA node in a processor group.
    /// This structure is used with the <see cref="GetLogicalProcessorInformationEx"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-numa_node_relationship"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct NUMA_NODE_RELATIONSHIP
    {
        /// <summary>
        /// The number of the NUMA node.
        /// </summary>
        public DWORD NodeNumber;

        /// <summary>
        /// This member is reserved.
        /// </summary>
        public ByValBYTEArrayStructForSize20 Reserved;

        /// <summary>
        /// A <see cref="GROUP_AFFINITY"/> structure that specifies a group number and processor affinity within the group.
        /// </summary>
        public GROUP_AFFINITY GroupMask;
    }
}
