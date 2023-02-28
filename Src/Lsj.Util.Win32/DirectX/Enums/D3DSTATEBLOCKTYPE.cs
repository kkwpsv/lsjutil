using static Lsj.Util.Win32.DirectX.Enums.D3DRENDERSTATETYPE;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Predefined sets of pipeline state used by state blocks (see State Blocks Save and Restore State (Direct3D 9)).
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dstateblocktype"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// As the following diagram shows, vertex and pixel state are both subsets of device state.
    /// There are only a few states that are considered both vertex and pixel state. These states are:
    /// Render state: <see cref="D3DRS_FOGDENSITY"/>
    /// Render state: <see cref="D3DRS_FOGSTART"/>
    /// Render state: <see cref="D3DRS_FOGEND"/>
    /// Texture state: <see cref="D3DTSS_TEXCOORDINDEX"/>
    /// Texture state: <see cref="D3DTSS_TEXTURETRANSFORMFLAGS"/>
    /// </remarks>
    public enum D3DSTATEBLOCKTYPE
    {
        /// <summary>
        /// Capture the current device state.
        /// </summary>
        D3DSBT_ALL = 1,

        /// <summary>
        /// Capture the current pixel state.
        /// </summary>
        D3DSBT_PIXELSTATE = 2,

        /// <summary>
        /// Capture the current vertex state.
        /// </summary>
        D3DSBT_VERTEXSTATE = 3,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// Do not use this value.
        /// </summary>
        D3DSBT_FORCE_DWORD = 0x7fffffff
    }
}
