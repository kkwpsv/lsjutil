using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="TTPOLYGONHEADER"/> structure specifies the starting position and type of a contour in a TrueType character outline.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/ns-wingdi-ttpolygonheader"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Each <see cref="TTPOLYGONHEADER"/> structure is followed by one or more <see cref="TTPOLYCURVE"/> structures.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct TTPOLYGONHEADER
    {
        /// <summary>
        /// TT_POLYGON_TYPE
        /// </summary>
        public const uint TT_POLYGON_TYPE = 24;

        /// <summary>
        /// The number of bytes required by the <see cref="TTPOLYGONHEADER"/> structure
        /// and <see cref="TTPOLYCURVE"/> structure or structures required to describe the contour of the character.
        /// </summary>
        public DWORD cb;

        /// <summary>
        /// The type of character outline returned. Currently, this value must be <see cref="TT_POLYGON_TYPE"/>.
        /// </summary>
        public DWORD dwType;

        /// <summary>
        /// The starting point of the contour in the character outline.
        /// </summary>
        public POINTFX pfxStart;
    }
}
