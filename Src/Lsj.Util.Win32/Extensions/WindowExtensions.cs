using System;
using System.Collections.Generic;
using System.Text;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Extensions
{
    public class WindowExtensions
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

        /// <summary>
        /// Get All Top-Level Window Handle (Use <see cref="EnumWindows"/>
        /// </summary>
        /// <returns></returns>
        public static (IntPtr, string)[] GetAllTopLevelWindowHandleWithText()
        {
            var result = new List<(IntPtr, string)>();
            EnumWindows((handle, _) =>
            {
                var sb = new StringBuilder(20);
                GetWindowText(handle, sb, 20);
                result.Add((handle, sb.ToString()));
                return true;
            }, IntPtr.Zero);
            return result.ToArray();
        }
    }
}
