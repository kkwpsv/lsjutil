using Lsj.Util.Win32.DirectX.BaseTypes;
using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Sampler states define texture sampling operations such as texture addressing and texture filtering.
    /// Some sampler states set-up vertex processing, and some set-up pixel processing.
    /// Sampler states can be saved and restored using stateblocks (see State Blocks Save and Restore State (Direct3D 9)).
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dsamplerstatetype"/>
    /// </para>
    /// </summary>
    public enum D3DSAMPLERSTATETYPE
    {
        /// <summary>
        /// Texture-address mode for the u coordinate.
        /// The default is <see cref="D3DTADDRESS_WRAP"/>.
        /// For more information, see <see cref="D3DTEXTUREADDRESS"/>.
        /// </summary>
        D3DSAMP_ADDRESSU = 1,

        /// <summary>
        /// Texture-address mode for the v coordinate.
        /// The default is <see cref="D3DTADDRESS_WRAP"/>.
        /// For more information, see <see cref="D3DTEXTUREADDRESS"/>.
        /// </summary>
        D3DSAMP_ADDRESSV = 2,

        /// <summary>
        /// Texture-address mode for the w coordinate.
        /// The default is <see cref="D3DTADDRESS_WRAP"/>.
        /// For more information, see <see cref="D3DTEXTUREADDRESS"/>.
        /// </summary>
        D3DSAMP_ADDRESSW = 3,

        /// <summary>
        /// Border color or type <see cref="D3DCOLOR"/>.
        /// The default color is 0x00000000.
        /// </summary>
        D3DSAMP_BORDERCOLOR = 4,

        /// <summary>
        /// Magnification filter of type <see cref="D3DTEXTUREFILTERTYPE"/>.
        /// The default value is <see cref="D3DTEXF_POINT"/>.
        /// </summary>
        D3DSAMP_MAGFILTER = 5,

        /// <summary>
        /// Minification filter of type <see cref="D3DTEXTUREFILTERTYPE"/>.
        /// The default value is <see cref="D3DTEXF_POINT"/>.
        /// </summary>
        D3DSAMP_MINFILTER = 6,

        /// <summary>
        /// Mipmap filter to use during minification.
        /// See <see cref="D3DTEXTUREFILTERTYPE"/>.
        /// The default value is <see cref="D3DTEXF_NONE"/>.
        /// </summary>
        D3DSAMP_MIPFILTER = 7,

        /// <summary>
        /// Mipmap level-of-detail bias.
        /// The default value is zero.
        /// </summary>
        D3DSAMP_MIPMAPLODBIAS = 8,

        /// <summary>
        /// level-of-detail index of largest map to use.
        /// Values range from 0 to (n - 1) where 0 is the largest.
        /// The default value is zero.
        /// </summary>
        D3DSAMP_MAXMIPLEVEL = 9,

        /// <summary>
        /// DWORD maximum anisotropy.
        /// Values range from 1 to the value that is specified in the <see cref="D3DCAPS9.MaxAnisotropy"/> member of the <see cref="D3DCAPS9"/> structure.
        /// The default value is 1.
        /// </summary>
        D3DSAMP_MAXANISOTROPY = 10,

        /// <summary>
        /// Gamma correction value.
        /// The default value is 0, which means gamma is 1.0 and no correction is required.
        /// Otherwise, this value means that the sampler should assume gamma of 2.2 on the content
        /// and convert it to linear (gamma 1.0) before presenting it to the pixel shader.
        /// </summary>
        D3DSAMP_SRGBTEXTURE = 11,

        /// <summary>
        /// When a multielement texture is assigned to the sampler, this indicates which element index to use.
        /// The default value is 0.
        /// </summary>
        D3DSAMP_ELEMENTINDEX = 12,

        /// <summary>
        /// Vertex offset in the presampled displacement map.
        /// This is a constant used by the tessellator, its default value is 0.
        /// </summary>
        D3DSAMP_DMAPOFFSET = 13,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// This value is not used.
        /// </summary>
        D3DSAMP_FORCE_DWORD = 0x7fffffff,
    }
}
