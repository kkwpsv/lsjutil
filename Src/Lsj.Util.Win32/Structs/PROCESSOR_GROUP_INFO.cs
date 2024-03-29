﻿using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Represents the number and affinity of processors in a processor group.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-processor_group_info"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PROCESSOR_GROUP_INFO
    {
        /// <summary>
        /// The maximum number of processors in the group.
        /// </summary>
        public BYTE MaximumProcessorCount;

        /// <summary>
        /// The number of active processors in the group.
        /// </summary>
        public BYTE ActiveProcessorCount;

        /// <summary>
        /// This member is reserved.
        /// </summary>
        public ByValBYTEArrayStructForSize38 Reserved;

        /// <summary>
        /// A bitmap that specifies the affinity for zero or more active processors within the group.
        /// </summary>
        public KAFFINITY ActiveProcessorMask;
    }
}
