using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.DllMainReasons;
using static Lsj.Util.Win32.Enums.EnumProcessModulesExFlags;
using static Lsj.Util.Win32.Enums.GetModuleHandleExFlags;
using static Lsj.Util.Win32.Enums.LoadLibraryExFlags;
using static Lsj.Util.Win32.Enums.ProcessAccessRights;
using static Lsj.Util.Win32.Enums.SearchPathModes;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// Adds a directory to the process DLL search path.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/libloaderapi/nf-libloaderapi-adddlldirectory"/>
        /// </para>
        /// </summary>
        /// <param name="NewDirectory">
        /// An absolute path to the directory to add to the search path.
        /// For example, to add the directory Dir2 to the process DLL search path, specify \Dir2.
        /// For more information about paths, see Naming Files, Paths, and Namespaces.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is an opaque pointer
        /// that can be passed to <see cref="RemoveDllDirectory"/> to remove the DLL from the process DLL search path.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="AddDllDirectory"/> function can be used to add any absolute path to the set of directories that are searched for a DLL.
        /// If <see cref="SetDefaultDllDirectories"/> is first called with <see cref="LOAD_LIBRARY_SEARCH_USER_DIRS"/>,
        /// directories specified with <see cref="AddDllDirectory"/> are added to the process DLL search path.
        /// Otherwise, directories specified with the <see cref="AddDllDirectory"/> function are used only
        /// for <see cref="LoadLibraryEx"/> function calls that specify <see cref="LOAD_LIBRARY_SEARCH_USER_DIRS"/>.
        /// If <see cref="AddDllDirectory"/> is used to add more than one directory to the process DLL search path,
        /// the order in which those directories are searched is unspecified.
        /// To remove a directory added with <see cref="AddDllDirectory"/>, use the <see cref="RemoveDllDirectory"/> function.
        /// Windows 7, Windows Server 2008 R2, Windows Vista and Windows Server 2008:
        /// To use this function in an application, call <see cref="GetProcAddress"/> to retrieve the function's address from Kernel32.dll.
        /// KB2533623 must be installed on the target platform.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "AddDllDirectory", ExactSpelling = true, SetLastError = true)]
        public static extern DLL_DIRECTORY_COOKIE AddDllDirectory([MarshalAs(UnmanagedType.LPWStr)][In] string NewDirectory);

        /// <summary>
        /// <para>
        /// Disables the <see cref="DLL_THREAD_ATTACH"/> and <see cref="DLL_THREAD_DETACH"/> notifications for the specified dynamic-link library (DLL).
        /// This can reduce the size of the working set for some applications.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/libloaderapi/nf-libloaderapi-disablethreadlibrarycalls"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DisableThreadLibraryCalls", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DisableThreadLibraryCalls([In] HMODULE hLibModule);

        /// <summary>
        /// <para>
        /// Retrieves the process identifier for each process object in the system.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/psapi/nf-psapi-enumprocesses"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "K32EnumProcesses", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnumProcesses([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)][In][Out] DWORD[] lpidProcess,
            [In] DWORD cb, [Out] out DWORD lpcbNeeded);

        /// <summary>
        /// <para>
        /// Retrieves a handle for each module in the specified process.
        /// To control whether a 64-bit application enumerates 32-bit modules, 64-bit modules,
        /// or both types of modules, use the <see cref="EnumProcessModulesEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/psapi/nf-psapi-enumprocessmodules"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process.
        /// </param>
        /// <param name="lphModule">
        /// An array that receives the list of module handles.
        /// </param>
        /// <param name="cb">
        /// The size of the <paramref name="lphModule"/> array, in bytes.
        /// </param>
        /// <param name="lpcbNeeded">
        /// The number of bytes required to store all module handles in the <paramref name="lphModule"/> array.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="EnumProcessModules"/> function is primarily designed for use by debuggers
        /// and similar applications that must extract module information from another process.
        /// If the module list in the target process is corrupted or not yet initialized,
        /// or if the module list changes during the function call as a result of DLLs being loaded or unloaded,
        /// <see cref="EnumProcessModules"/> may fail or return incorrect information.
        /// It is a good idea to specify a large array of <see cref="HMODULE"/> values,
        /// because it is hard to predict how many modules there will be in the process at the time you call <see cref="EnumProcessModules"/>.
        /// To determine if the <paramref name="lphModule"/> array is too small to hold all module handles for the process,
        /// compare the value returned in <paramref name="lpcbNeeded"/> with the value specified in <paramref name="cb"/>.
        /// If <paramref name="lpcbNeeded"/> is greater than <paramref name="cb"/>, increase the size of the array and call <see cref="EnumProcessModules"/> again.
        /// To determine how many modules were enumerated by the call to <see cref="EnumProcessModules"/>,
        /// divide the resulting value in the <paramref name="lpcbNeeded"/> parameter by <code>sizeof(HMODULE)</code>.
        /// The <see cref="EnumProcessModules"/> function does not retrieve handles for modules
        /// that were loaded with the <see cref="LOAD_LIBRARY_AS_DATAFILE"/> or similar flags.
        /// For more information, see <see cref="LoadLibraryEx"/>.
        /// Do not call <see cref="CloseHandle"/> on any of the handles returned by this function.
        /// The information comes from a snapshot, so there are no resources to be freed.
        /// If this function is called from a 32-bit application running on WOW64, it can only enumerate the modules of a 32-bit process.
        /// If the process is a 64-bit process, this function fails and the last error code is <see cref="ERROR_PARTIAL_COPY"/> (299).
        /// To take a snapshot of specified processes and the heaps, modules, and threads used by these processes, use the <see cref="CreateToolhelp32Snapshot"/> function.
        /// Starting with Windows 7 and Windows Server 2008 R2, Psapi.h establishes version numbers for the PSAPI functions.
        /// The PSAPI version number affects the name used to call the function and the library that a program must load.
        /// If PSAPI_VERSION is 2 or greater, this function is defined as K32EnumProcessModules in Psapi.h and exported in Kernel32.lib and Kernel32.dll.
        /// If PSAPI_VERSION is 1, this function is defined as <see cref="EnumProcessModules"/> in Psapi.h and exported in Psapi.lib and Psapi.dll as a wrapper that calls K32EnumProcessModules.
        /// Programs that must run on earlier versions of Windows as well as Windows 7 and later versions should always call this function as <see cref="EnumProcessModules"/>.
        /// To ensure correct resolution of symbols, add Psapi.lib to the TARGETLIBS macro and compile the program with -DPSAPI_VERSION=1.
        /// To use run-time dynamic linking, load Psapi.dll.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "K32EnumProcessModules", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnumProcessModules([In] HANDLE hProcess, [In][Out] HMODULE[] lphModule, [In] DWORD cb, [Out] out DWORD lpcbNeeded);

        /// <summary>
        /// <para>
        /// Retrieves a handle for each module in the specified process that meets the specified filter criteria.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/psapi/nf-psapi-enumprocessmodulesex"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process.
        /// </param>
        /// <param name="lphModule">
        /// An array that receives the list of module handles.
        /// </param>
        /// <param name="cb">
        /// The size of the <paramref name="lphModule"/> array, in bytes.
        /// </param>
        /// <param name="lpcbNeeded">
        /// The number of bytes required to store all module handles in the <paramref name="lphModule"/> array.
        /// </param>
        /// <param name="dwFilterFlag">
        /// The filter criteria. This parameter can be one of the following values.
        /// <see cref="LIST_MODULES_32BIT"/>, <see cref="LIST_MODULES_64BIT"/>, <see cref="LIST_MODULES_ALL"/>, <see cref="LIST_MODULES_DEFAULT"/>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="EnumProcessModulesEx"/> function is primarily designed for use by debuggers
        /// and similar applications that must extract module information from another process.
        /// If the module list in the target process is corrupted or not yet initialized, 
        /// or if the module list changes during the function call as a result of DLLs being loaded or unloaded,
        /// <see cref="EnumProcessModulesEx"/> may fail or return incorrect information.
        /// This function is intended primarily for 64-bit applications.
        /// If the function is called by a 32-bit application running under WOW64, the <paramref name="dwFilterFlag"/> option is ignored
        /// and the function provides the same results as the <see cref="EnumProcessModules"/> function.
        /// It is a good idea to specify a large array of <see cref="HMODULE"/> values,
        /// because it is hard to predict how many modules there will be in the process at the time you call <see cref="EnumProcessModulesEx"/>.
        /// To determine if the <paramref name="lphModule"/> array is too small to hold all module handles for the process,
        /// compare the value returned in <paramref name="lpcbNeeded"/> with the value specified in <paramref name="cb"/>.
        /// If <paramref name="lpcbNeeded"/> is greater than <paramref name="cb"/>, increase the size of the array and call <see cref="EnumProcessModulesEx"/> again.
        /// To determine how many modules were enumerated by the call to <see cref="EnumProcessModulesEx"/>,
        /// divide the resulting value in the <paramref name="lpcbNeeded"/> parameter by <code>sizeof(HMODULE)</code>.
        /// The <see cref="EnumProcessModulesEx"/> function does not retrieve handles for modules that were loaded with the <see cref="LOAD_LIBRARY_AS_DATAFILE"/> flag.
        /// For more information, see <see cref="LoadLibraryEx"/>.
        /// Do not call <see cref="CloseHandle"/> on any of the handles returned by this function.
        /// The information comes from a snapshot, so there are no resources to be freed.
        /// To take a snapshot of specified processes and the heaps, modules, and threads used by these processes,
        /// use the <see cref="CreateToolhelp32Snapshot"/> function.
        /// Starting with Windows 7 and Windows Server 2008 R2, Psapi.h establishes version numbers for the PSAPI functions.
        /// The PSAPI version number affects the name used to call the function and the library that a program must load.
        /// If PSAPI_VERSION is 2 or greater, this function is defined as K32EnumProcessModulesEx in Psapi.h and exported in Kernel32.lib and Kernel32.dll.
        /// If PSAPI_VERSION is 1, this function is defined as EnumProcessModulesEx in Psapi.h and exported in Psapi.lib and Psapi.dll as a wrapper that calls K32EnumProcessModulesEx.
        /// Programs that must run on earlier versions of Windows as well as Windows 7 and later versions should always call this function as <see cref="EnumProcessModulesEx"/>.
        /// To ensure correct resolution of symbols, add Psapi.lib to the TARGETLIBS macro and compile the program with –DPSAPI_VERSION=1.
        /// To use run-time dynamic linking, load Psapi.dll.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "K32EnumProcessModulesEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnumProcessModulesEx([In] HANDLE hProcess, [In][Out] HMODULE[] lphModule, [In] DWORD cb,
            [Out] out DWORD lpcbNeeded, [In] EnumProcessModulesExFlags dwFilterFlag);

        /// <summary>
        /// <para>
        /// Frees the loaded dynamic-link library (DLL) module and, if necessary, decrements its reference count.
        /// When the reference count reaches zero, the module is unloaded from the address space of the calling process and the handle is no longer valid.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/libloaderapi/nf-libloaderapi-freelibrary"/>
        /// </para>
        /// </summary>
        /// <param name="hLibModule">
        /// A handle to the loaded library module.
        /// The <see cref="LoadLibrary"/>, <see cref="LoadLibraryEx"/>, <see cref="GetModuleHandle"/>,
        /// or <see cref="GetModuleHandleEx"/> function returns this handle.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="BOOL.TRUE"/>.
        /// If the function fails, the return value is <see cref="BOOL.FALSE"/>.
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FreeLibrary", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL FreeLibrary([In] HMODULE hLibModule);

        /// <summary>
        /// <para>
        /// Decrements the reference count of a loaded dynamic-link library (DLL) by one,
        /// then calls <see cref="ExitThread"/> to terminate the calling thread.
        /// The function does not return.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/libloaderapi/nf-libloaderapi-freelibraryandexitthread"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FreeLibraryAndExitThread", ExactSpelling = true, SetLastError = true)]
        public static extern void FreeLibraryAndExitThread([In] HMODULE hLibModule, [In] DWORD dwExitCode);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hLibModule"></param>
        /// <returns></returns>
        [Obsolete]
        public static BOOL FreeModule(HINSTANCE hLibModule) => FreeLibrary(hLibModule);

        /// <summary>
        /// <para>
        /// Retrieves the fully qualified path for the file that contains the specified module.
        /// The module must have been loaded by the current process.
        /// To locate the file for a module that was loaded by another process, use the <see cref="GetModuleFileNameEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/libloaderapi/nf-libloaderapi-getmodulefilenamew"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetModuleFileNameW", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetModuleFileName([In] HMODULE hModule, [In] IntPtr lpFilename, [In] DWORD nSize);

        /// <summary>
        /// <para>
        /// Retrieves the fully qualified path for the file containing the specified module.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/psapi/nf-psapi-getmodulefilenameexw"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "K32GetModuleFileNameExW", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetModuleFileNameEx([In] HANDLE hProcess, [In] HMODULE hModule, [In] IntPtr lpFilename, [In] DWORD nSize);

        /// <summary>
        /// <para>
        /// Retrieves a module handle for the specified module. The module must have been loaded by the calling process.
        /// To avoid the race conditions described in the Remarks section, use the <see cref="GetModuleHandleEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/libloaderapi/nf-libloaderapi-getmodulehandlew"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetModuleHandleW", ExactSpelling = true, SetLastError = true)]
        public static extern HMODULE GetModuleHandle([In] LPWSTR lpModuleName);

        /// <summary>
        /// <para>
        /// Retrieves a module handle for the specified module and increments the module's reference count
        /// unless <see cref="GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT"/> is specified.
        /// The module must have been loaded by the calling process.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/libloaderapi/nf-libloaderapi-getmodulehandleexw"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetModuleHandleExW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetModuleHandleEx([In] GetModuleHandleExFlags dwFlags, [In] LPWSTR lpModuleName, [Out] out HMODULE phModule);

        /// <summary>
        /// <para>
        /// Retrieves the address of an exported function or variable from the specified dynamic-link library (DLL).
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/libloaderapi/nf-libloaderapi-getprocaddress"/>
        /// </para>
        /// </summary>
        /// <param name="hModule">
        /// A handle to the DLL module that contains the function or variable.
        /// The <see cref="LoadLibrary"/>, <see cref="LoadLibraryEx"/>, <see cref="LoadPackagedLibrary"/>, or <see cref="GetModuleHandle"/> function returns this handle.
        /// The <see cref="GetProcAddress"/> function does not retrieve addresses from modules that were loaded using the <see cref="LOAD_LIBRARY_AS_DATAFILE"/> flag.
        /// For more information, see <see cref="LoadLibraryEx"/>.
        /// </param>
        /// <param name="lpProcName">
        /// The function or variable name, or the function's ordinal value.
        /// If this parameter is an ordinal value, it must be in the low-order word; the high-order word must be zero.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the address of the exported function or variable.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The spelling and case of a function name pointed to by <paramref name="lpProcName"/> must be identical
        /// to that in the EXPORTS statement of the source DLL's module-definition (.def) file.
        /// The exported names of functions may differ from the names you use when calling these functions in your code.
        /// This difference is hidden by macros used in the SDK header files.
        /// For more information, see Conventions for Function Prototypes.
        /// The <paramref name="lpProcName"/> parameter can identify the DLL function
        /// by specifying an ordinal value associated with the function in the EXPORTS statement.
        /// <see cref="GetProcAddress"/> verifies that the specified ordinal is in the range 1 through the highest ordinal value exported in the .def file.
        /// The function then uses the ordinal as an index to read the function's address from a function table.
        /// If the .def file does not number the functions consecutively from 1 to N (where N is the number of exported functions),
        /// an error can occur where <see cref="GetProcAddress"/> returns an invalid, non-NULL address, even though there is no function with the specified ordinal.
        /// If the function might not exist in the DLL module—for example, if the function is available only on Windows Vista
        /// but the application might be running on Windows XP—specify the function by name rather than by ordinal value
        /// and design your application to handle the case when the function is not available, as shown in the following code fragment.
        /// <code>
        /// typedef void (WINAPI *PGNSI)(LPSYSTEM_INFO);
        /// 
        /// // Call GetNativeSystemInfo if supported or GetSystemInfo otherwise.
        /// 
        ///     PGNSI pGNSI;
        ///     SYSTEM_INFO si;
        ///     
        ///     ZeroMemory(&amp;si, sizeof(SYSTEM_INFO));
        ///     
        ///     pGNSI = (PGNSI) GetProcAddress(
        ///         GetModuleHandle(TEXT("kernel32.dll")), 
        ///         "GetNativeSystemInfo");
        ///    if(NULL != pGNSI)
        ///    {
        ///         pGNSI(&amp;si);
        ///    }
        ///    else 
        ///    {
        ///         GetSystemInfo(&amp;si);
        ///    }
        /// </code>
        /// For the complete example that contains this code fragment, see Getting the System Version.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetProcAddress", ExactSpelling = true, SetLastError = true, ThrowOnUnmappableChar = true)]
        public static extern FARPROC GetProcAddress([In] HMODULE hModule, [In] LPCSTR lpProcName);

        /// <summary>
        /// <para>
        /// Loads the specified module into the address space of the calling process.
        /// The specified module may cause other modules to be loaded.
        /// For additional load options, use the <see cref="LoadLibraryEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/libloaderapi/nf-libloaderapi-loadlibraryw"/>
        /// </para>
        /// </summary>
        /// <param name="lpLibFileName">
        /// The name of the module.
        /// This can be either a library module (a .dll file) or an executable module (an .exe file).
        /// The name specified is the file name of the module and is not related to the name stored in the library module itself,
        /// as specified by the LIBRARY keyword in the module-definition (.def) file.
        /// If the string specifies a full path, the function searches only that path for the module.
        /// If the string specifies a relative path or a module name without a path, the function uses a standard search strategy to find the module;
        /// for more information, see the Remarks.
        /// If the function cannot find the module, the function fails. When specifying a path, be sure to use backslashes (), not forward slashes (/).
        /// For more information about paths, see Naming a File or Directory.
        /// If the string specifies a module name without a path and the file name extension is omitted,
        /// the function appends the default library extension .dll to the module name.
        /// To prevent the function from appending .dll to the module name, include a trailing point character (.) in the module name string.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the module.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// To enable or disable error messages displayed by the loader during DLL loads, use the <see cref="SetErrorMode"/> function.
        /// <see cref="LoadLibrary"/> can be used to load a library module into the address space of the process and return a handle
        /// that can be used in <see cref="GetProcAddress"/> to get the address of a DLL function.
        /// <see cref="LoadLibrary"/> can also be used to load other executable modules.
        /// For example, the function can specify an .exe file to get a handle that can be used in <see cref="FindResource"/> or <see cref="LoadResource"/>.
        /// However, do not use <see cref="LoadLibrary"/> to run an .exe file. Instead, use the <see cref="CreateProcess"/> function.
        /// If the specified module is a DLL that is not already loaded for the calling process,
        /// the system calls the DLL's DllMain function with the <see cref="DLL_PROCESS_ATTACH"/> value.
        /// If DllMain returns <see cref="BOOL.TRUE"/>, <see cref="LoadLibrary"/> returns a handle to the module.
        /// If DllMain returns <see cref="BOOL.FALSE"/>, the system unloads the DLL from the process address space
        /// and <see cref="LoadLibrary"/> returns <see cref="IntPtr.Zero"/>.
        /// It is not safe to call <see cref="LoadLibrary"/> from DllMain.
        /// For more information, see the Remarks section in DllMain.
        /// Module handles are not global or inheritable.
        /// A call to <see cref="LoadLibrary"/> by one process does not produce a handle
        /// that another process can use — for example, in calling <see cref="GetProcAddress"/>.
        /// The other process must make its own call to <see cref="LoadLibrary"/> for the module before calling <see cref="GetProcAddress"/>.
        /// If <paramref name="lpLibFileName"/> does not include a path and there is more than one loaded module with the same base name and extension,
        /// the function returns a handle to the module that was loaded first.
        /// If no file name extension is specified in the <paramref name="lpLibFileName"/> parameter, the default library extension .dll is appended.
        /// However, the file name string can include a trailing point character (.) to indicate that the module name has no extension.
        /// When no path is specified, the function searches for loaded modules whose base name matches the base name of the module to be loaded.
        /// If the name matches, the load succeeds. Otherwise, the function searches for the file.
        /// The first directory searched is the directory containing the image file used to create the calling process
        /// (for more information, see the <see cref="CreateProcess"/> function).
        /// Doing this allows private dynamic-link library (DLL) files associated with a process to be found
        /// without adding the process's installed directory to the PATH environment variable.
        /// If a relative path is specified, the entire relative path is appended to every token in the DLL search path list.
        /// To load a module from a relative path without searching any other path, use <see cref="GetFullPathName"/> to get a nonrelative path
        /// and call <see cref="LoadLibrary"/> with the nonrelative path.
        /// For more information on the DLL search order, see Dynamic-Link Library Search Order.
        /// The search path can be altered using the <see cref="SetDllDirectory"/> function.
        /// This solution is recommended instead of using <see cref="SetCurrentDirectory"/> or hard-coding the full path to the DLL.
        /// If a path is specified and there is a redirection file for the application, the function searches for the module in the application's directory.
        /// If the module exists in the application's directory, <see cref="LoadLibrary"/> ignores the specified path
        /// and loads the module from the application's directory.
        /// If the module does not exist in the application's directory, <see cref="LoadLibrary"/> loads the module from the specified directory.
        /// For more information, see Dynamic Link Library Redirection.
        /// If you call <see cref="LoadLibrary"/> with the name of an assembly without a path specification
        /// and the assembly is listed in the system compatible manifest, the call is automatically redirected to the side-by-side assembly.
        /// The system maintains a per-process reference count on all loaded modules.
        /// Calling <see cref="LoadLibrary"/> increments the reference count.
        /// Calling the <see cref="FreeLibrary"/> or <see cref="FreeLibraryAndExitThread"/> function decrements the reference count.
        /// The system unloads a module when its reference count reaches zero or when the process terminates (regardless of the reference count).
        /// Windows Server 2003 and Windows XP:
        /// The Visual C++ compiler supports a syntax that enables you to declare thread-local variables: _declspec(thread).
        /// If you use this syntax in a DLL, you will not be able to load the DLL explicitly
        /// using <see cref="LoadLibrary"/> on versions of Windows prior to Windows Vista.
        /// If your DLL will be loaded explicitly, you must use the thread local storage functions instead of _declspec(thread).
        /// For an example, see Using Thread Local Storage in a Dynamic Link Library.
        /// Security Remark
        /// Do not use the <see cref="SearchPath"/> function to retrieve a path to a DLL for a subsequent <see cref="LoadLibrary"/> call.
        /// The <see cref="SearchPath"/> function uses a different search order than <see cref="LoadLibrary"/>
        /// and it does not use safe process search mode unless this is explicitly enabled
        /// by calling <see cref="SetSearchPathMode"/> with <see cref="BASE_SEARCH_PATH_ENABLE_SAFE_SEARCHMODE"/>.
        /// Therefore, <see cref="SearchPath"/> is likely to first search the user’s current working directory for the specified DLL.
        /// If an attacker has copied a malicious version of a DLL into the current working directory,
        /// the path retrieved by <see cref="SearchPath"/> will point to the malicious DLL, which <see cref="LoadLibrary"/> will then load.
        /// Do not make assumptions about the operating system version based on a <see cref="LoadLibrary"/> call that searches for a DLL.
        /// If the application is running in an environment where the DLL is legitimately not present but a malicious version of the DLL
        /// is in the search path, the malicious version of the DLL may be loaded.
        /// Instead, use the recommended techniques described in Getting the System Version.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadLibraryW", ExactSpelling = true, SetLastError = true)]
        public static extern HMODULE LoadLibrary([MarshalAs(UnmanagedType.LPWStr)][In] string lpLibFileName);

        /// <summary>
        /// <para>
        /// Loads the specified module into the address space of the calling process. The specified module may cause other modules to be loaded.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/libloaderapi/nf-libloaderapi-loadlibraryexw"/>
        /// </para>
        /// </summary>
        /// <param name="lpLibFileName">
        /// A string that specifies the file name of the module to load.
        /// This name is not related to the name stored in a library module itself, as specified by the LIBRARY keyword in the module-definition (.def) file.
        /// The module can be a library module (a .dll file) or an executable module (an .exe file).
        /// If the specified module is an executable module, static imports are not loaded;
        /// instead, the module is loaded as if <see cref="DONT_RESOLVE_DLL_REFERENCES"/> was specified.
        /// See the <paramref name="dwFlags"/> parameter for more information.
        /// If the string specifies a module name without a path and the file name extension is omitted,
        /// the function appends the default library extension .dll to the module name.
        /// To prevent the function from appending .dll to the module name, include a trailing point character (.) in the module name string.
        /// If the string specifies a fully qualified path, the function searches only that path for the module.
        /// When specifying a path, be sure to use backslashes (), not forward slashes (/).
        /// For more information about paths, see Naming Files, Paths, and Namespaces.
        /// If the string specifies a module name without a path and more than one loaded module has the same base name and extension,
        /// the function returns a handle to the module that was loaded first.
        /// If the string specifies a module name without a path and a module of the same name is not already loaded,
        /// or if the string specifies a module name with a relative path, the function searches for the specified module.
        /// The function also searches for modules if loading the specified module causes the system to load other associated modules
        /// (that is, if the module has dependencies). The directories that are searched
        /// and the order in which they are searched depend on the specified path and the <paramref name="dwFlags"/> parameter.
        /// For more information, see Remarks.
        /// If the function cannot find the module or one of its dependencies, the function fails.
        /// </param>
        /// <param name="hFile">
        /// This parameter is reserved for future use. It must be <see cref="NULL"/>.
        /// </param>
        /// <param name="dwFlags">
        /// The action to be taken when loading the module.
        /// If no flags are specified, the behavior of this function is identical to that of the <see cref="LoadLibrary"/> function.
        /// This parameter can be one of the following values.
        /// <see cref="DONT_RESOLVE_DLL_REFERENCES"/>, <see cref="LOAD_IGNORE_CODE_AUTHZ_LEVEL"/>, <see cref="LOAD_LIBRARY_AS_DATAFILE"/>,
        /// <see cref="LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE"/>, <see cref="LOAD_LIBRARY_AS_IMAGE_RESOURCE"/>,
        /// <see cref="LOAD_LIBRARY_SEARCH_APPLICATION_DIR"/>, <see cref="LOAD_LIBRARY_SEARCH_DEFAULT_DIRS"/>,
        /// <see cref="LOAD_LIBRARY_SEARCH_DLL_LOAD_DIR"/>, <see cref="LOAD_LIBRARY_SEARCH_SYSTEM32"/>,
        /// <see cref="LOAD_LIBRARY_SEARCH_USER_DIRS"/>, <see cref="LOAD_WITH_ALTERED_SEARCH_PATH"/>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the loaded module.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="LoadLibraryEx"/> function is very similar to the <see cref="LoadLibrary"/> function.
        /// The differences consist of a set of optional behaviors that <see cref="LoadLibraryEx"/> provides:
        /// <see cref="LoadLibraryEx"/> can load a DLL module without calling the DllMain function of the DLL.
        /// <see cref="LoadLibraryEx"/> can load a module in a way that is optimized for the case where the module will never be executed,
        /// loading the module as if it were a data file.
        /// <see cref="LoadLibraryEx"/> can find modules and their associated modules by using either of two search strategies
        /// or it can search a process-specific set of directories.
        /// You select these optional behaviors by setting the <paramref name="dwFlags"/> parameter;
        /// if <paramref name="dwFlags"/> is zero, <see cref="LoadLibraryEx"/> behaves identically to <see cref="LoadLibrary"/>.
        /// The calling process can use the handle returned by <see cref="LoadLibraryEx"/> to identify the module
        /// in calls to the <see cref="GetProcAddress"/>, <see cref="FindResource"/>, and <see cref="LoadResource"/> functions.
        /// To enable or disable error messages displayed by the loader during DLL loads, use the <see cref="SetErrorMode"/> function.
        /// It is not safe to call <see cref="LoadLibraryEx"/> from DllMain.
        /// For more information, see the Remarks section in DllMain.
        /// Visual C++: The Visual C++ compiler supports a syntax that enables you to declare thread-local variables: _declspec(thread).
        /// If you use this syntax in a DLL, you will not be able to load the DLL explicitly using <see cref="LoadLibraryEx"/>
        /// on versions of Windows prior to Windows Vista.
        /// If your DLL will be loaded explicitly, you must use the thread local storage functions instead of _declspec(thread).
        /// For an example, see Using Thread Local Storage in a Dynamic Link Library.
        /// Loading a DLL as a Data File or Image Resource
        /// The <see cref="LOAD_LIBRARY_AS_DATAFILE"/>, <see cref="LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE"/>,
        /// and <see cref="LOAD_LIBRARY_AS_IMAGE_RESOURCE"/> values affect the per-process reference count and the loading of the specified module.
        /// If any of these values is specified for the dwFlags parameter, the loader checks whether the module was already loaded
        /// by the process as an executable DLL.
        /// If so, this means that the module is already mapped into the virtual address space of the calling process.
        /// In this case, <see cref="LoadLibraryEx"/> returns a handle to the DLL and increments the DLL reference count.
        /// If the DLL module was not already loaded as a DLL, the system maps the module as a data or image file and not as an executable DLL.
        /// In this case, <see cref="LoadLibraryEx"/> returns a handle to the loaded data or image file
        /// but does not increment the reference count for the module and does not make the module visible to functions
        /// such as <see cref="CreateToolhelp32Snapshot"/> or <see cref="EnumProcessModules"/>.
        /// If <see cref="LoadLibraryEx"/> is called twice for the same file with <see cref="LOAD_LIBRARY_AS_DATAFILE"/>,
        /// <see cref="LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE"/>, or <see cref="LOAD_LIBRARY_AS_IMAGE_RESOURCE"/>, two separate mappings are created for the file.
        /// When the <see cref="LOAD_LIBRARY_AS_IMAGE_RESOURCE"/> value is used, the module is loaded as an image
        /// using portable executable (PE) section alignment expansion.
        /// Relative virtual addresses (RVA) do not have to be mapped to disk addresses, so resources can be more quickly retrieved from the module.
        /// Specifying <see cref="LOAD_LIBRARY_AS_IMAGE_RESOURCE"/> prevents other processes from modifying the module while it is loaded.
        /// Unless an application depends on specific image mapping characteristics, the <see cref="LOAD_LIBRARY_AS_IMAGE_RESOURCE"/> value
        /// should be used with either <see cref="LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE"/> or <see cref="LOAD_LIBRARY_AS_DATAFILE"/>.
        /// This allows the loader to choose whether to load the module as an image resource or a data file,
        /// selecting whichever option enables the system to share pages more effectively.
        /// Resource functions such as FindResource can use either mapping.
        /// To determine how a module was loaded, use one of the following macros to test the handle returned by <see cref="LoadLibraryEx"/>.
        /// <code>
        /// #define LDR_IS_DATAFILE(handle)      (((ULONG_PTR)(handle)) &amp;  (ULONG_PTR)1)
        /// #define LDR_IS_IMAGEMAPPING(handle)  (((ULONG_PTR)(handle)) &amp; (ULONG_PTR)2)
        /// #define LDR_IS_RESOURCE(handle)      (LDR_IS_IMAGEMAPPING(handle) || LDR_IS_DATAFILE(handle))
        /// </code>
        /// The following table describes these macros.
        /// LDR_IS_DATAFILE(handle):
        /// If this macro returns <see cref="TRUE"/>, the module was loaded as a data file
        /// (<see cref="LOAD_LIBRARY_AS_DATAFILE"/> or <see cref="LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE"/>).
        /// LDR_IS_IMAGEMAPPING(handle):
        /// If this macro returns <see cref="TRUE"/>, the module was loaded as an image file (<see cref="LOAD_LIBRARY_AS_IMAGE_RESOURCE"/>).
        /// LDR_IS_RESOURCE(handle):
        /// If this macro returns <see cref="TRUE"/>, the module was loaded as either a data file or an image file.
        /// Use the <see cref="FreeLibrary"/> function to free a loaded module, whether or not loading the module caused its reference count to be incremented.
        /// If the module was loaded as a data or image file, the mapping is destroyed but the reference count is not decremented.
        /// Otherwise, the DLL reference count is decremented.
        /// Therefore, it is safe to call <see cref="FreeLibrary"/> with any handle returned by <see cref="LoadLibraryEx"/>.
        /// Searching for DLLs and Dependencies
        /// The search path is the set of directories that are searched for a DLL.
        /// The <see cref="LoadLibraryEx"/> function can search for a DLL using a standard search path or an altered search path,
        /// or it can use a process-specific search path established with the <see cref="SetDefaultDllDirectories"/> and <see cref="AddDllDirectory"/> functions.
        /// For a list of directories and the order in which they are searched, see Dynamic-Link Library Search Order.
        /// The <see cref="LoadLibraryEx"/> function uses the standard search path in the following cases:
        /// The file name is specified without a path and the base file name does not match the base file name of a loaded module,
        /// and none of the LOAD_LIBRARY_SEARCH flags are used.
        /// A path is specified but <see cref="LOAD_WITH_ALTERED_SEARCH_PATH"/> is not used.
        /// The application has not specified a default DLL search path for the process using <see cref="SetDefaultDllDirectories"/>.
        /// If <paramref name="lpLibFileName"/> specifies a relative path, the entire relative path is appended to every token in the DLL search path.
        /// To load a module from a relative path without searching any other path, use <see cref="GetFullPathName"/> to get a nonrelative path
        /// and call <see cref="LoadLibraryEx"/> with the nonrelative path.
        /// If the module is being loaded as a datafile and the relative path starts with "." or "..", the relative path is treated as an absolute path.
        /// If <paramref name="lpLibFileName"/> specifies an absolute path and <paramref name="dwFlags"/>
        /// is set to <see cref="LOAD_WITH_ALTERED_SEARCH_PATH"/>, <see cref="LoadLibraryEx"/> uses the altered search path.
        /// The behavior is undefined when <see cref="LOAD_WITH_ALTERED_SEARCH_PATH"/> flag is set,
        /// and <paramref name="lpLibFileName"/> specifiies a relative path.
        /// The <see cref="SetDllDirectory"/> function can be used to modify the search path.
        /// This solution is better than using <see cref="SetCurrentDirectory"/> or hard-coding the full path to the DLL.
        /// However, be aware that using <see cref="SetDllDirectory"/> effectively disables safe DLL search mode
        /// while the specified directory is in the search path and it is not thread safe.
        /// If possible, it is best to use <see cref="AddDllDirectory"/> to modify a default process search path.
        /// For more information, see Dynamic-Link Library Search Order.
        /// An application can specify the directories to search for a single <see cref="LoadLibraryEx"/> call by using the LOAD_LIBRARY_SEARCH_* flags.
        /// If more than one LOAD_LIBRARY_SEARCH flag is specified, the directories are searched in the following order:
        /// The directory that contains the DLL (<see cref="LOAD_LIBRARY_SEARCH_DLL_LOAD_DIR"/>).
        /// This directory is searched only for dependencies of the DLL to be loaded.
        /// The application directory (<see cref="LOAD_LIBRARY_SEARCH_APPLICATION_DIR"/>).
        /// Paths explicitly added to the application search path with the <see cref="AddDllDirectory"/> function (<see cref="LOAD_LIBRARY_SEARCH_USER_DIRS"/>)
        /// or the <see cref="SetDllDirectory"/> function.
        /// If more than one path has been added, the order in which the paths are searched is unspecified.
        /// The System32 directory (<see cref="LOAD_LIBRARY_SEARCH_SYSTEM32"/>).
        /// Windows 7, Windows Server 2008 R2, Windows Vista and Windows Server 2008:
        /// The LOAD_LIBRARY_SEARCH_ flags are available on systems that have KB2533623 installed.
        /// To determine whether the flags are available, use <see cref="GetProcAddress"/> to get the address of
        /// the <see cref="AddDllDirectory"/>, <see cref="RemoveDllDirectory"/>, or <see cref="SetDefaultDllDirectories"/> function.
        /// If <see cref="GetProcAddress"/> succeeds, the LOAD_LIBRARY_SEARCH_ flags can be used with <see cref="LoadLibraryEx"/>.
        /// If the application has used the <see cref="SetDefaultDllDirectories"/> function to establish a DLL search path
        /// for the process and none of the LOAD_LIBRARY_SEARCH_* flags are used,
        /// the <see cref="LoadLibraryEx"/> function uses the process DLL search path instead of the standard search path.
        /// If a path is specified and there is a redirection file associated with the application,
        /// the <see cref="LoadLibraryEx"/> function searches for the module in the application directory.
        /// If the module exists in the application directory, <see cref="LoadLibraryEx"/> ignores the path specification
        /// and loads the module from the application directory.
        /// If the module does not exist in the application directory, the function loads the module from the specified directory.
        /// For more information, see Dynamic Link Library Redirection.
        /// If you call <see cref="LoadLibraryEx"/> with the name of an assembly without a path specification
        /// and the assembly is listed in the system compatible manifest, the call is automatically redirected to the side-by-side assembly.
        /// Security Remarks
        /// <see cref="LOAD_LIBRARY_AS_DATAFILE"/> does not prevent other processes from modifying the module while it is loaded.
        /// Because this can make your application less secure, you should use <see cref="LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE"/>
        /// instead of <see cref="LOAD_LIBRARY_AS_DATAFILE"/> when loading a module as a data file,
        /// unless you specifically need to use <see cref="LOAD_LIBRARY_AS_DATAFILE"/>.
        /// Specifying <see cref="LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE"/> prevents other processes from modifying the module while it is loaded.
        /// Do not specify <see cref="LOAD_LIBRARY_AS_DATAFILE"/> and <see cref="LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE"/> in the same call.
        /// Do not use the <see cref="SearchPath"/> function to retrieve a path to a DLL for a subsequent <see cref="LoadLibraryEx"/> call.
        /// The <see cref="SearchPath"/> function uses a different search order than <see cref="LoadLibraryEx"/>
        /// and it does not use safe process search mode unless this is explicitly enabled
        /// by calling <see cref="SetSearchPathMode"/> with <see cref="BASE_SEARCH_PATH_ENABLE_SAFE_SEARCHMODE"/>.
        /// Therefore, SearchPath is likely to first search the user’s current working directory for the specified DLL.
        /// If an attacker has copied a malicious version of a DLL into the current working directory,
        /// the path retrieved by <see cref="SearchPath"/> will point to the malicious DLL, which <see cref="LoadLibraryEx"/> will then load.
        /// Do not make assumptions about the operating system version based on a <see cref="LoadLibraryEx"/> call that searches for a DLL.
        /// If the application is running in an environment where the DLL is legitimately not present but a malicious version of the DLL is in the search path,
        /// the malicious version of the DLL may be loaded.
        /// Instead, use the recommended techniques described in Getting the System Version.
        /// For a general discussion of DLL security issues, see Dynamic-Link Library Security.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadLibraryExW", ExactSpelling = true, SetLastError = true)]
        public static extern HMODULE LoadLibraryEx([MarshalAs(UnmanagedType.LPWStr)][In] string lpLibFileName, [In] HANDLE hFile, [In] LoadLibraryExFlags dwFlags);

        /// <summary>
        /// <para>
        /// Loads and executes an application or creates a new instance of an existing application.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-loadmodule"/>
        /// </para>
        /// </summary>
        /// <param name="lpModuleName">
        /// The file name of the application to be run.
        /// When specifying a path, be sure to use backslashes (\), not forward slashes (/).
        /// If the <paramref name="lpModuleName"/> parameter does not contain a directory path, the system searches for the executable file in this order:
        /// The directory from which the application loaded.
        /// The current directory.
        /// The system directory. Use the <see cref="GetSystemDirectory"/> function to get the path of this directory.
        /// The 16-bit system directory. There is no function that obtains the path of this directory, but it is searched.
        /// The name of this directory is System.
        /// The Windows directory. Use the <see cref="GetWindowsDirectory"/> function to get the path of this directory.
        /// The directories that are listed in the PATH environment variable.
        /// </param>
        /// <param name="lpParameterBlock">
        /// A pointer to an application-defined LOADPARMS32 structure that defines the new application's parameter block.
        /// Set all unused members to <see cref="IntPtr.Zero"/>, except for LOADPARMS32.lpCmdLine,
        /// which must point to a null-terminated string if it is not used.
        /// For more information, see Remarks.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is greater than 31.
        /// If the function fails, the return value is an error value, which may be one of the following values.
        /// 0: The system is out of memory or resources.
        /// <see cref="ERROR_BAD_FORMAT"/>: The .exe file is invalid.
        /// <see cref="ERROR_FILE_NOT_FOUND"/>: The specified file was not found.
        /// <see cref="ERROR_PATH_NOT_FOUND"/>: The specified path was not found.
        /// </returns>
        [Obsolete("This function is provided only for compatibility with 16-bit versions of Windows. Applications should use the CreateProcess function.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadModule", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD LoadModule([MarshalAs(UnmanagedType.LPWStr)][In] string lpModuleName, [In] LPVOID lpParameterBlock);

        /// <summary>
        /// <para>
        /// Loads the specified packaged module and its dependencies into the address space of the calling process.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-loadpackagedlibrary"/>
        /// </para>
        /// </summary>
        /// <param name="lpwLibFileName">
        /// The file name of the packaged module to load. The module can be a library module (a .dll file) or an executable module (an .exe file).
        /// If this parameter specifies a module name without a path and the file name extension is omitted,
        /// the function appends the default library extension .dll to the module name.
        /// To prevent the function from appending .dll to the module name, include a trailing point character (.) in the module name string.
        /// If this parameter specifies a path, the function searches that path for the module.
        /// The path cannot be an absolute path or a relative path that contains ".." in the path.
        /// When specifying a path, be sure to use backslashes (), not forward slashes (/).
        /// For more information about paths, see Naming Files, Paths, and Namespaces.
        /// If the specified module is already loaded in the process, the function returns a handle to the loaded module.
        /// The module must have been originally loaded from the package dependency graph of the process.
        /// If loading the specified module causes the system to load other associated modules, the function first searches loaded modules,
        /// then it searches the package dependency graph of the process.
        /// For more information, see Remarks.
        /// </param>
        /// <param name="Reserved">
        /// This parameter is reserved. It must be 0.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the loaded module.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="LoadPackagedLibrary"/> function is a simplified version of <see cref="LoadLibraryEx"/>.
        /// Windows Runtime apps can use <see cref="LoadPackagedLibrary"/> to load packaged modules.
        /// Desktop applications cannot use <see cref="LoadPackagedLibrary"/>;
        /// if a desktop application calls this function it fails with <see cref="APPMODEL_ERROR_NO_PACKAGE"/>.
        /// <see cref="LoadPackagedLibrary"/> returns a handle to the specified module and increments its reference count.
        /// If the module is already loaded, the function returns a handle to the loaded module.
        /// The calling process can use the handle returned by <see cref="LoadPackagedLibrary"/>
        /// to identify the module in calls to the <see cref="GetProcAddress"/> function.
        /// Use the <see cref="FreeLibrary"/> function to free a loaded module and decrement its reference count.
        /// If the function must search for the specified module or its dependencies, it searches only the package dependency graph of the process.
        /// This is the application's package plus any dependencies specified
        /// as &lt;PackageDependency&gt; in the &lt;Dependencies&gt; section of the application's package manifest.
        /// Dependencies are searched in the order they appear in the manifest.
        /// The package dependency graph is specified in the &lt;Dependencies&gt; section of the application's package manifest.
        /// Dependencies are searched in the order they appear in the manifest.
        /// The search proceeds as follows:
        /// The function first searches modules that are already loaded.
        /// If the specified module was originally loaded from the package dependency graph of the process,
        /// the function returns a handle to the loaded module.
        /// If the specified module was not loaded from the package dependency graph of the process, the function returns <see cref="NULL"/>.
        /// If the module is not already loaded, the function searches the package dependency graph of the process.
        /// If the function cannot find the specified module or one of its dependencies, the function fails.
        /// It is not safe to call <see cref="LoadPackagedLibrary"/> from DllMain.
        /// For more information, see the Remarks section in DllMain.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadPackagedLibrary", ExactSpelling = true, SetLastError = true)]
        public static extern HMODULE LoadPackagedLibrary([MarshalAs(UnmanagedType.LPWStr)][In] string lpwLibFileName, [In] DWORD Reserved);

        /// <summary>
        /// <para>
        /// Retrieves information about the first module associated with a process.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/tlhelp32/nf-tlhelp32-module32firstw"/>
        /// </para>
        /// </summary>
        /// <param name="hSnapshot">
        /// A handle to the snapshot returned from a previous call to the <see cref="CreateToolhelp32Snapshot"/> function.
        /// </param>
        /// <param name="lpme">
        /// A pointer to a <see cref="MODULEENTRY32"/> structure.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if the first entry of the module list has been copied to the buffer or <see cref="FALSE"/> otherwise.
        /// The <see cref="ERROR_NO_MORE_FILES"/> error value is returned by the <see cref="GetLastError"/> function
        /// if no modules exist or the snapshot does not contain module information.
        /// </returns>
        /// <remarks>
        /// The calling application must set the <see cref="MODULEENTRY32.dwSize"/> member
        /// of <see cref="MODULEENTRY32"/> to the size, in bytes, of the structure.
        /// To retrieve information about other modules associated with the specified process, use the <see cref="Module32Next"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "Module32FirstW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL Module32First([In] HANDLE hSnapshot, [In][Out] ref MODULEENTRY32 lpme);

        /// <summary>
        /// <para>
        /// Retrieves information about the next module associated with a process or thread.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/tlhelp32/nf-tlhelp32-module32nextw"/>
        /// </para>
        /// </summary>
        /// <param name="hSnapshot">
        /// A handle to the snapshot returned from a previous call to the <see cref="CreateToolhelp32Snapshot"/> function.
        /// </param>
        /// <param name="lpme">
        /// A pointer to a <see cref="MODULEENTRY32"/> structure.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if the next entry of the module list has been copied to the buffer or <see cref="FALSE"/> otherwise.
        /// The <see cref="ERROR_NO_MORE_FILES"/> error value is returned by the <see cref="GetLastError"/> function if no more modules exist.
        /// </returns>
        /// <remarks>
        /// To retrieve information about first module associated with a process, use the <see cref="Module32First"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "Module32NextW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL Module32Next([In] HANDLE hSnapshot, [In][Out] ref MODULEENTRY32 lpme);

        /// <summary>
        /// <para>
        /// Removes a directory that was added to the process DLL search path by using <see cref="AddDllDirectory"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/libloaderapi/nf-libloaderapi-removedlldirectory"/>
        /// </para>
        /// </summary>
        /// <param name="Cookie">
        /// The cookie returned by <see cref="AddDllDirectory"/> when the directory was added to the search path.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// After <see cref="RemoveDllDirectory"/> returns, the cookie is no longer valid and should not be used.
        /// Windows 7, Windows Server 2008 R2, Windows Vista and Windows Server 2008:
        /// To call this function in an application, use the <see cref="GetProcAddress"/> function to retrieve its address from Kernel32.dll.
        /// KB2533623 must be installed on the target platform.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "RemoveDllDirectory", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL RemoveDllDirectory([In] DLL_DIRECTORY_COOKIE Cookie);

        /// <summary>
        /// <para>
        /// Specifies a default set of directories to search when the calling process loads a DLL.
        /// This search path is used when <see cref="LoadLibraryEx"/> is called with no LOAD_LIBRARY_SEARCH flags.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/libloaderapi/nf-libloaderapi-setdefaultdlldirectories"/>
        /// </para>
        /// </summary>
        /// <param name="DirectoryFlags">
        /// The directories to search. This parameter can be any combination of the following values.
        /// <see cref="LOAD_LIBRARY_SEARCH_APPLICATION_DIR"/>:
        /// If this value is used, the application's installation directory is searched.
        /// <see cref="LOAD_LIBRARY_SEARCH_DEFAULT_DIRS"/>:
        /// This value is a combination of <see cref="LOAD_LIBRARY_SEARCH_APPLICATION_DIR"/>,
        /// <see cref="LOAD_LIBRARY_SEARCH_SYSTEM32"/>, and <see cref="LOAD_LIBRARY_SEARCH_USER_DIRS"/>.
        /// This value represents the recommended maximum number of directories an application should include in its DLL search path.
        /// <see cref="LOAD_LIBRARY_SEARCH_SYSTEM32"/>:
        /// If this value is used, %windows%\system32 is searched.
        /// <see cref="LOAD_LIBRARY_SEARCH_USER_DIRS"/>:
        /// If this value is used, any path explicitly added using the <see cref="AddDllDirectory"/> or <see cref="SetDllDirectory"/> function is searched.
        /// If more than one directory has been added, the order in which those directories are searched is unspecified.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The DLL search path is the set of directories that are searched for a DLL when a full path is not specified
        /// in a <see cref="LoadLibrary"/> or <see cref="LoadLibraryEx"/> function call, or when a full path to the DLL is specified
        /// but the system must search for dependent DLLs.
        /// For more information about the standard DLL search path, see Dynamic-Link Library Search Order.
        /// The standard DLL search path contains directories that can be vulnerable to a DLL pre-loading attack.
        /// An application can use the <see cref="SetDefaultDllDirectories"/> function to specify a default DLL search path
        /// for the process that eliminates the most vulnerable directories and limits the other directories that are searched.
        /// The process DLL search path applies only to the calling process and persists for the life of the process.
        /// If the DirectoryFlags parameter specifies more than one flag, the directories are searched in the following order:
        /// The directory that contains the DLL (<see cref="LOAD_LIBRARY_SEARCH_DLL_LOAD_DIR"/>).
        /// This directory is searched only for dependencies of the DLL being loaded.
        /// The application directory (<see cref="LOAD_LIBRARY_SEARCH_APPLICATION_DIR"/>).
        /// Paths explicitly added to the application search path with the <see cref="AddDllDirectory"/> function
        /// (<see cref="LOAD_LIBRARY_SEARCH_USER_DIRS"/>) or the <see cref="SetDllDirectory"/> function.
        /// If more than one path has been added, the order in which the paths are searched is unspecified.
        /// The System directory (<see cref="LOAD_LIBRARY_SEARCH_SYSTEM32"/>).
        /// If <see cref="SetDefaultDllDirectories"/> does not specify <see cref="LOAD_LIBRARY_SEARCH_USER_DIRS"/>,
        /// directories specified with the <see cref="AddDllDirectory"/> function are used only for <see cref="LoadLibraryEx"/> function calls
        /// that specify <see cref="LOAD_LIBRARY_SEARCH_USER_DIRS"/>.
        /// It is not possible to revert to the standard DLL search path or remove any directory
        /// specified with <see cref="SetDefaultDllDirectories"/> from the search path.
        /// However, the process DLL search path can be overridden by calling <see cref="LoadLibraryEx"/> with one or more LOAD_LIBRARY_SEARCH flags,
        /// and directories added with <see cref="AddDllDirectory"/> can be removed by calling <see cref="RemoveDllDirectory"/>.
        /// Windows 7, Windows Server 2008 R2, Windows Vista and Windows Server 2008:
        /// To call this function in an application, use the <see cref="GetProcAddress"/> function to retrieve its address from Kernel32.dll.
        /// KB2533623 must be installed on the target platform.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetDefaultDllDirectories", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetDefaultDllDirectories([In] LoadLibraryExFlags DirectoryFlags);

        /// <summary>
        /// <para>
        /// Adds a directory to the search path used to locate DLLs for the application.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-setdlldirectoryw"/>
        /// </para>
        /// </summary>
        /// <param name="lpPathName">
        /// The directory to be added to the search path.
        /// If this parameter is an empty string (""), the call removes the current directory from the default DLL search order.
        /// If this parameter is <see langword="null"/>, the function restores the default search order.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="SetDllDirectory"/> function affects all subsequent calls to the <see cref="LoadLibrary"/> and <see cref="LoadLibraryEx"/> functions.
        /// It also effectively disables safe DLL search mode while the specified directory is in the search path.
        /// After calling <see cref="SetDllDirectory"/>, the standard DLL search path is:
        /// The directory from which the application loaded.
        /// The directory specified by the <paramref name="lpPathName"/> parameter.
        /// The system directory. Use the GetSystemDirectory function to get the path of this directory. The name of this directory is System32.
        /// The 16-bit system directory. There is no function that obtains the path of this directory, but it is searched.
        /// The name of this directory is System.
        /// The Windows directory. Use the <see cref="GetWindowsDirectory"/> function to get the path of this directory.
        /// The directories that are listed in the PATH environment variable.
        /// Each time the <see cref="SetDllDirectory"/> function is called,
        /// it replaces the directory specified in the previous <see cref="SetDllDirectory"/> call.
        /// To specify more than one directory, use the <see cref="AddDllDirectory"/> function
        /// and call <see cref="LoadLibraryEx"/> with <see cref="LOAD_LIBRARY_SEARCH_USER_DIRS"/>.
        /// To revert to the standard search path used by <see cref="LoadLibrary"/> and <see cref="LoadLibraryEx"/>,
        /// call <see cref="SetDllDirectory"/> with <see langword="null"/>.
        /// This also restores safe DLL search mode based on the SafeDllSearchMode registry value.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0502 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetDllDirectoryW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetDllDirectory([MarshalAs(UnmanagedType.LPWStr)][In] string lpPathName);
    }
}
