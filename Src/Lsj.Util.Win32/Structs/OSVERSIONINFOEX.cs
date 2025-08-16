using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.User32;
using static Lsj.Util.Win32.Enums.PlatformIds;
using static Lsj.Util.Win32.Enums.SuiteMasks;
using static Lsj.Util.Win32.Enums.NTProductTypes;
using static Lsj.Util.Win32.Enums.SystemMetricIndexes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals.ByValStructs;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains operating system version information.
    /// The information includes major and minor version numbers, a build number, a platform identifier,
    /// and information about product suites and the latest Service Pack installed on the system.
    /// This structure is used with the <see cref="GetVersionEx"/> and <see cref="VerifyVersionInfo"/> functions.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-osversioninfoexw"/>
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
    /// <para>
    /// You should not rely upon only the <see cref="VER_SUITE_SMALLBUSINESS"/> flag
    /// to determine whether Small Business Server has been installed on the system,
    /// as both this flag and the <see cref="VER_SUITE_SMALLBUSINESS_RESTRICTED"/> flag are set when this product suite is installed.
    /// If you upgrade this installation to Windows Server, Standard Edition,
    /// the <see cref="VER_SUITE_SMALLBUSINESS_RESTRICTED"/> flag will be cleared—however,
    /// the <see cref="VER_SUITE_SMALLBUSINESS"/> flag will remain set.
    /// In this case, this indicates that Small Business Server was once installed on this system.
    /// If this installation is further upgraded to Windows Server, Enterprise Edition,
    /// the <see cref="VER_SUITE_SMALLBUSINESS"/> flag will remain set.
    /// </para>
    /// <para>
    /// If compatibility mode is in effect, the <see cref="OSVERSIONINFOEX"/> structure
    /// contains information about the operating system that is selected for application compatibility.
    /// </para>
    /// <para>
    /// To determine whether a Win32-based application is running on WOW64, call the <see cref="IsWow64Process"/> function.
    /// To determine whether the system is running a 64-bit version of Windows, call the <see cref="GetNativeSystemInfo"/> function.
    /// </para>
    /// <para>
    /// The <see cref="GetSystemMetrics"/> function provides the following additional information about the current operating system.
    /// </para>
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
    /// Windows Server 2003 R2
    /// </term>
    /// <term>
    /// <see cref="SM_SERVERR2"/>
    /// </term>
    /// </item>
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
    /// Windows XP Tablet PC Edition
    /// </term>
    /// <term>
    /// <see cref="SM_TABLETPC"/>
    /// </term>
    /// </item>
    /// </list>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct OSVERSIONINFOEX
    {
        /// <summary>
        /// The size of this data structure, in bytes. Set this member to sizeof(<see cref="OSVERSIONINFOEX"/>).
        /// </summary>
        public DWORD dwOSVersionInfoSize;

        /// <summary>
        /// The major version number of the operating system. For more information, see Remarks.
        /// </summary>
        public DWORD dwMajorVersion;

        /// <summary>
        /// The minor version number of the operating system. For more information, see Remarks.
        /// </summary>
        public uint dwMinorVersion;

        /// <summary>
        /// The build number of the operating system.
        /// </summary>
        public DWORD dwBuildNumber;

        /// <summary>
        /// The operating system platform. This member can be <see cref="VER_PLATFORM_WIN32_NT"/> (2).
        /// </summary>
        public PlatformIds dwPlatformId;

        /// <summary>
        /// A null-terminated string, such as "Service Pack 3", that indicates the latest Service Pack installed on the system.
        /// If no Service Pack has been installed, the string is empty.
        /// </summary>
        public ByValStringStructForSize128 szCSDVersion;

        /// <summary>
        /// The major version number of the latest Service Pack installed on the system.
        /// For example, for Service Pack 3, the major version number is 3.
        /// If no Service Pack has been installed, the value is zero.
        /// </summary>
        public WORD wServicePackMajor;

        /// <summary>
        /// The minor version number of the latest Service Pack installed on the system.
        /// For example, for Service Pack 3, the minor version number is 0.
        /// </summary>
        public WORD wServicePackMinor;

        /// <summary>
        /// <para>
        /// A bit mask that identifies the product suites available on the system.
        /// This member can be a combination of the following values.
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
        /// <see cref="VER_SUITE_BACKOFFICE"/>
        /// </para>
        /// <para>
        /// 0x00000004
        /// </para>
        /// </term>
        /// <term>
        /// Microsoft BackOffice components are installed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VER_SUITE_BLADE"/>
        /// </para>
        /// <para>
        /// 0x00000400
        /// </para>
        /// </term>
        /// <term>
        /// Windows Server 2003, Web Edition is installed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VER_SUITE_COMPUTE_SERVER"/>
        /// </para>
        /// <para>
        /// 0x00004000
        /// </para>
        /// </term>
        /// <term>
        /// Windows Server 2003, Compute Cluster Edition is installed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VER_SUITE_DATACENTER"/>
        /// </para>
        /// <para>
        /// 0x00000080
        /// </para>
        /// </term>
        /// <term>
        /// Windows Server 2008 Datacenter, Windows Server 2003, Datacenter Edition, or Windows 2000 Datacenter Server is installed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VER_SUITE_ENTERPRISE"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// Windows Server 2008 Enterprise, Windows Server 2003, Enterprise Edition, or Windows 2000 Advanced Server is installed.
        /// Refer to the Remarks section for more information about this bit flag.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VER_SUITE_EMBEDDEDNT"/>
        /// </para>
        /// <para>
        /// 0x00000040
        /// </para>
        /// </term>
        /// <term>
        /// Windows XP Embedded is installed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VER_SUITE_PERSONAL"/>
        /// </para>
        /// <para>
        /// 0x00000200
        /// </para>
        /// </term>
        /// <term>
        /// Windows Vista Home Premium, Windows Vista Home Basic, or Windows XP Home Edition is installed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VER_SUITE_SINGLEUSERTS"/>
        /// </para>
        /// <para>
        /// 0x00000100
        /// </para>
        /// </term>
        /// <term>
        /// Remote Desktop is supported, but only one interactive session is supported.
        /// This value is set unless the system is running in application server mode.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VER_SUITE_SMALLBUSINESS"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// Microsoft Small Business Server was once installed on the system, but may have been upgraded to another version of Windows.
        /// Refer to the Remarks section for more information about this bit flag.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VER_SUITE_SMALLBUSINESS_RESTRICTED"/>
        /// </para>
        /// <para>
        /// 0x00000020
        /// </para>
        /// </term>
        /// <term>
        /// Microsoft Small Business Server is installed with the restrictive client license in force.
        /// Refer to the Remarks section for more information about this bit flag.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VER_SUITE_STORAGE_SERVER"/>
        /// </para>
        /// <para>
        /// 0x00002000
        /// </para>
        /// </term>
        /// <term>
        /// Windows Storage Server 2003 R2 or Windows Storage Server 2003 is installed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VER_SUITE_TERMINAL"/>
        /// </para>
        /// <para>
        /// 0x00000010
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Terminal Services is installed.
        /// This value is always set.
        /// </para>
        /// <para>
        /// If <see cref="VER_SUITE_TERMINAL"/> is set but <see cref="VER_SUITE_SINGLEUSERTS"/> is not set,
        /// the system is running in application server mode.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VER_SUITE_WH_SERVER"/>
        /// </para>
        /// <para>
        /// 0x00008000
        /// </para>
        /// </term>
        /// <term>
        /// Windows Home Server is installed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VER_SUITE_MULTIUSERTS"/>
        /// </para>
        /// <para>
        /// 0x00020000
        /// </para>
        /// </term>
        /// <term>
        /// AppServer mode is enabled.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public WORD wSuiteMask;

        /// <summary>
        /// <para>
        /// Any additional information about the system.
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
        /// <see cref="VER_NT_DOMAIN_CONTROLLER"/>
        /// </para>
        /// <para>
        /// 0x0000002
        /// </para>
        /// </term>
        /// <term>
        /// The system is a domain controller and the operating system is Windows Server 2012,
        /// Windows Server 2008 R2, Windows Server 2008, Windows Server 2003, or Windows 2000 Server.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VER_NT_SERVER"/>
        /// </para>
        /// <para>
        /// 0x0000003
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The operating system is Windows Server 2012, Windows Server 2008 R2, Windows Server 2008, Windows Server 2003, or Windows 2000 Server.
        /// </para>
        /// <para>
        /// Note that a server that is also a domain controller is reported as <see cref="VER_NT_DOMAIN_CONTROLLER"/>, not <see cref="VER_NT_SERVER"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VER_NT_WORKSTATION"/>
        /// </para>
        /// <para>
        /// 0x0000001
        /// </para>
        /// </term>
        /// <term>
        /// The operating system is Windows 8, Windows 7, Windows Vista, Windows XP Professional, Windows XP Home Edition, or Windows 2000 Professional.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public NTProductTypes wProductType;

        /// <summary>
        /// Reserved for future use. 
        /// </summary>
        public BYTE wReserved;
    }
}
