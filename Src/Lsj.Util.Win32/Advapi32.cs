using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.WaitResult;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.LogonFlags;
using static Lsj.Util.Win32.Enums.ProcessAccessRights;
using static Lsj.Util.Win32.Enums.ProcessCreationFlags;
using static Lsj.Util.Win32.Enums.ProcessPriorityClasses;
using static Lsj.Util.Win32.Enums.ThreadAccessRights;
using static Lsj.Util.Win32.Enums.TOKEN_INFORMATION_CLASS;
using static Lsj.Util.Win32.Enums.TOKEN_TYPE;
using static Lsj.Util.Win32.Enums.TokenAccessRights;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.User32;
using static Lsj.Util.Win32.Userenv;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Advapi32.dll
    /// </summary>
    public static class Advapi32
    {
        /// <summary>
        /// <para>
        /// Creates a new process and its primary thread. Then the new process runs the specified executable file in the security context
        /// of the specified credentials (user, domain, and password).
        /// It can optionally load the user profile for a specified user.
        /// This function is similar to the <see cref="CreateProcessAsUser"/> and <see cref="CreateProcessWithTokenW"/> functions,
        /// except that the caller does not need to call the <see cref="LogonUser"/> function to authenticate the user and get a token.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-createprocesswithlogonw
        /// </para>
        /// </summary>
        /// <param name="lpUsername">
        /// The name of the user.
        /// This is the name of the user account to log on to.
        /// If you use the UPN format, user@DNS_domain_name, the lpDomain parameter must be <see langword="null"/>.
        /// The user account must have the Log On Locally permission on the local computer.
        /// This permission is granted to all users on workstations and servers, but only to administrators on domain controllers.
        /// </param>
        /// <param name="lpDomain">
        /// The name of the domain or server whose account database contains the <paramref name="lpUsername"/> account.
        /// If this parameter is <see langword="null"/>, the user name must be specified in UPN format.
        /// </param>
        /// <param name="lpPassword">
        /// The clear-text password for the <paramref name="lpUsername"/> account.
        /// </param>
        /// <param name="dwLogonFlags">
        /// The logon option. This parameter can be 0 (zero) or one of the following values.
        /// <see cref="LOGON_WITH_PROFILE"/>, <see cref="LOGON_NETCREDENTIALS_ONLY"/>
        /// </param>
        /// <param name="lpApplicationName">
        /// The name of the module to be executed. This module can be a Windows-based application.
        /// It can be some other type of module (for example, MS-DOS or OS/2) if the appropriate subsystem is available on the local computer.
        /// The string can specify the full path and file name of the module to execute or it can specify a partial name.
        /// In the case of a partial name, the function uses the current drive and current directory to complete the specification.
        /// The function will not use the search path.
        /// This parameter must include the file name extension; no default extension is assumed.
        /// The <paramref name="lpApplicationName"/> parameter can be <see langword="null"/>.
        /// In that case, the module name must be the first white space–delimited token in the <paramref name="lpCommandLine"/> string.
        /// If you are using a long file name that contains a space, use quoted strings to indicate where the file name ends and the arguments begin;
        /// otherwise, the file name is ambiguous.
        /// For example, consider the string "c:\program files\sub dir\program name".
        /// This string can be interpreted in a number of ways.
        /// The system tries to interpret the possibilities in the following order:
        /// c:\program.exe c:\program files\sub.exe c:\program files\sub dir\program.exe c:\program files\sub dir\program name.exe
        /// If the executable module is a 16-bit application, <paramref name="lpApplicationName"/> should be NULL,
        /// and the string pointed to by <paramref name="lpCommandLine"/> should specify the executable module as well as its arguments.
        /// </param>
        /// <param name="lpCommandLine">
        /// The command line to be executed.
        /// The maximum length of this string is 1024 characters.
        /// If lpApplicationName is <see langword="null"/>,
        /// the module name portion of <paramref name="lpCommandLine"/> is limited to <see cref="MAX_PATH"/> characters.
        /// The function can modify the contents of this string.
        /// Therefore, this parameter cannot be a pointer to read-only memory (such as a const variable or a literal string).
        /// If this parameter is a constant string, the function may cause an access violation.
        /// The <paramref name="lpCommandLine"/> parameter can be <see langword="null"/>,
        /// and the function uses the string pointed to by <paramref name="lpApplicationName"/> as the command line.
        /// If both <paramref name="lpApplicationName"/> and <paramref name="lpCommandLine"/> are non-NULL,
        /// the null-terminated string pointed to by <paramref name="lpApplicationName"/> specifies the module to execute,
        /// and the null-terminated string pointed to by <paramref name="lpCommandLine"/> specifies the command line.
        /// The new process can use <see cref="GetCommandLine"/> to retrieve the entire command line.
        /// Console processes written in C can use the argc and argv arguments to parse the command line.
        /// Because argv[0] is the module name, C programmers generally repeat the module name as the first token in the command line.
        /// If <paramref name="lpApplicationName"/> is <see langword="null"/>,
        /// the first white space–delimited token of the command line specifies the module name.
        /// If you are using a long file name that contains a space, use quoted strings to indicate where the file name ends and
        /// the arguments begin (see the explanation for the <paramref name="lpApplicationName"/> parameter).
        /// If the file name does not contain an extension, .exe is appended.
        /// Therefore, if the file name extension is .com, this parameter must include the .com extension.
        /// If the file name ends in a period (.) with no extension, or if the file name contains a path, .exe is not appended.
        /// If the file name does not contain a directory path, the system searches for the executable file in the following sequence:
        /// 1.The directory from which the application loaded.
        /// 2. The current directory for the parent process.
        /// 3. The 32-bit Windows system directory. Use the <see cref="GetSystemDirectory"/> function to get the path of this directory.
        /// 4.The 16-bit Windows system directory. 
        /// There is no function that obtains the path of this directory, but it is searched. The name of this directory is System.
        /// 5. The Windows directory. Use the <see cref="GetWindowsDirectory"/> function to get the path of this directory.
        /// 6.The directories that are listed in the PATH environment variable.
        /// Note that this function does not search the per-application path specified by the App Paths registry key.
        /// To include this per-application path in the search sequence, use the <see cref="ShellExecute"/> function.
        /// The system adds a terminating null character to the command-line string to separate the file name from the arguments.
        /// This divides the original string into two strings for internal processing.
        /// </param>
        /// <param name="dwCreationFlags">
        /// The flags that control how the process is created.
        /// The <see cref="CREATE_DEFAULT_ERROR_MODE"/>, <see cref="CREATE_NEW_CONSOLE"/>,
        /// and <see cref="CREATE_NEW_PROCESS_GROUP"/> flags are enabled by default— even if you do not set the flag,
        /// the system functions as if it were set. You can specify additional flags as noted.
        /// <see cref="CREATE_DEFAULT_ERROR_MODE"/>, <see cref="CREATE_NEW_CONSOLE"/>,
        /// <see cref="CREATE_NEW_PROCESS_GROUP"/>, <see cref="CREATE_SEPARATE_WOW_VDM"/>,
        /// <see cref="CREATE_SUSPENDED"/>, <see cref="CREATE_UNICODE_ENVIRONMENT"/>
        /// This parameter also controls the new process's priority class, which is used to determine the scheduling priorities of the process's threads.
        /// For a list of values, see <see cref="GetPriorityClass"/>.
        /// If none of the priority class flags is specified, the priority class defaults to <see cref="NORMAL_PRIORITY_CLASS"/>
        /// unless the priority class of the creating process is <see cref="IDLE_PRIORITY_CLASS"/>
        /// or <see cref="BELOW_NORMAL_PRIORITY_CLASS"/>.
        /// In this case, the child process receives the default priority class of the calling process.
        /// </param>
        /// <param name="lpEnvironment">
        /// A pointer to an environment block for the new process.
        /// If this parameter is <see cref="IntPtr.Zero"/>, the new process uses an environment created
        /// from the profile of the user specified by <paramref name="lpUsername"/>.
        /// An environment block consists of a null-terminated block of null-terminated strings. Each string is in the following form:
        /// name=value
        /// Because the equal sign (=) is used as a separator, it must not be used in the name of an environment variable.
        /// An environment block can contain Unicode or ANSI characters.
        /// If the environment block pointed to by <paramref name="lpEnvironment"/> contains Unicode characters,
        /// ensure that <paramref name="dwCreationFlags"/> includes <see cref="CREATE_UNICODE_ENVIRONMENT"/>.
        /// If this parameter is <see cref="IntPtr.Zero"/> and the environment block of the parent process contains Unicode characters,
        /// you must also ensure that <paramref name="dwCreationFlags"/> includes <see cref="CREATE_UNICODE_ENVIRONMENT"/>.
        /// An ANSI environment block is terminated by two 0 (zero) bytes: one for the last string and one more to terminate the block.
        /// A Unicode environment block is terminated by four zero bytes: two for the last string and two more to terminate the block.
        /// To retrieve a copy of the environment block for a specific user, use the <see cref="CreateEnvironmentBlock"/> function.
        /// </param>
        /// <param name="lpCurrentDirectory">
        /// The full path to the current directory for the process. The string can also specify a UNC path.
        /// If this parameter is <see langword="null"/>, the new process has the same current drive and directory as the calling process.
        /// This feature is provided primarily for shells that need to start an application, and specify its initial drive and working directory.
        /// </param>
        /// <param name="lpStartupInfo">
        /// A pointer to a <see cref="STARTUPINFO"/> structure.
        /// The application must add permission for the specified user account to the specified window station and desktop, even for WinSta0\Default.
        /// If the <see cref="STARTUPINFO.lpDesktop"/> member is <see cref="IntPtr.Zero"/> or an empty string,
        /// the new process inherits the desktop and window station of its parent process.
        /// The application must add permission for the specified user account to the inherited window station and desktop.
        /// Windows XP:  <see cref="CreateProcessWithLogonW"/> adds permission for the specified user account to the inherited window station and desktop.
        /// Handles in <see cref="STARTUPINFO"/> must be closed with <see cref="CloseHandle"/> when they are no longer needed.
        /// If the <see cref="STARTUPINFO.dwFlags"/> member of the <see cref="STARTUPINFO"/> structure
        /// specifies <see cref="STARTUPINFOFlags.STARTF_USESTDHANDLES"/>, 
        /// the standard handle fields are copied unchanged to the child process without validation.
        /// The caller is responsible for ensuring that these fields contain valid handle values.
        /// Incorrect values can cause the child process to misbehave or crash.
        /// Use the Application Verifier runtime verification tool to detect invalid handles.
        /// </param>
        /// <param name="lpProcessInformation">
        /// A pointer to a <see cref="PROCESS_INFORMATION"/> structure that receives identification information for the new process,
        /// including a handle to the process.
        /// Handles in <see cref="PROCESS_INFORMATION"/> must be closed with the <see cref="CloseHandle"/> function when they are not needed.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="BOOL.TRUE"/>
        /// If the function fails, the return value is <see cref="BOOL.FALSE"/>
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// Note that the function returns before the process has finished initialization.
        /// If a required DLL cannot be located or fails to initialize, the process is terminated.
        /// To get the termination status of a process, call <see cref="GetExitCodeProcess"/>.
        /// </returns>
        /// <remarks>
        /// By default, <see cref="CreateProcessWithLogonW"/> does not load the specified user profile into the HKEY_USERS registry key.
        /// This means that access to information in the HKEY_CURRENT_USER registry key may not produce results that are consistent
        /// with a normal interactive logon.
        /// It is your responsibility to load the user registry hive into HKEY_USERS before calling <see cref="CreateProcessWithLogonW"/>,
        /// by using <see cref="LOGON_WITH_PROFILE"/>, or by calling the <see cref="LoadUserProfile"/> function.
        /// If the <paramref name="lpEnvironment"/> parameter is <see cref="IntPtr.Zero"/>,
        /// the new process uses an environment block created from the profile of the user specified by <paramref name="lpUsername"/>.
        /// If the HOMEDRIVE and HOMEPATH variables are not set, <see cref="CreateProcessWithLogonW"/> modifies the environment block
        /// to use the drive and path of the user's working directory.
        /// When created, the new process and thread handles receive full access rights
        /// (<see cref="PROCESS_ALL_ACCESS"/> and <see cref="THREAD_ALL_ACCESS"/>).
        /// For either handle, if a security descriptor is not provided, the handle can be used in any function that requires an object handle of that type.
        /// When a security descriptor is provided, an access check is performed on all subsequent uses of the handle before access is granted.
        /// If access is denied, the requesting process cannot use the handle to gain access to the process or thread.
        /// To retrieve a security token, pass the process handle in the <see cref="PROCESS_INFORMATION"/> structure
        /// to the <see cref="OpenProcessToken"/> function.
        /// The process is assigned a process identifier. The identifier is valid until the process terminates.
        /// It can be used to identify the process, or it can be specified in the <see cref="OpenProcess"/> function to open a handle to the process.
        /// The initial thread in the process is also assigned a thread identifier.
        /// It can be specified in the <see cref="OpenThread"/> function to open a handle to the thread.
        /// The identifier is valid until the thread terminates and can be used to uniquely identify the thread within the system.
        /// These identifiers are returned in <see cref="PROCESS_INFORMATION"/>.
        /// The calling thread can use the <see cref="WaitForInputIdle"/> function to wait until the new process has completed
        /// its initialization and is waiting for user input with no input pending.
        /// This can be useful for synchronization between parent and child processes
        /// , because <see cref="CreateProcessWithLogonW"/> returns without waiting for the new process to finish its initialization.
        /// For example, the creating process would use <see cref="WaitForInputIdle"/> before trying to
        /// find a window that is associated with the new process.
        /// The preferred way to shut down a process is by using the <see cref="ExitProcess"/> function,
        /// because this function sends notification of approaching termination to all DLLs attached to the process.
        /// Other means of shutting down a process do not notify the attached DLLs.
        /// Note that when a thread calls <see cref="ExitProcess"/>, other threads of the process are terminated 
        /// without an opportunity to execute any additional code (including the thread termination code of attached DLLs).
        /// For more information, see Terminating a Process.
        /// <see cref="CreateProcessWithLogonW"/> accesses the specified directory and executable image in the security context of the target user.
        /// If the executable image is on a network and a network drive letter is specified in the path,
        /// the network drive letter is not available to the target user, as network drive letters can be assigned for each logon.
        /// If a network drive letter is specified, this function fails. If the executable image is on a network, use the UNC path.
        /// There is a limit to the number of child processes that can be created by this function and run simultaneously.
        /// For example, on Windows XP, this limit is <see cref="MAXIMUM_WAIT_OBJECTS"/>*4.
        /// However, you may not be able to create this many processes due to system-wide quota limits.
        /// Windows XP with SP2,Windows Server 2003, or later:  You cannot call <see cref="CreateProcessWithLogonW"/> from a process
        /// that is running under the "LocalSystem" account, because the function uses the logon SID in the caller token,
        /// and the token for the "LocalSystem" account does not contain this SID.
        /// As an alternative, use the <see cref="CreateProcessAsUser"/> and <see cref="LogonUser"/> functions.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0500 or later.
        /// For more information, see Using the Windows Headers.
        /// 
        /// Security Remarks
        /// The first parameter, <paramref name="lpApplicationName"/>, can be <see langword="null"/>,
        /// in which case the executable name must be in the white space–delimited string pointed to by <paramref name="lpCommandLine"/>.
        /// If the executable or path name has a space in it, there is a risk that a different executable
        /// could be run because of the way the function parses spaces.
        /// The following example is dangerous because the function will attempt to run "Program.exe", if it exists, instead of "MyApp.exe".
        /// <code>
        /// LPTSTR szCmdline = _tcsdup(TEXT("C:\\Program Files\\MyApp -L -S"));
        /// CreateProcessWithLogonW(NULL, szCmdline, /* ... */);
        /// </code>
        /// If a malicious user were to create an application called "Program.exe" on a system,
        /// any program that incorrectly calls <see cref="CreateProcessWithLogonW"/> using the Program Files directory will run this application
        /// instead of the intended application.
        /// To avoid this problem, do not pass <see langword="null"/> for <paramref name="lpApplicationName"/>.
        /// If you do pass <see langword="null"/> for <paramref name="lpApplicationName"/>,
        /// use quotation marks around the executable path in <paramref name="lpCommandLine"/>, as shown in the example below.
        /// <code>
        /// LPTSTR szCmdline[] = _tcsdup(TEXT("\"C:\\Program Files\\MyApp\" -L -S"));
        /// CreateProcessWithLogonW(NULL, szCmdline, /*...*/);
        /// </code>
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateProcessWithLogonW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CreateProcessWithLogonW([MarshalAs(UnmanagedType.LPWStr)][In]string lpUsername,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpDomain, [MarshalAs(UnmanagedType.LPWStr)][In]string lpPassword,
            [In]LogonFlags dwLogonFlags, [MarshalAs(UnmanagedType.LPWStr)][In]string lpApplicationName,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpCommandLine, [In]ProcessCreationFlags dwCreationFlags,
            [In]IntPtr lpEnvironment, [MarshalAs(UnmanagedType.LPWStr)][In]string lpCurrentDirectory,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(AlternativeStructObjectMarshaler<STARTUPINFO, STARTUPINFOEX>))]
            [In]AlternativeStructObject<STARTUPINFO, STARTUPINFOEX> lpStartupInfo, [Out]out PROCESS_INFORMATION lpProcessInformation);


        /// <summary>
        /// <para>
        /// Creates a new process and its primary thread. The new process runs in the security context of the specified token.
        /// It can optionally load the user profile for the specified user.
        /// The process that calls CreateProcessWithTokenW must have the SE_IMPERSONATE_NAME privilege.
        /// If this function fails with <see cref="SystemErrorCodes.ERROR_PRIVILEGE_NOT_HELD"/>, use the <see cref="CreateProcessAsUser"/>
        /// or <see cref="CreateProcessWithLogonW"/> function instead.
        /// Typically, the process that calls <see cref="CreateProcessAsUser"/> must have the SE_INCREASE_QUOTA_NAME privilege
        /// and may require the SE_ASSIGNPRIMARYTOKEN_NAME privilege if the token is not assignable.
        /// <see cref="CreateProcessWithLogonW"/> requires no special privileges, but the specified user account must be allowed to log on interactively.
        /// Generally, it is best to use <see cref="CreateProcessWithLogonW"/> to create a process with alternate credentials.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-createprocesswithtokenw
        /// </para>
        /// </summary>
        /// <param name="hToken">
        /// A handle to the primary token that represents a user.
        /// The handle must have the <see cref="TOKEN_QUERY"/>, <see cref="TOKEN_DUPLICATE"/>, and <see cref="TOKEN_ASSIGN_PRIMARY"/> access rights.
        /// For more information, see Access Rights for Access-Token Objects.
        /// The user represented by the token must have read and execute access to the application specified
        /// by the <paramref name="lpApplicationName"/> or the <paramref name="lpCommandLine"/> parameter.
        /// To get a primary token that represents the specified user, call the LogonUser function.
        /// Alternatively, you can call the <see cref="DuplicateTokenEx"/> function to convert an impersonation token into a primary token.
        /// This allows a server application that is impersonating a client to create a process that has the security context of the client.
        /// Terminal Services:  The process is run in the session specified in the token.
        /// By default, this is the same session that called <see cref="LogonUser"/>.
        /// To change the session, use the <see cref="SetTokenInformation"/> function.
        /// </param>
        /// <param name="dwLogonFlags">
        /// The logon option. This parameter can be zero or one of the following values.
        /// <see cref="LOGON_WITH_PROFILE"/>, <see cref="LOGON_NETCREDENTIALS_ONLY"/>
        /// </param>
        /// <param name="lpApplicationName">
        /// The name of the module to be executed. This module can be a Windows-based application.
        /// It can be some other type of module (for example, MS-DOS or OS/2) if the appropriate subsystem is available on the local computer.
        /// The string can specify the full path and file name of the module to execute or it can specify a partial name.
        /// In the case of a partial name, the function uses the current drive and current directory to complete the specification.
        /// The function will not use the search path. This parameter must include the file name extension; no default extension is assumed.
        /// The <paramref name="lpApplicationName"/> parameter can be <see langword="null"/>.
        /// In that case, the module name must be the first white space–delimited token in the <paramref name="lpCurrentDirectory"/> string.
        /// If you are using a long file name that contains a space, use quoted strings to indicate where the file name ends and the arguments begin;
        /// otherwise, the file name is ambiguous.
        /// For example, consider the string "c:\program files\sub dir\program name".
        /// This string can be interpreted in a number of ways.
        /// The system tries to interpret the possibilities in the following order:
        /// c:\program.exe c:\program files\sub.exe c:\program files\sub dir\program.exe c:\program files\sub dir\program name.exe
        /// If the executable module is a 16-bit application, <paramref name="lpApplicationName"/> should be <see langword="null"/>,
        /// and the string pointed to by <paramref name="lpCommandLine"/> should specify the executable module as well as its arguments.
        /// </param>
        /// <param name="lpCommandLine">
        /// The command line to be executed.
        /// The maximum length of this string is 1024 characters.
        /// If <paramref name="lpApplicationName"/> is <see langword="null"/>, the module name
        /// portion of <paramref name="lpCommandLine"/> is limited to <see cref="MAX_PATH"/> characters.
        /// The function can modify the contents of this string.
        /// Therefore, this parameter cannot be a pointer to read-only memory (such as a const variable or a literal string).
        /// If this parameter is a constant string, the function may cause an access violation.
        /// The <paramref name="lpCommandLine"/> parameter can be <see langword="null"/>.
        /// In that case, the function uses the string pointed to by <paramref name="lpApplicationName"/> as the command line.
        /// If both <paramref name="lpApplicationName"/> and <paramref name="lpCommandLine"/> are non-NULL,
        /// <paramref name="lpApplicationName"/> specifies the module to execute, and <paramref name="lpCommandLine"/> specifies the command line. 
        /// The new process can use <see cref="GetCommandLine"/> to retrieve the entire command line.
        /// Console processes written in C can use the argc and argv arguments to parse the command line.
        /// Because argv[0] is the module name, C programmers generally repeat the module name as the first token in the command line.
        /// If <paramref name="lpApplicationName"/> is <see langword="null"/>,
        /// the first white space–delimited token of the command line specifies the module name.
        /// If you are using a long file name that contains a space, use quoted strings to indicate
        /// where the file name ends and the arguments begin (see the explanation for the <paramref name="lpApplicationName"/> parameter).
        /// If the file name does not contain an extension, .exe is appended.
        /// Therefore, if the file name extension is .com, this parameter must include the .com extension.
        /// If the file name ends in a period (.) with no extension, or if the file name contains a path, .exe is not appended.
        /// If the file name does not contain a directory path, the system searches for the executable file in the following sequence:
        /// 1. The directory from which the application loaded.
        /// 2. The current directory for the parent process.
        /// 3. The 32-bit Windows system directory. Use the <see cref="GetSystemDirectory"/> function to get the path of this directory.
        /// 4. The 16-bit Windows system directory. There is no function that obtains the path of this directory, but it is searched.
        /// 5. The Windows directory. Use the <see cref="GetWindowsDirectory"/> function to get the path of this directory.
        /// 6. The directories that are listed in the PATH environment variable.
        /// Note that this function does not search the per-application path specified by the App Paths registry key.
        /// To include this per-application path in the search sequence, use the <see cref="ShellExecute"/> function.
        /// The system adds a null character to the command line string to separate the file name from the arguments.
        /// This divides the original string into two strings for internal processing.
        /// </param>
        /// <param name="dwCreationFlags">
        /// The flags that control how the process is created.
        /// The <see cref="CREATE_DEFAULT_ERROR_MODE"/>, <see cref="CREATE_NEW_CONSOLE"/>,
        /// and <see cref="CREATE_NEW_PROCESS_GROUP"/> flags are enabled by default— even if you do not set the flag,
        /// the system functions as if it were set. You can specify additional flags as noted.
        /// <see cref="CREATE_DEFAULT_ERROR_MODE"/>, <see cref="CREATE_NEW_CONSOLE"/>,
        /// <see cref="CREATE_NEW_PROCESS_GROUP"/>, <see cref="CREATE_SEPARATE_WOW_VDM"/>,
        /// <see cref="CREATE_SUSPENDED"/>, <see cref="CREATE_UNICODE_ENVIRONMENT"/>,
        /// <see cref="EXTENDED_STARTUPINFO_PRESENT"/>
        /// This parameter also controls the new process's priority class, which is used to determine the scheduling priorities of the process's threads.
        /// For a list of values, see <see cref="GetPriorityClass"/>.
        /// If none of the priority class flags is specified, the priority class defaults to <see cref="NORMAL_PRIORITY_CLASS"/>
        /// unless the priority class of the creating process is <see cref="IDLE_PRIORITY_CLASS"/>
        /// or <see cref="BELOW_NORMAL_PRIORITY_CLASS"/>.
        /// In this case, the child process receives the default priority class of the calling process.
        /// </param>
        /// <param name="lpEnvironment">
        /// A pointer to an environment block for the new process.
        /// If this parameter is <see cref="IntPtr.Zero"/>, the new process uses an environment created
        /// from the profile of the user specified by <paramref name="hToken"/>.
        /// An environment block consists of a null-terminated block of null-terminated strings. Each string is in the following form:
        /// name=value
        /// Because the equal sign (=) is used as a separator, it must not be used in the name of an environment variable.
        /// An environment block can contain Unicode or ANSI characters.
        /// If the environment block pointed to by <paramref name="lpEnvironment"/> contains Unicode characters,
        /// ensure that <paramref name="dwCreationFlags"/> includes <see cref="CREATE_UNICODE_ENVIRONMENT"/>.
        /// If this parameter is <see cref="IntPtr.Zero"/> and the environment block of the parent process contains Unicode characters,
        /// you must also ensure that <paramref name="dwCreationFlags"/> includes <see cref="CREATE_UNICODE_ENVIRONMENT"/>.
        /// An ANSI environment block is terminated by two 0 (zero) bytes: one for the last string and one more to terminate the block.
        /// A Unicode environment block is terminated by four zero bytes: two for the last string and two more to terminate the block.
        /// To retrieve a copy of the environment block for a specific user, use the <see cref="CreateEnvironmentBlock"/> function.
        /// </param>
        /// <param name="lpCurrentDirectory">
        /// The full path to the current directory for the process. The string can also specify a UNC path.
        /// If this parameter is <see langword="null"/>, the new process has the same current drive and directory as the calling process.
        /// This feature is provided primarily for shells that need to start an application, and specify its initial drive and working directory.
        /// </param>
        /// <param name="lpStartupInfo">
        /// A pointer to a <see cref="STARTUPINFO"/> structure.
        /// The application must add permission for the specified user account to the specified window station and desktop, even for WinSta0\Default.
        /// If the <see cref="STARTUPINFO.lpDesktop"/> member is <see cref="IntPtr.Zero"/> or an empty string,
        /// the new process inherits the desktop and window station of its parent process.
        /// The application must add permission for the specified user account to the inherited window station and desktop.
        /// Windows XP:  <see cref="CreateProcessWithLogonW"/> adds permission for the specified user account to the inherited window station and desktop.
        /// Handles in <see cref="STARTUPINFO"/> must be closed with <see cref="CloseHandle"/> when they are no longer needed.
        /// If the <see cref="STARTUPINFO.dwFlags"/> member of the <see cref="STARTUPINFO"/> structure
        /// specifies <see cref="STARTUPINFOFlags.STARTF_USESTDHANDLES"/>, 
        /// the standard handle fields are copied unchanged to the child process without validation.
        /// The caller is responsible for ensuring that these fields contain valid handle values.
        /// Incorrect values can cause the child process to misbehave or crash.
        /// Use the Application Verifier runtime verification tool to detect invalid handles.
        /// </param>
        /// <param name="lpProcessInformation">
        /// A pointer to a <see cref="PROCESS_INFORMATION"/> structure that receives identification information for the new process,
        /// including a handle to the process.
        /// Handles in <see cref="PROCESS_INFORMATION"/> must be closed with the <see cref="CloseHandle"/> function when they are not needed.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="BOOL.TRUE"/>
        /// If the function fails, the return value is <see cref="BOOL.FALSE"/>
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// Note that the function returns before the process has finished initialization.
        /// If a required DLL cannot be located or fails to initialize, the process is terminated.
        /// To get the termination status of a process, call <see cref="GetExitCodeProcess"/>.
        /// </returns>
        /// <remarks>
        /// By default, <see cref="CreateProcessWithTokenW"/> does not load the specified user profile into the HKEY_USERS registry key.
        /// This means that access to information in the HKEY_CURRENT_USER registry key may not produce results that are consistent
        /// with a normal interactive logon.
        /// It is your responsibility to load the user registry hive into HKEY_USERS before calling <see cref="CreateProcessWithTokenW"/>,
        /// by using <see cref="LOGON_WITH_PROFILE"/>, or by calling the <see cref="LoadUserProfile"/> function.
        /// If the <paramref name="lpEnvironment"/> parameter is <see cref="IntPtr.Zero"/>,
        /// the new process uses an environment block created from the profile of the user specified by <paramref name="hToken"/>.
        /// If the HOMEDRIVE and HOMEPATH variables are not set, <see cref="CreateProcessWithTokenW"/> modifies the environment block
        /// to use the drive and path of the user's working directory.
        /// When created, the new process and thread handles receive full access rights
        /// (<see cref="PROCESS_ALL_ACCESS"/> and <see cref="THREAD_ALL_ACCESS"/>).
        /// For either handle, if a security descriptor is not provided, the handle can be used in any function that requires an object handle of that type.
        /// When a security descriptor is provided, an access check is performed on all subsequent uses of the handle before access is granted.
        /// If access is denied, the requesting process cannot use the handle to gain access to the process or thread.
        /// To retrieve a security token, pass the process handle in the <see cref="PROCESS_INFORMATION"/> structure
        /// to the <see cref="OpenProcessToken"/> function.
        /// The process is assigned a process identifier. The identifier is valid until the process terminates.
        /// It can be used to identify the process, or it can be specified in the <see cref="OpenProcess"/> function to open a handle to the process.
        /// The initial thread in the process is also assigned a thread identifier.
        /// It can be specified in the <see cref="OpenThread"/> function to open a handle to the thread.
        /// The identifier is valid until the thread terminates and can be used to uniquely identify the thread within the system.
        /// These identifiers are returned in <see cref="PROCESS_INFORMATION"/>.
        /// The calling thread can use the <see cref="WaitForInputIdle"/> function to wait until the new process has completed
        /// its initialization and is waiting for user input with no input pending.
        /// This can be useful for synchronization between parent and child processes,
        /// because <see cref="CreateProcessWithTokenW"/> returns without waiting for the new process to finish its initialization.
        /// For example, the creating process would use <see cref="WaitForInputIdle"/> before trying to
        /// find a window that is associated with the new process.
        /// The preferred way to shut down a process is by using the <see cref="ExitProcess"/> function,
        /// because this function sends notification of approaching termination to all DLLs attached to the process.
        /// Other means of shutting down a process do not notify the attached DLLs.
        /// Note that when a thread calls <see cref="ExitProcess"/>, other threads of the process are terminated 
        /// without an opportunity to execute any additional code (including the thread termination code of attached DLLs).
        /// For more information, see Terminating a Process.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0500 or later.
        /// For more information, see Using the Windows Headers.
        /// 
        /// Security Remarks
        /// The first parameter, <paramref name="lpApplicationName"/>, can be <see langword="null"/>,
        /// in which case the executable name must be in the white space–delimited string pointed to by <paramref name="lpCommandLine"/>.
        /// If the executable or path name has a space in it, there is a risk that a different executable
        /// could be run because of the way the function parses spaces.
        /// The following example is dangerous because the function will attempt to run "Program.exe", if it exists, instead of "MyApp.exe".
        /// <code>
        /// LPTSTR szCmdline = _tcsdup(TEXT("C:\\Program Files\\MyApp -L -S"));
        /// CreateProcessWithTokenW(NULL, szCmdline, /* ... */);
        /// </code>
        /// If a malicious user were to create an application called "Program.exe" on a system,
        /// any program that incorrectly calls <see cref="CreateProcessWithTokenW"/> using the Program Files directory will run this application
        /// instead of the intended application.
        /// To avoid this problem, do not pass <see langword="null"/> for <paramref name="lpApplicationName"/>.
        /// If you do pass <see langword="null"/> for <paramref name="lpApplicationName"/>,
        /// use quotation marks around the executable path in <paramref name="lpCommandLine"/>, as shown in the example below.
        /// <code>
        /// LPTSTR szCmdline[] = _tcsdup(TEXT("\"C:\\Program Files\\MyApp\" -L -S"));
        /// CreateProcessWithTokenW(NULL, szCmdline, /*...*/);
        /// </code>
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateProcessWithTokenW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CreateProcessWithTokenW([In]HANDLE hToken, [In]LogonFlags dwLogonFlags,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpApplicationName, [MarshalAs(UnmanagedType.LPWStr)][In]string lpCommandLine,
            [In]ProcessCreationFlags dwCreationFlags, [In]IntPtr lpEnvironment, [MarshalAs(UnmanagedType.LPWStr)][In]string lpCurrentDirectory,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(AlternativeStructObjectMarshaler<STARTUPINFO, STARTUPINFOEX>))]
            [In]AlternativeStructObject<STARTUPINFO, STARTUPINFOEX> lpStartupInfo, [Out]out PROCESS_INFORMATION lpProcessInformation);

        /// <summary>
        /// <para>
        /// The <see cref="GetTokenInformation"/> function retrieves a specified type of information about an access token.
        /// The calling process must have appropriate access rights to obtain the information.
        /// To determine if a user is a member of a specific group, use the <see cref="CheckTokenMembership"/> function.
        /// To determine group membership for app container tokens, use the <see cref="CheckTokenMembershipEx"/> function.
        /// </para>
        /// </summary>
        /// <param name="TokenHandle">
        /// A handle to an access token from which information is retrieved.
        /// If <paramref name="TokenInformationClass"/> specifies <see cref="TokenSource"/>, the handle must have <see cref="TOKEN_QUERY_SOURCE"/> access.
        /// For all other <paramref name="TokenInformationClass"/> values, the handle must have <see cref="TOKEN_QUERY"/> access.
        /// </param>
        /// <param name="TokenInformationClass">
        /// Specifies a value from the <see cref="TOKEN_INFORMATION_CLASS"/> enumerated type to identify the type of information the function retrieves.
        /// Any callers who check the TokenIsAppContainer and have it return 0 should also verify that
        /// the caller token is not an identify level impersonation token.
        /// If the current token is not an app container but is an identity level token, you should return AccessDenied.
        /// </param>
        /// <param name="TokenInformation">
        /// A pointer to a buffer the function fills with the requested information.
        /// The structure put into this buffer depends upon the type of information specified by the <paramref name="TokenInformationClass"/> parameter.
        /// </param>
        /// <param name="TokenInformationLength">
        /// Specifies the size, in bytes, of the buffer pointed to by the <paramref name="TokenInformation"/> parameter.
        /// If <paramref name="TokenInformation"/> is NULL, this parameter must be zero.
        /// </param>
        /// <param name="ReturnLength">
        /// A pointer to a variable that receives the number of bytes needed for the buffer pointed to by the <paramref name="TokenInformation"/> parameter.
        /// If this value is larger than the value specified in the <paramref name="TokenInformationLength"/> parameter,
        /// the function fails and stores no data in the buffer.
        /// If the value of the <paramref name="TokenInformationClass"/> parameter is <see cref="TokenDefaultDacl"/> and the token has no default DACL,
        /// the function sets the variable pointed to by <paramref name="ReturnLength"/> to sizeof("TOKEN_DEFAULT_DACL) and
        /// sets the <see cref="TOKEN_DEFAULT_DACL.DefaultDacl"/> member of the <see cref="TOKEN_DEFAULT_DACL"/> structure to <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTokenInformation", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetTokenInformation([In]IntPtr TokenHandle, [In]TOKEN_INFORMATION_CLASS TokenInformationClass,
            [In]IntPtr TokenInformation, [In]uint TokenInformationLength, [Out]out uint ReturnLength);


        /// <summary>
        /// <para>
        /// Creates a new process and its primary thread.
        /// The new process runs in the security context of the user represented by the specified token.
        /// Typically, the process that calls the <see cref="CreateProcessAsUser"/> function must have the SE_INCREASE_QUOTA_NAME privilege
        /// and may require the SE_ASSIGNPRIMARYTOKEN_NAME privilege if the token is not assignable.
        /// If this function fails with <see cref="SystemErrorCodes.ERROR_PRIVILEGE_NOT_HELD"/>,
        /// use the <see cref="CreateProcessWithLogonW"/> function instead.
        /// <see cref="CreateProcessWithLogonW"/> requires no special privileges,
        /// but the specified user account must be allowed to log on interactively.
        /// Generally, it is best to use <see cref="CreateProcessWithLogonW"/> to create a process with alternate credentials.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/processthreadsapi/nf-processthreadsapi-createprocessasuserw
        /// </para>
        /// </summary>
        /// <param name="hToken">
        /// A handle to the primary token that represents a user.
        /// The handle must have the <see cref="TOKEN_QUERY"/>, <see cref="TOKEN_DUPLICATE"/>, and <see cref="TOKEN_ASSIGN_PRIMARY"/> access rights.
        /// For more information, see Access Rights for Access-Token Objects.
        /// The user represented by the token must have read and execute access to the application specified by
        /// the <paramref name="lpApplicationName"/> or the <paramref name="lpCommandLine"/> parameter.
        /// To get a primary token that represents the specified user, call the <see cref="LogonUser"/> function.
        /// Alternatively, you can call the <see cref="DuplicateTokenEx"/> function to convert an impersonation token into a primary token.
        /// This allows a server application that is impersonating a client to create a process that has the security context of the client.
        /// If <paramref name="hToken"/> is a restricted version of the caller's primary token,
        /// the SE_ASSIGNPRIMARYTOKEN_NAME privilege is not required.
        /// If the necessary privileges are not already enabled, <see cref="CreateProcessAsUser"/> enables them for the duration of the call.
        /// For more information, see Running with Special Privileges.
        /// Terminal Services:  The process is run in the session specified in the token.
        /// By default, this is the same session that called <see cref="LogonUser"/>.
        /// To change the session, use the <see cref="SetTokenInformation"/> function.
        /// </param>
        /// <param name="lpApplicationName">
        /// The name of the module to be executed. This module can be a Windows-based application.
        /// It can be some other type of module (for example, MS-DOS or OS/2) if the appropriate subsystem is available on the local computer.
        /// The string can specify the full path and file name of the module to execute or it can specify a partial name.
        /// In the case of a partial name, the function uses the current drive and current directory to complete the specification.
        /// The function will not use the search path.
        /// This parameter must include the file name extension; no default extension is assumed.
        /// The <paramref name="lpApplicationName"/> parameter can be <see langword="null"/>.
        /// In that case, the module name must be the first white space–delimited token in the <paramref name="lpCommandLine"/> string.
        /// If you are using a long file name that contains a space, use quoted strings to indicate where the file name ends and the arguments begin;
        /// otherwise, the file name is ambiguous.
        /// For example, consider the string "c:\program files\sub dir\program name".
        /// This string can be interpreted in a number of ways.
        /// The system tries to interpret the possibilities in the following order:
        /// c:\program.exe c:\program files\sub.exe c:\program files\sub dir\program.exe c:\program files\sub dir\program name.exe
        /// If the executable module is a 16-bit application, <paramref name="lpApplicationName"/> should be NULL,
        /// and the string pointed to by <paramref name="lpCommandLine"/> should specify the executable module as well as its arguments.
        /// By default, all 16-bit Windows-based applications created by <see cref="CreateProcessAsUser"/> are run in a separate VDM
        /// (equivalent to <see cref="CREATE_SEPARATE_WOW_VDM"/> in <see cref="CreateProcess"/>).
        /// </param>
        /// <param name="lpCommandLine">
        /// The command line to be executed.
        /// The maximum length of this string is 32,768 characters, including the Unicode terminating null character.
        /// If lpApplicationName is <see langword="null"/>,
        /// the module name portion of <paramref name="lpCommandLine"/> is limited to <see cref="MAX_PATH"/> characters.
        /// The Unicode version of this function, <see cref="CreateProcess"/>, can modify the contents of this string.
        /// Therefore, this parameter cannot be a pointer to read-only memory (such as a const variable or a literal string).
        /// If this parameter is a constant string, the function may cause an access violation.
        /// The <paramref name="lpCommandLine"/> parameter can be <see langword="null"/>.
        /// In that case, the function uses the string pointed to by <paramref name="lpApplicationName"/> as the command line.
        /// If both <paramref name="lpApplicationName"/> and <paramref name="lpCommandLine"/> are non-NULL,
        /// the null-terminated string pointed to by <paramref name="lpApplicationName"/> specifies the module to execute,
        /// and the null-terminated string pointed to by <paramref name="lpCommandLine"/> specifies the command line.
        /// The new process can use <see cref="GetCommandLine"/> to retrieve the entire command line.
        /// Console processes written in C can use the argc and argv arguments to parse the command line.
        /// Because argv[0] is the module name, C programmers generally repeat the module name as the first token in the command line.
        /// If <paramref name="lpApplicationName"/> is <see langword="null"/>,
        /// the first white space–delimited token of the command line specifies the module name.
        /// If you are using a long file name that contains a space, use quoted strings to indicate where the file name ends and
        /// the arguments begin (see the explanation for the <paramref name="lpApplicationName"/> parameter).
        /// If the file name does not contain an extension, .exe is appended.
        /// Therefore, if the file name extension is .com, this parameter must include the .com extension.
        /// If the file name ends in a period (.) with no extension, or if the file name contains a path, .exe is not appended.
        /// If the file name does not contain a directory path, the system searches for the executable file in the following sequence:
        /// 1.The directory from which the application loaded.
        /// 2. The current directory for the parent process.
        /// 3. The 32-bit Windows system directory. Use the <see cref="GetSystemDirectory"/> function to get the path of this directory.
        /// 4.The 16-bit Windows system directory. 
        /// There is no function that obtains the path of this directory, but it is searched. The name of this directory is System.
        /// 5. The Windows directory. Use the <see cref="GetWindowsDirectory"/> function to get the path of this directory.
        /// 6.The directories that are listed in the PATH environment variable.
        /// Note that this function does not search the per-application path specified by the App Paths registry key.
        /// To include this per-application path in the search sequence, use the <see cref="ShellExecute"/> function.
        /// The system adds a terminating null character to the command-line string to separate the file name from the arguments.
        /// This divides the original string into two strings for internal processing.
        /// </param>
        /// <param name="lpProcessAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that determines whether
        /// the returned handle to the new process object can be inherited by child processes.
        /// If <paramref name="lpProcessAttributes"/> is <see langword="null"/>, the handle cannot be inherited.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the new process.
        /// If <paramref name="lpProcessAttributes"/> is <see langword="null"/> or
        /// <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> is <see cref="IntPtr.Zero"/>, the process gets a default security descriptor
        /// and the handle cannot be inherited..
        /// The default security descriptor is that of the user referenced in the <paramref name="hToken"/> parameter.
        /// This security descriptor may not allow access for the caller, in which case the process may not be opened again after it is run.
        /// The process handle is valid and will continue to have full access rights.
        /// </param>
        /// <param name="lpThreadAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that determines whether
        /// the returned handle to the new thread object can be inherited by child processes.
        /// If <paramref name="lpThreadAttributes"/> is <see langword="null"/>, the handle cannot be inherited.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the main thread.
        /// If <paramref name="lpThreadAttributes"/> is <see langword="null"/> or
        /// <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> is <see cref="IntPtr.Zero"/>, the thread gets a default security descriptor
        /// and the handle cannot be inherited.
        /// The default security descriptor is that of the user referenced in the <paramref name="hToken"/> parameter.
        /// This security descriptor may not allow access for the caller.
        /// </param>
        /// <param name="bInheritHandles">
        /// If this parameter is <see langword="true"/>, each inheritable handle in the calling process is inherited by the new process.
        /// If the parameter is <see langword="false"/>, the handles are not inherited.
        /// Note that inherited handles have the same value and access rights as the original handles.
        /// For additional discussion of inheritable handles, see Remarks.
        /// Terminal Services:  You cannot inherit handles across sessions.
        /// Additionally, if this parameter is <see langword="true"/>, you must create the process in the same session as the caller.
        /// Protected Process Light (PPL) processes:  The generic handle inheritance is blocked
        /// when a PPL process creates a non-PPL process since <see cref="PROCESS_DUP_HANDLE"/> is not allowed from a non-PPL process to a PPL process.
        /// See Process Security and Access Rights
        /// </param>
        /// <param name="dwCreationFlags">
        /// The flags that control the priority class and the creation of the process.
        /// For a list of values, see Process Creation Flags.
        /// This parameter also controls the new process's priority class, which is used to determine the scheduling priorities of the process's threads.
        /// For a list of values, see <see cref="GetPriorityClass"/>.
        /// If none of the priority class flags is specified, the priority class defaults to <see cref="NORMAL_PRIORITY_CLASS"/>
        /// unless the priority class of the creating process is <see cref="IDLE_PRIORITY_CLASS"/> 
        /// or <see cref="BELOW_NORMAL_PRIORITY_CLASS"/>.
        /// In this case, the child process receives the default priority class of the calling process.
        /// </param>
        /// <param name="lpEnvironment">
        /// A pointer to the environment block for the new process.
        /// If this parameter is <see langword="null"/>, the new process uses the environment of the calling process.
        /// An environment block consists of a null-terminated block of null-terminated strings.
        /// Each string is in the following form: name=value\0
        /// Because the equal sign is used as a separator, it must not be used in the name of an environment variable.
        /// An environment block can contain either Unicode or ANSI characters.
        /// If the environment block pointed to by <paramref name="lpEnvironment"/> contains Unicode characters,
        /// be sure that <paramref name="dwCreationFlags"/> includes <see cref="CREATE_UNICODE_ENVIRONMENT"/>.
        /// If this parameter is <see langword="null"/> and the environment block of the parent process contains Unicode characters,
        /// you must also ensure that <paramref name="dwCreationFlags"/> includes <see cref="CREATE_UNICODE_ENVIRONMENT"/>.
        /// The ANSI version of this function, <see cref="CreateProcessAsUser"/> fails if the total size of
        /// the environment block for the process exceeds 32,767 characters.
        /// Note that an ANSI environment block is terminated by two zero bytes: one for the last string, one more to terminate the block.
        /// A Unicode environment block is terminated by four zero bytes: two for the last string, two more to terminate the block.
        /// Windows Server 2003 and Windows XP:  If the size of the combined user and system environment variable exceeds 8192 bytes, 
        /// the process created by CreateProcessAsUser no longer runs with the environment block passed to the function by the parent process.
        /// Instead, the child process runs with the environment block returned by the <see cref="CreateEnvironmentBlock"/> function.
        /// To retrieve a copy of the environment block for a given user, use the <see cref="CreateEnvironmentBlock"/> function.
        /// </param>
        /// <param name="lpCurrentDirectory">
        /// The full path to the current directory for the process. The string can also specify a UNC path.
        /// If this parameter is <see langword="null"/>, the new process will have the same current drive and directory as the calling process.
        /// (This feature is provided primarily for shells that need to start an application and specify its initial drive and working directory.)
        /// </param>
        /// <param name="lpStartupInfo">
        /// A pointer to a <see cref="STARTUPINFO"/> or <see cref="STARTUPINFOEX"/> structure.
        /// To set extended attributes, use a <see cref="STARTUPINFOEX"/> structure and
        /// specify <see cref="EXTENDED_STARTUPINFO_PRESENT"/> in the <paramref name="dwCreationFlags"/> parameter.
        /// Handles in <see cref="STARTUPINFO"/> or <see cref="STARTUPINFOEX"/> must be closed
        /// with <see cref="CloseHandle"/> when they are no longer needed.
        /// Important  The caller is responsible for ensuring that the standard handle fields in <see cref="STARTUPINFO"/> contain valid handle values.
        /// These fields are copied unchanged to the child process without validation,
        /// even when the dwFlags member specifies <see cref="STARTUPINFOFlags.STARTF_USESTDHANDLES"/>.
        /// Incorrect values can cause the child process to misbehave or crash.
        /// Use the Application Verifier runtime verification tool to detect invalid handles.
        /// </param>
        /// <param name="lpProcessInformation">
        /// A pointer to a <see cref="PROCESS_INFORMATION"/> structure that receives identification information about the new process.
        /// Handles in <see cref="PROCESS_INFORMATION"/> must be closed with <see cref="CloseHandle"/> when they are no longer needed.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// Note that the function returns before the process has finished initialization.
        /// If a required DLL cannot be located or fails to initialize, the process is terminated.
        /// To get the termination status of a process, call <see cref="GetExitCodeProcess"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="CreateProcessAsUser"/> must be able to open the primary token of the calling process
        /// with the <see cref="TOKEN_DUPLICATE"/> and <see cref="TOKEN_IMPERSONATE"/> access rights.
        /// By default, <see cref="CreateProcessAsUser"/> creates the new process on a noninteractive window station
        /// with a desktop that is not visible and cannot receive user input.
        /// To enable user interaction with the new process, you must specify the name of
        /// the default interactive window station and desktop, "winsta0\default", in the <see cref="STARTUPINFO.lpDesktop"/> member
        /// of the <see cref="STARTUPINFO"/> structure.
        /// In addition, before calling <see cref="CreateProcessAsUser"/>, you must change the discretionary access control list (DACL) of both
        /// the default interactive window station and the default desktop.
        /// The DACLs for the window station and desktop must grant access to the user or the logon session
        /// represented by the <paramref name="hToken"/> parameter.
        /// <see cref="CreateProcessAsUser"/> does not load the specified user's profile into the HKEY_USERS registry key.
        /// Therefore, to access the information in the HKEY_CURRENT_USER registry key,
        /// you must load the user's profile information into HKEY_USERS with the <see cref="LoadUserProfile"/> function
        /// before calling <see cref="CreateProcessAsUser"/>.
        /// Be sure to call <see cref="UnloadUserProfile"/> after the new process exits.
        /// If the <paramref name="lpEnvironment"/> parameter is <see langword="null"/>, the new process inherits the environment of the calling process.
        /// <see cref="CreateProcessAsUser"/> does not automatically modify the environment block to include environment variables
        /// specific to the user represented by <paramref name="hToken"/>.
        /// For example, the USERNAME and USERDOMAIN variables are inherited from the calling process
        /// if <paramref name="lpEnvironment"/> is <see langword="null"/>.
        /// It is your responsibility to prepare the environment block for the new process and specify it in <paramref name="lpEnvironment"/>.
        /// The <see cref="CreateProcessWithLogonW"/> and <see cref="CreateProcessWithTokenW"/> functions are similar to
        /// <see cref="CreateProcessAsUser"/>, except that the caller does not need to call the <see cref="LogonUser"/> function
        /// to authenticate the user and get a token.
        /// <see cref="CreateProcessAsUser"/> allows you to access the specified directory and executable image in the security context
        /// of the caller or the target user.
        /// By default, <see cref="CreateProcessAsUser"/> accesses the directory and executable image in the security context of the caller.
        /// In this case, if the caller does not have access to the directory and executable image, the function fails.
        /// To access the directory and executable image using the security context of the target user, specify <paramref name="hToken"/> in a call
        /// to the <see cref="ImpersonateLoggedOnUser"/> function before calling <see cref="CreateProcessAsUser"/>.
        /// The process is assigned a process identifier.
        /// The identifier is valid until the process terminates.
        /// It can be used to identify the process, or specified in the <see cref="OpenProcess"/> function to open a handle to the process.
        /// The initial thread in the process is also assigned a thread identifier.
        /// It can be specified in the <see cref="OpenThread"/> function to open a handle to the thread.
        /// The identifier is valid until the thread terminates and can be used to uniquely identify the thread within the system.
        /// These identifiers are returned in the <see cref="PROCESS_INFORMATION"/> structure.
        /// The name of the executable in the command line that the operating system provides to a process is not necessarily identical
        /// to that in the command line that the calling process gives to the <see cref="CreateProcess"/> function.
        /// The operating system may prepend a fully qualified path to an executable name that is provided without a fully qualified path.
        /// The calling thread can use the <see cref="WaitForInputIdle"/> function to wait until the new process has finished its initialization
        /// and is waiting for user input with no input pending.
        /// For example, the creating process would use <see cref="WaitForInputIdle"/> before trying to find a window associated with the new process.
        /// This can be useful for synchronization between parent and child processes,
        /// because <see cref="CreateProcess"/> returns without waiting for the new process to finish its initialization.
        /// The preferred way to shut down a process is by using the <see cref="ExitProcess"/> function,
        /// because this function sends notification of approaching termination to all DLLs attached to the process.
        /// Other means of shutting down a process do not notify the attached DLLs.
        /// Note that when a thread calls <see cref="ExitProcess"/>, other threads of the process are terminated
        /// without an opportunity to execute any additional code (including the thread termination code of attached DLLs).
        /// For more information, see Terminating a Process.
        /// By default, passing <see langword="true"/> as the value of the <paramref name="bInheritHandles"/> parameter
        /// causes all inheritable handles to be inherited by the new process.
        /// This can be problematic for applications which create processes from multiple threads simultaneously
        /// yet desire each process to inherit different handles.
        /// Applications can use the <see cref="UpdateProcThreadAttributeList"/> function
        /// with the PROC_THREAD_ATTRIBUTE_HANDLE_LIST parameter to provide a list of handles to be inherited by a particular process.
        /// 
        /// Security Remarks
        /// The first parameter, <paramref name="lpApplicationName"/>, can be <see langword="null"/>,
        /// in which case the executable name must be in the white space–delimited string pointed to by <paramref name="lpCommandLine"/>.
        /// If the executable or path name has a space in it, there is a risk that a different executable
        /// could be run because of the way the function parses spaces.
        /// The following example is dangerous because the function will attempt to run "Program.exe", if it exists, instead of "MyApp.exe".
        /// <code>
        /// LPTSTR szCmdline = _tcsdup(TEXT("C:\\Program Files\\MyApp -L -S"));
        /// CreateProcess(NULL, szCmdline, /* ... */);
        /// </code>
        /// If a malicious user were to create an application called "Program.exe" on a system,
        /// any program that incorrectly calls <see cref="CreateProcessAsUser"/> using the Program Files directory will run this application
        /// instead of the intended application.
        /// To avoid this problem, do not pass <see langword="null"/> for <paramref name="lpApplicationName"/>.
        /// If you do pass <see langword="null"/> for <paramref name="lpApplicationName"/>,
        /// use quotation marks around the executable path in <paramref name="lpCommandLine"/>, as shown in the example below.
        /// <code>
        /// LPTSTR szCmdline[] = _tcsdup(TEXT("\"C:\\Program Files\\MyApp\" -L -S"));
        /// CreateProcess(NULL, szCmdline, /*...*/);
        /// </code>
        /// PowerShell:  When the <see cref="CreateProcessAsUser"/> function is used to implement a cmdlet in PowerShell version 2.0,
        /// the cmdlet operates correctly for both fan-in and fan-out remote sessions.
        /// Because of certain security scenarios, however, a cmdlet implemented with <see cref="CreateProcessAsUser"/> only operates correctly
        /// in PowerShell version 3.0 for fan-in remote sessions; fan-out remote sessions will fail because of insufficient client security privileges.
        /// To implement a cmdlet that works for both fan-in and fan-out remote sessions in PowerShell version 3.0,
        /// use the <see cref="CreateProcess"/> function.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateProcessAsUserW", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CreateProcessAsUser([In]IntPtr hToken, [MarshalAs(UnmanagedType.LPWStr)][In]string lpApplicationName,
          [MarshalAs(UnmanagedType.LPWStr)][In]string lpCommandLine,
          [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))]
          [In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpProcessAttributes,
          [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))]
          [In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpThreadAttributes,
          [In]bool bInheritHandles, [In]ProcessCreationFlags dwCreationFlags, [MarshalAs(UnmanagedType.LPWStr)][In]string lpEnvironment,
          [MarshalAs(UnmanagedType.LPWStr)][In]string lpCurrentDirectory,
          [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(AlternativeStructObjectMarshaler<STARTUPINFO, STARTUPINFOEX>))]
          [In]AlternativeStructObject<STARTUPINFO, STARTUPINFOEX> lpStartupInfo, [Out]out PROCESS_INFORMATION lpProcessInformation);

        /// <summary>
        /// <para>
        /// The <see cref="OpenProcessToken"/> function opens the access token associated with a process.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/processthreadsapi/nf-processthreadsapi-openprocesstoken
        /// </para>
        /// </summary>
        /// <param name="ProcessHandle">
        /// A handle to the process whose access token is opened.
        /// The process must have the <see cref="PROCESS_QUERY_INFORMATION"/> access permission.
        /// </param>
        /// <param name="DesiredAccess">
        /// Specifies an access mask that specifies the requested types of access to the access token.
        /// These requested access types are compared with the discretionary access control list (DACL) of the token
        /// to determine which accesses are granted or denied.
        /// For a list of access rights for access tokens, see Access Rights for Access-Token Objects.
        /// </param>
        /// <param name="TokenHandle">
        /// A pointer to a handle that identifies the newly opened access token when the function returns.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Close the access token handle returned through the <paramref name="TokenHandle"/> parameter by calling <see cref="CloseHandle"/>.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "OpenProcessToken", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool OpenProcessToken([In]IntPtr ProcessHandle, [In]uint DesiredAccess, [Out]out IntPtr TokenHandle);

        /// <summary>
        /// <para>
        /// The <see cref="DuplicateToken"/> function creates a new access token that duplicates one already in existence.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-duplicatetoken
        /// </para>
        /// </summary>
        /// <param name="ExistingTokenHandle">
        /// A handle to an access token opened with <see cref="TOKEN_DUPLICATE"/> access.
        /// </param>
        /// <param name="ImpersonationLevel">
        /// Specifies a <see cref="SECURITY_IMPERSONATION_LEVEL"/> enumerated type that supplies the impersonation level of the new token.
        /// </param>
        /// <param name="DuplicateTokenHandle">
        /// A pointer to a variable that receives a handle to the duplicate token.
        /// This handle has <see cref="TOKEN_IMPERSONATE"/> and <see cref="TOKEN_QUERY"/> access to the new token.
        /// When you have finished using the new token, call the <see cref="CloseHandle"/> function to close the token handle.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="DuplicateToken"/> function creates an impersonation token,
        /// which you can use in functions such as <see cref="SetThreadToken"/> and <see cref="ImpersonateLoggedOnUser"/>.
        /// The token created by <see cref="DuplicateToken"/> cannot be used in the <see cref="CreateProcessAsUser"/> function,
        /// which requires a primary token.
        /// To create a token that you can pass to <see cref="CreateProcessAsUser"/>, use the <see cref="DuplicateTokenEx"/> function.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "DuplicateToken", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DuplicateToken([In]IntPtr ExistingTokenHandle, [In]SECURITY_IMPERSONATION_LEVEL ImpersonationLevel,
            [Out]out IntPtr DuplicateTokenHandle);

        /// <summary>
        /// <para>
        /// The <see cref="DuplicateTokenEx"/> function creates a new access token that duplicates an existing token.
        /// This function can create either a primary token or an impersonation token.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-duplicatetokenex
        /// </para>
        /// </summary>
        /// <param name="ExistingTokenHandle">
        /// A handle to an access token opened with <see cref="TOKEN_DUPLICATE"/> access.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// Specifies the requested access rights for the new token.
        /// The <see cref="DuplicateTokenEx"/> function compares the requested access rights with the existing token's
        /// discretionary access control list (DACL) to determine which rights are granted or denied.
        /// To request the same access rights as the existing token, specify zero.
        /// To request all access rights that are valid for the caller, specify <see cref="MAXIMUM_ALLOWED"/>.
        /// For a list of access rights for access tokens, see Access Rights for Access-Token Objects.
        /// </param>
        /// <param name="lpTokenAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that specifies a security descriptor for the new token and
        /// determines whether child processes can inherit the token.
        /// If <paramref name="lpTokenAttributes"/> is <see langword="null"/>, the token gets a default security descriptor and
        /// the handle cannot be inherited.
        /// If the security descriptor contains a system access control list (SACL), the token gets <see cref="ACCESS_SYSTEM_SECURITY"/> access right,
        /// even if it was not requested in <paramref name="dwDesiredAccess"/>.
        /// To set the owner in the security descriptor for the new token,
        /// the caller's process token must have the SeRestorePrivilege privilege set.
        /// </param>
        /// <param name="ImpersonationLevel">
        /// Specifies a value from the <see cref="SECURITY_IMPERSONATION_LEVEL"/> enumeration that indicates the impersonation level of the new token.
        /// </param>
        /// <param name="TokenType">
        /// Specifies one of the following values from the <see cref="TOKEN_TYPE"/> enumeration.
        /// <see cref="TokenPrimary"/>: The new token is a primary token that you can use in the <see cref="CreateProcessAsUser"/> function.
        /// <see cref="TokenImpersonation"/>: The new token is an impersonation token.
        /// </param>
        /// <param name="DuplicateTokenHandle">
        /// A pointer to a HANDLE variable that receives the new token.
        /// When you have finished using the new token, call the <see cref="CloseHandle"/> function to close the token handle.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="DuplicateTokenEx"/> function allows you to create a primary token
        /// that you can use in the <see cref="CreateProcessAsUser"/> function.
        /// This allows a server application that is impersonating a client to create a process that has the security context of the client.
        /// Note that the <see cref="DuplicateToken"/> function can create only impersonation tokens,
        /// which are not valid for <see cref="CreateProcessAsUser"/>.
        /// The following is a typical scenario for using <see cref="DuplicateTokenEx"/> to create a primary token.
        /// A server application creates a thread that calls one of the impersonation functions,
        /// such as <see cref="ImpersonateNamedPipeClient"/>, to impersonate a client.
        /// The impersonating thread then calls the <see cref="OpenThreadToken"/> function to get its own token,
        /// which is an impersonation token that has the security context of the client.
        /// The thread specifies this impersonation token in a call to <see cref="DuplicateTokenEx"/>, specifying the <see cref="TokenPrimary"/> flag.
        /// The <see cref="DuplicateTokenEx"/> function creates a primary token that has the security context of the client.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "DuplicateTokenEx", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DuplicateTokenEx([In]IntPtr ExistingTokenHandle, [In]uint dwDesiredAccess,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))]
            [In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpTokenAttributes, [In]SECURITY_IMPERSONATION_LEVEL ImpersonationLevel,
            [In]TOKEN_TYPE TokenType, [Out]out IntPtr DuplicateTokenHandle);

        /// <summary>
        /// The SetTokenInformation function sets various types of information for a specified access token. 
        /// The information that this function sets replaces existing information. The calling process must have appropriate access rights to set the information.
        /// <para>
        /// From : https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-settokeninformation
        /// </para>
        /// </summary>
        /// <param name="TokenHandle">
        /// A handle to the access token for which information is to be set.
        /// </param>
        /// <param name="TokenInformationClass">
        /// A value from the<see cref="TOKEN_INFORMATION_CLASS"/>  enumerated type that identifies the type of information the function sets. 
        /// The valid values from TOKEN_INFORMATION_CLASS are described in the TokenInformation parameter.
        /// </param>
        /// <param name="TokenInformation">
        /// A pointer to a buffer that contains the information set in the access token. The structure of this buffer depends on the type of information specified by the TokenInformationClass parameter.
        /// </param>
        /// <param name="TokenInformationLength">
        /// Specifies the length, in bytes, of the buffer pointed to by TokenInformation.
        /// </param>
        /// <returns>
        /// If the function succeeds, the function returns nonzero.
        /// If the function fails, it returns zero.To get extended error information, call<see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// To set privilege information, an application can call the <see cref="AdjustTokenPrivileges"/> function.
        /// To set a token's groups, an application can call the AdjustTokenGroups function.
        /// Token-type information can be set only when an access token is created.
        /// </remarks>

        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetTokenInformation", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetTokenInformation([In]HANDLE TokenHandle, [In]TOKEN_INFORMATION_CLASS TokenInformationClass,
            [In]LPVOID TokenInformation, [In]DWORD TokenInformationLength);
    }
}
