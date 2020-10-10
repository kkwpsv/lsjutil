using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="PrintWindow"/> Flags
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-printwindow
    /// </para>
    /// </summary>
    public enum PrintWindowFlags : uint
    {
        /// <summary>
        /// Only the client area of the window is copied to hdcBlt.
        /// By default, the entire window is copied. 
        /// </summary>
        PW_CLIENTONLY = 0x00000001,
    }
}
