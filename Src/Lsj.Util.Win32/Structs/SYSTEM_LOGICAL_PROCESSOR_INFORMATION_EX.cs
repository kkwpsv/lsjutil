using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.LOGICAL_PROCESSOR_RELATIONSHIP;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about the relationships of logical processors and related hardware.
    /// The <see cref="GetLogicalProcessorInformationEx"/> function uses this structure.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-system_logical_processor_information_ex
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX
    {
        /// <summary>
        /// The type of relationship between the logical processors.
        /// This parameter can be one of the following <see cref="LOGICAL_PROCESSOR_RELATIONSHIP"/> values.
        /// <see cref="RelationCache"/>:
        /// The specified logical processors share a cache. The <see cref="Cache"/> member contains additional information.
        /// <see cref="RelationGroup"/>:
        /// The specified logical processors share a processor group. The <see cref="Group"/> member contains additional information.
        /// <see cref="RelationNumaNode"/>:
        /// The specified logical processors are part of the same NUMA node. The <see cref="NumaNode"/> member contains additional information.
        /// <see cref="RelationProcessorCore"/>:
        /// The specified logical processors share a single processor core. The <see cref="Processor"/> member contains additional information.
        /// <see cref="RelationProcessorPackage"/>:
        /// The specified logical processors share a physical package. The <see cref="Processor"/> member contains additional information.
        /// </summary>
        [FieldOffset(0)]
        public LOGICAL_PROCESSOR_RELATIONSHIP Relationship;

        /// <summary>
        /// The size of the structure.
        /// </summary>
        [FieldOffset(4)]
        public uint Size;

        /// <summary>
        /// A <see cref="PROCESSOR_RELATIONSHIP"/> structure that describes processor affinity.
        /// This structure contains valid data only if the <see cref="Relationship"/> member
        /// is <see cref="RelationProcessorCore"/> or <see cref="RelationProcessorPackage"/>.
        /// </summary>
        [FieldOffset(8)]
        public PROCESSOR_RELATIONSHIP Processor;

        /// <summary>
        /// A <see cref="NUMA_NODE_RELATIONSHIP"/> structure that describes a NUMA node.
        /// This structure contains valid data only if the <see cref="Relationship"/> member is <see cref="RelationNumaNode"/>.
        /// </summary>
        [FieldOffset(8)]
        public NUMA_NODE_RELATIONSHIP NumaNode;

        /// <summary>
        /// A <see cref="CACHE_RELATIONSHIP"/> structure that describes cache attributes.
        /// This structure contains valid data only if the <see cref="Relationship"/> member is <see cref="RelationCache"/>.
        /// </summary>
        [FieldOffset(8)]
        public CACHE_RELATIONSHIP Cache;

        /// <summary>
        /// A <see cref="GROUP_RELATIONSHIP"/> structure that contains information about the processor groups.
        /// This structure contains valid data only if the <see cref="Relationship"/> member is <see cref="RelationGroup"/>.
        /// </summary>
        [FieldOffset(8)]
        public GROUP_RELATIONSHIP Group;
    }
}
