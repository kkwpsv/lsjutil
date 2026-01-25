using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HKEY;
using static Lsj.Util.Win32.BaseTypes.USHORT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.COMPUTER_NAME_FORMAT;
using static Lsj.Util.Win32.Enums.LOGICAL_PROCESSOR_RELATIONSHIP;
using static Lsj.Util.Win32.Enums.PrivilegeConstants;
using static Lsj.Util.Win32.Enums.ProcessFeatures;
using static Lsj.Util.Win32.Enums.ProductTypes;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.SystemMetricIndexes;
using static Lsj.Util.Win32.Enums.VerifyVersionInfoTypeMasks;
using static Lsj.Util.Win32.Shell32;
using static Lsj.Util.Win32.Shlwapi;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using static Lsj.Util.Win32.User32;
using static Lsj.Util.Win32.Winmm;
using FILETIME = Lsj.Util.Win32.Structs.FILETIME;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// Retrieves the NetBIOS name of the local computer.
        /// This name is established at system startup, when the system reads it from the registry.
        /// </para>
        /// <para>
        /// <see cref="GetComputerName"/> retrieves only the NetBIOS name of the local computer.
        /// To retrieve the DNS host name, DNS domain name, or the fully qualified DNS name, call the <see cref="GetComputerNameEx"/> function.
        /// Additional information is provided by the <see cref="IADsADSystemInfo"/> interface.
        /// </para>
        /// <para>
        /// The behavior of this function can be affected if the local computer is a node in a cluster.
        /// For more information, see <see cref="ResUtilGetEnvironmentWithNetName"/> and <see cref="UseNetworkName"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getcomputernamew"/>
        /// </para>
        /// </summary>
        /// <param name="lpBuffer">
        /// A pointer to a buffer that receives the computer name or the cluster virtual server name.
        /// The buffer size should be large enough to contain <see cref="MAX_COMPUTERNAME_LENGTH"/> + 1 characters.
        /// </param>
        /// <param name="nSize">
        /// <para>
        /// On input, specifies the size of the buffer, in <c>TCHAR</c>s.
        /// On output, the number of TCHARs copied to the destination buffer, not including the terminating null character.
        /// </para>
        /// <para>
        /// If the buffer is too small, the function fails and <see cref="GetLastError"/> returns <see cref="ERROR_BUFFER_OVERFLOW"/>.
        /// The <paramref name="nSize"/> parameter specifies the size of the buffer required, including the terminating null character.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a nonzero value.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="GetComputerName"/> function retrieves the NetBIOS name established at system startup.
        /// Name changes made by the <see cref="SetComputerName"/> or <see cref="SetComputerNameEx"/> functions
        /// do not take effect until the user restarts the computer.
        /// </para>
        /// <para>
        /// If the caller is running under a client session, this function returns the server name.
        /// To retrieve the client name, use the <see cref="WTSQuerySessionInformation"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetComputerNameW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetComputerName([In] LPWSTR lpBuffer, [In][Out] ref DWORD nSize);

        /// <summary>
        /// <para>
        /// Retrieves a NetBIOS or DNS name associated with the local computer.
        /// The names are established at system startup, when the system reads them from the registry.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/sysinfoapi/nf-sysinfoapi-getcomputernameexw"/>
        /// </para>
        /// </summary>
        /// <param name="NameType">
        /// <para>
        /// The type of name to be retrieved.
        /// This parameter is a value from the <see cref="COMPUTER_NAME_FORMAT"/> enumeration type.
        /// The following table provides additional information.
        /// </para>
        /// <para>
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
        /// <see cref="ComputerNameDnsDomain"/>
        /// </term>
        /// <term>
        /// The name of the DNS domain assigned to the local computer.
        /// If the local computer is a node in a cluster,
        /// <paramref name="lpBuffer"/> receives the DNS domain name of the cluster virtual server.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ComputerNameDnsFullyQualified"/>
        /// </term>
        /// <term>
        /// The fully qualified DNS name that uniquely identifies the local computer.
        /// This name is a combination of the DNS host name and the DNS domain name, using the form <c>HostName.DomainName</c>.
        /// If the local computer is a node in a cluster,
        /// <paramref name="lpBuffer"/> receives the fully qualified DNS name of the cluster virtual server.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ComputerNameDnsHostname"/>
        /// </term>
        /// <term>
        /// The DNS host name of the local computer.
        /// If the local computer is a node in a cluster,
        /// <paramref name="lpBuffer"/> receives the DNS host name of the cluster virtual server.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ComputerNameNetBIOS"/>
        /// </term>
        /// <term>
        /// The NetBIOS name of the local computer.
        /// If the local computer is a node in a cluster,
        /// <paramref name="lpBuffer"/> receives the NetBIOS name of the cluster virtual server.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ComputerNamePhysicalDnsDomain"/>
        /// </term>
        /// <term>
        /// The name of the DNS domain assigned to the local computer.
        /// If the local computer is a node in a cluster,
        /// <paramref name="lpBuffer"/> receives the DNS domain name of the local computer, not the name of the cluster virtual server.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ComputerNamePhysicalDnsFullyQualified"/>
        /// </term>
        /// <term>
        /// <para>
        /// The fully qualified DNS name that uniquely identifies the computer.
        /// If the local computer is a node in a cluster,
        /// <paramref name="lpBuffer"/> receives the fully qualified DNS name of the local computer, not the name of the cluster virtual server.
        /// </para>
        /// <para>
        /// The fully qualified DNS name is a combination of the DNS host name and the DNS domain name, using the form <c>HostName.DomainName</c>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ComputerNamePhysicalDnsHostname"/>
        /// </term>
        /// <term>
        /// The DNS host name of the local computer.
        /// If the local computer is a node in a cluster,
        /// <paramref name="lpBuffer"/> receives the DNS host name of the local computer, not the name of the cluster virtual server.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ComputerNamePhysicalNetBIOS"/>
        /// </term>
        /// <term>
        /// The NetBIOS name of the local computer.
        /// If the local computer is a node in a cluster,
        /// <paramref name="lpBuffer"/> receives the NetBIOS name of the local computer, not the name of the cluster virtual server.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpBuffer">
        /// <para>
        /// A pointer to a buffer that receives the computer name or the cluster virtual server name.
        /// </para>
        /// <para>
        /// The length of the name may be greater than <see cref="MAX_COMPUTERNAME_LENGTH"/> characters because DNS allows longer names.
        /// To ensure that this buffer is large enough, set this parameter to <see cref="NULL"/>
        /// and use the required buffer size returned in the <paramref name="nSize"/> parameter.
        /// </para>
        /// </param>
        /// <param name="nSize">
        /// <para>
        /// On input, specifies the size of the buffer, in <c>TCHAR</c>s.
        /// On output, receives the number of <c>TCHAR</c>s copied to the destination buffer,
        /// not including the terminating <c>null</c> character.
        /// </para>
        /// <para>
        /// If the buffer is too small, the function fails and <see cref="GetLastError"/> returns <see cref="ERROR_MORE_DATA"/>.
        /// This parameter receives the size of the buffer required, including the terminating <c>null</c> character.
        /// </para>
        /// <para>
        /// If <paramref name="lpBuffer"/> is <see cref="NULL"/>, this parameter must be zero.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a nonzero value.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// Possible values include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_MORE_DATA"/>
        /// </term>
        /// <term>
        /// The <paramref name="lpBuffer"/> buffer is too small.
        /// The <paramref name="nSize"/> parameter contains the number of bytes required to receive the name.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If group policy is not set for the local machine,
        /// the <see cref="GetComputerNameEx"/> function retrieves the NetBIOS or DNS names established at system startup.
        /// If group policy is set, the function returns the primary domain name set by group policy.
        /// Name changes made by the <see cref="SetComputerName"/> or <see cref="SetComputerNameEx"/> functions
        /// do not take effect until the user restarts the computer.
        /// </para>
        /// <para>
        /// If the local computer is not configured to use DNS names, <see cref="GetComputerNameEx"/> will not return DNS information.
        /// To configure the computer to do this, follow the steps outlined in the operating system help
        /// and change the primary DNS suffix of the computer, then restart the computer.
        /// </para>
        /// <para>
        /// The behavior of this function can be affected if the local computer is a node in a cluster.
        /// For more information, see <see cref="ResUtilGetEnvironmentWithNetName"/> and <see cref="UseNetworkName"/>.
        /// </para>
        /// <para>
        /// If you are working with environments that use different DNS layouts,
        /// where the computer's FQDN does not match the FQDN of its domain, use <see cref="LsaQueryInformationPolicy"/> instead.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetComputerNameExW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetComputerNameEx([In] COMPUTER_NAME_FORMAT NameType, [In] LPWSTR lpBuffer, [In][Out] ref DWORD nSize);

        /// <summary>
        /// <para>
        /// Retrieves the current local date and time.
        /// </para>
        /// <para>
        /// To retrieve the current date and time in Coordinated Universal Time (UTC) format, use the <see cref="GetSystemTime"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/sysinfoapi/nf-sysinfoapi-getlocaltime"/>
        /// </para>
        /// </summary>
        /// <param name="lpSystemTime">
        /// A pointer to a <see cref="SYSTEMTIME"/> structure to receive the current local date and time.
        /// </param>
        /// <remarks>
        /// To set the current local date and time, use the <see cref="SetLocalTime"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetLocalTime", ExactSpelling = true)]
        public static extern void GetLocalTime([Out] out SYSTEMTIME lpSystemTime);

        /// <summary>
        /// <para>
        /// Retrieves information about logical processors and related hardware.
        /// </para>
        /// <para>
        /// To retrieve information about logical processors and related hardware, including processor groups,
        /// use the <see cref="GetLogicalProcessorInformationEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/sysinfoapi/nf-sysinfoapi-getlogicalprocessorinformation"/>
        /// </para>
        /// </summary>
        /// <param name="Buffer">
        /// A pointer to a buffer that receives an array of <see cref="SYSTEM_LOGICAL_PROCESSOR_INFORMATION"/> structures.
        /// If the function fails, the contents of this buffer are undefined.
        /// </param>
        /// <param name="ReturnedLength">
        /// On input, specifies the length of the buffer pointed to by Buffer, in bytes.
        /// If the buffer is large enough to contain all of the data, this function succeeds and
        /// <paramref name="ReturnedLength"/> is set to the number of bytes returned.
        /// If the buffer is not large enough to contain all of the data, the function fails,
        /// <see cref="GetLastError"/> returns <see cref="ERROR_INSUFFICIENT_BUFFER"/>,
        /// and <paramref name="ReturnedLength"/> is set to the buffer length required to contain all of the data.
        /// If the function fails with an error other than <see cref="ERROR_INSUFFICIENT_BUFFER"/>,
        /// the value of <paramref name="ReturnedLength"/> is undefined.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="TRUE"/>
        /// and at least one <see cref="SYSTEM_LOGICAL_PROCESSOR_INFORMATION"/> structure is written to the output buffer.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="GetLogicalProcessorInformation"/> can be used to get information
        /// about the relationship between logical processors in the system, including:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The logical processors that are part of a NUMA node.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The logical processors that share resources.
        /// An example of this type of resource sharing would be hyperthreading scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Your application can use this information when affinitizing your threads and processes
        /// to take best advantage of the hardware properties of the platform,
        /// or to determine the number of logical and physical processors for licensing purposes.
        /// </para>
        /// <para>
        /// Each of the <see cref="SYSTEM_LOGICAL_PROCESSOR_INFORMATION"/> structures returned in the buffer contains the following:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// A logical processor affinity mask, which indicates the logical processors that the information in the structure applies to.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A logical processor mask of type <see cref="LOGICAL_PROCESSOR_RELATIONSHIP"/>,
        /// which indicates the relationship between the logical processors in the mask.
        /// Applications calling this function must be prepared to handle additional indicator values in the future.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Note that the order in which the structures are returned in the buffer may change between calls to this function.
        /// </para>
        /// <para>
        /// The size of the <see cref="SYSTEM_LOGICAL_PROCESSOR_INFORMATION"/> structure varies
        /// between processor architectures and versions of Windows.
        /// For this reason, applications should first call this function to obtain the required buffer size,
        /// then dynamically allocate memory for the buffer.
        /// </para>
        /// <para>
        /// On systems with more than 64 logical processors,
        /// the <see cref="GetLogicalProcessorInformation"/> function retrieves logical processor information
        /// about processors in the processor group to which the calling thread is currently assigned.
        /// Use the <see cref="GetLogicalProcessorInformationEx"/> function to retrieve information
        /// about processors in all processor groups on the system.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Starting with TBD Release Iron, the behavior of this and other NUMA functions has been modified
        /// to better support systems with nodes containing more that 64 processors.
        /// For more information about this change, including information about enabling the old behavior of this API, see NUMA Support.
        /// </para>
        /// <para>
        /// Behavior starting with TBD Release Iron
        /// </para>
        /// <para>
        /// The relationship structures for <see cref="RelationNumaNode"/> contain
        /// the affinity mask for the node's affinity within the calling thread's group.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP, Note = "Windows XP with SP3")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetLogicalProcessorInformation", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetLogicalProcessorInformation([Out] out SYSTEM_LOGICAL_PROCESSOR_INFORMATION Buffer, [In][Out] ref uint ReturnedLength);

        /// <summary>
        /// <para>
        /// Retrieves information about the relationships of logical processors and related hardware.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/sysinfoapi/nf-sysinfoapi-getlogicalprocessorinformationex"/>
        /// </para>
        /// </summary>
        /// <param name="RelationshipType">
        /// <para>
        /// The type of relationship to retrieve.
        /// This parameter can be one of the following <see cref="LOGICAL_PROCESSOR_RELATIONSHIP"/> values.
        /// </para>
        /// <para>
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
        /// <see cref="RelationProcessorCore"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves information about logical processors that share a single processor core.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RelationNumaNode"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves information about logical processors that are part of the same NUMA node.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RelationCache"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves information about logical processors that share a cache.
        /// </term>
        /// </item>
        /// <item>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RelationProcessorPackage"/>
        /// </para>
        /// <para>
        /// 3
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves information about logical processors that share a physical package.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RelationGroup"/>
        /// </para>
        /// <para>
        /// 4
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves information about logical processors that share a processor group.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RelationProcessorDie"/>
        /// </para>
        /// <para>
        /// 5
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves information about logical processors that share a processor die.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RelationNumaNodeEx"/>
        /// </para>
        /// <para>
        /// 6
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves information about logical processors that are part of the same NUMA node (with full affinity).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RelationProcessorModule"/>
        /// </para>
        /// <para>
        /// 7
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves information about logical processors that share a processor module.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RelationAll"/>
        /// </para>
        /// <para>
        /// 0xffff
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves information about logical processors for all relationship types
        /// (cache, NUMA node, processor core, physical package, processor group, processor die, and processor module).
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="Buffer">
        /// A pointer to a buffer that receives an array of <see cref="SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX"/> structures.
        /// If the function fails, the contents of this buffer are undefined.
        /// </param>
        /// <param name="ReturnedLength">
        /// On input, specifies the length of the buffer pointed to by <paramref name="Buffer"/>, in bytes.
        /// If the buffer is large enough to contain all of the data,
        /// this function succeeds and <paramref name="ReturnedLength"/> is set to the number of bytes returned.
        /// If the buffer is not large enough to contain all of the data,
        /// the function fails, <see cref="GetLastError"/> returns <see cref="ERROR_INSUFFICIENT_BUFFER"/>,
        /// and <paramref name="ReturnedLength"/> is set to the buffer length required to contain all of the data.
        /// If the function fails with an error other than <see cref="ERROR_INSUFFICIENT_BUFFER"/>,
        /// the value of <paramref name="ReturnedLength"/> is undefined.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="TRUE"/>
        /// and at least one <see cref="SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX"/> structure is written to the output buffer.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If a 32-bit process running under WOW64 calls this function on a system with more than 64 processors,
        /// some of the processor affinity masks returned by the function may be incorrect.
        /// This is because the high-order <see cref="DWORD"/> of the 64-bit <see cref="KAFFINITY"/> structure
        /// that represents all 64 processors is "folded" into a 32-bit <see cref="KAFFINITY"/> structure in the caller's buffer.
        /// As a result, the affinity masks for processors 32 through 63 are incorrectly
        /// represented as duplicates of the masks for processors 0 through 31.
        /// In addition, the affinity masks for processors 32 through 63 are incorrectly
        /// represented as duplicates of the masks for processors 0 through 31.
        /// In addition, the sum of all per-group <see cref="PROCESSOR_GROUP_INFO.ActiveProcessorCount"/>
        /// and <see cref="PROCESSOR_GROUP_INFO.MaximumProcessorCount"/> values reported
        /// in <see cref="PROCESSOR_GROUP_INFO"/> structures may exclude some active logical processors.
        /// </para>
        /// <para>
        /// When this function is called with a relationship type of <see cref="RelationProcessorCore"/>, 
        /// it returns a <see cref="PROCESSOR_RELATIONSHIP"/> structure for every active processor core in every processor group in the system.
        /// This is by design, because an unaffinitized 32-bit thread can run on any logical processor in a given group,
        /// including processors 32 through 63.
        /// A 32-bit caller can use the total count of <see cref="PROCESSOR_RELATIONSHIP"/> structures
        /// to determine the actual number of active processor cores on the system.
        /// However, the affinity of a 32-bit thread cannot be explicitly set to logical processor 32 through 63 of any processor group.
        /// </para>
        /// <para>
        /// Behavior starting with Windows Server 2022 (21H2, build 20348)
        /// </para>
        /// <para>
        /// The behavior of this and other NUMA functions has been modified to better support systems with nodes containing more that 64 processors.
        /// For more information about this change, including information about enabling the old behavior of this API, see NUMA Support.
        /// </para>
        /// <para>
        /// Requests for <see cref="RelationNumaNode"/> will return <see cref="NUMA_NODE_RELATIONSHIP"/> structures
        /// that contain only the affinity of the node within it's primary group.
        /// The <see cref="NUMA_NODE_RELATIONSHIP.GroupCount"/> value will be 1 and the structure size is fixed.
        /// </para>
        /// <para>
        /// Requests for <see cref="RelationNumaNodeEx"/> or <see cref="RelationAll"/> will return <see cref="NUMA_NODE_RELATIONSHIP"/> structures
        /// that contain an array of affinities for the node over all groups.
        /// The <see cref="NUMA_NODE_RELATIONSHIP.GroupCount"/> reports the number of affinities and the size of structure is variable.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetLogicalProcessorInformationEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetLogicalProcessorInformationEx([In] LOGICAL_PROCESSOR_RELATIONSHIP RelationshipType,
            [Out] out SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX Buffer, [In][Out] ref DWORD ReturnedLength);

        /// <summary>
        /// <para>
        /// Retrieves information about the current system to an application running under WOW64.
        /// If the function is called from a 64-bit application, it is equivalent to the <see cref="GetSystemInfo"/> function.
        /// If the function is called from an x86 or x64 application running on a 64-bit system
        /// that does not have an Intel64 or x64 processor (such as ARM64),
        /// it will return information as if the system is x86 only if x86 emulation is supported (or x64 if x64 emulation is also supported).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/sysinfoapi/nf-sysinfoapi-getnativesysteminfo"/>
        /// </para>
        /// </summary>
        /// <param name="lpSystemInfo">
        /// A pointer to a <see cref="SYSTEM_INFO"/> structure that receives the information.
        /// </param>
        /// <remarks>
        /// To determine if a Win32-based application is running under WOW64 (or if a 64-bit system does not have an Intel64 or x64 processor),
        /// call the <see cref="IsWow64Process2"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetNativeSystemInfo", ExactSpelling = true)]
        public static extern void GetNativeSystemInfo([Out] out SYSTEM_INFO lpSystemInfo);

        /// <summary>
        /// <para>
        /// Retrieves the amount of memory available in the specified node.
        /// </para>
        /// <para>
        /// Use the <see cref="GetNumaAvailableMemoryNodeEx"/> function to specify the node as a <see cref="USHORT"/> value.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getnumaavailablememorynode"/>
        /// </para>
        /// </summary>
        /// <param name="Node">
        /// The number of the node.
        /// </param>
        /// <param name="AvailableBytes">
        /// The amount of available memory for the node, in bytes.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="GetNumaAvailableMemoryNode"/> function returns the amount of memory
        /// consumed by free and zeroed pages on the specified node.
        /// On systems with more than one node, this memory does not include standby pages.
        /// Therefore, the sum of the available memory values for all nodes in the system is equal
        /// to the value of the Free &amp; Zero Page List Bytes memory performance counter.
        /// On systems with only one node, the value returned by <see cref="GetNumaAvailableMemoryNode"/> includes standby pages and is equal
        /// to the value of the Available Bytes memory performance counter.
        /// For more information about performance counters, see Memory Performance Information.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP, Note = "Windows XP with SP2")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetNumaAvailableMemoryNode", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetNumaAvailableMemoryNode([In] UCHAR Node, [Out] out ULONGLONG AvailableBytes);

        /// <summary>
        /// <para>
        /// Retrieves the amount of memory that is available in a node specified as a <see cref="USHORT"/> value.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getnumaavailablememorynodeex"/>
        /// </para>
        /// </summary>
        /// <param name="Node">
        /// The number of the node.
        /// </param>
        /// <param name="AvailableBytes">
        /// The amount of available memory for the node, in bytes.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="GetNumaAvailableMemoryNodeEx"/> function returns the amount of memory
        /// consumed by free and zeroed pages on the specified node.
        /// On systems with more than one node, this memory does not include standby pages.
        /// Therefore, the sum of the available memory values for all nodes in the system
        /// is equal to the value of the Free &amp; Zero Page List Bytes memory performance counter.
        /// On systems with only one node, the value returned by <see cref="GetNumaAvailableMemoryNode"/>
        /// includes standby pages and is equal to the value of the Available Bytes memory performance counter.
        /// For more information about performance counters, see Memory Performance Information.
        /// </para>
        /// <para>
        /// The only difference between the <see cref="GetNumaAvailableMemoryNodeEx"/> function
        /// and the <see cref="GetNumaAvailableMemoryNode"/> function is the data type of the Node parameter.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetNumaAvailableMemoryNodeEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetNumaAvailableMemoryNodeEx([In] USHORT Node, [Out] out ULONGLONG AvailableBytes);

        /// <summary>
        /// <para>
        /// Retrieves the node that currently has the highest number.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/systemtopologyapi/nf-systemtopologyapi-getnumahighestnodenumber"/>
        /// </para>
        /// </summary>
        /// <param name="HighestNodeNumber">
        /// The number of the highest node.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The number of the highest node is not guaranteed to be the total number of nodes.
        /// </para>
        /// <para>
        /// To retrieve a list of all processors in a node, use the <see cref="GetNumaNodeProcessorMask"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP, Note = "Windows XP with SP2")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetNumaHighestNodeNumber", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetNumaHighestNodeNumber([Out] out ULONG HighestNodeNumber);

        /// <summary>
        /// <para>
        /// Retrieves the processor mask for the specified node.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getnumanodeprocessormask"/>
        /// </para>
        /// </summary>
        /// <param name="Node">
        /// The number of the node.
        /// </param>
        /// <param name="ProcessorMask">
        /// <para>
        /// The processor mask for the node.
        /// A processor mask is a bit vector in which each bit represents a processor and whether it is in the node.
        /// </para>
        /// <para>
        /// If the node has no processors configured, the processor mask is zero.
        /// </para>
        /// <para>
        /// On systems with more than 64 processors, this parameter is set to the processor mask for the node
        /// only if the node is in the same processor group as the calling thread.
        /// Otherwise, the parameter is set to zero.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To retrieve the highest numbered node in the system, use the <see cref="GetNumaHighestNodeNumber"/> function.
        /// Note that this number is not guaranteed to equal the total number of nodes in the system.
        /// </para>
        /// <para>
        /// To ensure that all threads for your process run on the same node,
        /// use the <see cref="SetProcessAffinityMask"/> function with a process affinity mask that specifies processors in the same node.
        /// </para>
        /// <para>
        /// Use the <see cref="GetNumaNodeProcessorMaskEx"/> function to retrieve the processor mask for a node in any processor group.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Starting with TBD Release Iron, the behavior of this and other NUMA functions has been modified
        /// to better support systems with nodes containing more that 64 processors.
        /// For more information about this change, including information about enabling the old behavior of this API, see NUMA Support.
        /// </para>
        /// <para>
        /// Behavior starting with TBD Release Iron
        /// </para>
        /// <para>
        /// Each node is assigned a primary group by the system.
        /// The mask returned by <see cref="GetNumaNodeProcessorMask"/> is for the node's primary group
        /// and is only returned if the calling thread belongs to that group.
        /// </para>
        /// <para>
        /// Behavior in previous versions
        /// </para>
        /// <para>
        /// The mask for the specified node is returned.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP, Note = "Windows XP with SP2")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetNumaNodeProcessorMask", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetNumaNodeProcessorMask([In] UCHAR Node, [Out] out ULONGLONG ProcessorMask);

        /// <summary>
        /// <para>
        /// Retrieves the processor mask for a node regardless of the processor group the node belongs to.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/systemtopologyapi/nf-systemtopologyapi-getnumanodeprocessormaskex"/>
        /// </para>
        /// </summary>
        /// <param name="Node">
        /// The node number.
        /// </param>
        /// <param name="ProcessorMask">
        /// <para>
        /// A pointer to a <see cref="GROUP_AFFINITY"/> structure that receives the processor mask for the specified node.
        /// A processor mask is a bit vector in which each bit represents a processor and whether it is in the node.
        /// </para>
        /// <para>
        /// If the specified node has no processors configured,
        /// the <see cref="GROUP_AFFINITY.Mask"/> member is zero and the <see cref="GROUP_AFFINITY.Group"/> member is undefined.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="GetNumaNodeProcessorMaskEx"/> function differs from <see cref="GetNumaNodeProcessorMask"/>
        /// in that it can retrieve the processor mask for a node regardless of the group the node belongs to.
        /// That is, the node does not have to be in the same group as the calling thread.
        /// The <see cref="GetNumaNodeProcessorMask"/> function can retrieve the processor mask
        /// only for nodes that are in the same group as the calling thread.
        /// </para>
        /// <para>
        /// To retrieve the highest numbered node in the system, use the <see cref="GetNumaHighestNodeNumber"/> function.
        /// Note that this number is not guaranteed to equal the total number of nodes in the system.
        /// </para>
        /// <para>
        /// To ensure that all threads for your process run on the same node,
        /// use the <see cref="SetProcessAffinityMask"/> function with a process affinity mask that specifies processors in the same node.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetNumaNodeProcessorMaskEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetNumaNodeProcessorMaskEx([In] USHORT Node, [Out] out GROUP_AFFINITY ProcessorMask);

        /// <summary>
        /// <para>
        /// Retrieves the node number for the specified processor.
        /// </para>
        /// <para>
        /// Use the <see cref="GetNumaProcessorNodeEx"/> function to specify a processor group
        /// and retrieve the node number as a <see cref="USHORT"/> value.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getnumaprocessornode"/>
        /// </para>
        /// </summary>
        /// <param name="Processor">
        /// <para>
        /// The processor number.
        /// </para>
        /// <para>
        /// On a system with more than 64 logical processors, the processor number is relative to the processor group
        /// that contains the processor on which the calling thread is running.
        /// </para>
        /// </param>
        /// <param name="NodeNumber">
        /// The node number.
        /// If the processor does not exist, this parameter is 0xFF.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// To retrieve the list of processors on the system, use the <see cref="GetProcessAffinityMask"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP, Note = "Windows XP with SP2")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetNumaProcessorNode", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetNumaProcessorNode([In] UCHAR Processor, [Out] out UCHAR NodeNumber);

        /// <summary>
        /// <para>
        /// Retrieves the node number as a <see cref="USHORT"/> value for the specified logical processor.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getnumaprocessornodeex"/>
        /// </para>
        /// </summary>
        /// <param name="Processor">
        /// A pointer to a <see cref="PROCESSOR_NUMBER"/> structure
        /// that represents the logical processor and the processor group to which it is assigned.
        /// </param>
        /// <param name="NodeNumber">
        /// A pointer to a variable to receive the node number.
        /// If the specified processor does not exist, this parameter is set to <see cref="MAXUSHORT"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetNumaProcessorNodeEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetNumaProcessorNodeEx([Out] out PROCESSOR_NUMBER Processor, [Out] out USHORT NodeNumber);

        /// <summary>
        /// <para>
        /// Retrieves the product type for the operating system on the local computer,
        /// and maps the type to the product types supported by the specified operating system.
        /// </para>
        /// <para>
        /// To retrieve product type information on versions of Windows prior to the minimum supported operating systems
        /// specified in the Requirements section, use the <see cref="GetVersionEx"/> function.
        /// You can also use the <c>OperatingSystemSKU</c> property of the <c>Win32_OperatingSystem</c> WMI class.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/sysinfoapi/nf-sysinfoapi-getproductinfo"/>
        /// </para>
        /// </summary>
        /// <param name="dwOSMajorVersion">
        /// <para>
        /// The major version number of the operating system. The minimum value is 6.
        /// </para>
        /// <para>
        /// The combination of the <paramref name="dwOSMajorVersion"/>, <paramref name="dwOSMinorVersion"/>,
        /// <paramref name="dwSpMajorVersion"/>, and <paramref name="dwSpMinorVersion"/> parameters
        /// describes the maximum target operating system version for the application.
        /// For example, Windows Vista and Windows Server 2008 are version 6.0.0.0 and Windows 7 and Windows Server 2008 R2 are version 6.1.0.0.
        /// All Windows 10 based releases will be listed as version 6.3.
        /// </para>
        /// </param>
        /// <param name="dwOSMinorVersion">
        /// The minor version number of the operating system. The minimum value is 0.
        /// </param>
        /// <param name="dwSpMajorVersion">
        /// The major version number of the operating system service pack. The minimum value is 0.
        /// </param>
        /// <param name="dwSpMinorVersion">
        /// The minor version number of the operating system service pack. The minimum value is 0.
        /// </param>
        /// <param name="pdwReturnedProductType">
        /// <para>
        /// The product type. This parameter cannot be <see cref="NullRef{DWORD}"/>.
        /// If the specified operating system is less than the current operating system,
        /// this information is mapped to the types supported by the specified operating system.
        /// If the specified operating system is greater than the highest supported operating system,
        /// this information is mapped to the types supported by the current operating system.
        /// </para>
        /// <para>
        /// This parameter can be one of the following values (some products below may be out of support).
        /// </para>
        /// <para>
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
        /// <see cref="PRODUCT_BUSINESS"/>
        /// </para>
        /// <para>
        /// 0x00000006
        /// </para>
        /// </term>
        /// <term>
        /// Business
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_BUSINESS_N"/>
        /// </para>
        /// <para>
        /// 0x00000010
        /// </para>
        /// </term>
        /// <term>
        /// Business N
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_CLUSTER_SERVER"/>
        /// </para>
        /// <para>
        /// 0x00000012
        /// </para>
        /// </term>
        /// <term>
        /// HPC Edition
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_CLUSTER_SERVER_V"/>
        /// </para>
        /// <para>
        /// 0x00000040
        /// </para>
        /// </term>
        /// <term>
        /// Server Hyper Core V
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_CORE"/>
        /// </para>
        /// <para>
        /// 0x00000065
        /// </para>
        /// </term>
        /// <term>
        /// Windows 10 Home
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_CORE_COUNTRYSPECIFIC"/>
        /// </para>
        /// <para>
        /// 0x00000063
        /// </para>
        /// </term>
        /// <term>
        /// Windows 10 Home China
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_CORE_N"/>
        /// </para>
        /// <para>
        /// 0x00000062
        /// </para>
        /// </term>
        /// <term>
        /// Windows 10 Home N
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_CORE_SINGLELANGUAGE"/>
        /// </para>
        /// <para>
        /// 0x00000064
        /// </para>
        /// </term>
        /// <term>
        /// Windows 10 Home Single Language
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_DATACENTER_EVALUATION_SERVER"/>
        /// </para>
        /// <para>
        /// 0x00000050
        /// </para>
        /// </term>
        /// <term>
        /// Server Datacenter (evaluation installation)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_DATACENTER_A_SERVER_CORE"/>
        /// </para>
        /// <para>
        /// 0x00000091
        /// </para>
        /// </term>
        /// <term>
        /// Server Datacenter, Semi-Annual Channel (core installation)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_STANDARD_A_SERVER_CORE"/>
        /// </para>
        /// <para>
        /// 0x00000092
        /// </para>
        /// </term>
        /// <term>
        /// Server Standard, Semi-Annual Channel (core installation)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_DATACENTER_SERVER"/>
        /// </para>
        /// <para>
        /// 0x00000008
        /// </para>
        /// </term>
        /// <term>
        /// Server Datacenter (full installation. For Server Core installations of Windows Server 2012 and later, use the method, Determining whether Server Core is running.)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_DATACENTER_SERVER_CORE"/>
        /// </para>
        /// <para>
        /// 0x0000000C
        /// </para>
        /// </term>
        /// <term>
        /// Server Datacenter (core installation, Windows Server 2008 R2 and earlier)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_DATACENTER_SERVER_CORE_V"/>
        /// </para>
        /// <para>
        /// 0x00000027
        /// </para>
        /// </term>
        /// <term>
        /// Server Datacenter without Hyper-V (core installation)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_DATACENTER_SERVER_V"/>
        /// </para>
        /// <para>
        /// 0x00000025
        /// </para>
        /// </term>
        /// <term>
        /// Server Datacenter without Hyper-V (full installation)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_EDUCATION"/>
        /// </para>
        /// <para>
        /// 0x00000079
        /// </para>
        /// </term>
        /// <term>
        /// Windows 10 Education
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_EDUCATION_N"/>
        /// </para>
        /// <para>
        /// 0x0000007A
        /// </para>
        /// </term>
        /// <term>
        /// Windows 10 Education N
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_ENTERPRISE"/>
        /// </para>
        /// <para>
        /// 0x00000004
        /// </para>
        /// </term>
        /// <term>
        /// Windows 10 Enterprise
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_ENTERPRISE_E"/>
        /// </para>
        /// <para>
        /// 0x00000046
        /// </para>
        /// </term>
        /// <term>
        /// Windows 10 Enterprise E
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_ENTERPRISE_EVALUATION"/>
        /// </para>
        /// <para>
        /// 0x00000048
        /// </para>
        /// </term>
        /// <term>
        /// Windows 10 Enterprise Evaluation
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_ENTERPRISE_N"/>
        /// </para>
        /// <para>
        /// 0x0000001B
        /// </para>
        /// </term>
        /// <term>
        /// Windows 10 Enterprise N
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_ENTERPRISE_N_EVALUATION"/>
        /// </para>
        /// <para>
        /// 0x00000054
        /// </para>
        /// </term>
        /// <term>
        /// Windows 10 Enterprise N Evaluation
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_ENTERPRISE_S"/>
        /// </para>
        /// <para>
        /// 0x0000007D
        /// </para>
        /// </term>
        /// <term>
        /// Windows 10 Enterprise 2015 LTSB
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_ENTERPRISE_S_EVALUATION"/>
        /// </para>
        /// <para>
        /// 0x00000081
        /// </para>
        /// </term>
        /// <term>
        /// Windows 10 Enterprise 2015 LTSB Evaluation
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_ENTERPRISE_S_N"/>
        /// </para>
        /// <para>
        /// 0x0000007E
        /// </para>
        /// </term>
        /// <term>
        /// Windows 10 Enterprise 2015 LTSB N
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_ENTERPRISE_S_N_EVALUATION"/>
        /// </para>
        /// <para>
        /// 0x00000082
        /// </para>
        /// </term>
        /// <term>
        /// Windows 10 Enterprise 2015 LTSB N Evaluation
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_ENTERPRISE_SERVER"/>
        /// </para>
        /// <para>
        /// 0x0000000A
        /// </para>
        /// </term>
        /// <term>
        /// Server Enterprise (full installation)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_ENTERPRISE_SERVER_CORE"/>
        /// </para>
        /// <para>
        /// 0x0000000E
        /// </para>
        /// </term>
        /// <term>
        /// Server Enterprise (core installation)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_ENTERPRISE_SERVER_CORE_V"/>
        /// </para>
        /// <para>
        /// 0x00000029
        /// </para>
        /// </term>
        /// <term>
        /// Server Enterprise without Hyper-V (core installation)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_ENTERPRISE_SERVER_IA64"/>
        /// </para>
        /// <para>
        /// 0x0000000F
        /// </para>
        /// </term>
        /// <term>
        /// Server Enterprise for Itanium-based Systems
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_ENTERPRISE_SERVER_V"/>
        /// </para>
        /// <para>
        /// 0x00000026
        /// </para>
        /// </term>
        /// <term>
        /// Server Enterprise without Hyper-V (full installation)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_ESSENTIALBUSINESS_SERVER_ADDL"/>
        /// </para>
        /// <para>
        /// 0x0000003C
        /// </para>
        /// </term>
        /// <term>
        /// Windows Essential Server Solution Additional
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_ESSENTIALBUSINESS_SERVER_ADDLSVC"/>
        /// </para>
        /// <para>
        /// 0x0000003E
        /// </para>
        /// </term>
        /// <term>
        /// Windows Essential Server Solution Additional SVC
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_ESSENTIALBUSINESS_SERVER_MGMT"/>
        /// </para>
        /// <para>
        /// 0x0000003B
        /// </para>
        /// </term>
        /// <term>
        /// Windows Essential Server Solution Management
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_ESSENTIALBUSINESS_SERVER_MGMTSVC"/>
        /// </para>
        /// <para>
        /// 0x0000003D
        /// </para>
        /// </term>
        /// <term>
        /// Windows Essential Server Solution Management SVC
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_HOME_BASIC"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// Home Basic
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_HOME_BASIC_E"/>
        /// </para>
        /// <para>
        /// 0x00000043
        /// </para>
        /// </term>
        /// <term>
        /// Not supported
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_HOME_BASIC_N"/>
        /// </para>
        /// <para>
        /// 0x00000005
        /// </para>
        /// </term>
        /// <term>
        /// Home Basic N
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_HOME_PREMIUM"/>
        /// </para>
        /// <para>
        /// 0x00000003
        /// </para>
        /// </term>
        /// <term>
        /// Home Premium
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_HOME_PREMIUM_E"/>
        /// </para>
        /// <para>
        /// 0x00000044
        /// </para>
        /// </term>
        /// <term>
        /// Not supported
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_HOME_PREMIUM_N"/>
        /// </para>
        /// <para>
        /// 0x0000001A
        /// </para>
        /// </term>
        /// <term>
        /// Home Premium N
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_HOME_PREMIUM_SERVER"/>
        /// </para>
        /// <para>
        /// 0x00000022
        /// </para>
        /// </term>
        /// <term>
        /// Windows Home Server 2011
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_HOME_SERVER"/>
        /// </para>
        /// <para>
        /// 0x00000013
        /// </para>
        /// </term>
        /// <term>
        /// Windows Storage Server 2008 R2 Essentials
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_HYPERV"/>
        /// </para>
        /// <para>
        /// 0x0000002A
        /// </para>
        /// </term>
        /// <term>
        /// Microsoft Hyper-V Server
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_IOTENTERPRISE"/>
        /// </para>
        /// <para>
        /// 0x000000BC
        /// </para>
        /// </term>
        /// <term>
        /// Windows IoT Enterprise
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_IOTENTERPRISE_S"/>
        /// </para>
        /// <para>
        /// 0x000000BF
        /// </para>
        /// </term>
        /// <term>
        /// Windows IoT Enterprise LTSC
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_IOTUAP"/>
        /// </para>
        /// <para>
        /// 0x0000007B
        /// </para>
        /// </term>
        /// <term>
        /// Windows 10 IoT Core
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_IOTUAPCOMMERCIAL"/>
        /// </para>
        /// <para>
        /// 0x00000083
        /// </para>
        /// </term>
        /// <term>
        /// Windows 10 IoT Core Commercial
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_MEDIUMBUSINESS_SERVER_MANAGEMENT"/>
        /// </para>
        /// <para>
        /// 0x0000001E
        /// </para>
        /// </term>
        /// <term>
        /// Windows Essential Business Server Management Server
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_MEDIUMBUSINESS_SERVER_MESSAGING"/>
        /// </para>
        /// <para>
        /// 0x00000020
        /// </para>
        /// </term>
        /// <term>
        /// Windows Essential Business Server Messaging Server
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_MEDIUMBUSINESS_SERVER_SECURITY"/>
        /// </para>
        /// <para>
        /// 0x0000001F
        /// </para>
        /// </term>
        /// <term>
        /// Windows Essential Business Server Security Server
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_MOBILE_CORE"/>
        /// </para>
        /// <para>
        /// 0x00000068
        /// </para>
        /// </term>
        /// <term>
        /// Windows 10 Mobile
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_MOBILE_ENTERPRISE"/>
        /// </para>
        /// <para>
        /// 0x00000085
        /// </para>
        /// </term>
        /// <term>
        /// Windows 10 Mobile Enterprise
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_MULTIPOINT_PREMIUM_SERVER"/>
        /// </para>
        /// <para>
        /// 0x0000004D
        /// </para>
        /// </term>
        /// <term>
        /// Windows MultiPoint Server Premium (full installation)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_MULTIPOINT_STANDARD_SERVER"/>
        /// </para>
        /// <para>
        /// 0x0000004C
        /// </para>
        /// </term>
        /// <term>
        /// Windows MultiPoint Server Standard (full installation)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_PPI_PRO"/>
        /// </para>
        /// <para>
        /// 0x00000077
        /// </para>
        /// </term>
        /// <term>
        /// Windows 10 Team
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_PRO_FOR_EDUCATION"/>
        /// </para>
        /// <para>
        /// 0x000000A4
        /// </para>
        /// </term>
        /// <term>
        /// Windows 10 Pro Education
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_PRO_WORKSTATION"/>
        /// </para>
        /// <para>
        /// 0x000000A1
        /// </para>
        /// </term>
        /// <term>
        /// Windows 10 Pro for Workstations
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_PRO_WORKSTATION_N"/>
        /// </para>
        /// <para>
        /// 0x000000A2
        /// </para>
        /// </term>
        /// <term>
        /// Windows 10 Pro for Workstations N
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_PROFESSIONAL"/>
        /// </para>
        /// <para>
        /// 0x00000030
        /// </para>
        /// </term>
        /// <term>
        /// Windows 10 Pro
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_PROFESSIONAL_E"/>
        /// </para>
        /// <para>
        /// 0x00000045
        /// </para>
        /// </term>
        /// <term>
        /// Not supported
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_PROFESSIONAL_N"/>
        /// </para>
        /// <para>
        /// 0x00000031
        /// </para>
        /// </term>
        /// <term>
        /// Windows 10 Pro N
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_PROFESSIONAL_WMC"/>
        /// </para>
        /// <para>
        /// 0x00000067
        /// </para>
        /// </term>
        /// <term>
        /// Professional with Media Center
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_SB_SOLUTION_SERVER"/>
        /// </para>
        /// <para>
        /// 0x00000032
        /// </para>
        /// </term>
        /// <term>
        /// Windows Small Business Server 2011 Essentials
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_SB_SOLUTION_SERVER_EM"/>
        /// </para>
        /// <para>
        /// 0x00000036
        /// </para>
        /// </term>
        /// <term>
        /// Server For SB Solutions EM
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_SERVER_FOR_SB_SOLUTIONS"/>
        /// </para>
        /// <para>
        /// 0x00000033
        /// </para>
        /// </term>
        /// <term>
        /// Server For SB Solutions
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_SERVER_FOR_SB_SOLUTIONS_EM"/>
        /// </para>
        /// <para>
        /// 0x00000037
        /// </para>
        /// </term>
        /// <term>
        /// Server For SB Solutions EM
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_SERVER_FOR_SMALLBUSINESS"/>
        /// </para>
        /// <para>
        /// 0x00000018
        /// </para>
        /// </term>
        /// <term>
        /// Windows Server 2008 for Windows Essential Server Solutions
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_SERVER_FOR_SMALLBUSINESS_V"/>
        /// </para>
        /// <para>
        /// 0x00000023
        /// </para>
        /// </term>
        /// <term>
        /// Windows Server 2008 without Hyper-V for Windows Essential Server Solutions
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_SERVER_FOUNDATION"/>
        /// </para>
        /// <para>
        /// 0x00000021
        /// </para>
        /// </term>
        /// <term>
        /// Server Foundation
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_SERVERRDSH"/>
        /// </para>
        /// <para>
        /// 0x000000AF
        /// </para>
        /// </term>
        /// <term>
        /// Windows 10 Enterprise for Virtual Desktops
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_SMALLBUSINESS_SERVER"/>
        /// </para>
        /// <para>
        /// 0x00000009
        /// </para>
        /// </term>
        /// <term>
        /// Windows Small Business Server
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_SMALLBUSINESS_SERVER_PREMIUM"/>
        /// </para>
        /// <para>
        /// 0x00000019
        /// </para>
        /// </term>
        /// <term>
        /// Small Business Server Premium
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_SMALLBUSINESS_SERVER_PREMIUM_CORE"/>
        /// </para>
        /// <para>
        /// 0x0000003F
        /// </para>
        /// </term>
        /// <term>
        /// Small Business Server Premium (core installation)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_SOLUTION_EMBEDDEDSERVER"/>
        /// </para>
        /// <para>
        /// 0x00000038
        /// </para>
        /// </term>
        /// <term>
        /// Windows MultiPoint Server
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_STANDARD_EVALUATION_SERVER"/>
        /// </para>
        /// <para>
        /// 0x0000004F
        /// </para>
        /// </term>
        /// <term>
        /// Server Standard (evaluation installation)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_STANDARD_SERVER"/>
        /// </para>
        /// <para>
        /// 0x00000007
        /// </para>
        /// </term>
        /// <term>
        /// Server Standard
        /// (full installation.
        /// For Server Core installations of Windows Server 2012 and later, use the method, Determining whether Server Core is running.)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_STANDARD_SERVER_CORE"/>
        /// </para>
        /// <para>
        /// 0x0000000D
        /// </para>
        /// </term>
        /// <term>
        /// Server Standard (core installation, Windows Server 2008 R2 and earlier)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_STANDARD_SERVER_CORE_V"/>
        /// </para>
        /// <para>
        /// 0x00000028
        /// </para>
        /// </term>
        /// <term>
        /// Server Standard without Hyper-V (core installation)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_STANDARD_SERVER_V"/>
        /// </para>
        /// <para>
        /// 0x00000024
        /// </para>
        /// </term>
        /// <term>
        /// Server Standard without Hyper-V
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_STANDARD_SERVER_SOLUTIONS"/>
        /// </para>
        /// <para>
        /// 0x00000034
        /// </para>
        /// </term>
        /// <term>
        /// Server Solutions Premium
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_STANDARD_SERVER_SOLUTIONS_CORE"/>
        /// </para>
        /// <para>
        /// 0x00000035
        /// </para>
        /// </term>
        /// <term>
        /// Server Solutions Premium (core installation)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_STARTER"/>
        /// </para>
        /// <para>
        /// 0x0000000B
        /// </para>
        /// </term>
        /// <term>
        /// Starter
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_STARTER_E"/>
        /// </para>
        /// <para>
        /// 0x00000042
        /// </para>
        /// </term>
        /// <term>
        /// Not supported
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_STARTER_N"/>
        /// </para>
        /// <para>
        /// 0x0000002F
        /// </para>
        /// </term>
        /// <term>
        /// Starter N
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_STORAGE_ENTERPRISE_SERVER"/>
        /// </para>
        /// <para>
        /// 0x00000017
        /// </para>
        /// </term>
        /// <term>
        /// Storage Server Enterprise
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_STORAGE_ENTERPRISE_SERVER_CORE"/>
        /// </para>
        /// <para>
        /// 0x0000002E
        /// </para>
        /// </term>
        /// <term>
        /// Storage Server Enterprise (core installation)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_STORAGE_EXPRESS_SERVER"/>
        /// </para>
        /// <para>
        /// 0x00000014
        /// </para>
        /// </term>
        /// <term>
        /// Storage Server Express
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_STORAGE_EXPRESS_SERVER_CORE"/>
        /// </para>
        /// <para>
        /// 0x0000002B
        /// </para>
        /// </term>
        /// <term>
        /// Storage Server Express (core installation)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_STORAGE_STANDARD_EVALUATION_SERVER"/>
        /// </para>
        /// <para>
        /// 0x00000060
        /// </para>
        /// </term>
        /// <term>
        /// Storage Server Standard (evaluation installation)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_STORAGE_STANDARD_SERVER"/>
        /// </para>
        /// <para>
        /// 0x00000015
        /// </para>
        /// </term>
        /// <term>
        /// Storage Server Standard
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_STORAGE_STANDARD_SERVER_CORE"/>
        /// </para>
        /// <para>
        /// 0x0000002C
        /// </para>
        /// </term>
        /// <term>
        /// Storage Server Standard (core installation)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_STORAGE_WORKGROUP_EVALUATION_SERVER"/>
        /// </para>
        /// <para>
        /// 0x0000005F
        /// </para>
        /// </term>
        /// <term>
        /// Storage Server Workgroup (evaluation installation)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_STORAGE_WORKGROUP_SERVER"/>
        /// </para>
        /// <para>
        /// 0x00000016
        /// </para>
        /// </term>
        /// <term>
        /// Storage Server Workgroup
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_STORAGE_WORKGROUP_SERVER_CORE"/>
        /// </para>
        /// <para>
        /// 0x0000002D
        /// </para>
        /// </term>
        /// <term>
        /// Storage Server Workgroup (core installation)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_ULTIMATE"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// Ultimate
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_ULTIMATE_E"/>
        /// </para>
        /// <para>
        /// 0x00000047
        /// </para>
        /// </term>
        /// <term>
        /// Not supported
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_ULTIMATE_N"/>
        /// </para>
        /// <para>
        /// 0x0000001C
        /// </para>
        /// </term>
        /// <term>
        /// Ultimate N
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_UNDEFINED"/>
        /// </para>
        /// <para>
        /// 0x00000000
        /// </para>
        /// </term>
        /// <term>
        /// An unknown product
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_WEB_SERVER"/>
        /// </para>
        /// <para>
        /// 0x00000011
        /// </para>
        /// </term>
        /// <term>
        /// Web Server (full installation)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PRODUCT_WEB_SERVER_CORE"/>
        /// </para>
        /// <para>
        /// 0x0000001D
        /// </para>
        /// </term>
        /// <term>
        /// Web Server (core installation)
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a nonzero value.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// This function fails if one of the input parameters is invalid.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To detect whether a server role or feature is installed, use the Server Feature WMI provider.
        /// </para>
        /// <para>
        /// Subsequent releases of Windows will map the product types it supports to the set of product types
        /// supported by each supported previous release of Windows, back to version 6.0.0.0.
        /// Therefore, an application that does an equality test for any of these values
        /// will continue to work on future releases, even when new product types are added.
        /// </para>
        /// <para>
        /// <c>PRODUCT_*_SERVER_CORE</c> values are not returned in Windows Server 2012, and later.
        /// For example, the base server edition, Server Datacenter,
        /// is used to build the two different installation options: "full server" and "core server".
        /// With Windows Server 2012, <see cref="GetProductInfo"/> will return <c>PRODUCT_DATACENTER</c>
        /// regardless of the option used during product installation.
        /// As noted above, for Server Core installations of Windows Server 2012 and later,
        /// use the method Determining whether Server Core is running.
        /// </para>
        /// <para>
        /// The following table indicates the product types that were introduced in 6.1.0.0,
        /// and what they will map to if <see cref="GetProductInfo"/> is called with version 6.0.0.0 on a 6.1.0.0 system.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// New for 6.1.0.0
        /// </term>
        /// <term>
        /// Value returned with 6.0.0.0
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="PRODUCT_PROFESSIONAL"/>
        /// </term>
        /// <term>
        /// <see cref="PRODUCT_BUSINESS"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PRODUCT_PROFESSIONAL_N"/>
        /// </term>
        /// <term>
        /// <see cref="PRODUCT_BUSINESS_N"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PRODUCT_STARTER_N"/>
        /// </term>
        /// <term>
        /// <see cref="PRODUCT_STARTER"/>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetProductInfo", ExactSpelling = true)]
        public static extern BOOL GetProductInfo([In] DWORD dwOSMajorVersion, [In] DWORD dwOSMinorVersion, [In] DWORD dwSpMajorVersion,
            [In] DWORD dwSpMinorVersion, [In][Out] ref ProductTypes pdwReturnedProductType);

        /// <summary>
        /// <para>
        /// Retrieves the path of the system directory.
        /// The system directory contains system files such as dynamic-link libraries and drivers.
        /// </para>
        /// <para>
        /// This function is provided primarily for compatibility.
        /// Applications should store code in the Program Files folder and persistent data in the Application Data folder in the user's profile.
        /// For more information, see <see cref="SHGetFolderPath"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/sysinfoapi/nf-sysinfoapi-getsystemdirectoryw"/>
        /// </para>
        /// </summary>
        /// <param name="lpBuffer">
        /// A pointer to the buffer to receive the path.
        /// This path does not end with a backslash unless the system directory is the root directory.
        /// For example, if the system directory is named Windows\System32 on drive C,
        /// the path of the system directory retrieved by this function is C:\Windows\System32.
        /// </param>
        /// <param name="uSize">
        /// The maximum size of the buffer, in <c>TCHAR</c>s.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the length, in <c>TCHAR</c>s,
        /// of the string copied to the buffer, not including the terminating null character.
        /// If the length is greater than the size of the buffer, the return value is the size of the buffer
        /// required to hold the path, including the terminating null character.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// Applications should not create files in the system directory.
        /// If the user is running a shared version of the operating system,
        /// the application does not have write access to the system directory.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSystemDirectoryW", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetSystemDirectory([In] IntPtr lpBuffer, [In] UINT uSize);

        /// <summary>
        /// <para>
        /// Retrieves the specified firmware table from the firmware table provider.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/sysinfoapi/nf-sysinfoapi-getsystemfirmwaretable"/>
        /// </para>
        /// </summary>
        /// <param name="FirmwareTableProviderSignature">
        /// <para>
        /// The identifier of the firmware table provider to which the query is to be directed.
        /// This parameter can be one of the following values.
        /// </para>
        /// <para>
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
        /// 'ACPI'
        /// </term>
        /// <term>
        /// The ACPI firmware table provider.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 'FIRM'
        /// </term>
        /// <term>
        /// The raw firmware table provider.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 'RSMB'
        /// </term>
        /// <term>
        /// The raw SMBIOS firmware table provider.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="FirmwareTableID">
        /// <para>
        /// The identifier of the firmware table. This identifier is little endian, you must reverse the characters in the string.
        /// </para>
        /// <para>
        /// For example, FACP is an ACPI provider, as described in the <c>Signature</c> field of the <c>DESCRIPTION_HEADER</c> structure
        /// in the ACPI specification (see the Advanced Configuration and Power Interface (ACPI) Specification.
        /// Therefore, use 'PCAF' to specify the FACP table, as shown in the following example:
        /// </para>
        /// <code>
        /// retVal = GetSystemFirmwareTable('ACPI', 'PCAF', pBuffer, BUFSIZE);
        /// </code>
        /// <para>
        /// For more information, see the Remarks section of the <see cref="EnumSystemFirmwareTables"/> function.
        /// </para>
        /// </param>
        /// <param name="pFirmwareTableBuffer">
        /// <para>
        /// A pointer to a buffer that receives the requested firmware table.
        /// If this parameter is <see cref="NULL"/>, the return value is the required buffer size.
        /// </para>
        /// <para>
        /// For more information on the contents of this buffer, see the Remarks section.
        /// </para>
        /// </param>
        /// <param name="BufferSize">
        /// The size of the <paramref name="pFirmwareTableBuffer"/> buffer, in bytes.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the number of bytes written to the buffer.
        /// This value will always be less than or equal to <paramref name="BufferSize"/>.
        /// </para>
        /// <para>
        /// If the function fails because the buffer is not large enough, the return value is the required buffer size, in bytes.
        /// This value is always greater than <paramref name="BufferSize"/>.
        /// </para>
        /// <para>
        /// If the function fails for any other reason, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Starting with Windows 10, version 1803, Universal Windows apps can access the System Management BIOS (SMBIOS) information
        /// by declaring the <c>smbios </c> restricted capability in the app manifest.
        /// See Access SMBIOS information from a Universal Windows App for details.
        /// Only raw SMBIOS (RSMB) firmware tables can be accessed from a Universal Windows app.
        /// </para>
        /// <para>
        /// As of Windows Server 2003 with Service Pack 1 (SP1), applications cannot access the \Device\PhysicalMemory object.
        /// Access to this object is limited to kernel-mode drivers.
        /// This change affects applications read System Management BIOS (SMBIOS) or other BIOS data stored in the lowest 1MB of physical memory.
        /// Applications have the following alternatives to read data from low physical memory:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Retrieve the SMBIOS properties using WMI.
        /// Many individual properties are contained in the Win32 classes.
        /// You can also retrieve the raw SMBIOS data in a single buffer using the <see cref="MSSMBios_RawSMBiosTables"/> class.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Use the <see cref="GetSystemFirmwareTable"/> function to read the raw SMBIOS firmware table.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// There is no way for applications to write to low physical memory.
        /// </para>
        /// <para>
        /// The raw SMBIOS table provider ('RSMB') retrieves the contents of the raw SMBIOS firmware table.
        /// The <paramref name="pFirmwareTableBuffer"/> buffer receives the following data:
        /// </para>
        /// <code>
        /// #include &lt;windows.h&gt;
        /// 
        /// struct RawSMBIOSData
        /// {
        ///    BYTE Used20CallingMethod;
        ///    BYTE SMBIOSMajorVersion;
        ///    BYTE SMBIOSMinorVersion;
        ///    BYTE DmiRevision;
        ///    DWORD Length;
        ///    BYTE SMBIOSTableData[];
        /// };
        /// </code>
        /// <para>
        /// The raw firmware table provider ('FIRM') retrieves the contents of the specified physical address range.
        /// The function returns the size of the address range.
        /// </para>
        /// <para>
        /// The ACPI table provider ('ACPI') retrieves the contents of the specified ACPI table.
        /// Because OEMs can include ACPI firmware tables that are not listed in the ACPI specification,
        /// you should first call <see cref="EnumSystemFirmwareTables"/> to enumerate all ACPI tables that are currently on the system.
        /// </para>
        /// <para>
        /// For ACPI, if the system contains multiple tables with the same name,
        /// they are all enumerated with <see cref="EnumSystemFirmwareTables"/>.
        /// However, <see cref="GetSystemFirmwareTable"/> retrieves only the first table in the list with this name.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSystemFirmwareTable", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetSystemFirmwareTable([In] DWORD FirmwareTableProviderSignature, [In] DWORD FirmwareTableID,
                [In] PVOID pFirmwareTableBuffer, [In] DWORD BufferSize);

        /// <summary>
        /// <para>
        /// Retrieves information about the current system.
        /// </para>
        /// <para>
        /// To retrieve accurate information for an application running on WOW64, call the <see cref="GetNativeSystemInfo"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/sysinfoapi/nf-sysinfoapi-getsysteminfo"/>
        /// </para>
        /// </summary>
        /// <param name="lpSystemInfo">
        /// A pointer to a <see cref="SYSTEM_INFO"/> structure that receives the information.
        /// </param>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSystemInfo", ExactSpelling = true)]
        public static extern void GetSystemInfo([Out] out SYSTEM_INFO lpSystemInfo);

        /// <summary>
        /// <para>
        /// Retrieves the current system date and time. The system time is expressed in Coordinated Universal Time (UTC).
        /// </para>
        /// <para>
        /// To retrieve the current system date and time in local time, use the <see cref="GetLocalTime"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/sysinfoapi/nf-sysinfoapi-getsystemtime"/>
        /// </para>
        /// </summary>
        /// <param name="lpSystemTime">
        /// A pointer to a <see cref="SYSTEMTIME"/> structure to receive the current system date and time. 
        /// The <paramref name="lpSystemTime"/> parameter must not be <see cref="NullRef{SYSTEMTIME}"/>.
        /// Using <see cref="NullRef{SYSTEMTIME}"/> will result in an access violation.
        /// </param>
        /// <remarks>
        /// To set the current system date and time, use the <see cref="SetSystemTime"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSystemTime", ExactSpelling = true)]
        public static extern void GetSystemTime([Out] out SYSTEMTIME lpSystemTime);

        /// <summary>
        /// <para>
        /// Determines whether the system is applying periodic time adjustments to its time-of-day clock,
        /// and obtains the value and period of any such adjustments.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/sysinfoapi/nf-sysinfoapi-getsystemtimeadjustment"/>
        /// </para>
        /// </summary>
        /// <param name="lpTimeAdjustment">
        /// A pointer to a variable that the function sets to the number of <paramref name="lpTimeIncrement"/> 100-nanosecond units
        /// added to the time-of-day clock for every period of time which actually passes as counted by the system.
        /// This value only has meaning if <paramref name="lpTimeAdjustmentDisabled"/> is <see cref="FALSE"/>.
        /// </param>
        /// <param name="lpTimeIncrement">
        /// A pointer to a variable that the function sets to the interval in 100-nanosecond units
        /// at which the system will add <paramref name="lpTimeAdjustment"/> to the time-of-day clock.
        /// This value only has meaning if <paramref name="lpTimeAdjustmentDisabled"/> is <see cref="FALSE"/>.
        /// </param>
        /// <param name="lpTimeAdjustmentDisabled">
        /// <para>
        /// A pointer to a variable that the function sets to indicate whether periodic time adjustment is in effect.
        /// </para>
        /// <para>
        /// A value of <see cref="TRUE"/> indicates that periodic time adjustment is disabled,
        /// and the system time-of-day clock advances at the normal rate.
        /// In this mode, the system may adjust the time of day using its own internal time synchronization mechanisms.
        /// These internal time synchronization mechanisms may cause the time-of-day clock to change
        /// during the normal course of the system operation, which can include noticeable jumps in time as deemed necessary by the system.
        /// </para>
        /// <para>
        /// A value of <see cref="FALSE"/> indicates that periodic time adjustment is being used to adjust the time-of-day clock.
        /// For each <paramref name="lpTimeIncrement"/> period of time that actually passes,
        /// <paramref name="lpTimeAdjustment"/> will be added to the time of day.
        /// If the <paramref name="lpTimeAdjustment"/> value is smaller than <paramref name="lpTimeIncrement"/>,
        /// the system time-of-day clock will advance at a rate slower than normal.
        /// If the <paramref name="lpTimeAdjustment"/> value is larger than <paramref name="lpTimeIncrement"/>,
        /// the time-of-day clock will advance at a rate faster than normal.
        /// If <paramref name="lpTimeAdjustment"/> equals <paramref name="lpTimeIncrement"/>,
        /// the time-of-day clock will advance at its normal speed.
        /// The <paramref name="lpTimeAdjustment"/> value can be set by calling <see cref="SetSystemTimeAdjustment"/>.
        /// The <paramref name="lpTimeIncrement"/> value is fixed by the system upon start, and does not change during system operation.
        /// In this mode, the system will not interfere with the time adjustment scheme,
        /// and will not attempt to synchronize time of day on its own via other techniques.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="GetSystemTimeAdjustment"/> and <see cref="SetSystemTimeAdjustment"/> functions
        /// can be used to support algorithms that want to synchronize the time-of-day clock,
        /// reported by <see cref="GetSystemTime"/> and <see cref="GetLocalTime"/>,
        /// with another time source by using a periodic time adjustment.
        /// </para>
        /// <para>
        /// The <see cref="GetSystemTimeAdjustment"/> function lets a caller determine whether periodic time adjustment is enabled,
        /// and if it is, obtain the amount of each adjustment and the time between adjustments.
        /// The <see cref="SetSystemTimeAdjustment"/> function lets a caller enable or disable periodic time adjustment,
        /// and set the value of the adjusting increment.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSystemTimeAdjustment", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetSystemTimeAdjustment([Out] out DWORD lpTimeAdjustment, [Out] out DWORD lpTimeIncrement,
            [Out] out BOOL lpTimeAdjustmentDisabled);

        /// <summary>
        /// <para>
        /// Retrieves the current system date and time. The information is in Coordinated Universal Time (UTC) format.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/sysinfoapi/nf-sysinfoapi-getsystemtimeasfiletime"/>
        /// </para>
        /// </summary>
        /// <param name="lpSystemTimeAsFileTime">
        /// A pointer to a <see cref="FILETIME"/> structure to receive the current system date and time in UTC format.
        /// </param>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSystemTimeAsFileTime", ExactSpelling = true)]
        public static extern void GetSystemTimeAsFileTime([Out] out FILETIME lpSystemTimeAsFileTime);

        /// <summary>
        /// <para>
        /// Retrieves the path of the shared Windows directory on a multi-user system.
        /// </para>
        /// <para>
        /// This function is provided primarily for compatibility.
        /// Applications should store code in the Program Files folder and persistent data in the Application Data folder in the user's profile.
        /// For more information, see <see cref="SHGetFolderPath"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/sysinfoapi/nf-sysinfoapi-getsystemwindowsdirectoryw"/>
        /// </para>
        /// </summary>
        /// <param name="lpBuffer">
        /// A pointer to a buffer that receives the path.
        /// This path does not end with a backslash unless the Windows directory is the root directory.
        /// For example, if the Windows directory is named Windows on drive C, the path of the Windows directory retrieved by this function is C:\Windows.
        /// If the system was installed in the root directory of drive C, the path retrieved is C:.
        /// </param>
        /// <param name="uSize">
        /// The maximum size of the buffer specified by the lpBuffer parameter, in <c>TCHAR</c>s.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the length of the string copied to the buffer,
        /// in <c>TCHAR</c>s, not including the terminating null character.
        /// </para>
        /// <para>
        /// If the length is greater than the size of the buffer,
        /// the return value is the size of the buffer required to hold the path.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// On a system that is running Terminal Services, each user has a unique Windows directory.
        /// The system Windows directory is shared by all users,
        /// so it is the directory where an application should store initialization and help files that apply to all users.
        /// </para>
        /// <para>
        /// With Terminal Services, the <see cref="GetSystemWindowsDirectory"/> function retrieves the path of the system Windows directory,
        /// while the <see cref="GetWindowsDirectory"/> function retrieves the path of a Windows directory that is private for each user.
        /// On a single-user system, <see cref="GetSystemWindowsDirectory"/> is the same as <see cref="GetWindowsDirectory"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSystemWindowsDirectoryW", ExactSpelling = true, SetLastError = true)]
        public static extern uint GetSystemWindowsDirectory([In] IntPtr lpBuffer, [In] uint uSize);

        /// <summary>
        /// <para>
        /// Retrieves the number of milliseconds that have elapsed since the system was started, up to 49.7 days.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/sysinfoapi/nf-sysinfoapi-gettickcount"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// The return value is the number of milliseconds that have elapsed since the system was started.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The resolution of the <see cref="GetTickCount"/> function is limited to the resolution of the system timer,
        /// which is typically in the range of 10 milliseconds to 16 milliseconds.
        /// The resolution of the <see cref="GetTickCount"/> function is not affected
        /// by adjustments made by the <see cref="GetSystemTimeAdjustment"/> function.
        /// </para>
        /// <para>
        /// The elapsed time is stored as a <see cref="DWORD"/> value.
        /// Therefore, the time will wrap around to zero if the system is run continuously for 49.7 days.
        /// To avoid this problem, use the <see cref="GetTickCount64"/> function.
        /// Otherwise, check for an overflow condition when comparing times.
        /// </para>
        /// <para>
        /// If you need a higher resolution timer, use a multimedia timer or a high-resolution timer.
        /// </para>
        /// <para>
        /// To obtain the time elapsed since the computer was started,
        /// retrieve the System Up Time counter in the performance data in the registry key <see cref="HKEY_PERFORMANCE_DATA"/>.
        /// The value returned is an 8-byte value.
        /// For more information, see Performance Counters.
        /// </para>
        /// <para>
        /// To obtain the time the system has spent in the working state since it was started,
        /// use the <see cref="QueryUnbiasedInterruptTime"/> function.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// The <see cref="QueryUnbiasedInterruptTime"/> function produces different results on debug ("checked") builds of Windows,
        /// because the interrupt-time count and tick count are advanced by approximately 49 days.
        /// This helps to identify bugs that might not occur until the system has been running for a long time.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTickCount", ExactSpelling = true)]
        public static extern DWORD GetTickCount();

        /// <summary>
        /// <para>
        /// Retrieves the number of milliseconds that have elapsed since the system was started.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/sysinfoapi/nf-sysinfoapi-gettickcount64"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// The number of milliseconds.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The resolution of the <see cref="GetTickCount64"/> function is limited to the resolution of the system timer,
        /// which is typically in the range of 10 milliseconds to 16 milliseconds.
        /// The resolution of the <see cref="GetTickCount64"/> function is not affected
        /// by adjustments made by the <see cref="GetSystemTimeAdjustment"/> function.
        /// </para>
        /// <para>
        /// If you need a higher resolution timer, use a multimedia timer or a high-resolution timer.
        /// </para>
        /// <para>
        /// To obtain the time the system has spent in the working state since it was started,
        /// use the <see cref="QueryUnbiasedInterruptTime"/> function.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// The <see cref="QueryUnbiasedInterruptTime"/> function produces different results on debug ("checked") builds of Windows,
        /// because the interrupt-time count and tick count are advanced by approximately 49 days.
        /// This helps to identify bugs that might not occur until the system has been running for a long time.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTickCount64", ExactSpelling = true)]
        public static extern ULONGLONG GetTickCount64();

        /// <summary>
        /// <para>
        /// <see cref="GetVersion"/> may be altered or unavailable for releases after Windows 8.1.
        /// Instead, use the Version Helper functions.
        /// For Windows 10 apps, please see Targeting your applications for Windows.
        /// </para>
        /// <para>
        /// With the release of Windows 8.1,
        /// the behavior of the <see cref="GetVersion"/> API has changed in the value it will return for the operating system version.
        /// The value returned by the <see cref="GetVersion"/> function now depends on how the application is manifested.
        /// </para>
        /// <para>
        /// Applications not manifested for Windows 8.1 or Windows 10 will return the Windows 8 OS version value (6.2).
        /// Once an application is manifested for a given operating system version,
        /// <see cref="GetVersion"/> will always return the version that the application is manifested for in future releases.
        /// To manifest your applications for Windows 8.1 or Windows 10, refer to Targeting your application for Windows.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/sysinfoapi/nf-sysinfoapi-getversion"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value includes the major and minor version numbers of the operating system in the low-order word,
        /// and information about the operating system platform in the high-order word.
        /// </para>
        /// <para>
        /// For all platforms, the low-order word contains the version number of the operating system.
        /// The low-order byte of this word specifies the major version number, in hexadecimal notation.
        /// The high-order byte specifies the minor version (revision) number, in hexadecimal notation.
        /// The high-order bit is zero, the next 7 bits represent the build number, and the low-order byte is 5.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="GetVersionEx"/> function was developed because many existing applications err when examining
        /// the packed DWORD value returned by <see cref="GetVersion"/>, transposing the major and minor version numbers.
        /// <see cref="GetVersionEx"/> forces applications to explicitly examine each element of version information.
        /// <see cref="VerifyVersionInfo"/> eliminates further potential for error
        /// by comparing the required system version with the current system version for you.
        /// </remarks>
        [Obsolete("GetVersion may be altered or unavailable for releases after Windows 8.1. Instead, use the Version Helper functions")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetVersion", ExactSpelling = true)]
        public static extern DWORD GetVersion();

        /// <summary>
        /// <para>
        /// With the release of Windows 8.1, the behavior of the <see cref="GetVersionEx"/> API has changed in the value
        /// it will return for the operating system version.
        /// The value returned by the <see cref="GetVersionEx"/> function now depends on how the application is manifested.
        /// </para>
        /// <para>
        /// Applications not manifested for Windows 8.1 or Windows 10 will return the Windows 8 OS version value (6.2).
        /// Once an application is manifested for a given operating system version,
        /// <see cref="GetVersionEx"/> will always return the version that the application is manifested for in future releases.
        /// To manifest your applications for Windows 8.1 or Windows 10, refer to Targeting your application for Windows.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/sysinfoapi/nf-sysinfoapi-getversionexw"/>
        /// </para>
        /// </summary>
        /// <param name="lpVersionInformation">
        /// <para>
        /// An <see cref="OSVERSIONINFO"/> or <see cref="OSVERSIONINFOEX"/> structure that receives the operating system information.
        /// </para>
        /// <para>
        /// Before calling the <see cref="GetVersionEx"/> function, set the <c>dwOSVersionInfoSize</c> member of the structure
        /// as appropriate to indicate which data structure is being passed to this function.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a nonzero value.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// The function fails if you specify an invalid value for the <c>dwOSVersionInfoSize</c> member
        /// of the <see cref="OSVERSIONINFO"/> or <see cref="OSVERSIONINFOEX"/> structure.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Identifying the current operating system is usually not the best way
        /// to determine whether a particular operating system feature is present.
        /// This is because the operating system may have had new features added in a redistributable DLL.
        /// Rather than using <see cref="GetVersionEx"/> to determine the operating system platform or version number,
        /// test for the presence of the feature itself.
        /// For more information, see Operating System Version.
        /// </para>
        /// <para>
        /// The <see cref="GetSystemMetrics"/> function provides additional information about the current operating system.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Product
        /// </term>
        /// <term>
        /// Setting
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Windows XP Media Center Edition
        /// </term>
        /// <term>
        /// <see cref="SM_MEDIACENTER"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Windows XP Starter Edition
        /// </term>
        /// <term>
        /// <see cref="SM_STARTER"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Windows XP Tablet PC Edition
        /// </term>
        /// <term>
        /// <see cref="SM_TABLETPC"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Windows Server 2003 R2
        /// </term>
        /// <term>
        /// <see cref="SM_SERVERR2"/>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// To check for specific operating systems or operating system features, use the <see cref="IsOS"/> function.
        /// The <see cref="GetProductInfo"/> function retrieves the product type.
        /// </para>
        /// <para>
        /// To retrieve information for the operating system on a remote computer,
        /// use the <see cref="NetWkstaGetInfo"/> function, the <c>Win32_OperatingSystem</c> WMI class,
        /// or the <c>OperatingSystem</c> property of the <see cref="IADsComputer"/> interface.
        /// </para>
        /// <para>
        /// To compare the current system version to a required version,
        /// use the <see cref="VerifyVersionInfo"/> function instead of using <see cref="GetVersionEx"/> to perform the comparison yourself.
        /// </para>
        /// <para>
        /// If compatibility mode is in effect, the <see cref="GetVersionEx"/> function reports the operating system as it identifies itself,
        /// which may not be the operating system that is installed.
        /// For example, if compatibility mode is in effect,
        /// <see cref="GetVersionEx"/> reports the operating system that is selected for application compatibility.
        /// </para>
        /// </remarks>
        [Obsolete("GetVersionEx may be altered or unavailable for releases after Windows 8.1. Instead, use the Version Helper functions")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetVersionExW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetVersionEx([In] in OSVERSIONINFO lpVersionInformation);

        /// <summary>
        /// <para>
        /// Retrieves the path of the Windows directory.
        /// </para>
        /// <para>
        /// This function is provided primarily for compatibility with legacy applications.
        /// New applications should store code in the Program Files folder and persistent data in the Application Data folder in the user's profile.
        /// For more information, see <see cref="SHGetFolderPath"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/sysinfoapi/nf-sysinfoapi-getwindowsdirectoryw"/>
        /// </para>
        /// </summary>
        /// <param name="lpBuffer">
        /// A pointer to a buffer that receives the path.
        /// This path does not end with a backslash unless the Windows directory is the root directory.
        /// For example, if the Windows directory is named Windows on drive C, the path of the Windows directory retrieved by this function is C:\Windows.
        /// If the system was installed in the root directory of drive C, the path retrieved is C:.
        /// </param>
        /// <param name="uSize">
        /// The maximum size of the buffer specified by the lpBuffer parameter, in <c>TCHAR</c>s.
        /// This value should be set to <see cref="MAX_PATH"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the length of the string copied to the buffer,
        /// in <c>TCHAR</c>s, not including the terminating null character.
        /// </para>
        /// <para>
        /// If the length is greater than the size of the buffer,
        /// the return value is the size of the buffer required to hold the path.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The Windows directory is the directory where some legacy applications store initialization and help files.
        /// New applications should not store files in the Windows directory;
        /// instead, they should store system-wide data in the application's installation directory, and user-specific data in the user's profile.
        /// </para>
        /// <para>
        /// If the user is running a shared version of the system, the Windows directory is guaranteed to be private for each user.
        /// </para>
        /// <para>
        /// If an application creates other files that it wants to store on a per-user basis,
        /// it should place them in the directory specified by the HOMEPATH environment variable.
        /// This directory will be different for each user, if so specified by an administrator, through the User Manager administrative tool.
        /// HOMEPATH always specifies either the user's home directory, which is guaranteed to be private for each user,
        /// or a default directory (for example, C:\USERS\DEFAULT) where the user will have all access.
        /// </para>
        /// <para>
        /// Terminal Services:
        /// If the application is running in a Terminal Services environment, each user has a private Windows directory.
        /// There is also a shared Windows directory for the system.
        /// If the application is Terminal-Services-aware
        /// (has the <see cref="IMAGE_DLLCHARACTERISTICS_TERMINAL_SERVER_AWARE"/> flag set in the image header),
        /// this function returns the path of the system Windows directory, just as the <see cref="GetSystemWindowsDirectory"/> function does.
        /// Otherwise, it retrieves the path of the private Windows directory for the user.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowsDirectoryW", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetWindowsDirectory([In] IntPtr lpBuffer, [In] UINT uSize);

        /// <summary>
        /// <para>
        /// Determines whether the specified processor feature is supported by the current computer.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-isprocessorfeaturepresent"/>
        /// </para>
        /// </summary>
        /// <param name="ProcessorFeature">
        /// <para>
        /// The processor feature to be tested. This parameter can be one of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="PF_ARM_64BIT_LOADSTORE_ATOMIC"/>
        /// </para>
        /// <para>
        /// 25
        /// </para>
        /// </term>
        /// <term>
        /// The 64-bit load/store atomic instructions are available.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_DIVIDE_INSTRUCTION_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 24
        /// </para>
        /// </term>
        /// <term>
        /// The divide instructions are available.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_EXTERNAL_CACHE_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 26
        /// </para>
        /// </term>
        /// <term>
        /// The external cache is available.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_FMAC_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 27
        /// </para>
        /// </term>
        /// <term>
        /// The floating-point multiply-accumulate instruction is available.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_VFP_32_REGISTERS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 18
        /// </para>
        /// </term>
        /// <term>
        /// The VFP/Neon: 32 x 64bit register bank is present.
        /// This flag has the same meaning as <see cref="PF_ARM_VFP_EXTENDED_REGISTERS"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_3DNOW_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 7
        /// </para>
        /// </term>
        /// <term>
        /// The 3D-Now instruction set is available.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_CHANNELS_ENABLED"/>
        /// </para>
        /// <para>
        /// 16
        /// </para>
        /// </term>
        /// <term>
        /// The processor channels are enabled.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_COMPARE_EXCHANGE_DOUBLE"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// The atomic compare and exchange operation (cmpxchg) is available.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_COMPARE_EXCHANGE128"/>
        /// </para>
        /// <para>
        /// 14
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The atomic compare and exchange 128-bit operation (cmpxchg16b) is available.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP/2000: This feature is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_COMPARE64_EXCHANGE128"/>
        /// </para>
        /// <para>
        /// 15
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The atomic compare 64 and exchange 128-bit operation (cmp8xchg16) is available.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP/2000: This feature is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_FASTFAIL_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 23
        /// </para>
        /// </term>
        /// <term>
        /// _fastfail() is available.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_FLOATING_POINT_EMULATED"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Floating-point operations are emulated using a software emulator.
        /// </para>
        /// <para>
        /// This function returns a nonzero value if floating-point operations are emulated; otherwise, it returns zero.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_FLOATING_POINT_PRECISION_ERRATA"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// On a Pentium, a floating-point precision error can occur in rare circumstances.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_MMX_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 3
        /// </para>
        /// </term>
        /// <term>
        /// The MMX instruction set is available.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_NX_ENABLED"/>
        /// </para>
        /// <para>
        /// 12
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Data execution prevention is enabled.
        /// </para>
        /// <para>
        /// Windows XP/2000: This feature is not supported until Windows XP with SP2 and Windows Server 2003 with SP1.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_PAE_ENABLED"/>
        /// </para>
        /// <para>
        /// 9
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The processor is PAE-enabled. For more information, see Physical Address Extension.
        /// </para>
        /// <para>
        /// All x64 processors always return a nonzero value for this feature.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_RDTSC_INSTRUCTION_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 8
        /// </para>
        /// </term>
        /// <term>
        /// The RDTSC instruction is available.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_RDWRFSGSBASE_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 22
        /// </para>
        /// </term>
        /// <term>
        /// RDFSBASE, RDGSBASE, WRFSBASE, and WRGSBASE instructions are available.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_SECOND_LEVEL_ADDRESS_TRANSLATION"/>
        /// </para>
        /// <para>
        /// 20
        /// </para>
        /// </term>
        /// <term>
        /// Second Level Address Translation is supported by the hardware.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_SSE3_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 13
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The SSE3 instruction set is available.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP/2000:  This feature is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_SSSE3_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 36
        /// </para>
        /// </term>
        /// <term>
        /// The SSSE3 instruction set is available.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_SSE4_1_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 37
        /// </para>
        /// </term>
        /// <term>
        /// The SSE4_1 instruction set is available.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_SSE4_2_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 38
        /// </para>
        /// </term>
        /// <term>
        /// The SSE4_2 instruction set is available.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_AVX_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 39
        /// </para>
        /// </term>
        /// <term>
        /// The AVX instruction set is available.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_AVX2_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 40
        /// </para>
        /// </term>
        /// <term>
        /// The AVX2 instruction set is available.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_AVX512F_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 41
        /// </para>
        /// </term>
        /// <term>
        /// The AVX512F instruction set is available.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_VIRT_FIRMWARE_ENABLED"/>
        /// </para>
        /// <para>
        /// 21
        /// </para>
        /// </term>
        /// <term>
        /// Virtualization is enabled in the firmware and made available by the operating system.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_XMMI_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 6
        /// </para>
        /// </term>
        /// <term>
        /// The SSE instruction set is available.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_XMMI64_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 10
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The SSE2 instruction set is available.
        /// </para>
        /// <para>
        /// Windows 2000: This feature is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_XSAVE_ENABLED"/>
        /// </para>
        /// <para>
        /// 17
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The processor implements the XSAVE and XRSTOR instructions.
        /// </para>
        /// <para>
        /// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP/2000:
        /// This feature is not supported until Windows 7 and Windows Server 2008 R2.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_V8_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 29
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the Arm v8 instructions set.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_V8_CRYPTO_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 30
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the Arm v8 extra cryptographic instructions (for example, AES, SHA1 and SHA2).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_V8_CRC32_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 31
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the Arm v8 extra CRC32 instructions.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_V81_ATOMIC_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 34
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the Arm v8.1 atomic instructions (for example, CAS, SWP).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_V82_DP_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 43
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the Arm v8.2 DP instructions (for example, SDOT, UDOT).
        /// This feature is optional in Arm v8.2 implementations and mandatory in Arm v8.4 implementations.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_V83_JSCVT_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 44
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the Arm v8.3 JSCVT instructions (for example, FJCVTZS).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_V83_LRCPC_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 45
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the Arm v8.3 LRCPC instructions (for example, LDAPR).
        /// Note that certain Arm v8.2 CPUs may optionally support the LRCPC instructions.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_SVE_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 46
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the SVE (Scalable Vector Extension) instructions (FEAT_SVE).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_SVE2_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 47
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the SVE2 instructions (FEAT_SVE2).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_SVE2_1_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 48
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the SVE2.1 instructions (FEAT_SVE2p1).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_SVE_AES_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 49
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the SVE AES instructions (FEAT_SVE_AES).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_SVE_PMULL128_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 50
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the SVE 128-bit polynomial multiply long instructions (FEAT_SVE_PMULL128).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_SVE_BITPERM_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 51
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the SVE bit permute instructions (FEAT_SVE_BitPerm).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_SVE_BF16_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 52
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the SVE BF16 (BFloat16) instructions (FEAT_BF16>).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_SVE_EBF16_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 53
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the SVE EBF16 (Extended BFloat16) instructions (FEAT_EBF16).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_SVE_B16B16_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 54
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the SVE B16B16 instructions (FEAT_SVE_B16B16).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_SVE_SHA3_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 55
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the SVE SHA-3 cryptographic instructions (FEAT_SVE_SHA3).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_SVE_SM4_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 56
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the SVE SM4 cryptographic instructions (FEAT_SVE_SM4).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_SVE_I8MM_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 57
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the SVE I8MM (Int8 matrix multiply) instructions (FEAT_I8MM).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_SVE_F32MM_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 58
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the SVE F32MM (FP32 matrix multiply) instructions (FEAT_F32MM).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_SVE_F64MM_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 59
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the SVE F64MM (FP64 matrix multiply) instructions (FEAT_F64MM).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_BMI2_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 60
        /// </para>
        /// </term>
        /// <term>
        /// This x64 processor implements the BMI2 instruction set.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_MOVDIR64B_INSTRUCTION_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 61
        /// </para>
        /// </term>
        /// <term>
        /// This x64 processor implements the MOVDIR64B instruction.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_LSE2_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 62
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the LSE2 atomic instructions (FEAT_LSE2).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_SHA3_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 64
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the SHA-3 cryptographic instructions (FEAT_SHA3).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_SHA512_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 65
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the SHA-512 cryptographic instructions (FEAT_SHA512).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_V82_I8MM_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 66
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the I8MM (Int8 matrix multiply) NEON instructions (FEAT_I8MM).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_V82_FP16_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 67
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the FP16 (half-precision floating point) NEON instructions (FEAT_FP16).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_V86_BF16_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 68
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the BF16 (BFloat16) NEON instructions (FEAT_BF16).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_V86_EBF16_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 69
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the EBF16 (Extended BFloat16) NEON instructions (FEAT_EBF16).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_SME_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 70
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the SME (Scalable Matrix Extension) instructions (FEAT_SME).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_SME2_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 71
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the SME2 instructions (FEAT_SME2).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_SME2_1_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 72
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the SME2.1 instructions (FEAT_SME2p1).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_SME2_2_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 73
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the SME2.2 instructions (FEAT_SME2p2).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_SME_AES_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 74
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the SVE AES instructions when in Streaming SVE mode (FEAT_SSVE_AES).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_SME_SBITPERM_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 75
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the SVE bit permute instructions when in Streaming SVE mode (FEAT_SSVE_BitPerm).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_SME_SF8MM4_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 76
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the SVE FMMLA (widening, 4-way, FP8 to FP16) instruction
        /// when in Streaming SVE mode (FEAT_SSVE_F8F16MM).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_SME_SF8MM8_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 77
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the SVE FMMLA (widening, 8-way, FP8 to FP32) instruction
        /// when in Streaming SVE mode (FEAT_SSVE_F8F32MM).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_SME_SF8DP2_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 78
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the SVE2 FP8DOT2 instructions when in Streaming SVE mode (FEAT_SSVE_FP8DOT2).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_SME_SF8DP4_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 79
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the SVE2 FP8DOT4 instructions when in Streaming SVE mode (FEAT_SSVE_FP8DOT4).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_SME_SF8FMA_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 80
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the SVE2 FP8FMA instructions when in Streaming SVE mode (FEAT_SSVE_FP8FMA).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_SME_F8F32_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 81
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the SME F8F32 instructions (FEAT_SME_F8F32).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_SME_F8F16_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 82
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the SME F8F16 instructions (FEAT_SME_F8F16).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_SME_F16F16_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 83
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the SME F16F16 instructions (FEAT_SME_F16F16).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_SME_B16B16_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 84
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the SME B16B16 instructions (FEAT_SME_B16B16).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_SME_F64F64_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 85
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the SME F64F64 instructions (FEAT_SME_F64F64).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_SME_I16I64_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 86
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the SME I16I64 instructions (FEAT_SME_I16I64).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_SME_LUTv2_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 87
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements the SME LUTv2 instructions (FEAT_SME_LUTv2).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_ARM_SME_FA64_INSTRUCTIONS_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 88
        /// </para>
        /// </term>
        /// <term>
        /// This Arm processor implements SME FA64 (Full AArch64 instruction set when in Streaming SVE mode) (FEAT_SME_FA64).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PF_UMONITOR_INSTRUCTION_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 89
        /// </para>
        /// </term>
        /// <term>
        /// This x64 processor implements the UMONITOR instruction.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the feature is supported, the return value is a nonzero value.
        /// </para>
        /// <para>
        /// If the feature is not supported, the return value is zero.
        /// </para>
        /// <para>
        /// If the HAL does not support detection of the feature,
        /// whether or not the hardware supports the feature, the return value is also zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Support for <see cref="PF_SSSE3_INSTRUCTIONS_AVAILABLE"/> through <see cref="PF_AVX512F_INSTRUCTIONS_AVAILABLE"/>
        /// were added in the Windows SDK (19041) and are supported by Windows 10, Version 2004 (May 2020 Update) or later.
        /// </para>
        /// <para>
        /// Support for <see cref="PF_ERMS_AVAILABLE"/>, <see cref="PF_ARM_V82_DP_INSTRUCTIONS_AVAILABLE"/>,
        /// and <see cref="PF_ARM_V83_JSCVT_INSTRUCTIONS_AVAILABLE"/> were added in the Windows SDK (20348)
        /// and are supported by Windows 11 and Windows Server 2022.
        /// </para>
        /// <para>
        /// The define <see cref="PF_ARM_V83_LRCPC_INSTRUCTIONS_AVAILABLE"/> was added in the Windows SDK (22621)
        /// and is supported by Windows 11, Version 22H2.
        /// </para>
        /// <para>
        /// Support for <see cref="PF_ARM_SVE_INSTRUCTIONS_AVAILABLE"/> through <see cref="PF_MOVDIR64B_INSTRUCTION_AVAILABLE"/>
        /// and <see cref="PF_ARM_SHA3_INSTRUCTIONS_AVAILABLE"/> through <see cref="PF_ARM_V86_EBF16_INSTRUCTIONS_AVAILABLE"/>
        /// were added in the Windows SDK (26100) and are supported by Windows 11, version 24H2 and Windows Server 2025 or later.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsProcessorFeaturePresent", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsProcessorFeaturePresent(ProcessFeatures ProcessorFeature);

        /// <summary>
        /// <para>
        /// Gets the current unbiased interrupt-time count, in units of 100 nanoseconds.
        /// The unbiased interrupt-time count does not include time the system spends in sleep or hibernation.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/realtimeapiset/nf-realtimeapiset-queryunbiasedinterrupttime"/>
        /// </para>
        /// </summary>
        /// <param name="UnbiasedTime"></param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails because it is called with a null parameter, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The interrupt-time count begins at zero when the system starts
        /// and is incremented at each clock interrupt by the length of a clock tick.
        /// The exact length of a clock tick depends on underlying hardware and can vary between systems.
        /// </para>
        /// <para>
        /// The interrupt-time count retrieved by the <see cref="QueryUnbiasedInterruptTime"/> function
        /// reflects only the time that the system is in the working state.
        /// Therefore, the interrupt-time count is not "biased" by time the system spends in sleep or hibernation.
        /// The system uses biased interrupt time for some operations,
        /// such as ensuring that relative timers that would have expired during sleep expire immediately upon waking.
        /// </para>
        /// <para>
        /// Unlike system time, the interrupt-time count is not subject to adjustments by users or the Windows time service.
        /// Applications can use the interrupt-time count to measure finer durations than are possible with system time.
        /// Applications that require greater precision than the interrupt-time count should use a high-resolution timer.
        /// Use the <see cref="QueryPerformanceFrequency"/> function to retrieve the frequency of the high-resolution timer
        /// and the <see cref="QueryPerformanceCounter"/> function to retrieve the counter's value.
        /// </para>
        /// <para>
        /// The timer resolution set by the <see cref="timeBeginPeriod"/> and <see cref="timeEndPeriod"/> functions
        /// affects the resolution of the <see cref="QueryUnbiasedInterruptTime"/> function.
        /// However, increasing the timer resolution is not recommended because it can reduce overall system performance
        /// and increase system power consumption by preventing the processor from entering power-saving states.
        /// Instead, applications should use a high-resolution timer.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// The <see cref="QueryUnbiasedInterruptTime"/> function produces different results on debug ("checked") builds of Windows,
        /// because the interrupt-time count and tick count are advanced by approximately 49 days.
        /// This helps to identify bugs that might not occur until the system has been running for a long time.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "QueryUnbiasedInterruptTime", ExactSpelling = true)]
        public static extern BOOL QueryUnbiasedInterruptTime([Out] out ULONGLONG UnbiasedTime);

        /// <summary>
        /// <para>
        /// Sets a new NetBIOS name for the local computer.
        /// The name is stored in the registry and the name change takes effect the next time the user restarts the computer.
        /// </para>
        /// <para>
        /// If the local computer is a node in a cluster,
        /// <see cref="SetComputerName"/> sets NetBIOS name of the local computer, not that of the cluster virtual server.
        /// </para>
        /// <para>
        /// To set the DNS host name or the DNS domain name, call the <see cref="SetComputerNameEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/sysinfoapi/nf-sysinfoapi-setcomputernamew"/>
        /// </para>
        /// </summary>
        /// <param name="lpComputerName">
        /// <para>
        /// The computer name that will take effect the next time the computer is started.
        /// The name must not be longer than <see cref="MAX_COMPUTERNAME_LENGTH"/> characters.
        /// </para>
        /// <para>
        /// The standard character set includes letters, numbers, and the following symbols: ! @ # $ % ^ &amp; ' ) ( . - _ { } ~ .
        /// If this parameter contains one or more characters that are outside the standard character set,
        /// <see cref="SetComputerName"/> returns <see cref="ERROR_INVALID_PARAMETER"/>.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a nonzero value.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// Applications using this function must have administrator rights.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetComputerNameW", ExactSpelling = true)]
        public static extern BOOL SetComputerName([In] LPCWSTR lpComputerName);

        /// <summary>
        /// <para>
        /// Sets the current local time and date.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/sysinfoapi/nf-sysinfoapi-setlocaltime"/>
        /// </para>
        /// </summary>
        /// <param name="lpSystemTime">
        /// <para>
        /// A pointer to a <see cref="SYSTEMTIME"/> structure that contains the new local date and time.
        /// </para>
        /// <para>
        /// The <see cref="SYSTEMTIME.wDayOfWeek"/> member of the <see cref="SYSTEMTIME"/> structure is ignored.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>.
        /// <para>
        /// The calling process must have the <see cref="SE_SYSTEMTIME_NAME"/> privilege.
        /// This privilege is disabled by default.
        /// The <see cref="SetLocalTime"/> function enables the <see cref="SE_SYSTEMTIME_NAME"/> privilege
        /// before changing the local time and disables the privilege before returning.
        /// For more information, see Running with Special Privileges.
        /// </para>
        /// <para>
        /// The system uses UTC internally.
        /// Therefore, when you call <see cref="SetLocalTime"/>,
        /// the system uses the current time zone information to perform the conversion, including the daylight saving time setting.
        /// Note that the system uses the daylight saving time setting of the current time, not the new time you are setting.
        /// Therefore, to ensure the correct result, call <see cref="SetLocalTime"/> a second time,
        /// now that the first call has updated the daylight saving time setting.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetLocalTime", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetLocalTime([In] in SYSTEMTIME lpSystemTime);

        /// <summary>
        /// <para>
        /// Sets the current system time and date. The system time is expressed in Coordinated Universal Time (UTC).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/sysinfoapi/nf-sysinfoapi-setsystemtime"/>
        /// </para>
        /// </summary>
        /// <param name="lpSystemTime">
        /// <para>
        /// A pointer to a <see cref="SYSTEMTIME"/> structure that contains the new system date and time.
        /// </para>
        /// <para>
        /// The <see cref="SYSTEMTIME.wDayOfWeek"/> member of the <see cref="SYSTEMTIME"/> structure is ignored.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The calling process must have the <see cref="SE_SYSTEMTIME_NAME"/> privilege.
        /// This privilege is disabled by default.
        /// The <see cref="SetSystemTime"/> function enables the <see cref="SE_SYSTEMTIME_NAME"/> privilege
        /// before changing the system time and disables the privilege before returning.
        /// For more information, see Running with Special Privileges.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetSystemTime", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetSystemTime([In] in SYSTEMTIME lpSystemTime);

        /// <summary>
        /// <para>
        /// Enables or disables periodic time adjustments to the system's time-of-day clock.
        /// When enabled, such time adjustments can be used to synchronize the time of day with some other source of time information.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/sysinfoapi/nf-sysinfoapi-setsystemtimeadjustment"/>
        /// </para>
        /// </summary>
        /// <param name="dwTimeAdjustment">
        /// <para>
        /// This value represents the number of 100-nanosecond units added to the system time-of-day
        /// for each <c>lpTimeIncrement</c> period of time that actually passes.
        /// Call <see cref="GetSystemTimeAdjustment"/> to obtain the <c>lpTimeIncrement</c> value.
        /// See remarks.
        /// </para>
        /// <para>
        /// Note  
        /// </para>
        /// <para>
        /// Currently, Windows Vista and Windows 7 machines will lose any time adjustments set less than 16.
        /// </para>
        /// </param>
        /// <param name="bTimeAdjustmentDisabled">
        /// <para>
        /// The time adjustment mode that the system is to use.
        /// Periodic system time adjustments can be disabled or enabled.
        /// </para>
        /// <para>
        /// A value of <see cref="TRUE"/> specifies that periodic time adjustment is to be disabled.
        /// When disabled, the value of <paramref name="dwTimeAdjustment"/> is ignored,
        /// and the system may adjust the time of day using its own internal time synchronization mechanisms.
        /// These internal time synchronization mechanisms may cause the time-of-day clock to change
        /// during the normal course of the system operation, which can include noticeable jumps in time as deemed necessary by the system.
        /// </para>
        /// <para>
        /// A value of <see cref="FALSE"/> specifies that periodic time adjustment is to be enabled,
        /// and will be used to adjust the time-of-day clock.
        /// The system will not interfere with the time adjustment scheme, and will not attempt to synchronize time of day on its own.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is non-zero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// One way the function can fail is if the caller does not possess the <see cref="SE_SYSTEMTIME_NAME"/> privilege.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="GetSystemTimeAdjustment"/> and <see cref="SetSystemTimeAdjustment"/> functions
        /// support algorithms that synchronize the time-of-day clock,
        /// reported via <see cref="GetSystemTime"/> and <see cref="GetLocalTime"/>,
        /// with another time source using a periodic time adjustment.
        /// </para>
        /// <para>
        /// The <see cref="SetSystemTimeAdjustment"/> function supports two modes of time synchronization:
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Mode
        /// </term>
        /// <term>
        /// Behavior
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Time-Adjustment Disabled
        /// </term>
        /// <term>
        /// For this mode, <paramref name="bTimeAdjustmentDisabled"/> is set to <see cref="TRUE"/>.
        /// In this mode, the value of <paramref name="dwTimeAdjustment"/> is ignored,
        /// and the system may adjust the time of day using its own internal time synchronization mechanisms.
        /// These internal time synchronization mechanisms may cause the time-of-day clock to change
        /// during the normal course of the system operation, which can include noticeable jumps in time as deemed necessary by the system.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Time-Adjustment Enabled
        /// </term>
        /// <term>
        /// <para>
        /// For this mode, <paramref name="bTimeAdjustmentDisabled"/> is set to <see cref="FALSE"/>.
        /// For each <c>lpTimeIncrement</c> period of time that actually passes, <paramref name="dwTimeAdjustment"/> will be added to the time of day.
        /// The period of time represented by <c>lpTimeIncrement</c> can be determined by calling <see cref="GetSystemTimeAdjustment"/>.
        /// The <c>lpTimeIncrement</c> value is fixed by the system upon start and does not change
        /// during system operation and is completely independent of the system’s internal clock interrupt resolution at any given time.
        /// Given this, the <c>lpTimeIncrement</c> value simply expresses a period of time
        /// for which <paramref name="dwTimeAdjustment"/> will be applied to the system’s time-of-day clock.
        /// </para>
        /// <para>
        /// If the <paramref name="dwTimeAdjustment"/> value is smaller than <c>lpTimeIncrement</c>,
        /// the time-of-day clock will advance at a rate slower than normal.
        /// If the <paramref name="dwTimeAdjustment"/> value is larger than <c>lpTimeIncrement</c>,
        /// the time-of-day clock will advance at a rate faster than normal.
        /// The degree to which the time-of-day-clock will run faster or slower depends on
        /// how far the <paramref name="dwTimeAdjustment"/> value is above or below the <c>lpTimeIncrement</c> value.
        /// If <paramref name="dwTimeAdjustment"/> equals <c>lpTimeIncrement</c>, the time-of-day clock will advance at normal speed.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// An application must have system-time privilege (the <see cref="SE_SYSTEMTIME_NAME"/> privilege) for this function to succeed.
        /// The <see cref="SE_SYSTEMTIME_NAME"/> privilege is disabled by default.
        /// Use the <see cref="AdjustTokenPrivileges"/> function to enable the privilege before calling <see cref="SetSystemTimeAdjustment"/>,
        /// and then to disable the privilege after the <see cref="SetSystemTimeAdjustment"/> call.
        /// For more information, see Running with Special Privileges.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetSystemTimeAdjustment", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetSystemTimeAdjustment([In] DWORD dwTimeAdjustment, [In] BOOL bTimeAdjustmentDisabled);

        /// <summary>
        /// <para>
        /// Compares a set of operating system version requirements to the corresponding values for the currently running version of the system.
        /// This function is subject to manifest-based behavior.
        /// For more information, see the Remarks section.
        /// </para>
        /// <para>
        /// Note:
        /// This function has been deprecated for Windows 10.
        /// See targeting your applications for Windows for more information.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-verifyversioninfow"/>
        /// </para>
        /// </summary>
        /// <param name="lpVersionInformation">
        /// <para>
        /// A pointer to an <see cref="OSVERSIONINFOEX"/> structure containing the operating system version requirements to compare.
        /// The <paramref name="dwTypeMask"/> parameter indicates the members of this structure that contain information to compare.
        /// </para>
        /// <para>
        /// You must set the <see cref="OSVERSIONINFOEX.dwOSVersionInfoSize"/> member of this structure to <c>sizeof(OSVERSIONINFOEX)</c>.
        /// You must also specify valid data for the members indicated by <paramref name="dwTypeMask"/>.
        /// The function ignores structure members for which the corresponding <paramref name="dwTypeMask"/> bit is not set.
        /// </para>
        /// </param>
        /// <param name="dwTypeMask">
        /// <para>
        /// A mask that indicates the members of the <see cref="OSVERSIONINFOEX"/> structure to be tested.
        /// This parameter can be one or more of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="VER_BUILDNUMBER"/>
        /// </para>
        /// <para>
        /// 0x0000004
        /// </para>
        /// </term>
        /// <term>
        /// <see cref="OSVERSIONINFOEX.dwBuildNumber"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VER_MAJORVERSION"/>
        /// </para>
        /// <para>
        /// 0x0000002
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// <see cref="OSVERSIONINFOEX.dwMajorVersion"/>
        /// </para>
        /// <para>
        /// If you are testing the major version, you must also test the minor version and the service pack major and minor versions.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VER_MINORVERSION"/>
        /// </para>
        /// <para>
        /// 0x0000001
        /// </para>
        /// </term>
        /// <term>
        /// <see cref="OSVERSIONINFOEX.dwMinorVersion"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VER_PLATFORMID"/>
        /// </para>
        /// <para>
        /// 0x0000008
        /// </para>
        /// </term>
        /// <term>
        /// <see cref="OSVERSIONINFOEX.dwPlatformId"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VER_SERVICEPACKMAJOR"/>
        /// </para>
        /// <para>
        /// 0x0000020
        /// </para>
        /// </term>
        /// <term>
        /// <see cref="OSVERSIONINFOEX.wServicePackMajor"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VER_SERVICEPACKMINOR"/>
        /// </para>
        /// <para>
        /// 0x0000010
        /// </para>
        /// </term>
        /// <term>
        /// <see cref="OSVERSIONINFOEX.wServicePackMinor"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VER_SUITENAME"/>
        /// </para>
        /// <para>
        /// 0x0000040
        /// </para>
        /// </term>
        /// <term>
        /// <see cref="OSVERSIONINFOEX.wSuiteMask"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VER_PRODUCT_TYPE"/>
        /// </para>
        /// <para>
        /// 0x0000080
        /// </para>
        /// </term>
        /// <term>
        /// <see cref="OSVERSIONINFOEX.wProductType"/>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="dwlConditionMask">
        /// The type of comparison to be used for each <paramref name="lpVersionInformation"/> member being compared.
        /// To build this value, call the <see cref="VerSetConditionMask"/> function
        /// or the <see cref="VER_SET_CONDITION"/> macro once for each <see cref="OSVERSIONINFOEX"/> member being compared.
        /// </param>
        /// <returns>
        /// <para>
        /// If the currently running operating system satisfies the specified requirements, the return value is a nonzero value.
        /// </para>
        /// <para>
        /// If the current system does not satisfy the requirements,
        /// the return value is zero and <see cref="GetLastError"/> returns <see cref="ERROR_OLD_WIN_VERSION"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero
        /// and <see cref="GetLastError"/> returns an error code other than <see cref="ERROR_OLD_WIN_VERSION"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="VerifyVersionInfo"/> function retrieves version information
        /// about the currently running operating system and compares it to the valid members of the <paramref name="lpVersionInformation"/> structure.
        /// This enables you to easily determine the presence of a required set of operating system version conditions.
        /// It is preferable to use <see cref="VerifyVersionInfo"/> rather than calling the <see cref="GetVersionEx"/> function to perform your own comparisons.
        /// </para>
        /// <para>
        /// Typically, <see cref="VerifyVersionInfo"/> returns a nonzero value only if all specified tests succeed.
        /// However, major, minor, and service pack versions are tested in a hierarchical manner
        /// because the operating system version is a combination of these values.
        /// If a condition exists for the major version, it supersedes the conditions specified for minor version and service pack version.
        /// (You cannot test for major version greater than 5 and minor version less than or equal to 1.
        /// If you specify such a test, the function will change the request to test for a minor version greater than 1
        /// because it is performing a greater than operation on the major version.)
        /// </para>
        /// <para>
        /// The function tests these values in this order: major version, minor version, and service pack version.
        /// The function continues testing values while they are equal, and stops when one of the values does not meet the specified condition.
        /// For example, if you test for a system greater than or equal to version 5.1 service pack 1, the test succeeds if the current version is 6.0.
        /// (The major version is greater than the specified version, so the testing stops.)
        /// In the same way, if you test for a system greater than or equal to version 5.1 service pack 1, the test succeeds if the current version is 5.2.
        /// (The minor version is greater than the specified versions, so the testing stops.)
        /// However, if you test for a system greater than or equal to version 5.1 service pack 1, the test fails if the current version is 5.0 service pack 2.
        /// (The minor version is not greater than the specified version, so the testing stops.)
        /// </para>
        /// <para>
        /// To verify a range of system versions, you must call <see cref="VerifyVersionInfo"/> twice.
        /// For example, to verify that the system version is greater than 5.0 but less than or equal to 5.1,
        /// first call <see cref="VerifyVersionInfo"/> to test that the major version is 5 and the minor version is greater than 0,
        /// then call <see cref="VerifyVersionInfo"/> again to test that the major version is 5 and the minor version is less than or equal to 1.
        /// </para>
        /// <para>
        /// Identifying the current operating system is usually not the best way to determine whether a particular operating system feature is present.
        /// This is because the operating system may have had new features added in a redistributable DLL.
        /// Rather than using <see cref="GetVersionEx"/> to determine the operating system platform or version number, test for the presence of the feature itself.
        /// For more information, see Operating System Version.
        /// </para>
        /// <para>
        /// To verify whether the current operating system is either the Media Center or Tablet PC version of Windows, call <see cref="GetSystemMetrics"/>.
        /// </para>
        /// <para>
        /// Windows 10:
        /// <see cref="VerifyVersionInfo"/> returns false when called by applications that do not have a compatibility manifest for Windows 8.1 or Windows 10
        /// if the <paramref name="lpVersionInformation"/> parameter is set so that it specifies Windows 8.1 or Windows 10,
        /// even when the current operating system version is Windows 8.1 or Windows 10.
        /// Specifically, <see cref="VerifyVersionInfo"/> has the following behavior:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// If the application has no manifest, <see cref="VerifyVersionInfo"/> behaves as if the operation system version is Windows 8 (6.2).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the application has a manifest that contains the GUID that corresponds to Windows 8.1,
        /// <see cref="VerifyVersionInfo"/> behaves as if the operation system version is Windows 8.1 (6.3).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the application has a manifest that contains the GUID that corresponds to Windows 10,
        /// <see cref="VerifyVersionInfo"/> behaves as if the operation system version is Windows 10 (10.0).
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The Version Helper functions use the <see cref="VerifyVersionInfo"/> function,
        /// so the behavior <see cref="IsWindows8Point1OrGreater"/> and <see cref="IsWindows10OrGreater"/>
        /// are similarly affected by the presence and content of the manifest.
        /// </para>
        /// <para>
        /// To manifest your applications for Windows 8.1 or Windows 10, see Targeting your application for Windows.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "VerifyVersionInfoW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL VerifyVersionInfo([In] in OSVERSIONINFOEX lpVersionInformation,
            [In] VerifyVersionInfoTypeMasks dwTypeMask, [In] DWORDLONG dwlConditionMask);
    }
}
