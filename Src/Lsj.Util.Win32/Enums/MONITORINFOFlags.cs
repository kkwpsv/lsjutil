using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>>
    /// <see cref="MONITORINFOEX"/> flags.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-monitorinfo"/>
    /// </para>
    /// </summary>
    public enum MONITORINFOFlags
    {
        /// <summary>
        /// This is the primary display monitor.
        /// </summary>
        MONITORINFOF_PRIMARY = 1,
    }
}
