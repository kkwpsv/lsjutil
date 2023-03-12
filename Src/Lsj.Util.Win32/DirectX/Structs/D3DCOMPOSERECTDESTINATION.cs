using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Specifies the source glyph and location in a monochrome surface to copy glyphs into.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dcomposerectdestination"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is used in calls to <see cref="IDirect3DDevice9Ex.ComposeRects"/> to enclose glyphs on the source surface.
    /// A vertex buffer (see <see cref="IDirect3DVertexBuffer9"/>) filled with these structures are created to contain the glyph locations.
    /// <see cref="USHORT"/> members are used to reduce the memory footprint as much as possible.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3DCOMPOSERECTDESTINATION
    {
        /// <summary>
        /// Index particular glyph from vertex buffer containing <see cref="D3DCOMPOSERECTDESC"/> structures.
        /// </summary>
        public USHORT SrcRectIndex;

        /// <summary>
        /// Reserved for alignment purposes.
        /// </summary>
        public USHORT Reserved;

        /// <summary>
        /// Left coordinate to begin copy at.
        /// </summary>
        public USHORT X;

        /// <summary>
        /// Top coordinate to begin copy at.
        /// </summary>
        public USHORT Y;
    }
}
