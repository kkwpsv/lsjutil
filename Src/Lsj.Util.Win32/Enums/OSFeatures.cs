using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Enums.NTProductTypes;
using static Lsj.Util.Win32.Enums.PlatformIds;
using static Lsj.Util.Win32.Enums.SuiteMasks;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// OS Features
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shlwapi/nf-shlwapi-isos"/>
    /// </para>
    /// </summary>
    public enum OSFeatures : uint
    {
        /// <summary>
        /// The program is running on one of the following versions of Windows:
        /// Windows 95
        /// Windows 98
        /// Windows Me
        /// Equivalent to <see cref="VER_PLATFORM_WIN32_WINDOWS"/>.
        /// Note that none of those systems are supported at this time.
        /// <see cref="OS_WINDOWS"/> returns <see cref="FALSE"/> on all supported systems. 
        /// </summary>
        OS_WINDOWS = 0,

        /// <summary>
        /// Always returns <see cref="TRUE"/>.
        /// </summary>
        OS_NT = 1,

        /// <summary>
        /// Always returns <see cref="FALSE"/>.
        /// </summary>
        OS_WIN95ORGREATER = 2,

        /// <summary>
        /// Always returns <see cref="FALSE"/>.
        /// </summary>
        OS_NT4ORGREATER = 3,

        /// <summary>
        /// Always returns <see cref="FALSE"/>.
        /// </summary>
        OS_WIN98ORGREATER = 5,

        /// <summary>
        /// Always returns <see cref="FALSE"/>.
        /// </summary>
        OS_WIN98_GOLD = 6,

        /// <summary>
        /// The program is running on Windows 2000 or one of its successors.
        /// </summary>
        OS_WIN2000ORGREATER = 7,

        /// <summary>
        /// Do not use; use <see cref="OS_PROFESSIONAL"/>.
        /// </summary>
        OS_WIN2000PRO = 8,

        /// <summary>
        ///  Do not use; use <see cref="OS_SERVER"/>.
        /// </summary>
        OS_WIN2000SERVER = 9,

        /// <summary>
        /// Do not use; use <see cref="OS_ADVSERVER"/>.
        /// </summary>
        OS_WIN2000ADVSERVER = 10,

        /// <summary>
        /// Do not use; use <see cref="OS_DATACENTER"/>.
        /// </summary>
        OS_WIN2000DATACENTER = 11,

        /// <summary>
        /// The program is running on Windows 2000 Terminal Server in either Remote Administration mode or Application Server mode,
        /// or Windows Server 2003 (or one of its successors) in Terminal Server mode or Remote Desktop for Administration mode.
        /// Consider using a more specific value such as <see cref="OS_TERMINALSERVER"/>,
        /// <see cref="OS_TERMINALREMOTEADMIN"/>, or <see cref="OS_PERSONALTERMINALSERVER"/>.
        /// </summary>
        OS_WIN2000TERMINAL = 12,

        /// <summary>
        /// The program is running on Windows Embedded, any version.
        /// Equivalent to <see cref="VER_SUITE_EMBEDDEDNT"/>.
        /// </summary>
        OS_EMBEDDED = 13,

        /// <summary>
        /// The program is running as a Terminal Server client.
        /// Equivalent to <code>GetSystemMetrics(SM_REMOTESESSION)</code>.
        /// </summary>
        OS_TERMINALCLIENT = 14,

        /// <summary>
        /// The program is running on Windows 2000 Terminal Server in the Remote Administration mode
        /// or Windows Server 2003 (or one of its successors) in the Remote Desktop for Administration mode (these are the default installation modes).
        /// This is equivalent to <see cref="VER_SUITE_TERMINAL"/> &amp;&amp; <see cref="VER_SUITE_SINGLEUSERTS"/>.
        /// </summary>
        OS_TERMINALREMOTEADMIN = 15,

        /// <summary>
        /// Always returns <see cref="FALSE"/>.
        /// </summary>
        OS_WIN95_GOLD = 16,

        /// <summary>
        /// Always returns <see cref="FALSE"/>.
        /// </summary>
        OS_MEORGREATER = 17,

        /// <summary>
        /// Always returns <see cref="FALSE"/>.
        /// </summary>
        OS_XPORGREATER = 18,

        /// <summary>
        /// Always returns <see cref="FALSE"/>.
        /// </summary>
        OS_HOME = 19,

        /// <summary>
        /// The program is running on Windows NT Workstation or Windows 2000 (or one of its successors) Professional.
        /// Equivalent to <see cref="VER_PLATFORM_WIN32_NT"/> &amp;&amp; <see cref="VER_NT_WORKSTATION"/>.
        /// </summary>
        OS_PROFESSIONAL = 20,

        /// <summary>
        /// The program is running on Windows Datacenter Server or Windows Server Datacenter Edition, any version.
        /// Equivalent to (<see cref="VER_NT_SERVER"/> || <see cref="VER_NT_DOMAIN_CONTROLLER"/>) &amp;&amp; <see cref="VER_SUITE_DATACENTER"/>.
        /// </summary>
        OS_DATACENTER = 21,

        /// <summary>
        /// The program is running on Windows Advanced Server or Windows Server Enterprise Edition, any version.
        /// Equivalent to (<see cref="VER_NT_SERVER"/> || <see cref="VER_NT_DOMAIN_CONTROLLER"/>)
        /// &amp;&amp; <see cref="VER_SUITE_ENTERPRISE"/> &amp;&amp; !<see cref="VER_SUITE_DATACENTER"/>.
        /// </summary>
        OS_ADVSERVER = 22,

        /// <summary>
        /// The program is running on Windows Server (Standard) or Windows Server Standard Edition, any version.
        /// This value will not return true for <see cref="VER_SUITE_DATACENTER"/>, <see cref="VER_SUITE_ENTERPRISE"/>,
        /// <see cref="VER_SUITE_SMALLBUSINESS"/>, or <see cref="VER_SUITE_SMALLBUSINESS_RESTRICTED"/>.
        /// </summary>
        OS_SERVER = 23,

        /// <summary>
        /// The program is running on Windows 2000 Terminal Server in Application Server mode,
        /// or on Windows Server 2003 (or one of its successors) in Terminal Server mode.
        /// This is equivalent to <see cref="VER_SUITE_TERMINAL"/> &amp;&amp; <see cref="VER_SUITE_SINGLEUSERTS"/>.
        /// </summary>
        OS_TERMINALSERVER = 24,

        /// <summary>
        /// The program is running on Windows XP (or one of its successors), Home Edition or Professional.
        /// This is equivalent to <see cref="VER_SUITE_SINGLEUSERTS"/> &amp;&amp; !<see cref="VER_SUITE_TERMINAL"/>.
        /// </summary>
        OS_PERSONALTERMINALSERVER = 25,

        /// <summary>
        /// Fast user switching is enabled.
        /// </summary>
        OS_FASTUSERSWITCHING = 26,

        /// <summary>
        /// Always returns <see cref="FALSE"/>.
        /// </summary>
        OS_WELCOMELOGONUI = 27,

        /// <summary>
        /// The computer is joined to a domain.
        /// </summary>
        OS_DOMAINMEMBER = 28,

        /// <summary>
        /// The program is running on any Windows Server product.
        /// Equivalent to <see cref="VER_NT_SERVER"/> || <see cref="VER_NT_DOMAIN_CONTROLLER"/>.
        /// </summary>
        OS_ANYSERVER = 29,

        /// <summary>
        ///  The program is a 32-bit program running on 64-bit Windows.
        /// </summary>
        OS_WOW6432 = 30,

        /// <summary>
        /// Always returns <see cref="FALSE"/>.
        /// </summary>
        OS_WEBSERVER = 31,

        /// <summary>
        /// The program is running on Microsoft Small Business Server with restrictive client license in force.
        /// Equivalent to <see cref="VER_SUITE_SMALLBUSINESS_RESTRICTED"/>.
        /// </summary>
        OS_SMALLBUSINESSSERVER = 32,

        /// <summary>
        /// The program is running on Windows XP Tablet PC Edition, or one of its successors.
        /// </summary>
        OS_TABLETPC = 33,

        /// <summary>
        /// The user should be presented with administrator UI.
        /// It is possible to have server administrative UI on a non-server machine.
        /// This value informs the application that an administrator's profile has roamed to a non-server,
        /// and UI should be appropriate to an administrator.
        /// Otherwise, the user is shown a mix of administrator and nonadministrator settings.
        /// </summary>
        OS_SERVERADMINUI = 34,

        /// <summary>
        /// The program is running on Windows XP Media Center Edition, or one of its successors.
        /// Equivalent to <code>GetSystemMetrics(SM_MEDIACENTER)</code>.
        /// </summary>
        OS_MEDIACENTER = 35,

        /// <summary>
        /// The program is running on Windows Appliance Server.
        /// </summary>
        OS_APPLIANCE = 36,
    }
}
