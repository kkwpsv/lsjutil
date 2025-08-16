using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="TRACKMOUSEEVENT"/> Flags
    /// </summary>
    public enum TrackMouseEventFlags : uint
    {
        /// <summary>
        /// TME_CANCEL
        /// </summary>
        TME_CANCEL = 0x80000000,

        /// <summary>
        /// TME_HOVER
        /// </summary>
        TME_HOVER = 0x00000001,

        /// <summary>
        /// TME_LEAVE
        /// </summary>
        TME_LEAVE = 0x00000002,

        /// <summary>
        /// TME_NONCLIENT
        /// </summary>
        TME_NONCLIENT = 0x00000010,

        /// <summary>
        /// TME_QUERY
        /// </summary>
        TME_QUERY = 0x40000000,
    }
}
