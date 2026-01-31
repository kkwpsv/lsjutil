using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.MonitorDefaultFlags;

namespace Lsj.Util.Win32
{
    public static partial class User32
    {
        /// <summary>
        /// <para>
        /// The <see cref="GetMonitorInfo"/> function retrieves information about a display monitor.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getmonitorinfow"/>
        /// </para>
        /// </summary>
        /// <param name="hMonitor">
        /// A handle to the display monitor of interest.
        /// </param>
        /// <param name="lpmi">
        /// <para>
        /// A pointer to a <see cref="MONITORINFO"/> or <see cref="MONITORINFOEX"/> structure that receives information about the specified display monitor.
        /// </para>
        /// <para>
        /// You must set the <see cref="MONITORINFO.cbSize"/> member of the structure to <c>sizeof(MONITORINFO)</c> or <c>sizeof(MONITORINFOEX)</c>
        /// before calling the <see cref="GetMonitorInfo"/> function.
        /// Doing so lets the function determine the type of structure you are passing to it.
        /// </para>
        /// <para>
        /// The <see cref="MONITORINFOEX"/> structure is a superset of the <see cref="MONITORINFO"/> structure.
        /// It has one additional member: a string that contains a name for the display monitor.
        /// Most applications have no use for a display monitor name, and so can save some bytes by using a <see cref="MONITORINFO"/> structure.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMonitorInfoW", ExactSpelling = true)]
        public static extern BOOL GetMonitorInfo([In] HMONITOR hMonitor, [In][Out] ref MONITORINFOEX lpmi);

        /// <summary>
        /// <para>
        /// The <see cref="MonitorFromPoint"/> function retrieves a handle to the display monitor that contains a specified point.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-monitorfrompoint"/>
        /// </para>
        /// </summary>
        /// <param name="pt">
        /// A <see cref="POINT"/> structure that specifies the point of interest in virtual-screen coordinates.
        /// </param>
        /// <param name="dwFlags">
        /// <para>
        /// Determines the function's return value if the point is not contained within any display monitor.
        /// </para>
        /// <para>
        /// This parameter can be one of the following values.
        /// </para>
        /// <para>
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
        /// <para>
        /// <see cref="MONITOR_DEFAULTTONULL"/>
        /// </para>
        /// <para>
        /// 0x00000000
        /// </para>
        /// </term>
        /// <term>
        /// Returns <see cref="NULL"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MONITOR_DEFAULTTOPRIMARY"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// Returns a handle to the primary display monitor.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MONITOR_DEFAULTTONEAREST"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// Returns a handle to the display monitor that is nearest to the point.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the point is contained by a display monitor,
        /// the return value is an <see cref="HMONITOR"/> handle to that display monitor.
        /// </para>
        /// <para>
        /// If the point is not contained by a display monitor,
        /// the return value depends on the value of <paramref name="dwFlags"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "MonitorFromPoint", ExactSpelling = true)]
        public static extern HMONITOR MonitorFromPoint([In] POINT pt, [In] MonitorDefaultFlags dwFlags);

        /// <summary>
        /// <para>
        /// The <see cref="MonitorFromRect"/> function retrieves a handle to the display monitor
        /// that has the largest area of intersection with a specified rectangle.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-monitorfromrect"/>
        /// </para>
        /// </summary>
        /// <param name="lprc">
        /// A pointer to a <see cref="RECT"/> structure that specifies the rectangle of interest in virtual-screen coordinates.
        /// </param>
        /// <param name="dwFlags">
        /// <para>
        /// Determines the function's return value if the rectangle does not intersect any display monitor.
        /// </para>
        /// <para>
        /// This parameter can be one of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="MONITOR_DEFAULTTONEAREST"/>
        /// </term>
        /// <term>
        /// Returns a handle to the display monitor that is nearest to the rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MONITOR_DEFAULTTONULL"/>
        /// </term>
        /// <term>
        /// Returns <see cref="NULL"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MONITOR_DEFAULTTOPRIMARY"/>
        /// </term>
        /// <term>
        /// Returns a handle to the primary display monitor.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the rectangle intersects one or more display monitor rectangles,
        /// the return value is an <see cref="HMONITOR"/> handle to the display monitor
        /// that has the largest area of intersection with the rectangle.
        /// </para>
        /// <para>
        /// If the rectangle does not intersect a display monitor,
        /// the return value depends on the value of <paramref name="dwFlags"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "MonitorFromRect", ExactSpelling = true)]
        public static extern HMONITOR MonitorFromRect([In] in RECT lprc, [In] MonitorDefaultFlags dwFlags);

        /// <summary>
        /// <para>
        /// The <see cref="MonitorFromWindow"/> function retrieves a handle to the display monitor 
        /// that has the largest area of intersection with the bounding rectangle of a specified window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-monitorfromwindow"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window of interest.
        /// </param>
        /// <param name="dwFlags">
        /// <para>
        /// Determines the function's return value if the window does not intersect any display monitor.
        /// </para>
        /// <para>
        /// This parameter can be one of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="MONITOR_DEFAULTTONEAREST"/>
        /// </term>
        /// <term>
        /// Returns a handle to the display monitor that is nearest to the window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MONITOR_DEFAULTTONULL"/>
        /// </term>
        /// <term>
        /// Returns <see cref="NULL"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MONITOR_DEFAULTTOPRIMARY"/>
        /// </term>
        /// <term>
        /// Returns a handle to the primary display monitor.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the window intersects one or more display monitor rectangles,
        /// the return value is an <see cref="HMONITOR"/> handle to the display monitor that has the largest area of intersection with the window.
        /// </para>
        /// <para>
        /// If the window does not intersect a display monitor, the return value depends on the value of <paramref name="dwFlags"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// If the window is currently minimized, <see cref="MonitorFromWindow"/> uses the rectangle of the window before it was minimized.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "MonitorFromWindow", ExactSpelling = true)]
        public static extern HMONITOR MonitorFromWindow([In] HWND hwnd, [In] MonitorDefaultFlags dwFlags);
    }
}
