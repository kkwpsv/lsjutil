using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the subresources from a 3D texture to use in a shader-resource view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tex3d_srv"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is one member of a shader-resource-view description, <see cref="D3D12_SHADER_RESOURCE_VIEW_DESC"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_TEX3D_SRV
    {
        /// <summary>
        /// The index of the most detailed mipmap level to use; this number is between 0 and <see cref="MipLevels"/>
        /// (from the original Texture3D for which <see cref="ID3D12Device.CreateShaderResourceView"/> creates a view) -1.
        /// </summary>
        public UINT MostDetailedMip;

        /// <summary>
        /// The maximum number of mipmap levels for the view of the texture.
        /// See the remarks in <see cref="D3D12_TEX1D_SRV"/>.
        /// Set to -1 to indicate all the mipmap levels from <see cref="MostDetailedMip"/> on down to least detailed.
        /// </summary>
        public UINT MipLevels;

        /// <summary>
        /// <para>
        /// Specifies the minimum mipmap level that you can access.
        /// Specifying 0.0f means that you can access all of the mipmap levels.
        /// Specifying 3.0f means that you can access mipmap levels from 3.0f to MipCount - 1.
        /// </para>
        /// <para>
        /// We recommend that you don't set <see cref="MostDetailedMip"/> and <see cref="ResourceMinLODClamp"/> at the same time.
        /// Instead, set one of those two members to 0 (to get default behavior).
        /// That's because <see cref="MipLevels"/> is interpreted differently in conjunction with different fields:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// For <see cref="MostDetailedMip"/>, mips are in the range
        /// [<see cref="MostDetailedMip"/>, <see cref="MostDetailedMip"/> + <see cref="MipLevels"/> - 1].
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// For <see cref="ResourceMinLODClamp"/>, mips are in the range
        /// [<see cref="ResourceMinLODClamp"/>, <see cref="MipLevels"/> - 1].
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public FLOAT ResourceMinLODClamp;
    }
}
