using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Specifies the window station, desktop, standard handles, and attributes for a new process.
    /// It is used with the <see cref="CreateProcess"/> and <see cref="CreateProcessAsUser"/> functions.
    /// </para>
    /// <para>
    /// From : https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/ns-winbase-startupinfoexw
    /// </para>
    /// </summary>
    /// <remarks>
    /// Be sure to set the cb member of the <see cref="STARTUPINFO"/> structure to <code>sizeof(STARTUPINFOEX)</code>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct STARTUPINFOEX
    {
        /// <summary>
        /// A <see cref="STARTUPINFO"/> structure.
        /// </summary>
        public STARTUPINFO StartupInfo;

        /// <summary>
        /// An attribute list.
        /// This list is created by the <see cref="InitializeProcThreadAttributeList"/> function.
        /// </summary>
        public IntPtr lpAttributeList;
    }
}
