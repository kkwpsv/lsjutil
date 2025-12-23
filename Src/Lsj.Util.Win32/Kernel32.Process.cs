using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.DllMainReasons;
using static Lsj.Util.Win32.Enums.LoadLibraryExFlags;
using static Lsj.Util.Win32.Enums.NTSTATUS;
using static Lsj.Util.Win32.Enums.PrivilegeConstants;
using static Lsj.Util.Win32.Enums.PROCESS_MITIGATION_POLICY;
using static Lsj.Util.Win32.Enums.ProcessAccessRights;
using static Lsj.Util.Win32.Enums.ProcessCreationChildProcessPolicies;
using static Lsj.Util.Win32.Enums.ProcessCreationDesktopAppPolices;
using static Lsj.Util.Win32.Enums.ProcessCreationFlags;
using static Lsj.Util.Win32.Enums.ProcessCreationMitigationPolicies;
using static Lsj.Util.Win32.Enums.ProcessPriorityClasses;
using static Lsj.Util.Win32.Enums.SearchPathModes;
using static Lsj.Util.Win32.Enums.StartupInfoFlags;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.Toolhelp32SnapshotFlags;
using static Lsj.Util.Win32.Shell32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using static Lsj.Util.Win32.User32;
using FILETIME = Lsj.Util.Win32.Structs.FILETIME;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// Creates a new process and its primary thread. The new process runs in the security context of the calling process.
        /// </para>
        /// <para>
        /// If the calling process is impersonating another user, the new process uses the token for the calling process, not the impersonation token.
        /// To run the new process in the security context of the user represented by the impersonation token,
        /// use the <see cref="CreateProcessAsUser"/> or <see cref="CreateProcessWithLogonW"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-createprocessw"/>
        /// </para>
        /// </summary>
        /// <param name="lpApplicationName">
        /// <para>
        /// The name of the module to be executed. This module can be a Windows-based application.
        /// It can be some other type of module (for example, MS-DOS or OS/2) if the appropriate subsystem is available on the local computer.
        /// </para>
        /// <para>
        /// The string can specify the full path and file name of the module to execute or it can specify a partial name.
        /// In the case of a partial name, the function uses the current drive and current directory to complete the specification.
        /// The function will not use the search path. This parameter must include the file name extension; no default extension is assumed.
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
        /// <list type="number">
        /// <item>
        /// <description>
        /// c:\program.exe
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// c:\program files\sub.exe
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// c:\program files\sub dir\program.exe
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// c:\program files\sub dir\program name.exe
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If the executable module is a 16-bit application, <paramref name="lpApplicationName"/> should be <see cref="NULL"/>,
        /// and the string pointed to by <paramref name="lpCommandLine"/> should specify the executable module as well as its arguments.
        /// </para>
        /// <para>
        /// To run a batch file, you must start the command interpreter;
        /// set <paramref name="lpApplicationName"/> to cmd.exe and set <paramref name="lpCommandLine"/> to the following arguments:
        /// /c plus the name of the batch file.
        /// </para>
        /// </param>
        /// <param name="lpCommandLine">
        /// <para>
        /// The command line to be executed.
        /// </para>
        /// <para>
        /// The maximum length of this string is 32,767 characters, including the Unicode terminating null character.
        /// If <paramref name="lpApplicationName"/> is <see cref="NULL"/>,
        /// the module name portion of <paramref name="lpCommandLine"/> is limited to <see cref="MAX_PATH"/> characters.
        /// </para>
        /// <para>
        /// The Unicode version of this function, <see cref="CreateProcess"/>, can modify the contents of this string.
        /// Therefore, this parameter cannot be a pointer to read-only memory (such as a <c>const</c> variable or a literal string).
        /// If this parameter is a constant string, the function may cause an access violation.
        /// </para>
        /// <para>
        /// The <paramref name="lpCommandLine"/> parameter can be <see cref="NULL"/>.
        /// In that case, the function uses the string pointed to by <paramref name="lpApplicationName"/> as the command line.
        /// </para>
        /// <para>
        /// If both <paramref name="lpApplicationName"/> and <paramref name="lpCommandLine"/> are non-<see cref="NULL"/>,
        /// the null-terminated string pointed to by <paramref name="lpApplicationName"/> specifies the module to execute,
        /// and the null-terminated string pointed to by <paramref name="lpCommandLine"/> specifies the command line.
        /// The new process can use <see cref="GetCommandLine"/> to retrieve the entire command line.
        /// Console processes written in C can use the <c>argc</c> and <c>argv</c> arguments to parse the command line.
        /// Because <c>argv[0]</c> is the module name, C programmers generally repeat the module name as the first token in the command line.
        /// </para>
        /// <para>
        /// If <paramref name="lpApplicationName"/> is <see cref="NULL"/>,
        /// the first white space–delimited token of the command line specifies the module name.
        /// If you are using a long file name that contains a space, use quoted strings to indicate where the file name ends and the arguments begin
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
        /// The 16-bit Windows system directory. There is no function that obtains the path of this directory, but it is searched.
        /// The name of this directory is System.
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
        /// The system adds a terminating null character to the command-line string to separate the file name from the arguments.
        /// This divides the original string into two strings for internal processing.
        /// </para>
        /// </param>
        /// <param name="lpProcessAttributes">
        /// <para>
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that determines
        /// whether the returned handle to the new process object can be inherited by child processes.
        /// If <paramref name="lpProcessAttributes"/> is <see cref="NullRef{SECURITY_ATTRIBUTES}"/>, the handle cannot be inherited.
        /// </para>
        /// <para>
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the new process.
        /// If <paramref name="lpProcessAttributes"/> is <see cref="NullRef{SECURITY_ATTRIBUTES}"/>
        /// or <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> is <see cref="NULL"/>, the process gets a default security descriptor.
        /// The ACLs in the default security descriptor for a process come from the primary token of the creator.
        /// </para>
        /// <para>
        /// Windows XP:
        /// The ACLs in the default security descriptor for a process come from the primary or impersonation token of the creator.
        /// This behavior changed with Windows XP with SP2 and Windows Server 2003.
        /// </para>
        /// </param>
        /// <param name="lpThreadAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that specifies a security descriptor 
        /// for the new thread and determines whether child processes can inherit the returned handle.
        /// If <paramref name="lpThreadAttributes"/> is <see cref="NullRef{SECURITY_ATTRIBUTES}"/>,
        /// the thread gets a default security descriptor and the handle cannot be inherited.
        /// The access control lists (ACL) in the default security descriptor for a thread come from the primary token of the creator.
        /// </param>
        /// <param name="bInheritHandles">
        /// <para>
        /// If this parameter is <see cref="TRUE"/>, each inheritable handle in the calling process is inherited by the new process.
        /// If the parameter is <see cref="FALSE"/>, the handles are not inherited.
        /// Note that inherited handles have the same value and access rights as the original handles.
        /// For additional discussion of inheritable handles, see Remarks.
        /// </para>
        /// <para>
        /// Terminal Services:
        /// You cannot inherit handles across sessions.
        /// Additionally, if this parameter is <see cref="TRUE"/>, you must create the process in the same session as the caller.
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
        /// This parameter also controls the new process's priority class, which is used to determine the scheduling priorities of the process's threads.
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
        /// </para>
        /// </param>
        /// <param name="lpEnvironment">
        /// <para>
        /// A pointer to the environment block for the new process.
        /// If this parameter is <see cref="NULL"/>, the new process uses the environment of the calling process.
        /// </para>
        /// <para>
        /// An environment block consists of a null-terminated block of null-terminated strings.
        /// Each string is in the following form:
        /// </para>
        /// <para>
        /// <c>name=value\0</c>
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
        /// The ANSI version of this function, <c>CreateProcessA</c> fails if the total size of the environment block for the process exceeds 32,767 characters.
        /// </para>
        /// <para>
        /// Note that an ANSI environment block is terminated by two zero bytes: one for the last string, one more to terminate the block.
        /// A Unicode environment block is terminated by four zero bytes: two for the last string, two more to terminate the block.
        /// </para>
        /// </param>
        /// <param name="lpCurrentDirectory">
        /// <para>
        /// The full path to the current directory for the process. The string can also specify a UNC path.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NULL"/>, the new process will have the same current drive and directory as the calling process.
        /// (This feature is provided primarily for shells that need to start an application and specify its initial drive and working directory.)
        /// </para>
        /// </param>
        /// <param name="lpStartupInfo">
        /// <para>
        /// A pointer to a <see cref="STARTUPINFO"/> or <see cref="STARTUPINFOEX"/> structure.
        /// </para>
        /// <para>
        /// To set extended attributes, use a <see cref="STARTUPINFOEX"/> structure
        /// and specify <see cref="EXTENDED_STARTUPINFO_PRESENT"/> in the <paramref name="dwCreationFlags"/> parameter.
        /// </para>
        /// <para>
        /// Handles in <see cref="STARTUPINFO"/> or <see cref="STARTUPINFOEX"/> must be closed with <see cref="CloseHandle"/> when they are no longer needed.
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
        /// The process is assigned a process identifier. The identifier is valid until the process terminates.
        /// It can be used to identify the process, or specified in the <see cref="OpenProcess"/> function to open a handle to the process.
        /// The initial thread in the process is also assigned a thread identifier.
        /// It can be specified in the <see cref="OpenThread"/> function to open a handle to the thread.
        /// The identifier is valid until the thread terminates and can be used to uniquely identify the thread within the system.
        /// These identifiers are returned in the <see cref="PROCESS_INFORMATION"/> structure.
        /// </para>
        /// <para>
        /// The name of the executable in the command line that the operating system provides to a process is not necessarily identical to
        /// that in the command line that the calling process gives to the <see cref="CreateProcess"/> function.
        /// The operating system may prepend a fully qualified path to an executable name that is provided without a fully qualified path.
        /// </para>
        /// <para>
        /// The calling thread can use the <see cref="WaitForInputIdle"/> function to wait
        /// until the new process has finished its initialization and is waiting for user input with no input pending.
        /// This can be useful for synchronization between parent and child processes,
        /// because <see cref="CreateProcess"/> returns without waiting for the new process to finish its initialization.
        /// For example, the creating process would use <see cref="WaitForInputIdle"/> before trying to find a window associated with the new process.
        /// </para>
        /// <para>
        /// The preferred way to shut down a process is by using the <see cref="ExitProcess"/> function,
        /// because this function sends notification of approaching termination to all DLLs attached to the process.
        /// Other means of shutting down a process do not notify the attached DLLs.
        /// Note that when a thread calls <see cref="ExitProcess"/>, other threads of the process are terminated
        /// without an opportunity to execute any additional code (including the thread termination code of attached DLLs).
        /// For more information, see Terminating a Process.
        /// </para>
        /// <para>
        /// A parent process can directly alter the environment variables of a child process during process creation.
        /// This is the only situation when a process can directly change the environment settings of another process.
        /// For more information, see Changing Environment Variables.
        /// </para>
        /// <para>
        /// If an application provides an environment block,
        /// the current directory information of the system drives is not automatically propagated to the new process.
        /// For example, there is an environment variable named =C: whose value is the current directory on drive C.
        /// An application must manually pass the current directory information to the new process.
        /// To do so, the application must explicitly create these environment variable strings,
        /// sort them alphabetically (because the system uses a sorted environment), and put them into the environment block.
        /// Typically, they will go at the front of the environment block, due to the environment block sort order.
        /// </para>
        /// <para>
        /// One way to obtain the current directory information for a drive X is to make the following call: <c>GetFullPathName("X:", ...)</c>.
        /// That avoids an application having to scan the environment block.
        /// If the full path returned is X:, there is no need to pass that value on as environment data,
        /// since the root directory is the default current directory for drive X of a new process.
        /// </para>
        /// <para>
        /// When a process is created with <see cref="CREATE_NEW_PROCESS_GROUP"/> specified,
        /// an implicit call to <c>SetConsoleCtrlHandler(NULL,TRUE)</c> is made on behalf of the new process;
        /// this means that the new process has CTRL+C disabled.
        /// This lets shells handle CTRL+C themselves, and selectively pass that signal on to sub-processes.
        /// CTRL+BREAK is not disabled, and may be used to interrupt the process/process group.
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
        /// The first parameter, <paramref name="lpApplicationName"/>, can be <see cref="NULL"/>,
        /// in which case the executable name must be in the white space–delimited string pointed to by <paramref name="lpCommandLine"/>.
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
        /// any program that incorrectly calls <see cref="CreateProcess"/> using the Program Files directory
        /// will run this application instead of the intended application.
        /// </para>
        /// <para>
        /// To avoid this problem, do not pass <see cref="NULL"/> for <paramref name="lpApplicationName"/>.
        /// If you do pass <see cref="NULL"/> for <paramref name="lpApplicationName"/>,
        /// use quotation marks around the executable path in <paramref name="lpCommandLine"/>, as shown in the example below.
        /// </para>
        /// <code>
        /// LPTSTR szCmdline[] = _tcsdup(TEXT("\"C:\\Program Files\\MyApp\" -L -S"));
        /// CreateProcess(NULL, szCmdline, /*...*/);
        /// </code>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateProcessW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CreateProcess([In] LPCWSTR lpApplicationName, [In] LPWSTR lpCommandLine, [In] in SECURITY_ATTRIBUTES lpProcessAttributes,
            [In] in SECURITY_ATTRIBUTES lpThreadAttributes, [In] BOOL bInheritHandles, [In] ProcessCreationFlags dwCreationFlags,
            [In] LPVOID lpEnvironment, [In] LPCWSTR lpCurrentDirectory, [In] in STARTUPINFO lpStartupInfo, [Out] out PROCESS_INFORMATION lpProcessInformation);

        /// <summary>
        /// <para>
        /// Takes a snapshot of the specified processes, as well as the heaps, modules, and threads used by these processes.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/tlhelp32/nf-tlhelp32-createtoolhelp32snapshot"/>
        /// </para>
        /// </summary>
        /// <param name="dwFlags">
        /// <para>
        /// The portions of the system to be included in the snapshot.
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
        /// <see cref="TH32CS_INHERIT"/>
        /// </para>
        /// <para>
        /// 0x80000000
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that the snapshot handle is to be inheritable.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TH32CS_SNAPALL"/>
        /// </term>
        /// <term>
        /// Includes all processes and threads in the system, plus the heaps and modules of the process specified in <paramref name="th32ProcessID"/>.
        /// Equivalent to specifying the <see cref="TH32CS_SNAPHEAPLIST"/>, <see cref="TH32CS_SNAPMODULE"/>,
        /// <see cref="TH32CS_SNAPPROCESS"/>, and <see cref="TH32CS_SNAPTHREAD"/> values combined using an OR operation ('|').
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TH32CS_SNAPHEAPLIST"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// Includes all heaps of the process specified in <paramref name="th32ProcessID"/> in the snapshot.
        /// To enumerate the heaps, see <see cref="Heap32ListFirst"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TH32CS_SNAPMODULE"/>
        /// </para>
        /// <para>
        /// 0x00000008
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Includes all modules of the process specified in <paramref name="th32ProcessID"/> in the snapshot.
        /// To enumerate the modules, see <see cref="Module32First"/>.
        /// If the function fails with <see cref="ERROR_BAD_LENGTH"/>, retry the function until it succeeds.
        /// </para>
        /// <para>
        /// 64-bit Windows:  Using this flag in a 32-bit process includes the 32-bit modules of the process specified in <paramref name="th32ProcessID"/>,
        /// while using it in a 64-bit process includes the 64-bit modules.
        /// To include the 32-bit modules of the process specified in <paramref name="th32ProcessID"/> from a 64-bit process,
        /// use the <see cref="TH32CS_SNAPMODULE32"/> flag.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TH32CS_SNAPMODULE32"/>
        /// </para>
        /// <para>
        /// 0x00000010
        /// </para>
        /// </term>
        /// <term>
        /// Includes all 32-bit modules of the process specified in <paramref name="th32ProcessID"/> in the snapshot when called from a 64-bit process.
        /// This flag can be combined with <see cref="TH32CS_SNAPMODULE"/> or <see cref="TH32CS_SNAPALL"/>.
        /// If the function fails with <see cref="ERROR_BAD_LENGTH"/>, retry the function until it succeeds.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TH32CS_SNAPPROCESS"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// Includes all processes in the system in the snapshot.
        /// To enumerate the processes, see <see cref="Process32First"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TH32CS_SNAPTHREAD"/>
        /// </para>
        /// <para>
        /// 0x00000004
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Includes all threads in the system in the snapshot.
        /// To enumerate the threads, see <see cref="Thread32First"/>.
        /// </para>
        /// <para>
        /// To identify the threads that belong to a specific process, compare its process identifier
        /// to the <see cref="THREADENTRY32.th32OwnerProcessID"/> member of the <see cref="THREADENTRY32"/> structure when enumerating the threads.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="th32ProcessID">
        /// <para>
        /// The process identifier of the process to be included in the snapshot.
        /// This parameter can be zero to indicate the current process.
        /// This parameter is used when the <see cref="TH32CS_SNAPHEAPLIST"/>, <see cref="TH32CS_SNAPMODULE"/>,
        /// <see cref="TH32CS_SNAPMODULE32"/>, or <see cref="TH32CS_SNAPALL"/> value is specified.
        /// Otherwise, it is ignored and all processes are included in the snapshot.
        /// </para>
        /// <para>
        /// If the specified process is the Idle process or one of the CSRSS processes,
        /// this function fails and the last error code is <see cref="ERROR_ACCESS_DENIED"/>
        /// because their access restrictions prevent user-level code from opening them.
        /// </para>
        /// <para>
        /// If the specified process is a 64-bit process and the caller is a 32-bit process,
        /// this function fails and the last error code is <see cref="ERROR_PARTIAL_COPY"/> (299).
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, it returns an open handle to the specified snapshot.
        /// </para>
        /// <para>
        /// If the function fails, it returns <see cref="INVALID_HANDLE_VALUE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// Possible error codes include <see cref="ERROR_BAD_LENGTH"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The snapshot taken by this function is examined by the other tool help functions to provide their results.
        /// Access to the snapshot is read only.
        /// The snapshot handle acts as an object handle and is subject to the same rules regarding which processes and threads it is valid in.
        /// </para>
        /// <para>
        /// To enumerate the heap or module states for all processes,
        /// specify <see cref="TH32CS_SNAPALL"/> and set <paramref name="th32ProcessID"/> to zero.
        /// Then, for each additional process in the snapshot, call <see cref="CreateToolhelp32Snapshot"/> again,
        /// specifying its process identifier and the <see cref="TH32CS_SNAPHEAPLIST"/> or <see cref="TH32CS_SNAPMODULE"/> value.
        /// </para>
        /// <para>
        /// When taking snapshots that include heaps and modules for a process other than the current process,
        /// the <see cref="CreateToolhelp32Snapshot"/> function can fail or return incorrect information for a variety of reasons.
        /// For example, if the loader data table in the target process is corrupted or not initialized,
        /// or if the module list changes during the function call as a result of DLLs being loaded or unloaded,
        /// the function might fail with <see cref="ERROR_BAD_LENGTH"/> or other error code.
        /// Ensure that the target process was not started in a suspended state, and try calling the function again.
        /// If the function fails with <see cref="ERROR_BAD_LENGTH"/>
        /// when called with <see cref="TH32CS_SNAPMODULE"/> or <see cref="TH32CS_SNAPMODULE32"/>, call the function again until it succeeds.
        /// </para>
        /// <para>
        /// The <see cref="TH32CS_SNAPMODULE"/> and <see cref="TH32CS_SNAPMODULE32"/> flags do not retrieve handles
        /// for modules that were loaded with the <see cref="LOAD_LIBRARY_AS_DATAFILE"/> or similar flags.
        /// For more information, see <see cref="LoadLibraryEx"/>.
        /// </para>
        /// <para>
        /// To destroy the snapshot, use the <see cref="CloseHandle"/> function.
        /// </para>
        /// <para>
        /// Note that you can use the <see cref="QueryFullProcessImageName"/> function to retrieve the full name of an executable image
        /// for both 32- and 64-bit processes from a 32-bit process.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateToolhelp32Snapshot", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE CreateToolhelp32Snapshot([In] Toolhelp32SnapshotFlags dwFlags, [In] DWORD th32ProcessID);

        /// <summary>
        /// <para>
        /// Deletes the specified list of attributes for process and thread creation.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-deleteprocthreadattributelist"/>
        /// </para>
        /// </summary>
        /// <param name="lpAttributeList">
        /// The attribute list.
        /// This list is created by the <see cref="InitializeProcThreadAttributeList"/> function.
        /// </param>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteProcThreadAttributeList", ExactSpelling = true)]
        public static extern void DeleteProcThreadAttributeList([In] LPPROC_THREAD_ATTRIBUTE_LIST lpAttributeList);

        /// <summary>
        /// <para>
        /// Removes as many pages as possible from the working set of the specified process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/psapi/nf-psapi-emptyworkingset"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process.
        /// The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> or <see cref="PROCESS_QUERY_LIMITED_INFORMATION"/> access right
        /// and the <see cref="PROCESS_SET_QUOTA"/> access right.
        /// For more information, see Process Security and Access Rights.
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
        /// You can also empty the working set by calling the <see cref="SetProcessWorkingSetSize"/> or <see cref="SetProcessWorkingSetSizeEx"/> function
        /// with the <c>dwMinimumWorkingSetSize</c> and <c>dwMaximumWorkingSetSize</c> parameters set to the value <c>(SIZE_T)(-1)</c>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "K32EmptyWorkingSet", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EmptyWorkingSet([In] HANDLE hProcess);

        /// <summary>
        /// <para>
        /// Retrieves the process identifier for each process object in the system.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/psapi/nf-psapi-enumprocesses"/>
        /// </para>
        /// </summary>
        /// <param name="lpidProcess">
        /// A pointer to an array that receives the list of process identifiers.
        /// </param>
        /// <param name="cb">
        /// The size of the <paramref name="lpidProcess"/> array, in bytes.
        /// </param>
        /// <param name="lpcbNeeded">
        /// The number of bytes returned in the <paramref name="lpidProcess"/> array.
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
        /// It is a good idea to use a large array, because it is hard to predict how many processes there will be at the time you call <see cref="EnumProcesses"/>.
        /// </para>
        /// <para>
        /// To determine how many processes were enumerated, divide the <paramref name="lpcbNeeded"/> value by <c>sizeof(DWORD)</c>.
        /// There is no indication given when the buffer is too small to store all process identifiers.
        /// Therefore, if <paramref name="lpcbNeeded"/> equals <paramref name="cb"/>, consider retrying the call with a larger array.
        /// </para>
        /// <para>
        /// To obtain process handles for the processes whose identifiers you have just obtained, call the <see cref="OpenProcess"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "K32EnumProcesses", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnumProcesses([In][Out] DWORD[] lpidProcess, [In] DWORD cb, [Out] out DWORD lpcbNeeded);

        /// <summary>
        /// <para>
        /// Ends the calling process and all its threads.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-exitprocess"/>
        /// </para>
        /// </summary>
        /// <param name="uExitCode">
        /// The exit code for the process and all threads.
        /// </param>
        /// <remarks>
        /// <para>
        /// Use the <see cref="GetExitCodeProcess"/> function to retrieve the process's exit value.
        /// Use the <see cref="GetExitCodeThread"/> function to retrieve a thread's exit value.
        /// </para>
        /// <para>
        /// Exiting a process causes the following:
        /// </para>
        /// <para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// All of the threads in the process, except the calling thread,
        /// terminate their execution without receiving a <see cref="DLL_THREAD_DETACH"/> notification.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The states of all of the threads terminated in step 1 become signaled.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The entry-point functions of all loaded dynamic-link libraries (DLLs) are called with <see cref="DLL_PROCESS_DETACH"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// After all attached DLLs have executed any process termination code,
        /// the <see cref="ExitProcess"/> function terminates the current process, including the calling thread.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The state of the calling thread becomes signaled.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// All of the object handles opened by the process are closed.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The termination status of the process changes from <see cref="STILL_ACTIVE"/> to the exit value of the process.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The state of the process object becomes signaled, satisfying any threads that had been waiting for the process to terminate.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If one of the terminated threads in the process holds a lock and the DLL detach code in one of the loaded DLLs attempts to acquire the same lock,
        /// then calling <see cref="ExitProcess"/> results in a deadlock.
        /// In contrast, if a process terminates by calling <see cref="TerminateProcess"/>,
        /// the DLLs that the process is attached to are not notified of the process termination.
        /// Therefore, if you do not know the state of all threads in your process,
        /// it is better to call <see cref="TerminateProcess"/> than <see cref="ExitProcess"/>.
        /// Note that returning from the <c>main</c> function of an application results in a call to <see cref="ExitProcess"/>.
        /// </para>
        /// <para>
        /// Calling <see cref="ExitProcess"/> in a DLL can lead to unexpected application or system errors.
        /// Be sure to call <see cref="ExitProcess"/> from a DLL only if you know which applications
        /// or system components will load the DLL and that it is safe to call <see cref="ExitProcess"/> in this context.
        /// </para>
        /// <para>
        /// Exiting a process does not cause child processes to be terminated.
        /// </para>
        /// <para>
        /// Exiting a process does not necessarily remove the process object from the operating system.
        /// A process object is deleted when the last handle to the process is closed.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ExitProcess", ExactSpelling = true)]
        public static extern void ExitProcess([In] UINT uExitCode);

        /// <summary>
        /// <para>
        /// Flushes the instruction cache for the specified process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-flushinstructioncache"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// A handle to a process whose instruction cache is to be flushed.
        /// </param>
        /// <param name="lpBaseAddress">
        /// A pointer to the base of the region to be flushed.
        /// This parameter can be <see cref="NULL"/>.
        /// </param>
        /// <param name="dwSize">
        /// The size of the region to be flushed if the <paramref name="lpBaseAddress"/> parameter is not <see cref="NULL"/>, in bytes.
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
        /// Applications should call <see cref="FlushInstructionCache"/> if they generate or modify code in memory.
        /// The CPU cannot detect the change, and may execute the old code it cached.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FlushInstructionCache", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL FlushInstructionCache([In] HANDLE hProcess, [In] LPCVOID lpBaseAddress, [In] SIZE_T dwSize);

        /// <summary>
        /// <para>
        /// Flushes the write queue of each processor that is running a thread of the current process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-flushprocesswritebuffers"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// The function generates an interprocessor interrupt (IPI) to all processors that are part of the current process affinity.
        /// It guarantees the visibility of write operations performed on one processor to the other processors.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FlushProcessWriteBuffers", ExactSpelling = true)]
        public static extern void FlushProcessWriteBuffers();

        /// <summary>
        /// <para>
        /// Retrieves a pseudo handle for the current process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-getcurrentprocess"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// The return value is a pseudo handle to the current process.
        /// </returns>
        /// <remarks>
        /// <para>
        /// A pseudo handle is a special constant, currently (<see cref="HANDLE"/>)-1, that is interpreted as the current process handle.
        /// For compatibility with future operating systems,
        /// it is best to call <see cref="GetCurrentProcess"/> instead of hard-coding this constant value.
        /// The calling process can use a pseudo handle to specify its own process whenever a process handle is required.
        /// Pseudo handles are not inherited by child processes.
        /// </para>
        /// <para>
        /// This handle has the <see cref="PROCESS_ALL_ACCESS"/> access right to the process object.
        /// For more information, see Process Security and Access Rights.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:
        /// This handle has the maximum access allowed by the security descriptor of the process to the primary token of the process.
        /// </para>
        /// <para>
        /// A process can create a "real" handle to itself that is valid in the context of other processes, or that can be inherited by other processes,
        /// by specifying the pseudo handle as the source handle in a call to the <see cref="DuplicateHandle"/> function.
        /// A process can also use the <see cref="OpenProcess"/> function to open a real handle to itself.
        /// </para>
        /// <para>
        /// The pseudo handle need not be closed when it is no longer needed.
        /// Calling the <see cref="CloseHandle"/> function with a pseudo handle has no effect.
        /// If the pseudo handle is duplicated by <see cref="DuplicateHandle"/>, the duplicate handle must be closed.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCurrentProcess", ExactSpelling = true)]
        public static extern HANDLE GetCurrentProcess();

        /// <summary>
        /// <para>
        /// Retrieves the process identifier of the calling process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-getcurrentprocessid"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// The return value is the process identifier of the calling process.
        /// </returns>
        /// <remarks>
        /// Until the process terminates, the process identifier uniquely identifies the process throughout the system.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCurrentProcessId", ExactSpelling = true)]
        public static extern DWORD GetCurrentProcessId();

        /// <summary>
        /// <para>
        /// Retrieves the termination status of the specified process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-getexitcodeprocess"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// <para>
        /// A handle to the process.
        /// </para>
        /// <para>
        /// The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> or <see cref="PROCESS_QUERY_LIMITED_INFORMATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:
        /// The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> access right.
        /// </para>
        /// </param>
        /// <param name="lpExitCode">
        /// A pointer to a variable to receive the process termination status.
        /// For more information, see Remarks.
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
        /// This function returns immediately.
        /// If the process has not terminated and the function succeeds, the status returned is <see cref="STILL_ACTIVE"/>
        /// (a macro for <see cref="STATUS_PENDING"/> (minwinbase.h)).
        /// If the process has terminated and the function succeeds, the status returned is one of the following values:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The exit value specified in the <see cref="ExitProcess"/> or <see cref="TerminateProcess"/> function.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The return value from the <c>main</c> or <c>WinMain</c> function of the process.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The exception value for an unhandled exception that caused the process to terminate.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// The <see cref="GetExitCodeProcess"/> function returns a valid error code defined by the application only after the thread terminates.
        /// Therefore, an application should not use <see cref="STILL_ACTIVE"/> (259) as an error code
        /// (<see cref="STILL_ACTIVE"/> is a macro for <see cref="STATUS_PENDING"/> (minwinbase.h)).
        /// If a thread returns <see cref="STILL_ACTIVE"/> (259) as an error code,
        /// then applications that test for that value could interpret it to mean that the thread is still running,
        /// and continue to test for the completion of the thread after the thread has terminated,
        /// which could put the application into an infinite loop.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetExitCodeProcess", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetExitCodeProcess([In] HANDLE hProcess, [Out] out DWORD lpExitCode);

        /// <summary>
        /// <para>
        /// Retrieves the performance values contained in the <see cref="PERFORMANCE_INFORMATION"/> structure.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/psapi/nf-psapi-getperformanceinfo"/>
        /// </para>
        /// </summary>
        /// <param name="pPerformanceInformation">
        /// A pointer to a <see cref="PERFORMANCE_INFORMATION"/> structure that receives the performance information.
        /// </param>
        /// <param name="cb">
        /// The size of the <see cref="PERFORMANCE_INFORMATION"/> structure, in bytes.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "K32GetPerformanceInfo", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetPerformanceInfo([In][Out] ref PERFORMANCE_INFORMATION pPerformanceInformation, [In] DWORD cb);

        /// <summary>
        /// <para>
        /// Retrieves the priority class for the specified process.
        /// This value, together with the priority value of each thread of the process, determines each thread's base priority level.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-getpriorityclass"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// <para>
        /// The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> or <see cref="PROCESS_QUERY_LIMITED_INFORMATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:
        /// The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> access right.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the priority class of the specified process.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// The process's priority class is one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code/value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="ABOVE_NORMAL_PRIORITY_CLASS"/>
        /// </para>
        /// <para>
        /// 0x00008000
        /// </para>
        /// </term>
        /// <term>
        /// Process that has priority above <see cref="NORMAL_PRIORITY_CLASS"/> but below <see cref="HIGH_PRIORITY_CLASS"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BELOW_NORMAL_PRIORITY_CLASS"/>
        /// </para>
        /// <para>
        /// 0x00004000
        /// </para>
        /// </term>
        /// <term>
        /// Process that has priority above <see cref="IDLE_PRIORITY_CLASS"/> but below <see cref="NORMAL_PRIORITY_CLASS"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HIGH_PRIORITY_CLASS"/>
        /// </para>
        /// <para>
        /// 0x00000080
        /// </para>
        /// </term>
        /// <term>
        /// Process that performs time-critical tasks that must be executed immediately for it to run correctly.
        /// The threads of a high-priority class process preempt the threads of normal or idle priority class processes.
        /// An example is the Task List, which must respond quickly when called by the user, regardless of the load on the operating system.
        /// Use extreme care when using the high-priority class,
        /// because a high-priority class CPU-bound application can use nearly all available cycles.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="IDLE_PRIORITY_CLASS"/>
        /// </para>
        /// <para>
        /// 0x00000040
        /// </para>
        /// </term>
        /// <term>
        /// Process whose threads run only when the system is idle
        /// and are preempted by the threads of any process running in a higher priority class.
        /// An example is a screen saver. The idle priority class is inherited by child processes.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="NORMAL_PRIORITY_CLASS"/>
        /// </para>
        /// <para>
        /// 0x00000020
        /// </para>
        /// </term>
        /// <term>
        /// Process with no special scheduling needs.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="REALTIME_PRIORITY_CLASS"/>
        /// </para>
        /// <para>
        /// 0x00000100
        /// </para>
        /// </term>
        /// <term>
        /// Process that has the highest possible priority.
        /// The threads of a real-time priority class process preempt the threads of all other processes,
        /// including operating system processes performing important tasks.
        /// For example, a real-time process that executes for more than a very brief interval
        /// can cause disk caches not to flush or cause the mouse to be unresponsive.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Every thread has a base priority level determined by the thread's priority value and the priority class of its process.
        /// The operating system uses the base priority level of all executable threads to determine which thread gets the next slice of CPU time.
        /// Threads are scheduled in a round-robin fashion at each priority level,
        /// and only when there are no executable threads at a higher level will scheduling of threads at a lower level take place.
        /// </para>
        /// <para>
        /// For a table that shows the base priority levels for each combination of priority class and thread priority value, see Scheduling Priorities.
        /// </para>
        /// <para>
        /// Priority class is maintained by the executive, so all processes have a priority class that can be queried.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPriorityClass", ExactSpelling = true, SetLastError = true)]
        public static extern ProcessPriorityClasses GetPriorityClass([In] HANDLE hProcess);

        /// <summary>
        /// <para>
        /// Retrieves the process affinity mask for the specified process and the system affinity mask for the system.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getprocessaffinitymask"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// <para>
        /// A handle to the process whose affinity mask is desired.
        /// </para>
        /// <para>
        /// This handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> or <see cref="PROCESS_QUERY_LIMITED_INFORMATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:
        /// The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> access right.
        /// </para>
        /// </param>
        /// <param name="lpProcessAffinityMask">
        /// A pointer to a variable that receives the affinity mask for the specified process.
        /// </param>
        /// <param name="lpSystemAffinityMask">
        /// A pointer to a variable that receives the affinity mask for the system.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero and the function sets the variables
        /// pointed to by <paramref name="lpProcessAffinityMask"/> and <paramref name="lpSystemAffinityMask"/> to the appropriate affinity masks.
        /// </para>
        /// <para>
        /// On a system with more than 64 processors, if the threads of the calling process are in a single processor group,
        /// the function sets the variables pointed to by <paramref name="lpProcessAffinityMask"/> and <paramref name="lpSystemAffinityMask"/>
        /// to the process affinity mask and the processor mask of active logical processors for that group.
        /// If the calling process contains threads in multiple groups, the function returns zero for both affinity masks.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero, and the values of the variables
        /// pointed to by <paramref name="lpProcessAffinityMask"/> and <paramref name="lpSystemAffinityMask"/> are undefined.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// A process affinity mask is a bit vector in which each bit represents the processors that a process is allowed to run on.
        /// A system affinity mask is a bit vector in which each bit represents the processors that are configured into a system.
        /// </para>
        /// <para>
        /// A process affinity mask is a subset of the system affinity mask.
        /// A process is only allowed to run on the processors configured into a system.
        /// Therefore, the process affinity mask cannot specify a 1 bit for a processor
        /// when the system affinity mask specifies a 0 bit for that processor.
        /// </para>
        /// <para>
        /// Starting with Windows 11 and Windows Server 2022, on a system with more than 64 processors,
        /// process and thread affinities span all processors in the system, across all processor groups, by default.
        /// The <see cref="GetProcessAffinityMask"/> function sets the <paramref name="lpProcessAffinityMask"/>
        /// and <paramref name="lpSystemAffinityMask"/> to the process and system processor masks over the process' primary group.
        /// If the process had explicitly set the affinity of one or more of its threads outside of the process' primary group,
        /// the function returns zero for both affinity masks.
        /// If, however, <paramref name="hProcess"/> specifies a handle to the current process,
        /// the function always uses the calling thread's primary group (which by default is the same as the process' primary group)
        /// in order to set the <paramref name="lpProcessAffinityMask"/> and <paramref name="lpSystemAffinityMask"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetProcessAffinityMask", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetProcessAffinityMask([In] HANDLE hProcess, [Out] out DWORD_PTR lpProcessAffinityMask,
            [Out] out DWORD_PTR lpSystemAffinityMask);

        /// <summary>
        /// <para>
        /// Retrieves the number of open handles that belong to the specified process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-getprocesshandlecount"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// <para>
        /// A handle to the process whose handle count is being requested.
        /// The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> or <see cref="PROCESS_QUERY_LIMITED_INFORMATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:
        /// The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> access right.
        /// </para>
        /// </param>
        /// <param name="pdwHandleCount">
        /// A pointer to a variable that receives the number of open handles that belong to the specified process.
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
        /// This function retrieves information about the executive objects for the process.
        /// For more information, see Kernel Objects.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP, Note = "Windows XP with SP1")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetProcessHandleCount", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetProcessHandleCount([In] HANDLE hProcess, [In][Out] ref DWORD pdwHandleCount);

        /// <summary>
        /// <para>
        /// Retrieves the process identifier of the specified process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-getprocessid"/>
        /// </para>
        /// </summary>
        /// <param name="Process">
        /// <para>
        /// A handle to the process.
        /// The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> or <see cref="PROCESS_QUERY_LIMITED_INFORMATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:  The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> access right.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the process identifier.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// Until a process terminates, its process identifier uniquely identifies it on the system.
        /// For more information about access rights, see Process Security and Access Rights.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP, Note = "Windows XP with SP1")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetProcessId", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetProcessId([In] HANDLE Process);

        /// <summary>
        /// <para>
        /// Retrieves the name of the executable file for the specified process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/psapi/nf-psapi-getprocessimagefilenamew"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// <para>
        /// A handle to the process.
        /// The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> or <see cref="PROCESS_QUERY_LIMITED_INFORMATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:
        /// The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> access right.
        /// </para>
        /// </param>
        /// <param name="lpImageFileName">
        /// A pointer to a buffer that receives the full path to the executable file.
        /// </param>
        /// <param name="nSize">
        /// The size of the <paramref name="lpImageFileName"/> buffer, in characters.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value specifies the length of the string copied to the buffer.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The file Psapi.dll is installed in the %windir%\System32 directory.
        /// If there is another copy of this DLL on your computer, it can lead to the following error when running applications on your system:
        /// "The procedure entry point GetProcessImageFileName could not be located in the dynamic link library PSAPI.DLL."
        /// To work around this problem, locate any versions that are not in the %windir%\System32 directory and delete or rename them, then restart.
        /// </para>
        /// <para>
        /// The <see cref="GetProcessImageFileName"/> function returns the path in device form, rather than drive letters.
        /// For example, the file name C:\Windows\System32\Ctype.nls would look as follows in device form:
        /// </para>
        /// <para>
        /// \Device\Harddisk0\Partition1\Windows\System32\Ctype.nls
        /// </para>
        /// <para>
        /// To retrieve the module name of the current process, use the <see cref="GetModuleFileName"/> function with a <see cref="NULL"/> module handle.
        /// This is more efficient than calling the <see cref="GetProcessImageFileName"/> function with a handle to the current process.
        /// </para>
        /// <para>
        /// To retrieve the name of the main executable module for a remote process in win32 path format,
        /// use the <see cref="QueryFullProcessImageName"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "K32GetProcessImageFileNameW", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetProcessImageFileName([In] HANDLE hProcess, [In] IntPtr lpImageFileName, [In] DWORD nSize);

        /// <summary>
        /// <para>
        /// Retrieves information about the memory usage of the specified process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/psapi/nf-psapi-getprocessmemoryinfo"/>
        /// </para>
        /// </summary>
        /// <param name="Process">
        /// <para>
        /// A handle to the process.
        /// The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> or <see cref="PROCESS_QUERY_LIMITED_INFORMATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:
        /// The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> and <see cref="PROCESS_VM_READ"/> access rights.
        /// </para>
        /// </param>
        /// <param name="ppsmemCounters">
        /// A pointer to the <see cref="PROCESS_MEMORY_COUNTERS"/> or <see cref="PROCESS_MEMORY_COUNTERS_EX"/> structure
        /// that receives information about the memory usage of the process.
        /// </param>
        /// <param name="cb">
        /// The size of the <paramref name="ppsmemCounters"/> structure, in bytes.
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "K32GetProcessMemoryInfo", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetProcessMemoryInfo([In] HANDLE Process, [In][Out] ref PROCESS_MEMORY_COUNTERS ppsmemCounters, [In] DWORD cb);

        /// <summary>
        /// <para>
        /// Retrieves mitigation policy settings for the calling process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-getprocessmitigationpolicy"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// <para>
        /// The mitigation policy to retrieve. This parameter can be one of the following values.
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
        /// <see cref="ProcessDEPPolicy"/>
        /// </term>
        /// <term>
        /// <para>
        /// The data execution prevention (DEP) policy of the process.
        /// </para>
        /// <para>
        /// The <paramref name="lpBuffer"/> parameter points to a <see cref="PROCESS_MITIGATION_DEP_POLICY"/> structure
        /// that specifies the DEP policy flags.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ProcessASLRPolicy"/>
        /// </term>
        /// <term>
        /// <para>
        /// The Address Space Layout Randomization (ASLR) policy of the process.
        /// </para>
        /// <para>
        /// The <paramref name="lpBuffer"/> parameter points to a <see cref="PROCESS_MITIGATION_ASLR_POLICY"/> structure
        /// that specifies the ASLR policy flags.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ProcessDynamicCodePolicy"/>
        /// </term>
        /// <term>
        /// <para>
        /// The dynamic code policy of the process.
        /// When turned on, the process cannot generate dynamic code or modify existing executable code.
        /// </para>
        /// <para>
        /// The <paramref name="lpBuffer"/> parameter points to a <see cref="PROCESS_MITIGATION_DYNAMIC_CODE_POLICY"/> structure
        /// that specifies the dynamic code policy flags.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ProcessStrictHandleCheckPolicy"/>
        /// </term>
        /// <term>
        /// <para>
        /// The process will receive a fatal error if it manipulates a handle that is not valid.
        /// </para>
        /// <para>
        /// The <paramref name="lpBuffer"/> parameter points to a <see cref="PROCESS_MITIGATION_STRICT_HANDLE_CHECK_POLICY"/> structure
        /// that specifies the handle check policy flags.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ProcessSystemCallDisablePolicy"/>
        /// </term>
        /// <term>
        /// <para>
        /// Disables the ability to use NTUser/GDI functions at the lowest layer.
        /// </para>
        /// <para>
        /// The <paramref name="lpBuffer"/> parameter points to a <see cref="PROCESS_MITIGATION_SYSTEM_CALL_DISABLE_POLICY"/> structure
        /// that specifies the system call disable policy flags.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ProcessMitigationOptionsMask"/>
        /// </term>
        /// <term>
        /// <para>
        /// Returns the mask of valid bits for all the mitigation options on the system.
        /// An application can set many mitigation options without querying the operating system for mitigation options
        /// by combining bitwise with the mask to exclude all non-supported bits at once.
        /// </para>
        /// <para>
        /// The <paramref name="lpBuffer"/> parameter points to a <see cref="ULONG64"/> bit vector for the mask,
        /// or a two-element array of <see cref="ULONG64"/> bit vectors.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ProcessExtensionPointDisablePolicy"/>
        /// </term>
        /// <term>
        /// <para>
        /// Prevents certain built-in third party extension points from being enabled,
        /// preventing legacy extension point DLLs from being loaded into the process.
        /// </para>
        /// <para>
        /// The <paramref name="lpBuffer"/> parameter points to a <see cref="PROCESS_MITIGATION_EXTENSION_POINT_DISABLE_POLICY"/> structure
        /// that specifies the extension point disable policy flags.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ProcessControlFlowGuardPolicy"/>
        /// </term>
        /// <term>
        /// <para>
        /// The Control Flow Guard (CFG) policy of the process.
        /// </para>
        /// <para>
        /// The <paramref name="lpBuffer"/> parameter points to a <see cref="PROCESS_MITIGATION_CONTROL_FLOW_GUARD_POLICY"/> structure
        /// that specifies the CFG policy flags.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ProcessSignaturePolicy"/>
        /// </term>
        /// <term>
        /// <para>
        /// The policy of a process that can restrict image loading to those images that are either signed by Microsoft,
        /// by the Windows Store, or by Microsoft, the Windows Store and the Windows Hardware Quality Labs (WHQL).
        /// </para>
        /// <para>
        /// The <paramref name="lpBuffer"/> parameter points to a <see cref="PROCESS_MITIGATION_BINARY_SIGNATURE_POLICY"/> structure
        /// that specifies the signature policy flags.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ProcessFontDisablePolicy"/>
        /// </term>
        /// <term>
        /// <para>
        /// The policy regarding font loading for the process.
        /// When turned on, the process cannot load non-system fonts.
        /// </para>
        /// <para>
        /// The <paramref name="lpBuffer"/> parameter points to a <see cref="PROCESS_MITIGATION_FONT_DISABLE_POLICY"/> structure
        /// that specifies the policy flags for font loading.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ProcessImageLoadPolicy"/>
        /// </term>
        /// <term>
        /// <para>
        /// The policy regarding image loading for the process,
        /// which determines the types of executable images that are allowed to be mapped into the process.
        /// When turned on, images cannot be loaded from some locations, such a remote devices or files that have the low mandatory label.
        /// </para>
        /// <para>
        /// The <paramref name="lpBuffer"/> parameter points to a <see cref="PROCESS_MITIGATION_IMAGE_LOAD_POLICY"/> structure
        /// that specifies the policy flags for image loading.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ProcessRedirectionTrustPolicy"/>
        /// </term>
        /// <term>
        /// The RedirectionGuard policy of a process.
        /// The <paramref name="lpBuffer"/> parameter points to a <see cref="PROCESS_MITIGATION_REDIRECTION_TRUST_POLICY"/> structure
        /// that specifies the mitigation mode.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ProcessSideChannelIsolationPolicy"/>
        /// </term>
        /// <term>
        /// <para>
        /// Windows 10, version 1809 and above:
        /// The policy regarding isolation of side channels for the specified process.
        /// </para>
        /// <para>
        /// The <paramref name="lpBuffer"/> parameter points to a <see cref="PROCESS_MITIGATION_SIDE_CHANNEL_ISOLATION_POLICY"/> structure
        /// that specifies the policy flags for side channel isolation.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ProcessUserShadowStackPolicy"/>
        /// </term>
        /// <term>
        /// <para>
        /// Windows 10, version 2004 and above:
        /// The policy regarding user-mode Hardware-enforced Stack Protection for the specified process.
        /// </para>
        /// <para>
        /// The <paramref name="lpBuffer"/> parameter points to a <see cref="PROCESS_MITIGATION_USER_SHADOW_STACK_POLICY"/> structure
        /// that specifies the policy flags for user-mode Hardware-enforced Stack Protection.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpBuffer">
        /// <para>
        /// If the <paramref name="MitigationPolicy"/> parameter is <see cref="ProcessDEPPolicy"/>,
        /// this parameter points to a <see cref="PROCESS_MITIGATION_DEP_POLICY"/> structure
        /// that receives the DEP policy flags.
        /// </para>
        /// <para>
        /// If the <paramref name="MitigationPolicy"/> parameter is <see cref="ProcessASLRPolicy"/>,
        /// this parameter points to a <see cref="PROCESS_MITIGATION_ASLR_POLICY"/> structure
        /// that receives the ASLR policy flags.
        /// </para>
        /// <para>
        /// If the <paramref name="MitigationPolicy"/> parameter is <see cref="ProcessDynamicCodePolicy"/>,
        /// this parameter points to a <see cref="PROCESS_MITIGATION_DYNAMIC_CODE_POLICY"/> structure
        /// that receives the dynamic code policy flags.
        /// </para>
        /// <para>
        /// If the <paramref name="MitigationPolicy"/> parameter is <see cref="ProcessStrictHandleCheckPolicy"/>,
        /// this parameter points to a <see cref="PROCESS_MITIGATION_STRICT_HANDLE_CHECK_POLICY"/> structure
        /// that specifies the handle check policy flags.
        /// </para>
        /// <para>
        /// If the <paramref name="MitigationPolicy"/> parameter is <see cref="ProcessSystemCallDisablePolicy"/>,
        /// this parameter points to a <see cref="PROCESS_MITIGATION_SYSTEM_CALL_DISABLE_POLICY"/> structure
        /// that specifies the system call disable policy flags.
        /// </para>
        /// <para>
        /// If the <paramref name="MitigationPolicy"/> parameter is <see cref="ProcessMitigationOptionsMask"/>,
        /// this parameter points to a <see cref="ULONG64"/> bit vector for the mask
        /// or a two-element array of <see cref="ULONG64"/> bit vectors.
        /// </para>
        /// <para>
        /// If the <paramref name="MitigationPolicy"/> parameter is <see cref="ProcessExtensionPointDisablePolicy"/>,
        /// this parameter points to a <see cref="PROCESS_MITIGATION_EXTENSION_POINT_DISABLE_POLICY"/> structure
        /// that specifies the extension point disable policy flags.
        /// </para>
        /// <para>
        /// If the <paramref name="MitigationPolicy"/> parameter is <see cref="ProcessControlFlowGuardPolicy"/>,
        /// this parameter points to a <see cref="PROCESS_MITIGATION_CONTROL_FLOW_GUARD_POLICY"/> structure
        /// that specifies the CFG policy flags.
        /// </para>
        /// <para>
        /// If the <paramref name="MitigationPolicy"/> parameter is <see cref="ProcessSignaturePolicy"/>,
        /// this parameter points to a <see cref="PROCESS_MITIGATION_BINARY_SIGNATURE_POLICY"/> structure
        /// that receives the signature policy flags.
        /// </para>
        /// <para>
        /// If the <paramref name="MitigationPolicy"/> parameter is <see cref="ProcessFontDisablePolicy"/>,
        /// this parameter points to a <see cref="PROCESS_MITIGATION_FONT_DISABLE_POLICY"/> structure
        /// that receives the policy flags for font loading.
        /// </para>
        /// <para>
        /// If the <paramref name="MitigationPolicy"/> parameter is <see cref="ProcessImageLoadPolicy"/>,
        /// this parameter points to a <see cref="PROCESS_MITIGATION_IMAGE_LOAD_POLICY"/> structure
        /// that receives the policy flags for image loading.
        /// </para>
        /// <para>
        /// If the <paramref name="MitigationPolicy"/> parameter is <see cref="ProcessRedirectionTrustPolicy"/>,
        /// this parameter points to a <see cref="PROCESS_MITIGATION_REDIRECTION_TRUST_POLICY"/> structure
        /// that specifies the mitigation mode.
        /// </para>
        /// <para>
        /// If the <paramref name="MitigationPolicy"/> parameter is <see cref="ProcessUserShadowStackPolicy"/>,
        /// this parameter points to a <see cref="PROCESS_MITIGATION_USER_SHADOW_STACK_POLICY"/> structure
        /// that receives the policy flags for user-mode Hardware-enforced Stack Protection.
        /// </para>
        /// </param>
        /// <param name="dwLength">
        /// The size of <paramref name="lpBuffer"/>, in bytes.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To retrieve error values defined for this function, call <see cref="GetLastError"/>.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetProcessMitigationPolicy", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetProcessMitigationPolicy([In] HANDLE hProcess, [In] PROCESS_MITIGATION_POLICY MitigationPolicy,
            [In] PVOID lpBuffer, [In] SIZE_T dwLength);

        /// <summary>
        /// <para>
        /// Retrieves the priority boost control state of the specified process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-getprocesspriorityboost"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// <para>
        /// A handle to the process.
        /// This handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> or <see cref="PROCESS_QUERY_LIMITED_INFORMATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:
        /// The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> access right.
        /// </para>
        /// </param>
        /// <param name="pDisablePriorityBoost">
        /// A pointer to a variable that receives the priority boost control state.
        /// A value of <see cref="TRUE"/> indicates that dynamic boosting is disabled.
        /// A value of <see cref="FALSE"/> indicates normal behavior.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// In that case, the variable pointed to by the <paramref name="pDisablePriorityBoost"/> parameter receives the priority boost control state.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetProcessPriorityBoost", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetProcessPriorityBoost([In] HANDLE hProcess, [Out] out BOOL pDisablePriorityBoost);

        /// <summary>
        /// <para>
        /// Retrieves timing information for the specified process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-getprocesstimes"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// <para>
        /// A handle to the process whose timing information is sought.
        /// The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> or <see cref="PROCESS_QUERY_LIMITED_INFORMATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:
        /// The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> access right.
        /// </para>
        /// </param>
        /// <param name="lpCreationTime">
        /// A pointer to a <see cref="FILETIME"/> structure that receives the creation time of the process.
        /// </param>
        /// <param name="lpExitTime">
        /// A pointer to a <see cref="FILETIME"/> structure that receives the exit time of the process.
        /// If the process has not exited, the content of this structure is undefined.
        /// </param>
        /// <param name="lpKernelTime">
        /// A pointer to a <see cref="FILETIME"/> structure that receives the amount of time that the process has executed in kernel mode.
        /// The time that each of the threads of the process has executed in kernel mode is determined,
        /// and then all of those times are summed together to obtain this value.
        /// </param>
        /// <param name="lpUserTime">
        /// A pointer to a <see cref="FILETIME"/> structure that receives the amount of time that the process has executed in user mode.
        /// The time that each of the threads of the process has executed in user mode is determined,
        /// and then all of those times are summed together to obtain this value.
        /// Note that this value can exceed the amount of real time elapsed (between <paramref name="lpCreationTime"/> and <paramref name="lpExitTime"/>)
        /// if the process executes across multiple CPU cores.
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
        /// All times are expressed using <see cref="FILETIME"/> data structures.
        /// Such a structure contains two 32-bit values that combine to form a 64-bit count of 100-nanosecond time units.
        /// </para>
        /// <para>
        /// Process creation and exit times are points in time expressed as the amount of time
        /// that has elapsed since midnight on January 1, 1601 at Greenwich, England.
        /// There are several functions that an application can use to convert such values to more generally useful forms.
        /// </para>
        /// <para>
        /// Process kernel mode and user mode times are amounts of time.
        /// For example, if a process has spent one second in kernel mode,
        /// this function will fill the <see cref="FILETIME"/> structure specified by <paramref name="lpKernelTime"/> with a 64-bit value of ten million.
        /// That is the number of 100-nanosecond units in one second.
        /// </para>
        /// <para>
        /// To retrieve the number of CPU clock cycles used by the threads of the process,
        /// use the <see cref="QueryProcessCycleTime"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetProcessTimes", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetProcessTimes([In] HANDLE hProcess, [Out] out FILETIME lpCreationTime, [Out] out FILETIME lpExitTime,
            [Out] out FILETIME lpKernelTime, [Out] out FILETIME lpUserTime);

        /// <summary>
        /// <para>
        /// Retrieves the major and minor version numbers of the system on which the specified process expects to run.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-getprocessversion"/>
        /// </para>
        /// </summary>
        /// <param name="ProcessId">
        /// The process identifier of the process of interest.
        /// A value of zero specifies the calling process.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the version of the system on which the process expects to run.
        /// The high word of the return value contains the major version number.
        /// The low word of the return value contains the minor version number.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// The function fails if <paramref name="ProcessId"/> is an invalid value.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="GetProcessVersion"/> function performs less quickly
        /// when <paramref name="ProcessId"/> is nonzero, specifying a process other than the calling process.
        /// </para>
        /// <para>
        /// The version number returned by this function is the version number stamped in the image header of the .exe file the process is running.
        /// Linker programs set this value.
        /// </para>
        /// <para>
        /// If this function is called from a 32-bit application running on WOW64,
        /// the specified process must be a 32-bit process or the function fails.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetProcessVersion", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetProcessVersion([In] DWORD ProcessId);

        /// <summary>
        /// <para>
        /// Retrieves the contents of the <see cref="STARTUPINFO"/> structure that was specified when the calling process was created.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-getstartupinfow"/>
        /// </para>
        /// </summary>
        /// <param name="lpStartupInfo">
        /// A pointer to a <see cref="STARTUPINFO"/> structure that receives the startup information.
        /// </param>
        /// <remarks>
        /// The <see cref="STARTUPINFO"/> structure was specified by the process that created the calling process.
        /// It can be used to specify properties associated with the main window of the calling process.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetStartupInfoW", ExactSpelling = true)]
        public static extern void GetStartupInfo([Out] out STARTUPINFO lpStartupInfo);

        /// <summary>
        /// <para>
        /// Initializes the specified list of attributes for process and thread creation.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-initializeprocthreadattributelist"/>
        /// </para>
        /// </summary>
        /// <param name="lpAttributeList">
        /// The attribute list.
        /// This parameter can be <see cref="NULL"/> to determine the buffer size required to support the specified number of attributes.
        /// </param>
        /// <param name="dwAttributeCount">
        /// The count of attributes to be added to the list.
        /// </param>
        /// <param name="dwFlags">
        /// This parameter is reserved and must be zero.
        /// </param>
        /// <param name="lpSize">
        /// <para>
        /// If <paramref name="lpAttributeList"/> is not <see cref="NULL"/>,
        /// this parameter specifies the size in bytes of the <paramref name="lpAttributeList"/> buffer on input.
        /// On output, this parameter receives the size in bytes of the initialized attribute list.
        /// </para>
        /// <para>
        /// If <paramref name="lpAttributeList"/> is <see cref="NULL"/>, this parameter receives the required buffer size in bytes.
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
        /// First, call this function with the <paramref name="dwAttributeCount"/> parameter set to the maximum number of attributes
        /// you will be using and the <paramref name="lpAttributeList"/> to <see cref="NULL"/>.
        /// The function returns the required buffer size in bytes in the <paramref name="lpSize"/> parameter.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This initial call will return an error by design. This is expected behavior.
        /// Allocate enough space for the data in the <paramref name="lpAttributeList"/> buffer and call the function again to initialize the buffer.
        /// </para>
        /// <para>
        /// To add attributes to the list, call the <see cref="UpdateProcThreadAttribute"/> function.
        /// To specify these attributes when creating a process, specify <see cref="EXTENDED_STARTUPINFO_PRESENT"/>
        /// in the <c>dwCreationFlag</c> parameter and a <see cref="STARTUPINFOEX"/> structure in the <c>lpStartupInfo</c> parameter.
        /// Note that you can specify the same <see cref="STARTUPINFOEX"/> structure to multiple child processes.
        /// </para>
        /// <para>
        /// When you have finished using the list, call the <see cref="DeleteProcThreadAttributeList"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitializeProcThreadAttributeList", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL InitializeProcThreadAttributeList([In] LPPROC_THREAD_ATTRIBUTE_LIST lpAttributeList, [In] DWORD dwAttributeCount,
            [In] DWORD dwFlags, [In][Out] ref SIZE_T lpSize);

        /// <summary>
        /// <para>
        /// Loads and executes an application or creates a new instance of an existing application.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-loadmodule"/>
        /// </para>
        /// </summary>
        /// <param name="lpModuleName">
        /// <para>
        /// The file name of the application to be run.
        /// When specifying a path, be sure to use backslashes (\), not forward slashes (/).
        /// If the <paramref name="lpModuleName"/> parameter does not contain a directory path,
        /// the system searches for the executable file in this order:
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
        /// The current directory.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The system directory.
        /// Use the <see cref="GetSystemDirectory"/> function to get the path of this directory.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The 16-bit system directory.
        /// There is no function that obtains the path of this directory, but it is searched.
        /// The name of this directory is System.
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
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpParameterBlock">
        /// <para>
        /// A pointer to an application-defined <see cref="LOADPARMS32"/> structure that defines the new application's parameter block.
        /// </para>
        /// <para>
        /// Set all unused members to <see cref="NULL"/>, except for <see cref="LOADPARMS32.lpCmdLine"/>,
        /// which must point to a null-terminated string if it is not used.
        /// For more information, see Remarks.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is greater than 31.
        /// </para>
        /// <para>
        /// If the function fails, the return value is an error value, which may be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code/value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0
        /// </term>
        /// <term>
        /// The system is out of memory or resources.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="ERROR_BAD_FORMAT"/>
        /// </para>
        /// <para>
        /// 11L
        /// </para>
        /// </term>
        /// <term>
        /// The .exe file is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="ERROR_FILE_NOT_FOUND"/>
        /// </para>
        /// <para>
        /// 2L
        /// </para>
        /// </term>
        /// <term>
        /// The specified file was not found.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="ERROR_PATH_NOT_FOUND"/>
        /// </para>
        /// <para>
        /// 3L
        /// </para>
        /// </term>
        /// <term>
        /// The specified path was not found.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        [Obsolete("This function is provided only for compatibility with 16-bit versions of Windows. Applications should use the CreateProcess function.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadModule", ExactSpelling = true)]
        public static extern DWORD LoadModule([In] LPCWSTR lpModuleName, [In] LPVOID lpParameterBlock);

        /// <summary>
        /// <para>
        /// Opens an existing local process object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-openprocess"/>
        /// </para>
        /// </summary>
        /// <param name="dwDesiredAccess">
        /// <para>
        /// The access to the process object.
        /// This access right is checked against the security descriptor for the process.
        /// This parameter can be one or more of the process access rights.
        /// </para>
        /// <para>
        /// If the caller has enabled the <c>SeDebugPrivilege</c> privilege,
        /// the requested access is granted regardless of the contents of the security descriptor.
        /// </para>
        /// </param>
        /// <param name="bInheritHandle">
        /// If this value is <see cref="TRUE"/>, processes created by this process will inherit the handle.
        /// Otherwise, the processes do not inherit this handle.
        /// </param>
        /// <param name="dwProcessId">
        /// <para>
        /// The identifier of the local process to be opened.
        /// </para>
        /// <para>
        /// If the specified process is the System Idle Process (0x00000000), the function fails
        /// and the last error code is <see cref="ERROR_INVALID_PARAMETER"/>.
        /// If the specified process is the System process or one of the Client Server Run-Time Subsystem (CSRSS) processes,
        /// this function fails and the last error code is <see cref="ERROR_ACCESS_DENIED"/>
        /// because their access restrictions prevent user-level code from opening them.
        /// </para>
        /// <para>
        /// If you are using <see cref="GetCurrentProcessId"/> as an argument to this function,
        /// consider using <see cref="GetCurrentProcess"/> instead of <see cref="OpenProcess"/>, for improved performance.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is an open handle to the specified process.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To open a handle to another local process and obtain full access rights, you must enable the <c>SeDebugPrivilege</c> privilege.
        /// For more information, see Changing Privileges in a Token.
        /// </para>
        /// <para>
        /// The handle returned by the <see cref="OpenProcess"/> function can be used in any function that requires a handle to a process,
        /// such as the wait functions, provided the appropriate access rights were requested.
        /// </para>
        /// <para>
        /// When you are finished with the handle, be sure to close it using the <see cref="CloseHandle"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "OpenProcess", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE OpenProcess([In] ACCESS_MASK dwDesiredAccess, [In] BOOL bInheritHandle, [In] DWORD dwProcessId);

        /// <summary>
        /// <para>
        /// Retrieves information about the first process encountered in a system snapshot.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/tlhelp32/nf-tlhelp32-process32firstw"/>
        /// </para>
        /// </summary>
        /// <param name="hSnapshot">
        /// A handle to the snapshot returned from a previous call to the <see cref="CreateToolhelp32Snapshot"/> function.
        /// </param>
        /// <param name="lppe">
        /// A pointer to a <see cref="PROCESSENTRY32"/> structure.
        /// It contains process information such as the name of the executable file,
        /// the process identifier, and the process identifier of the parent process.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if the first entry of the process list has been copied to the buffer or <see cref="FALSE"/> otherwise.
        /// The <see cref="ERROR_NO_MORE_FILES"/> error value is returned by the <see cref="GetLastError"/> function
        /// if no processes exist or the snapshot does not contain process information.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The calling application must set the <see cref="PROCESSENTRY32.dwSize"/> member
        /// of <see cref="PROCESSENTRY32"/> to the size, in bytes, of the structure.
        /// </para>
        /// <para>
        /// To retrieve information about other processes recorded in the same snapshot, use the <see cref="Process32Next"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "Process32FirstW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL Process32First([In] HANDLE hSnapshot, [In][Out] ref PROCESSENTRY32 lppe);

        /// <summary>
        /// <para>
        /// Retrieves information about the next process recorded in a system snapshot.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/tlhelp32/nf-tlhelp32-process32nextw"/>
        /// </para>
        /// </summary>
        /// <param name="hSnapshot">
        /// A handle to the snapshot returned from a previous call to the <see cref="CreateToolhelp32Snapshot"/> function.
        /// </param>
        /// <param name="lppe">
        /// A pointer to a <see cref="PROCESSENTRY32"/> structure.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if the next entry of the process list has been copied to the buffer or <see cref="FALSE"/> otherwise.
        /// The <see cref="ERROR_NO_MORE_FILES"/> error value is returned by the <see cref="GetLastError"/> function
        /// if no processes exist or the snapshot does not contain process information.
        /// </returns>
        /// <remarks>
        /// To retrieve information about the first process recorded in a snapshot, use the <see cref="Process32First"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "Process32NextW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL Process32Next([In] HANDLE hSnapshot, [In][Out] ref PROCESSENTRY32 lppe);

        /// <summary>
        /// <para>
        /// Retrieves the Remote Desktop Services session associated with a specified process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-processidtosessionid"/>
        /// </para>
        /// </summary>
        /// <param name="dwProcessId">
        /// Specifies a process identifier.
        /// Use the <see cref="GetCurrentProcessId"/> function to retrieve the process identifier for the current process.
        /// </param>
        /// <param name="pSessionId">
        /// Pointer to a variable that receives the identifier of the Remote Desktop Services session under which the specified process is running.
        /// To retrieve the identifier of the session currently attached to the console, use the <see cref="WTSGetActiveConsoleSessionId"/> function.
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
        /// Callers must hold the <see cref="PROCESS_QUERY_INFORMATION"/> access right for the specified process.
        /// For more information, see Process Security and Access Rights.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ProcessIdToSessionId", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ProcessIdToSessionId([In] DWORD dwProcessId, [Out] out DWORD pSessionId);

        /// <summary>
        /// <para>
        /// Retrieves the full name of the executable image for the specified process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-queryfullprocessimagenamew"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process.
        /// This handle must be created with the <see cref="PROCESS_QUERY_INFORMATION"/> or <see cref="PROCESS_QUERY_LIMITED_INFORMATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </param>
        /// <param name="dwFlags">
        /// <para>
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
        /// 0
        /// </term>
        /// <term>
        /// The name should use the Win32 path format.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PROCESS_NAME_NATIVE"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// The name should use the native system path format.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpExeName">
        /// The path to the executable image.
        /// If the function succeeds, this string is null-terminated.
        /// </param>
        /// <param name="lpdwSize">
        /// On input, specifies the size of the <paramref name="lpExeName"/> buffer, in characters.
        /// On success, receives the number of characters written to the buffer, not including the null-terminating character.
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
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "QueryFullProcessImageNameW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL QueryFullProcessImageName([In] HANDLE hProcess, [In] DWORD dwFlags, [In] IntPtr lpExeName, [In][Out] ref DWORD lpdwSize);

        /// <summary>
        /// <para>
        /// Retrieves the affinity update mode of the specified process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-queryprocessaffinityupdatemode"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process.
        /// The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> or <see cref="PROCESS_QUERY_LIMITED_INFORMATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </param>
        /// <param name="lpdwFlags">
        /// <para>
        /// The affinity update mode.
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
        /// 0
        /// </term>
        /// <term>
        /// Dynamic update of the process affinity by the system is disabled.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PROCESS_AFFINITY_ENABLE_AUTO_UPDATE"/>
        /// </para>
        /// <para>
        /// 0x00000001UL
        /// </para>
        /// </term>
        /// <term>
        /// Dynamic update of the process affinity by the system is enabled.
        /// </term>
        /// </item>
        /// </list>
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
        [WindowsVersionRequirement(WindowsVersion.WindowsVista, BuildNumbers.WindowsVistaSP1)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "QueryProcessAffinityUpdateMode", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL QueryProcessAffinityUpdateMode([In] HANDLE hProcess, [Out] out DWORD lpdwFlags);

        /// <summary>
        /// <para>
        /// Retrieves the sum of the cycle time of all threads of the specified process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/realtimeapiset/nf-realtimeapiset-queryprocesscycletime"/>
        /// </para>
        /// </summary>
        /// <param name="ProcessHandle">
        /// A handle to the process.
        /// The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> or <see cref="PROCESS_QUERY_LIMITED_INFORMATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </param>
        /// <param name="CycleTime">
        /// The number of CPU clock cycles used by the threads of the process.
        /// This value includes cycles spent in both user mode and kernel mode.
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
        /// To enumerate the processes in the system, use the <see cref="EnumProcesses"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "QueryProcessCycleTime", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL QueryProcessCycleTime([In] HANDLE ProcessHandle, [Out] out ULONG64 CycleTime);

        /// <summary>
        /// <para>
        /// Retrieves information about the pages currently added to the working set of the specified process.
        /// </para>
        /// <para>
        /// To retrieve working set information for a subset of virtual addresses,
        /// or to retrieve information about pages that are not part of the working set (such as AWE or large pages),
        /// use the <see cref="QueryWorkingSetEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/psapi/nf-psapi-queryworkingset"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process.
        /// The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> and <see cref="PROCESS_VM_READ"/> access rights.
        /// For more information, see Process Security and Access Rights.
        /// </param>
        /// <param name="pv">
        /// <para>
        /// A pointer to the buffer that receives the information.
        /// For more information, see <see cref="PSAPI_WORKING_SET_INFORMATION"/>.
        /// </para>
        /// <para>
        /// If the buffer pointed to by the <paramref name="pv"/> parameter is not large enough
        /// to contain all working set entries for the target process, the function fails with <see cref="ERROR_BAD_LENGTH"/>.
        /// In this case, the <see cref="PSAPI_WORKING_SET_INFORMATION.NumberOfEntries"/> member
        /// of the <see cref="PSAPI_WORKING_SET_INFORMATION"/> structure is set to the required number of entries,
        /// but the function does not return information about the working set entries.
        /// </para>
        /// </param>
        /// <param name="cb">
        /// The size of the <paramref name="pv"/> buffer, in bytes.
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "K32QueryWorkingSet", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL QueryWorkingSet([In] HANDLE hProcess, [In] PVOID pv, [In] DWORD cb);

        /// <summary>
        /// <para>
        /// Retrieves extended information about the pages at specific virtual addresses in the address space of the specified process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/psapi/nf-psapi-queryworkingsetex"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process.
        /// The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </param>
        /// <param name="pv">
        /// A pointer to an array of <see cref="PSAPI_WORKING_SET_EX_INFORMATION"/> structures.
        /// On input, each item in the array specifies a virtual address of interest.
        /// On output, each item in the array receives information about the corresponding virtual page.
        /// </param>
        /// <param name="cb">
        /// The size of the <paramref name="pv"/> buffer, in bytes.
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
        /// Unlike the <see cref="QueryWorkingSet"/> function, which is limited to the working set of the target process,
        /// the <see cref="QueryWorkingSetEx"/> function can be used to query addresses that are not in the process working set
        /// but are still part of the process, such as AWE and large pages.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "K32QueryWorkingSetEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL QueryWorkingSetEx([In] HANDLE hProcess, [In] PVOID pv, [In] DWORD cb);

        /// <summary>
        /// <para>
        /// Sets the priority class for the specified process.
        /// This value together with the priority value of each thread of the process determines each thread's base priority level.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-setpriorityclass"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// <para>
        /// A handle to the process.
        /// </para>
        /// <para>
        /// The handle must have the <see cref="PROCESS_SET_INFORMATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </para>
        /// </param>
        /// <param name="dwPriorityClass">
        /// <para>
        /// The priority class for the process.
        /// This parameter can be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Priority
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="ABOVE_NORMAL_PRIORITY_CLASS"/>
        /// </para>
        /// <para>
        /// 0x00008000
        /// </para>
        /// </term>
        /// <term>
        /// Process that has priority above <see cref="NORMAL_PRIORITY_CLASS"/> but below <see cref="HIGH_PRIORITY_CLASS"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BELOW_NORMAL_PRIORITY_CLASS"/>
        /// </para>
        /// <para>
        /// 0x00004000
        /// </para>
        /// </term>
        /// <term>
        /// Process that has priority above <see cref="IDLE_PRIORITY_CLASS"/> but below <see cref="NORMAL_PRIORITY_CLASS"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HIGH_PRIORITY_CLASS"/>
        /// </para>
        /// <para>
        /// 0x00000080
        /// </para>
        /// </term>
        /// <term>
        /// Process that performs time-critical tasks that must be executed immediately.
        /// The threads of the process preempt the threads of normal or idle priority class processes.
        /// An example is the Task List, which must respond quickly when called by the user, regardless of the load on the operating system.
        /// Use extreme care when using the high-priority class, because a high-priority class application can use nearly all available CPU time.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="IDLE_PRIORITY_CLASS"/>
        /// </para>
        /// <para>
        /// 0x00000040
        /// </para>
        /// </term>
        /// <term>
        /// Process whose threads run only when the system is idle.
        /// The threads of the process are preempted by the threads of any process running in a higher priority class.
        /// An example is a screen saver. The idle-priority class is inherited by child processes.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="NORMAL_PRIORITY_CLASS"/>
        /// </para>
        /// <para>
        /// 0x00000020
        /// </para>
        /// </term>
        /// <term>
        /// Process with no special scheduling needs.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PROCESS_MODE_BACKGROUND_BEGIN"/>
        /// </para>
        /// <para>
        /// 0x00100000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Begin background processing mode.
        /// The system lowers the resource scheduling priorities of the process (and its threads)
        /// so that it can perform background work without significantly affecting activity in the foreground.
        /// </para>
        /// <para>
        /// This value can be specified only if <paramref name="hProcess"/> is a handle to the current process.
        /// The function fails if the process is already in background processing mode.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:
        /// This value is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PROCESS_MODE_BACKGROUND_END"/>
        /// </para>
        /// <para>
        /// 0x00200000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// End background processing mode.
        /// The system restores the resource scheduling priorities of the process (and its threads)
        /// as they were before the process entered background processing mode.
        /// </para>
        /// <para>
        /// This value can be specified only if <paramref name="hProcess"/> is a handle to the current process.
        /// The function fails if the process is not in background processing mode.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:
        /// This value is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="REALTIME_PRIORITY_CLASS"/>
        /// </para>
        /// <para>
        /// 0x00000100
        /// </para>
        /// </term>
        /// <term>
        /// Process that has the highest possible priority.
        /// The threads of the process preempt the threads of all other processes,
        /// including operating system processes performing important tasks.
        /// For example, a real-time process that executes for more than a very brief interval
        /// can cause disk caches not to flush or cause the mouse to be unresponsive.
        /// </term>
        /// </item>
        /// </list>
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
        /// Every thread has a base priority level determined by the thread's priority value and the priority class of its process.
        /// The system uses the base priority level of all executable threads to determine which thread gets the next slice of CPU time.
        /// The <see cref="SetThreadPriority"/> function enables setting the base priority level of a thread
        /// relative to the priority class of its process.
        /// For more information, see Scheduling Priorities.
        /// </para>
        /// <para>
        /// The <c>*_PRIORITY_CLASS</c> values affect the CPU scheduling priority of the process.
        /// For processes that perform background work such as file I/O, network I/O, or data processing,
        /// it is not sufficient to adjust the CPU scheduling priority;
        /// even an idle CPU priority process can easily interfere with system responsiveness when it uses the disk and memory.
        /// Processes that perform background work should use the <see cref="PROCESS_MODE_BACKGROUND_BEGIN"/>
        /// and <see cref="PROCESS_MODE_BACKGROUND_END"/> values to adjust their resource scheduling priorities;
        /// processes that interact with the user should not use <see cref="PROCESS_MODE_BACKGROUND_BEGIN"/>.
        /// </para>
        /// <para>
        /// If a process is in background processing mode, the new threads it creates will also be in background processing mode.
        /// When a thread is in background processing mode, it should minimize sharing resources
        /// such as critical sections, heaps, and handles with other threads in the process, otherwise priority inversions can occur.
        /// If there are threads executing at high priority,
        /// a thread in background processing mode may not be scheduled promptly, but it will never be starved.
        /// </para>
        /// <para>
        /// Each thread can enter background processing mode independently using <see cref="SetThreadPriority"/>.
        /// Do not call <see cref="SetPriorityClass"/> to enter background processing mode
        /// after a thread in the process has called <see cref="SetThreadPriority"/> to enter background processing mode.
        /// After a process ends background processing mode, it resets all threads in the process;
        /// however, it is not possible for the process to know which threads were already in background processing mode.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetPriorityClass", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetPriorityClass([In] HANDLE hProcess, [In] ProcessPriorityClasses dwPriorityClass);

        /// <summary>
        /// <para>
        /// Sets a processor affinity mask for the threads of the specified process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-setprocessaffinitymask"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process whose affinity mask is to be set.
        /// This handle must have the <see cref="PROCESS_SET_INFORMATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </param>
        /// <param name="dwProcessAffinityMask">
        /// <para>
        /// The affinity mask for the threads of the process.
        /// </para>
        /// <para>
        /// On a system with more than 64 processors, the affinity mask must specify processors in a single processor group.
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
        /// If the process affinity mask requests a processor that is not configured in the system,
        /// the last error code is <see cref="ERROR_INVALID_PARAMETER"/>.
        /// </para>
        /// <para>
        /// On a system with more than 64 processors, if the calling process contains threads in more than one processor group,
        /// the last error code is <see cref="ERROR_INVALID_PARAMETER"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// A process affinity mask is a bit vector in which each bit represents a logical processor
        /// on which the threads of the process are allowed to run.
        /// The value of the process affinity mask must be a subset of the system affinity mask values
        /// obtained by the <see cref="GetProcessAffinityMask"/> function.
        /// A process is only allowed to run on the processors configured into a system.
        /// Therefore, the process affinity mask cannot specify a 1 bit for a processor
        /// when the system affinity mask specifies a 0 bit for that processor.
        /// </para>
        /// <para>
        /// Process affinity is inherited by any child process or newly instantiated local process.
        /// </para>
        /// <para>
        /// Do not call <see cref="SetProcessAffinityMask"/> in a DLL that may be called by processes other than your own.
        /// </para>
        /// <para>
        /// On a system with more than 64 processors, the <see cref="SetProcessAffinityMask"/> function can be used
        /// to set the process affinity mask only for processes with threads in a single processor group.
        /// Use the <see cref="SetThreadAffinityMask"/> function to set the affinity mask for individual threads in multiple groups.
        /// This effectively changes the group assignment of the process.
        /// </para>
        /// <para>
        /// Starting with Windows 11 and Windows Server 2022, on a system with more than 64 processors,
        /// process and thread affinities span all processors in the system, across all processor groups, by default.
        /// Instead of always failing in case the calling process contains threads in more than one processor group,
        /// the <see cref="SetProcessAffinityMask"/> function fails (returning zero with <see cref="ERROR_INVALID_PARAMETER"/> last error code)
        /// if the process had explicitly set the affinity of one or more of its threads outside of the process' primary group.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetProcessAffinityMask", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetProcessAffinityMask([In] HANDLE hProcess, [In] DWORD_PTR dwProcessAffinityMask);

        /// <summary>
        /// <para>
        /// Sets the affinity update mode of the specified process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-setprocessaffinityupdatemode"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process.
        /// This handle must be returned by the <see cref="GetCurrentProcess"/> function.
        /// </param>
        /// <param name="dwFlags">
        /// <para>
        /// The affinity update mode.
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
        /// 0
        /// </term>
        /// <term>
        /// Disables dynamic update of the process affinity by the system.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PROCESS_AFFINITY_ENABLE_AUTO_UPDATE"/>
        /// </para>
        /// <para>
        /// 0x00000001UL
        /// </para>
        /// </term>
        /// <term>
        /// Enables dynamic update of the process affinity by the system.
        /// </term>
        /// </item>
        /// </list>
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
        /// The system can adjust process affinity under various conditions, such as when a processor is added dynamically.
        /// By default, dynamic updates to the process affinity are disabled for each process.
        /// </para>
        /// <para>
        /// Processes should use this function to indicate whether they can handle dynamic adjustment of process affinity by the system.
        /// After a process enables affinity update mode, it can call this function to disable it.
        /// However, a process cannot enable affinity update mode after it has used this function to disable it.
        /// </para>
        /// <para>
        /// Child processes do not inherit the affinity update mode of the parent process.
        /// The affinity update mode must be explicitly set for each child process.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista, BuildNumbers.WindowsVistaSP1)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetProcessAffinityUpdateMode", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetProcessAffinityUpdateMode([In] HANDLE hProcess, [In] DWORD dwFlags);

        /// <summary>
        /// <para>
        /// Sets a mitigation policy for the calling process.
        /// Mitigation policies enable a process to harden itself against various types of attacks.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-setprocessmitigationpolicy"/>
        /// </para>
        /// </summary>
        /// <param name="MitigationPolicy">
        /// <para>
        /// The mitigation policy to apply. This parameter can be one of the following values.
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
        /// <see cref="ProcessDEPPolicy"/>
        /// </term>
        /// <term>
        /// <para>
        /// The data execution prevention (DEP) policy of the process.
        /// </para>
        /// <para>
        /// The <paramref name="lpBuffer"/> parameter points to a <see cref="PROCESS_MITIGATION_DEP_POLICY"/> structure
        /// that specifies the DEP policy flags.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ProcessASLRPolicy"/>
        /// </term>
        /// <term>
        /// <para>
        /// The Address Space Layout Randomization (ASLR) policy of the process.
        /// </para>
        /// <para>
        /// The <paramref name="lpBuffer"/> parameter points to a <see cref="PROCESS_MITIGATION_ASLR_POLICY"/> structure
        /// that specifies the ASLR policy flags.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ProcessDynamicCodePolicy"/>
        /// </term>
        /// <term>
        /// <para>
        /// The dynamic code policy of the process.
        /// When turned on, the process cannot generate dynamic code or modify existing executable code.
        /// </para>
        /// <para>
        /// The <paramref name="lpBuffer"/> parameter points to a <see cref="PROCESS_MITIGATION_DYNAMIC_CODE_POLICY"/> structure
        /// that specifies the dynamic code policy flags.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ProcessStrictHandleCheckPolicy"/>
        /// </term>
        /// <term>
        /// <para>
        /// The process will receive a fatal error if it manipulates a handle that is not valid.
        /// </para>
        /// <para>
        /// The <paramref name="lpBuffer"/> parameter points to a <see cref="PROCESS_MITIGATION_STRICT_HANDLE_CHECK_POLICY"/> structure
        /// that specifies the handle check policy flags.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ProcessSystemCallDisablePolicy"/>
        /// </term>
        /// <term>
        /// <para>
        /// Disables the ability to use NTUser/GDI functions at the lowest layer.
        /// </para>
        /// <para>
        /// The <paramref name="lpBuffer"/> parameter points to a <see cref="PROCESS_MITIGATION_SYSTEM_CALL_DISABLE_POLICY"/> structure
        /// that specifies the system call disable policy flags.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ProcessMitigationOptionsMask"/>
        /// </term>
        /// <term>
        /// <para>
        /// Returns the mask of valid bits for all the mitigation options on the system.
        /// An application can set many mitigation options without querying the operating system for mitigation options
        /// by combining bitwise with the mask to exclude all non-supported bits at once.
        /// </para>
        /// <para>
        /// The <paramref name="lpBuffer"/> parameter points to a <see cref="ULONG64"/> bit vector for the mask,
        /// or to accommodate more than 64 bits, a two-element array of <see cref="ULONG64"/> bit vectors.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ProcessExtensionPointDisablePolicy"/>
        /// </term>
        /// <term>
        /// The <paramref name="lpBuffer"/> parameter points to a <see cref="PROCESS_MITIGATION_EXTENSION_POINT_DISABLE_POLICY"/> structure
        /// that specifies the extension point disable policy flags.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ProcessControlFlowGuardPolicy"/>
        /// </term>
        /// <term>
        /// <para>
        /// The Control Flow Guard (CFG) policy of the process.
        /// </para>
        /// <para>
        /// The <paramref name="lpBuffer"/> parameter points to a <see cref="PROCESS_MITIGATION_CONTROL_FLOW_GUARD_POLICY"/> structure
        /// that specifies the CFG policy flags.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ProcessSignaturePolicy"/>
        /// </term>
        /// <term>
        /// <para>
        /// The policy of a process that can restrict image loading to those images that are either signed by Microsoft,
        /// by the Windows Store, or by Microsoft, the Windows Store and the Windows Hardware Quality Labs (WHQL).
        /// </para>
        /// <para>
        /// he <paramref name="lpBuffer"/> parameter points to a <see cref="PROCESS_MITIGATION_BINARY_SIGNATURE_POLICY"/> structure
        /// that specifies the signature policy flags.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ProcessFontDisablePolicy"/>
        /// </term>
        /// <term>
        /// <para>
        /// The policy regarding font loading for the process.
        /// When turned on, the process cannot load non-system fonts.
        /// </para>
        /// <para>
        /// The <paramref name="lpBuffer"/> parameter points to a <see cref="PROCESS_MITIGATION_FONT_DISABLE_POLICY"/> structure
        /// that specifies the policy flags for font loading.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ProcessImageLoadPolicy"/>
        /// </term>
        /// <term>
        /// <para>
        /// The policy regarding image loading for the process,
        /// which determines the types of executable images that are allowed to be mapped into the process.
        /// When turned on, images cannot be loaded from some locations, such a remote devices or files that have the low mandatory label.
        /// </para>
        /// <para>
        /// The <paramref name="lpBuffer"/> parameter points to a <see cref="PROCESS_MITIGATION_IMAGE_LOAD_POLICY"/> structure
        /// that specifies the policy flags for image loading.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ProcessRedirectionTrustPolicy"/>
        /// </term>
        /// <term>
        /// The RedirectionGuard policy of a process.
        /// The <paramref name="lpBuffer"/> parameter points to a <see cref="PROCESS_MITIGATION_REDIRECTION_TRUST_POLICY"/> structure
        /// that specifies the mitigation mode.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ProcessSideChannelIsolationPolicy"/>
        /// </term>
        /// <term>
        /// <para>
        /// Windows 10, version 1809 and above:
        /// The policy regarding isolation of side channels for the specified process.
        /// </para>
        /// <para>
        /// The <paramref name="lpBuffer"/> parameter points to a <see cref="PROCESS_MITIGATION_SIDE_CHANNEL_ISOLATION_POLICY"/> structure
        /// that specifies the policy flags for side channel isolation.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ProcessUserShadowStackPolicy"/>
        /// </term>
        /// <term>
        /// <para>
        /// Windows 10, version 2004 and above:
        /// The policy regarding user-mode Hardware-enforced Stack Protection for the process.
        /// </para>
        /// <para>
        /// The <paramref name="lpBuffer"/> parameter points to a <see cref="PROCESS_MITIGATION_USER_SHADOW_STACK_POLICY"/> structure
        /// that specifies the policy flags for user-mode Hardware-enforced Stack Protection.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpBuffer">
        /// <para>
        /// If the <paramref name="MitigationPolicy"/> parameter is <see cref="ProcessDEPPolicy"/>,
        /// this parameter points to a <see cref="PROCESS_MITIGATION_DEP_POLICY"/> structure
        /// that specifies the DEP policy flags.
        /// </para>
        /// <para>
        /// If the <paramref name="MitigationPolicy"/> parameter is <see cref="ProcessASLRPolicy"/>,
        /// this parameter points to a <see cref="PROCESS_MITIGATION_ASLR_POLICY"/> structure
        /// that specifies the ASLR policy flags.
        /// </para>
        /// <para>
        /// If the <paramref name="MitigationPolicy"/> parameter is <see cref="ProcessImageLoadPolicy"/>,
        /// this parameter points to a <see cref="PROCESS_MITIGATION_IMAGE_LOAD_POLICY"/> structure
        /// that receives the policy flags for image loading.
        /// </para>
        /// <para>
        /// If the <paramref name="MitigationPolicy"/> parameter is <see cref="ProcessStrictHandleCheckPolicy"/>,
        /// this parameter points to a <see cref="PROCESS_MITIGATION_STRICT_HANDLE_CHECK_POLICY"/> structure
        /// that specifies the handle check policy flags.
        /// </para>
        /// <para>
        /// If the <paramref name="MitigationPolicy"/> parameter is <see cref="ProcessSystemCallDisablePolicy"/>,
        /// this parameter points to a <see cref="PROCESS_MITIGATION_SYSTEM_CALL_DISABLE_POLICY"/> structure
        /// that specifies the system call disable policy flags.
        /// </para>
        /// <para>
        /// If the <paramref name="MitigationPolicy"/> parameter is <see cref="ProcessMitigationOptionsMask"/>,
        /// this parameter points to a <see cref="ULONG64"/> bit vector for the mask,
        /// or to accommodate more than 64 bits, a two-element array of <see cref="ULONG64"/> bit vectors.
        /// </para>
        /// <para>
        /// If the <paramref name="MitigationPolicy"/> parameter is <see cref="ProcessExtensionPointDisablePolicy"/>,
        /// this parameter points to a <see cref="PROCESS_MITIGATION_EXTENSION_POINT_DISABLE_POLICY"/> structure
        /// that specifies the extension point disable policy flags.
        /// </para>
        /// <para>
        /// If the <paramref name="MitigationPolicy"/> parameter is <see cref="ProcessControlFlowGuardPolicy"/>,
        /// this parameter points to a <see cref="PROCESS_MITIGATION_CONTROL_FLOW_GUARD_POLICY"/> structure
        /// that specifies the CFG policy flags.
        /// </para>
        /// <para>
        /// If the <paramref name="MitigationPolicy"/> parameter is <see cref="ProcessSignaturePolicy"/>,
        /// this parameter points to a <see cref="PROCESS_MITIGATION_BINARY_SIGNATURE_POLICY"/> structure
        /// that specifies the signature policy flags.
        /// </para>
        /// <para>
        /// If the <paramref name="MitigationPolicy"/> parameter is <see cref="ProcessFontDisablePolicy"/>,
        /// this parameter points to a <see cref="PROCESS_MITIGATION_FONT_DISABLE_POLICY"/> structure
        /// that specifies the policy flags for font loading.
        /// </para>
        /// <para>
        /// If the <paramref name="MitigationPolicy"/> parameter is <see cref="ProcessImageLoadPolicy"/>,
        /// this parameter points to a <see cref="PROCESS_MITIGATION_IMAGE_LOAD_POLICY"/> structure
        /// that specifies the policy flags for image loading.
        /// </para>
        /// <para>
        /// If the <paramref name="MitigationPolicy"/> parameter is <see cref="ProcessRedirectionTrustPolicy"/>,
        /// this parameter points to a <see cref="PROCESS_MITIGATION_REDIRECTION_TRUST_POLICY"/> structure
        /// that specifies the mitigation mode.
        /// </para>
        /// <para>
        /// If the <paramref name="MitigationPolicy"/> parameter is <see cref="ProcessUserShadowStackPolicy"/>,
        /// this parameter points to a <see cref="PROCESS_MITIGATION_USER_SHADOW_STACK_POLICY"/> structure
        /// that specifies the policy flags for user-mode Hardware-enforced Stack Protection.
        /// </para>
        /// </param>
        /// <param name="dwLength">
        /// The size of <paramref name="lpBuffer"/>, in bytes.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To retrieve error values defined for this function, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Setting mitigation policy for a process helps prevent an attacker from exploiting security vulnerabilities.
        /// Use the <see cref="SetProcessMitigationPolicy"/> function to enable or disable security mitigation programmatically.
        /// </para>
        /// <para>
        /// For maximum effectiveness, mitigation policies should be applied before or during process initialization.
        /// For example, setting the ASLR policy that enables forced relocation of images is effective
        /// only if it is applied before all of the images in a process have been loaded.
        /// </para>
        /// <para>
        /// ASLR mitigation policies cannot be made less restrictive after they have been applied.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetProcessMitigationPolicy", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetProcessMitigationPolicy([In] PROCESS_MITIGATION_POLICY MitigationPolicy, [In] PVOID lpBuffer, [In] SIZE_T dwLength);

        /// <summary>
        /// <para>
        /// Disables or enables the ability of the system to temporarily boost the priority of the threads of the specified process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-setprocesspriorityboost"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process.
        /// This handle must have the <see cref="PROCESS_SET_INFORMATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </param>
        /// <param name="bDisablePriorityBoost">
        /// If this parameter is <see cref="TRUE"/>, dynamic boosting is disabled.
        /// If the parameter is <see cref="FALSE"/>, dynamic boosting is enabled.
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
        /// When a thread is running in one of the dynamic priority classes,
        /// the system temporarily boosts the thread's priority when it is taken out of a wait state.
        /// If <see cref="SetProcessPriorityBoost"/> is called with the <paramref name="bDisablePriorityBoost"/> parameter set to <see cref="TRUE"/>,
        /// its threads' priorities are not boosted.
        /// This setting affects all existing threads and any threads subsequently created by the process.
        /// To restore normal behavior, call <see cref="SetProcessPriorityBoost"/> with <paramref name="bDisablePriorityBoost"/> set to <see cref="FALSE"/>.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetProcessPriorityBoost", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetProcessPriorityBoost([In] HANDLE hProcess, [In] BOOL bDisablePriorityBoost);

        /// <summary>
        /// <para>
        /// Sets shutdown parameters for the currently calling process.
        /// This function sets a shutdown order for a process relative to the other processes in the system.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-setprocessshutdownparameters"/>
        /// </para>
        /// </summary>
        /// <param name="dwLevel">
        /// <para>
        /// The shutdown priority for a process relative to other processes in the system.
        /// The system shuts down processes from high <paramref name="dwLevel"/> values to low.
        /// The highest and lowest shutdown priorities are reserved for system components.
        /// This parameter must be in the following range of values.
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
        /// 000-0FF
        /// </term>
        /// <term>
        /// System reserved last shutdown range.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 100-1FF
        /// </term>
        /// <term>
        /// Application reserved last shutdown range.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 200-2FF
        /// </term>
        /// <term>
        /// Application reserved "in between" shutdown range.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 300-3FF
        /// </term>
        /// <term>
        /// Application reserved first shutdown range.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 400-4FF
        /// </term>
        /// <term>
        /// System reserved first shutdown range.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// All processes start at shutdown level 0x280.
        /// </para>
        /// </param>
        /// <param name="dwFlags">
        /// <para>
        /// This parameter can be the following value.
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
        /// <see cref="SHUTDOWN_NORETRY"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// The system terminates the process without displaying a retry dialog box for the user.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function is succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// Applications running in the system security context do not get shut down by the operating system.
        /// They get notified of shutdown or logoff through the callback function installable via <see cref="SetConsoleCtrlHandler"/>.
        /// They also get notified in the order specified by the <paramref name="dwLevel"/> parameter.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetProcessShutdownParameters", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetProcessShutdownParameters([In] DWORD dwLevel, [In] DWORD dwFlags);

        /// <summary>
        /// <para>
        /// Sets the minimum and maximum working set sizes for the specified process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/memoryapi/nf-memoryapi-setprocessworkingsetsize"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// <para>
        /// A handle to the process whose working set sizes is to be set.
        /// </para>
        /// <para>
        /// The handle must have the <see cref="PROCESS_SET_QUOTA"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </para>
        /// </param>
        /// <param name="dwMinimumWorkingSetSize">
        /// <para>
        /// The minimum working set size for the process, in bytes.
        /// The virtual memory manager attempts to keep at least this much memory resident in the process whenever the process is active.
        /// </para>
        /// <para>
        /// This parameter must be greater than zero but less than or equal to the maximum working set size.
        /// The default size is 50 pages (for example, this is 204,800 bytes on systems with a 4K page size).
        /// If the value is greater than zero but less than 20 pages, the minimum value is set to 20 pages.
        /// </para>
        /// <para>
        /// If both <paramref name="dwMinimumWorkingSetSize"/> and <paramref name="dwMaximumWorkingSetSize"/> have the value (<see cref="SIZE_T"/>)–1,
        /// the function removes as many pages as possible from the working set of the specified process.
        /// </para>
        /// </param>
        /// <param name="dwMaximumWorkingSetSize">
        /// <para>
        /// The maximum working set size for the process, in bytes.
        /// The virtual memory manager attempts to keep no more than this much memory resident in the process
        /// whenever the process is active and available memory is low.
        /// </para>
        /// <para>
        /// This parameter must be greater than or equal to 13 pages (for example, 53,248 on systems with a 4K page size),
        /// and less than the system-wide maximum (number of available pages minus 512 pages).
        /// The default size is 345 pages (for example, this is 1,413,120 bytes on systems with a 4K page size).
        /// </para>
        /// <para>
        /// If both <paramref name="dwMinimumWorkingSetSize"/> and <paramref name="dwMaximumWorkingSetSize"/> have the value (<see cref="SIZE_T"/>)–1,
        /// the function removes as many pages as possible from the working set of the specified process.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// Call <see cref="GetLastError"/> to obtain extended error information.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The working set of a process is the set of memory pages in the virtual address space of the process
        /// that are currently resident in physical memory.
        /// These pages are available for an application to use without triggering a page fault.
        /// For more information about page faults, see Working Set.
        /// The minimum and maximum working set sizes affect the virtual memory paging behavior of a process.
        /// </para>
        /// <para>
        /// The working set of the specified process can be emptied by specifying the value (<see cref="SIZE_T"/>)–1
        /// for both the minimum and maximum working set sizes.
        /// This removes as many pages as possible from the working set.
        /// The <see cref="EmptyWorkingSet"/> function can also be used for this purpose.
        /// </para>
        /// <para>
        /// If the values of either <paramref name="dwMinimumWorkingSetSize"/> or <paramref name="dwMaximumWorkingSetSize"/>
        /// are greater than the process' current working set sizes,
        /// the specified process must have the <see cref="SE_INC_WORKING_SET_NAME"/> privilege.
        /// All users generally have this privilege.
        /// For more information about security privileges, see Privileges.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:
        /// The specified process must have the <see cref="SE_INC_BASE_PRIORITY_NAME"/> privilege.
        /// Users in the Administrators and Power Users groups generally have this privilege.
        /// </para>
        /// <para>
        /// The operating system allocates working set sizes on a first-come, first-served basis.
        /// For example, if an application successfully sets 40 megabytes as its minimum working set size on a 64-megabyte system,
        /// and a second application requests a 40-megabyte working set size, the operating system denies the second application's request.
        /// </para>
        /// <para>
        /// Using the <see cref="SetProcessWorkingSetSize"/> function to set an application's minimum and maximum working set sizes
        /// does not guarantee that the requested memory will be reserved, or that it will remain resident at all times.
        /// When the application is idle, or a low-memory situation causes a demand for memory,
        /// the operating system can reduce the application's working set.
        /// An application can use the <see cref="VirtualLock"/> function to lock ranges of the application's virtual address space in memory;
        /// however, that can potentially degrade the performance of the system.
        /// </para>
        /// <para>
        /// When you increase the working set size of an application, you are taking away physical memory from the rest of the system.
        /// This can degrade the performance of other applications and the system as a whole.
        /// It can also lead to failures of operations that require physical memory to be present
        /// (for example, creating processes, threads, and kernel pool).
        /// Thus, you must use the <see cref="SetProcessWorkingSetSize"/> function carefully.
        /// You must always consider the performance of the whole system when you are designing an application.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetProcessWorkingSetSize", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetProcessWorkingSetSize([In] HANDLE hProcess, [In] SIZE_T dwMinimumWorkingSetSize, [In] SIZE_T dwMaximumWorkingSetSize);

        /// <summary>
        /// <para>
        /// Terminates the specified process and all of its threads.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-terminateprocess"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// <para>
        /// A handle to the process to be terminated.
        /// </para>
        /// <para>
        /// The handle must have the <see cref="PROCESS_TERMINATE"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </para>
        /// </param>
        /// <param name="uExitCode">
        /// The exit code to be used by the process and threads terminated as a result of this call.
        /// Use the <see cref="GetExitCodeProcess"/> function to retrieve a process's exit value.
        /// Use the <see cref="GetExitCodeThread"/> function to retrieve a thread's exit value.
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
        /// The <see cref="TerminateProcess"/> function is used to unconditionally cause a process to exit.
        /// The state of global data maintained by dynamic-link libraries (DLLs) may be compromised
        /// if <see cref="TerminateProcess"/> is used rather than <see cref="ExitProcess"/>.
        /// </para>
        /// <para>
        /// This function stops execution of all threads within the process and requests cancellation of all pending I/O.
        /// The terminated process cannot exit until all pending I/O has been completed or canceled.
        /// When a process terminates, its kernel object is not destroyed
        /// until all processes that have open handles to the process have released those handles.
        /// </para>
        /// <para>
        /// When a process terminates itself, <see cref="TerminateProcess"/> stops execution of the calling thread and does not return.
        /// Otherwise, <see cref="TerminateProcess"/> is asynchronous; it initiates termination and returns immediately.
        /// If you need to be sure the process has terminated, call the <see cref="WaitForSingleObject"/> function with a handle to the process.
        /// </para>
        /// <para>
        /// A process cannot prevent itself from being terminated.
        /// </para>
        /// <para>
        /// After a process has terminated, call to <see cref="TerminateProcess"/> with open handles
        /// to the process fails with <see cref="ERROR_ACCESS_DENIED"/> (5) error code.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "TerminateProcess", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL TerminateProcess([In] HANDLE hProcess, [In] UINT uExitCode);

        /// <summary>
        /// <para>
        /// Updates the specified attribute in a list of attributes for process and thread creation.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-updateprocthreadattribute"/>
        /// </para>
        /// </summary>
        /// <param name="lpAttributeList">
        /// A pointer to an attribute list created by the <see cref="InitializeProcThreadAttributeList"/> function.
        /// </param>
        /// <param name="dwFlags">
        /// This parameter is reserved and must be zero.
        /// </param>
        /// <param name="Attribute">
        /// <para>
        /// The attribute key to update in the attribute list.
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
        /// <see cref="PROC_THREAD_ATTRIBUTE_GROUP_AFFINITY"/>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpValue"/> parameter is a pointer to a <see cref="GROUP_AFFINITY"/> structure
        /// that specifies the processor group affinity for the new thread.
        /// </para>
        /// <para>
        /// Supported in Windows 7 and newer and Windows Server 2008 R2 and newer.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PROC_THREAD_ATTRIBUTE_HANDLE_LIST"/>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpValue"/> parameter is a pointer to a list of handles to be inherited by the child process.
        /// </para>
        /// <para>
        /// These handles must be created as inheritable handles and must not include pseudo handles
        /// such as those returned by the <see cref="GetCurrentProcess"/> or <see cref="GetCurrentThread"/> function.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// if you use this attribute, pass in a value of <see cref="TRUE"/>
        /// for the <c>bInheritHandles</c> parameter of the <see cref="CreateProcess"/> function. 
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PROC_THREAD_ATTRIBUTE_IDEAL_PROCESSOR"/>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpValue"/> parameter is a pointer to a <see cref="PROCESSOR_NUMBER"/> structure
        /// that specifies the ideal processor for the new thread.
        /// </para>
        /// <para>
        /// Supported in Windows 7 and newer and Windows Server 2008 R2 and newer.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PROC_THREAD_ATTRIBUTE_MACHINE_TYPE"/>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpValue"/> parameter is a pointer to a <see cref="WORD"/>
        /// that specifies the machine architecture of the child process.
        /// </para>
        /// <para>
        /// Supported in Windows 11 and newer.
        /// </para>
        /// <para>
        /// The <see cref="WORD"/> pointed to by <paramref name="lpValue"/> can be a value listed on IMAGE FILE MACHINE CONSTANTS.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PROC_THREAD_ATTRIBUTE_MITIGATION_POLICY"/>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpValue"/> parameter is a pointer to a <see cref="DWORD"/> or <see cref="DWORD64"/>
        /// that specifies the exploit mitigation policy for the child process.
        /// Starting in Windows 10, version 1703, this parameter can also be a pointer to a two-element <see cref="DWORD64"/> array.
        /// </para>
        /// <para>
        /// The specified policy overrides the policies set for the application
        /// and the system and cannot be changed after the child process starts running.
        /// </para>
        /// <para>
        /// The <see cref="DWORD"/> or <see cref="DWORD64"/> pointed to by <paramref name="lpValue"/>
        /// can be one or more of the values listed in the remarks.
        /// </para>
        /// <para>
        /// Supported in Windows 7 and newer and Windows Server 2008 R2 and newer.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PROC_THREAD_ATTRIBUTE_PARENT_PROCESS"/>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpValue"/> parameter is a pointer to the handle of a process to use
        /// (instead of the calling process) as the parent for the process being created.
        /// The handle for the process used must have the <see cref="PROCESS_CREATE_PROCESS"/> access right.
        /// </para>
        /// <para>
        /// Attributes inherited from the specified process include handles, the device map,
        /// processor affinity, priority, quotas, the process token, and job object.
        /// (Note that some attributes such as the debug port will come from the creating process, not the process specified by this handle.)
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PROC_THREAD_ATTRIBUTE_PREFERRED_NODE"/>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpValue"/> parameter is a pointer to the node number of the preferred NUMA node for the new process.
        /// </para>
        /// <para>
        /// Supported in Windows 7 and newer and Windows Server 2008 R2 and newer.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PROC_THREAD_ATTRIBUTE_UMS_THREAD"/>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpValue"/> parameter is a pointer to a <see cref="UMS_CREATE_THREAD_ATTRIBUTES"/> structure
        /// that specifies a user-mode scheduling (UMS) thread context and a UMS completion list to associate with the thread.
        /// </para>
        /// <para>
        /// After the UMS thread is created, the system queues it to the specified completion list.
        /// The UMS thread runs only when an application's UMS scheduler retrieves the UMS thread from the completion list and selects it to run.
        /// For more information, see User-Mode Scheduling.
        /// </para>
        /// <para>
        /// Supported in Windows 7 and newer and Windows Server 2008 R2 and newer.
        /// </para>
        /// <para>
        /// Not supported in Windows 11 and newer (see User-Mode Scheduling).
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PROC_THREAD_ATTRIBUTE_SECURITY_CAPABILITIES"/>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpValue"/> parameter is a pointer to a <see cref="SECURITY_CAPABILITIES"/> structure
        /// that defines the security capabilities of an app container.
        /// If this attribute is set the new process will be created as an AppContainer process.
        /// </para>
        /// <para>
        /// Supported in Windows 8 and newer and Windows Server 2012 and newer.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PROC_THREAD_ATTRIBUTE_PROTECTION_LEVEL"/>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpValue"/> parameter is a pointer to a <see cref="DWORD"/> value of <see cref="PROTECTION_LEVEL_SAME"/>.
        /// This specifies the protection level of the child process to be the same as the protection level of its parent process.
        /// </para>
        /// <para>
        /// Supported in Windows 8.1 and newer and Windows Server 2012 R2 and newer.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PROC_THREAD_ATTRIBUTE_CHILD_PROCESS_POLICY"/>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpValue"/> parameter is a pointer to a <see cref="DWORD"/> value that specifies the child process policy.
        /// The policy specifies whether to allow a child process to be created.
        /// </para>
        /// <para>
        /// For information on the possible values for the <see cref="DWORD"/> to which <paramref name="lpValue"/> points, see Remarks.
        /// </para>
        /// <para>
        /// Supported in Windows 10 and newer and Windows Server 2016 and newer.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PROC_THREAD_ATTRIBUTE_DESKTOP_APP_POLICY"/>
        /// </term>
        /// <term>
        /// <para>
        /// This attribute is relevant only to win32 applications that have been converted to UWP packages by using the Desktop Bridge.
        /// </para>
        /// <para>
        /// The <paramref name="lpValue"/> parameter is a pointer to a <see cref="DWORD"/> value that specifies the desktop app policy.
        /// The policy specifies whether descendant processes should continue to run in the desktop environment.
        /// </para>
        /// <para>
        /// For information about the possible values for the <see cref="DWORD"/> to which <paramref name="lpValue"/> points, see Remarks.
        /// </para>
        /// <para>
        /// Supported in Windows 10 Version 1703 and newer and Windows Server Version 1709 and newer.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PROC_THREAD_ATTRIBUTE_JOB_LIST"/>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpValue"/> parameter is a pointer to a list of job handles to be assigned to the child process, in the order specified.
        /// </para>
        /// <para>
        /// Supported in Windows 10 and newer and Windows Server 2016 and newer.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PROC_THREAD_ATTRIBUTE_ENABLE_OPTIONAL_XSTATE_FEATURES"/>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpValue"/> parameter is a pointer to a <see cref="DWORD64"/> value
        /// that specifies the set of optional XState features to enable for the new thread.
        /// </para>
        /// <para>
        /// Supported in Windows 11 and newer and Windows Server 2022 and newer.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpValue">
        /// A pointer to the attribute value.
        /// This value should persist until the attribute is destroyed using the <see cref="DeleteProcThreadAttributeList"/> function.
        /// </param>
        /// <param name="cbSize">
        /// The size of the attribute value specified by the <paramref name="lpValue"/> parameter.
        /// </param>
        /// <param name="lpPreviousValue">
        /// This parameter is reserved and must be <see cref="NULL"/>.
        /// </param>
        /// <param name="lpReturnSize">
        /// This parameter is reserved and must be <see cref="NULL"/>.
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
        /// An attribute list is an opaque structure that consists of a series of key/value pairs, one for each attribute.
        /// A process can update only the attribute keys described in this topic.
        /// </para>
        /// <para>
        /// The <see cref="DWORD"/> or <see cref="DWORD64"/> pointed to by <paramref name="lpValue"/> can be one or more of the following values
        /// when you specify <see cref="PROC_THREAD_ATTRIBUTE_MITIGATION_POLICY"/> for the <paramref name="Attribute"/> parameter:
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_DEP_ENABLE"/> (0x00000001)
        /// Enables data execution prevention (DEP) for the child process.
        /// For more information, see Data Execution Prevention.
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_DEP_ATL_THUNK_ENABLE"/> (0x00000002)
        /// Enables DEP-ATL thunk emulation for the child process.
        /// DEP-ATL thunk emulation causes the system to intercept NX faults that originate from the Active Template Library (ATL) thunk layer.
        /// This value can be specified only with <see cref="PROCESS_CREATION_MITIGATION_POLICY_DEP_ENABLE"/>.
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_SEHOP_ENABLE"/> (0x00000004)
        /// Enables structured exception handler overwrite protection (SEHOP) for the child process.
        /// SEHOP blocks exploits that use the structured exception handler (SEH) overwrite technique.
        /// </para>
        /// <para>
        /// Windows 7, Windows Server 2008 R2, Windows Server 2008 and Windows Vista:
        /// The following values are not supported until Windows 8 and Windows Server 2012.
        /// </para>
        /// <para>
        /// The force Address Space Layout Randomization (ASLR) policy, if enabled, forcibly rebases images
        /// that are not dynamic base compatible by acting as though an image base collision happened at load time.
        /// If relocations are required, images that do not have a base relocation section will not be loaded.
        /// </para>
        /// <para>
        /// The following mitigation options are available for mandatory ASLR policy:
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_FORCE_RELOCATE_IMAGES_ALWAYS_ON"/> (0x00000001 &lt;&lt; 8)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_FORCE_RELOCATE_IMAGES_ALWAYS_OFF"/> (0x00000002 &lt;&lt; 8)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_FORCE_RELOCATE_IMAGES_ALWAYS_ON_REQ_RELOCS"/> (0x00000003 &lt;&lt; 8)
        /// </para>
        /// <para>
        /// The heap terminate on corruption policy, if enabled, causes the heap to terminate if it becomes corrupt.
        /// Note that 'always off' does not override the default opt-in for binaries with current subsystem versions set in the image header.
        /// Heap terminate on corruption is user mode enforced.
        /// </para>
        /// <para>
        /// The following mitigation options are available for heap terminate on corruption policy:
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_HEAP_TERMINATE_ALWAYS_ON"/> (0x00000001 &lt;&lt; 12)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_HEAP_TERMINATE_ALWAYS_OFF"/> (0x00000002 &lt;&lt; 12)
        /// </para>
        /// <para>
        /// The bottom-up randomization policy, which includes stack randomization options,
        /// causes a random location to be used as the lowest user address.
        /// </para>
        /// <para>
        /// The following mitigation options are available for the bottom-up randomization policy:
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_BOTTOM_UP_ASLR_ALWAYS_ON"/> (0x00000001 &lt;&lt; 16)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_BOTTOM_UP_ASLR_ALWAYS_OFF"/> (0x00000002 &lt;&lt; 16)
        /// </para>
        /// <para>
        /// The high-entropy bottom-up randomization policy, if enabled, causes up to 1TB of bottom-up variance to be used.
        /// Note that high-entropy bottom-up randomization is effective if and only if bottom-up ASLR is also enabled;
        /// high-entropy bottom-up randomization is only meaningful for native 64-bit processes.
        /// </para>
        /// <para>
        /// The following mitigation options are available for the high-entropy bottom-up randomization policy:
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_HIGH_ENTROPY_ASLR_ALWAYS_ON"/> (0x00000001 &lt;&lt; 20)
        /// </para>
        /// <para>
        /// PROCESS_CREATION_MITIGATION_POLICY_HIGH_ENTROPY_ASLR_ALWAYS_OFF (0x00000002 &lt;&lt; 20)
        /// </para>
        /// <para>
        /// The strict handle checking enforcement policy, if enabled, causes an exception to be raised immediately on a bad handle reference.
        /// If this policy is not enabled, a failure status will be returned from the handle reference instead.
        /// </para>
        /// <para>
        /// The following mitigation options are available for the strict handle checking enforcement policy:
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_STRICT_HANDLE_CHECKS_ALWAYS_ON"/> (0x00000001 &lt;&lt; 24)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_STRICT_HANDLE_CHECKS_ALWAYS_OFF"/> (0x00000002 &lt;&lt; 24)
        /// </para>
        /// <para>
        /// The Win32k system call disable policy, if enabled, prevents a process from making Win32k calls.
        /// </para>
        /// <para>
        /// The following mitigation options are available for the Win32k system call disable policy:
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_WIN32K_SYSTEM_CALL_DISABLE_ALWAYS_ON"/> (0x00000001 &lt;&lt; 28)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_WIN32K_SYSTEM_CALL_DISABLE_ALWAYS_OFF"/> (0x00000002 &lt;&lt; 28)
        /// </para>
        /// <para>
        /// The Extension Point Disable policy, if enabled, prevents certain built-in third party extension points from being used.
        /// This policy blocks the following extension points:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// AppInit DLLs
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Winsock Layered Service Providers (LSPs)
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Global Windows Hooks
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Legacy Input Method Editors (IMEs)
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Local hooks still work with the Extension Point Disable policy enabled.
        /// This behavior is used to prevent legacy extension points from being loaded into a process that does not use them.
        /// </para>
        /// <para>
        /// The following mitigation options are available for the extension point disable policy:
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_EXTENSION_POINT_DISABLE_ALWAYS_ON"/> (0x00000001 &lt;&lt; 32)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_EXTENSION_POINT_DISABLE_ALWAYS_OFF"/> (0x00000002 &lt;&lt; 32)
        /// </para>
        /// <para>
        /// The Control Flow Guard (CFG) policy, if turned on, places additional restrictions
        /// on indirect calls in code that has been built with CFG enabled.
        /// </para>
        /// <para>
        /// The following mitigation options are available for controlling the CFG policy:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_CONTROL_FLOW_GUARD_MASK"/> (0x00000003ui64 &lt;&lt; 40)
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_CONTROL_FLOW_GUARD_DEFER"/> (0x00000000ui64 &lt;&lt; 40)
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_CONTROL_FLOW_GUARD_ALWAYS_ON"/> (0x00000001ui64 &lt;&lt; 40)
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_CONTROL_FLOW_GUARD_ALWAYS_OFF"/> (0x00000002ui64 &lt;&lt; 40)
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_CONTROL_FLOW_GUARD_EXPORT_SUPPRESSION"/> (0x00000003ui64 &lt;&lt; 40)
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// In addition, the following policy can be specified to enforce that EXEs/DLLs must enable CFG.
        /// If an attempt is made to load an EXE/DLL that does not enable CFG, the load will fail:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY2_STRICT_CONTROL_FLOW_GUARD_MASK"/> (0x00000003ui64 &lt;&lt; 8)
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY2_STRICT_CONTROL_FLOW_GUARD_DEFER"/> (0x00000000ui64 &lt;&lt; 8)
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY2_STRICT_CONTROL_FLOW_GUARD_ALWAYS_ON"/> (0x00000001ui64 &lt;&lt; 8)
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY2_STRICT_CONTROL_FLOW_GUARD_ALWAYS_OFF"/> (0x00000002ui64 &lt;&lt; 8)
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY2_STRICT_CONTROL_FLOW_GUARD_RESERVED"/> (0x00000003ui64 &lt;&lt; 8)
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The dynamic code policy, if turned on, prevents a process from generating dynamic code or modifying executable code.
        /// </para>
        /// <para>
        /// The following mitigation options are available for the dynamic code policy:
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_PROHIBIT_DYNAMIC_CODE_MASK"/> (0x00000003ui64 &lt;&lt; 36)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_PROHIBIT_DYNAMIC_CODE_DEFER"/> (0x00000000ui64 &lt;&lt; 36)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_PROHIBIT_DYNAMIC_CODE_ALWAYS_ON"/> (0x00000001ui64 &lt;&lt; 36)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_PROHIBIT_DYNAMIC_CODE_ALWAYS_OFF"/> (0x00000002ui64 &lt;&lt; 36)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_PROHIBIT_DYNAMIC_CODE_ALWAYS_ON_ALLOW_OPT_OUT"/> (0x00000003ui64 &lt;&lt; 36)
        /// </para>
        /// <para>
        /// The binary signature policy requires EXEs/DLLs to be properly signed.
        /// </para>
        /// <para>
        /// The following mitigation options are available for the binary signature policy:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_BLOCK_NON_MICROSOFT_BINARIES_MASK"/> (0x00000003ui64 &lt;&lt; 44)
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_BLOCK_NON_MICROSOFT_BINARIES_DEFER"/> (0x00000000ui64 &lt;&lt; 44)
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_BLOCK_NON_MICROSOFT_BINARIES_ALWAYS_ON"/> (0x00000001ui64 &lt;&lt; 44)
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_BLOCK_NON_MICROSOFT_BINARIES_ALWAYS_OFF"/> (0x00000002ui64 &lt;&lt; 44)
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_BLOCK_NON_MICROSOFT_BINARIES_ALLOW_STORE"/> (0x00000003ui64 &lt;&lt; 44)
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The font loading prevention policy for the process determines whether non-system fonts can be loaded for a process.
        /// When the policy is turned on, the process is prevented from loading non-system fonts.
        /// </para>
        /// <para>
        /// The following mitigation options are available for the font loading prevention policy:
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_FONT_DISABLE_MASK"/> (0x00000003ui64 &lt;&lt; 48)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_FONT_DISABLE_DEFER"/> (0x00000000ui64 &lt;&lt; 48)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_FONT_DISABLE_ALWAYS_ON"/> (0x00000001ui64 &lt;&lt; 48)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_FONT_DISABLE_ALWAYS_OFF"/> (0x00000002ui64 &lt;&lt; 48)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_AUDIT_NONSYSTEM_FONTS"/> (0x00000003ui64 &lt;&lt; 48)
        /// </para>
        /// <para>
        /// The image loading policy of the process determines the types of executable images that can be mapped into the process.
        /// When the policy is turned on, images cannot be loaded from some locations,
        /// such as remove devices or files that have the Low mandatory label.
        /// </para>
        /// <para>
        /// The following mitigation options are available for the image loading policy:
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_IMAGE_LOAD_NO_REMOTE_MASK"/> (0x00000003ui64 &lt;&lt; 52)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_IMAGE_LOAD_NO_REMOTE_DEFER"/> (0x00000000ui64 &lt;&lt; 52)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_IMAGE_LOAD_NO_REMOTE_ALWAYS_ON"/> (0x00000001ui64 &lt;&lt; 52)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_IMAGE_LOAD_NO_REMOTE_ALWAYS_OFF"/> (0x00000002ui64 &lt;&lt; 52)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_IMAGE_LOAD_NO_REMOTE_RESERVED"/> (0x00000003ui64 &lt;&lt; 52)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_IMAGE_LOAD_NO_LOW_LABEL_MASK"/> (0x00000003ui64 &lt;&lt; 56)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_IMAGE_LOAD_NO_LOW_LABEL_DEFER"/> (0x00000000ui64 &lt;&lt; 56)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_IMAGE_LOAD_NO_LOW_LABEL_ALWAYS_ON"/> (0x00000001ui64 &lt;&lt; 56)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_IMAGE_LOAD_NO_LOW_LABEL_ALWAYS_OFF"/> (0x00000002ui64 &lt;&lt; 56)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_IMAGE_LOAD_NO_LOW_LABEL_RESERVED"/> (0x00000003ui64 &lt;&lt; 56)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_IMAGE_LOAD_PREFER_SYSTEM32_MASK"/> (0x00000003ui64 &lt;&lt; 60)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_IMAGE_LOAD_PREFER_SYSTEM32_DEFER"/> (0x00000000ui64 &lt;&lt; 60)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_IMAGE_LOAD_PREFER_SYSTEM32_ALWAYS_ON"/> (0x00000001ui64 &lt;&lt; 60)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_IMAGE_LOAD_PREFER_SYSTEM32_ALWAYS_OFF"/> (0x00000002ui64 &lt;&lt; 60)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_IMAGE_LOAD_PREFER_SYSTEM32_RESERVED"/> (0x00000003ui64 &lt;&lt; 60)
        /// </para>
        /// <para>
        /// Windows 10, version 1709:
        /// The following value is available only in Windows 10, version 1709 or later
        /// and only with the January 2018 Windows security updates and any applicable firmware updates from the OEM device manufacturer.
        /// See Windows Client Guidance for IT Pros to protect against speculative execution side-channel vulnerabilities.
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY2_RESTRICT_INDIRECT_BRANCH_PREDICTION_ALWAYS_ON"/> (0x00000001ui64 &lt;&lt; 16)
        /// This flag can be used by processes to protect against sibling hardware threads (hyperthreads) from interfering with indirect branch predictions.
        /// Processes that have sensitive information in their address space should consider enabling this flag
        /// to protect against attacks involving indirect branch prediction (such as CVE-2017-5715).
        /// </para>
        /// <para>
        /// Windows 10, version 1809:  The following value is available only in Windows 10, version 1809 or later.
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY2_SPECULATIVE_STORE_BYPASS_DISABLE_ALWAYS_ON"/> (0x00000001ui64 &lt;&lt; 24)
        /// This flag can be used by processes to disable the Speculative Store Bypass (SSB) feature of CPUs
        /// that may be vulnerable to speculative execution side channel attacks involving SSB (CVE-2018-3639).
        /// This flag is only supported by certain Intel CPUs that have the requisite hardware features.
        /// On CPUs that do not support this feature, the flag has no effect.
        /// </para>
        /// <para>
        /// Windows 10, version 2004:  The following values are available only in Windows 10, version 2004 or later.
        /// </para>
        /// <para>
        /// Hardware-enforced Stack Protection (HSP) is a hardware-based security feature where the CPU verifies function
        /// return addresses at runtime by employing a shadow stack mechanism.
        /// For user-mode HSP, the default mode is compatibility mode,
        /// where only shadow stack violations occurring in modules that are considered compatible with shadow stacks (CETCOMPAT) are fatal.
        /// In strict mode, all shadow stack violations are fatal.
        /// </para>
        /// <para>
        /// The following mitigation options are available for user-mode Hardware-enforced Stack Protection and related features:
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY2_CET_USER_SHADOW_STACKS_ALWAYS_ON"/> (0x00000001ui64 &lt;&lt; 28)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY2_CET_USER_SHADOW_STACKS_ALWAYS_OFF"/> (0x00000002ui64 &lt;&lt; 28)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY2_CET_USER_SHADOW_STACKS_STRICT_MODE"/> (0x00000003ui64 &lt;&lt; 28)
        /// </para>
        /// <para>
        /// Instruction Pointer validation:
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY2_USER_CET_SET_CONTEXT_IP_VALIDATION_ALWAYS_ON"/> (0x00000001ui64 &lt;&lt; 32)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY2_USER_CET_SET_CONTEXT_IP_VALIDATION_ALWAYS_OFF"/> (0x00000002ui64 &lt;&lt; 32)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY2_USER_CET_SET_CONTEXT_IP_VALIDATION_RELAXED_MODE"/> (0x00000003ui64 &lt;&lt; 32)
        /// </para>
        /// <para>
        /// Blocking the load of non-CETCOMPAT/non-EHCONT binaries:
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY2_BLOCK_NON_CET_BINARIES_ALWAYS_ON"/> (0x00000001ui64 &lt;&lt; 36)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY2_BLOCK_NON_CET_BINARIES_ALWAYS_OFF"/> (0x00000002ui64 &lt;&lt; 36)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY2_BLOCK_NON_CET_BINARIES_NON_EHCONT"/> (0x00000003ui64 &lt;&lt; 36)
        /// </para>
        /// <para>
        /// Restricting certain HSP APIs used to specify security properties of dynamic code to only be callable from outside of the process:
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY2_CET_DYNAMIC_APIS_OUT_OF_PROC_ONLY_ALWAYS_ON"/> (0x00000001ui64 &lt;&lt; 48)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY2_CET_DYNAMIC_APIS_OUT_OF_PROC_ONLY_ALWAYS_OFF"/> (0x00000002ui64 &lt;&lt; 48)
        /// </para>
        /// <para>
        /// The FSCTL system call disable policy, if enabled, prevents a process from making NtFsControlFile calls.
        /// The following mitigation options are available for the FSCTL system call disable policy:
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY2_FSCTL_SYSTEM_CALL_DISABLE_ALWAYS_ON"/> (0x00000001ui64 &lt;&lt; 56)
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY2_FSCTL_SYSTEM_CALL_DISABLE_ALWAYS_OFF"/> (0x00000002ui64 &lt;&lt; 56)
        /// </para>
        /// <para>
        /// The <see cref="DWORD"/> pointed to by <paramref name="lpValue"/> can be one or more of the following values
        /// when you specify <see cref="PROC_THREAD_ATTRIBUTE_CHILD_PROCESS_POLICY"/> for the <paramref name="Attribute"/> parameter:
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_CHILD_PROCESS_RESTRICTED"/> 0x01
        /// </para>
        /// <para>
        /// The process being created is not allowed to create child processes.
        /// This restriction becomes a property of the token as which the process runs.
        /// It should be noted that this restriction is only effective in sandboxed applications (such as AppContainer)
        /// which ensure privileged process handles are not accessible to the process.
        /// For example, if a process restricting child process creation is able to access another process handle
        /// with <see cref="PROCESS_CREATE_PROCESS"/> or <see cref="PROCESS_VM_WRITE"/> access rights,
        /// then it may be possible to bypass the child process restriction.
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_CHILD_PROCESS_OVERRIDE"/> 0x02
        /// </para>
        /// <para>
        /// The process being created is allowed to create a child process, if it would otherwise be restricted.
        /// You can only specify this value if the process that is creating the new process is not restricted.
        /// </para>
        /// <para>
        /// The <see cref="DWORD"/> pointed to by <paramref name="lpValue"/> can be one or more of the following values
        /// when you specify <see cref="PROC_THREAD_ATTRIBUTE_DESKTOP_APP_POLICY"/> for the <paramref name="Attribute"/> parameter:
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_DESKTOP_APP_BREAKAWAY_ENABLE_PROCESS_TREE"/> 0x01
        /// </para>
        /// <para>
        /// The process being created will create any child processes outside of the desktop app runtime environment.
        /// This behavior is the default for processes for which no policy has been set.
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_DESKTOP_APP_BREAKAWAY_DISABLE_PROCESS_TREE"/> 0x02
        /// </para>
        /// <para>
        /// The process being created will create any child processes inside of the desktop app runtime environment.
        /// This policy is inherited by the descendant processes until it is overridden
        /// by creating a process with <see cref="PROCESS_CREATION_DESKTOP_APP_BREAKAWAY_ENABLE_PROCESS_TREE"/>.
        /// </para>
        /// <para>
        /// <see cref="PROCESS_CREATION_DESKTOP_APP_BREAKAWAY_OVERRIDE"/> 0x04
        /// </para>
        /// <para>
        /// The process being created will run inside the desktop app runtime environment.
        /// This policy applies only to the process being created, not its descendants..
        /// </para>
        /// <para>
        /// In order to launch the child process with the same protection level as the parent,
        /// the parent process must specify the <see cref="PROC_THREAD_ATTRIBUTE_PROTECTION_LEVEL"/> attribute for the child process.
        /// This can be used for both protected and unprotected processes.
        /// For example, when this flag is used by an unprotected process, the system will launch a child process at unprotected level.
        /// The <see cref="CREATE_PROTECTED_PROCESS"/> flag must be specified in both cases.
        /// </para>
        /// <para>
        /// The following example launches a child process with the same protection level as the parent process:
        /// </para>
        /// <code>
        /// DWORD ProtectionLevel = PROTECTION_LEVEL_SAME;
        /// SIZE_T AttributeListSize;
        /// 
        /// STARTUPINFOEXW StartupInfoEx = { 0 };
        /// 
        /// StartupInfoEx.StartupInfo.cb = sizeof(StartupInfoEx);
        /// 
        /// InitializeProcThreadAttributeList(NULL, 1, 0, &amp;AttributeListSize)
        /// 
        /// 
        /// StartupInfoEx.lpAttributeList = (LPPROC_THREAD_ATTRIBUTE_LIST) HeapAlloc(
        ///     GetProcessHeap(),
        ///     0,
        ///     AttributeListSize
        ///     );
        /// 
        /// if (InitializeProcThreadAttributeList(StartupInfoEx.lpAttributeList,
        ///                                       1,
        ///                                       0,
        ///                                       &amp;AttributeListSize) == FALSE)
        /// {
        ///     Result = GetLastError();
        ///     goto exitFunc;
        /// }
        /// 
        /// if (UpdateProcThreadAttribute(StartupInfoEx.lpAttributeList,
        ///                               0,
        ///                               PROC_THREAD_ATTRIBUTE_PROTECTION_LEVEL,
        ///                               &amp;ProtectionLevel,
        ///                               sizeof(ProtectionLevel),
        ///                               NULL,
        ///                               NULL) == FALSE)
        /// {
        ///     Result = GetLastError();
        ///     goto exitFunc;
        /// }
        /// 
        /// PROCESS_INFORMATION ProcessInformation = { 0 };
        /// 
        /// if (CreateProcessW(ApplicationName,
        ///                    CommandLine,
        ///                    ProcessAttributes,
        ///                    ThreadAttributes,
        ///                    InheritHandles,
        ///                    EXTENDED_STARTUPINFO_PRESENT | CREATE_PROTECTED_PROCESS,
        ///                    Environment,
        ///                    CurrentDirectory,
        ///                    (LPSTARTUPINFOW)&amp;StartupInfoEx,
        ///                    &amp;ProcessInformation) == FALSE)
        /// {
        ///     Result = GetLastError();
        ///     goto exitFunc;
        /// }
        /// </code>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "UpdateProcThreadAttribute", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL UpdateProcThreadAttribute([In] LPPROC_THREAD_ATTRIBUTE_LIST lpAttributeList, [In] DWORD dwFlags,
            [In] DWORD_PTR Attribute, [In] PVOID lpValue, [In] SIZE_T cbSize, [In] PVOID lpPreviousValue, [Out] out SIZE_T lpReturnSize);
    }
}
