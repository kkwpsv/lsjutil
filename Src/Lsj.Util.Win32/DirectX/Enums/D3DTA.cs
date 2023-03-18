using Lsj.Util.Win32.DirectX.ComInterfaces;
using System;
using static Lsj.Util.Win32.DirectX.Enums.D3DPMISCCAPS;
using static Lsj.Util.Win32.DirectX.Enums.D3DRENDERSTATETYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3DTEXTUREOP;
using static Lsj.Util.Win32.DirectX.Enums.D3DTEXTURESTAGESTATETYPE;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Texture argument constants are used as values for the following members of the <see cref="D3DTEXTURESTAGESTATETYPE"/> enumerated type:
    /// <see cref="D3DTSS_ALPHAARG0"/>
    /// <see cref="D3DTSS_ALPHAARG1"/>
    /// <see cref="D3DTSS_ALPHAARG2"/>
    /// <see cref="D3DTSS_COLORARG0"/>
    /// <see cref="D3DTSS_COLORARG1"/>
    /// <see cref="D3DTSS_COLORARG2"/>
    /// <see cref="D3DTSS_RESULTARG"/>
    /// Set and retrieve texture arguments by calling the <see cref="IDirect3DDevice9.SetTextureStageState"/> and <see cref="IDirect3DDevice9.GetTextureStageState"/> methods.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dta"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum D3DTA : uint
    {
        /// <summary>
        /// Select a constant from a texture stage.
        /// The default value is 0xffffffff.
        /// </summary>
        D3DTA_CONSTANT = 0x00000006,

        /// <summary>
        /// The texture argument is the result of the previous blending stage.
        /// In the first texture stage (stage 0), this argument is equivalent to <see cref="D3DTA_DIFFUSE"/>.
        /// If the previous blending stage uses a bump-map texture (the <see cref="D3DTOP_BUMPENVMAP"/> operation),
        /// the system chooses the texture from the stage before the bump-map texture.
        /// If s represents the current texture stage and s - 1 contains a bump-map texture,
        /// this argument becomes the result output by texture stage s - 2.
        /// Permissions are read/write.
        /// </summary>
        D3DTA_CURRENT = 0x00000001 ,

        /// <summary>
        /// The texture argument is the diffuse color interpolated from vertex components during Gouraud shading.
        /// If the vertex does not contain a diffuse color, the default color is 0xffffffff.
        /// Permissions are read-only.
        /// </summary>
        D3DTA_DIFFUSE = 0x00000000,

        /// <summary>
        /// Mask value for all arguments; not used when setting texture arguments.
        /// </summary>
        D3DTA_SELECTMASK = 0x0000000f,

        /// <summary>
        /// he texture argument is the specular color interpolated from vertex components during Gouraud shading.
        /// If the vertex does not contain a specular color, the default color is 0xffffffff.
        /// Permissions are read-only.
        /// </summary>
        D3DTA_SPECULAR = 0x00000004,

        /// <summary>
        /// The texture argument is a temporary register color for read or write.
        /// <see cref="D3DTA_TEMP"/> is supported if the <see cref="D3DPMISCCAPS_TSSARGTEMP"/> device capability is present.
        /// The default value for the register is (0.0, 0.0, 0.0, 0.0).
        /// Permissions are read/write.
        /// </summary>
        D3DTA_TEMP = 0x00000005,

        /// <summary>
        /// The texture argument is the texture color for this texture stage.
        /// Permissions are read-only.
        /// </summary>
        D3DTA_TEXTURE = 0x00000002,

        /// <summary>
        /// The texture argument is the texture factor set in a previous call
        /// to the <see cref="IDirect3DDevice9.SetRenderState"/> with the <see cref="D3DRS_TEXTUREFACTOR"/> render-state value.
        /// Permissions are read-only.
        /// </summary>
        D3DTA_TFACTOR = 0x00000003,

        /// <summary>
        /// Replicate the alpha information to all color channels before the operation completes.
        /// This is a read modifier.
        /// </summary>
        D3DTA_ALPHAREPLICATE = 0x00000020,

        /// <summary>
        /// Take the complement of the argument x, (1.0 - x).
        /// This is a read modifier.
        /// </summary>
        D3DTA_COMPLEMENT = 0x00000010,
    }
}
