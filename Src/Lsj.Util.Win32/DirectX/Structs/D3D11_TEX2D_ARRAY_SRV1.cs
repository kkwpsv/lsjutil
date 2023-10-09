using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the subresources from an array of 2D textures to use in a shader-resource view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/ns-d3d11_3-d3d11_tex2d_array_srv1"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_TEX2D_ARRAY_SRV1
    {
        /// <summary>
        /// Index of the most detailed mipmap level to use;
        /// this number is between 0 and <see cref="MipLevels"/>
        /// (from the original Texture2D for which <see cref="ID3D11Device3.CreateShaderResourceView1"/> creates a view) -1.
        /// </summary>
        public UINT MostDetailedMip;

        /// <summary>
        /// The maximum number of mipmap levels for the view of the texture.
        /// See the remarks in <see cref="D3D11_TEX1D_SRV"/>.
        /// Set to -1 to indicate all the mipmap levels from <see cref="MostDetailedMip"/> on down to least detailed.
        /// </summary>
        public UINT MipLevels;

        /// <summary>
        /// The index of the first texture to use in an array of textures.
        /// </summary>
        public UINT FirstArraySlice;

        /// <summary>
        /// Number of textures in the array.
        /// </summary>
        public UINT ArraySize;

        /// <summary>
        /// The index (plane slice number) of the plane to use in an array of textures.
        /// </summary>
        public UINT PlaneSlice;
    }
}
