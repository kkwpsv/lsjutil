﻿using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using System.Text;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// Retrieves information about logical processors and related hardware.
        /// To retrieve information about logical processors and related hardware, including processor groups,
        /// use the <see cref="GetLogicalProcessorInformationEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/en-us/windows/win32/api/sysinfoapi/nf-sysinfoapi-getlogicalprocessorinformation
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
        /// and <see cref="ReturnLength"/> is set to the buffer length required to contain all of the data.
        /// If the function fails with an error other than <see cref="ERROR_INSUFFICIENT_BUFFER"/>,
        /// the value of <see cref="ReturnLength"/> is undefined.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/> and
        /// at least one <see cref="SYSTEM_LOGICAL_PROCESSOR_INFORMATION"/> structure is written to the output buffer.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="GetLogicalProcessorInformation"/> can be used to get information about the relationship
        /// between logical processors in the system, including:
        /// The logical processors that are part of a NUMA node.
        /// The logical processors that share resources. An example of this type of resource sharing would be hyperthreading scenarios.
        /// Your application can use this information when affinitizing your threads and processes
        /// to take best advantage of the hardware properties of the platform,
        /// or to determine the number of logical and physical processors for licensing purposes.
        /// Each of the <see cref="SYSTEM_LOGICAL_PROCESSOR_INFORMATION"/> structures returned in the buffer contains the following:
        /// A logical processor affinity mask, which indicates the logical processors that the information in the structure applies to.
        /// A logical processor mask of type <see cref="LOGICAL_PROCESSOR_RELATIONSHIP"/>,
        /// which indicates the relationship between the logical processors in the mask.
        /// Applications calling this function must be prepared to handle additional indicator values in the future.
        /// Note that the order in which the structures are returned in the buffer may change between calls to this function.
        /// The size of the <see cref="SYSTEM_LOGICAL_PROCESSOR_INFORMATION"/> structure varies between processor architectures and versions of Windows.
        /// For this reason, applications should first call this function to obtain the required buffer size,
        /// then dynamically allocate memory for the buffer.
        /// On systems with more than 64 logical processors, the <see cref="GetLogicalProcessorInformation"/> function retrieves
        /// logical processor information about processors in the processor group to which the calling thread is currently assigned.
        /// Use the <see cref="GetLogicalProcessorInformationEx"/> function to retrieve information about processors in all processor groups on the system.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetLogicalProcessorInformationEx", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetLogicalProcessorInformation([In]IntPtr Buffer, [In][Out]ref uint ReturnedLength);

        /// <summary>
        /// <para>
        /// Retrieves information about the relationships of logical processors and related hardware.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/sysinfoapi/nf-sysinfoapi-getlogicalprocessorinformationex
        /// </para>
        /// </summary>
        /// <param name="RelationshipType">
        /// The type of relationship to retrieve.
        /// This parameter can be one of the following <see cref="LOGICAL_PROCESSOR_RELATIONSHIP"/> values.
        /// <see cref="RelationCache"/>: Retrieves information about logical processors that share a cache.
        /// <see cref="RelationNumaNode"/>: Retrieves information about logical processors that are part of the same NUMA node.
        /// <see cref="RelationProcessorCore"/>: Retrieves information about logical processors that share a single processor core.
        /// <see cref="RelationProcessorPackage"/>: Retrieves information about logical processors that share a physical package.
        /// <see cref="RelationGroup"/>: Retrieves information about logical processors that share a processor group.
        /// <see cref="RelationAll"/>: Retrieves information about logical processors for all relationship types
        /// (cache, NUMA node, processor core, physical package, and processor group).
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
        /// If the function succeeds, the return value is <see langword="true"/> and
        /// at least one <see cref="SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX"/> structure is written to the output buffer.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If a 32-bit process running under WOW64 calls this function on a system with more than 64 processors,
        /// some of the processor affinity masks returned by the function may be incorrect.
        /// This is because the high-order DWORD of the 64-bit <see cref="KAFFINITY"/> structure that represents all 64 processors is "folded"
        /// into a 32-bit <see cref="KAFFINITY"/> structure in the caller's buffer.
        /// As a result, the affinity masks for processors 32 through 63 are incorrectly represented as duplicates of the masks for processors 0 through 31.
        /// In addition, the sum of all per-group <see cref="PROCESSOR_GROUP_INFO.ActiveProcessorCount"/> 
        /// and <see cref="PROCESSOR_GROUP_INFO.MaximumProcessorCount"/> values
        /// reported in <see cref="PROCESSOR_GROUP_INFO"/> structures may exclude some active logical processors.
        /// When this function is called with a relationship type of <see cref="RelationProcessorCore"/>,
        /// it returns a <see cref="PROCESSOR_RELATIONSHIP"/> structure for every active processor core in every processor group in the system.
        /// This is by design, because an unaffinitized 32-bit thread can run on any logical processor in a given group,
        /// including processors 32 through 63.
        /// A 32-bit caller can use the total count of <see cref="PROCESSOR_RELATIONSHIP"/> structures to determine the actual number
        /// of active processor cores on the system.
        /// However, the affinity of a 32-bit thread cannot be explicitly set to logical processor 32 through 63 of any processor group.
        /// To compile an application that uses this function, set _WIN32_WINNT >= 0x0601.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetLogicalProcessorInformationEx", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetLogicalProcessorInformationEx([In]LOGICAL_PROCESSOR_RELATIONSHIP RelationshipType,
            [In]IntPtr Buffer, [In][Out]ref uint ReturnedLength);

        /// <summary>
        /// <para>
        /// Retrieves information about the current system to an application running under WOW64.
        /// If the function is called from a 64-bit application, or on a 64-bit system that does not have an Intel64 or x64 processor (such as ARM64),
        /// it is equivalent to the <see cref="GetSystemInfo"/> function.
        /// </para>
        /// </summary>
        /// <param name="lpSystemInfo">
        /// A pointer to a <see cref="SYSTEM_INFO"/> structure that receives the information.
        /// </param>
        /// <remarks>
        /// To determine whether a Win32-based application is running under WOW64, call the <see cref="IsWow64Process2"/> function.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0501 or later.For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetNativeSystemInfo", SetLastError = true)]
        public static extern void GetNativeSystemInfo([Out]out SYSTEM_INFO lpSystemInfo);

        /// <summary>
        /// <para>
        /// Retrieves the product type for the operating system on the local computer,
        /// and maps the type to the product types supported by the specified operating system.
        /// To retrieve product type information on versions of Windows prior to the minimum supported operating systems specified
        /// in the Requirements section, use the <see cref="GetVersionEx"/> function.
        /// You can also use the OperatingSystemSKU property of the Win32_OperatingSystem WMI class.
        /// </para>
        /// </summary>
        /// <param name="dwOSMajorVersion">
        /// The major version number of the operating system. The minimum value is 6.
        /// The combination of the <paramref name="dwOSMajorVersion"/>, <paramref name="dwOSMinorVersion"/>, <paramref name="dwSpMajorVersion"/>,
        /// and <paramref name="dwSpMinorVersion"/> parameters describes the maximum target operating system version for the application.
        /// For example, Windows Vista and Windows Server 2008 are version 6.0.0.0 and Windows 7 and Windows Server 2008 R2 are version 6.1.0.0.
        /// All Windows 10 based releases will be listed as version 6.3.
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
        /// The product type. This parameter cannot be <see cref="IntPtr.Zero"/>.
        /// If the specified operating system is less than the current operating system,
        /// this information is mapped to the types supported by the specified operating system.
        /// If the specified operating system is greater than the highest supported operating system,
        /// this information is mapped to the types supported by the current operating system.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// To detect whether a server role or feature is installed, use the Server Feature WMI provider.
        /// Subsequent releases of Windows will map the product types it supports to the set of product types supported
        /// by each supported previous release of Windows, back to version 6.0.0.0.
        /// Therefore, an application that does an equality test for any of these values will continue to work on future releases,
        /// even when new product types are added.
        /// PRODUCT_*_SERVER_CORE values are not returned in Windows Server 2012, and later.
        /// For example, the base server edition, Server Datacenter,
        /// is used to build the two different installation options: "full server" and "core server".
        /// With Windows Server 2012, <see cref="GetProductInfo"/> will return <see cref="PRODUCT_DATACENTER"/> regardless of
        /// the option used during product installation.
        /// As noted above, for Server Core installations of Windows Server 2012 and later, use the method Determining whether Server Core is running.
        /// The following table indicates the product types that were introduced in 6.1.0.0,
        /// and what they will map to if <see cref="GetProductInfo"/> is called with version 6.0.0.0 on a 6.1.0.0 system.
        /// New for 6.1.0.0	Value                   returned with 6.0.0.0
        /// <see cref="PRODUCT_PROFESSIONAL"/>      <see cref="PRODUCT_BUSINESS"/>
        /// <see cref="PRODUCT_PROFESSIONAL_N"/>    <see cref="PRODUCT_BUSINESS_N"/>
        /// <see cref="PRODUCT_STARTER_N"/>         <see cref="PRODUCT_STARTER"/>
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetProductInfo", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetProductInfo([In]uint dwOSMajorVersion, [In]uint dwOSMinorVersion, [In]uint dwSpMajorVersion,
            [In]uint dwSpMinorVersion, [In][Out]ref ProductTypes pdwReturnedProductType);

        /// <summary>
        /// <para>
        /// Retrieves information about the current system.
        /// To retrieve accurate information for an application running on WOW64, call the <see cref="GetNativeSystemInfo"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/sysinfoapi/nf-sysinfoapi-getsysteminfo
        /// </para>
        /// </summary>
        /// <param name="lpSystemInfo">
        /// A pointer to a <see cref="SYSTEM_INFO"/> structure that receives the information.
        /// </param>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSystemInfo", SetLastError = true)]
        public static extern void GetSystemInfo([Out]out SYSTEM_INFO lpSystemInfo);

        /// <summary>
        /// <para>
        /// Retrieves the path of the system directory.
        /// The system directory contains system files such as dynamic-link libraries and drivers.
        /// This function is provided primarily for compatibility.
        /// Applications should store code in the Program Files folder and persistent data in the Application Data folder in the user's profile.
        /// For more information, see <see cref="ShGetFolderPath"/>.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/sysinfoapi/nf-sysinfoapi-getsystemdirectoryw
        /// </para>
        /// </summary>
        /// <param name="lpBuffer">
        /// A pointer to the buffer to receive the path.
        /// This path does not end with a backslash unless the system directory is the root directory.
        /// For example, if the system directory is named Windows\System32 on drive C,
        /// the path of the system directory retrieved by this function is C:\Windows\System32.
        /// </param>
        /// <param name="uSize">
        /// The maximum size of the buffer, in TCHARs.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the length, in TCHARs, of the string copied to the buffer,
        /// not including the terminating null character.
        /// If the length is greater than the size of the buffer, the return value is the size of the buffer required to hold the path,
        /// including the terminating null character.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Applications should not create files in the system directory.
        /// If the user is running a shared version of the operating system, the application does not have write access to the system directory.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSystemDirectoryW", SetLastError = true)]
        public static extern uint GetSystemDirectory([Out]StringBuilder lpBuffer, [In]uint uSize);

        /// <summary>
        /// <para>
        /// Retrieves the path of the shared Windows directory on a multi-user system.
        /// This function is provided primarily for compatibility.
        /// Applications should store code in the Program Files folder and persistent data in the Application Data folder in the user's profile.
        /// For more information, see <see cref="ShGetFolderPath"/>.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/sysinfoapi/nf-sysinfoapi-getsystemwindowsdirectoryw
        /// </para>
        /// </summary>
        /// <param name="lpBuffer">
        /// A pointer to a buffer that receives the path.
        /// This path does not end with a backslash unless the Windows directory is the root directory.
        /// For example, if the Windows directory is named Windows on drive C, the path of the Windows directory retrieved by this function is C:\Windows.
        /// If the system was installed in the root directory of drive C, the path retrieved is C:.
        /// </param>
        /// <param name="uSize">
        /// The maximum size of the buffer specified by the lpBuffer parameter, in TCHARs.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the length of the string copied to the buffer, in TCHARs,
        /// not including the terminating null character.
        /// If the length is greater than the size of the buffer, the return value is the size of the buffer required to hold the path.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// On a system that is running Terminal Services, each user has a unique Windows directory.
        /// The system Windows directory is shared by all users,
        /// so it is the directory where an application should store initialization and help files that apply to all users.
        /// With Terminal Services, the <see cref="GetSystemWindowsDirectory"/> function retrieves the path of the system Windows directory,
        /// while the <see cref="GetWindowsDirectory"/> function retrieves the path of a Windows directory that is private for each user.
        /// On a single-user system, <see cref="GetSystemWindowsDirectory"/> is the same as <see cref="GetWindowsDirectory"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSystemWindowsDirectoryW", SetLastError = true)]
        public static extern uint GetSystemWindowsDirectory([MarshalAs(UnmanagedType.LPWStr)][Out]StringBuilder lpBuffer, [In]uint uSize);

        /// <summary>
        /// <para>
        /// With the release of Windows 8.1, the behavior of the <see cref="GetVersionEx"/> API has changed in the value
        /// it will return for the operating system version.
        /// The value returned by the <see cref="GetVersionEx"/> function now depends on how the application is manifested.
        /// Applications not manifested for Windows 8.1 or Windows 10 will return the Windows 8 OS version value (6.2).
        /// Once an application is manifested for a given operating system version,
        /// <see cref="GetVersionEx"/> will always return the version that the application is manifested for in future releases.
        /// To manifest your applications for Windows 8.1 or Windows 10, refer to Targeting your application for Windows.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/sysinfoapi/nf-sysinfoapi-getversionexw
        /// </para>
        /// </summary>
        /// <param name="lpVersionInformation">
        /// An <see cref="OSVERSIONINFO"/> or <see cref="OSVERSIONINFOEX"/> structure that receives the operating system information.
        /// Before calling the <see cref="GetVersionEx"/> function, set the <see cref="OSVERSIONINFO.dwOSVersionInfoSize"/> member of the structure
        /// as appropriate to indicate which data structure is being passed to this function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// The function fails if you specify an invalid value for the <see cref="OSVERSIONINFO.dwOSVersionInfoSize"/> member
        /// of the <see cref="OSVERSIONINFO"/> or <see cref="OSVERSIONINFOEX"/> structure.
        /// </returns>
        /// <remarks>
        /// Identifying the current operating system is usually not the best way to determine whether a particular operating system feature is present.
        /// This is because the operating system may have had new features added in a redistributable DLL.
        /// Rather than using <see cref="GetVersionEx"/> to determine the operating system platform or version number, 
        /// test for the presence of the feature itself. For more information, see Operating System Version.
        /// The <see cref="GetSystemMetrics"/> function provides additional information about the current operating system.
        /// Windows XP Media Center Edition: <see cref="SM_MEDIACENTER"/>
        /// Windows XP Starter Edition: <see cref="SM_STARTER"/>
        /// Windows XP Tablet PC Edition :<see cref="SM_TABLETPC"/>
        /// Windows Server 2003 R2: <see cref="SM_SERVERR2"/>
        /// To check for specific operating systems or operating system features, use the <see cref="IsOS"/> function.
        /// The <see cref="GetProductInfo"/> function retrieves the product type.
        /// To retrieve information for the operating system on a remote computer, use the <see cref="NetWkstaGetInfo"/> function,
        /// the Win32_OperatingSystem WMI class, or the OperatingSystem property of the IADsComputer interface.
        /// To compare the current system version to a required version, use the <see cref="VerifyVersionInfo"/> function instead of
        /// using <see cref="GetVersionEx"/> to perform the comparison yourself.
        /// If compatibility mode is in effect, the <see cref="GetVersionEx"/> function reports the operating system as it identifies itself,
        /// which may not be the operating system that is installed.
        /// For example, if compatibility mode is in effect,
        /// <see cref="GetVersionEx"/> reports the operating system that is selected for application compatibility.
        /// </remarks>
        [Obsolete("GetVersionEx may be altered or unavailable for releases after Windows 8.1. Instead, use the Version Helper functions")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetVersionExW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetVersionEx(
          [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(AlternativeStructObjectMarshaler<OSVERSIONINFO, OSVERSIONINFOEX>))]
          [In]AlternativeStructObject<OSVERSIONINFO, OSVERSIONINFOEX> lpVersionInformation);

        /// <summary>
        /// <para>
        /// Retrieves the path of the Windows directory.
        /// This function is provided primarily for compatibility with legacy applications.
        /// New applications should store code in the Program Files folder and persistent data in the Application Data folder in the user's profile.
        /// For more information, see <see cref="ShGetFolderPath"/>.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/sysinfoapi/nf-sysinfoapi-getwindowsdirectoryw
        /// </para>
        /// </summary>
        /// <param name="lpBuffer">
        /// A pointer to a buffer that receives the path.
        /// This path does not end with a backslash unless the Windows directory is the root directory.
        /// For example, if the Windows directory is named Windows on drive C, the path of the Windows directory retrieved by this function is C:\Windows.
        /// If the system was installed in the root directory of drive C, the path retrieved is C:.
        /// </param>
        /// <param name="uSize">
        /// The maximum size of the buffer specified by the lpBuffer parameter, in TCHARs.
        /// This value should be set to <see cref="MAX_PATH"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the length of the string copied to the buffer, in TCHARs,
        /// not including the terminating null character.
        /// If the length is greater than the size of the buffer, the return value is the size of the buffer required to hold the path.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The Windows directory is the directory where some legacy applications store initialization and help files.
        /// New applications should not store files in the Windows directory;
        /// instead, they should store system-wide data in the application's installation directory, and user-specific data in the user's profile.
        /// If the user is running a shared version of the system, the Windows directory is guaranteed to be private for each user.
        /// If an application creates other files that it wants to store on a per-user basis,
        /// it should place them in the directory specified by the HOMEPATH environment variable.
        /// This directory will be different for each user, if so specified by an administrator, through the User Manager administrative tool.
        /// HOMEPATH always specifies either the user's home directory, which is guaranteed to be private for each user, or a default directory
        /// (for example, C:\USERS\DEFAULT) where the user will have all access.
        /// Terminal Services:
        /// If the application is running in a Terminal Services environment, each user has a private Windows directory.
        /// There is also a shared Windows directory for the system.
        /// If the application is Terminal-Services-aware (has the <see cref="IMAGE_DLLCHARACTERISTICS_TERMINAL_SERVER_AWARE"/> flag set in the image header),
        /// this function returns the path of the system Windows directory, just as the <see cref="GetSystemWindowsDirectory"/> function does.
        /// Otherwise, it retrieves the path of the private Windows directory for the user.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowsDirectoryW", SetLastError = true)]
        public static extern uint GetWindowsDirectory([MarshalAs(UnmanagedType.LPWStr)][Out]StringBuilder lpBuffer, [In]uint uSize);
    }
}