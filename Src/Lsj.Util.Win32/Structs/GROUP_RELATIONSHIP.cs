﻿using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Represents information about processor groups.
    /// This structure is used with the <see cref="GetLogicalProcessorInformationEx"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-group_relationship"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct GROUP_RELATIONSHIP
    {
        /// <summary>
        /// The maximum number of processor groups on the system.
        /// </summary>
        public WORD MaximumGroupCount;

        /// <summary>
        /// The number of active groups on the system.
        /// This member indicates the number of <see cref="PROCESSOR_GROUP_INFO"/> structures in the <see cref="GroupInfo"/> array.
        /// </summary>
        public WORD ActiveGroupCount;

        /// <summary>
        /// This member is reserved.
        /// </summary>
        public ByValBYTEArrayStructForSize20 Reserved;

        /// <summary>
        /// An array of <see cref="PROCESSOR_GROUP_INFO"/> structures.
        /// Each structure represents the number and affinity of processors in an active group on the system.
        /// </summary>
        public PROCESSOR_GROUP_INFO GroupInfo;
    }
}
