using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32
{
    public static partial class User32
    {
        /// <summary>
        /// <para>
        /// Enumerates all top-level windows associated with the specified desktop.
        /// It passes the handle to each window, in turn, to an application-defined callback function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-enumdesktopwindows
        /// </para>
        /// </summary>
        /// <param name="hDesktop">
        /// A handle to the desktop whose top-level windows are to be enumerated.
        /// This handle is returned by the <see cref="CreateDesktop"/>, <see cref="GetThreadDesktop"/>, <see cref="OpenDesktop"/>,
        /// or <see cref="OpenInputDesktop"/> function, and must have the <see cref="DESKTOP_READOBJECTS"/> access right.
        /// For more information, see Desktop Security and Access Rights.
        /// If this parameter is <see cref="IntPtr.Zero"/>, the current desktop is used.
        /// </param>
        /// <param name="lpfn">
        /// A pointer to an application-defined <see cref="WNDENUMPROC"/> callback function.
        /// </param>
        /// <param name="lParam">
        /// An application-defined value to be passed to the callback function.
        /// </param>
        /// <returns>
        /// If the function fails or is unable to perform the enumeration, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// You must ensure that the callback function sets <see cref="SetLastError"/> if it fails.
        /// Windows Server 2003 and Windows XP/2000:
        /// If there are no windows on the desktop, <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_HANDLE"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="EnumDesktopWindows"/> function repeatedly invokes the <paramref name="lpfn"/> callback function
        /// until the last top-level window is enumerated or the callback function returns <see langword="false"/>.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumDesktopWindows", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumDesktopWindows([In]IntPtr hDesktop, [In]WNDENUMPROC lpfn, [In]IntPtr lParam);
    }
}
