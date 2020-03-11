using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.LogonFlags;
using static Lsj.Util.Win32.Enums.ProcessCreationFlags;
using static Lsj.Util.Win32.Enums.ProcessPriorityClasses;
using static Lsj.Util.Win32.Userenv;
using static Lsj.Util.Win32.Enums.DllMainReasons;
using System.Text;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// The lpValue parameter is a pointer to a <see cref="GROUP_AFFINITY"/> structure that specifies the processor group affinity for the new thread.
        /// Windows Server 2008 and Windows Vista:  This value is not supported until Windows 7 and Windows Server 2008 R2.
        /// </summary>
        public static readonly UIntPtr PROC_THREAD_ATTRIBUTE_GROUP_AFFINITY = (UIntPtr)0x30003;

        /// <summary>
        /// The lpValue parameter is a pointer to a list of handles to be inherited by the child process.
        /// These handles must be created as inheritable handles and must not include pseudo handles such as those returned
        /// by the <see cref="GetCurrentProcess"/> or <see cref="GetCurrentThread"/> function.
        /// Note
        /// if you use this attribute, pass in a value of <see langword="true"/> for the bInheritHandles parameter of the <see cref="CreateProcess"/> function.
        /// </summary>
        public static readonly UIntPtr PROC_THREAD_ATTRIBUTE_HANDLE_LIST = (UIntPtr)0x20002;

        /// <summary>
        /// The lpValue parameter is a pointer to a <see cref="PROCESSOR_NUMBER"/> structure that specifies the ideal processor for the new thread.
        /// Windows Server 2008 and Windows Vista:  This value is not supported until Windows 7 and Windows Server 2008 R2.
        /// </summary>
        public static readonly UIntPtr PROC_THREAD_ATTRIBUTE_IDEAL_PROCESSOR = (UIntPtr)0x30005;

        /// <summary>
        /// The lpValue parameter is a pointer to a DWORD or DWORD64 that specifies the exploit mitigation policy for the child process.
        /// Starting in Windows 10, version 1703, this parameter can also be a pointer to a two-element DWORD64 array.
        /// The specified policy overrides the policies set for the application and the system and cannot be changed after the child process starts running.
        /// Windows Server 2008 and Windows Vista:  This value is not supported until Windows 7 and Windows Server 2008 R2.
        /// The DWORD or DWORD64 pointed to by lpValue can be one or more of the values listed in the remarks.
        /// </summary>
        public static readonly UIntPtr PROC_THREAD_ATTRIBUTE_MITIGATION_POLICY = (UIntPtr)0x20007;

        /// <summary>
        /// The lpValue parameter is a pointer to a handle to a process to use instead of the calling process as the parent for the process being created.
        /// The process to use must have the <see cref="PROCESS_CREATE_PROCESS"/> access right.
        /// Attributes inherited from the specified process include handles, the device map, processor affinity, priority,
        /// quotas, the process token, and job object.
        /// (Note that some attributes such as the debug port will come from the creating process, not the process specified by this handle.)
        /// </summary>
        public static readonly UIntPtr PROC_THREAD_ATTRIBUTE_PARENT_PROCESS = (UIntPtr)0x20000;

        /// <summary>
        /// The lpValue parameter is a pointer to the node number of the preferred NUMA node for the new process.
        /// Windows Server 2008 and Windows Vista:  This value is not supported until Windows 7 and Windows Server 2008 R2.
        /// </summary>
        public static readonly UIntPtr PROC_THREAD_ATTRIBUTE_PREFERRED_NODE = (UIntPtr)0x20004;

        /// <summary>
        /// The lpValue parameter is a pointer to a <see cref="UMS_CREATE_THREAD_ATTRIBUTES"/> structure
        /// that specifies a user-mode scheduling (UMS) thread context and a UMS completion list to associate with the thread.
        /// After the UMS thread is created, the system queues it to the specified completion list.
        /// The UMS thread runs only when an application's UMS scheduler retrieves the UMS thread from the completion list and selects it to run.
        /// For more information, see User-Mode Scheduling.
        /// Windows Server 2008 and Windows Vista:  This value is not supported until Windows 7 and Windows Server 2008 R2.
        /// </summary>
        public static readonly UIntPtr PROC_THREAD_ATTRIBUTE_UMS_THREAD = (UIntPtr)0x30006;

        /// <summary>
        /// The lpValue parameter is a pointer to a <see cref="SECURITY_CAPABILITIES"/> structure that defines the security capabilities of an app container.
        /// If this attribute is set the new process will be created as an AppContainer process.
        /// Windows 7, Windows Server 2008 R2, Windows Server 2008 and Windows Vista:  This value is not supported until Windows 8 and Windows Server 2012.
        /// </summary>
        public static readonly UIntPtr PROC_THREAD_ATTRIBUTE_SECURITY_CAPABILITIES = (UIntPtr)0x20009;

        /// <summary>
        /// The lpValue parameter is a pointer to a DWORD value of <see cref="PROTECTION_LEVEL_SAME"/>.
        /// This specifies the protection level of the child process to be the same as the protection level of its parent process.
        /// </summary>
        public static readonly UIntPtr PROC_THREAD_ATTRIBUTE_PROTECTION_LEVEL = (UIntPtr)0x2000B;

        /// <summary>
        /// The lpValue parameter is a pointer to a DWORD or DWORD64 value that specifies the child process policy.
        /// The policy specifies whether to allow a child process to be created.
        /// For information on the possible values for the DWORD or DWORD64 to which lpValue points, see Remarks.
        /// </summary>
        public static readonly UIntPtr PROC_THREAD_ATTRIBUTE_CHILD_PROCESS_POLICY = (UIntPtr)0x2000E;

        /// <summary>
        /// This attribute is relevant only to win32 applications that have been converted to UWP packages by using the Desktop Bridge.
        /// The lpValue parameter is a pointer to a DWORD value that specifies the desktop app policy.
        /// The policy specifies whether descendant processes should continue to run in the desktop environment.
        /// For information about the possible values for the DWORD to which lpValue points, see Remarks.
        /// </summary>
        public static readonly UIntPtr PROC_THREAD_ATTRIBUTE_DESKTOP_APP_POLICY = (UIntPtr)0x20012;

        /// <summary>
        /// PROCESS_NAME_NATIVE
        /// </summary>
        public const uint PROCESS_NAME_NATIVE = 0x00000001;


        /// <summary>
        /// <para>
        /// Creates a new process and its primary thread. The new process runs in the security context of the calling process.
        /// If the calling process is impersonating another user, the new process uses the token for the calling process, not the impersonation token.
        /// To run the new process in the security context of the user represented by the impersonation token,
        /// use the <see cref="CreateProcessAsUser"/> or <see cref="CreateProcessWithLogonW"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-createprocessw
        /// </para>
        /// </summary>
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
        /// To run a batch file, you must start the command interpreter; set <paramref name="lpApplicationName"/> to cmd.exe and
        /// set <paramref name="lpCommandLine"/> to the following arguments: /c plus the name of the batch file.
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
        /// <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> is <see cref="IntPtr.Zero"/>, the process gets a default security descriptor.
        /// The ACLs in the default security descriptor for a process come from the primary token of the creator.
        /// Windows XP:  The ACLs in the default security descriptor for a process come from the primary or impersonation token of the creator.
        /// This behavior changed with Windows XP with SP2 and Windows Server 2003.
        /// </param>
        /// <param name="lpThreadAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that determines whether
        /// the returned handle to the new thread object can be inherited by child processes.
        /// If <paramref name="lpThreadAttributes"/> is <see langword="null"/>, the handle cannot be inherited.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the main thread.
        /// If <paramref name="lpThreadAttributes"/> is <see langword="null"/> or
        /// <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> is <see cref="IntPtr.Zero"/>, the thread gets a default security descriptor.
        /// The ACLs in the default security descriptor for a thread come from the process token.
        /// Windows XP:  The ACLs in the default security descriptor for a thread come from the primary or impersonation token of the creator.
        /// This behavior changed with Windows XP with SP2 and Windows Server 2003.
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
        /// you must also ensure that dwCreationFlags includes <see cref="CREATE_UNICODE_ENVIRONMENT"/>.
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
        /// Handles in <see cref="STARTUPINFO"/> or <see cref="STARTUPINFOEX"/> must be closed with CloseHandle when they are no longer needed.
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
        /// A parent process can directly alter the environment variables of a child process during process creation.
        /// This is the only situation when a process can directly change the environment settings of another process.
        /// For more information, see Changing Environment Variables.
        /// If an application provides an environment block,
        /// the current directory information of the system drives is not automatically propagated to the new process.
        /// For example, there is an environment variable named =C: whose value is the current directory on drive C.
        /// An application must manually pass the current directory information to the new process.
        /// To do so, the application must explicitly create these environment variable strings,
        /// sort them alphabetically (because the system uses a sorted environment), and put them into the environment block.
        /// Typically, they will go at the front of the environment block, due to the environment block sort order.
        /// One way to obtain the current directory information for a drive X is to make the following call: GetFullPathName("X:", ...).
        /// That avoids an application having to scan the environment block.
        /// If the full path returned is X:, there is no need to pass that value on as environment data,
        /// since the root directory is the default current directory for drive X of a new process.
        /// When a process is created with <see cref="CREATE_NEW_PROCESS_GROUP"/> specified,
        /// an implicit call to SetConsoleCtrlHandler(NULL,TRUE) is made on behalf of the new process;
        /// this means that the new process has CTRL+C disabled.
        /// This lets shells handle CTRL+C themselves, and selectively pass that signal on to sub-processes.
        /// CTRL+BREAK is not disabled, and may be used to interrupt the process/process group.
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
        /// any program that incorrectly calls <see cref="CreateProcess"/> using the Program Files directory will run this application
        /// instead of the intended application.
        /// To avoid this problem, do not pass <see langword="null"/> for <paramref name="lpApplicationName"/>.
        /// If you do pass <see langword="null"/> for <paramref name="lpApplicationName"/>,
        /// use quotation marks around the executable path in <paramref name="lpCommandLine"/>, as shown in the example below.
        /// <code>
        /// LPTSTR szCmdline[] = _tcsdup(TEXT("\"C:\\Program Files\\MyApp\" -L -S"));
        /// CreateProcess(NULL, szCmdline, /*...*/);
        /// </code>
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateProcessW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CreateProcess([MarshalAs(UnmanagedType.LPWStr)][In]string lpApplicationName,
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
        /// Creates a new process and its primary thread.
        /// The new process runs in the security context of the user represented by the specified token.
        /// Typically, the process that calls the <see cref="CreateProcessAsUser"/> function must have the <see cref="SE_INCREASE_QUOTA_NAME"/> privilege
        /// and may require the <see cref="SE_ASSIGNPRIMARYTOKEN_NAME"/> privilege if the token is not assignable.
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
        /// the <see cref="SE_ASSIGNPRIMARYTOKEN_NAME"/> privilege is not required.
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateProcessAsUserW", SetLastError = true)]
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
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateProcessWithLogonW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CreateProcessWithLogonW([MarshalAs(UnmanagedType.LPWStr)][In]string lpUsername,
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
        /// The process that calls CreateProcessWithTokenW must have the <see cref="SE_IMPERSONATE_NAME"/> privilege.
        /// If this function fails with <see cref="SystemErrorCodes.ERROR_PRIVILEGE_NOT_HELD"/>, use the <see cref="CreateProcessAsUser"/>
        /// or <see cref="CreateProcessWithLogonW"/> function instead.
        /// Typically, the process that calls <see cref="CreateProcessAsUser"/> must have the <see cref="SE_INCREASE_QUOTA_NAME"/> privilege
        /// and may require the <see cref="SE_ASSIGNPRIMARYTOKEN_NAME"/> privilege if the token is not assignable.
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
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateProcessWithTokenW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CreateProcessWithTokenW([In]IntPtr hToken, [In]LogonFlags dwLogonFlags,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpApplicationName, [MarshalAs(UnmanagedType.LPWStr)][In]string lpCommandLine,
            [In]ProcessCreationFlags dwCreationFlags, [In]IntPtr lpEnvironment, [MarshalAs(UnmanagedType.LPWStr)][In]string lpCurrentDirectory,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(AlternativeStructObjectMarshaler<STARTUPINFO, STARTUPINFOEX>))]
            [In]AlternativeStructObject<STARTUPINFO, STARTUPINFOEX> lpStartupInfo, [Out]out PROCESS_INFORMATION lpProcessInformation);

        /// <summary>
        /// <para>
        /// Ends the calling process and all its threads.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/processthreadsapi/nf-processthreadsapi-exitprocess
        /// </para>
        /// </summary>
        /// <param name="uExitCode">
        /// The exit code for the process and all threads.
        /// </param>
        /// <remarks>
        /// Use the <see cref="GetExitCodeProcess"/> function to retrieve the process's exit value.
        /// Use the <see cref="GetExitCodeThread"/> function to retrieve a thread's exit value.
        /// Exiting a process causes the following:
        /// All of the threads in the process, except the calling thread, terminate their execution
        /// without receiving a <see cref="DLL_THREAD_DETACH"/> notification.
        /// The states of all of the threads terminated in step 1 become signaled.
        /// The entry-point functions of all loaded dynamic-link libraries (DLLs) are called with <see cref="DLL_PROCESS_DETACH"/>.
        /// After all attached DLLs have executed any process termination code, the <see cref="ExitProcess"/> function terminates the current process,
        /// including the calling thread.
        /// The state of the calling thread becomes signaled.
        /// All of the object handles opened by the process are closed.
        /// The termination status of the process changes from <see cref="STILL_ACTIVE"/> to the exit value of the process.
        /// The state of the process object becomes signaled, satisfying any threads that had been waiting for the process to terminate.
        /// If one of the terminated threads in the process holds a lock and the DLL detach code in one of the loaded DLLs
        /// attempts to acquire the same lock, then calling <see cref="ExitProcess"/> results in a deadlock.
        /// In contrast, if a process terminates by calling <see cref="TerminateProcess"/>, the DLLs that the process is attached to
        /// are not notified of the process termination.
        /// Therefore, if you do not know the state of all threads in your process,
        /// it is better to call <see cref="TerminateProcess"/> than <see cref="ExitProcess"/>.
        /// Note that returning from the main function of an application results in a call to <see cref="ExitProcess"/>.
        /// Calling <see cref="ExitProcess"/> in a DLL can lead to unexpected application or system errors.
        /// Be sure to call <see cref="ExitProcess"/> from a DLL only if you know which applications or system components
        /// will load the DLL  and that it is safe to call <see cref="ExitProcess"/> in this context.
        /// Exiting a process does not cause child processes to be terminated.
        /// Exiting a process does not necessarily remove the process object from the operating system.
        /// A process object is deleted when the last handle to the process is closed.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ExitProcess", SetLastError = true)]
        public static extern void ExitProcess([In]uint uExitCode);

        /// <summary>
        /// <para>
        /// Expands environment-variable strings and replaces them with the values defined for the current user.
        /// To specify the environment block for a particular user or the system, use the ExpandEnvironmentStringsForUser function.
        /// </para>
        /// </summary>
        /// <param name="lpSrc">
        /// A buffer that contains one or more environment-variable strings in the form: %variableName%.
        /// For each such reference, the %variableName% portion is replaced with the current value of that environment variable.
        /// Case is ignored when looking up the environment-variable name.
        /// If the name is not found, the %variableName% portion is left unexpanded.
        /// Note that this function does not support all the features that Cmd.exe supports.
        /// For example, it does not support %variableName:str1= str2 % or % variableName:~offset,length%.
        /// </param>
        /// <param name="lpDst">
        /// A pointer to a buffer that receives the result of expanding the environment variable strings in the <paramref name="lpSrc"/> buffer.
        /// Note that this buffer cannot be the same as the <paramref name="lpSrc"/> buffer.
        /// </param>
        /// <param name="nSize">
        /// The maximum number of characters that can be stored in the buffer pointed to by the <paramref name="lpDst"/> parameter.
        /// When using ANSI strings, the buffer size should be the string length, plus terminating null character, plus one.
        /// When using Unicode strings, the buffer size should be the string length plus the terminating null character.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the number of TCHARs stored in the destination buffer, including the terminating null character.
        /// If the destination buffer is too small to hold the expanded string, the return value is the required buffer size, in characters.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The size of the <paramref name="lpSrc"/> and <paramref name="lpDst"/> buffers is limited to 32K.
        /// To replace folder names in a fully qualified path with their associated environment-variable strings,
        /// use the <see cref="PathUnExpandEnvStrings"/> function.
        /// To retrieve the list of environment variables for a process, use the <see cref="GetEnvironmentStrings"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ExpandEnvironmentStringsW", SetLastError = true)]
        public static extern uint ExpandEnvironmentStrings([MarshalAs(UnmanagedType.LPWStr)][In]string lpSrc,
            [MarshalAs(UnmanagedType.LPWStr)][Out]StringBuilder lpDst, [In]uint nSize);

        /// <summary>
        /// <para>
        /// Flushes the instruction cache for the specified process.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/processthreadsapi/nf-processthreadsapi-flushinstructioncache
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// A handle to a process whose instruction cache is to be flushed.
        /// </param>
        /// <param name="lpBaseAddress">
        /// A pointer to the base of the region to be flushed.
        /// This parameter can be <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <param name="dwSize">
        /// The size of the region to be flushed if the <paramref name="lpBaseAddress"/> parameter is not <see cref="IntPtr.Zero"/>, in bytes.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Applications should call <see cref="FlushInstructionCache"/> if they generate or modify code in memory.
        /// The CPU cannot detect the change, and may execute the old code it cached.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FlushInstructionCache", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FlushInstructionCache([In]IntPtr hProcess, [In]IntPtr lpBaseAddress, [In]IntPtr dwSize);

        /// <summary>
        /// <para>
        /// Frees a block of environment strings.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/processenv/nf-processenv-freeenvironmentstringsw
        /// </para>
        /// </summary>
        /// <param name="penv"></param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If you used the ANSI version of <see cref="GetEnvironmentStrings"/>, be sure to use the ANSI version of <see cref="FreeEnvironmentStrings"/>.
        /// Similarly, if you used the Unicode version of <see cref="GetEnvironmentStrings"/>, 
        /// be sure to use the Unicode version of <see cref="FreeEnvironmentStrings"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FreeEnvironmentStringsW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FreeEnvironmentStrings([In]IntPtr penv);

        /// <summary>
        /// <para>
        /// Retrieves the current directory for the current process.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-getcurrentdirectory
        /// </para>
        /// </summary>
        /// <param name="nBufferLength">
        /// The length of the buffer for the current directory string, in TCHARs.
        /// The buffer length must include room for a terminating null character.
        /// </param>
        /// <param name="lpBuffer">
        /// A pointer to the buffer that receives the current directory string.
        /// This null-terminated string specifies the absolute path to the current directory.
        /// To determine the required buffer size, set this parameter to <see langword="null"/> and the <paramref name="nBufferLength"/> parameter to 0.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value specifies the number of characters that are written to the buffer,
        /// not including the terminating null character.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If the buffer that is pointed to by <paramref name="lpBuffer"/> is not large enough,
        /// the return value specifies the required size of the buffer, in characters, including the null-terminating character.
        /// </returns>
        /// <remarks>
        /// Each process has a single current directory that consists of two parts:
        /// A disk designator that is either a drive letter followed by a colon, or a server name followed by a share name (\\servername\sharename)
        /// A directory on the disk designator
        /// To set the current directory, use the <see cref="SetCurrentDirectory"/> function.
        /// Multithreaded applications and shared library code should not use the <see cref="GetCurrentDirectory"/> function
        /// and should avoid using relative path names.
        /// The current directory state written by the <see cref="SetCurrentDirectory"/> function is stored as a global variable in each process,
        /// therefore multithreaded applications cannot reliably use this value without possible data corruption from other threads
        /// that may also be reading or setting this value.
        /// This limitation also applies to the <see cref="SetCurrentDirectory"/> and <see cref="GetFullPathName"/> functions.
        /// The exception being when the application is guaranteed to be running in a single thread,
        /// for example parsing file names from the command line argument string in the main thread prior to creating any additional threads.
        /// Using relative path names in multithreaded applications or shared library code can yield unpredictable results and is not supported.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCurrentDirectory", SetLastError = true)]
        public static extern uint GetCurrentDirectory([In]uint nBufferLength, [MarshalAs(UnmanagedType.LPWStr)][Out]StringBuilder lpBuffer);

        /// <summary>
        /// <para>
        /// Retrieves a pseudo handle for the current process.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/processthreadsapi/nf-processthreadsapi-getcurrentprocess
        /// </para>
        /// </summary>
        /// <returns>
        /// The return value is a pseudo handle to the current process.
        /// </returns>
        /// <remarks>
        /// A pseudo handle is a special constant, currently -1, that is interpreted as the current process handle.
        /// For compatibility with future operating systems, it is best to call <see cref="GetCurrentProcess"/> instead of hard-coding this constant value.
        /// The calling process can use a pseudo handle to specify its own process whenever a process handle is required.
        /// Pseudo handles are not inherited by child processes.
        /// This handle has the <see cref="PROCESS_ALL_ACCESS"/> access right to the process object.
        /// For more information, see Process Security and Access Rights.
        /// Windows Server 2003 and Windows XP:
        /// This handle has the maximum access allowed by the security descriptor of the process to the primary token of the process.
        /// A process can create a "real" handle to itself that is valid in the context of other processes,
        /// or that can be inherited by other processes,
        /// by specifying the pseudo handle as the source handle in a call to the <see cref="DuplicateHandle"/> function.
        /// A process can also use the <see cref="OpenProcess"/> function to open a real handle to itself.
        /// The pseudo handle need not be closed when it is no longer needed.
        /// Calling the <see cref="CloseHandle"/> function with a pseudo handle has no effect.
        /// If the pseudo handle is duplicated by <see cref="DuplicateHandle"/>, the duplicate handle must be closed.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCurrentProcess", SetLastError = true)]
        public static extern IntPtr GetCurrentProcess();

        /// <summary>
        /// <para>
        /// Retrieves the environment variables for the current process.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/processenv/nf-processenv-getenvironmentstringsw
        /// </para>
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is a pointer to the environment block of the current process.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="GetEnvironmentStrings"/> function returns a pointer to a block of memory
        /// that contains the environment variables of the calling process (both the system and the user environment variables).
        /// Each environment block contains the environment variables in the following format:
        /// Var1 Value1 Var2 Value2 Var3 Value3 VarN ValueN Treat this memory as read-only; do not modify it directly.
        /// To add or change an environment variable, use the <see cref="GetEnvironmentVariable"/> and <see cref="SetEnvironmentVariable"/> functions.
        /// When the block returned by <see cref="GetEnvironmentStrings"/> is no longer needed,
        /// it should be freed by calling the <see cref="FreeEnvironmentStrings"/> function.
        /// Note that the ANSI version of this function, GetEnvironmentStringsA, returns OEM characters.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetEnvironmentStringsW", SetLastError = true)]
        public static extern IntPtr GetEnvironmentStrings();

        /// <summary>
        /// <para>
        /// Retrieves the contents of the specified variable from the environment block of the calling process.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/processenv/nf-processenv-getenvironmentvariablew
        /// </para>
        /// </summary>
        /// <param name="lpName">
        /// The name of the environment variable.
        /// </param>
        /// <param name="lpBuffer">
        /// A pointer to a buffer that receives the contents of the specified environment variable as a null-terminated string.
        /// An environment variable has a maximum size limit of 32,767 characters, including the null-terminating character.
        /// </param>
        /// <param name="nSize">
        /// The size of the buffer pointed to by the <paramref name="lpBuffer"/> parameter, including the null-terminating character, in characters.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the number of characters stored in the buffer pointed to by <paramref name="lpBuffer"/>,
        /// not including the terminating null character.
        /// If <paramref name="lpBuffer"/> is not large enough to hold the data, the return value is the buffer size, in characters,
        /// required to hold the string and its terminating null character and the contents of <paramref name="lpBuffer"/> are undefined.
        /// If the function fails, the return value is zero.
        /// If the specified environment variable was not found in the environment block,
        /// <see cref="GetLastError"/> returns <see cref="ERROR_ENVVAR_NOT_FOUND"/>.
        /// </returns>
        /// <remarks>
        /// This function can retrieve either a system environment variable or a user environment variable.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetEnvironmentVariableW", SetLastError = true)]
        public static extern uint GetEnvironmentVariable([MarshalAs(UnmanagedType.LPWStr)][In]string lpName,
            [MarshalAs(UnmanagedType.LPWStr)][Out]StringBuilder lpBuffer, [In]uint nSize);

        /// <summary>
        /// <para>
        /// Retrieves the termination status of the specified process.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/processthreadsapi/nf-processthreadsapi-getexitcodeprocess
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process.
        /// The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> or <see cref="PROCESS_QUERY_LIMITED_INFORMATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// Windows Server 2003 and Windows XP:  The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> access right.
        /// </param>
        /// <param name="lpExitCode">
        /// A pointer to a variable to receive the process termination status.
        /// For more information, see Remarks.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// This function returns immediately.
        /// If the process has not terminated and the function succeeds, the status returned is <see cref="STILL_ACTIVE"/>.
        /// If the process has terminated and the function succeeds, the status returned is one of the following values:
        /// The exit value specified in the <see cref="ExitProcess"/> or <see cref="TerminateProcess"/> function.
        /// The return value from the main or WinMain function of the process.
        /// The exception value for an unhandled exception that caused the process to terminate.
        /// The <see cref="GetExitCodeProcess"/> function returns a valid error code defined by the application only after the thread terminates.
        /// Therefore, an application should not use <see cref="STILL_ACTIVE"/> as an error code.
        /// If a thread returns <see cref="STILL_ACTIVE"/> as an error code, applications that test for this value could interpret it to mean
        /// that the thread is still running and continue to test for the completion of the thread after the thread has terminated,
        /// which could put the application into an infinite loop.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetExitCodeProcess", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetExitCodeProcess([In]IntPtr hProcess, [Out]out uint lpExitCode);

        /// <summary>
        /// <para>
        /// Retrieves the priority class for the specified process.
        /// This value, together with the priority value of each thread of the process, determines each thread's base priority level.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/processthreadsapi/nf-processthreadsapi-getpriorityclass
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process.
        /// The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> or <see cref="PROCESS_QUERY_LIMITED_INFORMATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// Windows Server 2003 and Windows XP:
        /// The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> access right.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the priority class of the specified process.
        /// If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Every thread has a base priority level determined by the thread's priority value and the priority class of its process.
        /// The operating system uses the base priority level of all executable threads to determine which thread gets the next slice of CPU time.
        /// Threads are scheduled in a round-robin fashion at each priority level,
        /// and only when there are no executable threads at a higher level will scheduling of threads at a lower level take place.
        /// For a table that shows the base priority levels for each combination of priority class and thread priority value, see Scheduling Priorities.
        /// Priority class is maintained by the executive, so all processes have a priority class that can be queried.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPriorityClass", SetLastError = true)]
        public static extern ProcessPriorityClasses GetPriorityClass([In]IntPtr hProcess);

        /// <summary>
        /// <para>
        /// Retrieves the process identifier of the specified process.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/processthreadsapi/nf-processthreadsapi-getprocessid
        /// </para>
        /// </summary>
        /// <param name="Process">
        /// A handle to the process. The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/>
        /// or <see cref="PROCESS_QUERY_LIMITED_INFORMATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// Windows Server 2003 and Windows XP:  The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> access right.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// Until a process terminates, its process identifier uniquely identifies it on the system.
        /// For more information about access rights, see Process Security and Access Rights.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetProcessId", SetLastError = true)]
        public static extern uint GetProcessId([In]IntPtr Process);

        /// <summary>
        /// <para>
        /// Retrieves the name of the executable file for the specified process.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/psapi/nf-psapi-getprocessimagefilenamew
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process.
        /// The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> or <see cref="PROCESS_QUERY_LIMITED_INFORMATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// Windows Server 2003 and Windows XP:
        /// The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> access right.
        /// </param>
        /// <param name="lpImageFileName">
        /// A pointer to a buffer that receives the full path to the executable file.
        /// </param>
        /// <param name="nSize">
        /// The size of the <paramref name="lpImageFileName"/> buffer, in characters.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value specifies the length of the string copied to the buffer.
        /// If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The file Psapi.dll is installed in the %windir%\System32 directory.
        /// If there is another copy of this DLL on your computer, it can lead to the following error when running applications on your system:
        /// "The procedure entry point GetProcessImageFileName could not be located in the dynamic link library PSAPI.DLL."
        /// To work around this problem, locate any versions that are not in the %windir%\System32 directory and delete or rename them, then restart.
        /// The GetProcessImageFileName function returns the path in device form, rather than drive letters.
        /// For example, the file name C:\Windows\System32\Ctype.nls would look as follows in device form:
        /// \Device\Harddisk0\Partition1\Windows\System32\Ctype.nls
        /// To retrieve the module name of the current process,
        /// use the <see cref="GetModuleFileName"/> function with a <see cref="IntPtr.Zero"/> module handle.
        /// This is more efficient than calling the <see cref="GetProcessImageFileName"/> function with a handle to the current process.
        /// To retrieve the name of the main executable module for a remote process in win32 path format,
        /// use the <see cref="QueryFullProcessImageName"/> function.
        /// Starting with Windows 7 and Windows Server 2008 R2, Psapi.h establishes version numbers for the PSAPI functions.
        /// The PSAPI version number affects the name used to call the function and the library that a program must load.
        /// If PSAPI_VERSION is 2 or greater, this function is defined as K32GetProcessImageFileName in Psapi.h and
        /// exported in Kernel32.lib and Kernel32.dll.
        /// If PSAPI_VERSION is 1, this function is defined as GetProcessImageFileName in Psapi.h and exported in Psapi.lib and Psapi.dll
        /// as a wrapper that calls K32GetProcessImageFileName.
        /// Programs that must run on earlier versions of Windows as well as Windows 7 and later versions should always 
        /// call this function as <see cref="GetProcessImageFileName"/>.
        /// To ensure correct resolution of symbols, add Psapi.lib to the TARGETLIBS macro and compile the program with -DPSAPI_VERSION=1.
        /// To use run-time dynamic linking, load Psapi.dll.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetProcessImageFileNameW", SetLastError = true)]
        public static extern uint GetProcessImageFileName([In]IntPtr hProcess, [MarshalAs(UnmanagedType.LPWStr)][Out]StringBuilder lpImageFileName,
            [In]uint nSize);

        /// <summary>
        /// <para>
        /// Retrieves timing information for the specified process.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/processthreadsapi/nf-processthreadsapi-getprocesstimes
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process whose timing information is sought. 
        /// The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> or <see cref="PROCESS_QUERY_LIMITED_INFORMATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// Windows Server 2003 and Windows XP: The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> access right.
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
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// All times are expressed using <see cref="FILETIME"/> data structures.
        /// Such a structure contains two 32-bit values that combine to form a 64-bit count of 100-nanosecond time units.
        /// Process creation and exit times are points in time expressed as the amount of time that has elapsed
        /// since midnight on January 1, 1601 at Greenwich, England.
        /// There are several functions that an application can use to convert such values to more generally useful forms.
        /// Process kernel mode and user mode times are amounts of time.
        /// For example, if a process has spent one second in kernel mode, this function will fill the <see cref="FILETIME"/> structure
        /// specified by <paramref name="lpKernelTime"/> with a 64-bit value of ten million.
        /// That is the number of 100-nanosecond units in one second.
        /// To retrieve the number of CPU clock cycles used by the threads of the process, use the <see cref="QueryProcessCycleTime"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetProcessTimes", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetProcessTimes([In]IntPtr hProcess, [Out]out FILETIME lpCreationTime, [Out]out FILETIME lpExitTime,
            [Out]out FILETIME lpKernelTime, [Out]out FILETIME lpUserTime);

        /// <summary>
        /// <para>
        /// Retrieves the contents of the <see cref="STARTUPINFO"/> structure that was specified when the calling process was created.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/processthreadsapi/nf-processthreadsapi-getstartupinfow
        /// </para>
        /// </summary>
        /// <param name="lpStartupInfo">
        /// A pointer to a <see cref="STARTUPINFO"/> structure that receives the startup information.
        /// </param>
        /// <remarks>
        /// The <see cref="STARTUPINFO"/> structure was specified by the process that created the calling process.
        /// It can be used to specify properties associated with the main window of the calling process.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetStartupInfoW", SetLastError = true)]
        public static extern void GetStartupInfo([Out]out STARTUPINFO lpStartupInfo);

        /// <summary>
        /// <para>
        /// Initializes the specified list of attributes for process and thread creation.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/processthreadsapi/nf-processthreadsapi-initializeprocthreadattributelist
        /// </para>
        /// </summary>
        /// <param name="lpAttributeList">
        /// The attribute list.
        /// This parameter can be <see cref="IntPtr.Zero"/> to determine the buffer size required to support the specified number of attributes.
        /// </param>
        /// <param name="dwAttributeCount">
        /// The count of attributes to be added to the list.
        /// </param>
        /// <param name="dwFlags">
        /// This parameter is reserved and must be zero.
        /// </param>
        /// <param name="lpSize">
        /// If <paramref name="lpAttributeList"/> is not <see cref="IntPtr.Zero"/>,
        /// this parameter specifies the size in bytes of the <paramref name="lpAttributeList"/> buffer on input.
        /// On output, this parameter receives the size in bytes of the initialized attribute list.
        /// If <paramref name="lpAttributeList"/> is <see cref="IntPtr.Zero"/>, this parameter receives the required buffer size in bytes.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// First, call this function with the <paramref name="dwAttributeCount"/> parameter set to the maximum number of attributes
        /// you will be using and the <paramref name="lpAttributeList"/> to <see cref="IntPtr.Zero"/>.
        /// The function returns the required buffer size in bytes in the <paramref name="lpSize"/> parameter.
        /// This initial call will return an error by design. This is expected behavior.
        /// Allocate enough space for the data in the lpAttributeList buffer and call the function again to initialize the buffer.
        /// To add attributes to the list, call the <see cref="UpdateProcThreadAttribute"/> function.
        /// To specify these attributes when creating a process, specify <see cref="EXTENDED_STARTUPINFO_PRESENT"/> in the dwCreationFlag parameter
        /// and a <see cref="STARTUPINFOEX"/> structure in the lpStartupInfo parameter.
        /// Note that you can specify the same <see cref="STARTUPINFOEX"/> structure to multiple child processes.
        /// When you have finished using the list, call the <see cref="DeleteProcThreadAttributeList"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitializeProcThreadAttributeList", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool InitializeProcThreadAttributeList([In]IntPtr lpAttributeList, [In]uint dwAttributeCount,
            [In]uint dwFlags, [In][Out]ref IntPtr lpSize);

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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "OpenProcessToken", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool OpenProcessToken([In]IntPtr ProcessHandle, [In]uint DesiredAccess, [Out]out IntPtr TokenHandle);

        /// <summary>
        /// <para>
        /// Retrieves the full name of the executable image for the specified process.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-queryfullprocessimagenamew
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process.
        /// This handle must be created with the <see cref="PROCESS_QUERY_INFORMATION"/> or <see cref="PROCESS_QUERY_LIMITED_INFORMATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </param>
        /// <param name="dwFlags">
        /// This parameter can be one of the following values.
        /// 0: The name should use the Win32 path format.
        /// <see cref="PROCESS_NAME_NATIVE"/>: The name should use the native system path format.
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
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or later.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "QueryFullProcessImageNameW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool QueryFullProcessImageName([In]IntPtr hProcess, [In]uint dwFlags,
            [MarshalAs(UnmanagedType.LPWStr)][In]StringBuilder lpExeName, [In][Out]ref uint lpdwSize);

        /// <summary>
        /// <para>
        /// Changes the current directory for the current process.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-setcurrentdirectory
        /// </para>
        /// </summary>
        /// <param name="lpPathName">
        /// The path to the new current directory.
        /// This parameter may specify a relative path or a full path.
        /// In either case, the full path of the specified directory is calculated and stored as the current directory.
        /// For more information, see File Names, Paths, and Namespaces.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// The final character before the null character must be a backslash ('').
        /// If you do not specify the backslash, it will be added for you; therefore, specify <see cref="MAX_PATH"/>-2 characters
        /// for the path unless you include the trailing backslash, in which case, specify <see cref="MAX_PATH"/>-1 characters for the path.
        /// Starting with Windows 10, version 1607, for the unicode version of this function (<see cref="SetCurrentDirectory"/>),
        /// you can opt-in to remove the <see cref="MAX_PATH"/> limitation.
        /// See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Each process has a single current directory made up of two parts:
        /// A disk designator that is either a drive letter followed by a colon, or a server name and share name (\\servername\sharename)
        /// A directory on the disk designator
        /// Multithreaded applications and shared library code should not use the <see cref="SetCurrentDirectory"/> function
        /// and should avoid using relative path names.
        /// The current directory state written by the <see cref="SetCurrentDirectory"/> function is stored as a global variable in each process,
        /// therefore multithreaded applications cannot reliably use this value without possible data corruption from other threads
        /// that may also be reading or setting this value.
        /// This limitation also applies to the <see cref="GetCurrentDirectory"/> and <see cref="GetFullPathName"/> functions.
        /// The exception being when the application is guaranteed to be running in a single thread,
        /// for example parsing file names from the command line argument string in the main thread prior to creating any additional threads.
        /// Using relative path names in multithreaded applications or shared library code can yield unpredictable results and is not supported.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetCurrentDirectory", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetCurrentDirectory([MarshalAs(UnmanagedType.LPWStr)][In]string lpPathName);

        /// <summary>
        /// <para>
        /// Sets the contents of the specified environment variable for the current process.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/processenv/nf-processenv-setenvironmentvariablew
        /// </para>
        /// </summary>
        /// <param name="lpName">
        /// The name of the environment variable.
        /// The operating system creates the environment variable if it does not exist and <paramref name="lpValue"/> is not <see langword="null"/>.
        /// </param>
        /// <param name="lpValue">
        /// The contents of the environment variable. The maximum size of a user-defined environment variable is 32,767 characters.
        /// For more information, see Environment Variables.
        /// Windows Server 2003 and Windows XP:  The total size of the environment block for a process may not exceed 32,767 characters.
        /// If this parameter is <see langword="null"/>, the variable is deleted from the current process's environment.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// This function has no effect on the system environment variables or the environment variables of other processes.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetEnvironmentVariableW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetEnvironmentVariable([MarshalAs(UnmanagedType.LPWStr)][In]string lpName,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpValue);

        /// <summary>
        /// <para>
        /// Terminates the specified process and all of its threads.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/processthreadsapi/nf-processthreadsapi-terminateprocess
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process to be terminated.
        /// The handle must have the <see cref="PROCESS_TERMINATE"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </param>
        /// <param name="uExitCode">
        /// The exit code to be used by the process and threads terminated as a result of this call.
        /// Use the <see cref="GetExitCodeProcess"/> function to retrieve a process's exit value.
        /// Use the <see cref="GetExitCodeThread"/> function to retrieve a thread's exit value.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="TerminateProcess"/> function is used to unconditionally cause a process to exit.
        /// The state of global data maintained by dynamic-link libraries (DLLs) may be compromised
        /// if <see cref="TerminateProcess"/> is used rather than <see cref="ExitProcess"/>.
        /// This function stops execution of all threads within the process and requests cancellation of all pending I/O.
        /// The terminated process cannot exit until all pending I/O has been completed or canceled.
        /// When a process terminates, its kernel object is not destroyed until all processes that have open handles to the process have released those handles.
        /// <see cref="TerminateProcess"/> is asynchronous; it initiates termination and returns immediately.
        /// If you need to be sure the process has terminated, call the <see cref="WaitForSingleObject"/> function with a handle to the process.
        /// A process cannot prevent itself from being terminated.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "TerminateProcess", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool TerminateProcess([In]IntPtr hProcess, [In]uint uExitCode);

        /// <summary>
        /// <para>
        /// Updates the specified attribute in a list of attributes for process and thread creation.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/processthreadsapi/nf-processthreadsapi-updateprocthreadattribute
        /// </para>
        /// </summary>
        /// <param name="lpAttributeList">
        /// A pointer to an attribute list created by the <see cref="InitializeProcThreadAttributeList"/> function.
        /// </param>
        /// <param name="dwFlags">
        /// This parameter is reserved and must be zero.
        /// </param>
        /// <param name="Attribute">
        /// The attribute key to update in the attribute list. This parameter can be one of the following values.
        /// <see cref="PROC_THREAD_ATTRIBUTE_GROUP_AFFINITY"/>, <see cref="PROC_THREAD_ATTRIBUTE_HANDLE_LIST"/>,
        /// <see cref="PROC_THREAD_ATTRIBUTE_IDEAL_PROCESSOR"/>, <see cref="PROC_THREAD_ATTRIBUTE_MITIGATION_POLICY"/>,
        /// <see cref="PROC_THREAD_ATTRIBUTE_PARENT_PROCESS"/>, <see cref="PROC_THREAD_ATTRIBUTE_PREFERRED_NODE"/>,
        /// <see cref="PROC_THREAD_ATTRIBUTE_UMS_THREAD"/>, <see cref="PROC_THREAD_ATTRIBUTE_SECURITY_CAPABILITIES"/>,
        /// <see cref="PROC_THREAD_ATTRIBUTE_PROTECTION_LEVEL"/>, <see cref="PROC_THREAD_ATTRIBUTE_CHILD_PROCESS_POLICY"/>,
        /// <see cref="PROC_THREAD_ATTRIBUTE_DESKTOP_APP_POLICY"/>.
        /// </param>
        /// <param name="lpValue">
        /// A pointer to the attribute value.
        /// This value should persist until the attribute is destroyed using the <see cref="DeleteProcThreadAttributeList"/> function.
        /// </param>
        /// <param name="cbSize">
        /// The size of the attribute value specified by the <paramref name="lpValue"/> parameter.
        /// </param>
        /// <param name="lpPreviousValue">
        /// This parameter is reserved and must be <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <param name="lpReturnSize">
        /// This parameter is reserved and must be <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// An attribute list is an opaque structure that consists of a series of key/value pairs, one for each attribute.
        /// A process can update only the attribute keys described in this topic.
        /// The DWORD or DWORD64 pointed to by <paramref name="lpValue"/> can be one or more of the following values
        /// when you specify <see cref="PROC_THREAD_ATTRIBUTE_MITIGATION_POLICY"/> for the <paramref name="Attribute"/> parameter:
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_DEP_ENABLE "/>:
        /// Enables data execution prevention (DEP) for the child process. For more information, see Data Execution Prevention.
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_DEP_ATL_THUNK_ENABLE "/>:
        /// Enables DEP-ATL thunk emulation for the child process.
        /// DEP-ATL thunk emulation causes the system to intercept NX faults that originate from the Active Template Library (ATL) thunk layer.
        /// This value can be specified only with <see cref="PROCESS_CREATION_MITIGATION_POLICY_DEP_ENABLE"/>.
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_SEHOP_ENABLE"/>:
        /// Enables structured exception handler overwrite protection (SEHOP) for the child process.
        /// SEHOP blocks exploits that use the structured exception handler (SEH) overwrite technique.
        /// Windows 7, Windows Server 2008 R2, Windows Server 2008 and Windows Vista:
        /// The following values are not supported until Windows 8 and Windows Server 2012.
        /// The force Address Space Layout Randomization(ASLR) policy, if enabled, forcibly rebases images
        /// that are not dynamic base compatible by acting as though an image base collision happened at load time.
        /// If relocations are required, images that do not have a base relocation section will not be loaded.
        /// The following mitigation options are available for mandatory ASLR policy:
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_FORCE_RELOCATE_IMAGES_ALWAYS_ON"/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_FORCE_RELOCATE_IMAGES_ALWAYS_OFF"/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_FORCE_RELOCATE_IMAGES_ALWAYS_ON_REQ_RELOCS "/>,
        /// The heap terminate on corruption policy, if enabled, causes the heap to terminate if it becomes corrupt.
        /// Note that 'always off' does not override the default opt-in for binaries with current subsystem versions set in the image header.
        /// Heap terminate on corruption is user mode enforced.
        /// The following mitigation options are available for heap terminate on corruption policy:
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_HEAP_TERMINATE_ALWAYS_ON "/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_HEAP_TERMINATE_ALWAYS_OFF "/>
        /// The bottom-up randomization policy, which includes stack randomization options, causes a random location to be used as the lowest user address.
        /// The following mitigation options are available for the bottom-up randomization policy:
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_BOTTOM_UP_ASLR_ALWAYS_ON "/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_BOTTOM_UP_ASLR_ALWAYS_OFF "/>
        /// The high-entropy bottom-up randomization policy, if enabled, causes up to 1TB of bottom-up variance to be used.
        /// Note that high-entropy bottom-up randomization is effective if and only if bottom-up ASLR is also enabled;
        /// high-entropy bottom-up randomization is only meaningful for native 64-bit processes.
        /// The following mitigation options are available for the high-entropy bottom-up randomization policy:
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_HIGH_ENTROPY_ASLR_ALWAYS_ON "/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_HIGH_ENTROPY_ASLR_ALWAYS_OFF "/>
        /// The strict handle checking enforcement policy, if enabled, causes an exception to be raised immediately on a bad handle reference.
        /// If this policy is not enabled, a failure status will be returned from the handle reference instead.
        /// The following mitigation options are available for the strict handle checking enforcement policy:
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_STRICT_HANDLE_CHECKS_ALWAYS_ON "/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_STRICT_HANDLE_CHECKS_ALWAYS_OFF "/>
        /// The Win32k system call disable policy, if enabled, prevents a process from making Win32k calls.
        /// The following mitigation options are available for the Win32k system call disable policy:
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_WIN32K_SYSTEM_CALL_DISABLE_ALWAYS_ON "/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_WIN32K_SYSTEM_CALL_DISABLE_ALWAYS_OFF "/>
        /// The Extension Point Disable policy, if enabled, prevents certain built-in third party extension points from being used.
        /// This policy blocks the following extension points:
        /// AppInit DLLs
        /// Winsock Layered Service Providers (LSPs)
        /// Globoal Windows Hooks
        /// Legacy Input Method Editors (IMEs)
        /// Local hooks still work with the Extension Point Disable policy enabled.
        /// This behavior is used to prevent legacy extension points from being loaded into a process that does not use them.
        /// The following mitigation options are available for the extension point disable policy:
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_EXTENSION_POINT_DISABLE_ALWAYS_ON"/>
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_EXTENSION_POINT_DISABLE_ALWAYS_OFF"/>
        /// The Control Flow Guard (CFG) policy, if turned on, places additional restrictions on indirect calls in code that has been built with CFG enabled.
        /// The following mitigation options are available for controlling the CFG policy:
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_CONTROL_FLOW_GUARD_MASK "/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_CONTROL_FLOW_GUARD_DEFER "/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_CONTROL_FLOW_GUARD_ALWAYS_ON "/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_CONTROL_FLOW_GUARD_ALWAYS_OFF "/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_CONTROL_FLOW_GUARD_EXPORT_SUPPRESSION "/>
        /// In addition, the following policy can be specified to enforce that EXEs/DLLs must enable CFG.
        /// If an attempt is made to load an EXE/DLL that does not enable CFG, the load will fail:
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY2_STRICT_CONTROL_FLOW_GUARD_MASK"/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY2_STRICT_CONTROL_FLOW_GUARD_DEFER"/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY2_STRICT_CONTROL_FLOW_GUARD_ALWAYS_ON"/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY2_STRICT_CONTROL_FLOW_GUARD_ALWAYS_OFF"/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY2_STRICT_CONTROL_FLOW_GUARD_RESERVED"/>
        /// The dynamic code policy, if turned on, prevents a process from generating dynamic code or modifying executable code.
        /// The following mitigation options are available for the dynamic code policy:
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_PROHIBIT_DYNAMIC_CODE_MASK"/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_PROHIBIT_DYNAMIC_CODE_DEFER"/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_PROHIBIT_DYNAMIC_CODE_ALWAYS_ON"/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_PROHIBIT_DYNAMIC_CODE_ALWAYS_OFF"/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_PROHIBIT_DYNAMIC_CODE_ALWAYS_ON_ALLOW_OPT_OUT"/>
        /// The binary signature policy requires EXEs/DLLs to be properly signed.
        /// The following mitigation options are available for the binary signature policy:
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_BLOCK_NON_MICROSOFT_BINARIES_MASK"/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_BLOCK_NON_MICROSOFT_BINARIES_DEFER"/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_BLOCK_NON_MICROSOFT_BINARIES_ALWAYS_ON"/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_BLOCK_NON_MICROSOFT_BINARIES_ALWAYS_OFF"/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_BLOCK_NON_MICROSOFT_BINARIES_ALLOW_STORE"/>
        /// The font loading prevention policy for the process determines whether non-system fonts can be loaded for a process.
        /// When the policy is turned on, the process is prevented from loading non-system fonts.
        /// The following mitigation options are available for the font loading prevention policy:
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_FONT_DISABLE_MASK"/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_FONT_DISABLE_DEFER "/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_FONT_DISABLE_ALWAYS_ON "/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_FONT_DISABLE_ALWAYS_OFF "/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_AUDIT_NONSYSTEM_FONTS "/>
        /// The image loading policy of the process determines the types of executable images that can be mapped into the process.
        /// When the policy is turned on, images cannot be loaded from some locations, such as remove devices or files that have the Low mandatory label.
        /// The following mitigation options are available for the image loading policy:
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_IMAGE_LOAD_NO_REMOTE_MASK "/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_IMAGE_LOAD_NO_REMOTE_DEFER "/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_IMAGE_LOAD_NO_REMOTE_ALWAYS_ON "/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_IMAGE_LOAD_NO_REMOTE_ALWAYS_OFF "/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_IMAGE_LOAD_NO_REMOTE_RESERVED "/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_IMAGE_LOAD_NO_LOW_LABEL_MASK "/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_IMAGE_LOAD_NO_LOW_LABEL_DEFER "/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_IMAGE_LOAD_NO_LOW_LABEL_ALWAYS_ON "/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_IMAGE_LOAD_NO_LOW_LABEL_ALWAYS_OFF "/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_IMAGE_LOAD_NO_LOW_LABEL_RESERVED "/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_IMAGE_LOAD_PREFER_SYSTEM32_MASK "/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_IMAGE_LOAD_PREFER_SYSTEM32_DEFER "/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_IMAGE_LOAD_PREFER_SYSTEM32_ALWAYS_ON "/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_IMAGE_LOAD_PREFER_SYSTEM32_ALWAYS_OFF "/>,
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY_IMAGE_LOAD_PREFER_SYSTEM32_RESERVED "/>,
        /// Windows 10, version 1709:
        /// The following value is available only in Windows 10, version 1709 or later and only with the January 2018 Windows security updates
        /// and any applicable firmware updates from the OEM device manufacturer.
        /// See Windows Client Guidance for IT Pros to protect against speculative execution side-channel vulnerabilities.
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY2_RESTRICT_INDIRECT_BRANCH_PREDICTION_ALWAYS_ON"/>,
        /// This flag can be used by processes to protect against sibling hardware threads (hyperthreads) from interfering with indirect branch predictions.
        /// Processes that have sensitive information in their address space should consider enabling this flag to protect against attacks
        /// involving indirect branch prediction (such as CVE-2017-5715).
        /// Windows 10, version 1809:  The following value is available only in Windows 10, version 1809 or later.
        /// <see cref="PROCESS_CREATION_MITIGATION_POLICY2_SPECULATIVE_STORE_BYPASS_DISABLE_ALWAYS_ON "/>,
        /// This flag can be used by processes to disable the Speculative Store Bypass (SSB) feature of CPUs
        /// that may be vulnerable to speculative execution side channel attacks involving SSB (CVE-2018-3639).
        /// This flag is only supported by certain Intel CPUs that have the requisite hardware features.
        /// On CPUs that do not support this feature, the flag has no effect.
        /// The DWORD or DWORD64 pointed to by <paramref name="lpValue"/> can be one or more of the following values
        /// when you specify <see cref="PROC_THREAD_ATTRIBUTE_CHILD_PROCESS_POLICY"/> for the <paramref name="Attribute"/> parameter:
        /// <see cref="PROCESS_CREATION_CHILD_PROCESS_RESTRICTED"/>
        /// The process being created is not allowed to create child processes.
        /// This restriction becomes a property of the token as which the process runs.
        /// It should be noted that this restriction is only effective in sandboxed applications (such as AppContainer)
        /// which ensure privileged process handles are not accessible to the process.
        /// For example, if a process restricting child process creation is able to access another process handle
        /// with <see cref="PROCESS_CREATE_PROCESS"/> or <see cref="PROCESS_VM_WRITE"/> access rights,
        /// then it may be possible to bypass the child process restriction.
        /// <see cref="PROCESS_CREATION_CHILD_PROCESS_OVERRIDE "/>
        /// The process being created is allowed to create a child process, if it would otherwise be restricted.
        /// You can only specify this value if the process that is creating the new process is not restricted.
        /// The DWORD pointed to by <paramref name="lpValue"/> can be one or more of the following values
        /// when you specify <see cref="PROC_THREAD_ATTRIBUTE_DESKTOP_APP_POLICY"/> for the <paramref name="Attribute"/> parameter:
        /// <see cref="PROCESS_CREATION_DESKTOP_APP_BREAKAWAY_ENABLE_PROCESS_TREE "/>
        /// The process being created will create any child processes outside of the desktop app runtime environment.
        /// This behavior is the default for processes for which no policy has been set.
        /// <see cref="PROCESS_CREATION_DESKTOP_APP_BREAKAWAY_DISABLE_PROCESS_TREE "/>
        /// The process being created will create any child processes inside of the desktop app runtime environment.
        /// This policy is inherited by the descendant processes until it is overridden
        /// by creating a process with <see cref="PROCESS_CREATION_DESKTOP_APP_BREAKAWAY_ENABLE_PROCESS_TREE"/>.
        /// <see cref="PROCESS_CREATION_DESKTOP_APP_BREAKAWAY_OVERRIDE "/>
        /// The process being created will run inside the desktop app runtime environment.
        /// This policy applies only to the process being created, not its descendants.
        /// In order to launch the child process with the same protection level as the parent,
        /// the parent process must specify the <see cref="PROC_THREAD_ATTRIBUTE_PROTECTION_LEVEL"/> attribute for the child process.
        /// This can be used for both protected and unprotected processes.
        /// For example, when this flag is used by an unprotected process, the system will launch a child process at unprotected level.
        /// The <see cref="CREATE_PROTECTED_PROCESS"/> flag must be specified in both cases.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "UpdateProcThreadAttribute", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UpdateProcThreadAttribute([In]IntPtr lpAttributeList, [In]uint dwFlags, [In]UIntPtr Attribute,
            [In]IntPtr lpValue, [In]UIntPtr cbSize, [In]IntPtr lpPreviousValue, [In]IntPtr lpReturnSize);
    }
}
