using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="DuplicateHandle"/> options
    /// </summary>
    public enum DuplicateHandleOptions : uint
    {
        /// <summary>
        /// DUPLICATE_CLOSE_SOURCE
        /// </summary>
        DUPLICATE_CLOSE_SOURCE = 0x00000001,

        /// <summary>
        /// DUPLICATE_SAME_ACCESS
        /// </summary>
        DUPLICATE_SAME_ACCESS = 0x00000002,
    }
}
