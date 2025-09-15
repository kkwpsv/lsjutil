using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HKEY;
using static Lsj.Util.Win32.BaseTypes.WaitResult;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.LogonFlags;
using static Lsj.Util.Win32.Enums.PrivilegeConstants;
using static Lsj.Util.Win32.Enums.ProcessAccessRights;
using static Lsj.Util.Win32.Enums.ProcessCreationFlags;
using static Lsj.Util.Win32.Enums.ProcessPriorityClasses;
using static Lsj.Util.Win32.Enums.StartupInfoFlags;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.ThreadAccessRights;
using static Lsj.Util.Win32.Enums.TokenAccessRights;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Shell32;
using static Lsj.Util.Win32.User32;
using static Lsj.Util.Win32.Userenv;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Advapi32.dll
    /// </summary>
    public partial class Advapi32
    {
        /// <summary>
        /// <para>
        /// Creates a new process and its primary thread.
        /// The new process runs in the security context of the user represented by the specified token.
        /// </para>
        /// <para>
        /// Typically, the process that calls the <see cref="CreateProcessAsUser"/> function
        /// must have the <see cref="SE_INCREASE_QUOTA_NAME"/> privilege
        /// and may require the <see cref="SE_ASSIGNPRIMARYTOKEN_NAME"/> privilege if the token is not assignable.
        /// If this function fails with <see cref="ERROR_PRIVILEGE_NOT_HELD"/> (1314), use the <see cref="CreateProcessWithLogonW"/> function instead.
        /// <see cref="CreateProcessWithLogonW"/> requires no special privileges,
        /// but the specified user account must be allowed to log on interactively.
        /// Generally, it is best to use <see cref="CreateProcessWithLogonW"/> to create a process with alternate credentials.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-createprocessasuserw"/>
        /// </para>
        /// </summary>
        /// <param name="hToken">
        /// <para>
        /// A handle to the primary token that represents a user.
        /// The handle must have the <see cref="TOKEN_QUERY"/>, <see cref="TOKEN_DUPLICATE"/>, and <see cref="TOKEN_ASSIGN_PRIMARY"/> access rights.
        /// For more information, see Access Rights for Access-Token Objects.
        /// The user represented by the token must have read and execute access to the application
        /// specified by the <paramref name="lpApplicationName"/> or the <paramref name="lpCommandLine"/> parameter.
        /// </para>
        /// <para>
        /// To get a primary token that represents the specified user, call the <see cref="LogonUser"/> function.
        /// Alternatively, you can call the <see cref="DuplicateTokenEx"/> function to convert an impersonation token into a primary token.
        /// This allows a server application that is impersonating a client to create a process that has the security context of the client.
        /// </para>
        /// <para>
        /// If <paramref name="hToken"/> is a restricted version of the caller's primary token,
        /// the <see cref="SE_ASSIGNPRIMARYTOKEN_NAME"/> privilege is not required.
        /// If the necessary privileges are not already enabled, <see cref="CreateProcessAsUser"/> enables them for the duration of the call.
        /// For more information, see Running with Special Privileges.
        /// </para>
        /// <para>
        /// Terminal Services:
        /// The process is run in the session specified in the token.
        /// By default, this is the same session that called <see cref="LogonUser"/>.
        /// To change the session, use the <see cref="SetTokenInformation"/> function.
        /// </para>
        /// </param>
        /// <param name="lpApplicationName">
        /// <para>
        /// The name of the module to be executed.
        /// This module can be a Windows-based application.
        /// It can be some other type of module (for example, MS-DOS or OS/2) if the appropriate subsystem is available on the local computer.
        /// </para>
        /// <para>
        /// The string can specify the full path and file name of the module to execute or it can specify a partial name.
        /// In the case of a partial name, the function uses the current drive and current directory to complete the specification.
        /// The function will not use the search path.
        /// This parameter must include the file name extension; no default extension is assumed.
        /// </para>
        /// <para>
        /// The <paramref name="lpApplicationName"/> parameter can be <see cref="NULL"/>.
        /// In that case, the module name must be the first white space–delimited token in the <paramref name="lpCommandLine"/> string.
        /// If you are using a long file name that contains a space,
        /// use quoted strings to indicate where the file name ends and the arguments begin;
        /// otherwise, the file name is ambiguous.
        /// For example, consider the string "c:\program files\sub dir\program name".
        /// This string can be interpreted in a number of ways.
        /// The system tries to interpret the possibilities in the following order:
        /// </para>
        /// <para>
        /// c:\program.exe c:\program files\sub.exe c:\program files\sub dir\program.exe c:\program files\sub dir\program name.exe
        /// If the executable module is a 16-bit application, <paramref name="lpApplicationName"/> should be <see cref="NULL"/>,
        /// and the string pointed to by <paramref name="lpCommandLine"/> should specify the executable module as well as its arguments.
        /// By default, all 16-bit Windows-based applications created by <see cref="CreateProcessAsUser"/> are run in a separate VDM
        /// (equivalent to <see cref="CREATE_SEPARATE_WOW_VDM"/> in <see cref="CreateProcess"/>).
        /// </para>
        /// </param>
        /// <param name="lpCommandLine">
        /// <para>
        /// The command line to be executed. The maximum length of this string is 32K characters.
        /// If <paramref name="lpApplicationName"/> is <see cref="NULL"/>,
        /// the module name portion of <paramref name="lpCommandLine"/> is limited to <see cref="MAX_PATH"/> characters.
        /// </para>
        /// <para>
        /// The Unicode version of this function, <see cref="CreateProcessAsUser"/>, can modify the contents of this string.
        /// Therefore, this parameter cannot be a pointer to read-only memory (such as a const variable or a literal string).
        /// If this parameter is a constant string, the function may cause an access violation.
        /// </para>
        /// <para>
        /// The <paramref name="lpCommandLine"/> parameter can be <see cref="NULL"/>.
        /// In that case, the function uses the string pointed to by <paramref name="lpApplicationName"/> as the command line.
        /// </para>
        /// <para>
        /// If both <paramref name="lpApplicationName"/> and <paramref name="lpCommandLine"/> are non-<see cref="NULL"/>,
        /// *<paramref name="lpApplicationName"/> specifies the module to execute, and *<paramref name="lpCommandLine"/> specifies the command line.
        /// The new process can use <see cref="GetCommandLine"/> to retrieve the entire command line.
        /// Console processes written in C can use the argc and argv arguments to parse the command line.
        /// Because argv[0] is the module name, C programmers generally repeat the module name as the first token in the command line.
        /// </para>
        /// <para>
        /// If <paramref name="lpApplicationName"/> is <see cref="NULL"/>,
        /// the first white space–delimited token of the command line specifies the module name.
        /// If you are using a long file name that contains a space,
        /// use quoted strings to indicate where the file name ends and the arguments begin
        /// (see the explanation for the <paramref name="lpApplicationName"/> parameter).
        /// If the file name does not contain an extension, .exe is appended.
        /// Therefore, if the file name extension is .com, this parameter must include the .com extension.
        /// If the file name ends in a period (.) with no extension, or if the file name contains a path, .exe is not appended.
        /// If the file name does not contain a directory path, the system searches for the executable file in the following sequence:
        /// </para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// The directory from which the application loaded.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The current directory for the parent process.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The 32-bit Windows system directory.
        /// Use the <see cref="GetSystemDirectory"/> function to get the path of this directory.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The 16-bit Windows system directory.
        /// There is no function that obtains the path of this directory, but it is searched.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The Windows directory.
        /// Use the <see cref="GetWindowsDirectory"/> function to get the path of this directory.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The directories that are listed in the PATH environment variable.
        /// Note that this function does not search the per-application path specified by the App Paths registry key.
        /// To include this per-application path in the search sequence, use the <see cref="ShellExecute"/> function.
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// The system adds a null character to the command line string to separate the file name from the arguments.
        /// This divides the original string into two strings for internal processing.
        /// </para>
        /// </param>
        /// <param name="lpProcessAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that specifies a security descriptor for the new process object
        /// and determines whether child processes can inherit the returned handle to the process.
        /// If <paramref name="lpProcessAttributes"/> is <see cref="NULL"/>
        /// or <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> is <see cref="NULL"/>,
        /// the process gets a default security descriptor and the handle cannot be inherited.
        /// The default security descriptor is that of the user referenced in the <paramref name="hToken"/> parameter.
        /// This security descriptor may not allow access for the caller, in which case the process may not be opened again after it is run.
        /// The process handle is valid and will continue to have full access rights.
        /// </param>
        /// <param name="lpThreadAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that specifies a security descriptor for the new thread object
        /// and determines whether child processes can inherit the returned handle to the thread.
        /// If <paramref name="lpThreadAttributes"/> is <see cref="NULL"/>
        /// or <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> is <see cref="NULL"/>,
        /// the thread gets a default security descriptor and the handle cannot be inherited.
        /// The default security descriptor is that of the user referenced in the <paramref name="hToken"/> parameter.
        /// This security descriptor may not allow access for the caller.
        /// </param>
        /// <param name="bInheritHandles">
        /// <para>
        /// If this parameter is <see cref="TRUE"/>, each inheritable handle in the calling process is inherited by the new process.
        /// If the parameter is <see cref="FALSE"/>, the handles are not inherited.
        /// Note that inherited handles have the same value and access rights as the original handles.
        /// For additional discussion of inheritable handles, see Remarks.
        /// </para>
        /// <para>
        /// Terminal Services:
        /// You cannot inherit handles across sessions.
        /// Additionally, if this parameter is <see cref="TRUE"/>, you must create the process in the same session as the caller.
        /// </para>
        /// <para>
        /// Protected Process Light (PPL) processes:
        /// The generic handle inheritance is blocked when a PPL process creates a non-PPL process 
        /// since <see cref="PROCESS_DUP_HANDLE"/> is not allowed from a non-PPL process to a PPL process.
        /// See Process Security and Access Rights
        /// </para>
        /// </param>
        /// <param name="dwCreationFlags">
        /// <para>
        /// The flags that control the priority class and the creation of the process.
        /// For a list of values, see Process Creation Flags.
        /// </para>
        /// <para>
        /// This parameter also controls the new process's priority class,
        /// which is used to determine the scheduling priorities of the process's threads.
        /// For a list of values, see <see cref="GetPriorityClass"/>.
        /// If none of the priority class flags is specified, the priority class defaults to <see cref="NORMAL_PRIORITY_CLASS"/>
        /// unless the priority class of the creating process is <see cref="IDLE_PRIORITY_CLASS"/> or <see cref="BELOW_NORMAL_PRIORITY_CLASS"/>.
        /// In this case, the child process receives the default priority class of the calling process.
        /// </para>
        /// <para>
        /// If the <paramref name="dwCreationFlags"/> parameter has a value of 0:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The process inherits both the error mode of the caller and the parent's console.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The environment block for the new process is assumed to contain ANSI characters
        /// (see <paramref name="lpEnvironment"/> parameter for additional information).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A 16-bit Windows-based application runs in a shared Virtual DOS machine (VDM).
        /// </description>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="lpEnvironment">
        /// <para>
        /// A pointer to an environment block for the new process.
        /// If this parameter is <see cref="NULL"/>, the new process uses the environment of the calling process.
        /// </para>
        /// <para>
        /// An environment block consists of a null-terminated block of null-terminated strings.
        /// Each string is in the following form:
        /// </para>
        /// <para>
        /// name=value\0
        /// </para>
        /// <para>
        /// Because the equal sign is used as a separator, it must not be used in the name of an environment variable.
        /// </para>
        /// <para>
        /// An environment block can contain either Unicode or ANSI characters.
        /// If the environment block pointed to by <paramref name="lpEnvironment"/> contains Unicode characters,
        /// be sure that <paramref name="dwCreationFlags"/> includes <see cref="CREATE_UNICODE_ENVIRONMENT"/>.
        /// </para>
        /// <para>
        /// The ANSI version of this function, CreateProcessAsUserA fails if the total size of the environment block for the process exceeds 32,767 characters.
        /// </para>
        /// <para>
        /// Note that an ANSI environment block is terminated by two zero bytes: one for the last string, one more to terminate the block.
        /// A Unicode environment block is terminated by four zero bytes: two for the last string, two more to terminate the block.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:
        /// If the size of the combined user and system environment variable exceeds 8192 bytes,
        /// the process created by <see cref="CreateProcessAsUser"/> no longer runs with the environment block passed to the function by the parent process.
        /// Instead, the child process runs with the environment block returned by the <see cref="CreateEnvironmentBlock"/> function.
        /// </para>
        /// <para>
        /// To retrieve a copy of the environment block for a given user, use the <see cref="CreateEnvironmentBlock"/> function.
        /// </para>
        /// </param>
        /// <param name="lpCurrentDirectory">
        /// <para>
        /// The full path to the current directory for the process.
        /// The string can also specify a UNC path.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NULL"/>, the new process will have the same current drive and directory as the calling process.
        /// (This feature is provided primarily for shells that need to start an application and specify its initial drive and working directory.)
        /// </para>
        /// </param>
        /// <param name="lpStartupInfo">
        /// <para>
        /// A pointer to a <see cref="STARTUPINFO"/> or <see cref="STARTUPINFOEX"/> structure.
        /// </para>
        /// <para>
        /// The user must have full access to both the specified window station and desktop.
        /// If you want the process to be interactive, specify winsta0\default.
        /// If the <see cref="STARTUPINFO.lpDesktop"/> member is <see cref="NULL"/>,
        /// the new process inherits the desktop and window station of its parent process.
        /// If this member is an empty string, "", the new process connects to a window station
        /// using the rules described in Process Connection to a Window Station.
        /// </para>
        /// <para>
        /// To set extended attributes, use a <see cref="STARTUPINFOEX"/> structure
        /// and specify <see cref="EXTENDED_STARTUPINFO_PRESENT"/> in the <paramref name="dwCreationFlags"/> parameter.
        /// </para>
        /// <para>
        /// Handles in <see cref="STARTUPINFO"/> or <see cref="STARTUPINFOEX"/> must
        /// be closed with <see cref="CloseHandle"/> when they are no longer needed.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// The caller is responsible for ensuring that the standard handle fields in <see cref="STARTUPINFO"/> contain valid handle values.
        /// These fields are copied unchanged to the child process without validation,
        /// even when the <see cref="STARTUPINFO.dwFlags"/> member specifies <see cref="STARTF_USESTDHANDLES"/>.
        /// Incorrect values can cause the child process to misbehave or crash.
        /// Use the Application Verifier runtime verification tool to detect invalid handles.
        /// </para>
        /// </param>
        /// <param name="lpProcessInformation">
        /// <para>
        /// A pointer to a <see cref="PROCESS_INFORMATION"/> structure that receives identification information about the new process.
        /// </para>
        /// <para>
        /// Handles in <see cref="PROCESS_INFORMATION"/> must be closed with <see cref="CloseHandle"/> when they are no longer needed.
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
        /// <para>
        /// Note that the function returns before the process has finished initialization.
        /// If a required DLL cannot be located or fails to initialize, the process is terminated.
        /// To get the termination status of a process, call <see cref="GetExitCodeProcess"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="CreateProcessAsUser"/> must be able to open the primary token of the calling process
        /// with the <see cref="TOKEN_DUPLICATE"/> and <see cref="TOKEN_IMPERSONATE"/> access rights.
        /// </para>
        /// <para>
        /// By default, <see cref="CreateProcessAsUser"/> creates the new process on a noninteractive window station
        /// with a desktop that is not visible and cannot receive user input.
        /// To enable user interaction with the new process, you must specify the name of the default interactive window station and desktop,
        /// "winsta0\default", in the <see cref="STARTUPINFO.lpDesktop"/> member of the <see cref="STARTUPINFO"/> structure.
        /// In addition, before calling <see cref="CreateProcessAsUser"/>,
        /// you must change the discretionary access control list (DACL) of both the default interactive window station and the default desktop.
        /// The DACLs for the window station and desktop must grant access to the user or the logon session represented by the <paramref name="hToken"/> parameter.
        /// </para>
        /// <para>
        /// <see cref="CreateProcessAsUser"/> does not load the specified user's profile into the <see cref="HKEY_USERS"/> registry key.
        /// Therefore, to access the information in the <see cref="HKEY_CURRENT_USER"/> registry key,
        /// you must load the user's profile information into <see cref="HKEY_USERS"/>
        /// with the <see cref="LoadUserProfile"/> function before calling <see cref="CreateProcessAsUser"/>.
        /// Be sure to call <see cref="UnloadUserProfile"/> after the new process exits.
        /// </para>
        /// <para>
        /// If the <paramref name="lpEnvironment"/> parameter is <see cref="NULL"/>,
        /// the new process inherits the environment of the calling process.
        /// <see cref="CreateProcessAsUser"/> does not automatically modify the environment block to include environment variables
        /// specific to the user represented by <paramref name="hToken"/>.
        /// For example, the USERNAME and USERDOMAIN variables are inherited from the calling process if <paramref name="lpEnvironment"/> is NULL.
        /// It is your responsibility to prepare the environment block for the new process and specify it in <paramref name="lpEnvironment"/>.
        /// </para>
        /// <para>
        /// The <see cref="CreateProcessWithLogonW"/> and <see cref="CreateProcessWithTokenW"/> functions are similar to <see cref="CreateProcessAsUser"/>,
        /// except that the caller does not need to call the <see cref="LogonUser"/> function to authenticate the user and get a token.
        /// </para>
        /// <para>
        /// <see cref="CreateProcessAsUser"/> allows you to access the specified directory
        /// and executable image in the security context of the caller or the target user.
        /// By default, <see cref="CreateProcessAsUser"/> accesses the directory and executable image in the security context of the caller.
        /// In this case, if the caller does not have access to the directory and executable image, the function fails.
        /// To access the directory and executable image using the security context of the target user,
        /// specify <paramref name="hToken"/> in a call to the <see cref="ImpersonateLoggedOnUser"/> function before calling <see cref="CreateProcessAsUser"/>.
        /// </para>
        /// <para>
        /// The process is assigned a process identifier.
        /// The identifier is valid until the process terminates.
        /// It can be used to identify the process, or specified in the <see cref="OpenProcess"/> function to open a handle to the process.
        /// The initial thread in the process is also assigned a thread identifier.
        /// It can be specified in the <see cref="OpenThread"/> function to open a handle to the thread.
        /// The identifier is valid until the thread terminates and can be used to uniquely identify the thread within the system.
        /// These identifiers are returned in the <see cref="PROCESS_INFORMATION"/> structure.
        /// </para>
        /// <para>
        /// The calling thread can use the <see cref="WaitForInputIdle"/> function to wait
        /// until the new process has finished its initialization and is waiting for user input with no input pending.
        /// This can be useful for synchronization between parent and child processes,
        /// because <see cref="CreateProcessAsUser"/> returns without waiting for the new process to finish its initialization.
        /// For example, the creating process would use <see cref="WaitForInputIdle"/> before trying to find a window associated with the new process.
        /// </para>
        /// <para>
        /// The preferred way to shut down a process is by using the <see cref="ExitProcess"/> function,
        /// because this function sends notification of approaching termination to all DLLs attached to the process.
        /// Other means of shutting down a process do not notify the attached DLLs.
        /// Note that when a thread calls <see cref="ExitProcess"/>,
        /// other threads of the process are terminated without an opportunity to execute any additional code
        /// (including the thread termination code of attached DLLs).
        /// For more information, see Terminating a Process.
        /// </para>
        /// <para>
        /// By default, passing <see cref="TRUE"/> as the value of the <paramref name="bInheritHandles"/> parameter
        /// causes all inheritable handles to be inherited by the new process.
        /// This can be problematic for applications which create processes from multiple threads simultaneously
        /// yet desire each process to inherit different handles.
        /// Applications can use the <see cref="UpdateProcThreadAttributeList"/> function
        /// with the <see cref="PROC_THREAD_ATTRIBUTE_HANDLE_LIST"/> parameter to provide a list of handles to be inherited by a particular process.
        /// </para>
        /// <para>
        /// Security Remarks
        /// </para>
        /// <para>
        /// The <paramref name="lpApplicationName"/> parameter can be <see cref="NULL"/>,
        /// in which case the executable name must be the first white space–delimited string in <paramref name="lpCommandLine"/>.
        /// If the executable or path name has a space in it,
        /// there is a risk that a different executable could be run because of the way the function parses spaces.
        /// The following example is dangerous because the function will attempt to run "Program.exe", if it exists, instead of "MyApp.exe".
        /// </para>
        /// <code>
        /// LPTSTR szCmdline = _tcsdup(TEXT("C:\\Program Files\\MyApp -L -S"));
        /// CreateProcess(NULL, szCmdline, /* ... */);
        /// </code>
        /// <para>
        /// If a malicious user were to create an application called "Program.exe" on a system,
        /// any program that incorrectly calls <see cref="CreateProcessAsUser"/> using the Program Files directory
        /// will run this application instead of the intended application.
        /// </para>
        /// <para>
        /// To avoid this problem, do not pass <see cref="NULL"/> for <paramref name="lpApplicationName"/>.
        /// If you do pass <see cref="NULL"/> for <paramref name="lpApplicationName"/>,
        /// use quotation marks around the executable path in <paramref name="lpCommandLine"/>, as shown in the example below.
        /// </para>
        /// <code>
        /// LPTSTR szCmdline[] = _tcsdup(TEXT("\"C:\\Program Files\\MyApp\" -L -S"));
        /// CreateProcess(NULL, szCmdline, /*...*/);
        /// </code>
        /// <para>
        /// PowerShell:
        /// When the <see cref="CreateProcessAsUser"/> function is used to implement a cmdlet in PowerShell version 2.0,
        /// the cmdlet operates correctly for both fan-in and fan-out remote sessions.
        /// Because of certain security scenarios, however, a cmdlet implemented with <see cref="CreateProcessAsUser"/> only operates correctly
        /// in PowerShell version 3.0 for fan-in remote sessions; fan-out remote sessions will fail because of insufficient client security privileges.
        /// To implement a cmdlet that works for both fan-in and fan-out remote sessions in PowerShell version 3.0,
        /// use the <see cref="CreateProcess"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateProcessAsUserW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CreateProcessAsUser([In] HANDLE hToken, [In] LPCWSTR lpApplicationName, [In] LPWSTR lpCommandLine,
            [In] in SECURITY_ATTRIBUTES lpProcessAttributes, [In] in SECURITY_ATTRIBUTES lpThreadAttributes, [In] BOOL bInheritHandles,
            [In] ProcessCreationFlags dwCreationFlags, [In] LPVOID lpEnvironment, [In] LPCWSTR lpCurrentDirectory,
            [In] in STARTUPINFO lpStartupInfo, [Out] out PROCESS_INFORMATION lpProcessInformation);

        /// <summary>
        /// <para>
        /// Creates a new process and its primary thread.
        /// Then the new process runs the specified executable file in the security context of the specified credentials (user, domain, and password).
        /// It can optionally load the user profile for a specified user.
        /// </para>
        /// <para>
        /// This function is similar to the <see cref="CreateProcessAsUser"/> and <see cref="CreateProcessWithTokenW"/> functions,
        /// except that the caller does not need to call the <see cref="LogonUser"/> function to authenticate the user and get a token.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-createprocesswithlogonw"/>
        /// </para>
        /// </summary>
        /// <param name="lpUsername">
        /// <para>
        /// The name of the user.
        /// This is the name of the user account to log on to.
        /// If you use the UPN format, user@DNS_domain_name, the <paramref name="lpDomain"/> parameter must be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// The user account must have the Log On Locally permission on the local computer.
        /// This permission is granted to all users on workstations and servers, but only to administrators on domain controllers.
        /// </para>
        /// </param>
        /// <param name="lpDomain">
        /// The name of the domain or server whose account database contains the <paramref name="lpUsername"/> account.
        /// If this parameter is <see cref="NULL"/>, the user name must be specified in UPN format.
        /// </param>
        /// <param name="lpPassword">
        /// The clear-text password for the <paramref name="lpUsername"/> account.
        /// </param>
        /// <param name="dwLogonFlags">
        /// <para>
        /// The logon option. This parameter can be 0 (zero) or one of the following values.
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
        /// <see cref="LOGON_WITH_PROFILE"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Log on, then load the user profile in the <see cref="HKEY_USERS"/> registry key.
        /// The function returns after the profile is loaded.
        /// Loading the profile can be time-consuming, so it is best to use this value
        /// only if you must access the information in the <see cref="HKEY_CURRENT_USER"/> registry key.
        /// </para>
        /// <para>
        /// Windows Server 2003:
        /// The profile is unloaded after the new process is terminated, whether or not it has created child processes.
        /// </para>
        /// <para>
        /// Windows XP:
        /// The profile is unloaded after the new process and all child processes it has created are terminated.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="LOGON_NETCREDENTIALS_ONLY"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Log on, but use the specified credentials on the network only.
        /// The new process uses the same token as the caller, but the system creates a new logon session within LSA,
        /// and the process uses the specified credentials as the default credentials.
        /// </para>
        /// <para>
        /// This value can be used to create a process that uses a different set of credentials locally than it does remotely.
        /// This is useful in inter-domain scenarios where there is no trust relationship.
        /// </para>
        /// <para>
        /// The system does not validate the specified credentials.
        /// Therefore, the process can start, but it may not have access to network resources.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="lpApplicationName">
        /// <para>
        /// The name of the module to be executed.
        /// This module can be a Windows-based application.
        /// It can be some other type of module (for example, MS-DOS or OS/2) if the appropriate subsystem is available on the local computer.
        /// </para>
        /// <para>
        /// The string can specify the full path and file name of the module to execute or it can specify a partial name.
        /// If it is a partial name, the function uses the current drive and current directory to complete the specification.
        /// The function does not use the search path.
        /// This parameter must include the file name extension; no default extension is assumed.
        /// </para>
        /// <para>
        /// The <paramref name="lpApplicationName"/> parameter can be <see cref="NULL"/>,
        /// and the module name must be the first white space–delimited token in the <paramref name="lpCommandLine"/> string.
        /// If you are using a long file name that contains a space,
        /// use quoted strings to indicate where the file name ends and the arguments begin;
        /// otherwise, the file name is ambiguous.
        /// </para>
        /// <para>
        /// For example, the following string can be interpreted in different ways:
        /// </para>
        /// <para>
        /// "c:\program files\sub dir\program name"
        /// </para>
        /// <para>
        /// The system tries to interpret the possibilities in the following order:
        /// </para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// c:\program.exe files\sub dir\program name
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// c:\program files\sub.exe dir\program name
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// c:\program files\sub dir\program.exe name
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// c:\program files\sub dir\program name.exe
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// If the executable module is a 16-bit application, <paramref name="lpApplicationName"/> should be <see cref="NULL"/>,
        /// and the string pointed to by <paramref name="lpCommandLine"/> should specify the executable module and its arguments.
        /// </para>
        /// </param>
        /// <param name="lpCommandLine">
        /// <para>
        /// The command line to be executed.
        /// The maximum length of this string is 1024 characters.
        /// If <paramref name="lpApplicationName"/> is <see cref="NULL"/>,
        /// the module name portion of <paramref name="lpCommandLine"/> is limited to <see cref="MAX_PATH"/> characters.
        /// </para>
        /// <para>
        /// The function can modify the contents of this string.
        /// Therefore, this parameter cannot be a pointer to read-only memory (such as a const variable or a literal string).
        /// If this parameter is a constant string, the function may cause an access violation.
        /// </para>
        /// <para>
        /// The <paramref name="lpCommandLine"/> parameter can be <see cref="NULL"/>,
        /// and the function uses the string pointed to by <paramref name="lpApplicationName"/> as the command line.
        /// </para>
        /// <para>
        /// If both <paramref name="lpApplicationName"/> and <paramref name="lpCommandLine"/> are non-<see cref="NULL"/>,
        /// *<paramref name="lpApplicationName"/> specifies the module to execute,
        /// and *<paramref name="lpCommandLine"/> specifies the command line.
        /// The new process can use <see cref="GetCommandLine"/> to retrieve the entire command line.
        /// Console processes written in C can use the argc and argv arguments to parse the command line.
        /// Because argv[0] is the module name, C programmers typically repeat the module name as the first token in the command line.
        /// </para>
        /// <para>
        /// If <paramref name="lpApplicationName"/> is <see cref="NULL"/>,
        /// the first white space–delimited token of the command line specifies the module name.
        /// If you are using a long file name that contains a space,
        /// use quoted strings to indicate where the file name ends and the arguments begin
        /// (see the explanation for the <paramref name="lpApplicationName"/> parameter).
        /// If the file name does not contain an extension, .exe is appended.
        /// Therefore, if the file name extension is .com, this parameter must include the .com extension.
        /// If the file name ends in a period with no extension, or if the file name contains a path, .exe is not appended.
        /// If the file name does not contain a directory path, the system searches for the executable file in the following sequence:
        /// </para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// The directory from which the application loaded.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The current directory for the parent process.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The 32-bit Windows system directory.
        /// Use the <see cref="GetSystemDirectory"/> function to get the path of this directory.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The 16-bit Windows system directory.
        /// There is no function that obtains the path of this directory, but it is searched.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The Windows directory. Use the <see cref="GetWindowsDirectory"/> function to get the path of this directory.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The directories that are listed in the PATH environment variable.
        /// Note that this function does not search the per-application path specified by the App Paths registry key.
        /// To include this per-application path in the search sequence, use the <see cref="ShellExecute"/> function.
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// The system adds a null character to the command line string to separate the file name from the arguments.
        /// This divides the original string into two strings for internal processing.
        /// </para>
        /// </param>
        /// <param name="dwCreationFlags">
        /// <para>
        /// The flags that control how the process is created.
        /// The <see cref="CREATE_DEFAULT_ERROR_MODE"/>, <see cref="CREATE_NEW_CONSOLE"/>,
        /// and <see cref="CREATE_NEW_PROCESS_GROUP"/> flags are enabled by default.
        /// For a list of values, see Process Creation Flags.
        /// </para>
        /// <para>
        /// This parameter also controls the new process's priority class,
        /// which is used to determine the scheduling priorities of the process's threads.
        /// For a list of values, see <see cref="GetPriorityClass"/>.
        /// If none of the priority class flags is specified, the priority class defaults to <see cref="NORMAL_PRIORITY_CLASS"/>
        /// unless the priority class of the creating process is <see cref="IDLE_PRIORITY_CLASS"/> or <see cref="BELOW_NORMAL_PRIORITY_CLASS"/>.
        /// In this case, the child process receives the default priority class of the calling process.
        /// </para>
        /// <para>
        /// If the <paramref name="dwCreationFlags"/> parameter has a value of 0:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The process gets the default error mode, creates a new console and creates a new process group.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The environment block for the new process is assumed to contain ANSI characters
        /// (see <paramref name="lpEnvironment"/> parameter for additional information).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A 16-bit Windows-based application runs in a shared Virtual DOS machine (VDM).
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpEnvironment">
        /// <para>
        /// A pointer to an environment block for the new process.
        /// If this parameter is <see cref="NULL"/>, the new process uses an environment
        /// created from the profile of the user specified by <paramref name="lpUsername"/>.
        /// </para>
        /// <para>
        /// An environment block consists of a null-terminated block of null-terminated strings.
        /// Each string is in the following form:
        /// </para>
        /// <para>
        /// name=value
        /// </para>
        /// <para>
        /// Because the equal sign (=) is used as a separator, it must not be used in the name of an environment variable.
        /// </para>
        /// <para>
        /// An environment block can contain Unicode or ANSI characters.
        /// If the environment block pointed to by <paramref name="lpEnvironment"/> contains Unicode characters,
        /// ensure that <paramref name="dwCreationFlags"/> includes <see cref="CREATE_UNICODE_ENVIRONMENT"/>.
        /// </para>
        /// <para>
        /// An ANSI environment block is terminated by two 0 (zero) bytes: one for the last string and one more to terminate the block.
        /// A Unicode environment block is terminated by four zero bytes: two for the last string and two more to terminate the block.
        /// </para>
        /// <para>
        /// To retrieve a copy of the environment block for a specific user, use the <see cref="CreateEnvironmentBlock"/> function.
        /// </para>
        /// </param>
        /// <param name="lpCurrentDirectory">
        /// <para>
        /// The full path to the current directory for the process.
        /// The string can also specify a UNC path.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NULL"/>, the new process has the same current drive and directory as the calling process.
        /// This feature is provided primarily for shells that need to start an application,
        /// and specify its initial drive and working directory.
        /// </para>
        /// </param>
        /// <param name="lpStartupInfo">
        /// <para>
        /// A pointer to a <see cref="STARTUPINFO"/> structure.
        /// </para>
        /// <para>
        /// The application must add permission for the specified user account to the specified window station and desktop, even for WinSta0\Default.
        /// </para>
        /// <para>
        /// If the lpDesktop member is <see cref="NULL"/> or an empty string,
        /// the new process inherits the desktop and window station of its parent process.
        /// The application must add permission for the specified user account to the inherited window station and desktop.
        /// </para>
        /// <para>
        /// Windows XP: 
        /// <see cref="CreateProcessWithLogonW"/> adds permission for the specified user account to the inherited window station and desktop.
        /// </para>
        /// <para>
        /// Handles in <see cref="STARTUPINFO"/> must be closed with <see cref="CloseHandle"/> when they are no longer needed.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// If the <see cref="STARTUPINFO.dwFlags"/> member of the <see cref="STARTUPINFO"/> structure
        /// specifies <see cref="STARTF_USESTDHANDLES"/>, the standard handle fields are copied unchanged to the child process without validation.
        /// The caller is responsible for ensuring that these fields contain valid handle values.
        /// Incorrect values can cause the child process to misbehave or crash.
        /// Use the Application Verifier runtime verification tool to detect invalid handles.
        /// </para>
        /// </param>
        /// <param name="lpProcessInformation">
        /// <para>
        /// A pointer to a <see cref="PROCESS_INFORMATION"/> structure
        /// that receives identification information for the new process, including a handle to the process.
        /// </para>
        /// <para>
        /// Handles in <see cref="PROCESS_INFORMATION"/> must be closed with the <see cref="CloseHandle"/> function when they are not needed.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is 0 (zero).
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// Note that the function returns before the process has finished initialization.
        /// If a required DLL cannot be located or fails to initialize, the process is terminated.
        /// To get the termination status of a process, call <see cref="GetExitCodeProcess"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// By default, <see cref="CreateProcessWithLogonW"/> does not load the specified user profile
        /// into the <see cref="HKEY_USERS"/> registry key.
        /// This means that access to information in the <see cref="HKEY_CURRENT_USER"/> registry key
        /// may not produce results that are consistent with a normal interactive logon.
        /// It is your responsibility to load the user registry hive into <see cref="HKEY_USERS"/>
        /// before calling <see cref="CreateProcessWithLogonW"/>,
        /// by using <see cref="LOGON_WITH_PROFILE"/>, or by calling the <see cref="LoadUserProfile"/> function.
        /// </para>
        /// <para>
        /// If the <paramref name="lpEnvironment"/> parameter is <see cref="NULL"/>,
        /// the new process uses an environment block created from the profile of the user specified by <paramref name="lpUsername"/>.
        /// If the HOMEDRIVE and HOMEPATH variables are not set,
        /// <see cref="CreateProcessWithLogonW"/> modifies the environment block to use the drive and path of the user's working directory.
        /// </para>
        /// <para>
        /// When created, the new process and thread handles receive full access rights
        /// (<see cref="PROCESS_ALL_ACCESS"/> and <see cref="THREAD_ALL_ACCESS"/>).
        /// For either handle, if a security descriptor is not provided,
        /// the handle can be used in any function that requires an object handle of that type.
        /// When a security descriptor is provided, an access check is performed on all subsequent uses of the handle before access is granted.
        /// If access is denied, the requesting process cannot use the handle to gain access to the process or thread.
        /// </para>
        /// <para>
        /// To retrieve a security token, pass the process handle in the <see cref="PROCESS_INFORMATION"/> structure
        /// to the <see cref="OpenProcessToken"/> function.
        /// </para>
        /// <para>
        /// The process is assigned a process identifier.
        /// The identifier is valid until the process terminates.
        /// It can be used to identify the process, or it can be specified in the <see cref="OpenProcess"/> function to open a handle to the process.
        /// The initial thread in the process is also assigned a thread identifier.
        /// It can be specified in the <see cref="OpenThread"/> function to open a handle to the thread.
        /// The identifier is valid until the thread terminates and can be used to uniquely identify the thread within the system.
        /// These identifiers are returned in <see cref="PROCESS_INFORMATION"/>.
        /// </para>
        /// <para>
        /// The calling thread can use the <see cref="WaitForInputIdle"/> function to wait
        /// until the new process has completed its initialization and is waiting for user input with no input pending.
        /// This can be useful for synchronization between parent and child processes,
        /// because <see cref="CreateProcessWithLogonW"/> returns without waiting for the new process to finish its initialization.
        /// For example, the creating process would use <see cref="WaitForInputIdle"/>
        /// before trying to find a window that is associated with the new process.
        /// </para>
        /// <para>
        /// The preferred way to shut down a process is by using the <see cref="ExitProcess"/> function,
        /// because this function sends notification of approaching termination to all DLLs attached to the process.
        /// Other means of shutting down a process do not notify the attached DLLs.
        /// Note that when a thread calls <see cref="ExitProcess"/>,
        /// other threads of the process are terminated without an opportunity to execute any additional code
        /// (including the thread termination code of attached DLLs).
        /// For more information, see Terminating a Process.
        /// </para>
        /// <para>
        /// <see cref="CreateProcessWithLogonW"/> accesses the specified directory and executable image in the security context of the target user.
        /// If the executable image is on a network and a network drive letter is specified in the path,
        /// the network drive letter is not available to the target user, as network drive letters can be assigned for each logon.
        /// If a network drive letter is specified, this function fails.
        /// If the executable image is on a network, use the UNC path.
        /// </para>
        /// <para>
        /// There is a limit to the number of child processes that can be created by this function and run simultaneously.
        /// For example, on Windows XP, this limit is <see cref="MAXIMUM_WAIT_OBJECTS"/>*4.
        /// However, you may not be able to create this many processes due to system-wide quota limits.
        /// </para>
        /// <para>
        /// Windows XP with SP2,Windows Server 2003, or later:
        /// You cannot call <see cref="CreateProcessWithLogonW"/> from a process that is running under the "LocalSystem" account,
        /// because the function uses the logon SID in the caller token, and the token for the "LocalSystem" account does not contain this SID.
        /// As an alternative, use the <see cref="CreateProcessAsUser"/> and <see cref="LogonUser"/> functions.
        /// </para>
        /// <para>
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0500 or later.
        /// For more information, see Using the Windows Headers.
        /// </para>
        /// <para>
        /// Security Remarks
        /// </para>
        /// <para>
        /// The <paramref name="lpApplicationName"/> parameter can be <see cref="NULL"/>,
        /// and the executable name must be the first white space–delimited string in <paramref name="lpCommandLine"/>.
        /// If the executable or path name has a space in it,
        /// there is a risk that a different executable could be run because of the way the function parses spaces.
        /// Avoid the following example, because the function attempts to run "Program.exe", if it exists, instead of "MyApp.exe".
        /// </para>
        /// <code>
        /// LPTSTR szCmdline = _tcsdup(TEXT("C:\\Program Files\\MyApp -L -S"));
        /// CreateProcessWithLogonW(NULL, szCmdline, /* ... */);
        /// </code>
        /// <para>
        /// If a malicious user creates an application called "Program.exe" on a system,
        /// any program that incorrectly calls <see cref="CreateProcessWithLogonW"/> using the Program Files directory
        /// runs the malicious user application instead of the intended application.
        /// </para>
        /// <para>
        /// To avoid this issue, do not pass <see cref="NULL"/> for <paramref name="lpApplicationName"/>.
        /// If you pass <see cref="NULL"/> for <paramref name="lpApplicationName"/>,
        /// use quotation marks around the executable path in <paramref name="lpCommandLine"/>,
        /// as shown in the following example:
        /// </para>
        /// <code>
        /// LPTSTR szCmdline[] = _tcsdup(TEXT("\"C:\\Program Files\\MyApp\" -L -S"));
        /// CreateProcessWithLogonW(NULL, szCmdline, /*...*/);
        /// </code>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateProcessWithLogonW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CreateProcessWithLogonW([In] LPCWSTR lpUsername, [In] LPCWSTR lpDomain, [In] LPCWSTR lpPassword,
            [In] LogonFlags dwLogonFlags, [In] LPCWSTR lpApplicationName, [In] LPWSTR lpCommandLine, [In] ProcessCreationFlags dwCreationFlags,
            [In] LPVOID lpEnvironment, [In] LPCWSTR lpCurrentDirectory, [In] in STARTUPINFO lpStartupInfo, [Out] out PROCESS_INFORMATION lpProcessInformation);

        /// <summary>
        /// <para>
        /// Creates a new process and its primary thread.
        /// The new process runs in the security context of the specified token.
        /// It can optionally load the user profile for the specified user.
        /// </para>
        /// <para>
        /// The process that calls <see cref="CreateProcessWithTokenW"/> must have the <see cref="SE_IMPERSONATE_NAME"/> privilege.
        /// If this function fails with <see cref="ERROR_PRIVILEGE_NOT_HELD"/> (1314),
        /// use the <see cref="CreateProcessAsUser"/> or <see cref="CreateProcessWithLogonW"/> function instead.
        /// Typically, the process that calls <see cref="CreateProcessAsUser"/> must have the <see cref="SE_INCREASE_QUOTA_NAME"/> privilege
        /// and may require the <see cref="SE_ASSIGNPRIMARYTOKEN_NAME"/> privilege if the token is not assignable.
        /// <see cref="CreateProcessWithLogonW"/> requires no special privileges,
        /// but the specified user account must be allowed to log on interactively.
        /// Generally, it is best to use <see cref="CreateProcessWithLogonW"/> to create a process with alternate credentials.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-createprocesswithtokenw"/>
        /// </para>
        /// </summary>
        /// <param name="hToken">
        /// <para>
        /// A handle to the primary token that represents a user.
        /// The handle must have the <see cref="TOKEN_QUERY"/>, <see cref="TOKEN_DUPLICATE"/>, and <see cref="TOKEN_ASSIGN_PRIMARY"/> access rights.
        /// For more information, see Access Rights for Access-Token Objects.
        /// The user represented by the token must have read and execute access to the application
        /// specified by the <paramref name="lpApplicationName"/> or the <paramref name="lpCommandLine"/> parameter.
        /// </para>
        /// <para>
        /// To get a primary token that represents the specified user, call the <see cref="LogonUser"/> function.
        /// Alternatively, you can call the <see cref="DuplicateTokenEx"/> function to convert an impersonation token into a primary token.
        /// This allows a server application that is impersonating a client to create a process that has the security context of the client.
        /// </para>
        /// <para>
        /// Terminal Services:
        /// The caller's process always runs in the caller's session, not in the session specified in the token.
        /// To run a process in the session specified in the token, use the <see cref="CreateProcessAsUser"/> function.
        /// </para>
        /// </param>
        /// <param name="dwLogonFlags">
        /// <para>
        /// The logon option. This parameter can be zero or one of the following values.
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
        /// <see cref="LOGON_WITH_PROFILE"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Log on, then load the user's profile in the <see cref="HKEY_USERS"/> registry key.
        /// The function returns after the profile has been loaded.
        /// Loading the profile can be time-consuming, so it is best to use this value
        /// only if you must access the information in the <see cref="HKEY_CURRENT_USER"/> registry key.
        /// </para>
        /// <para>
        /// Windows Server 2003:
        /// The profile is unloaded after the new process has been terminated, regardless of whether it has created child processes.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="LOGON_NETCREDENTIALS_ONLY"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Log on, but use the specified credentials on the network only.
        /// The new process uses the same token as the caller, but the system creates a new logon session within LSA,
        /// and the process uses the specified credentials as the default credentials.
        /// </para>
        /// <para>
        /// This value can be used to create a process that uses a different set of credentials locally than it does remotely.
        /// This is useful in inter-domain scenarios where there is no trust relationship.
        /// </para>
        /// <para>
        /// The system does not validate the specified credentials.
        /// Therefore, the process can start, but it may not have access to network resources.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="lpApplicationName">
        /// <para>
        /// The name of the module to be executed.
        /// This module can be a Windows-based application.
        /// It can be some other type of module (for example, MS-DOS or OS/2) if the appropriate subsystem is available on the local computer.
        /// </para>
        /// <para>
        /// The string can specify the full path and file name of the module to execute or it can specify a partial name.
        /// In the case of a partial name, the function uses the current drive and current directory to complete the specification.
        /// The function will not use the search path.
        /// This parameter must include the file name extension; no default extension is assumed.
        /// </para>
        /// <para>
        /// The <paramref name="lpApplicationName"/> parameter can be <see cref="NULL"/>.
        /// In that case, the module name must be the first white space–delimited token in the <paramref name="lpCommandLine"/> string.
        /// If you are using a long file name that contains a space,
        /// use quoted strings to indicate where the file name ends and the arguments begin;
        /// otherwise, the file name is ambiguous.
        /// For example, consider the string "c:\program files\sub dir\program name".
        /// This string can be interpreted in a number of ways.
        /// The system tries to interpret the possibilities in the following order:
        /// </para>
        /// <para>
        /// c:\program.exe c:\program files\sub.exe c:\program files\sub dir\program.exe c:\program files\sub dir\program name.exe
        /// If the executable module is a 16-bit application, <paramref name="lpApplicationName"/> should be <see cref="NULL"/>,
        /// and the string pointed to by <paramref name="lpCommandLine"/> should specify the executable module as well as its arguments.
        /// </para>
        /// </param>
        /// <param name="lpCommandLine">
        /// <para>
        /// The command line to be executed.
        /// </para>
        /// <para>
        /// The maximum length of this string is 1024 characters.
        /// If <paramref name="lpApplicationName"/> is <see cref="NULL"/>,
        /// the module name portion of <paramref name="lpCommandLine"/> is limited to <see cref="MAX_PATH"/> characters.
        /// </para>
        /// <para>
        /// The function can modify the contents of this string.
        /// Therefore, this parameter cannot be a pointer to read-only memory (such as a const variable or a literal string).
        /// If this parameter is a constant string, the function may cause an access violation.
        /// </para>
        /// <para>
        /// The <paramref name="lpCommandLine"/> parameter can be <see cref="NULL"/>.
        /// In that case, the function uses the string pointed to by <paramref name="lpApplicationName"/> as the command line.
        /// </para>
        /// <para>
        /// If both <paramref name="lpApplicationName"/> and <paramref name="lpCommandLine"/> are non-<see cref="NULL"/>,
        /// *<paramref name="lpApplicationName"/> specifies the module to execute,
        /// and *<paramref name="lpCommandLine"/> specifies the command line.
        /// The new process can use <see cref="GetCommandLine"/> to retrieve the entire command line.
        /// Console processes written in C can use the argc and argv arguments to parse the command line.
        /// Because argv[0] is the module name, C programmers generally repeat the module name as the first token in the command line.
        /// </para>
        /// <para>
        /// If <paramref name="lpApplicationName"/> is <see cref="NULL"/>,
        /// the first white space–delimited token of the command line specifies the module name.
        /// If you are using a long file name that contains a space,
        /// use quoted strings to indicate where the file name ends and the arguments begin
        /// (see the explanation for the <paramref name="lpApplicationName"/> parameter).
        /// If the file name does not contain an extension, .exe is appended.
        /// Therefore, if the file name extension is .com, this parameter must include the .com extension.
        /// If the file name ends in a period (.) with no extension, or if the file name contains a path, .exe is not appended.
        /// If the file name does not contain a directory path, the system searches for the executable file in the following sequence:
        /// </para>
        /// <para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// The directory from which the application loaded.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The current directory for the parent process.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The 32-bit Windows system directory.
        /// Use the <see cref="GetSystemDirectory"/> function to get the path of this directory.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The 16-bit Windows system directory.
        /// There is no function that obtains the path of this directory, but it is searched.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The Windows directory.
        /// Use the <see cref="GetWindowsDirectory"/> function to get the path of this directory.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The directories that are listed in the PATH environment variable.
        /// Note that this function does not search the per-application path specified by the App Paths registry key.
        /// To include this per-application path in the search sequence, use the <see cref="ShellExecute"/> function.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The system adds a null character to the command line string to separate the file name from the arguments.
        /// This divides the original string into two strings for internal processing.
        /// </para>
        /// </param>
        /// <param name="dwCreationFlags">
        /// <para>
        /// The flags that control how the process is created.
        /// The <see cref="CREATE_DEFAULT_ERROR_MODE"/>, <see cref="CREATE_NEW_CONSOLE"/>,
        /// and <see cref="CREATE_NEW_PROCESS_GROUP"/> flags are enabled by default.
        /// For a list of values, see Process Creation Flags.
        /// </para>
        /// <para>
        /// This parameter also controls the new process's priority class,
        /// which is used to determine the scheduling priorities of the process's threads.
        /// For a list of values, see <see cref="GetPriorityClass"/>.
        /// If none of the priority class flags is specified, the priority class defaults to <see cref="NORMAL_PRIORITY_CLASS"/>
        /// unless the priority class of the creating process is <see cref="IDLE_PRIORITY_CLASS"/> or <see cref="BELOW_NORMAL_PRIORITY_CLASS"/>.
        /// In this case, the child process receives the default priority class of the calling process.
        /// </para>
        /// <para>
        /// If the <paramref name="dwCreationFlags"/> parameter has a value of 0:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The process gets the default error mode, creates a new console and creates a new process group.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The environment block for the new process is assumed to contain ANSI characters
        /// (see <paramref name="lpEnvironment"/> parameter for additional information).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A 16-bit Windows-based application runs in a shared Virtual DOS machine (VDM).
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpEnvironment">
        /// <para>
        /// A pointer to an environment block for the new process.
        /// If this parameter is <see cref="NULL"/>, the new process uses an environment
        /// created from the profile of the user specified by lpUsername.
        /// </para>
        /// <para>
        /// An environment block consists of a null-terminated block of null-terminated strings.
        /// Each string is in the following form:
        /// </para>
        /// <para>
        /// name=value
        /// </para>
        /// <para>
        /// Because the equal sign (=) is used as a separator, it must not be used in the name of an environment variable.
        /// </para>
        /// <para>
        /// An environment block can contain Unicode or ANSI characters.
        /// If the environment block pointed to by <paramref name="lpEnvironment"/> contains Unicode characters,
        /// be sure that <paramref name="dwCreationFlags"/> includes <see cref="CREATE_UNICODE_ENVIRONMENT"/>.
        /// </para>
        /// <para>
        /// An ANSI environment block is terminated by two zero bytes: one for the last string, one more to terminate the block.
        /// A Unicode environment block is terminated by four zero bytes: two for the last string and two more to terminate the block.
        /// </para>
        /// <para>
        /// To retrieve a copy of the environment block for a specific user, use the <see cref="CreateEnvironmentBlock"/> function.
        /// </para>
        /// </param>
        /// <param name="lpCurrentDirectory">
        /// <para>
        /// The full path to the current directory for the process. The string can also specify a UNC path.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NULL"/>, the new process will have the same current drive and directory as the calling process.
        /// (This feature is provided primarily for shells that need to start an application and specify its initial drive and working directory.)
        /// </para>
        /// </param>
        /// <param name="lpStartupInfo">
        /// <para>
        /// A pointer to a <see cref="STARTUPINFO"/> or <see cref="STARTUPINFOEX"/> structure.
        /// </para>
        /// <para>
        /// If the <see cref="STARTUPINFO.lpDesktop"/> member is <see cref="NULL"/> or an empty string,
        /// the new process inherits the desktop and window station of its parent process.
        /// The function adds permission for the specified user account to the inherited window station and desktop.
        /// Otherwise, if this member specifies a desktop, it is the responsibility of the application
        /// to add permission for the specified user account to the specified window station and desktop, even for WinSta0\Default.
        /// </para>
        /// <para>
        /// Handles in <see cref="STARTUPINFO"/> or <see cref="STARTUPINFOEX"/> must
        /// be closed with <see cref="CloseHandle"/> when they are no longer needed.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// If the <see cref="STARTUPINFO.dwFlags"/> member of the <see cref="STARTUPINFO"/> structure
        /// specifies <see cref="STARTF_USESTDHANDLES"/>, the standard handle fields are copied unchanged to the child process without validation.
        /// The caller is responsible for ensuring that these fields contain valid handle values.
        /// Incorrect values can cause the child process to misbehave or crash.
        /// Use the Application Verifier runtime verification tool to detect invalid handles.
        /// </para>
        /// </param>
        /// <param name="lpProcessInformation">
        /// <para>
        /// A pointer to a <see cref="PROCESS_INFORMATION"/> structure
        /// that receives identification information for the new process, including a handle to the process.
        /// </para>
        /// <para>
        /// Handles in <see cref="PROCESS_INFORMATION"/> must
        /// be closed with the <see cref="CloseHandle"/> function when they are no longer needed.
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
        /// <para>
        /// Note that the function returns before the process has finished initialization.
        /// If a required DLL cannot be located or fails to initialize, the process is terminated.
        /// To get the termination status of a process, call <see cref="GetExitCodeProcess"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// By default, <see cref="CreateProcessWithTokenW"/> does not load the specified user's profile
        /// into the <see cref="HKEY_USERS"/> registry key.
        /// This means that access to information in the <see cref="HKEY_CURRENT_USER"/> registry key
        /// may not produce results consistent with a normal interactive logon.
        /// It is your responsibility to load the user's registry hive into <see cref="HKEY_USERS"/>
        /// by either using <see cref="LOGON_WITH_PROFILE"/>,
        /// or by calling the <see cref="LoadUserProfile"/> function before calling this function.
        /// </para>
        /// <para>
        /// If the <paramref name="lpEnvironment"/> parameter is <see cref="NULL"/>,
        /// the new process uses an environment block created from the profile of the user specified by lpUserName.
        /// If the HOMEDRIVE and HOMEPATH variables are not set,
        /// <see cref="CreateProcessWithTokenW"/> modifies the environment block to use the drive and path of the user's working directory.
        /// </para>
        /// <para>
        /// When created, the new process and thread handles receive full access rights
        /// (<see cref="PROCESS_ALL_ACCESS"/> and <see cref="THREAD_ALL_ACCESS"/>).
        /// For either handle, if a security descriptor is not provided,
        /// the handle can be used in any function that requires an object handle of that type.
        /// When a security descriptor is provided, an access check is performed on all subsequent uses of the handle before access is granted.
        /// If access is denied, the requesting process cannot use the handle to gain access to the process or thread.
        /// </para>
        /// <para>
        /// To retrieve a security token, pass the process handle
        /// in the <see cref="PROCESS_INFORMATION"/> structure to the <see cref="OpenProcessToken"/> function.
        /// </para>
        /// <para>
        /// The process is assigned a process identifier.
        /// The identifier is valid until the process terminates.
        /// It can be used to identify the process, or specified in the <see cref="OpenProcess"/> function to open a handle to the process.
        /// The initial thread in the process is also assigned a thread identifier.
        /// It can be specified in the <see cref="OpenThread"/> function to open a handle to the thread.
        /// The identifier is valid until the thread terminates and can be used to uniquely identify the thread within the system.
        /// These identifiers are returned in <see cref="PROCESS_INFORMATION"/>.
        /// </para>
        /// <para>
        /// The calling thread can use the <see cref="WaitForInputIdle"/> function to wait
        /// until the new process has finished its initialization and is waiting for user input with no input pending.
        /// This can be useful for synchronization between parent and child processes,
        /// because <see cref="CreateProcessWithTokenW"/> returns without waiting for the new process to finish its initialization.
        /// For example, the creating process would use <see cref="WaitForInputIdle"/>
        /// before trying to find a window associated with the new process.
        /// </para>
        /// <para>
        /// The preferred way to shut down a process is by using the <see cref="ExitProcess"/> function,
        /// because this function sends notification of approaching termination to all DLLs attached to the process.
        /// Other means of shutting down a process do not notify the attached DLLs.
        /// Note that when a thread calls <see cref="ExitProcess"/>,
        /// other threads of the process are terminated without an opportunity to execute any additional code
        /// (including the thread termination code of attached DLLs).
        /// For more information, see Terminating a Process.
        /// </para>
        /// <para>
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0500 or later.
        /// For more information, see Using the Windows Headers.
        /// </para>
        /// <para>
        /// Security Remarks
        /// </para>
        /// <para>
        /// The <paramref name="lpApplicationName"/> parameter can be <see cref="NULL"/>,
        /// in which case the executable name must be the first white space–delimited string in <paramref name="lpCommandLine"/>.
        /// If the executable or path name has a space in it,
        /// there is a risk that a different executable could be run because of the way the function parses spaces.
        /// The following example is dangerous because the function will attempt to run "Program.exe",
        /// if it exists, instead of "MyApp.exe".
        /// </para>
        /// <code>
        /// LPTSTR szCmdline = _tcsdup(TEXT("C:\\Program Files\\MyApp -L -S"));
        /// CreateProcessWithTokenW(NULL, szCmdline, /* ... */);
        /// </code>
        /// <para>
        /// If a malicious user were to create an application called "Program.exe" on a system,
        /// any program that incorrectly calls <see cref="CreateProcessWithTokenW"/> using the Program Files directory
        /// will run this application instead of the intended application.
        /// </para>
        /// <para>
        /// To avoid this problem, do not pass NULL for <paramref name="lpApplicationName"/>.
        /// If you do pass <see cref="NULL"/> for <paramref name="lpApplicationName"/>,
        /// use quotation marks around the executable path in <paramref name="lpCommandLine"/>,
        /// as shown in the example below.
        /// </para>
        /// <code>
        /// LPTSTR szCmdline[] = _tcsdup(TEXT("\"C:\\Program Files\\MyApp\" -L -S"));
        /// CreateProcessWithTokenW(NULL, szCmdline, /*...*/);
        /// </code>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateProcessWithTokenW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CreateProcessWithTokenW([In] HANDLE hToken, [In] LogonFlags dwLogonFlags, [In] LPCWSTR lpApplicationName,
            [In] LPWSTR lpCommandLine, [In] ProcessCreationFlags dwCreationFlags, [In] LPVOID lpEnvironment, [In] LPCWSTR lpCurrentDirectory,
            [In] in STARTUPINFO lpStartupInfo, [Out] out PROCESS_INFORMATION lpProcessInformation);
    }
}
