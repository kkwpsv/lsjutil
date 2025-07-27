using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Enums.PlatformIds;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals.ByValStructs;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains operating system version information.
    /// The information includes major and minor version numbers, a build number, a platform identifier, and descriptive text about the operating system.
    /// This structure is used with the <see cref="GetVersionEx"/> function.
    /// </para>
    /// <para>
    /// To obtain additional version information, use the <see cref="OSVERSIONINFOEX"/> structure with <see cref="GetVersionEx"/> instead.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-osversioninfow"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Relying on version information is not the best way to test for a feature.
    /// Instead, refer to the documentation for the feature of interest.
    /// For more information on common techniques for feature detection, see Operating System Version.
    /// </para>
    /// <para>
    /// If you must require a particular operating system, be sure to use it as a minimum supported version,
    /// rather than design the test for the one operating system.
    /// This way, your detection code will continue to work on future versions of Windows.
    /// </para>
    /// <para>
    /// The following table summarizes the values returned by supported versions of Windows.
    /// Use the information in the column labeled "Other" to distinguish between operating systems with identical version numbers.
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Operating system
    /// </term>
    /// <term>
    /// Version number
    /// </term>
    /// <term>
    /// <see cref="dwMajorVersion"/>
    /// </term>
    /// <term>
    /// <see cref="dwMinorVersion"/>
    /// </term>
    /// <term>
    /// Other
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// Windows 10
    /// </term>
    /// <term>
    /// 10.0*
    /// </term>
    /// <term>
    /// 10
    /// </term>
    /// <term>
    /// 0
    /// </term>
    /// <term>
    /// <code>OSVERSIONINFOEX.wProductType == VER_NT_WORKSTATION</code>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Windows Server 2016
    /// </term>
    /// <term>
    /// 10.0*
    /// </term>
    /// <term>
    /// 10
    /// </term>
    /// <term>
    /// 0
    /// </term>
    /// <term>
    /// <code>OSVERSIONINFOEX.wProductType != VER_NT_WORKSTATION</code>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Windows 8.1
    /// </term>
    /// <term>
    /// 6.3*
    /// </term>
    /// <term>
    /// 6
    /// </term>
    /// <term>
    /// 3
    /// </term>
    /// <term>
    /// <code>OSVERSIONINFOEX.wProductType == VER_NT_WORKSTATION</code>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Windows Server 2012 R2
    /// </term>
    /// <term>
    /// 6.3*
    /// </term>
    /// <term>
    /// 6
    /// </term>
    /// <term>
    /// 3
    /// </term>
    /// <term>
    /// <code>OSVERSIONINFOEX.wProductType != VER_NT_WORKSTATION</code>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Windows 8
    /// </term>
    /// <term>
    /// 6.2
    /// </term>
    /// <term>
    /// 6
    /// </term>
    /// <term>
    /// 2
    /// </term>
    /// <term>
    /// <code>OSVERSIONINFOEX.wProductType == VER_NT_WORKSTATION</code>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Windows Server 2012
    /// </term>
    /// <term>
    /// 6.2
    /// </term>
    /// <term>
    /// 6
    /// </term>
    /// <term>
    /// 2
    /// </term>
    /// <term>
    /// <code>OSVERSIONINFOEX.wProductType != VER_NT_WORKSTATION</code>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Windows 7
    /// </term>
    /// <term>
    /// 6.1
    /// </term>
    /// <term>
    /// 6
    /// </term>
    /// <term>
    /// 1
    /// </term>
    /// <term>
    /// <code>OSVERSIONINFOEX.wProductType == VER_NT_WORKSTATION</code>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Windows Server 2008 R2
    /// </term>
    /// <term>
    /// 6.1
    /// </term>
    /// <term>
    /// 6
    /// </term>
    /// <term>
    /// 1
    /// </term>
    /// <term>
    /// <code>OSVERSIONINFOEX.wProductType != VER_NT_WORKSTATION</code>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Windows Server 2008
    /// </term>
    /// <term>
    /// 6.0
    /// </term>
    /// <term>
    /// 6
    /// </term>
    /// <term>
    /// 0
    /// </term>
    /// <term>
    /// <code>OSVERSIONINFOEX.wProductType != VER_NT_WORKSTATION</code>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Windows Vista
    /// </term>
    /// <term>
    /// 6.0
    /// </term>
    /// <term>
    /// 6
    /// </term>
    /// <term>
    /// 0
    /// </term>
    /// <term>
    /// <code>OSVERSIONINFOEX.wProductType == VER_NT_WORKSTATION</code>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Windows Server 2003 R2
    /// </term>
    /// <term>
    /// 5.2
    /// </term>
    /// <term>
    /// 5
    /// </term>
    /// <term>
    /// 2
    /// </term>
    /// <term>
    /// <code>GetSystemMetrics(SM_SERVERR2) != 0</code>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Windows Server 2003
    /// </term>
    /// <term>
    /// 5.2
    /// </term>
    /// <term>
    /// 5
    /// </term>
    /// <term>
    /// 2
    /// </term>
    /// <term>
    /// <code>GetSystemMetrics(SM_SERVERR2) == 0</code>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Windows XP
    /// </term>
    /// <term>
    /// 5.1
    /// </term>
    /// <term>
    /// 5
    /// </term>
    /// <term>
    /// 1
    /// </term>
    /// <term>
    /// Not applicable
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Windows 2000
    /// </term>
    /// <term>
    /// 5.0
    /// </term>
    /// <term>
    /// 5
    /// </term>
    /// <term>
    /// 0
    /// </term>
    /// <term>
    /// Not applicable
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// * For applications that have been manifested for Windows 8.1 or Windows 10.
    /// Applications not manifested for Windows 8.1 or Windows 10 will return the Windows 8 OS version value (6.2).
    /// To manifest your applications for Windows 8.1 or Windows 10, refer to Targeting your application for Windows.
    /// </term>
    /// </item>
    /// </list>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct OSVERSIONINFO
    {
        /// <summary>
        /// The size of this data structure, in bytes. Set this member to sizeof(<see cref="OSVERSIONINFO"/>).
        /// </summary>
        public DWORD dwOSVersionInfoSize;

        /// <summary>
        /// The major version number of the operating system. For more information, see Remarks.
        /// </summary>
        public DWORD dwMajorVersion;

        /// <summary>
        /// The minor version number of the operating system. For more information, see Remarks.
        /// </summary>
        public DWORD dwMinorVersion;

        /// <summary>
        /// The build number of the operating system. This member can be <see cref="VER_PLATFORM_WIN32_NT"/>.
        /// </summary>
        public DWORD dwBuildNumber;

        /// <summary>
        /// <para>
        /// The operating system platform. This member can be the following value.
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
        /// <see cref="VER_PLATFORM_WIN32_NT"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// The operating system is Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003, Windows XP, or Windows 2000.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public PlatformIds dwPlatformId;

        /// <summary>
        /// A null-terminated string, such as "Service Pack 3", that indicates the latest Service Pack installed on the system.
        /// If no Service Pack has been installed, the string is empty.
        /// </summary>
        public ByValStringStructForSize128 szCSDVersion;
    }
}
