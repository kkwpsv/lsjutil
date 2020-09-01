using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.LOGICAL_PROCESSOR_RELATIONSHIP;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Represents information about affinity within a processor group.
    /// This structure is used with the <see cref="GetLogicalProcessorInformationEx"/> function.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-processor_relationship
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="PROCESSOR_RELATIONSHIP"/> structure describes the logical processors associated with either a processor core or a processor package.
    /// If the <see cref="PROCESSOR_RELATIONSHIP"/> structure represents a processor core, the <see cref="GroupCount"/> member is always 1.
    /// If the <see cref="PROCESSOR_RELATIONSHIP"/> structure represents a processor package, the <see cref="GroupCount"/> member is 1 only
    /// if all processors are in the same processor group.
    /// If the package contains more than one NUMA node, the system might assign different NUMA nodes to different processor groups.
    /// In this case, the <see cref="GroupCount"/> member is the number of groups to which NUMA nodes in the package are assigned.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PROCESSOR_RELATIONSHIP
    {
        /// <summary>
        /// LTP_PC_SMT
        /// </summary>
        public const byte LTP_PC_SMT = 0x1;

        /// <summary>
        /// If the <see cref="SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX.Relationship"/> member of 
        /// the <see cref="SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX"/> structure is <see cref="RelationProcessorCore"/>,
        /// this member is <see cref="LTP_PC_SMT"/> if the core has more than one logical processor, or 0 if the core has one logical processor.
        /// If the <see cref="SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX.Relationship"/> member of
        /// the <see cref="SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX"/> structure is <see cref="RelationProcessorPackage"/>, this member is always 0.
        /// </summary>
        public BYTE Flags;

        /// <summary>
        /// If the <see cref="SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX.Relationship"/> member of
        /// the <see cref="SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX"/> structure is <see cref="RelationProcessorCore"/>,
        /// <see cref="EfficiencyClass"/> specifies the intrinsic tradeoff between performance and power for the applicable core.
        /// A core with a higher value for the efficiency class has intrinsically greater performance and less efficiency
        /// than a core with a lower value for the efficiency class.
        /// <see cref="EfficiencyClass"/> is only nonzero on systems with a heterogeneous set of cores.
        /// If the <see cref="SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX.Relationship"/> member of
        /// the <see cref="SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX"/> structure is <see cref="RelationProcessorPackage"/>,
        /// <see cref="EfficiencyClass"/> is always 0.
        /// The minimum operating system version that supports this member is Windows 10.
        /// </summary>
        public BYTE EfficiencyClass;

        /// <summary>
        /// This member is reserved.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public BYTE[] Reserved;

        /// <summary>
        /// This member specifies the number of entries in the <see cref="GroupMask"/> array.
        /// For more information, see Remarks.
        /// </summary>
        public WORD GroupCount;

        /// <summary>
        /// An array of <see cref="GROUP_AFFINITY"/> structures.
        /// The <see cref="GroupCount"/> member specifies the number of structures in the array.
        /// Each structure in the array specifies a group number and processor affinity within the group.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ANYSIZE_ARRAY)]
        public GROUP_AFFINITY[] GroupMask;
    }
}
