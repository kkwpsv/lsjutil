using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="RGNDATAHEADER"/> structure describes the data returned by the <see cref="GetRegionData"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-rgndataheader"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct RGNDATAHEADER
    {
        /// <summary>
        /// The size, in bytes, of the header.
        /// </summary>
        public DWORD dwSize;

        /// <summary>
        /// The type of region.
        /// This value must be <see cref="RDH_RECTANGLES"/>.
        /// </summary>
        public DWORD iType;

        /// <summary>
        /// The number of rectangles that make up the region.
        /// </summary>
        public DWORD nCount;

        /// <summary>
        /// The size of the <see cref="RGNDATA"/> buffer required to receive the <see cref="RECT"/> structures that make up the region.
        /// If the size is not known, this member can be zero.
        /// </summary>
        public DWORD nRgnSize;

        /// <summary>
        /// A bounding rectangle for the region in logical units.
        /// </summary>
        public RECT rcBound;
    }
}
