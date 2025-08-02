using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.LOGICAL_PROCESSOR_RELATIONSHIP;
using static Lsj.Util.Win32.Enums.ProcessorArchitectures;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about the current computer system.
    /// This includes the architecture and type of the processor, the number of processors in the system, the page size, and other such information.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/sysinfoapi/ns-sysinfoapi-system_info"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SYSTEM_INFO
    {
        /// <summary>
        /// <para>
        /// The processor architecture of the installed operating system.
        /// This member can be one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PROCESSOR_ARCHITECTURE_AMD64"/>
        /// </para>
        /// <para>
        /// 9
        /// </para>
        /// </term>
        /// <term>
        /// x64 (AMD or Intel)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PROCESSOR_ARCHITECTURE_ARM"/>
        /// </para>
        /// <para>
        /// 5
        /// </para>
        /// </term>
        /// <term>
        /// ARM
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PROCESSOR_ARCHITECTURE_ARM64"/>
        /// </para>
        /// <para>
        /// 12
        /// </para>
        /// </term>
        /// <term>
        /// ARM64
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PROCESSOR_ARCHITECTURE_IA64"/>
        /// </para>
        /// <para>
        /// 6
        /// </para>
        /// </term>
        /// <term>
        /// Intel Itanium-based
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PROCESSOR_ARCHITECTURE_INTEL"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// x86
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PROCESSOR_ARCHITECTURE_UNKNOWN"/>
        /// </para>
        /// <para>
        /// 0xffff
        /// </para>
        /// </term>
        /// <term>
        /// Unknown architecture.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public ProcessorArchitectures wProcessorArchitecture;

        /// <summary>
        /// This member is reserved for future use.
        /// </summary>
        public WORD wReserved;

        /// <summary>
        /// The page size and the granularity of page protection and commitment.
        /// This is the page size used by the <see cref="VirtualAlloc"/> function.
        /// </summary>
        public DWORD dwPageSize;

        /// <summary>
        /// A pointer to the lowest memory address accessible to applications and dynamic-link libraries (DLLs).
        /// </summary>
        public LPVOID lpMinimumApplicationAddress;

        /// <summary>
        /// A pointer to the highest memory address accessible to applications and DLLs.
        /// </summary>
        public LPVOID lpMaximumApplicationAddress;

        /// <summary>
        /// A mask representing the set of processors configured into the system. Bit 0 is processor 0; bit 31 is processor 31.
        /// </summary>
        public DWORD_PTR dwActiveProcessorMask;

        /// <summary>
        /// <para>
        /// The number of logical processors in the current group.
        /// To retrieve this value, use the <see cref="GetLogicalProcessorInformation"/> function.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// For information about the physical processors shared by logical processors,
        /// call <see cref="GetLogicalProcessorInformationEx"/> with the RelationshipType parameter set to <see cref="RelationProcessorPackage"/>
        /// </para>
        /// </summary>
        public DWORD dwNumberOfProcessors;

        /// <summary>
        /// <para>
        /// An obsolete member that is retained for compatibility.
        /// Use the <see cref="wProcessorArchitecture"/>, <see cref="wProcessorLevel"/>,
        /// and <see cref="wProcessorRevision"/> members to determine the type of processor.
        /// </para>
        /// <para>
        /// PROCESSOR_INTEL_386 (386)
        /// </para>
        /// <para>
        /// PROCESSOR_INTEL_486 (486)
        /// </para>
        /// <para>
        /// PROCESSOR_INTEL_PENTIUM (586)
        /// </para>
        /// <para>
        /// PROCESSOR_INTEL_IA64 (2200)
        /// </para>
        /// <para>
        /// PROCESSOR_AMD_X8664 (8664)
        /// </para>
        /// <para>
        /// PROCESSOR_ARM (Reserved)
        /// </para>
        /// </summary>
        public ProcessorTypes dwProcessorType;

        /// <summary>
        /// The granularity for the starting address at which virtual memory can be allocated.
        /// For more information, see <see cref="VirtualAlloc"/>.
        /// </summary>
        public DWORD dwAllocationGranularity;

        /// <summary>
        /// <para>
        /// The architecture-dependent processor level.
        /// It should be used only for display purposes.
        /// To determine the feature set of a processor, use the <see cref="IsProcessorFeaturePresent"/> function.
        /// </para>
        /// <para>
        /// If <see cref="wProcessorArchitecture"/> is <see cref="PROCESSOR_ARCHITECTURE_INTEL"/>,
        /// <see cref="wProcessorLevel"/> is defined by the CPU vendor.
        /// </para>
        /// <para>
        /// If <see cref="wProcessorArchitecture"/> is <see cref="PROCESSOR_ARCHITECTURE_IA64"/>,
        /// <see cref="wProcessorLevel"/> is set to 1.
        /// </para>
        /// </summary>
        public WORD wProcessorLevel;

        /// <summary>
        /// <para>
        /// The architecture-dependent processor revision.
        /// The following table shows how the revision value is assembled for each type of processor architecture.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Processor
        /// </term>
        /// <term>
        /// Value
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Intel Pentium, Cyrix, or NextGen 586
        /// </term>
        /// <term>
        /// <para>
        /// The high byte is the model and the low byte is the stepping.
        /// For example, if the value is xxyy, the model number and stepping can be displayed as follows:
        /// </para>
        /// <para>
        /// Model xx, Stepping yy
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Intel 80386 or 80486
        /// </term>
        /// <term>
        /// <para>
        /// A value of the form xxyz.
        /// </para>
        /// <para>
        /// If xx is equal to 0xFF, y - 0xA is the model number, and z is the stepping identifier.
        /// </para>
        /// <para>
        /// If xx is not equal to 0xFF, xx + 'A' is the stepping letter and yz is the minor stepping.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// ARM
        /// </term>
        /// <term>
        /// Reserved.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public WORD wProcessorRevision;
    }
}
