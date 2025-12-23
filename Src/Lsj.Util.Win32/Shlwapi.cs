using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HKEY;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.FormatMessageFlags;
using static Lsj.Util.Win32.Enums.OSFeatures;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Shlwapi.dll
    /// </summary>
    public static class Shlwapi
    {
        /// <summary>
        /// <para>
        /// Checks for specified operating systems and operating system features.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shlwapi/nf-shlwapi-isos"/>
        /// </para>
        /// </summary>
        /// <param name="dwOS">
        /// <para>
        /// A value that specifies which operating system or operating system feature to check for.
        /// One of the following values (you cannot combine values).
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Name
        /// </term>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="OS_WINDOWS"/>
        /// </term>
        /// <term>
        /// 0
        /// </term>
        /// <term>
        /// <para>
        /// The program is running on one of the following versions of Windows:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Windows 95
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Windows 98
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Windows Me
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Equivalent to <see cref="VER_PLATFORM_WIN32_WINDOWS"/>.
        /// Note that none of those systems are supported at this time.
        /// <see cref="OS_WINDOWS"/> returns <see cref="FALSE"/> on all supported systems.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OS_NT"/>
        /// </term>
        /// <term>
        /// 1
        /// </term>
        /// <term>
        /// Always returns <see cref="TRUE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OS_WIN95ORGREATER"/>
        /// </term>
        /// <term>
        /// 2
        /// </term>
        /// <term>
        /// Always returns <see cref="FALSE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OS_NT4ORGREATER"/>
        /// </term>
        /// <term>
        /// 3
        /// </term>
        /// <term>
        /// Always returns <see cref="FALSE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OS_WIN98ORGREATER"/>
        /// </term>
        /// <term>
        /// 5
        /// </term>
        /// <term>
        /// Always returns <see cref="FALSE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OS_WIN98_GOLD"/>
        /// </term>
        /// <term>
        /// 6
        /// </term>
        /// <term>
        /// Always returns <see cref="FALSE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OS_WIN2000ORGREATER"/>
        /// </term>
        /// <term>
        /// 7
        /// </term>
        /// <term>
        /// The program is running on Windows 2000 or one of its successors.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OS_WIN2000PRO"/>
        /// </term>
        /// <term>
        /// 8
        /// </term>
        /// <term>
        /// Do not use; use <see cref="OS_PROFESSIONAL"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OS_WIN2000SERVER"/>
        /// </term>
        /// <term>
        /// 9
        /// </term>
        /// <term>
        /// Do not use; use <see cref="OS_SERVER"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OS_WIN2000ADVSERVER"/>
        /// </term>
        /// <term>
        /// 10
        /// </term>
        /// <term>
        /// Do not use; use <see cref="OS_ADVSERVER"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OS_WIN2000DATACENTER"/>
        /// </term>
        /// <term>
        /// 11
        /// </term>
        /// <term>
        /// Do not use; use <see cref="OS_DATACENTER"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OS_WIN2000TERMINAL"/>
        /// </term>
        /// <term>
        /// 12
        /// </term>
        /// <term>
        /// The program is running on Windows 2000 Terminal Server in either Remote Administration mode or Application Server mode,
        /// or Windows Server 2003 (or one of its successors) in Terminal Server mode or Remote Desktop for Administration mode.
        /// Consider using a more specific value such as <see cref="OS_TERMINALSERVER"/>,
        /// <see cref="OS_TERMINALREMOTEADMIN"/>, or <see cref="OS_PERSONALTERMINALSERVER"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OS_EMBEDDED"/>
        /// </term>
        /// <term>
        /// 13
        /// </term>
        /// <term>
        /// The program is running on Windows Embedded, any version.
        /// Equivalent to <see cref="VER_SUITE_EMBEDDEDNT"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OS_TERMINALCLIENT"/>
        /// </term>
        /// <term>
        /// 14
        /// </term>
        /// <term>
        /// The program is running as a Terminal Server client.
        /// Equivalent to <c>GetSystemMetrics(SM_REMOTESESSION)</c>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OS_TERMINALREMOTEADMIN"/>
        /// </term>
        /// <term>
        /// 15
        /// </term>
        /// <term>
        /// The program is running on Windows 2000 Terminal Server in the Remote Administration mode
        /// or Windows Server 2003 (or one of its successors) in the Remote Desktop for Administration mode (these are the default installation modes).
        /// This is equivalent to <c>VER_SUITE_TERMINAL &amp;&amp; VER_SUITE_SINGLEUSERTS</c>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OS_WIN95_GOLD"/>
        /// </term>
        /// <term>
        /// 16
        /// </term>
        /// <term>
        /// Always returns <see cref="FALSE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OS_MEORGREATER"/>
        /// </term>
        /// <term>
        /// 17
        /// </term>
        /// <term>
        /// Always returns <see cref="FALSE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OS_XPORGREATER"/>
        /// </term>
        /// <term>
        /// 18
        /// </term>
        /// <term>
        /// Always returns <see cref="FALSE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OS_HOME"/>
        /// </term>
        /// <term>
        /// 19
        /// </term>
        /// <term>
        /// Always returns <see cref="FALSE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OS_PROFESSIONAL"/>
        /// </term>
        /// <term>
        /// 20
        /// </term>
        /// <term>
        /// The program is running on Windows NT Workstation or Windows 2000 (or one of its successors) Professional.
        /// Equivalent to <c>VER_PLATFORM_WIN32_NT &amp;&amp; VER_NT_WORKSTATION</c>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OS_DATACENTER"/>
        /// </term>
        /// <term>
        /// 21
        /// </term>
        /// <term>
        /// The program is running on Windows Datacenter Server or Windows Server Datacenter Edition, any version.
        /// Equivalent to <c>(VER_NT_SERVER || VER_NT_DOMAIN_CONTROLLER) &amp;&amp; VER_SUITE_DATACENTER</c>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OS_ADVSERVER"/>
        /// </term>
        /// <term>
        /// 22
        /// </term>
        /// <term>
        /// The program is running on Windows Advanced Server or Windows Server Enterprise Edition, any version.
        /// Equivalent to <c> (VER_NT_SERVER || VER_NT_DOMAIN_CONTROLLER) &amp;&amp; VER_SUITE_ENTERPRISE &amp;&amp; !VER_SUITE_DATACENTER</c>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OS_SERVER"/>
        /// </term>
        /// <term>
        /// 23
        /// </term>
        /// <term>
        /// The program is running on Windows Server (Standard) or Windows Server Standard Edition, any version.
        /// This value will not return <see cref="TRUE"/> for <see cref="VER_SUITE_DATACENTER"/>, <see cref="VER_SUITE_ENTERPRISE"/>,
        /// <see cref="VER_SUITE_SMALLBUSINESS"/>, or <see cref="VER_SUITE_SMALLBUSINESS_RESTRICTED"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OS_TERMINALSERVER"/>
        /// </term>
        /// <term>
        /// 24
        /// </term>
        /// <term>
        /// The program is running on Windows 2000 Terminal Server in Application Server mode,
        /// or on Windows Server 2003 (or one of its successors) in Terminal Server mode.
        /// This is equivalent to <see cref="VER_SUITE_TERMINAL"/> &amp;&amp; <see cref="VER_SUITE_SINGLEUSERTS"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OS_PERSONALTERMINALSERVER"/>
        /// </term>
        /// <term>
        /// 25
        /// </term>
        /// <term>
        /// The program is running on Windows XP (or one of its successors), Home Edition or Professional.
        /// This is equivalent to <c>VER_SUITE_TERMINAL &amp;&amp; VER_SUITE_SINGLEUSERTS</c>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OS_FASTUSERSWITCHING"/>
        /// </term>
        /// <term>
        /// 26
        /// </term>
        /// <term>
        /// Fast user switching is enabled.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OS_WELCOMELOGONUI"/>
        /// </term>
        /// <term>
        /// 27
        /// </term>
        /// <term>
        /// Always returns <see cref="FALSE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OS_DOMAINMEMBER"/>
        /// </term>
        /// <term>
        /// 28
        /// </term>
        /// <term>
        /// The computer is joined to a domain.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OS_ANYSERVER"/>
        /// </term>
        /// <term>
        /// 29
        /// </term>
        /// <term>
        /// The program is running on any Windows Server product.
        /// Equivalent to <c>VER_NT_SERVER || VER_NT_DOMAIN_CONTROLLER</c>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OS_WOW6432"/>
        /// </term>
        /// <term>
        /// 30
        /// </term>
        /// <term>
        /// The program is a 32-bit program running on 64-bit Windows.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OS_WEBSERVER"/>
        /// </term>
        /// <term>
        /// 31
        /// </term>
        /// <term>
        /// Always returns <see cref="FALSE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OS_SMALLBUSINESSSERVER"/>
        /// </term>
        /// <term>
        /// 32
        /// </term>
        /// <term>
        /// The program is running on Microsoft Small Business Server with restrictive client license in force.
        /// Equivalent to <see cref="VER_SUITE_SMALLBUSINESS_RESTRICTED"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OS_TABLETPC"/>
        /// </term>
        /// <term>
        /// 33
        /// </term>
        /// <term>
        /// The program is running on Windows XP Tablet PC Edition, or one of its successors.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OS_SERVERADMINUI"/>
        /// </term>
        /// <term>
        /// 34
        /// </term>
        /// <term>
        /// The user should be presented with administrator UI.
        /// It is possible to have server administrative UI on a non-server machine.
        /// This value informs the application that an administrator's profile has roamed to a non-server, and UI should be appropriate to an administrator.
        /// Otherwise, the user is shown a mix of administrator and nonadministrator settings.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OS_MEDIACENTER"/>
        /// </term>
        /// <term>
        /// 35
        /// </term>
        /// <term>
        /// The program is running on Windows XP Media Center Edition, or one of its successors.
        /// Equivalent to <c>GetSystemMetrics(SM_MEDIACENTER)</c>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OS_APPLIANCE"/>
        /// </term>
        /// <term>
        /// 36
        /// </term>
        /// <term>
        /// The program is running on Windows Appliance Server.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// Returns a nonzero value if the specified operating system or operating system feature is detected, otherwise <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Values are not provided for Windows Vista and Windows 7.
        /// To determine whether either of those operating systems are present, use <see cref="VerifyVersionInfo"/>.
        /// </para>
        /// <para>
        /// In Windows versions earlier than Windows Vista, <see cref="IsOS"/> was not exported by name or declared in a public header file.
        /// To use it in those cases, you must use <see cref="GetProcAddress"/> and request ordinal 437 from Shlwapi.dll to obtain a function pointer.
        /// Under Windows Vista, <see cref="IsOS"/> is included in Shlwapi.h and this is not necessary.
        /// </para>
        /// <para>
        /// When referring to server products, "Windows Server" refers only to the Standard Edition server.
        /// If all server products are covered by a particular flag, it is called out explicitly in the table.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("Shlwapi.dll", CharSet = CharSet.Unicode, EntryPoint = "IsOS", ExactSpelling = true)]
        public static extern BOOL IsOS([In] OSFeatures dwOS);

        /// <summary>
        /// <para>
        /// Searches for a file.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shlwapi/nf-shlwapi-pathfindonpathw"/>
        /// </para>
        /// </summary>
        /// <param name="pszPath">
        /// A pointer to a null-terminated string of length <see cref="MAX_PATH"/> that contains the file name for which to search.
        /// If the search is successful, this parameter is used to return the fully qualified path name.
        /// </param>
        /// <param name="ppszOtherDirs">
        /// An optional, null-terminated array of directories to be searched first.
        /// This value can be <see langword="null"/>.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful, or <see cref="FALSE"/> otherwise.
        /// </returns>
        /// <remarks>
        /// <see cref="PathFindOnPath"/> searches for the file specified by <paramref name="pszPath"/>.
        /// If no directories are specified in <paramref name="ppszOtherDirs"/>,
        /// it attempts to find the file by searching standard directories such as System32 and the directories specified in the PATH environment variable.
        /// To expedite the process or enable <see cref="PathFindOnPath"/> to search a wider range of directories,
        /// use the <paramref name="ppszOtherDirs"/> parameter to specify one or more directories to be searched first.
        /// If more than one file has the name specified by <paramref name="pszPath"/>, <see cref="PathFindOnPath"/> returns the first instance it finds.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Shlwapi.dll", CharSet = CharSet.Unicode, EntryPoint = "PathFindOnPathW", ExactSpelling = true)]
        public static extern BOOL PathFindOnPath([In] LPWSTR pszPath, [In] LPCWSTR[] ppszOtherDirs);

        /// <summary>
        /// <para>
        /// Recursively copies the subkeys and values of the source subkey to the destination key.
        /// <see cref="SHCopyKey"/> does not copy the security attributes of the keys.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shlwapi/nf-shlwapi-shcopykeyw"/>
        /// </para>
        /// </summary>
        /// <param name="hkeySrc">
        /// A handle to the source key (for example, <see cref="HKEY_CURRENT_USER"/>).
        /// </param>
        /// <param name="pszSrcSubKey">
        /// The subkey whose subkeys and values are to be copied.
        /// </param>
        /// <param name="hkeyDest">
        /// The destination key.
        /// </param>
        /// <param name="fReserved">
        /// Reserved. Must be 0.
        /// </param>
        /// <returns>
        /// Returns <see cref="ERROR_SUCCESS"/> if successful, or one of the nonzero error codes defined in Winerror.h otherwise.
        /// Use <see cref="FormatMessage"/> with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag to retrieve a generic description of the error.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// This function does not duplicate the security attributes of the keys and values that it copies.
        /// Rather, all security attributes in the destination key are the default attributes.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Shlwapi.dll", CharSet = CharSet.Unicode, EntryPoint = "SHCopyKeyW", ExactSpelling = true)]
        public static extern LSTATUS SHCopyKey([In] HKEY hkeySrc, [In] LPCWSTR pszSrcSubKey, [In] HKEY hkeyDest, [In] DWORD fReserved);

        /// <summary>
        /// <para>
        /// Deletes a subkey and all its descendants.
        /// This function removes the key and all the key's values from the registry.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shlwapi/nf-shlwapi-shdeletekeyw"/>
        /// </para>
        /// </summary>
        /// <param name="hkey">
        /// <para>
        /// A handle to an open registry key, or one of the following predefined keys:
        /// </para>
        /// <para>
        /// <see cref="HKEY_CLASSES_ROOT"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_CONFIG"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_USER"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_LOCAL_MACHINE"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_PERFORMANCE_DATA"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_USERS"/>
        /// </para>
        /// </param>
        /// <param name="pszSubKey">
        /// The address of a null-terminated string specifying the name of the key to delete.
        /// </param>
        /// <returns>
        /// Returns <see cref="ERROR_SUCCESS"/> if successful, or one of the nonzero error codes defined in Winerror.h otherwise.
        /// Use <see cref="FormatMessage"/> with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag to retrieve a generic description of the error.
        /// </returns>
        /// <remarks>
        /// Alternatively, use the <see cref="RegDeleteKey"/> or <see cref="RegDeleteTree"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Shlwapi.dll", CharSet = CharSet.Unicode, EntryPoint = "SHDeleteKeyW", ExactSpelling = true)]
        public static extern LSTATUS SHDeleteKey([In] HKEY hkey, [In] LPCWSTR pszSubKey);
    }
}
