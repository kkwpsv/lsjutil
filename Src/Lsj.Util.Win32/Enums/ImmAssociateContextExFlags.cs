using static Lsj.Util.Win32.Imm32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="ImmAssociateContextEx"/> Flags
    /// </summary>
    public enum ImmAssociateContextExFlags : uint
    {
        /// <summary>
        /// IACE_CHILDREN
        /// </summary>
        IACE_CHILDREN = 0x0001,

        /// <summary>
        /// IACE_DEFAULT
        /// </summary>
        IACE_DEFAULT = 0x0010,

        /// <summary>
        /// IACE_IGNORENOCONTEXT
        /// </summary>
        IACE_IGNORENOCONTEXT = 0x0020,
    }
}
