using Lsj.Util.Win32.DirectX.Structs;
using static Lsj.Util.Win32.DirectX.Enums.D3DPBLENDCAPS;
using static Lsj.Util.Win32.DirectX.Enums.D3DRENDERSTATETYPE;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines the supported blend mode.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dblend"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// In the preceding member descriptions, the RGBA values of the source and destination are indicated by the s and d subscripts.
    /// The values in this enumerated type are used by the following render states:
    /// <see cref="D3DRS_DESTBLEND"/>, <see cref="D3DRS_SRCBLEND"/>, <see cref="D3DRS_DESTBLENDALPHA"/>, <see cref="D3DRS_SRCBLENDALPHA"/>
    /// See <see cref="D3DRENDERSTATETYPE"/>
    /// Render Target Blending
    /// Direct3D 9Ex has improved text rendering capabilities. Rendering clear-type fonts would normally require two passes.
    /// To eliminate the second pass, a pixel shader can be used to output two colors, which we can call PSOutColor[0] and PSOutColor[1].
    /// The first color would contain the standard 3 color components (RGB). The second color would contain 3 alpha components (one for each component of the first color).
    /// These new blending modes are only used for text rendering on the first render target.
    /// </remarks>
    public enum D3DBLEND
    {
        /// <summary>
        /// Blend factor is (0, 0, 0, 0).
        /// </summary>
        D3DBLEND_ZERO = 1,

        /// <summary>
        /// Blend factor is (1, 1, 1, 1).
        /// </summary>
        D3DBLEND_ONE = 2,

        /// <summary>
        /// Blend factor is (Rₛ, Gₛ, Bₛ, Aₛ).
        /// </summary>
        D3DBLEND_SRCCOLOR = 3,

        /// <summary>
        /// Blend factor is (1 - Rₛ, 1 - Gₛ, 1 - Bₛ, 1 - Aₛ).
        /// </summary>
        D3DBLEND_INVSRCCOLOR = 4,

        /// <summary>
        /// Blend factor is (Aₛ, Aₛ, Aₛ, Aₛ).
        /// </summary>
        D3DBLEND_SRCALPHA = 5,

        /// <summary>
        /// Blend factor is ( 1 - Aₛ, 1 - Aₛ, 1 - Aₛ, 1 - Aₛ).
        /// </summary>
        D3DBLEND_INVSRCALPHA = 6,

        /// <summary>
        /// Blend factor is (Ad Ad Ad Ad).
        /// </summary>
        D3DBLEND_DESTALPHA = 7,

        /// <summary>
        /// Blend factor is (1 - Ad 1 - Ad 1 - Ad 1 - Ad).
        /// </summary>
        D3DBLEND_INVDESTALPHA = 8,

        /// <summary>
        /// Blend factor is (Rd, Gd, Bd, Ad).
        /// </summary>
        D3DBLEND_DESTCOLOR = 9,

        /// <summary>
        /// Blend factor is (1 - Rd, 1 - Gd, 1 - Bd, 1 - Ad).
        /// </summary>
        D3DBLEND_INVDESTCOLOR = 10,

        /// <summary>
        /// Blend factor is (f, f, f, 1); where f = min(Aₛ, 1 - Ad).
        /// </summary>
        D3DBLEND_SRCALPHASAT = 11,

        /// <summary>
        /// Obsolete.
        /// Starting with DirectX 6, you can achieve the same effect by setting the source and destination blend factors
        /// to <see cref="D3DBLEND_SRCALPHA"/> and <see cref="D3DBLEND_INVSRCALPHA"/> in separate calls.
        /// </summary>
        D3DBLEND_BOTHSRCALPHA = 12,

        /// <summary>
        /// Obsolete.
        /// Source blend factor is (1 - Aₛ, 1 - Aₛ, 1 - Aₛ, 1 - Aₛ), and destination blend factor is (Aₛ, Aₛ, Aₛ, Aₛ);
        /// the destination blend selection is overridden.
        /// This blend mode is supported only for the <see cref="D3DRS_SRCBLEND"/> render state.
        /// </summary>
        D3DBLEND_BOTHINVSRCALPHA = 13,

        /// <summary>
        /// Constant color blending factor used by the frame-buffer blender.
        /// This blend mode is supported only if <see cref="D3DPBLENDCAPS_BLENDFACTOR"/> is set
        /// in the <see cref="D3DCAPS9.D3DCAPS9"/> or <see cref="D3DCAPS9.DestBlendCaps"/> members of <see cref="D3DCAPS9"/>.
        /// </summary>
        D3DBLEND_BLENDFACTOR = 14,

        /// <summary>
        /// Inverted constant color-blending factor used by the frame-buffer blender.
        /// This blend mode is supported only if the <see cref="D3DPBLENDCAPS_BLENDFACTOR"/> bit is set
        /// in the <see cref="D3DCAPS9.D3DCAPS9"/> or <see cref="D3DCAPS9.DestBlendCaps"/> members of <see cref="D3DCAPS9"/>.
        /// </summary>
        D3DBLEND_INVBLENDFACTOR = 15,

        /// <summary>
        /// Blend factor is (PSOutColor[1]r, PSOutColor[1]g, PSOutColor[1]b, not used). See Render Target Blending.
        /// Differences between Direct3D 9 and Direct3D 9Ex:
        /// This flag is available in Direct3D 9Ex only.
        /// </summary>
        D3DBLEND_SRCCOLOR2 = 16,

        /// <summary>
        /// Blend factor is (1 - PSOutColor[1]r, 1 - PSOutColor[1]g, 1 - PSOutColor[1]b, not used)).
        /// See Render Target Blending.
        /// Differences between Direct3D 9 and Direct3D 9Ex:
        /// This flag is available in Direct3D 9Ex only.
        /// </summary>
        D3DBLEND_INVSRCCOLOR2 = 17,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// This value is not used.
        /// </summary>
        D3DBLEND_FORCE_DWORD = 0x7fffffff
    }
}
