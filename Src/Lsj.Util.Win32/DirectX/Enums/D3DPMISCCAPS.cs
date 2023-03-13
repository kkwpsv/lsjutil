using static Lsj.Util.Win32.DirectX.Enums.D3DBLENDOP;
using static Lsj.Util.Win32.DirectX.Enums.D3DCULL;
using static Lsj.Util.Win32.DirectX.Enums.D3DRENDERSTATETYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3DTEXTURESTAGESTATETYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3DUSAGE;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Miscellaneous driver primitive capability flags.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dpmisccaps"/>
    /// </para>
    /// </summary>
    public enum D3DPMISCCAPS
    {
        /// <summary>
        /// Device can enable and disable modification of the depth buffer on pixel operations.
        /// </summary>
        D3DPMISCCAPS_MASKZ = 0x00000002,

        /// <summary>
        /// The driver does not perform triangle culling.
        /// This corresponds to the <see cref="D3DCULL_NONE"/> member of the <see cref="D3DCULL"/> enumerated type.
        /// </summary>
        D3DPMISCCAPS_CULLNONE = 0x00000010,

        /// <summary>
        /// The driver supports clockwise triangle culling through the <see cref="D3DRS_CULLMODE"/> state.
        /// (This applies only to triangle primitives.)
        /// This flag corresponds to the <see cref="D3DCULL_CW"/> member of the <see cref="D3DCULL"/> enumerated type.
        /// </summary>
        D3DPMISCCAPS_CULLCW = 0x00000020,

        /// <summary>
        /// The driver supports counterclockwise culling through the <see cref="D3DRS_CULLMODE"/> state.
        /// (This applies only to triangle primitives.)
        /// This flag corresponds to the <see cref="D3DCULL_CCW"/> member of the <see cref="D3DCULL"/> enumerated type.
        /// </summary>
        D3DPMISCCAPS_CULLCCW = 0x00000040,

        /// <summary>
        /// Device supports per-channel writes for the render-target color buffer through the <see cref="D3DRS_COLORWRITEENABLE"/> state.
        /// </summary>
        D3DPMISCCAPS_COLORWRITEENABLE = 0x00000100,

        /// <summary>
        /// Device correctly clips scaled points of size greater than 1.0 to user-defined clipping planes.
        /// </summary>
        D3DPMISCCAPS_CLIPPLANESCALEDPOINTS = 0x00000200,

        /// <summary>
        /// Device clips post-transformed vertex primitives.
        /// Specify <see cref="D3DUSAGE_DONOTCLIP"/> when the pipeline should not do any clipping.
        /// For this case, additional software clipping may need to be performed at draw time, requiring the vertex buffer to be in system memory.
        /// </summary>
        D3DPMISCCAPS_CLIPTLVERTS = 0x00000200,

        /// <summary>
        /// Device supports <see cref="D3DTA"/> for temporary register.
        /// </summary>
        D3DPMISCCAPS_TSSARGTEMP = 0x00000400,

        /// <summary>
        /// Device supports alpha-blending operations other than <see cref="D3DBLENDOP_ADD"/>.
        /// </summary>
        D3DPMISCCAPS_BLENDOP = 0x00000800,

        /// <summary>
        /// A reference device that does not render.
        /// </summary>
        D3DPMISCCAPS_NULLREFERENCE = 0x00000100,

        /// <summary>
        /// Device supports independent write masks for multiple element textures or multiple render targets.
        /// </summary>
        D3DPMISCCAPS_INDEPENDENTWRITEMASKS = 0x00004000,

        /// <summary>
        /// Device supports per-stage constants.
        /// See <see cref="D3DTSS_CONSTANT"/> in <see cref="D3DTEXTURESTAGESTATETYPE"/>.
        /// </summary>
        D3DPMISCCAPS_PERSTAGECONSTANT = 0x00008000,

        /// <summary>
        /// Device supports conversion to sRGB after blending.
        /// Differences between Direct3D 9 and Direct3D 9Ex:
        /// This flag is available in Direct3D 9Ex only.
        /// </summary>
        D3DPMISCCAPS_POSTBLENDSRGBCONVERT = 0x00200000,

        /// <summary>
        /// Device supports separate fog and specular alpha.
        /// Many devices use the specular alpha channel to store the fog factor.
        /// </summary>
        D3DPMISCCAPS_FOGANDSPECULARALPHA = 0x00010000,

        /// <summary>
        /// Device supports separate blend settings for the alpha channel.
        /// </summary>
        D3DPMISCCAPS_SEPARATEALPHABLEND = 0x00020000,

        /// <summary>
        /// Device supports different bit depths for multiple render targets.
        /// </summary>
        D3DPMISCCAPS_MRTINDEPENDENTBITDEPTHS = 0x00040000,

        /// <summary>
        /// Device supports post-pixel shader operations for multiple render targets.
        /// </summary>
        D3DPMISCCAPS_MRTPOSTPIXELSHADERBLENDING = 0x00080000,

        /// <summary>
        /// Device clamps fog blend factor per vertex.
        /// </summary>
        D3DPMISCCAPS_FOGVERTEXCLAMPED = 0x00100000,
    }
}
