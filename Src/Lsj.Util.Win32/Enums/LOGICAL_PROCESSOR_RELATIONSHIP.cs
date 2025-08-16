using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Represents the relationship between the processor set identified
    /// in the corresponding <see cref="SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX"/> structure.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ne-winnt-logical_processor_relationship"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The value specified by this enumeration indicates the relationship
    /// represented in the corresponding <see cref="SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX"/> structure.
    /// </remarks>
    public enum LOGICAL_PROCESSOR_RELATIONSHIP
    {
        /// <summary>
        /// The specified logical processors share a single processor core.
        /// </summary>
        RelationProcessorCore,

        /// <summary>
        /// The specified logical processors are part of the same NUMA node.
        /// </summary>
        RelationNumaNode,

        /// <summary>
        /// <para>
        /// The specified logical processors share a cache.
        /// </para>
        /// <para>
        /// Windows Server 2003: This value is not supported until Windows Server 2003 with SP1 and Windows XP Professional x64 Edition.
        /// </para>
        /// </summary>
        RelationCache,

        /// <summary>
        /// <para>
        /// The specified logical processors share a physical package
        /// (a single package socketed or soldered onto a motherboard may contain multiple processor cores or threads,
        /// each of which is treated as a separate processor by the operating system).
        /// </para>
        /// <para>
        /// Windows Server 2003: This value is not supported until Windows Server 2003 with SP1 and Windows XP Professional x64 Edition.
        /// </para>
        /// </summary>
        RelationProcessorPackage,

        /// <summary>
        /// <para>
        /// The specified logical processors share a single processor group.
        /// </para>
        /// <para>
        /// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP Professional x64 Edition:
        /// This value is not supported until Windows Server 2008 R2.
        /// </para>
        /// </summary>
        RelationGroup,

        /// <summary>
        /// The specified logical processors share a single processor die.
        /// </summary>
        RelationProcessorDie,

        /// <summary>
        /// Introduced in Windows Server 2022 (21H2, build 20348).
        /// Requests that the full affinity be returned.
        /// Unlike the other relation types, <see cref="RelationNumaNodeEx"/> is not used on input.
        /// It is simply a request for <see cref="RelationNumaNode"/> with full group information.
        /// </summary>
        RelationNumaNodeEx,

        /// <summary>
        /// <para>
        /// On input, retrieves information about all possible relationship types. This value is not used on output.
        /// </para>
        /// <para>
        /// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP Professional x64 Edition:
        /// This value is not supported until Windows Server 2008 R2.
        /// </para>
        /// </summary>
        RelationProcessorModule,

        /// <summary>
        /// On input, retrieves information about all possible relationship types. This value is not used on output.
        /// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP Professional x64 Edition:
        /// This value is not supported until Windows Server 2008 R2.
        /// </summary>
        RelationAll = 0xffff,
    }
}
