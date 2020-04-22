using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Enums.PlatformIds;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains operating system version information.
    /// The information includes major and minor version numbers, a build number, a platform identifier, and descriptive text about the operating system.
    /// This structure is used with the <see cref="GetVersionEx"/> function.
    /// To obtain additional version information, use the <see cref="OSVERSIONINFOEX"/> structure with <see cref="GetVersionEx"/> instead.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-osversioninfow
    /// </para>
    /// </summary>
    /// <remarks>
    /// Relying on version information is not the best way to test for a feature.
    /// Instead, refer to the documentation for the feature of interest.
    /// For more information on common techniques for feature detection, see Operating System Version.
    /// If you must require a particular operating system, be sure to use it as a minimum supported version,
    /// rather than design the test for the one operating system.
    /// This way, your detection code will continue to work on future versions of Windows.
    /// The following table summarizes the values returned by supported versions of Windows.
    /// Use the information in the column labeled "Other" to distinguish between operating systems with identical version numbers.
    /// Operating system        Version number  dwMajorVersion  dwMinorVersion  Other
    /// Windows 10              10.0            10              0               OSVERSIONINFOEX.wProductType == VER_NT_WORKSTATION
    /// Windows Server 2016     10.0            10              0               OSVERSIONINFOEX.wProductType != VER_NT_WORKSTATION
    /// Windows 8.1             6.3             6               3               OSVERSIONINFOEX.wProductType == VER_NT_WORKSTATION
    /// Windows Server 2012 R2  6.3             6               3               OSVERSIONINFOEX.wProductType != VER_NT_WORKSTATION
    /// Windows 8               6.2             6               2               OSVERSIONINFOEX.wProductType == VER_NT_WORKSTATION
    /// Windows Server 2012     6.2             6               2               OSVERSIONINFOEX.wProductType != VER_NT_WORKSTATION
    /// Windows 7               6.1             6               1               OSVERSIONINFOEX.wProductType == VER_NT_WORKSTATION
    /// Windows Server 2008 R2  6.1             6               1               OSVERSIONINFOEX.wProductType != VER_NT_WORKSTATION
    /// Windows Server 2008     6.0             6               0               OSVERSIONINFOEX.wProductType == VER_NT_WORKSTATION
    /// Windows Vista           6.0             6               0               OSVERSIONINFOEX.wProductType != VER_NT_WORKSTATION
    /// Windows Server 2003 R2  5.2             5               2               GetSystemMetrics(SM_SERVERR2) != 0
    /// Windows Server 2003     5.2             5               2               GetSystemMetrics(SM_SERVERR2) == 0
    /// Windows XP              5.1             5               0               Not applicable
    /// Windows 2000            5.0             5               0               Not applicable
    /// For applications that have been manifested for Windows 8.1 or Windows 10.
    /// Applications not manifested for Windows 8.1 or Windows 10 will return the Windows 8 OS version value (6.2).
    /// To manifest your applications for Windows 8.1 or Windows 10, refer to Targeting your application for Windows.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct OSVERSIONINFO
    {
        /// <summary>
        /// The size of this data structure, in bytes. Set this member to sizeof(<see cref="OSVERSIONINFO"/>).
        /// </summary>
        public uint dwOSVersionInfoSize;

        /// <summary>
        /// The major version number of the operating system. For more information, see Remarks.
        /// </summary>
        public uint dwMajorVersion;

        /// <summary>
        /// The minor version number of the operating system. For more information, see Remarks.
        /// </summary>
        public uint dwMinorVersion;

        /// <summary>
        /// The build number of the operating system. This member can be <see cref="VER_PLATFORM_WIN32_NT"/>.
        /// </summary>
        public uint dwBuildNumber;

        /// <summary>
        /// The operating system platform. This member can be the following value.
        /// </summary>
        public PlatformIds dwPlatformId;

        /// <summary>
        /// A null-terminated string, such as "Service Pack 3", that indicates the latest Service Pack installed on the system.
        /// If no Service Pack has been installed, the string is empty.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U2, SizeConst = 128)]
        public ushort[] szCSDVersion;
    }
}
