using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="LockSetForegroundWindow"/> Flags
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-locksetforegroundwindow"/>
    /// </para>
    /// </summary>
    public enum LockSetForegroundWindowFlags : uint
    {
        /// <summary>
        /// Disables calls to <see cref="SetForegroundWindow"/>.
        /// </summary>
        LSFW_LOCK = 1,

        /// <summary>
        /// Enables calls to <see cref="SetForegroundWindow"/>.
        /// </summary>
        LSFW_UNLOCK = 2,
    }
}
