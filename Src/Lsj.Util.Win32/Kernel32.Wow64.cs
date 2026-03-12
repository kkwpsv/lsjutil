using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.ProcessAccessRights;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.ThreadAccessRights;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// Retrieves the path of the system directory used by WOW64.
        /// This directory is not present on 32-bit Windows.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wow64apiset/nf-wow64apiset-getsystemwow64directoryw"/>
        /// </para>
        /// </summary>
        /// <param name="lpBuffer">
        /// A pointer to the buffer to receive the path.
        /// This path does not end with a backslash.
        /// </param>
        /// <param name="uSize">
        /// The maximum size of the buffer, in <c>TCHAR</c>s.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the length, in <c>v</c>s,
        /// of the string copied to the buffer, not including the terminating null character.
        /// If the length is greater than the size of the buffer,
        /// the return value is the size of the buffer required to hold the path.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// On 32-bit Windows, the function always fails,
        /// and the extended error is set to <see cref="ERROR_CALL_NOT_IMPLEMENTED"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// WOW64 uses the system directory to store shared 32-bit code on 64-bit Windows.
        /// Most applications have no need to access this directory explicitly.
        /// </para>
        /// <para>
        /// For more information on WOW64, see Running 32-bit Applications.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSystemWow64DirectoryW", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetSystemWow64Directory([In] LPWSTR lpBuffer, [In] UINT uSize);

        /// <summary>
        /// <para>
        /// Determines whether the specified process is running under WOW64 or an Intel64 of x64 processor.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wow64apiset/nf-wow64apiset-iswow64process"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// <para>
        /// A handle to the process.
        /// The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> or <see cref="PROCESS_QUERY_LIMITED_INFORMATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:
        /// The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> access right.
        /// </para>
        /// </param>
        /// <param name="Wow64Process">
        /// A pointer to a value that is set to <see cref="TRUE"/> if the process is running under WOW64 on an Intel64 or x64 processor.
        /// If the process is running under 32-bit Windows, the value is set to <see cref="FALSE"/>.
        /// If the process is a 32-bit application running under 64-bit Windows 10 on ARM, the value is set to <see cref="FALSE"/>.
        /// If the process is a 64-bit application running under 64-bit Windows, the value is also set to <see cref="FALSE"/>.
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
        /// Applications should use <see cref="IsWow64Process2"/> instead of <see cref="IsWow64Process"/> to determine if a process is running under WOW.
        /// <see cref="IsWow64Process2"/> removes the ambiguity inherent to multiple WOW environments
        /// by explicitly returning both the architecture of the host and guest for a given process.
        /// Applications can use this information to reliably identify situations such as running under emulation on ARM64.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsWow64Process", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsWow64Process([In] HANDLE hProcess, [Out] out BOOL Wow64Process);

        /// <summary>
        /// <para>
        /// Determines whether the specified process is running under WOW64; also returns additional machine process and architecture information.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wow64apiset/nf-wow64apiset-iswow64process2"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process.
        /// The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> or <see cref="PROCESS_QUERY_LIMITED_INFORMATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </param>
        /// <param name="pProcessMachine">
        /// On success, returns a pointer to an <c>IMAGE_FILE_MACHINE_*</c> value.
        /// The value will be <see cref="IMAGE_FILE_MACHINE_UNKNOWN"/> if the target process is not a WOW64 process;
        /// otherwise, it will identify the type of WoW process.
        /// </param>
        /// <param name="pNativeMachine">
        /// On success, returns a pointer to a possible <c>IMAGE_FILE_MACHINE_*</c> value identifying the native architecture of host system.
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
        /// <para>
        /// <see cref="IsWow64Process2"/> provides an improved direct replacement for <see cref="IsWow64Process"/>.
        /// In addition to determining if the specified process is running under WOW64,
        /// <see cref="IsWow64Process2"/> returns the following information:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Whether the target process, specified by <paramref name="hProcess"/>, is running under Wow or not.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The architecture of the target process.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Optionally, the architecture of the host system.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows10, BuildNumbers.Windows10_1607)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsWow64Process2", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsWow64Process2([In] HANDLE hProcess, [Out] out USHORT pProcessMachine, [Out] out USHORT pNativeMachine);

        /// <summary>
        /// <para>
        /// Disables file system redirection for the calling thread. File system redirection is enabled by default.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wow64apiset/nf-wow64apiset-wow64disablewow64fsredirection"/>
        /// </para>
        /// </summary>
        /// <param name="OldValue">
        /// <para>
        /// The WOW64 file system redirection value.
        /// The system uses this parameter to store information necessary to revert (re-enable) file system redirection.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This value is for system use only. To avoid unpredictable behavior, do not modify this value in any way.
        /// </para>
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
        /// <para>
        /// This function is useful for 32-bit applications that want to gain access to the native system32 directory.
        /// By default, WOW64 file system redirection is enabled.
        /// </para>
        /// <para>
        /// The <see cref="Wow64DisableWow64FsRedirection"/>/<see cref="Wow64RevertWow64FsRedirection"/> function pairing
        /// is a replacement for the functionality of the <see cref="Wow64EnableWow64FsRedirection"/> function.
        /// </para>
        /// <para>
        /// To restore file system redirection, call the <see cref="Wow64RevertWow64FsRedirection"/> function.
        /// Every successful call to the <see cref="Wow64DisableWow64FsRedirection"/> function
        /// must have a matching call to the <see cref="Wow64RevertWow64FsRedirection"/> function.
        /// This will ensure redirection is re-enabled and frees associated system resources.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// The <see cref="Wow64DisableWow64FsRedirection"/> function affects all file operations performed by the current thread,
        /// which can have unintended consequences if file system redirection is disabled for any length of time.
        /// For example, DLL loading depends on file system redirection,
        /// so disabling file system redirection will cause DLL loading to fail.
        /// Also, many feature implementations use delayed loading and will fail while redirection is disabled.
        /// The failure state of the initial delay-load operation is persisted,
        /// so any subsequent use of the delay-load function will fail even after file system redirection is re-enabled.
        /// To avoid these problems, disable file system redirection immediately before calls to specific file I/O functions
        /// (such as <see cref="CreateFile"/>) that must not be redirected,
        /// and re-enable file system redirection immediately afterward using <see cref="Wow64RevertWow64FsRedirection"/>.
        /// Disabling file system redirection affects only operations made by the current thread.
        /// Some functions, such as <see cref="CreateProcessAsUser"/>, do their work on another thread,
        /// which is not affected by the state of file system redirection in the calling thread.
        /// </para>
        /// <para>
        /// In Windows 8 and Windows Server 2012, this function is supported by the following technologies.
        /// </para>
        /// <para>
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
        /// No
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
        /// Yes
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
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "Wow64DisableWow64FsRedirection", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL Wow64DisableWow64FsRedirection([Out] out PVOID OldValue);

        /// <summary>
        /// <para>
        /// Enables or disables file system redirection for the calling thread.
        /// </para>
        /// <para>
        /// This function may not work reliably when there are nested calls.
        /// Therefore, this function has been replaced by the <see cref="Wow64DisableWow64FsRedirection"/> and <see cref="Wow64RevertWow64FsRedirection"/> functions.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// These two methods of controlling file system redirection cannot be combined in any way.
        /// Do not use the <see cref="Wow64EnableWow64FsRedirection"/> function
        /// with either the <see cref="Wow64DisableWow64FsRedirection"/> or the <see cref="Wow64RevertWow64FsRedirection"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-wow64enablewow64fsredirection"/>
        /// </para>
        /// </summary>
        /// <param name="Wow64FsEnableRedirection">
        /// Indicates the type of request for WOW64 system folder redirection.
        /// If <see cref="TRUE"/>, requests redirection be enabled;
        /// if <see cref="FALSE"/>, requests redirection be disabled.
        /// </param>
        /// <returns>
        /// Boolean value indicating whether the function succeeded.
        /// If <see cref="TRUE"/>, the function succeeded;
        /// if <see cref="FALSE"/>, the function failed.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function is useful for 32-bit applications that want to gain access to the native system32 directory.
        /// By default, WOW64 file system redirection is enabled.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// The <see cref="Wow64EnableWow64FsRedirection"/> function affects all file operations performed by the current thread,
        /// which can have unintended consequences if file system redirection is disabled for any length of time.
        /// For example, DLL loading depends on file system redirection, so disabling file system redirection will cause DLL loading to fail.
        /// Also, many feature implementations use delayed loading and will fail while redirection is disabled.
        /// The failure state of the initial delay-load operation is persisted,
        /// so any subsequent use of the delay-load function will fail even after file system redirection is re-enabled.
        /// To avoid these problems, disable file system redirection immediately before calls to specific file I/O functions
        /// (such as <see cref="CreateFile"/>) that must not be redirected,
        /// and re-enable file system redirection immediately afterward using <c>Wow64EnableWow64FsRedirection(TRUE)</c>.
        /// </para>
        /// <para>
        /// File redirection is enabled or disabled only for the thread calling this function.
        /// This affects only operations made by the current thread.
        /// Some functions, such as <see cref="CreateProcessAsUser"/>, do their work on another thread,
        /// which is not affected by the state of file system redirection in the calling thread.
        /// </para>
        /// <para>
        /// In Windows 8 and Windows Server 2012, this function is supported by the following technologies.
        /// </para>
        /// <para>
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
        /// No
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
        /// Yes
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
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "Wow64EnableWow64FsRedirection", ExactSpelling = true, SetLastError = true)]
        public static extern BOOLEAN Wow64EnableWow64FsRedirection([In] BOOLEAN Wow64FsEnableRedirection);

        /// <summary>
        /// <para>
        /// Retrieves the context of the specified WOW64 thread.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wow64apiset/nf-wow64apiset-wow64getthreadcontext"/>
        /// </para>
        /// </summary>
        /// <param name="hThread">
        /// A handle to the thread whose context is to be retrieved.
        /// The handle must have <see cref="THREAD_GET_CONTEXT"/> access to the thread.
        /// For more information, see Thread Security and Access Rights.
        /// </param>
        /// <param name="lpContext">
        /// A <see cref="WOW64_CONTEXT"/> structure.
        /// The caller must initialize the <see cref="WOW64_CONTEXT.ContextFlags"/> member of this structure.
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
        /// This function is used to retrieve the thread context of the specified thread.
        /// The function retrieves a selective context based on the value
        /// of the <see cref="WOW64_CONTEXT.ContextFlags"/> member of the context structure.
        /// The thread identified by the <paramref name="hThread"/> parameter is typically being debugged,
        /// but the function can also operate when the thread is not being debugged.
        /// </para>
        /// <para>
        /// You cannot get a valid context for a running thread.
        /// Use the <see cref="Wow64SuspendThread"/> function to suspend the thread before calling <see cref="Wow64GetThreadContext"/>.
        /// </para>
        /// <para>
        /// If you call <see cref="Wow64GetThreadContext"/> for the current thread, the function returns successfully;
        /// however, the context returned is not valid.
        /// </para>
        /// <para>
        /// This function is intended for 64-bit applications.
        /// It is not supported on 32-bit Windows; such calls fail and set the last error code to <see cref="ERROR_INVALID_FUNCTION"/>.
        /// A 32-bit application can call this function on a WOW64 thread;
        /// the result is the same as calling the <see cref="GetThreadContext"/> function function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "Wow64GetThreadContext", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL Wow64GetThreadContext([In] HANDLE hThread, [In][Out] ref WOW64_CONTEXT lpContext);

        /// <summary>
        /// <para>
        /// Restores file system redirection for the calling thread.
        /// </para>
        /// <para>
        /// This function should not be called without a previous call to the <see cref="Wow64DisableWow64FsRedirection"/> function.
        /// </para>
        /// <para>
        /// Any data allocation on behalf of the <see cref="Wow64DisableWow64FsRedirection"/> function is cleaned up by this function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wow64apiset/nf-wow64apiset-wow64revertwow64fsredirection"/>
        /// </para>
        /// </summary>
        /// <param name="OlValue">
        /// <para>
        /// The WOW64 file system redirection value.
        /// This value is obtained from the <see cref="Wow64DisableWow64FsRedirection"/> function.
        /// </para>
        /// <para>
        /// This value is defined in <c>wow64apiset.h</c>.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a nonzero value.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="FALSE"/> (zero).
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="Wow64DisableWow64FsRedirection"/>/<see cref="Wow64RevertWow64FsRedirection"/> function pair
        /// is a replacement for the functionality of the <see cref="Wow64EnableWow64FsRedirection"/> function.
        /// </para>
        /// <para>
        /// To disable file system redirection, call the <see cref="Wow64DisableWow64FsRedirection"/> function.
        /// Every call to the <see cref="Wow64DisableWow64FsRedirection"/> function
        /// must have a matching call to the <see cref="Wow64RevertWow64FsRedirection"/> function.
        /// This will ensure redirection is re-enabled and frees associated system resources.
        /// </para>
        /// <para>
        /// In Windows 8 and Windows Server 2012, this function is supported by the following technologies.
        /// </para>
        /// <para>
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
        /// No
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
        /// Yes
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
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "Wow64RevertWow64FsRedirection", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL Wow64RevertWow64FsRedirection([In] PVOID OlValue);

        /// <summary>
        /// <para>
        /// Sets the context of the specified WOW64 thread.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wow64apiset/nf-wow64apiset-wow64setthreadcontext"/>
        /// </para>
        /// </summary>
        /// <param name="hThread">
        /// A handle to the thread whose context is to be set.
        /// </param>
        /// <param name="lpContext">
        /// A <see cref="WOW64_CONTEXT"/> structure.
        /// The caller must initialize the <see cref="ContextFlags"/> member of this structure.
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
        /// This function allows the selective context to be set based on the value
        /// of the <see cref="WOW64_CONTEXT.ContextFlags"/> member of the context structure.
        /// The thread handle identified by the <paramref name="hThread"/> parameter is typically being debugged,
        /// but the function can also operate even when it is not being debugged.
        /// </para>
        /// <para>
        /// This function is intended for 64-bit applications.
        /// It is not supported on 32-bit Windows; such calls fail and set the last error code to <see cref="ERROR_INVALID_FUNCTION"/>.
        /// A 32-bit application can call this function on a WOW64 thread;
        /// the result is the same as calling the <see cref="SetThreadContext"/> function.
        /// </para>
        /// <para>
        /// Do not try to set the context for a running thread; the results are unpredictable.
        /// Use the <see cref="Wow64SuspendThread"/> function to suspend the thread before calling <see cref="Wow64SetThreadContext"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "Wow64SetThreadContext", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL Wow64SetThreadContext([In] HANDLE hThread, [In] in WOW64_CONTEXT lpContext);

        /// <summary>
        /// <para>
        /// Suspends the specified WOW64 thread.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-wow64suspendthread"/>
        /// </para>
        /// </summary>
        /// <param name="hThread">
        /// A handle to the thread that is to be suspended.
        /// The handle must have the <see cref="THREAD_SUSPEND_RESUME"/> access right.
        /// For more information, see Thread Security and Access Rights.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the thread's previous suspend count; otherwise, it is <c>(DWORD) -1</c>.
        /// To get extended error information, use the <see cref="GetLastError"/> function.
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the function succeeds, execution of the specified thread is suspended and the thread's suspend count is incremented.
        /// Suspending a thread causes the thread to stop executing user-mode (application) code.
        /// </para>
        /// <para>
        /// This function is primarily designed for use by debuggers. It is not intended to be used for thread synchronization.
        /// Calling <see cref="Wow64SuspendThread"/> on a thread that owns a synchronization object, such as a mutex or critical section,
        /// can lead to a deadlock if the calling thread tries to obtain a synchronization object owned by a suspended thread.
        /// To avoid this situation, a thread within an application that is not a debugger should signal the other thread to suspend itself.
        /// The target thread must be designed to watch for this signal and respond appropriately.
        /// </para>
        /// <para>
        /// Each thread has a suspend count (with a maximum value of <see cref="MAXIMUM_SUSPEND_COUNT"/>).
        /// If the suspend count is greater than zero, the thread is suspended;
        /// otherwise, the thread is not suspended and is eligible for execution.
        /// Calling <see cref="Wow64SuspendThread"/> causes the target thread's suspend count to be incremented.
        /// Attempting to increment past the maximum suspend count causes an error without incrementing the count.
        /// </para>
        /// <para>
        /// The <see cref="ResumeThread"/> function decrements the suspend count of a suspended thread.
        /// </para>
        /// <para>
        /// This function is intended for 64-bit applications.
        /// It is not supported on 32-bit Windows; such calls fail and set the last error code to <see cref="ERROR_INVALID_FUNCTION"/>.
        /// A 32-bit application can call this function on a WOW64 thread;
        /// the result is the same as calling the <see cref="SuspendThread"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "Wow64SuspendThread", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD Wow64SuspendThread([In] HANDLE hThread);
    }
}
