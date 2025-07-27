using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.MONITORINFOFlags;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="MONITORINFOEX"/> structure contains information about a display monitor.
    /// </para>
    /// <para>
    /// The <see cref="GetMonitorInfo"/> function stores information into a <see cref="MONITORINFOEX"/> structure or a <see cref="MONITORINFO"/> structure.
    /// </para>
    /// <para>
    /// The <see cref="MONITORINFOEX"/> structure is a superset of the <see cref="MONITORINFO"/> structure.
    /// The <see cref="MONITORINFOEX"/> structure adds a string member to contain a name for the display monitor.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-monitorinfoexw"/>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-monitorinfo"/>
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
        /// <para>
        /// A set of flags that represent attributes of the display monitor.
        /// </para>
        /// <para>
        /// The following flag is defined.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="MONITORINFOF_PRIMARY"/>
        /// </term>
        /// <term>
        /// This is the primary display monitor.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public MONITORINFOFlags dwFlags;

        /// <summary>
        /// A string that specifies the device name of the monitor being used.
        /// </summary>
        public ByValStringStructForSize32 szDevice;
    }
}
