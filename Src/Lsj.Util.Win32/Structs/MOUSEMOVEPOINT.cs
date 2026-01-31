using Lsj.Util.Win32.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about the mouse's location in screen coordinates.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-mousemovepoint"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct MOUSEMOVEPOINT
    {
        /// <summary>
        /// The x-coordinate of the mouse.
        /// </summary>
        public int x;

        /// <summary>
        /// The y-coordinate of the mouse.
        /// </summary>
        public int y;

        /// <summary>
        /// The time stamp of the mouse coordinate.
        /// </summary>
        public DWORD time;

        /// <summary>
        /// Additional information associated with this coordinate.
        /// </summary>
        public ULONG_PTR dwExtraInfo;
    }
}
