using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="CombineRgn"/> Modes
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-combinergn"/>
    /// </para>
    /// </summary>
    public enum CombineRgnModes
    {
        /// <summary>
        /// Creates the intersection of the two combined regions.
        /// </summary>
        RGN_AND = 1,

        /// <summary>
        /// Creates the union of two combined regions.
        /// </summary>
        RGN_OR = 2,

        /// <summary>
        /// Creates the union of two combined regions except for any overlapping areas.
        /// </summary>
        RGN_XOR = 3,

        /// <summary>
        /// Combines the parts of hrgnSrc1 that are not part of hrgnSrc2.
        /// </summary>
        RGN_DIFF = 4,

        /// <summary>
        /// Creates a copy of the region identified by hrgnSrc1.
        /// </summary>
        RGN_COPY = 5,
    }
}
