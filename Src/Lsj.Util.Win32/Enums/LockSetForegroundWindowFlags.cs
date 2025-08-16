using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="LockSetForegroundWindow"/> flags
    /// </summary>
    public enum LockSetForegroundWindowFlags : uint
    {
        /// <summary>
        /// LSFW_LOCK
        /// </summary>
        LSFW_LOCK = 1,

        /// <summary>
        /// LSFW_UNLOCK
        /// </summary>
        LSFW_UNLOCK = 2,
    }
}
