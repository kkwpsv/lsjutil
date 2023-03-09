using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.LOGICAL_PROCESSOR_RELATIONSHIP;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Describes the relationship between the specified processor set.
    /// This structure is used with the <see cref="GetLogicalProcessorInformation"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-system_logical_processor_information"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SYSTEM_LOGICAL_PROCESSOR_INFORMATION
    {
        /// <summary>
        /// The processor mask identifying the processors described by this structure.
        /// A processor mask is a bit vector in which each set bit represents an active processor in the relationship.
        /// At least one bit will be set.
        /// On a system with more than 64 processors, the processor mask identifies processors in a single processor group.
        /// </summary>
        public ULONG_PTR ProcessorMask;

        /// <summary>
        /// The relationship between the processors identified by the value of the <see cref="ProcessorMask"/> member.
        /// This member can be one of the following <see cref="LOGICAL_PROCESSOR_RELATIONSHIP"/> values.
        /// <see cref="RelationCache"/>:
        /// The specified logical processors share a cache.The Cache member contains additional information.
        /// Windows Server 2003:  This value is not supported until Windows Server 2003 with SP1 and Windows XP Professional x64 Edition.
        /// <see cref="RelationNumaNode"/>
        /// The specified logical processors are part of the same NUMA node.The NumaNode member contains additional information.
        /// <see cref="RelationProcessorCore"/>
        /// The specified logical processors share a single processor core.The ProcessorCore member contains additional information.
        /// <see cref="RelationProcessorPackage"/>
        /// The specified logical processors share a physical package. There is no additional information available.
        /// Windows Server 2003 and Windows XP Professional x64 Edition:
        /// This value is not supported until Windows Server 2003 with SP1 and Windows XP with SP3.
        /// Future versions of Windows may support additional values for the Relationship member.
        /// </summary>
        public LOGICAL_PROCESSOR_RELATIONSHIP Relationship;

#pragma warning disable IDE1006 
        /// <summary>
        /// 
        /// </summary>
        private SYSTEM_LOGICAL_PROCESSOR_INFORMATION_DUMMYUNIONNAME _SYSTEM_LOGICAL_PROCESSOR_INFORMATION_DUMMYUNIONNAME;

        /// <summary>
        /// This structure contains valid data only if the <see cref="Relationship"/> member is <see cref="RelationProcessorCore"/>.
        /// </summary>
        public SYSTEM_LOGICAL_PROCESSOR_INFORMATION_ProcessorCore ProcessorCore
        {
            get => _SYSTEM_LOGICAL_PROCESSOR_INFORMATION_DUMMYUNIONNAME.ProcessorCore;
            set => _SYSTEM_LOGICAL_PROCESSOR_INFORMATION_DUMMYUNIONNAME.ProcessorCore = value;
        }

        /// <summary>
        /// This structure contains valid data only if the <see cref="Relationship"/> member is <see cref="RelationNumaNode"/>.
        /// </summary>
        public SYSTEM_LOGICAL_PROCESSOR_INFORMATION_NumaNode NumaNode
        {
            get => _SYSTEM_LOGICAL_PROCESSOR_INFORMATION_DUMMYUNIONNAME.NumaNode;
            set => _SYSTEM_LOGICAL_PROCESSOR_INFORMATION_DUMMYUNIONNAME.NumaNode = value;
        }

        /// <summary>
        /// A <see cref="CACHE_DESCRIPTOR"/> structure that identifies the characteristics of a particular cache.
        /// There is one record returned for each cache reported.
        /// Some or all caches may not be reported, depending on the mechanism used by the processor to identify its caches.
        /// Therefore, do not assume the absence of any particular caches.
        /// Caches are not necessarily shared among logical processors.
        /// This structure contains valid data only if the <see cref="Relationship"/> member is <see cref="RelationCache"/>.
        /// Windows Server 2003:  This member is not supported until Windows Server 2003 with SP1 and Windows XP Professional x64 Edition.
        /// </summary>
        public CACHE_DESCRIPTOR Cache
        {
            get => _SYSTEM_LOGICAL_PROCESSOR_INFORMATION_DUMMYUNIONNAME.Cache;
            set => _SYSTEM_LOGICAL_PROCESSOR_INFORMATION_DUMMYUNIONNAME.Cache = value;
        }

        /// <summary>
        /// Reserved. Do not use.
        /// </summary>
        public ByValULONGLONGArrayStructForSize2 Reserved
        {
            get => _SYSTEM_LOGICAL_PROCESSOR_INFORMATION_DUMMYUNIONNAME.Reserved;
            set => _SYSTEM_LOGICAL_PROCESSOR_INFORMATION_DUMMYUNIONNAME.Reserved = value;
        }
#pragma warning restore IDE1006 

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
        private struct SYSTEM_LOGICAL_PROCESSOR_INFORMATION_DUMMYUNIONNAME
        {
            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public SYSTEM_LOGICAL_PROCESSOR_INFORMATION_ProcessorCore ProcessorCore;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public SYSTEM_LOGICAL_PROCESSOR_INFORMATION_NumaNode NumaNode;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public CACHE_DESCRIPTOR Cache;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public ByValULONGLONGArrayStructForSize2 Reserved;
        }

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct SYSTEM_LOGICAL_PROCESSOR_INFORMATION_ProcessorCore
        {
            /// <summary>
            /// If the value of this member is 1, the logical processors identified by the value of the <see cref="ProcessorMask"/> member
            /// share functional units, as in Hyperthreading or SMT.
            /// Otherwise, the identified logical processors do not share functional units.
            /// Windows Server 2003 and Windows XP Professional x64 Edition:
            /// This member is also 1 for cores that share a physical package.
            /// Therefore, to determine whether the processor supports multiple cores or hyperthreading on systems prior to Windows Vista,
            /// use the CPUID instruction.
            /// </summary>
            public BYTE Flags;
        }

        /// <summary>
        /// 
        /// </summary>
        public struct SYSTEM_LOGICAL_PROCESSOR_INFORMATION_NumaNode
        {
            /// <summary>
            /// Identifies the NUMA node.
            /// The valid values of this parameter are 0 to the highest NUMA node number inclusive.
            /// A non-NUMA multiprocessor system will report that all processors belong to one NUMA node.
            /// </summary>
            public DWORD NodeNumber;
        }
    }
}
