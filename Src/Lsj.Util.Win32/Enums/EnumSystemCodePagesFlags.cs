using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="EnumSystemCodePages"/> Flags
    /// </summary>
    public enum EnumSystemCodePagesFlags : uint
    {
        /// <summary>
        /// CP_INSTALLED
        /// </summary>
        CP_INSTALLED = 0x00000001,

        /// <summary>
        /// CP_SUPPORTED
        /// </summary>
        CP_SUPPORTED = 0x00000002,
    }
}
