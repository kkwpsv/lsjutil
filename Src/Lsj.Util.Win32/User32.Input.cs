using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32
{
    public static partial class User32
    {
        /// <summary>
        /// <para>
        /// Retrieves the current double-click time for the mouse.
        /// A double-click is a series of two clicks of the mouse button, the second occurring within a specified time after the first.
        /// The double-click time is the maximum number of milliseconds that may occur between the first and second click of a double-click.
        /// The maximum double-click time is 5000 milliseconds.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getdoubleclicktime
        /// </para>
        /// </summary>
        /// <returns>
        /// The return value specifies the current double-click time, in milliseconds.
        /// The maximum return value is 5000 milliseconds.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDoubleClickTime", SetLastError = true)]
        public static extern uint GetDoubleClickTime();
    }
}
