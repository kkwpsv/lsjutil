using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="UpdateLayeredWindow"/> flags
    /// </summary>
    public enum UpdateLayeredWindowFlags : uint
    {
        /// <summary>
        /// ULW_ALPHA
        /// </summary>
        ULW_ALPHA = 2,

        /// <summary>
        /// ULW_COLORKEY
        /// </summary>
        ULW_COLORKEY = 1,

        /// <summary>
        /// ULW_OPAQUE
        /// </summary>
        ULW_OPAQUE = 4,

        /// <summary>
        /// ULW_EX_NORESIZE
        /// </summary>
        ULW_EX_NORESIZE = 8,
    }
}
