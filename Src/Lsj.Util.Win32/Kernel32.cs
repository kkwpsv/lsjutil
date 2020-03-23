using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using System.Text;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;

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
        /// Adds a character string to the global atom table and returns a unique value (an atom) identifying the string.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-globaladdatomw
        /// </para>
        /// </summary>
        /// <param name="lpString">
        /// The null-terminated string to be added.
        /// The string can have a maximum size of 255 bytes.
        /// Strings that differ only in case are considered identical.
        /// The case of the first string of this name added to the table is preserved and returned by the <see cref="GlobalGetAtomName"/> function.
        /// Alternatively, you can use an integer atom that has been converted using the <see cref="MAKEINTATOM"/> macro.
        /// See the Remarks for more information.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the newly created atom.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the string already exists in the global atom table,
        /// the atom for the existing string is returned and the atom's reference count is incremented.
        /// The string associated with the atom is not deleted from memory until its reference count is zero.
        /// For more information, see the <see cref="GlobalDeleteAtom"/> function.
        /// Global atoms are not deleted automatically when the application terminates.
        /// For every call to the <see cref="GlobalAddAtom"/> function, there must be a corresponding call to the <see cref="GlobalDeleteAtom"/> function.
        /// If the <paramref name="lpString"/> parameter has the form "#1234",
        /// <see cref="GlobalAddAtom"/> returns an integer atom whose value is the 16-bit representation of the decimal number
        /// specified in the string (0x04D2, in this example).
        /// If the decimal value specified is 0x0000 or is greater than or equal to 0xC000, the return value is zero, indicating an error.
        /// If <paramref name="lpString"/> was created by the <see cref="MAKEINTATOM"/> macro,
        /// the low-order word must be in the range 0x0001 through 0xBFFF.
        /// If the low-order word is not in this range, the function fails.
        /// If <paramref name="lpString"/> has any other form, <see cref="GlobalAddAtom"/> returns a string atom.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GlobalAddAtom", SetLastError = true)]
        public static extern ushort GlobalAddAtom([MarshalAs(UnmanagedType.LPWStr)][In]string lpString);

        /// <summary>
        /// <para>
        /// Retrieves a copy of the character string associated with the specified global atom.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-globalgetatomnamew
        /// </para>
        /// </summary>
        /// <param name="nAtom">
        /// The global atom associated with the character string to be retrieved.
        /// </param>
        /// <param name="lpBuffer">
        /// The buffer for the character string.
        /// </param>
        /// <param name="nSize">
        /// The size, in characters, of the buffer.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the length of the string copied to the buffer, in characters,
        /// not including the terminating null character.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The string returned for an integer atom (an atom whose value is in the range 0x0001 to 0xBFFF) is a null-terminated string
        /// in which the first character is a pound sign (#) and the remaining characters represent the unsigned integer atom value.
        /// Security Considerations
        /// Using this function incorrectly might compromise the security of your program.
        /// Incorrect use of this function includes not correctly specifying the size of the <paramref name="lpBuffer"/> parameter.
        /// Also, note that a global atom is accessible by anyone; thus, privacy and the integrity of its contents is not assured.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GlobalGetAtomNameW", SetLastError = true)]
        public static extern uint GlobalGetAtomName([In]ushort nAtom, [MarshalAs(UnmanagedType.LPWStr)][Out]StringBuilder lpBuffer, [In]int nSize);

        /// <summary>
        /// <para>
        /// Decrements the reference count of a global string atom.
        /// If the atom's reference count reaches zero, <see cref="GlobalDeleteAtom"/> removes the string associated with the atom
        /// from the global atom table.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-globaldeleteatom
        /// </para>
        /// </summary>
        /// <param name="nAtom">
        /// The atom and character string to be deleted.
        /// </param>
        /// <returns>
        /// The function always returns (ATOM) 0.
        /// To determine whether the function has failed,
        /// call <see cref="SetLastError"/> with <see cref="ERROR_SUCCESS"/> before calling <see cref="GlobalDeleteAtom"/>,
        /// then call <see cref="GetLastError"/>.
        /// If the last error code is still <see cref="ERROR_SUCCESS"/>, <see cref="GlobalDeleteAtom"/> has succeeded.
        /// </returns>
        /// <remarks>
        /// A string atom's reference count specifies the number of times the string has been added to the atom table.
        /// The <see cref="GlobalAddAtom"/> function increments the reference count of a string
        /// that already exists in the global atom table each time it is called.
        /// Each call to <see cref="GlobalAddAtom"/> should have a corresponding call to <see cref="GlobalDeleteAtom"/>.
        /// Do not call <see cref="GlobalDeleteAtom"/> more times than you call <see cref="GlobalAddAtom"/>,
        /// or you may delete the atom while other clients are using it.
        /// Applications using Dynamic Data Exchange (DDE) should follow the rules on global atom management to prevent leaks and premature deletion.
        /// <see cref="GlobalDeleteAtom"/> has no effect on an integer atom (an atom whose value is in the range 0x0001 to 0xBFFF).
        /// The function always returns zero for an integer atom.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GlobalDeleteAtom", SetLastError = true)]
        public static extern ushort GlobalDeleteAtom([In]uint nAtom);

        /// <summary>
        /// <para>
        /// Verifies that the calling process has read access to the specified range of memory.
        /// Important This function is obsolete and should not be used.
        /// Despite its name, it does not guarantee that the pointer is valid or that the memory pointed to is safe to use.
        /// For more information, see Remarks on this page.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-isbadreadptr
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
        /// If the calling process has read access to some, but not all, of the bytes in the specified memory range, the return value is <see cref="BOOL.TRUE"/>.
        /// In a preemptive multitasking environment, it is possible for some other thread to change the process's access to the memory being tested. Even when the function indicates that the process has read access to the specified memory, you should use structured exception handling when attempting to access the memory. Use of structured exception handling enables the system to notify the process if an access violation exception occurs, giving the process an opportunity to handle the exception.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsBadReadPtr", SetLastError = true)]
        public static extern BOOL IsBadReadPtr([In]IntPtr lp, [In]UINT_PTR ucb);

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
        /// A pointer to a value that is set to <see langword="true"/> if the process is running under WOW64 on an Intel64 or x64 processor.
        /// If the process is running under 32-bit Windows, the value is set to <see langword="false"/>.
        /// If the process is a 32-bit application running under 64-bit Windows 10 on ARM, the value is set to <see langword="false"/>.
        /// If the process is a 64-bit application running under 64-bit Windows, the value is also set to <see langword="false"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsWow64Process", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWow64Process([In]IntPtr hProcess, [Out]out bool Wow64Process);

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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "QueryPerformanceCounter", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool QueryPerformanceCounter([Out]out LARGE_INTEGER lpPerformanceCount);

        /// <summary>
        /// <para>
        /// Retrieves the frequency of the performance counter.
        /// The frequency of the performance counter is fixed at system boot and is consistent across all processors.
        /// Therefore, the frequency need only be queried upon application initialization, and the result can be cached.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/profileapi/nf-profileapi-queryperformancefrequency
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "QueryPerformanceFrequency", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool QueryPerformanceFrequency([Out]out LARGE_INTEGER lpFrequency);
    }
}
