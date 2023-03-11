using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies how to combine the glyph data from the source and destination surfaces in a call to <see cref="IDirect3DDevice9Ex.ComposeRects"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dcomposerectsop"/>
    /// </para>
    /// </summary>
    public enum D3DCOMPOSERECTSOP
    {
        /// <summary>
        /// Copy the source to the destination.
        /// </summary>
        D3DCOMPOSERECTS_COPY = 1,

        /// <summary>
        /// Bitwise OR the source and the destination.
        /// </summary>
        D3DCOMPOSERECTS_OR = 2,

        /// <summary>
        /// Bitwise AND the source and the destination.
        /// </summary>
        D3DCOMPOSERECTS_AND = 3,

        /// <summary>
        /// Copy the negated source to the destination (Dst &amp; ~Src).
        /// </summary>
        D3DCOMPOSERECTS_NEG = 4,

        /// <summary>
        /// Reserved.
        /// Used to force enumeration to 32-bits in size.
        /// </summary>
        D3DCOMPOSERECTS_FORCE_DWORD = 0x7fffffff
    }
}
