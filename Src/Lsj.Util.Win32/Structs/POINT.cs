using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// The POINT structure defines the x- and y-coordinates of a point.
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/windef/ns-windef-point
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct POINT
    {
        /// <summary>
        /// Specifies the x-coordinate of the point.
        /// </summary>
        public int x;

        /// <summary>
        /// Specifies the y-coordinate of the point.
        /// </summary>
        public int y;
    }
}
