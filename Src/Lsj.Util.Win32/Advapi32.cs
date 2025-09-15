using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.FileAccessRights;
using static Lsj.Util.Win32.Enums.Logon32Providers;
using static Lsj.Util.Win32.Enums.LogonTypes;
using static Lsj.Util.Win32.Enums.PrivilegeConstants;
using static Lsj.Util.Win32.Enums.ProcessAccessRights;
using static Lsj.Util.Win32.Enums.SECURITY_DESCRIPTOR_CONTROL;
using static Lsj.Util.Win32.Enums.SECURITY_IMPERSONATION_LEVEL;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.ThreadAccessRights;
using static Lsj.Util.Win32.Enums.TokenAccessRights;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Advapi32.dll
    /// </summary>
    public static partial class Advapi32
    {
        /// <summary>
        /// <para>
        /// Stops a system shutdown that has been initiated.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-abortsystemshutdownw"/>
        /// </para>
        /// </summary>
        /// <param name="lpMachineName">
        /// The network name of the computer where the shutdown is to be stopped.
        /// If <paramref name="lpMachineName"/> is <see cref="NULL"/> or an empty string, the function stops the shutdown on the local computer.
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
        /// The <see cref="InitiateSystemShutdown"/> and <see cref="InitiateSystemShutdownEx"/> functions
        /// display a dialog box that notifies the user that the system is shutting down.
        /// During the shutdown time-out period, the <see cref="AbortSystemShutdown"/> function can prevent the system from shutting down.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP with SP1
        /// If the computer to be shut down is a Terminal Services server,
        /// the system displays a dialog box to all local and remote users warning them that shutdown has been initiated.
        /// If shutdown is prevented by <see cref="AbortSystemShutdown"/>,
        /// the system displays dialog box to the users informing them that the server is no longer shutting down.
        /// </para>
        /// <para>
        /// To stop the local computer from shutting down,
        /// the calling process must have the <see cref="SE_SHUTDOWN_NAME"/> privilege.
        /// To stop a remote computer from shutting down,
        /// the calling process must have the <see cref="SE_REMOTE_SHUTDOWN_NAME"/> privilege on the remote computer.
        /// By default, users can enable the <see cref="SE_SHUTDOWN_NAME"/> privilege on the computer they are logged onto,
        /// and administrators can enable the <see cref="SE_REMOTE_SHUTDOWN_NAME"/> privilege on remote computers.
        /// For more information, see Running with Special Privileges.
        /// </para>
        /// <para>
        /// Common reasons for failure include an invalid computer name, an inaccessible computer, or insufficient privilege.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AbortSystemShutdownW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AbortSystemShutdown([In] LPWSTR lpMachineName);

        /// <summary>
        /// <para>
        /// Decrypts an encrypted file or directory.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-decryptfilew"/>
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// <para>
        /// The name of the file or directory to be decrypted.
        /// </para>
        /// <para>
        /// The caller must have the <see cref="FILE_READ_DATA"/>, <see cref="FILE_WRITE_DATA"/>,
        /// <see cref="FILE_READ_ATTRIBUTES"/>, <see cref="FILE_WRITE_ATTRIBUTES"/>, and <see cref="SYNCHRONIZE"/> access rights.
        /// For more information, see File Security and Access Rights.
        /// </para>
        /// </param>
        /// <param name="dwReserved">
        /// Reserved; must be zero.
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
        /// The <see cref="DecryptFile"/> function requires exclusive access to the file being decrypted,
        /// and will fail if another process is using the file.
        /// If the file is not encrypted, <see cref="DecryptFile"/> simply returns a nonzero value, which indicates success.
        /// </para>
        /// <para>
        /// If <paramref name="lpFileName"/> specifies a read-only file,
        /// the function fails and <see cref="GetLastError"/> returns <see cref="ERROR_FILE_READ_ONLY"/>.
        /// If <paramref name="lpFileName"/> specifies a directory that contains a read-only file,
        /// the functions succeeds but the directory is not decrypted.
        /// </para>
        /// <para>
        /// In Windows 8, Windows Server 2012, and later, this function is supported by the following technologies. 
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Technology
        /// </term>
        /// <term>
        /// Supported
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Server Message Block (SMB) 3.0 protocol
        /// </term>
        /// <term>
        /// Yes
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// SMB 3.0 Transparent Failover (TFO)
        /// </term>
        /// <term>
        /// No
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// SMB 3.0 with Scale-out File Shares (SO)
        /// </term>
        /// <term>
        /// No
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Cluster Shared Volume File System (CsvFS)
        /// </term>
        /// <term>
        /// No
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Resilient File System (ReFS)
        /// </term>
        /// <term>
        /// No
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// SMB 3.0 does not support EFS on shares with continuous availability capability.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "DecryptFileW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DecryptFile([In] LPCWSTR lpFileName, [In] DWORD dwReserved);

        /// <summary>
        /// <para>
        /// Encrypts a file or directory.
        /// All data streams in a file are encrypted.
        /// All new files created in an encrypted directory are encrypted.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-encryptfilew"/>
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// <para>
        /// The name of the file or directory to be encrypted.
        /// </para>
        /// <para>
        /// The caller must have the <see cref="FILE_READ_DATA"/>, <see cref="FILE_WRITE_DATA"/>,
        /// <see cref="FILE_READ_ATTRIBUTES"/>, <see cref="FILE_WRITE_ATTRIBUTES"/>, and <see cref="SYNCHRONIZE"/> access rights.
        /// For more information, see File Security and Access Rights.
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
        /// The <see cref="EncryptFile"/> function requires exclusive access to the file being encrypted, and will fail if another process is using the file.
        /// </para>
        /// <para>
        /// If the file is already encrypted, <see cref="EncryptFile"/> simply returns a nonzero value, which indicates success.
        /// If the file is compressed, <see cref="EncryptFile"/> will decompress the file before encrypting it.
        /// </para>
        /// <para>
        /// If <paramref name="lpFileName"/> specifies a read-only file,
        /// the function fails and <see cref="GetLastError"/> returns <see cref="ERROR_FILE_READ_ONLY"/>.
        /// If <paramref name="lpFileName"/> specifies a directory that contains a read-only file,
        /// the functions succeeds but the directory is not encrypted.
        /// </para>
        /// <para>
        /// To decrypt an encrypted file, use the <see cref="DecryptFile"/> function.
        /// </para>
        /// <para>
        /// In Windows 8, Windows Server 2012, and later, this function is supported by the following technologies. 
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Technology
        /// </term>
        /// <term>
        /// Supported
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Server Message Block (SMB) 3.0 protocol
        /// </term>
        /// <term>
        /// Yes
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// SMB 3.0 Transparent Failover (TFO)
        /// </term>
        /// <term>
        /// No
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// SMB 3.0 with Scale-out File Shares (SO)
        /// </term>
        /// <term>
        /// No
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Cluster Shared Volume File System (CsvFS)
        /// </term>
        /// <term>
        /// No
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Resilient File System (ReFS)
        /// </term>
        /// <term>
        /// No
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// SMB 3.0 does not support EFS on shares with continuous availability capability.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "EncryptFileW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EncryptFile([In] LPCWSTR lpFileName);

        /// <summary>
        /// <para>
        /// Enumerates <see cref="DYNAMIC_TIME_ZONE_INFORMATION"/> entries stored in the registry.
        /// This information is used to support time zones that experience annual boundary changes due to daylight saving time adjustments.
        /// Use the information returned by this function when calling <see cref="GetDynamicTimeZoneInformationEffectiveYears"/>
        /// to retrieve the specific range of years to pass to <see cref="GetTimeZoneInformationForYear"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/timezoneapi/nf-timezoneapi-enumdynamictimezoneinformation"/>
        /// </para>
        /// </summary>
        /// <param name="dwIndex">
        /// Index value that represents the location of a <see cref="DYNAMIC_TIME_ZONE_INFORMATION"/> entry.
        /// </param>
        /// <param name="lpTimeZoneInformation">
        /// Specifies settings for a time zone and dynamic daylight saving time.
        /// </param>
        /// <returns>
        /// <para>
        /// This function returns <see cref="DWORD"/>. Possible return values include:
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_SUCCESS"/>
        /// </term>
        /// <term>
        /// The operation succeeded.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_NO_MORE_ITEMS"/>
        /// </term>
        /// <term>
        /// No more data is available for the given index.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_PARAMETER"/>
        /// </term>
        /// <term>
        /// A parameter is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Any other value
        /// </term>
        /// <term>
        /// The operation failed.
        /// </term>
        /// </item>
        /// </list>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The following example demonstrates looping through the potential timezones until <see cref="ERROR_NO_MORE_ITEMS"/> is returned,
        /// indicating that there are no more time zone entries in the registry.
        /// </para>
        /// <code>
        /// std::vector&lt;DYNAMIC_TIME_ZONE_INFORMATION&gt; possibleTimezones;
        /// DYNAMIC_TIME_ZONE_INFORMATION dynamicTimezone = {};
        /// DWORD dwResult = 0;
        /// DWORD i = 0;
        /// 
        /// do
        /// {
        ///     dwResult = EnumDynamicTimeZoneInformation(i++, &amp;dynamicTimezone);
        ///     if (dwResult == ERROR_SUCCESS)
        ///     {
        ///         possibleTimezones.push_back(dynamicTimezone);
        ///     }
        /// }
        /// while (dwResult != ERROR_NO_MORE_ITEMS);
        /// </code>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumDynamicTimeZoneInformation", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD EnumDynamicTimeZoneInformation([In] DWORD dwIndex, [Out] out DYNAMIC_TIME_ZONE_INFORMATION lpTimeZoneInformation);

        /// <summary>
        /// <para>
        /// The <see cref="ImpersonateLoggedOnUser"/> function lets the calling thread impersonate the security context of a logged-on user.
        /// The user is represented by a token handle.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-impersonateloggedonuser"/>
        /// </para>
        /// </summary>
        /// <param name="hToken">
        /// A handle to a primary or impersonation access token that represents a logged-on user.
        /// This can be a token handle returned by a call to <see cref="LogonUser"/>, <see cref="CreateRestrictedToken"/>,
        /// <see cref="DuplicateToken"/>, <see cref="DuplicateTokenEx"/>, <see cref="OpenProcessToken"/>, or <see cref="OpenThreadToken"/> functions.
        /// If <paramref name="hToken"/> is a handle to a primary token, the token must
        /// have <see cref="TOKEN_QUERY"/> and <see cref="TOKEN_DUPLICATE"/> access.
        /// If <paramref name="hToken"/> is a handle to an impersonation token,
        /// the token must have <see cref="TOKEN_QUERY"/> and <see cref="TOKEN_IMPERSONATE"/> access.
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
        /// The impersonation lasts until the thread exits or until it calls <see cref="RevertToSelf"/>.
        /// </para>
        /// <para>
        /// The calling thread does not need to have any particular privileges to call <see cref="ImpersonateLoggedOnUser"/>.
        /// </para>
        /// <para>
        /// If the call to <see cref="ImpersonateLoggedOnUser"/> fails, the client connection is not impersonated
        /// and the client request is made in the security context of the process.
        /// If the process is running as a highly privileged account, such as LocalSystem, or as a member of an administrative group,
        /// the user may be able to perform actions they would otherwise be disallowed.
        /// Therefore, it is important to always check the return value of the call,
        /// and if it fails, raise an error; do not continue execution of the client request.
        /// </para>
        /// <para>
        /// All impersonate functions, including <see cref="ImpersonateLoggedOnUser"/> allow the requested impersonation if one of the following is true:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The requested impersonation level of the token is less than <see cref="SecurityImpersonation"/>,
        /// such as <see cref="SecurityIdentification"/> or <see cref="SecurityAnonymous"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The caller has the SeImpersonatePrivilege privilege.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A process (or another process in the caller's logon session) created the token using explicit credentials through <see cref="LogonUser"/> or <see cref="LsaLogonUser"/> function.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The authenticated identity is same as the caller.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Windows XP with SP1 and earlier:
        /// The SeImpersonatePrivilege privilege is not supported.
        /// </para>
        /// <para>
        /// For more information about impersonation, see Client Impersonation.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ImpersonateLoggedOnUser", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ImpersonateLoggedOnUser([In] HANDLE hToken);

        /// <summary>
        /// <para>
        /// The <see cref="ImpersonateNamedPipeClient"/> function impersonates a named-pipe client application.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/namedpipeapi/nf-namedpipeapi-impersonatenamedpipeclient"/>
        /// </para>
        /// </summary>
        /// <param name="hNamedPipe">
        /// A handle to a named pipe.
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
        /// The <see cref="ImpersonateNamedPipeClient"/> function allows the server end of a named pipe to impersonate the client end.
        /// When this function is called, the named-pipe file system changes the thread of the calling process
        /// to start impersonating the security context of the last message read from the pipe.
        /// Only the server end of the pipe can call this function.
        /// </para>
        /// <para>
        /// The server can call the <see cref="RevertToSelf"/> function when the impersonation is complete.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// If the <see cref="ImpersonateNamedPipeClient"/> function fails, the client is not impersonated,
        /// and all subsequent client requests are made in the security context of the process that called the function.
        /// If the calling process is running as a privileged account,
        /// it can perform actions that the client would not be allowed to perform.
        /// To avoid security risks, the calling process should always check the return value.
        /// If the return value indicates that the function call failed, no client requests should be executed.
        /// All impersonate functions, including <see cref="ImpersonateNamedPipeClient"/> allow the requested impersonation if one of the following is true:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The requested impersonation level of the token is less than <see cref="SecurityImpersonation"/>,
        /// such as <see cref="SecurityIdentification"/> or <see cref="SecurityAnonymous"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The caller has the SeImpersonatePrivilege privilege.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A process (or another process in the caller's logon session) created the token
        /// using explicit credentials through <see cref="LogonUser"/> or <see cref="LsaLogonUser"/> function.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The authenticated identity is same as the caller.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Windows XP with SP1 and earlier:
        /// The SeImpersonatePrivilege privilege is not supported.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ImpersonateNamedPipeClient", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ImpersonateNamedPipeClient([In] HANDLE hNamedPipe);

        /// <summary>
        /// <para>
        /// The <see cref="ImpersonateSelf"/> function obtains an access token that impersonates the security context of the calling process.
        /// The token is assigned to the calling thread.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-impersonateself"/>
        /// </para>
        /// </summary>
        /// <param name="ImpersonationLevel">
        /// Specifies a <see cref="SECURITY_IMPERSONATION_LEVEL"/> enumerated type that supplies the impersonation level of the new token.
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
        /// The <see cref="ImpersonateSelf"/> function is used for tasks such as enabling a privilege for a single thread
        /// rather than for the entire process or for changing the default discretionary access control list (DACL) for a single thread.
        /// </para>
        /// <para>
        /// The server can call the <see cref="RevertToSelf"/> function when the impersonation is complete.
        /// </para>
        /// <para>
        /// For this function to succeed, the DACL protecting the process token must grant the <see cref="TOKEN_DUPLICATE"/> right to itself.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ImpersonateSelf", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ImpersonateSelf([In] SECURITY_IMPERSONATION_LEVEL ImpersonationLevel);

        /// <summary>
        /// <para>
        /// Initiates a shutdown and optional restart of the specified computer.
        /// </para>
        /// <para>
        /// To record a reason for the shutdown in the event log, call the <see cref="InitiateSystemShutdownEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-initiatesystemshutdownw"/>
        /// </para>
        /// </summary>
        /// <param name="lpMachineName">
        /// The network name of the computer to be shut down.
        /// If <paramref name="lpMachineName"/> is <see cref="NULL"/> or an empty string, the function shuts down the local computer.
        /// </param>
        /// <param name="lpMessage">
        /// <para>
        /// The message to be displayed in the shutdown dialog box.
        /// This parameter can be <see cref="NULL"/> if no message is required.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:
        /// This string is also stored as a comment in the event log entry.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP with SP1:
        /// The string is limited to 3072 TCHARs.
        /// </para>
        /// </param>
        /// <param name="dwTimeout">
        /// <para>
        /// The length of time that the shutdown dialog box should be displayed, in seconds.
        /// While this dialog box is displayed, the shutdown can be stopped by the <see cref="AbortSystemShutdown"/> function.
        /// </para>
        /// <para>
        /// If <paramref name="dwTimeout"/> is not zero, <see cref="InitiateSystemShutdown"/> displays a dialog box on the specified computer.
        /// The dialog box displays the name of the user who called the function,
        /// displays the message specified by the <paramref name="lpMessage"/> parameter, and prompts the user to log off.
        /// The dialog box beeps when it is created and remains on top of other windows in the system.
        /// The dialog box can be moved but not closed.
        /// A timer counts down the remaining time before a forced shutdown.
        /// </para>
        /// <para>
        /// If <paramref name="dwTimeout"/> is zero, the computer shuts down without displaying the dialog box,
        /// and the shutdown cannot be stopped by <see cref="AbortSystemShutdown"/>.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP with SP1:
        /// The time-out value is limited to <see cref="MAX_SHUTDOWN_TIMEOUT"/> seconds.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP with SP1:
        /// If the computer to be shut down is a Terminal Services server, the system displays a dialog box
        /// to all local and remote users warning them that shutdown has been initiated.
        /// The dialog box includes who requested the shutdown, the display message (see <paramref name="lpMessage"/>),
        /// and how much time there is until the server is shut down.
        /// </para>
        /// </param>
        /// <param name="bForceAppsClosed">
        /// <para>
        /// If this parameter is <see cref="TRUE"/>, applications with unsaved changes are to be forcibly closed.
        /// Note that this can result in data loss.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="FALSE"/>, the system displays a dialog box instructing the user to close the applications.
        /// </para>
        /// </param>
        /// <param name="bRebootAfterShutdown">
        /// If this parameter is <see cref="TRUE"/>, the computer is to restart immediately after shutting down.
        /// If this parameter is <see cref="FALSE"/>, the system flushes all caches to disk and safely powers down the system.
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
        /// To shut down the local computer,
        /// the calling thread must have the <see cref="SE_SHUTDOWN_NAME"/> privilege.
        /// To shut down a remote computer,
        /// the calling thread must have the <see cref="SE_REMOTE_SHUTDOWN_NAME"/> privilege on the remote computer.
        /// By default, users can enable the <see cref="SE_SHUTDOWN_NAME"/> privilege on the computer they are logged onto,
        /// and administrators can enable the <see cref="SE_REMOTE_SHUTDOWN_NAME"/> privilege on remote computers.
        /// For more information, see Running with Special Privileges.
        /// </para>
        /// <para>
        /// Common reasons for failure include an invalid or inaccessible computer name or insufficient privilege.
        /// The error <see cref="ERROR_SHUTDOWN_IN_PROGRESS"/> is returned if a shutdown is already in progress on the specified computer.
        /// The error <see cref="ERROR_NOT_READY"/> can be returned if fast-user switching is enabled but no user is logged on.
        /// </para>
        /// <para>
        /// A non-zero return value does not mean the logoff was or will be successful.
        /// The shutdown is an asynchronous process, and it can occur long after the API call has returned, or not at all.
        /// Even if the timeout value is zero, the shutdown can still be aborted by applications, services or even the system.
        /// The non-zero return value indicates that the validation of the rights and parameters was successful
        /// and that the system accepted the shutdown request.
        /// </para>
        /// <para>
        /// When this function is called, the caller must specify whether or not applications with unsaved changes should be forcibly closed.
        /// If the caller chooses not to force these applications closed,
        /// and an application with unsaved changes is running on the console session,
        /// the shutdown will remain in progress until the user logged into the console session
        /// aborts the shutdown, saves changes, closes the application, or forces the application to close.
        /// During this period, the shutdown may not be aborted except by the console user, and another shutdown may not be initiated.
        /// </para>
        /// <para>
        /// Note that calling this function with the value of the <paramref name="bForceAppsClosed"/> parameter
        /// set to <see cref="TRUE"/> avoids this situation.
        /// Remember that doing this may result in loss of data.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:
        /// If the computer is locked and the <paramref name="bForceAppsClosed"/> parameter is <see cref="FALSE"/>,
        /// the last error code is <see cref="ERROR_MACHINE_LOCKED"/>.
        /// If the system is not ready to handle the request, the last error code is <see cref="ERROR_NOT_READY"/>.
        /// The application should wait a short while and retry the call.
        /// For example, the system can be unready to initiate a shutdown, and return <see cref="ERROR_NOT_READY"/>,
        /// if the shutdown request comes at the same time a user tries to log onto the system.
        /// In this case, the application should wait a short while and retry the call.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitiateSystemShutdownW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL InitiateSystemShutdown([In] LPWSTR lpMachineName, [In] LPWSTR lpMessage, [In] DWORD dwTimeout,
            [In] BOOL bForceAppsClosed, [In] BOOL bRebootAfterShutdown);

        /// <summary>
        /// <para>
        /// Initiates a shutdown and optional restart of the specified computer, and optionally records the reason for the shutdown.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-initiatesystemshutdownexw"/>
        /// </para>
        /// </summary>
        /// <param name="lpMachineName">
        /// The network name of the computer to be shut down.
        /// If <paramref name="lpMachineName"/> is <see cref="NULL"/> or an empty string, the function shuts down the local computer.
        /// </param>
        /// <param name="lpMessage">
        /// <para>
        /// The message to be displayed in the shutdown dialog box.
        /// This parameter can be <see cref="NULL"/> if no message is required.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:
        /// This string is also stored as a comment in the event log entry.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP with SP1:
        /// The string is limited to 3072 TCHARs.
        /// </para>
        /// </param>
        /// <param name="dwTimeout">
        /// <para>
        /// The length of time that the shutdown dialog box should be displayed, in seconds.
        /// While this dialog box is displayed, shutdown can be stopped by the <see cref="AbortSystemShutdown"/> function.
        /// </para>
        /// <para>
        /// If <paramref name="dwTimeout"/> is not zero,
        /// <see cref="InitiateSystemShutdownEx"/> displays a dialog box on the specified computer.
        /// The dialog box displays the name of the user who called the function,
        /// displays the message specified by the <paramref name="lpMessage"/> parameter, and prompts the user to log off.
        /// The dialog box beeps when it is created and remains on top of other windows in the system.
        /// The dialog box can be moved but not closed.
        /// A timer counts down the remaining time before shutdown.
        /// </para>
        /// <para>
        /// If <paramref name="dwTimeout"/> is zero, the computer shuts down without displaying the dialog box,
        /// and the shutdown cannot be stopped by <see cref="AbortSystemShutdown"/>.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP with SP1:
        /// The time-out value is limited to <see cref="MAX_SHUTDOWN_TIMEOUT"/> seconds.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP with SP1:
        /// If the computer to be shut down is a Terminal Services server, the system displays a dialog box
        /// to all local and remote users warning them that shutdown has been initiated.
        /// The dialog box includes who requested the shutdown, the display message (see <paramref name="lpMessage"/>),
        /// and how much time there is until the server is shut down.
        /// </para>
        /// </param>
        /// <param name="bForceAppsClosed">
        /// If this parameter is <see cref="TRUE"/>, applications with unsaved changes are to be forcibly closed.
        /// If this parameter is <see cref="FALSE"/>, the system displays a dialog box instructing the user to close the applications.
        /// </param>
        /// <param name="bRebootAfterShutdown">
        /// If this parameter is <see cref="TRUE"/>, the computer is to restart immediately after shutting down.
        /// If this parameter is <see cref="FALSE"/>, the system flushes all caches to disk and safely powers down the system.
        /// </param>
        /// <param name="dwReason">
        /// <para>
        /// The reason for initiating the shutdown. This parameter must be one of the system shutdown reason codes.
        /// </para>
        /// <para>
        /// If this parameter is zero, the default is an undefined shutdown that is logged as "No title for this reason could be found".
        /// By default, it is also an unplanned shutdown.
        /// Depending on how the system is configured, an unplanned shutdown triggers the creation of a file
        /// that contains the system state information, which can delay shutdown.
        /// Therefore, do not use zero for this parameter.
        /// </para>
        /// <para>
        /// Windows XP:
        /// System state information is not saved during an unplanned system shutdown.
        /// The preceding text does not apply.
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
        /// To shut down the local computer, the calling thread must have the <see cref="SE_SHUTDOWN_NAME"/> privilege.
        /// To shut down a remote computer, the calling thread must have the <see cref="SE_REMOTE_SHUTDOWN_NAME"/> privilege on the remote computer.
        /// By default, users can enable the <see cref="SE_SHUTDOWN_NAME"/> privilege on the computer they are logged onto,
        /// and administrators can enable the <see cref="SE_REMOTE_SHUTDOWN_NAME"/> privilege on remote computers.
        /// For more information, see Running with Special Privileges.
        /// </para>
        /// <para>
        /// Common reasons for failure include an invalid or inaccessible computer name or insufficient privilege.
        /// The error <see cref="ERROR_SHUTDOWN_IN_PROGRESS"/> is returned if a shutdown is already in progress on the specified computer.
        /// The error <see cref="ERROR_NOT_READY"/> can be returned if fast-user switching is enabled but no user is logged on.
        /// </para>
        /// <para>
        /// A non-zero return value does not mean the logoff was or will be successful.
        /// The shutdown is an asynchronous process, and it can occur long after the API call has returned, or not at all.
        /// Even if the timeout value is zero, the shutdown can still be aborted by applications, services, or even the system.
        /// The non-zero return value indicates that the validation of the rights and parameters was successful
        /// and that the system accepted the shutdown request.
        /// </para>
        /// <para>
        /// When this function is called, the caller must specify
        /// whether or not applications with unsaved changes should be forcibly closed.
        /// If the caller chooses not to force these applications to close and an application
        /// with unsaved changes is running on the console session, the shutdown will remain in progress
        /// until the user logged into the console session aborts the shutdown, saves changes,
        /// closes the application, or forces the application to close.
        /// During this period the shutdown may not be aborted except by the console user, and another shutdown may not be initiated.
        /// </para>
        /// <para>
        /// Note that calling this function with the value of the <paramref name="bForceAppsClosed"/> parameter
        /// set to <see cref="TRUE"/> avoids this situation.
        /// Remember that doing this may result in loss of data.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:
        /// If the computer is locked and the <paramref name="bForceAppsClosed"/> parameter is <see cref="FALSE"/>,
        /// the last error code is <see cref="ERROR_MACHINE_LOCKED"/>.
        /// If the system is not ready to handle the request, the last error code is <see cref="ERROR_NOT_READY"/>.
        /// The application should wait a short while and retry the call.
        /// For example, the system can be unready to initiate a shutdown, and return <see cref="ERROR_NOT_READY"/>,
        /// if the shutdown request comes at the same time a user tries to log onto the system.
        /// In this case, the application should wait a short while and retry the call.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitiateSystemShutdownExW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL InitiateSystemShutdownEx([In] LPWSTR lpMachineName, [In] LPWSTR lpMessage, [In] DWORD dwTimeout,
            [In] BOOL bForceAppsClosed, [In] BOOL bRebootAfterShutdown, [In] SystemShutdownReasonCodes dwReason);

        /// <summary>
        /// <para>
        /// The <see cref="LogonUser"/> function attempts to log a user on to the local computer.
        /// The local computer is the computer from which LogonUser was called.
        /// You cannot use <see cref="LogonUser"/> to log on to a remote computer.
        /// You specify the user with a user name and domain and authenticate the user with a plaintext password.
        /// If the function succeeds, you receive a handle to a token that represents the logged-on user.
        /// You can then use this token handle to impersonate the specified user or, in most cases,
        /// to create a process that runs in the context of the specified user.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-logonuserw"/>
        /// </para>
        /// </summary>
        /// <param name="lpszUsername">
        /// A pointer to a null-terminated string that specifies the name of the user.
        /// This is the name of the user account to log on to.
        /// If you use the user principal name (UPN) format, User@DNSDomainName, the <paramref name="lpszDomain"/> parameter must be <see langword="null"/>.
        /// </param>
        /// <param name="lpszDomain">
        /// A pointer to a null-terminated string that specifies the name of the domain or server
        /// whose account database contains the <paramref name="lpszUsername"/> account.
        /// If this parameter is <see cref="NULL"/>, the user name must be specified in UPN format.
        /// If this parameter is ".", the function validates the account by using only the local account database.
        /// </param>
        /// <param name="lpszPassword">
        /// A pointer to a null-terminated string that specifies the plaintext password for the user account specified by <paramref name="lpszUsername"/>.
        /// When you have finished using the password, clear the password from memory by calling the <see cref="SecureZeroMemory"/> function.
        /// For more information about protecting passwords, see Handling Passwords.
        /// </param>
        /// <param name="dwLogonType">
        /// <para>
        /// The type of logon operation to perform.
        /// This parameter can be one of the following values, defined in Winbase.h.
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
        /// <see cref="LOGON32_LOGON_BATCH"/>
        /// </term>
        /// <term>
        /// This logon type is intended for batch servers, where processes may be executing on behalf of a user without their direct intervention.
        /// This type is also for higher performance servers that process many plaintext authentication attempts at a time, such as mail or web servers.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LOGON32_LOGON_INTERACTIVE"/>
        /// </term>
        /// <term>
        /// This logon type is intended for users who will be interactively using the computer,
        /// such as a user being logged on by a terminal server, remote shell, or similar process.
        /// This logon type has the additional expense of caching logon information for disconnected operations;
        /// therefore, it is inappropriate for some client/server applications, such as a mail server.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LOGON32_LOGON_NETWORK"/>
        /// </term>
        /// <term>
        /// This logon type is intended for high performance servers to authenticate plaintext passwords.
        /// The <see cref="LogonUser"/> function does not cache credentials for this logon type.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LOGON32_LOGON_NETWORK_CLEARTEXT"/>
        /// </term>
        /// <term>
        /// This logon type preserves the name and password in the authentication package,
        /// which allows the server to make connections to other network servers while impersonating the client.
        /// A server can accept plaintext credentials from a client, call <see cref="LogonUser"/>, 
        /// verify that the user can access the system across the network, and still communicate with other servers.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LOGON32_LOGON_NEW_CREDENTIALS"/>
        /// </term>
        /// <term>
        /// <para>
        /// This logon type allows the caller to clone its current token and specify new credentials for outbound connections.
        /// The new logon session has the same local identifier but uses different credentials for other network connections.
        /// </para>
        /// <para>
        /// This logon type is supported only by the <see cref="LOGON32_PROVIDER_WINNT50"/> logon provider.
        /// </para>
        /// <para>
        /// Note: As of January 2023, it is not possible
        /// to use the <see cref="LOGON32_LOGON_NEW_CREDENTIALS"/> logon type with a Group Managed Service Account (gMSA).
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LOGON32_LOGON_SERVICE"/>
        /// </term>
        /// <term>
        /// Indicates a service-type logon.
        /// The account provided must have the service privilege enabled.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LOGON32_LOGON_UNLOCK"/>
        /// </term>
        /// <term>
        /// <para>
        /// GINAs are no longer supported.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:
        /// This logon type is for GINA DLLs that log on users who will be interactively using the computer.
        /// This logon type can generate a unique audit record that shows when the workstation was unlocked.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="dwLogonProvider">
        /// <para>
        /// Specifies the logon provider. This parameter can be one of the following values.
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
        /// <see cref="LOGON32_PROVIDER_DEFAULT"/>
        /// </term>
        /// <term>
        /// Use the standard logon provider for the system.
        /// The default security provider is negotiate,
        /// unless you pass <see cref="NULL"/> for the domain name and the user name is not in UPN format.
        /// In this case, the default provider is NTLM.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LOGON32_PROVIDER_WINNT50"/>
        /// </term>
        /// <term>
        /// Use the negotiate logon provider.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LOGON32_PROVIDER_WINNT40"/>
        /// </term>
        /// <term>
        /// Use the NTLM logon provider.
        /// </term>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="phToken">
        /// <para>
        /// A pointer to a handle variable that receives a handle to a token that represents the specified user.
        /// </para>
        /// <para>
        /// You can use the returned handle in calls to the <see cref="ImpersonateLoggedOnUser"/> function.
        /// </para>
        /// <para>
        /// In most cases, the returned handle is a primary token that you can use in calls to the <see cref="CreateProcessAsUser"/> function.
        /// However, if you specify the <see cref="LOGON32_LOGON_NETWORK"/> flag,
        /// <see cref="LogonUser"/> returns an impersonation token that you cannot use in <see cref="CreateProcessAsUser"/>
        /// unless you call <see cref="DuplicateTokenEx"/> to convert it to a primary token.
        /// </para>
        /// <para>
        /// When you no longer need this handle, close it by calling the <see cref="CloseHandle"/> function.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the function returns nonzero.
        /// </para>
        /// <para>
        /// If the function fails, it returns zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="LOGON32_LOGON_NETWORK"/> logon type is fastest, but it has the following limitations:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The function returns an impersonation token, not a primary token.
        /// You cannot use this token directly in the <see cref="CreateProcessAsUser"/> function.
        /// However, you can call the <see cref="DuplicateTokenEx"/> function to convert the token to a primary token,
        /// and then use it in <see cref="CreateProcessAsUser"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If you convert the token to a primary token and use it in <see cref="CreateProcessAsUser"/> to start a process,
        /// the new process cannot access other network resources, such as remote servers or printers, through the redirector.
        /// An exception is that if the network resource is not access controlled, then the new process will be able to access it.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The <see cref="SE_TCB_NAME"/> privilege is not required for this function unless you are logging onto a Passport account.
        /// </para>
        /// <para>
        /// The account specified by <paramref name="lpszUsername"/>, must have the necessary account rights.
        /// For example, to log on a user with the <see cref="LOGON32_LOGON_INTERACTIVE"/> flag,
        /// the user (or a group to which the user belongs) must have the <see cref="SE_INTERACTIVE_LOGON_NAME"/> account right.
        /// For a list of the account rights that affect the various logon operations, see Account Rights Constants.
        /// </para>
        /// <para>
        /// A user is considered logged on if at least one token exists.
        /// If you call <see cref="CreateProcessAsUser"/> and then close the token,
        /// the system considers the user as still logged on until the process (and all child processes) have ended.
        /// </para>
        /// <para>
        /// If the <see cref="LogonUser"/> call is successful, the system notifies network providers that the logon occurred
        /// by calling the provider's NPLogonNotify entry-point function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "LogonUserW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL LogonUser([In] LPCWSTR lpszUsername, [In] LPCWSTR lpszDomain, [In] LPCWSTR lpszPassword,
            [In] LogonTypes dwLogonType, [In] Logon32Providers dwLogonProvider, [Out] out HANDLE phToken);

        /// <summary>
        /// <para>
        /// The <see cref="LookupPrivilegeName"/> function retrieves the name that corresponds to the privilege
        /// represented on a specific system by a specified locally unique identifier (LUID).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-lookupprivilegenamew"/>
        /// </para>
        /// </summary>
        /// <param name="lpSystemName">
        /// A pointer to a null-terminated string that specifies the name of the system on which the privilege name is retrieved.
        /// If a null string is specified, the function attempts to find the privilege name on the local system.
        /// </param>
        /// <param name="lpLuid">
        /// A pointer to the LUID by which the privilege is known on the target system.
        /// </param>
        /// <param name="lpName">
        /// A pointer to a buffer that receives a null-terminated string that represents the privilege name.
        /// For example, this string could be "SeSecurityPrivilege".
        /// </param>
        /// <param name="cchName">
        /// A pointer to a variable that specifies the size, in a TCHAR value, of the <paramref name="lpName"/> buffer.
        /// When the function returns, this parameter contains the length of the privilege name, not including the terminating null character.
        /// If the buffer pointed to by the <paramref name="lpName"/> parameter is too small, this variable contains the required size.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the function returns nonzero.
        /// </para>
        /// <para>
        /// If the function fails, it returns zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="LookupPrivilegeName"/> function supports only the privileges specified in the Defined Privileges section of Winnt.h.
        /// For a list of values, see Privilege Constants.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "LookupPrivilegeNameW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL LookupPrivilegeName([In] LPCWSTR lpSystemName, [In] in LUID lpLuid, [In] LPWSTR lpName, [In][Out] ref DWORD cchName);

        /// <summary>
        /// <para>
        /// The <see cref="LookupPrivilegeValue"/> function retrieves the locally unique identifier (LUID)
        /// used on a specified system to locally represent the specified privilege name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-lookupprivilegevaluew"/>
        /// </para>
        /// </summary>
        /// <param name="lpSystemName">
        /// A pointer to a null-terminated string that specifies the name of the system on which the privilege name is retrieved.
        /// If a null string is specified, the function attempts to find the privilege name on the local system.
        /// </param>
        /// <param name="lpName">
        /// A pointer to a null-terminated string that specifies the name of the privilege, as defined in the Winnt.h header file.
        /// For example, this parameter could specify the constant, <see cref="SE_SECURITY_NAME"/>, or its corresponding string, "SeSecurityPrivilege".
        /// </param>
        /// <param name="lpLuid">
        /// A pointer to a variable that receives the LUID by which the privilege is known on the system
        /// specified by the <paramref name="lpSystemName"/> parameter.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the function returns nonzero.
        /// </para>
        /// <para>
        /// If the function fails, it returns zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="LookupPrivilegeValue"/> function supports only the privileges specified in the Defined Privileges section of Winnt.h.
        /// For a list of values, see Privilege Constants.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "LookupPrivilegeValueW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL LookupPrivilegeValue([In] LPCWSTR lpSystemName, [In] LPCWSTR lpName, [Out] out LUID lpLuid);

        /// <summary>
        /// <para>
        /// The <see cref="MapGenericMask"/> function maps the generic access rights in an access mask to specific and standard access rights.
        /// The function applies a mapping supplied in a <see cref="GENERIC_MAPPING"/> structure.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-mapgenericmask"/>
        /// </para>
        /// </summary>
        /// <param name="AccessMask">
        /// A pointer to an access mask.
        /// </param>
        /// <param name="GenericMapping">
        /// A pointer to a <see cref="GENERIC_MAPPING"/> structure specifying a mapping of generic access types to specific and standard access types.
        /// </param>
        /// <remarks>
        /// After calling the <see cref="MapGenericMask"/> function, the access mask pointed to by the <paramref name="AccessMask"/> parameter
        /// has none of its generic bits (<see cref="GENERIC_MAPPING.GenericRead"/>, <see cref="GENERIC_MAPPING.GenericWrite"/>,
        /// <see cref="GENERIC_MAPPING.GenericExecute"/>, or <see cref="GENERIC_MAPPING.GenericAll"/>) or undefined bits set,
        /// although it can have other bits set.
        /// If bits other than the generic bits are provided on input, this function does not clear them.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "MapGenericMask", ExactSpelling = true, SetLastError = true)]
        public static extern void MapGenericMask([In][Out] ref ACCESS_MASK AccessMask, [In] in GENERIC_MAPPING GenericMapping);

        /// <summary>
        /// <para>
        /// The <see cref="RevertToSelf"/> function terminates the impersonation of a client application.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-reverttoself"/>
        /// </para>
        /// </summary>
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
        /// A process should call the <see cref="RevertToSelf"/> function after finishing any impersonation begun
        /// by using the <see cref="DdeImpersonateClient"/>, <see cref="ImpersonateDdeClientWindow"/>,
        /// <see cref="ImpersonateLoggedOnUser"/>, <see cref="ImpersonateNamedPipeClient"/>,
        /// <see cref="ImpersonateSelf"/>, <see cref="ImpersonateAnonymousToken"/> or <see cref="SetThreadToken"/> function.
        /// </para>
        /// <para>
        /// An RPC server that used the <see cref="RpcImpersonateClient"/> function to impersonate a client
        /// must call the <see cref="RpcRevertToSelf"/> or <see cref="RpcRevertToSelfEx"/> to end the impersonation.
        /// </para>
        /// <para>
        /// If <see cref="RevertToSelf"/> fails, your application continues to run in the context of the client, which is not appropriate.
        /// You should shut down the process if <see cref="RevertToSelf"/> fails.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RevertToSelf", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL RevertToSelf();

        /// <summary>
        /// <para>
        /// The <see cref="SetSecurityDescriptorControl"/> function sets the control bits of a security descriptor.
        /// The function can set only the control bits that relate to automatic inheritance of ACEs.
        /// To set the other control bits of a security descriptor, use the functions,
        /// such as <see cref="SetSecurityDescriptorDacl"/>, for modifying the components of a security descriptor.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-setsecuritydescriptorcontrol"/>
        /// </para>
        /// </summary>
        /// <param name="pSecurityDescriptor">
        /// A pointer to a <see cref="SECURITY_DESCRIPTOR"/> structure whose control and revision information are set.
        /// </param>
        /// <param name="ControlBitsOfInterest">
        /// A <see cref="SECURITY_DESCRIPTOR_CONTROL"/> mask that indicates the control bits to set.
        /// </param>
        /// <param name="ControlBitsToSet">
        /// A <see cref="SECURITY_DESCRIPTOR_CONTROL"/> mask that indicates the new values
        /// for the control bits specified by the <paramref name="ControlBitsToSet"/> mask.
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
        /// The <see cref="SetSecurityDescriptorControl"/> function specifies the control bit or bits to modify, and whether the bits are on or off.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetSecurityDescriptorControl", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetSecurityDescriptorControl([In] PSECURITY_DESCRIPTOR pSecurityDescriptor,
            [In] SECURITY_DESCRIPTOR_CONTROL ControlBitsOfInterest, [In] SECURITY_DESCRIPTOR_CONTROL ControlBitsToSet);

        /// <summary>
        /// <para>
        /// The <see cref="SetSecurityDescriptorDacl"/> function sets information in a discretionary access control list (DACL).
        /// If a DACL is already present in the security descriptor, the DACL is replaced.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-setsecuritydescriptordacl"/>
        /// </para>
        /// </summary>
        /// <param name="pSecurityDescriptor">
        /// A pointer to the <see cref="SECURITY_DESCRIPTOR"/> structure to which the function adds the DACL.
        /// This security descriptor must be in absolute format,
        /// meaning that its members must be pointers to other structures, rather than offsets to contiguous data.
        /// </param>
        /// <param name="bDaclPresent">
        /// A flag that indicates the presence of a DACL in the security descriptor.
        /// If this parameter is <see cref="TRUE"/>, the function sets the <see cref="SE_DACL_PRESENT"/> flag
        /// in the <see cref="SECURITY_DESCRIPTOR_CONTROL"/> structure and uses the values
        /// in the <paramref name="pDacl"/> and <paramref name="bDaclDefaulted"/> parameters.
        /// If this parameter is <see cref="FALSE"/>, the function clears the <see cref="SE_DACL_PRESENT"/> flag,
        /// and <paramref name="pDacl"/> and <paramref name="bDaclDefaulted"/> are ignored.
        /// </param>
        /// <param name="pDacl">
        /// A pointer to an <see cref="ACL"/> structure that specifies the DACL for the security descriptor.
        /// If this parameter is <see cref="NullRef{ACL}"/>, a NULL DACL is assigned to the security descriptor, which allows all access to the object.
        /// The DACL is referenced by, not copied into, the security descriptor.
        /// </param>
        /// <param name="bDaclDefaulted">
        /// A flag that indicates the source of the DACL.
        /// If this flag is <see cref="TRUE"/>, the DACL has been retrieved by some default mechanism.
        /// If <see cref="FALSE"/>, the DACL has been explicitly specified by a user.
        /// The function stores this value in the <see cref="SE_DACL_DEFAULTED"/> flag of the <see cref="SECURITY_DESCRIPTOR_CONTROL"/> structure.
        /// If this parameter is not specified, the <see cref="SE_DACL_DEFAULTED"/> flag is cleared.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the function returns nonzero.
        /// </para>
        /// <para>
        /// If the function fails, it returns zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// There is an important difference between an empty and a nonexistent DACL.
        /// When a DACL is empty, it contains no access control entries (ACEs); therefore, no access rights are explicitly granted.
        /// As a result, access to the object is implicitly denied.
        /// </para>
        /// <para>
        /// When an object has no DACL (when the <paramref name="pDacl"/> parameter is <see cref="NULL"/>),
        /// no protection is assigned to the object, and all access requests are granted.
        /// To help maintain security, restrict access by using a DACL.
        /// </para>
        /// <para>
        /// There are three possible outcomes in different configurations of the <paramref name="bDaclPresent"/> flag
        /// and the <paramref name="pDacl"/> parameter:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// When the <paramref name="pDacl"/> parameter points to a DACL and the <paramref name="bDaclPresent"/> flag is <see cref="TRUE"/>,
        /// a DACL is specified and it must contain access-allowed ACEs to allow access to the object.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// When the <paramref name="pDacl"/> parameter does not point to a DACL
        /// and the <paramref name="bDaclPresent"/> flag is <see cref="TRUE"/>, a <see cref="NULL"/> DACL is specified.
        /// All access is allowed.
        /// You should not use a <see cref="NULL"/> DACL with an object because any user can change the DACL and owner of the security descriptor.
        /// This will interfere with use of the object.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// When the <paramref name="pDacl"/> parameter does not point to a DACL
        /// and the <paramref name="bDaclPresent"/> flag is <see cref="FALSE"/>,
        /// a DACL can be provided for the object through an inheritance or default mechanism.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetSecurityDescriptorDacl", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetSecurityDescriptorDacl([In] PSECURITY_DESCRIPTOR pSecurityDescriptor, [In] BOOL bDaclPresent,
            [In] in ACL pDacl, [In] BOOL bDaclDefaulted);

        /// <summary>
        /// <para>
        /// The <see cref="SetSecurityDescriptorGroup"/> function sets the primary group information of an absolute-format security descriptor,
        /// replacing any primary group information already present in the security descriptor.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-setsecuritydescriptorgroup"/>
        /// </para>
        /// </summary>
        /// <param name="pSecurityDescriptor">
        /// A pointer to the <see cref="SECURITY_DESCRIPTOR"/> structure whose primary group is set by this function.
        /// The function replaces any existing primary group with the new primary group.
        /// </param>
        /// <param name="pGroup">
        /// A pointer to a <see cref="SID"/> structure for the security descriptor's new primary group.
        /// The <see cref="SID"/> structure is referenced by, not copied into, the security descriptor.
        /// If this parameter is <see cref="NULL"/>, the function clears the security descriptor's primary group information.
        /// This marks the security descriptor as having no primary group.
        /// </param>
        /// <param name="bGroupDefaulted">
        /// Indicates whether the primary group information was derived from a default mechanism.
        /// If this value is <see cref="TRUE"/>, it is default information, and the function stores
        /// this value as the <see cref="SE_GROUP_DEFAULTED"/> flag in the <see cref="SECURITY_DESCRIPTOR_CONTROL"/> structure.
        /// If this parameter is <see cref="FALSE"/>, the <see cref="SE_GROUP_DEFAULTED"/> flag is cleared.
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
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetSecurityDescriptorGroup", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetSecurityDescriptorGroup([In] PSECURITY_DESCRIPTOR pSecurityDescriptor, [In] PSID pGroup, [In] BOOL bGroupDefaulted);

        /// <summary>
        /// <para>
        /// The <see cref="SetSecurityDescriptorOwner"/> function sets the owner information of an absolute-format security descriptor.
        /// It replaces any owner information already present in the security descriptor.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-setsecuritydescriptorowner"/>
        /// </para>
        /// </summary>
        /// <param name="pSecurityDescriptor">
        /// A pointer to the <see cref="SECURITY_DESCRIPTOR"/> structure whose owner is set by this function.
        /// The function replaces any existing owner with the new owner.
        /// </param>
        /// <param name="pOwner">
        /// A pointer to a <see cref="SID"/> structure for the security descriptor's new primary owner.
        /// The <see cref="SID"/> structure is referenced by, not copied into, the security descriptor.
        /// If this parameter is <see cref="NULL"/>, the function clears the security descriptor's owner information.
        /// This marks the security descriptor as having no owner.
        /// </param>
        /// <param name="bOwnerDefaulted">
        /// Indicates whether the owner information is derived from a default mechanism.
        /// If this value is <see cref="TRUE"/>, it is default information.
        /// The function stores this value as the <see cref="SE_OWNER_DEFAULTED"/> flag in the <see cref="SECURITY_DESCRIPTOR_CONTROL"/> structure.
        /// If this parameter is <see cref="FALSE"/>, the <see cref="SE_OWNER_DEFAULTED"/> flag is cleared.
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
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetSecurityDescriptorOwner", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetSecurityDescriptorOwner([In] PSECURITY_DESCRIPTOR pSecurityDescriptor, [In] PSID pOwner, [In] BOOL bOwnerDefaulted);

        /// <summary>
        /// <para>
        /// The <see cref="SetSecurityDescriptorSacl"/> function sets information in a system access control list (SACL).
        /// If there is already a SACL present in the security descriptor, it is replaced.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-setsecuritydescriptorsacl"/>
        /// </para>
        /// </summary>
        /// <param name="pSecurityDescriptor">
        /// A pointer to the <see cref="SECURITY_DESCRIPTOR"/> structure to which the function adds the SACL.
        /// This security descriptor must be in absolute format, meaning that its members must be pointers to other structures,
        /// rather than offsets to contiguous data.
        /// </param>
        /// <param name="bSaclPresent">
        /// Indicates the presence of a SACL in the security descriptor.
        /// If this parameter is <see cref="TRUE"/>, the function sets the <see cref="SE_SACL_PRESENT"/> flag
        /// in the <see cref="SECURITY_DESCRIPTOR_CONTROL"/> structure and uses the values
        /// in the <paramref name="pSacl"/> and <paramref name="bSaclDefaulted"/> parameters.
        /// If it is <see cref="FALSE"/>, the function does not set the <see cref="SE_SACL_PRESENT"/> flag,
        /// and <paramref name="pSacl"/> and <paramref name="bSaclDefaulted"/> are ignored.
        /// </param>
        /// <param name="pSacl">
        /// A pointer to an <see cref="ACL"/> structure that specifies the SACL for the security descriptor.
        /// If this parameter is <see cref="NullRef{ACL}"/>, a NULL SACL is assigned to the security descriptor.
        /// The SACL is referenced by, not copied into, the security descriptor.
        /// </param>
        /// <param name="bSaclDefaulted">
        /// Indicates the source of the SACL.
        /// If this flag is <see cref="TRUE"/>, the SACL has been retrieved by some default mechanism.
        /// If it is <see cref="FALSE"/>, the SACL has been explicitly specified by a user.
        /// The function stores this value in the <see cref="SE_SACL_DEFAULTED"/> flag of the <see cref="SECURITY_DESCRIPTOR_CONTROL"/> structure.
        /// If this parameter is not specified, the <see cref="SE_SACL_DEFAULTED"/> flag is cleared.
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
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetSecurityDescriptorSacl", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetSecurityDescriptorSacl([In] PSECURITY_DESCRIPTOR pSecurityDescriptor,
            [In] BOOL bSaclPresent, [In] in ACL pSacl, [In] BOOL bSaclDefaulted);

    }
}
