using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="SCROLLINFO"/> flags
    /// </summary>
    public enum ScrollInfoFlags : uint
    {
        /// <summary>
        /// SIF_RANGE
        /// </summary>
        SIF_RANGE = 0x0001,

        /// <summary>
        /// SIF_PAGE
        /// </summary>
        SIF_PAGE = 0x0002,

        /// <summary>
        /// SIF_POS
        /// </summary>
        SIF_POS = 0x0004,

        /// <summary>
        /// SIF_DISABLENOSCROLL
        /// </summary>
        SIF_DISABLENOSCROLL = 0x0008,

        /// <summary>
        /// SIF_TRACKPOS
        /// </summary>
        SIF_TRACKPOS = 0x0010,

        /// <summary>
        /// SIF_ALL
        /// </summary>
        SIF_ALL = (SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS),
    }
}
