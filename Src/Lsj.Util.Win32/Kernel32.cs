using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Kernel32.dll
    /// </summary>
    public static class Kernel32
    {
        /// <summary>
        /// <para>
        /// Sets the last-error code for the calling thread.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/errhandlingapi/nf-errhandlingapi-setlasterror
        /// </para>
        /// </summary>
        /// <param name="dwErrCode">The last-error code for the thread.</param>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetLastError", SetLastError = true)]
        public static extern void SetLastError([In]uint dwErrCode);
    }
}
