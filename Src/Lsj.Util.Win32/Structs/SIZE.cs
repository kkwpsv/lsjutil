using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="SIZE"/> structure defines the width and height of a rectangle.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/windef/ns-windef-size"/>
    /// </para>
    /// </summary>
    /// <remark>
    /// The rectangle dimensions stored in this structure can correspond to viewport extents,
    /// window extents, text extents, bitmap dimensions, or the aspect-ratio filter for some extended functions.
    /// </remark>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SIZE
    {
        /// <summary>
        /// Specifies the rectangle's width. The units depend on which function uses this structure.
        /// </summary>
        public LONG cx;

        /// <summary>
        /// Specifies the rectangle's height. The units depend on which function uses this structure.
        /// </summary>
        public LONG cy;
    }
}
