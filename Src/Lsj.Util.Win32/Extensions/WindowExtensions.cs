using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Extensions
{
    /// <summary>
    /// Window Extensions
    /// </summary>
    public static class WindowExtensions
    {
        /// <summary>
        /// Get All Top-Level Window Handle (Use <see cref="EnumWindows"/>
        /// </summary>
        /// <returns></returns>
        public static IntPtr[] GetAllTopLevelWindowHandle()
        {
            var result = new List<IntPtr>();
            EnumWindows((handle, _) =>
            {
                result.Add(handle);
                return true;
            }, IntPtr.Zero);
            return result.ToArray();
        }

#if !NET40 && !NET45
        /// <summary>
        /// Get All Top-Level Window Handle (Use <see cref="EnumWindows"/>
        /// </summary>
        /// <returns></returns>
        public static (IntPtr WindowHandle, string Text)[] GetAllTopLevelWindowHandleWithText()
        {
            var result = new List<(IntPtr, string)>();
            EnumWindows((handle, _) =>
            {
                SetLastError(0);
                var length = GetWindowTextLength(handle);
                var code = Marshal.GetLastWin32Error();
                if (code == 0)
                {
                    var sb = new StringBuilder(length);
                    GetWindowText(handle, sb, 20);
                    code = Marshal.GetLastWin32Error();
                    if (code == 0)
                    {
                        result.Add((handle, sb.ToString()));
                        return true;
                    }
                }
                result.Add((handle, null));
                return true;
            }, IntPtr.Zero);
            return result.ToArray();
        }
#endif
    }
}
