using Lsj.Util.Win32.DirectX.ComInterfaces;
using static Lsj.Util.Win32.DirectX.Enums.D3DCREATE;
using static Lsj.Util.Win32.DirectX.Enums.D3DPOOL;
using static Lsj.Util.Win32.DirectX.Enums.D3DRENDERSTATETYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3DBLEND;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Driver capability flags.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dcaps3"/>
    /// </para>
    /// </summary>
    public enum D3DCAPS3 : uint
    {
        /// <summary>
        /// Indicates that the device can respect the <see cref="D3DRS_ALPHABLENDENABLE"/> render state in full-screen mode
        /// while using the FLIP or DISCARD swap effect.
        /// This only applies when the <see cref="D3DRS_SRCBLEND"/> or <see cref="D3DRS_DESTBLEND"/> states are set to one of the following:
        /// <see cref="D3DBLEND_DESTALPHA"/>, <see cref="D3DBLEND_INVDESTALPHA"/>,
        /// <see cref="D3DBLEND_DESTCOLOR"/>, <see cref="D3DBLEND_INVDESTCOLOR"/>
        /// </summary>
        D3DCAPS3_ALPHA_FULLSCREEN_FLIP_OR_DISCARD = 0x00000020,

        /// <summary>
        /// Device can accelerate a memory copy from system memory to local video memory.
        /// This cap guarantees that <see cref="IDirect3DDevice9.UpdateSurface"/> and <see cref="IDirect3DDevice9.UpdateTexture"/> calls will be hardware accelerated.
        /// If this cap is absent, these calls will succeed but will be slower.
        /// </summary>
        D3DCAPS3_COPY_TO_VIDMEM = 0x00000100,

        /// <summary>
        /// Device can accelerate a memory copy from local video memory to system memory.
        /// This cap guarantees that <see cref="IDirect3DDevice9.GetRenderTargetData"/> calls will be hardware accelerated.
        /// If this cap is absent, this call will succeed but will be slower.
        /// </summary>
        D3DCAPS3_COPY_TO_SYSTEMMEM = 0x00000200,

        /// <summary>
        /// The display driver supports the DXVA-HD DDI.
        /// For more information about DXVA-HD DDI, see Processing High-Definition Video.
        /// Differences between Direct3D 9 and Direct3D 9Ex:
        /// This flag is available in Direct3D 9Ex only.
        /// </summary>
        D3DCAPS3_DXVAHD = 0x00000400,

        /// <summary>
        /// Indicates that the device can perform gamma correction from a windowed back buffer (containing linear content) to an sRGB desktop.
        /// </summary>
        D3DCAPS3_LINEAR_TO_SRGB_PRESENTATION = 0x00000080,

        /// <summary>
        /// Reserved; not used.
        /// </summary>
        D3DCAPS3_RESERVED = 0x8000001f,
    }
}
