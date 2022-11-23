using Lsj.Util.Win32.Structs;
using System;

namespace Lsj.Util.Win32.NativeUI
{
    /// <summary>
    /// Window Finder
    /// </summary>
    public static class WindowFinder
    {
        /// <summary>
        /// Find window from point.
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Win32Window? FromPoint(POINT point)
        {
            var handle = User32.WindowFromPoint(point);
            if (handle != IntPtr.Zero)
            {
                return new Win32Window(handle);
            }
            else
            {
                return null;
            }
        }
    }
}
