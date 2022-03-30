using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="RGNDATA"/> structure contains a header and an array of rectangles that compose a region.
    /// The rectangles are sorted top to bottom, left to right. They do not overlap.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-rgndata"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct RGNDATA
    {
        /// <summary>
        /// A <see cref="RGNDATAHEADER"/> structure.
        /// The members of this structure specify the type of region (whether it is rectangular or trapezoidal),
        /// the number of rectangles that make up the region,
        /// the size of the buffer that contains the rectangle structures, and so on.
        /// </summary>
        public RGNDATAHEADER rdh;

        /// <summary>
        /// Specifies an arbitrary-size buffer that contains the <see cref="RECT"/> structures that make up the region.
        /// </summary>
        public byte Buffer;
    }
}
