using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using System.Text;
using static Lsj.Util.Win32.Enums.DllMainReasons;
using static Lsj.Util.Win32.Enums.GetModuleHandleExFlags;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// Disables the <see cref="DLL_THREAD_ATTACH"/> and <see cref="DLL_THREAD_DETACH"/> notifications for the specified dynamic-link library (DLL).
        /// This can reduce the size of the working set for some applications.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/libloaderapi/nf-libloaderapi-disablethreadlibrarycalls
        /// </para>
        /// </summary>
        /// <param name="hLibModule">
        /// A handle to the DLL module for which the <see cref="DLL_THREAD_ATTACH"/> and <see cref="DLL_THREAD_DETACH"/> notifications are to be disabled.
        /// The <see cref="LoadLibrary"/>, <see cref="LoadLibraryEx"/>, or <see cref="GetModuleHandle"/> function returns this handle.
        /// Note that you cannot call <see cref="GetModuleHandle"/> with <see cref="IntPtr.Zero"/>
        /// because this returns the base address of the executable image, not the DLL image.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// The <see cref="DisableThreadLibraryCalls"/> function fails if the DLL specified
        /// by <paramref name="hLibModule"/> has active static thread local storage, or if <paramref name="hLibModule"/> is an invalid module handle.
        /// To get extended error information, see <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="DisableThreadLibraryCalls"/> function lets a DLL disable the <see cref="DLL_THREAD_ATTACH"/>
        /// and <see cref="DLL_THREAD_DETACH"/> notification calls.
        /// This can be a useful optimization for multithreaded applications that have many DLLs, frequently create and delete threads,
        /// and whose DLLs do not need these thread-level notifications of attachment/detachment.
        /// A remote procedure call (RPC) server application is an example of such an application.
        /// In these sorts of applications, DLL initialization routines often remain in memory
        /// to service <see cref="DLL_THREAD_ATTACH"/> and <see cref="DLL_THREAD_DETACH"/> notifications.
        /// By disabling the notifications, the DLL initialization code is not paged in because a thread is created or deleted,
        /// thus reducing the size of the application's working code set.
        /// To implement the optimization, modify a DLL's <see cref="DLL_PROCESS_ATTACH"/> code to call <see cref="DisableThreadLibraryCalls"/>.
        /// Do not call this function from a DLL that is linked to the static C run-time library (CRT).
        /// The static CRT requires <see cref="DLL_THREAD_ATTACH"/> and <see cref="DLL_THREAD_DETACH"/> notifications to function properly.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DisableThreadLibraryCalls", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DisableThreadLibraryCalls([In]IntPtr hLibModule);

        /// <summary>
        /// <para>
        /// Frees the loaded dynamic-link library (DLL) module and, if necessary, decrements its reference count.
        /// When the reference count reaches zero, the module is unloaded from the address space of the calling process and the handle is no longer valid.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/libloaderapi/nf-libloaderapi-freelibrary
        /// </para>
        /// </summary>
        /// <param name="hLibModule">
        /// A handle to the loaded library module.
        /// The <see cref="LoadLibrary"/>, <see cref="LoadLibraryEx"/>, <see cref="GetModuleHandle"/>,
        /// or <see cref="GetModuleHandleEx"/> function returns this handle.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, see <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The system maintains a per-process reference count for each loaded module.
        /// A module that was loaded at process initialization due to load-time dynamic linking has a reference count of one.
        /// The reference count for a module is incremented each time the module is loaded by a call to <see cref="LoadLibrary"/>.
        /// The reference count is also incremented by a call to <see cref="LoadLibraryEx"/> unless the module is being loaded for
        /// the first time and is being loaded as a data or image file.
        /// The reference count is decremented each time the <see cref="FreeLibrary"/>
        /// or <see cref="FreeLibraryAndExitThread"/> function is called for the module.
        /// When a module's reference count reaches zero or the process terminates, the system unloads the module from the address space of the process.
        /// Before unloading a library module, the system enables the module to detach from the process by calling the module's DllMain function,
        /// if it has one, with the <see cref="DLL_PROCESS_DETACH"/> value.
        /// Doing so gives the library module an opportunity to clean up resources allocated on behalf of the current process.
        /// After the entry-point function returns, the library module is removed from the address space of the current process.
        /// It is not safe to call <see cref="FreeLibrary"/> from DllMain. For more information, see the Remarks section in DllMain.
        /// Calling <see cref="FreeLibrary"/> does not affect other processes that are using the same module.
        /// Use caution when calling <see cref="FreeLibrary"/> with a handle returned by <see cref="GetModuleHandle"/>.
        /// The <see cref="GetModuleHandle"/> function does not increment a module's reference count,
        /// so passing this handle to <see cref="FreeLibrary"/> can cause a module to be unloaded prematurely.
        /// A thread that must unload the DLL in which it is executing and then terminate itself should call <see cref="FreeLibraryAndExitThread"/>
        /// instead of calling <see cref="FreeLibrary"/> and <see cref="ExitThread"/> separately.
        /// Otherwise, a race condition can occur.
        /// For details, see the Remarks section of <see cref="FreeLibraryAndExitThread"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FreeLibrary", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FreeLibrary([In]IntPtr hLibModule);

        /// <summary>
        /// <para>
        /// Retrieves the process identifier for each process object in the system.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/psapi/nf-psapi-enumprocesses
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
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, see <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// It is a good idea to use a large array, because it is hard to predict how many processes there will be
        /// at the time you call <see cref="EnumProcesses"/>.
        /// To determine how many processes were enumerated, divide the <paramref name="lpcbNeeded"/> value by sizeof(DWORD).
        /// There is no indication given when the buffer is too small to store all process identifiers.
        /// Therefore, if <paramref name="lpcbNeeded"/> equals cb, consider retrying the call with a larger array.
        /// To obtain process handles for the processes whose identifiers you have just obtained, call the <see cref="OpenProcess"/> function.
        /// Starting with Windows 7 and Windows Server 2008 R2, Psapi.h establishes version numbers for the PSAPI functions.
        /// The PSAPI version number affects the name used to call the function and the library that a program must load.
        /// If PSAPI_VERSION is 2 or greater, this function is defined as K32EnumProcesses in Psapi.h and exported in Kernel32.lib and Kernel32.dll.
        /// If PSAPI_VERSION is 1, this function is defined as <see cref="EnumProcesses"/> in Psapi.h and exported in Psapi.lib and Psapi.dll
        /// as a wrapper that calls K32EnumProcesses.
        /// Programs that must run on earlier versions of Windows as well as Windows 7 and later versions
        /// should always call this function as <see cref="EnumProcesses"/>.
        /// To ensure correct resolution of symbols, add Psapi.lib to the TARGETLIBS macro and compile the program with –DPSAPI_VERSION=1.
        /// To use run-time dynamic linking, load Psapi.dll.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumProcesses", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumProcesses([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)][In][Out]uint[] lpidProcess,
            [In]uint cb, [Out]out uint lpcbNeeded);

        /// <summary>
        /// <para>
        /// Decrements the reference count of a loaded dynamic-link library (DLL) by one,
        /// then calls <see cref="ExitThread"/> to terminate the calling thread.
        /// The function does not return.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/libloaderapi/nf-libloaderapi-freelibraryandexitthread
        /// </para>
        /// </summary>
        /// <param name="hLibModule">
        /// A handle to the DLL module whose reference count the function decrements.
        /// The <see cref="LoadLibrary"/> or <see cref="GetModuleHandleEx"/> function returns this handle.
        /// Do not call this function with a handle returned by the <see cref="GetModuleHandle"/> function,
        /// since this function does not maintain a reference count for the module.
        /// </param>
        /// <param name="dwExitCode">
        /// The exit code for the calling thread.
        /// </param>
        /// <remarks>
        /// The <see cref="FreeLibraryAndExitThread"/> function allows threads that are executing within a DLL to safely free the DLL
        /// in which they are executing and terminate themselves.
        /// If they were to call <see cref="FreeLibrary"/> and <see cref="ExitThread"/> separately, a race condition would exist.
        /// The library could be unloaded before <see cref="ExitThread"/> is called.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FreeLibraryAndExitThread", SetLastError = true)]
        public static extern void FreeLibraryAndExitThread([In]IntPtr hLibModule, [In]uint dwExitCode);

        /// <summary>
        /// <para>
        /// Retrieves the fully qualified path for the file that contains the specified module.
        /// The module must have been loaded by the current process.
        /// To locate the file for a module that was loaded by another process, use the <see cref="GetModuleFileNameEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/libloaderapi/nf-libloaderapi-getmodulefilenamew
        /// </para>
        /// </summary>
        /// <param name="hModule">
        /// A handle to the loaded module whose path is being requested.
        /// If this parameter is <see cref="IntPtr.Zero"/>,
        /// <see cref="GetModuleFileName"/> retrieves the path of the executable file of the current process.
        /// The <see cref="GetModuleFileName"/> function does not retrieve the path for modules
        /// that were loaded using the <see cref="LOAD_LIBRARY_AS_DATAFILE"/> flag.
        /// For more information, see <see cref="LoadLibraryEx"/>.
        /// </param>
        /// <param name="lpFilename">
        /// A pointer to a buffer that receives the fully qualified path of the module.
        /// If the length of the path is less than the size that the <paramref name="nSize"/> parameter specifies,
        /// the function succeeds and the path is returned as a null-terminated string.
        /// If the length of the path exceeds the size that the <paramref name="nSize"/> parameter specifies,
        /// the function succeeds and the string is truncated to <paramref name="nSize"/> characters including the terminating null character.
        /// Windows XP:  The string is truncated to nSize characters and is not null-terminated.
        /// The string returned will use the same format that was specified when the module was loaded.
        /// Therefore, the path can be a long or short file name, and can use the prefix "\?".
        /// For more information, see Naming a File.
        /// </param>
        /// <param name="nSize">
        /// The size of the <paramref name="lpFilename"/> buffer, in TCHARs.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the length of the string that is copied to the buffer, in characters,
        /// not including the terminating null character.
        /// If the buffer is too small to hold the module name, the string is truncated to <paramref name="nSize"/> characters
        /// including the terminating null character, the function returns <paramref name="nSize"/>,
        /// and the function sets the last error to <see cref="ERROR_INSUFFICIENT_BUFFER"/>.
        /// Windows XP:  If the buffer is too small to hold the module name, the function returns <paramref name="nSize"/>.
        /// The last error code remains <see cref="ERROR_SUCCESS"/>.
        /// If <paramref name="nSize"/> is zero, the return value is zero and the last error code is <see cref="ERROR_SUCCESS"/>
        /// If the function fails, the return value is 0 (zero). To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If a DLL is loaded in two processes, its file name in one process may differ in case from its file name in the other process.
        /// The global variable _pgmptr is automatically initialized to the full path of the executable file,
        /// and can be used to retrieve the full path name of an executable file.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetModuleFileNameW", SetLastError = true)]
        public static extern uint GetModuleFileName([In]IntPtr hModule, [MarshalAs(UnmanagedType.LPWStr)][Out]StringBuilder lpFilename, [In]uint nSize);

        /// <summary>
        /// <para>
        /// Retrieves the fully qualified path for the file containing the specified module.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/psapi/nf-psapi-getmodulefilenameexw
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process that contains the module.
        /// The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> and <see cref="PROCESS_VM_READ"/> access rights.
        /// For more information, see Process Security and Access Rights.
        /// The <see cref="GetModuleFileNameEx"/> function does not retrieve the path for modules
        /// that were loaded using the <see cref="LOAD_LIBRARY_AS_DATAFILE"/> flag.
        /// For more information, see <see cref="LoadLibraryEx"/>.
        /// </param>
        /// <param name="hModule">
        /// A handle to the module.
        /// If this parameter is <see cref="IntPtr.Zero"/>, <see cref="GetModuleFileNameEx"/> returns the path of the executable file of the process
        /// specified in <paramref name="hProcess"/>.
        /// </param>
        /// <param name="lpFilename">
        /// A pointer to a buffer that receives the fully qualified path to the module. 
        /// If the size of the file name is larger than the value of the <paramref name="nSize"/> parameter,
        /// the function succeeds but the file name is truncated and null-terminated.
        /// </param>
        /// <param name="nSize">
        /// The size of the <paramref name="lpFilename"/> buffer, in characters.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the length of the string that is copied to the buffer.
        /// If the function fails, the return value is 0 (zero). To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="GetModuleFileNameEx"/> function is primarily designed for use by debuggers and similar applications
        /// that must extract module information from another process.
        /// If the module list in the target process is corrupted or is not yet initialized,
        /// or if the module list changes during the function call as a result of DLLs being loaded or unloaded,
        /// <see cref="GetModuleFileNameEx"/> may fail or return incorrect information.
        /// To retrieve the name of a module in the current process, use the <see cref="GetModuleFileName"/> function.
        /// This is more efficient and more reliable than calling <see cref="GetModuleFileNameEx"/> with a handle to the current process.
        /// To retrieve the name of the main executable module for a remote process,
        /// use the <see cref="GetProcessImageFileName"/> or <see cref="QueryFullProcessImageName"/> function.
        /// This is more efficient and more reliable than calling the <see cref="GetModuleFileNameEx"/> function
        /// with a <see cref="IntPtr.Zero"/> module handle.
        /// Starting with Windows 7 and Windows Server 2008 R2, Psapi.h establishes version numbers for the PSAPI functions.
        /// The PSAPI version number affects the name used to call the function and the library that a program must load.
        /// If PSAPI_VERSION is 2 or greater, this function is defined as K32GetModuleFileNameEx in Psapi.h and exported in Kernel32.lib and Kernel32.dll.
        /// If PSAPI_VERSION is 1, this function is defined as GetModuleFileNameEx in Psapi.h and exported in Psapi.lib and Psapi.dll
        /// as a wrapper that calls K32GetModuleFileNameEx.
        /// Programs that must run on earlier versions of Windows as well as Windows 7 and later versions
        /// should always call this function as <see cref="GetModuleFileNameEx"/>.
        /// To ensure correct resolution of symbols, add Psapi.lib to the TARGETLIBS macro and compile the program with -DPSAPI_VERSION=1.
        /// To use run-time dynamic linking, load Psapi.dll.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetModuleFileNameExW", SetLastError = true)]
        public static extern uint GetModuleFileNameEx([In]IntPtr hProcess, [In]IntPtr hModule,
            [MarshalAs(UnmanagedType.LPWStr)][Out]StringBuilder lpFilename, [In]uint nSize);

        /// <summary>
        /// <para>
        /// Retrieves a module handle for the specified module. The module must have been loaded by the calling process.
        /// To avoid the race conditions described in the Remarks section, use the <see cref="GetModuleHandleEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/libloaderapi/nf-libloaderapi-getmodulehandlew
        /// </para>
        /// </summary>
        /// <param name="lpModuleName">
        /// The name of the loaded module (either a .dll or .exe file).
        /// If the file name extension is omitted, the default library extension .dll is appended.
        /// The file name string can include a trailing point character (.) to indicate that the module name has no extension.
        /// The string does not have to specify a path. When specifying a path, be sure to use backslashes (), not forward slashes (/).
        /// The name is compared (case independently) to the names of modules currently mapped into the address space of the calling process.
        /// If this parameter is <see langword="null"/>, <see cref="GetModuleHandle"/> returns a handle to the file 
        /// used to create the calling process (.exe file).
        /// The <see cref="GetModuleHandle"/> function does not retrieve handles for modules
        /// that were loaded using the <see cref="LOAD_LIBRARY_AS_DATAFILE"/> flag.
        /// For more information, see <see cref="LoadLibraryEx"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the specified module.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The returned handle is not global or inheritable. It cannot be duplicated or used by another process.
        /// If <paramref name="lpModuleName"/> does not include a path and there is more than one loaded module with the same base name and extension,
        /// you cannot predict which module handle will be returned.
        /// To work around this problem, you could specify a path, use side-by-side assemblies, or use <see cref="GetModuleHandleEx"/>
        /// to specify a memory location rather than a DLL name.
        /// The <see cref="GetModuleHandle"/> function returns a handle to a mapped module without incrementing its reference count.
        /// However, if this handle is passed to the FreeLibrary function, the reference count of the mapped module will be decremented.
        /// Therefore, do not pass a handle returned by <see cref="GetModuleHandle"/> to the <see cref="FreeLibrary"/> function.
        /// Doing so can cause a DLL module to be unmapped prematurely.
        /// This function must be used carefully in a multithreaded application.
        /// There is no guarantee that the module handle remains valid between the time this function returns the handle and the time it is used.
        /// For example, suppose that a thread retrieves a module handle, but before it uses the handle, a second thread frees the module.
        /// If the system loads another module, it could reuse the module handle that was recently freed.
        /// Therefore, the first thread would have a handle to a different module than the one intended.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetModuleHandleW", SetLastError = true)]
        public static extern IntPtr GetModuleHandle([MarshalAs(UnmanagedType.LPWStr)][In]string lpModuleName);

        /// <summary>
        /// <para>
        /// Retrieves a module handle for the specified module and increments the module's reference count
        /// unless <see cref="GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT"/> is specified.
        /// The module must have been loaded by the calling process.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/libloaderapi/nf-libloaderapi-getmodulehandleexw
        /// </para>
        /// </summary>
        /// <param name="dwFlags">
        /// This parameter can be zero or one or more of the following values.
        /// If the module's reference count is incremented, the caller must use the <see cref="FreeLibrary"/> function
        /// to decrement the reference count when the module handle is no longer needed.
        /// </param>
        /// <param name="lpModuleName">
        /// The name of the loaded module (either a .dll or .exe file), or an address in the module
        /// (if <paramref name="dwFlags"/> is <see cref="GET_MODULE_HANDLE_EX_FLAG_FROM_ADDRESS"/>).
        /// For a module name, if the file name extension is omitted, the default library extension .dll is appended.
        /// The file name string can include a trailing point character (.) to indicate that the module name has no extension.
        /// The string does not have to specify a path.
        /// When specifying a path, be sure to use backslashes (), not forward slashes (/).
        /// The name is compared (case independently) to the names of modules currently mapped into the address space of the calling process.
        /// If this parameter is <see langword="null"/>, the function returns a handle to the file used to create the calling process (.exe file).
        /// </param>
        /// <param name="phModule">
        /// A handle to the specified module.
        /// If the function fails, this parameter is <see cref="IntPtr.Zero"/>.
        /// The <see cref="GetModuleHandleEx"/> function does not retrieve handles for modules that were loaded
        /// using the <see cref="LOAD_LIBRARY_AS_DATAFILE"/> flag.
        /// For more information, see <see cref="LoadLibraryEx"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, see <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The handle returned is not global or inheritable. It cannot be duplicated or used by another process.
        /// If <paramref name="lpModuleName"/> does not include a path and there is more than one loaded module with the same base name and extension,
        /// you cannot predict which module handle will be returned.
        /// To work around this problem, you could specify a path, use side-by-side assemblies, or specify a memory location rather than a DLL name
        /// in the <paramref name="lpModuleName"/> parameter.
        /// If <paramref name="dwFlags"/> contains <see cref="GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT"/>,
        /// the <see cref="GetModuleHandleEx"/> function returns a handle to a mapped module without incrementing its reference count.
        /// However, if this handle is passed to the FreeLibrary function, the reference count of the mapped module will be decremented.
        /// Therefore, do not pass a handle returned by <see cref="GetModuleHandleEx"/>
        /// with <see cref="GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT"/> to the <see cref="FreeLibrary"/> function.
        /// Doing so can cause a DLL module to be unmapped prematurely.
        /// If <paramref name="dwFlags"/> contains <see cref="GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT"/>,
        /// this function must be used carefully in a multithreaded application.
        /// There is no guarantee that the module handle remains valid between the time this function returns the handle and the time it is used.
        /// For example, a thread retrieves a module handle, but before it uses the handle, a second thread frees the module.
        /// If the system loads another module, it could reuse the module handle that was recently freed.
        /// Therefore, first thread would have a handle to a module different than the one intended.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0501 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetModuleHandleExW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetModuleHandleEx([In]GetModuleHandleExFlags dwFlags, [MarshalAs(UnmanagedType.LPWStr)][In]string lpModuleName,
            [Out]out IntPtr phModule);
    }
}
