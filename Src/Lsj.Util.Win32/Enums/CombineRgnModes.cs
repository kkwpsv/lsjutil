using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="CombineRgn"/> Modes
    /// </summary>
    public enum CombineRgnModes
    {
        /// <summary>
        /// RGN_AND
        /// </summary>
        RGN_AND = 1,

        /// <summary>
        /// RGN_OR
        /// </summary>
        RGN_OR = 2,

        /// <summary>
        /// RGN_XOR
        /// </summary>
        RGN_XOR = 3,

        /// <summary>
        /// RGN_DIFF
        /// </summary>
        RGN_DIFF = 4,

        /// <summary>
        /// RGN_COPY
        /// </summary>
        RGN_COPY = 5,
    }
}
