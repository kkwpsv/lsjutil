using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="GetAncestor"/> flags
    /// </summary>
    public enum GetAncestorFlags : uint
    {
        /// <summary>
        /// GA_PARENT
        /// </summary>
        GA_PARENT = 1,

        /// <summary>
        /// GA_ROOT
        /// </summary>
        GA_ROOT = 2,

        /// <summary>
        /// GA_ROOTOWNER
        /// </summary>
        GA_ROOTOWNER = 3,
    }
}
