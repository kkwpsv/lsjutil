using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals.ByValStringStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="MONITORINFOEX"/> structure contains information about a display monitor.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-monitorinfo"/>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-monitorinfoexw"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct MONITORINFOEX
    {
        /// <summary>
        /// <para>
        /// The size of the structure, in bytes.
        /// </para>
        /// <para>
        /// Set this member to <code>sizeof(MONITORINFOEX)</code> before calling the <see cref="GetMonitorInfo"/> function.
        /// Doing so lets the function determine the type of structure you are passing to it.
        /// </para>
        /// </summary>
        public DWORD cbSize;

        /// <summary>
        /// A <see cref="RECT"/> structure that specifies the display monitor rectangle, expressed in virtual-screen coordinates.
        /// Note that if the monitor is not the primary display monitor, some of the rectangle's coordinates may be negative values.
        /// </summary>
        public RECT rcMonitor;

        /// <summary>
        /// A <see cref="RECT"/> structure that specifies the work area rectangle of the display monitor, expressed in virtual-screen coordinates.
        /// Note that if the monitor is not the primary display monitor, some of the rectangle's coordinates may be negative values.
        /// </summary>
        public RECT rcWork;

        /// <summary>
        /// A set of flags that represent attributes of the display monitor.
        /// </summary>
        public MONITORINFOFlags dwFlags;

        /// <summary>
        /// A string that specifies the device name of the monitor being used.
        /// </summary>
        public ByValStringStructForSize32 szDevice;
    }
}
