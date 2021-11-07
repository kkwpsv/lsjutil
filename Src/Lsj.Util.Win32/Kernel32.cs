using Lsj.Util.IL;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Enums.CodePages;
using static Lsj.Util.Win32.Enums.EnumSystemCodePagesFlags;
using static Lsj.Util.Win32.Enums.LoadLibraryExFlags;
using static Lsj.Util.Win32.Enums.SYSNLS_FUNCTION;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Kernel32.dll
    /// </summary>
    public static partial class Kernel32
    {
        /// <summary>
        /// NUMA_NO_PREFERRED_NODE
        /// </summary>
        public const uint NUMA_NO_PREFERRED_NODE = 0xffffffff;

        /// <summary>
        /// <para>
        /// An application-defined callback function that processes enumerated code page information
        /// provided by the <see cref="EnumSystemCodePages"/> function.
        /// The <see cref="CODEPAGE_ENUMPROC"/> type defines a pointer to this callback function.
        /// EnumCodePagesProc is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/previous-versions/windows/desktop/legacy/dd317809(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="lpCodePageString">
        /// Pointer to a buffer containing a null-terminated code page identifier string.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> to continue enumeration or <see cref="FALSE"/> otherwise.
        /// </returns>
        /// <remarks>
        /// An EnumCodePagesProc function can carry out any desired task.
        /// The application registers this function by passing its address to the <see cref="EnumSystemCodePages"/> function.
        /// When an application is using this function to determine an appropriate code page for saving data, it should use Unicode when possible.
        /// Other code pages are not as portable as Unicode between vendors or operating systems,
        /// due to different implementations of the associated standards.
        /// </remarks>
        public delegate BOOL Codepageenumproc([In] LPWSTR lpCodePageString);


        /// <summary>
        /// <para>
        /// Generates simple tones on the speaker.
        /// The function is synchronous; it performs an alertable wait and does not return control to its caller until the sound finishes.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/utilapiset/nf-utilapiset-beep"/>
        /// </para>
        /// </summary>
        /// <param name="dwFreq">
        /// The frequency of the sound, in hertz. This parameter must be in the range 37 through 32,767 (0x25 through 0x7FFF).
        /// </param>
        /// <param name="dwDuration">
        /// The duration of the sound, in milliseconds.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// A long time ago, all PC computers shared a common 8254 programable interval timer chip for the generation of primitive sounds.
        /// The <see cref="Beep"/> function was written specifically to emit a beep on that piece of hardware.
        /// On these older systems, muting and volume controls have no effect on <see cref="Beep"/>; you would still hear the tone.
        /// To silence the tone, you used the following commands:
        /// net stop beep
        /// sc config beep start= disabled
        /// Since then, sound cards have become standard equipment on almost all PC computers.
        /// As sound cards became more common, manufacturers began to remove the old timer chip from computers.
        /// The chips were also excluded from the design of server computers.
        /// The result is that <see cref="Beep"/> did not work on all computers without the chip.
        /// This was okay because most developers had moved on to calling the <see cref="MessageBeep"/> function
        /// that uses whatever is the default sound device instead of the 8254 chip.
        /// Eventually because of the lack of hardware to communicate with,
        /// support for <see cref="Beep"/> was dropped in Windows Vista and Windows XP 64-Bit Edition.
        /// In Windows 7, <see cref="Beep"/> was rewritten to pass the beep to the default sound device for the session.
        /// This is normally the sound card, except when run under Terminal Services, in which case the beep is rendered on the client.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "Beep", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL Beep([In] DWORD dwFreq, [In] DWORD dwDuration);

        /// <summary>
        /// <para>
        /// Retrieves a pointer to the preceding character in a string.
        /// This function can handle strings consisting of either single- or multi-byte characters.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-charprevw"/>
        /// </para>
        /// </summary>
        /// <param name="lpszStart">
        /// The beginning of the string.
        /// </param>
        /// <param name="lpszCurrent">
        /// A character in a null-terminated string.
        /// </param>
        /// <returns>
        /// The return value is a pointer to the preceding character in the string,
        /// or to the first character in the string if the <paramref name="lpszCurrent"/> parameter equals the <paramref name="lpszStart"/> parameter.
        /// </returns>
        /// <remarks>
        /// This function works with default "user" expectations of characters when dealing with diacritics.
        /// For example: A string that contains U+0061 U+030a "LATIN SMALL LETTER A" + COMBINING RING ABOVE" — which looks like "å",
        /// will advance two code points, not one.
        /// A string that contains U+0061 U+0301 U+0302 U+0303 U+0304 — which looks like "a´^~¯", will advance five code points, not one, and so on.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CharPrevW", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr CharPrev([In] IntPtr lpszStart, [In] IntPtr lpszCurrent);

        /// <summary>
        /// <para>
        /// Retrieves the pointer to the preceding character in a string.
        /// This function can handle strings consisting of either single- or multi-byte characters.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-charprevexa"/>
        /// </para>
        /// </summary>
        /// <param name="CodePage">
        /// The identifier of the code page to use to check lead-byte ranges.
        /// Can be one of the code-page values provided in Code Page Identifiers, or one of the following predefined values.
        /// <see cref="CP_ACP"/>: Use system default ANSI code page.
        /// <see cref="CP_MACCP"/>: Use the system default Macintosh code page.
        /// <see cref="CP_OEMCP"/>: Use system default OEM code page.
        /// </param>
        /// <param name="lpStart">
        /// The beginning of the string.
        /// </param>
        /// <param name="lpCurrentChar">
        /// A character in a null-terminated string.
        /// </param>
        /// <param name="dwFlags">
        /// This parameter is reserved and must be zero.
        /// </param>
        /// <returns>
        /// The return value is a pointer to the preceding character in the string,
        /// or to the first character in the string if the <paramref name="lpCurrentChar"/> parameter equals the <paramref name="lpStart"/> parameter.
        /// </returns>
        /// <remarks>
        /// <see cref="CharPrevExA"/> specifies a code-page to use, whereas <see cref="CharPrev"/> (if called as an ANSI function) uses the system default code-page.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CharPrevExA", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr CharPrevExA([In] WORD CodePage, [In] IntPtr lpStart, [In] IntPtr lpCurrentChar, [In] DWORD dwFlags);

        /// <summary>
        /// <para>
        /// Enumerates the code pages that are either installed on or supported by an operating system.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-enumsystemcodepagesw"/>
        /// </para>
        /// </summary>
        /// <param name="lpCodePageEnumProc">
        /// Pointer to an application-defined callback function.
        /// The <see cref="EnumSystemCodePages"/> function enumerates code pages by making repeated calls to this callback function.
        /// For more information, see <see cref="CODEPAGE_ENUMPROC"/>.
        /// </param>
        /// <param name="dwFlags">
        /// Flag specifying the code pages to enumerate.
        /// This parameter can have one of the following values, which are mutually exclusive.
        /// <see cref="CP_INSTALLED"/>: Enumerate only installed code pages.
        /// <see cref="CP_SUPPORTED"/>: Enumerate all supported code pages.
        /// </param>
        /// <returns>
        /// Returns a nonzero value if successful, or 0 otherwise.
        /// To get extended error information, the application can call <see cref="GetLastError"/>,
        /// which can return one of the following error codes:
        /// <see cref="ERROR_BADDB"/>:
        /// The function could not access the data.
        /// This situation should not normally occur, and typically indicates a bad installation, a disk problem, or the like.
        /// <see cref="ERROR_INVALID_FLAGS"/>:
        /// The values supplied for flags were not valid.
        /// <see cref="ERROR_INVALID_PARAMETER"/>:
        /// Any of the parameter values was invalid.
        /// </returns>
        /// <remarks>
        /// This function enumerates the code pages by passing code page identifiers, one at a time,
        /// to the specified application-defined callback function.
        /// This process continues until all installed or supported code page identifiers have been passed to the callback function,
        /// or the callback function returns <see cref="FALSE"/>.
        /// When an application is using this function to determine an appropriate code page for saving data, it should use Unicode when possible.
        /// Other code pages are not as portable as Unicode between vendors or operating systems,
        /// due to different implementations of the associated standards.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumSystemCodePagesW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnumSystemCodePages([In] CODEPAGE_ENUMPROC lpCodePageEnumProc, [In] EnumSystemCodePagesFlags dwFlags);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpProc"></param>
        [Obsolete]
        public static void FreeProcInstance(FARPROC lpProc)
        {
        }

        /// <summary>
        /// <para>
        /// Retrieves information about any valid installed or available code page.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-getcpinfoexw"/>
        /// </para>
        /// </summary>
        /// <param name="CodePage">
        /// Identifier for the code page for which to retrieve information.
        /// The application can specify the code page identifier for any installed or available code page, or one of the following predefined values.
        /// See Code Page Identifiers for a list of identifiers for ANSI and other code pages.
        /// <see cref="CP_ACP"/>: Use the system default Windows ANSI code page.
        /// <see cref="CP_MACCP"/>: Use the system default Macintosh code page.
        /// <see cref="CP_OEMCP"/>: Use the system default OEM code page.
        /// <see cref="CP_THREAD_ACP"/>: Use the current thread's ANSI code page.
        /// </param>
        /// <param name="dwFlags">
        /// Reserved; must be 0.
        /// </param>
        /// <param name="lpCPInfoEx">
        /// Pointer to a <see cref="CPINFOEX"/> structure that receives information about the code page.
        /// </param>
        /// <returns>
        /// Returns a nonzero value if successful, or 0 otherwise.
        /// To get extended error information, the application can call <see cref="GetLastError"/>,
        /// which can return one of the following error codes:
        /// <see cref="ERROR_INVALID_PARAMETER"/>: Any of the parameter values was invalid.
        /// </returns>
        /// <remarks>
        /// The information retrieved in the <see cref="CPINFOEX"/> structure is not always useful for all code pages.
        /// To determine buffer sizes, for example, the application should call <see cref="MultiByteToWideChar"/>
        /// or <see cref="WideCharToMultiByte"/> to request an accurate buffer size.
        /// If <see cref="CPINFOEX"/> settings indicate that a lead byte exists,
        /// the conversion function does not necessarily handle lead bytes differently,
        /// for example, in the case of a missing or illegal trail byte.
        /// Note
        /// The winnls.h header defines <see cref="GetCPInfoEx"/> as an alias which automatically
        /// selects the ANSI or Unicode version of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead to mismatches
        /// that result in compilation or runtime errors.
        /// For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCPInfoExW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetCPInfoEx([In] CodePages CodePage, [In] DWORD dwFlags, [Out] out CPINFOEX lpCPInfoEx);

        /// <summary>
        /// <para>
        /// Retrieves information about the current version of a specified NLS capability for a locale specified by name.
        /// Note
        /// The application should call this function in preference to <see cref="GetNLSVersion"/> if designed to run only on Windows Vista and later.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-getnlsversionex"/>
        /// </para>
        /// </summary>
        /// <param name="function">
        /// The NLS capability to query.
        /// This value must be <see cref="COMPARE_STRING"/>.
        /// See the <see cref="SYSNLS_FUNCTION"/> enumeration.
        /// </param>
        /// <param name="lpLocaleName">
        /// Pointer to a locale name, or one of the following predefined values.
        /// <see cref="LOCALE_NAME_INVARIANT"/>, <see cref="LOCALE_NAME_SYSTEM_DEFAULT"/>, <see cref="LOCALE_NAME_USER_DEFAULT"/>
        /// </param>
        /// <param name="lpVersionInformation">
        /// Pointer to an <see cref="NLSVERSIONINFOEX"/> structure.
        /// The application must initialize the <see cref="NLSVERSIONINFOEX.dwNLSVersionInfoSize"/> member to <code>sizeof(NLSVERSIONINFOEX)</code>.
        /// Note
        /// On Windows Vista and later, the function can alternatively provide version information in an <see cref="NLSVERSIONINFO"/> structure.
        /// </param>
        /// <returns></returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetNLSVersionEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetNLSVersionEx([In] SYSNLS_FUNCTION function, [MarshalAs(UnmanagedType.LPWStr)][In] string lpLocaleName,
            [In] in NLSVERSIONINFOEX lpVersionInformation);

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
        /// The <see cref="LoadLibrary"/>, <see cref="LoadLibraryEx"/>, <see cref="LoadPackagedLibrary"/>,
        /// or <see cref="GetModuleHandle"/> function returns this handle.
        /// The <see cref="GetProcAddress"/> function does not retrieve addresses from modules
        /// that were loaded using the <see cref="LOAD_LIBRARY_AS_DATAFILE"/> flag.
        /// For more information, see <see cref="LoadLibraryEx"/>.
        /// </param>
        /// <param name="lpProcName">
        /// The function or variable name, or the function's ordinal value.
        /// If this parameter is an ordinal value, it must be in the low-order word; the high-order word must be zero.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the address of the exported function or variable.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The spelling and case of a function name pointed to by <paramref name="lpProcName"/> must be identical to that
        /// in the EXPORTS statement of the source DLL's module-definition (.def) file.
        /// The exported names of functions may differ from the names you use when calling these functions in your code.
        /// This difference is hidden by macros used in the SDK header files.
        /// For more information, see Conventions for Function Prototypes.
        /// The <paramref name="lpProcName"/> parameter can identify the DLL function by specifying an ordinal value
        /// associated with the function in the EXPORTS statement.
        /// <see cref="GetProcAddress"/> verifies that the specified ordinal is in the range 1 through the highest ordinal value exported in the .def file.
        /// The function then uses the ordinal as an index to read the function's address from a function table.
        /// If the .def file does not number the functions consecutively from 1 to N (where N is the number of exported functions),
        /// an error can occur where <see cref="GetProcAddress"/> returns an invalid, non-NULL address,
        /// even though there is no function with the specified ordinal.
        /// If the function might not exist in the DLL module—for example, if the function is available only on Windows Vista
        /// but the application might be running on Windows XP—specify the function by name rather than by ordinal value
        /// and design your application to handle the case when the function is not available, as shown in the following code fragment.
        /// <code>
        /// typedef void (WINAPI *PGNSI)(LPSYSTEM_INFO);
        /// // Call GetNativeSystemInfo if supported or GetSystemInfo otherwise.
        /// PGNSI pGNSI;
        /// SYSTEM_INFO si;
        /// ZeroMemory(&amp;si, sizeof(SYSTEM_INFO));
        /// pGNSI = (PGNSI) GetProcAddress(GetModuleHandle(TEXT("kernel32.dll")), "GetNativeSystemInfo");
        /// if(NULL != pGNSI)
        /// {
        ///     pGNSI(&amp;si);
        /// }
        /// else 
        /// {
        ///     GetSystemInfo(&amp;si);
        /// }
        /// </code>
        /// For the complete example that contains this code fragment, see Getting the System Version.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetProcAddress", ExactSpelling = true, SetLastError = true, ThrowOnUnmappableChar = true)]
        public static extern FARPROC GetProcAddress([In] HMODULE hModule, [MarshalAs(UnmanagedType.LPStr)][In] string lpProcName);

        /// <summary>
        /// <para>
        /// Determines whether the calling process has read access to the memory at the specified address.
        /// Important
        /// This function is obsolete and should not be used. Despite its name,
        /// it does not guarantee that the pointer is valid or that the memory pointed to is safe to use.
        /// For more information, see Remarks on this page.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-isbadcodeptr"/>
        /// </para>
        /// </summary>
        /// <param name="lpfn">
        /// A pointer to a memory address.
        /// </param>
        /// <returns>
        /// If the calling process has read access to the specified memory, the return value is <see cref="FALSE"/>.
        /// If the calling process does not have read access to the specified memory, the return value is <see cref="TRUE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If the application is compiled as a debugging version, and the process does not have read access to the specified memory location,
        /// the function causes an assertion and breaks into the debugger.
        /// Leaving the debugger, the function continues as usual, and returns a <see cref="FALSE"/> value.
        /// This behavior is by design, as a debugging aid.
        /// </returns>
        /// <remarks>
        /// In a preemptive multitasking environment, it is possible for some other thread to change the process's access to the memory being tested.
        /// Even when the function indicates that the process has read access to the specified memory,
        /// you should use structured exception handling when attempting to access the memory.
        /// Use of structured exception handling enables the system to notify the process if an access violation exception occurs,
        /// giving the process an opportunity to handle the exception.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsBadCodePtr", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsBadCodePtr([In] FARPROC lpfn);

        /// <summary>
        /// <para>
        /// Verifies that the calling process has read access to the specified range of memory.
        /// Important This function is obsolete and should not be used.
        /// Despite its name, it does not guarantee that the pointer is valid or that the memory pointed to is safe to use.
        /// For more information, see Remarks on this page.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-isbadreadptr"/>
        /// </para>
        /// </summary>
        /// <param name="lp">
        /// A pointer to the first byte of the memory block.
        /// </param>
        /// <param name="ucb">
        /// The size of the memory block, in bytes.
        /// If this parameter is zero, the return value is <see cref="BOOL.FALSE"/>.
        /// </param>
        /// <returns>
        /// If the calling process has read access to all bytes in the specified memory range, the return value is <see cref="BOOL.FALSE"/>.
        /// If the calling process does not have read access to all bytes in the specified memory range, the return value is <see cref="BOOL.TRUE"/>.
        /// If the application is compiled as a debugging version, and the process does not have read access to all bytes in the specified memory range,
        /// the function causes an assertion and breaks into the debugger.
        /// Leaving the debugger, the function continues as usual, and returns a <see cref="BOOL.TRUE"/> value.
        /// This behavior is by design, as a debugging aid.
        /// </returns>
        /// <remarks>
        /// This function is typically used when working with pointers returned from third-party libraries,
        /// where you cannot determine the memory management behavior in the third-party DLL.
        /// Threads in a process are expected to cooperate in such a way that one will not free memory that the other needs.
        /// Use of this function does not negate the need to do this.
        /// If this is not done, the application may fail in an unpredictable manner.
        /// Dereferencing potentially invalid pointers can disable stack expansion in other threads.
        /// A thread exhausting its stack, when stack expansion has been disabled, results in the immediate termination of the parent process,
        /// with no pop-up error window or diagnostic information.
        /// If the calling process has read access to some, but not all, of the bytes in the specified memory range,
        /// the return value is <see cref="BOOL.TRUE"/>.
        /// In a preemptive multitasking environment, it is possible for some other thread to change the process's access to the memory being tested.
        /// Even when the function indicates that the process has read access to the specified memory,
        /// you should use structured exception handling when attempting to access the memory.
        /// Use of structured exception handling enables the system to notify the process if an access violation exception occurs,
        /// giving the process an opportunity to handle the exception.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsBadReadPtr", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsBadReadPtr([In] IntPtr lp, [In] UINT_PTR ucb);

        /// <summary>
        /// <para>
        /// Verifies that the calling process has read access to the specified range of memory.
        /// Important
        /// This function is obsolete and should not be used. Despite its name,
        /// it does not guarantee that the pointer is valid or that the memory pointed to is safe to use.
        /// For more information, see Remarks on this page.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-isbadstringptrw"/>
        /// </para>
        /// </summary>
        /// <param name="lpsz">
        /// A pointer to a null-terminated string, either Unicode or ASCII.
        /// </param>
        /// <param name="ucchMax">
        /// The maximum size of the string, in TCHARs.
        /// The function checks for read access in all characters up to the string's terminating null character or
        /// up to the number of characters specified by this parameter, whichever is smaller.
        /// If this parameter is zero, the return value is <see cref="BOOL.FALSE"/>.
        /// </param>
        /// <returns>
        /// If the calling process has read access to all characters up to the string's terminating null character
        /// or up to the number of characters specified by <paramref name="ucchMax"/>, the return value is <see cref="BOOL.FALSE"/>.
        /// If the calling process does not have read access to all characters up to the string's terminating null character
        /// or up to the number of characters specified by <paramref name="ucchMax"/>, the return value is <see cref="BOOL.TRUE"/>.
        /// If the application is compiled as a debugging version, and the process does not have read access to the entire memory range specified,
        /// the function causes an assertion and breaks into the debugger.
        /// Leaving the debugger, the function continues as usual, and returns a <see cref="BOOL.FALSE"/> value This behavior is by design,
        /// as a debugging aid.
        /// </returns>
        /// <remarks>
        /// This function is typically used when working with pointers returned from third-party libraries,
        /// where you cannot determine the memory management behavior in the third-party DLL.
        /// Threads in a process are expected to cooperate in such a way that one will not free memory that the other needs.
        /// Use of this function does not negate the need to do this.
        /// If this is not done, the application may fail in an unpredictable manner.
        /// Dereferencing potentially invalid pointers can disable stack expansion in other threads.
        /// A thread exhausting its stack, when stack expansion has been disabled, results in the immediate termination of the parent process,
        /// with no pop-up error window or diagnostic information.
        /// If the calling process has read access to some, but not all, of the specified memory range, the return value is <see cref="BOOL.FALSE"/>.
        /// In a preemptive multitasking environment, it is possible for some other thread to change the process's access to the memory being tested.
        /// Even when the function indicates that the process has read access to the specified memory,
        /// you should use structured exception handling when attempting to access the memory.
        /// Use of structured exception handling enables the system to notify the process if an access violation exception occurs,
        /// giving the process an opportunity to handle the exception.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsBadStringPtrW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsBadStringPtr([In] IntPtr lpsz, UINT_PTR ucchMax);

        /// <summary>
        /// <para>
        /// Verifies that the calling process has write access to the specified range of memory.
        /// Important This function is obsolete and should not be used. Despite its name,
        /// it does not guarantee that the pointer is valid or that the memory pointed to is safe to use.
        /// For more information, see Remarks on this page.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-isbadwriteptr"/>
        /// </para>
        /// </summary>
        /// <param name="lp">
        /// A pointer to the first byte of the memory block.
        /// </param>
        /// <param name="ucb">
        /// The size of the memory block, in bytes. If this parameter is zero, the return value is <see cref="BOOL.FALSE"/>.
        /// </param>
        /// <returns>
        /// If the calling process has write access to all bytes in the specified memory range, the return value is <see cref="BOOL.FALSE"/>.
        /// If the calling process does not have write access to all bytes in the specified memory range, the return value is <see cref="BOOL.TRUE"/>.
        /// If the application is run under a debugger and the process does not have write access to all bytes in the specified memory range,
        /// the function causes a first chance STATUS_ACCESS_VIOLATION exception.
        /// The debugger can be configured to break for this condition.
        /// After resuming process execution in the debugger, the function continues as usual and returns a <see cref="BOOL.TRUE"/> value.
        /// This behavior is by design and serves as a debugging aid.
        /// </returns>
        /// <remarks>
        /// This function is typically used when working with pointers returned from third-party libraries,
        /// where you cannot determine the memory management behavior in the third-party DLL.
        /// Threads in a process are expected to cooperate in such a way that one will not free memory that the other needs.
        /// Use of this function does not negate the need to do this. If this is not done, the application may fail in an unpredictable manner.
        /// Dereferencing potentially invalid pointers can disable stack expansion in other threads. A thread exhausting its stack,
        /// when stack expansion has been disabled, results in the immediate termination of the parent process,
        /// with no pop-up error window or diagnostic information.
        /// If the calling process has write access to some, but not all, of the bytes in the specified memory range,
        /// the return value is <see cref="BOOL.TRUE"/>.
        /// In a preemptive multitasking environment, it is possible for some other thread to change the process's access to the memory being tested.
        /// Even when the function indicates that the process has write access to the specified memory,
        /// you should use structured exception handling when attempting to access the memory.
        /// Use of structured exception handling enables the system to notify the process if an access violation exception occurs,
        /// giving the process an opportunity to handle the exception.
        /// <see cref="IsBadWritePtr"/> is not multithread safe. To use it properly on a pointer shared by multiple threads,
        /// call it inside a critical region of code that allows only one thread to access the memory being checked.
        /// Use operating system–level objects such as critical sections or mutexes or the interlocked functions to create the critical region of code.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsBadReadPtr", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsBadWritePtr([In] LPVOID lp, [In] UINT_PTR ucb);

        /// <summary>
        /// <para>
        /// Determines if a specified character is a lead byte for the system default Windows ANSI code page (<see cref="CP_ACP"/>).
        /// A lead byte is the first byte of a two-byte character in a double-byte character set (DBCS) for the code page.
        /// To use a different code page, your application should use the <see cref="IsDBCSLeadByteEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-isdbcsleadbyte"/>
        /// </para>
        /// </summary>
        /// <param name="TestChar">
        /// The character to test.
        /// </param>
        /// <returns>
        /// Returns a <see cref="TRUE"/> value if the test character is potentially a lead byte.
        /// The function returns <see cref="FALSE"/> if the test character is not a lead byte or if it is a single-byte character.
        /// To get extended error information, the application can call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// This function does not validate the presence or validity of a trail byte.
        /// Therefore, <see cref="MultiByteToWideChar"/> might not recognize a sequence that the application
        /// using <see cref="IsDBCSLeadByte"/> reports as a lead byte.
        /// The application can easily become unsynchronized with the results of <see cref="MultiByteToWideChar"/>,
        /// potentially leading to unexpected errors or buffer size mismatches.
        /// In general, instead of attempting low-level manipulation of code page data,
        /// applications should use <see cref="MultiByteToWideChar"/> to convert the data to UTF-16 and work with it in that encoding.
        /// Lead byte values are specific to each distinct DBCS.
        /// Some byte values can appear in a single code page as both the lead and trail byte of a DBCS character.
        /// To make sense of a DBCS string, an application normally starts at the beginning of a string and scans forward,
        /// keeping track when it encounters a lead byte, and treating the next byte as the trailing part of the same character.
        /// If the application must back up, it should use <see cref="CharPrev"/> instead of attempting to develop its own algorithm.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsDBCSLeadByte", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsDBCSLeadByte([In] BYTE TestChar);

        /// <summary>
        /// <para>
        /// Determines if a specified character is potentially a lead byte.
        /// A lead byte is the first byte of a two-byte character in a double-byte character set (DBCS) for the code page.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-isdbcsleadbyteex"/>
        /// </para>
        /// </summary>
        /// <param name="CodePage">
        /// Identifier of the code page used to check lead byte ranges.
        /// This parameter can be one of the code page identifiers defined in Unicode and Character Set Constants
        /// or one of the following predefined values.
        /// This function validates lead byte values only in code pages 932, 936, 949, 950, and 1361.
        /// <see cref="CP_ACP"/>: Use system default Windows ANSI code page.
        /// <see cref="CP_MACCP"/>: Use the system default Macintosh code page.
        /// <see cref="CP_OEMCP"/>: Use system default OEM code page.
        /// <see cref="CP_THREAD_ACP"/>: Use the Windows ANSI code page for the current thread. 
        /// </param>
        /// <param name="TestChar">
        /// The character to test.
        /// </param>
        /// <returns>
        /// Returns a nonzero value if the byte is a lead byte.
        /// The function returns 0 if the byte is not a lead byte or if the character is a single-byte character.
        /// To get extended error information, the application can call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Note
        /// This function does not validate the presence or validity of a trail byte.
        /// Therefore, <see cref="MultiByteToWideChar"/> might not recognize a sequence
        /// that the application using <see cref="IsDBCSLeadByte"/> reports as a lead byte.
        /// The application can easily become unsynchronized with the results of <see cref="MultiByteToWideChar"/>,
        /// potentially leading to unexpected errors or buffer size mismatches.
        /// In general, instead of attempting low-level manipulation of code page data,
        /// applications should use <see cref="MultiByteToWideChar"/> to convert the data to UTF-16 and work with it in that encoding.
        /// Lead byte values are specific to each distinct DBCS.
        /// Some byte values can appear in a single code page as both the lead and trail byte of a DBCS character.
        /// Thus, <see cref="IsDBCSLeadByteEx"/> can only indicate a potential lead byte value.
        /// To make sense of a DBCS string, an application normally starts at the beginning of the string and scans forward,
        /// keeping track when it encounters a lead byte, and treating the next byte as the trailing part of the same character.
        /// To back up, the application should use <see cref="CharPrevExA"/> instead of attempting to develop its own algorithm.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsDBCSLeadByteEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsDBCSLeadByteEx([In] UINT CodePage, [In] BYTE TestChar);

        /// <summary>
        /// <para>
        /// Determines if a specified code page is valid.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-isvalidcodepage"/>
        /// </para>
        /// </summary>
        /// <param name="CodePage">
        /// Code page identifier for the code page to check.
        /// </param>
        /// <returns>
        /// Returns a <see cref="TRUE"/> value if the code page is valid, or <see cref="FALSE"/> if the code page is invalid.
        /// </returns>
        /// <remarks>
        /// A code page is considered valid only if it is installed on the operating system. Unicode is preferred.
        /// Starting with Windows Vista, all code pages that can be installed are loaded by default.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsValidCodePage", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsValidCodePage([In] UINT CodePage);

        /// <summary>
        /// MakeProcInstance
        /// </summary>
        /// <param name="lpProc"></param>
        /// <param name="hInstance"></param>
        /// <returns></returns>
        [Obsolete]
        public static FARPROC MakeProcInstance(FARPROC lpProc, HINSTANCE hInstance) => lpProc;

        /// <summary>
        /// <para>
        /// Multiplies two 32-bit values and then divides the 64-bit result by a third 32-bit value. The final result is rounded to the nearest integer.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-muldiv"/>
        /// </para>
        /// </summary>
        /// <param name="nNumber">
        /// The multiplicand.
        /// </param>
        /// <param name="nNumerator">
        /// The multiplier.
        /// </param>
        /// <param name="nDenominator">
        /// The number by which the result of the multiplication operation is to be divided.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the result of the multiplication and division, rounded to the nearest integer.
        /// If the result is a positive half integer (ends in .5), it is rounded up.
        /// If the result is a negative half integer, it is rounded down.
        /// If either an overflow occurred or nDenominator was 0, the return value is -1.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "MulDiv", ExactSpelling = true, SetLastError = true)]
        public static extern int MulDiv([In] int nNumber, [In] int nNumerator, [In] int nDenominator);

        /// <summary>
        /// <para>
        /// Retrieves the current value of the performance counter, which is a high resolution (&lt;1us) time stamp
        /// that can be used for time-interval measurements.
        /// </para>
        /// <para>
        /// https://docs.microsoft.com/zh-cn/windows/win32/api/profileapi/nf-profileapi-queryperformancecounter
        /// </para>
        /// </summary>
        /// <param name="lpPerformanceCount">
        /// A pointer to a variable that receives the current performance-counter value, in counts.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// On systems that run Windows XP or later, the function will always succeed and will thus never return zero.
        /// </returns>
        /// <remarks>
        /// For more info about this function and its usage, see Acquiring high-resolution time stamps.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "QueryPerformanceCounter", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL QueryPerformanceCounter([Out] out LARGE_INTEGER lpPerformanceCount);

        /// <summary>
        /// <para>
        /// Retrieves the frequency of the performance counter.
        /// The frequency of the performance counter is fixed at system boot and is consistent across all processors.
        /// Therefore, the frequency need only be queried upon application initialization, and the result can be cached.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/profileapi/nf-profileapi-queryperformancefrequency"/>
        /// </para>
        /// </summary>
        /// <param name="lpFrequency">
        /// A pointer to a variable that receives the current performance-counter frequency, in counts per second.
        /// If the installed hardware doesn't support a high-resolution performance counter, this parameter can be zero
        /// (this will not occur on systems that run Windows XP or later).
        /// </param>
        /// <returns>
        /// If the installed hardware supports a high-resolution performance counter, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// On systems that run Windows XP or later, the function will always succeed and will thus never return zero.
        /// </returns>
        /// <remarks>
        /// For more info about this function and its usage, see Acquiring high-resolution time stamps.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "QueryPerformanceFrequency", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL QueryPerformanceFrequency([Out] out LARGE_INTEGER lpFrequency);

        /// <summary>
        /// <para>
        /// Fills a block of memory with zeros. It is designed to be a more secure version of <see cref="ZeroMemory"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/previous-versions/windows/desktop/legacy/aa366920%28v%3dvs.85%29"/>
        /// </para>
        /// </summary>
        /// <param name="dest">
        /// A pointer to the starting address of the block of memory to fill with zeros.
        /// </param>
        /// <param name="size">
        /// The size of the block of memory to fill with zeros, in bytes.
        /// </param>
        /// <remarks>
        /// Many programming languages include syntax for initializing complex variables to zero.
        /// There can be differences between the results of these operations and the <see cref="ZeroMemory"/> function.
        /// Use <see cref="ZeroMemory"/> to clear a block of memory in any programming language.
        /// This macro is defined as the RtlZeroMemory macro.
        /// For more information, see WinBase.h and WinNT.h.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "RtlSecureZeroMemory", ExactSpelling = true, SetLastError = true)]
        public static extern void SecureZeroMemory([In] PVOID dest, [In] SIZE_T size);

        /// <summary>
        /// <para>
        /// Runs the specified application.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-winexec"/>
        /// </para>
        /// </summary>
        /// <param name="lpCmdLine">
        /// The command line (file name plus optional parameters) for the application to be executed.
        /// If the name of the executable file in the <paramref name="lpCmdLine"/> parameter does not contain a directory path,
        /// the system searches for the executable file in this sequence:
        /// The directory from which the application loaded.
        /// The current directory.
        /// The Windows system directory. The <see cref="GetSystemDirectory"/> function retrieves the path of this directory.
        /// The Windows directory. The <see cref="GetWindowsDirectory"/> function retrieves the path of this directory.
        /// The directories listed in the PATH environment variable.
        /// </param>
        /// <param name="uCmdShow">
        /// The display options.
        /// For a list of the acceptable values, see the description of the nCmdShow parameter of the <see cref="ShowWindow"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is greater than 31.
        /// If the function fails, the return value is one of the following error values.
        /// 0: The system is out of memory or resources.
        /// <see cref="ERROR_BAD_FORMAT"/>: The .exe file is invalid.
        /// <see cref="ERROR_FILE_NOT_FOUND"/>: The specified file was not found.
        /// <see cref="ERROR_PATH_NOT_FOUND"/>: The specified path was not found.
        /// </returns>
        /// <remarks>
        /// The <see cref="WinExec"/> function returns when the started process calls the <see cref="GetMessage"/> function or a time-out limit is reached.
        /// To avoid waiting for the time out delay, call the <see cref="GetMessage"/> function as soon as possible
        /// in any process started by a call to <see cref="WinExec"/>.
        /// Security Remarks
        /// The executable name is treated as the first white space-delimited string in <paramref name="lpCmdLine"/>.
        /// If the executable or path name has a space in it, there is a risk that a different executable could be run
        /// because of the way the function parses spaces. The following example is dangerous because the function will attempt to run "Program.exe",
        /// if it exists, instead of "MyApp.exe".
        /// <code>
        /// WinExec("C:\\Program Files\\MyApp", ...)
        /// </code>
        /// If a malicious user were to create an application called "Program.exe" on a system,
        /// any program that incorrectly calls <see cref="WinExec"/> using the Program Files directory will run this application
        /// instead of the intended application.
        /// To avoid this problem, use <see cref="CreateProcess"/> rather than <see cref="WinExec"/>.
        /// However, if you must use <see cref="WinExec"/> for legacy reasons, make sure the application name is enclosed in quotation marks
        /// as shown in the example below.
        /// <code>
        /// WinExec("\"C:\\Program Files\\MyApp.exe\" -L -S", ...)
        /// </code>
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit Windows. Applications should use the CreateProcess function.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WinExec", ExactSpelling = true, SetLastError = true)]
        public static extern UINT WinExec([MarshalAs(UnmanagedType.LPWStr)][In] string lpCmdLine, [In] ShowWindowCommands uCmdShow);

        /// <summary>
        /// <para>
        /// Fills a block of memory with zeros.
        /// To avoid any undesired effects of optimizing compilers, use the <see cref="SecureZeroMemory"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/previous-versions/windows/desktop/legacy/aa366920(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="Destination">
        /// A pointer to the starting address of the block of memory to fill with zeros.
        /// </param>
        /// <param name="Length">
        /// The size of the block of memory to fill with zeros, in bytes.
        /// </param>
        /// <remarks>
        /// Many programming languages include syntax for initializing complex variables to zero.
        /// There can be differences between the results of these operations and the <see cref="ZeroMemory"/> function.
        /// Use <see cref="ZeroMemory"/> to clear a block of memory in any programming language.
        /// This macro is defined as the RtlZeroMemory macro. For more information, see WinBase.h and WinNT.h.
        /// </remarks>
        public static unsafe void ZeroMemory([In] PVOID Destination, [In] SIZE_T Length) => Unsafe.InitBlock(Destination, 0, (uint)(IntPtr)Length);
    }
}
