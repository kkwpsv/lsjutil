using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Specifies the subresources from a 3D texture to use in a shader-resource view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex3d_srv"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is one member of a shader-resource-view description (see <see cref="D3D11_SHADER_RESOURCE_VIEW_DESC"/>)
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_TEX3D_SRV
    {
        /// <summary>
        /// Index of the most detailed mipmap level to use;
        /// this number is between 0 and <see cref="MipLevels"/>
        /// (from the original Texture2D for which <see cref="ID3D11Device.CreateShaderResourceView"/> creates a view) -1.
        /// </summary>
        public UINT MostDetailedMip;

        /// <summary>
        /// The maximum number of mipmap levels for the view of the texture.
        /// See the remarks in <see cref="D3D11_TEX1D_SRV"/>.
        /// Set to -1 to indicate all the mipmap levels from <see cref="MostDetailedMip"/> on down to least detailed.
        /// </summary>
        public UINT MipLevels;
    }
}
