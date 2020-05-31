using Lsj.Util.Win32.BaseTypes;
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
        /// Determines whether the specified process is running under WOW64 or an Intel64 of x64 processor.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wow64apiset/nf-wow64apiset-iswow64process
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process.
        /// The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> or <see cref="PROCESS_QUERY_LIMITED_INFORMATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// Windows Server 2003 and Windows XP:  The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> access right.
        /// </param>
        /// <param name="Wow64Process">
        /// A pointer to a value that is set to <see cref="TRUE"/> if the process is running under WOW64 on an Intel64 or x64 processor.
        /// If the process is running under 32-bit Windows, the value is set to <see cref="FALSE"/>.
        /// If the process is a 32-bit application running under 64-bit Windows 10 on ARM, the value is set to <see cref="FALSE"/>.
        /// If the process is a 64-bit application running under 64-bit Windows, the value is also set to <see cref="FALSE"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Applications should use <see cref="IsWow64Process2"/> instead of <see cref="IsWow64Process"/> to determine if a process is running under WOW.
        /// <see cref="IsWow64Process2"/> removes the ambiguity inherent to multiple WOW environments
        /// by explicitly returning both the architecture of the host and guest for a given process.
        /// Applications can use this information to reliably identify situations such as running under emulation on ARM64.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0501 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsWow64Process", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsWow64Process([In]HANDLE hProcess, [Out]out BOOL Wow64Process);

        /// <summary>
        /// <para>
        /// Determines whether the specified process is running under WOW64; also returns additional machine process and architecture information.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wow64apiset/nf-wow64apiset-iswow64process2
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process.
        /// The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> or <see cref="PROCESS_QUERY_LIMITED_INFORMATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </param>
        /// <param name="pProcessMachine">
        /// On success, returns a pointer to an IMAGE_FILE_MACHINE_* value.
        /// The value will be <see cref="IMAGE_FILE_MACHINE_UNKNOWN"/> if the target process is not a WOW64 process;
        /// otherwise, it will identify the type of WoW process.
        /// </param>
        /// <param name="pNativeMachine">
        /// On success, returns a pointer to a possible IMAGE_FILE_MACHINE_* value identifying the native architecture of host system.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// IsWow64Process2 provides an improved direct replacement for <see cref="IsWow64Process"/>.
        /// In addition to determining if the specified process is running under WOW64,
        /// <see cref="IsWow64Process2"/> returns the following information:
        /// Whether the target process, specified by <paramref name="hProcess"/>, is running under Wow or not.
        /// The architecture of the target process.
        /// Optionally, the architecture of the host system.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsWow64Process2", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsWow64Process2([In]HANDLE hProcess, [Out]out USHORT pProcessMachine, [Out]out USHORT pNativeMachine);

        /// <summary>
        /// <para>
        /// Disables file system redirection for the calling thread. File system redirection is enabled by default.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wow64apiset/nf-wow64apiset-wow64disablewow64fsredirection
        /// </para>
        /// </summary>
        /// <param name="OldValue">
        /// The WOW64 file system redirection value.
        /// The system uses this parameter to store information necessary to revert (re-enable) file system redirection.
        /// Note  This value is for system use only. To avoid unpredictable behavior, do not modify this value in any way.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a <see cref="TRUE"/> value.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// This function is useful for 32-bit applications that want to gain access to the native system32 directory.
        /// By default, WOW64 file system redirection is enabled.
        /// The <see cref="Wow64DisableWow64FsRedirection"/>/<see cref="Wow64RevertWow64FsRedirection"/> function pairing is a replacement
        /// for the functionality of the <see cref="Wow64EnableWow64FsRedirection"/> function.
        /// To restore file system redirection, call the <see cref="Wow64RevertWow64FsRedirection"/> function.
        /// Every successful call to the <see cref="Wow64DisableWow64FsRedirection"/> function must have a matching call
        /// to the <see cref="Wow64RevertWow64FsRedirection"/> function.
        /// This will ensure redirection is re-enabled and frees associated system resources.
        /// Note The <see cref="Wow64DisableWow64FsRedirection"/> function affects all file operations performed by the current thread,
        /// which can have unintended consequences if file system redirection is disabled for any length of time.
        /// For example, DLL loading depends on file system redirection, so disabling file system redirection will cause DLL loading to fail.
        /// Also, many feature implementations use delayed loading and will fail while redirection is disabled.
        /// The failure state of the initial delay-load operation is persisted, so any subsequent use of the delay-load function
        /// will fail even after file system redirection is re-enabled.
        /// To avoid these problems, disable file system redirection immediately before calls to specific file I/O functions
        /// (such as <see cref="CreateFile"/>) that must not be redirected, and re-enable file system redirection immediately
        /// afterward using <see cref="Wow64RevertWow64FsRedirection"/>.
        /// Disabling file system redirection affects only operations made by the current thread.
        /// Some functions, such as <see cref="CreateProcessAsUser"/>, do their work on another thread,
        /// which is not affected by the state of file system redirection in the calling thread.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "Wow64DisableWow64FsRedirection", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL Wow64DisableWow64FsRedirection([Out]out PVOID OldValue);

        /// <summary>
        /// <para>
        /// Enables or disables file system redirection for the calling thread.
        /// This function may not work reliably when there are nested calls.
        /// Therefore, this function has been replaced by the <see cref="Wow64DisableWow64FsRedirection"/>
        /// and <see cref="Wow64RevertWow64FsRedirection"/> functions.
        /// Note These two methods of controlling file system redirection cannot be combined in any way.
        /// Do not use the <see cref="Wow64EnableWow64FsRedirection"/> function with either the <see cref="Wow64DisableWow64FsRedirection"/>
        /// or the <see cref="Wow64RevertWow64FsRedirection"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-wow64enablewow64fsredirection
        /// </para>
        /// </summary>
        /// <param name="Wow64FsEnableRedirection">
        /// Indicates the type of request for WOW64 system folder redirection.
        /// If <see cref="BOOLEAN.TRUE"/>, requests redirection be enabled; if <see cref="BOOLEAN.FALSE"/>, requests redirection be disabled.
        /// </param>
        /// <returns>
        /// Boolean value indicating whether the function succeeded.
        /// If <see cref="BOOLEAN.TRUE"/>, the function succeeded; if <see cref="BOOLEAN.FALSE"/>, the function failed.
        /// </returns>
        /// <remarks>
        /// This function is useful for 32-bit applications that want to gain access to the native system32 directory.
        /// By default, WOW64 file system redirection is enabled.
        /// Note The <see cref="Wow64EnableWow64FsRedirection"/> function affects all file operations performed by the current thread,
        /// which can have unintended consequences if file system redirection is disabled for any length of time.
        /// For example, DLL loading depends on file system redirection, so disabling file system redirection will cause DLL loading to fail.
        /// Also, many feature implementations use delayed loading and will fail while redirection is disabled.
        /// The failure state of the initial delay-load operation is persisted, so any subsequent use of the delay-load function
        /// will fail even after file system redirection is re-enabled.
        /// To avoid these problems, disable file system redirection immediately before calls to specific file I/O functions
        /// (such as <see cref="CreateFile"/>) that must not be redirected, and re-enable file system redirection immediately
        /// afterward using <code>Wow64EnableWow64FsRedirection(TRUE)</code>.
        /// File redirection is enabled or disabled only for the thread calling this function.
        /// This affects only operations made by the current thread.
        /// Some functions, such as <see cref="CreateProcessAsUser"/>, do their work on another thread,
        /// which is not affected by the state of file system redirection in the calling thread.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "Wow64EnableWow64FsRedirection", ExactSpelling = true, SetLastError = true)]
        public static extern BOOLEAN Wow64EnableWow64FsRedirection([In]BOOLEAN Wow64FsEnableRedirection);

        /// <summary>
        /// <para>
        /// Restores file system redirection for the calling thread.
        /// This function should not be called without a previous call to the <see cref="Wow64DisableWow64FsRedirection"/> function.
        /// Any data allocation on behalf of the <see cref="Wow64DisableWow64FsRedirection"/> function is cleaned up by this function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wow64apiset/nf-wow64apiset-wow64revertwow64fsredirection
        /// </para>
        /// </summary>
        /// <param name="OlValue"></param>
        /// <returns>
        /// If the function succeeds, the return value is a <see cref="TRUE"/> value.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="Wow64DisableWow64FsRedirection"/>/<see cref="Wow64RevertWow64FsRedirection"/> function pair
        /// is a replacement for the functionality of the <see cref="Wow64EnableWow64FsRedirection"/> function.
        /// To disable file system redirection, call the <see cref="Wow64DisableWow64FsRedirection"/> function.
        /// Every call to the <b>Wow64DisableWow64FsRedirection</b> function must have a matching call
        /// to the <see cref="Wow64RevertWow64FsRedirection"/> function.
        /// This will ensure redirection is re-enabled and frees associated system resources.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "Wow64RevertWow64FsRedirection", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL Wow64RevertWow64FsRedirection([In]PVOID OlValue);

        /// <summary>
        /// <para>
        /// Suspends the specified WOW64 thread.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-wow64suspendthread
        /// </para>
        /// </summary>
        /// <param name="hThread">
        /// A handle to the thread that is to be suspended.
        /// The handle must have the <see cref="THREAD_SUSPEND_RESUME"/> access right.
        /// For more information, see Thread Security and Access Rights.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the thread's previous suspend count; otherwise, it is (<see cref="DWORD"/>) -1.
        /// To get extended error information, use the <see cref="GetLastError"/> function.
        /// </returns>
        /// <remarks>
        /// If the function succeeds, execution of the specified thread is suspended and the thread's suspend count is incremented.
        /// Suspending a thread causes the thread to stop executing user-mode (application) code.
        /// This function is primarily designed for use by debuggers.
        /// It is not intended to be used for thread synchronization.
        /// Calling <see cref="Wow64SuspendThread"/> on a thread that owns a synchronization object, such as a mutex or critical section,
        /// can lead to a deadlock if the calling thread tries to obtain a synchronization object owned by a suspended thread.
        /// To avoid this situation, a thread within an application that is not a debugger should signal the other thread to suspend itself.
        /// The target thread must be designed to watch for this signal and respond appropriately.
        /// Each thread has a suspend count (with a maximum value of <see cref="MAXIMUM_SUSPEND_COUNT"/>).
        /// If the suspend count is greater than zero, the thread is suspended; otherwise, the thread is not suspended and is eligible for execution.
        /// Calling <see cref="Wow64SuspendThread"/> causes the target thread's suspend count to be incremented.
        /// Attempting to increment past the maximum suspend count causes an error without incrementing the count.
        /// The ResumeThread function decrements the suspend count of a suspended thread.
        /// This function is intended for 64-bit applications.
        /// It is not supported on 32-bit Windows; such calls fail and set the last error code to <see cref="ERROR_INVALID_FUNCTION"/>.
        /// A 32-bit application can call this function on a WOW64 thread; the result is the same as calling the <see cref="SuspendThread"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "Wow64SuspendThread", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD Wow64SuspendThread([In]HANDLE hThread);
    }
}
