using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
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
        /// The processor architecture of the installed operating system.
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
        /// The number of logical processors in the current group.
        /// To retrieve this value, use the <see cref="GetLogicalProcessorInformation"/> function.
        ///  For information about the physical processors shared by logical processors,
        ///  call <see cref="GetLogicalProcessorInformationEx"/> with the RelationshipType parameter set to <see cref="RelationProcessorPackage"/>
        /// </summary>
        public DWORD dwNumberOfProcessors;

        /// <summary>
        /// An obsolete member that is retained for compatibility.
        /// Use the <see cref="wProcessorArchitecture"/>, <see cref="wProcessorLevel"/>,
        /// and <see cref="wProcessorRevision"/> members to determine the type of processor.
        /// </summary>
        public ProcessorTypes dwProcessorType;

        /// <summary>
        /// The granularity for the starting address at which virtual memory can be allocated.
        /// For more information, see <see cref="VirtualAlloc"/>.
        /// </summary>
        public DWORD dwAllocationGranularity;

        /// <summary>
        /// The architecture-dependent processor level.
        /// It should be used only for display purposes.
        /// To determine the feature set of a processor, use the <see cref="IsProcessorFeaturePresent"/> function.
        /// If <see cref="wProcessorArchitecture"/> is <see cref="PROCESSOR_ARCHITECTURE_INTEL"/>,
        /// <see cref="wProcessorLevel"/> is defined by the CPU vendor.
        /// If <see cref="wProcessorArchitecture"/> is <see cref="PROCESSOR_ARCHITECTURE_IA64"/>, <see cref="wProcessorLevel"/> is set to 1.
        /// </summary>
        public WORD wProcessorLevel;

        /// <summary>
        /// The architecture-dependent processor revision.
        /// The following table shows how the revision value is assembled for each type of processor architecture.
        /// Intel Pentium, Cyrix, or NextGen 586:
        /// The high byte is the model and the low byte is the stepping.
        /// For example, if the value is xxyy, the model number and stepping can be displayed as follows:
        /// Model xx, Stepping yy
        /// Intel 80386 or 80486:
        /// A value of the form xxyz.
        /// If xx is equal to 0xFF, y - 0xA is the model number, and z is the stepping identifier.
        /// If xx is not equal to 0xFF, xx + 'A' is the stepping letter and yz is the minor stepping.
        /// ARM:
        /// Reserved.
        /// </summary>
        public WORD wProcessorRevision;
    }
}
