using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Enums.ProcessAccessRights;

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
    }
}
