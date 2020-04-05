using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="DOCINFO"/> Flags.
    /// </summary>
    public enum DOCINFOFlags : uint
    {
        /// <summary>
        /// DI_APPBANDING
        /// </summary>
        DI_APPBANDING = 0x00000001,

        /// <summary>
        /// DI_ROPS_READ_DESTINATION
        /// </summary>
        DI_ROPS_READ_DESTINATION = 0x00000002,
    }
}
