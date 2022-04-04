using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="SetLastErrorEx"/> Types
    /// </summary>
    public enum SetLastErrorExTypes : uint
    {
        /// <summary>
        /// SLE_ERROR
        /// </summary>
        SLE_ERROR = 0x00000001,

        /// <summary>
        /// SLE_MINORERROR
        /// </summary>
        SLE_MINORERROR = 0x00000002,

        /// <summary>
        /// SLE_WARNING
        /// </summary>
        SLE_WARNING = 0x00000003,
    }
}
