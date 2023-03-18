using Lsj.Util.Win32.DirectX.ComInterfaces;
using System;
using static Lsj.Util.Win32.DirectX.Enums.D3DTEXTURESTAGESTATETYPE;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines texture coordinate transformation values.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dtexturetransformflags"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Texture coordinates can be transformed using a 4 x 4 matrix before the results are passed to the rasterizer.
    /// The texture coordinate transforms are set by calling <see cref="IDirect3DDevice9.SetTextureStageState"/>,
    /// and by passing in the <see cref="D3DTSS_TEXTURETRANSFORMFLAGS"/> texture stage state and one of the values from <see cref="D3DTEXTURETRANSFORMFLAGS"/>.
    /// For more information about texture transforms, see Texture Coordinate Transformations (Direct3D 9).
    /// </remarks>
    [Flags]
    public enum D3DTEXTURETRANSFORMFLAGS
    {
        /// <summary>
        /// Texture coordinates are passed directly to the rasterizer.
        /// </summary>
        D3DTTFF_DISABLE = 0,

        /// <summary>
        /// The rasterizer should expect 1D texture coordinates.
        /// This value is used by fixed function vertex processing; it should be set to 0 when using a programmable vertex shader.
        /// </summary>
        D3DTTFF_COUNT1 = 1,

        /// <summary>
        /// The rasterizer should expect 2D texture coordinates.
        /// This value is used by fixed function vertex processing; it should be set to 0 when using a programmable vertex shader.
        /// </summary>
        D3DTTFF_COUNT2 = 2,

        /// <summary>
        /// The rasterizer should expect 3D texture coordinates.
        /// This value is used by fixed function vertex processing; it should be set to 0 when using a programmable vertex shader.
        /// </summary>
        D3DTTFF_COUNT3 = 3,

        /// <summary>
        /// The rasterizer should expect 4D texture coordinates.
        /// This value is used by fixed function vertex processing; it should be set to 0 when using a programmable vertex shader.
        /// </summary>
        D3DTTFF_COUNT4 = 4,

        /// <summary>
        /// This flag is honored by the fixed function pixel pipeline, as well as the programmable pixel pipeline in versions ps_1_1 to ps_1_3.
        /// When texture projection is enabled for a texture stage, all four floating point values must be written to the corresponding texture register.
        /// Each texture coordinate is divided by the last element before being passed to the rasterizer.
        /// For example, if this flag is specified with the <see cref="D3DTTFF_COUNT3"/> flag,
        /// the first and second texture coordinates are divided by the third coordinate before being passed to the rasterizer.
        /// </summary>
        D3DTTFF_PROJECTED = 256,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// This value is not used.
        /// </summary>
        D3DTTFF_FORCE_DWORD = 0x7fffffff
    }
}
