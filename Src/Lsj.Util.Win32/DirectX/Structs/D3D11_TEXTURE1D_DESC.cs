using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_USAGE;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_BIND_FLAG;
using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a 1D texture.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_texture1d_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is used in a call to <see cref="ID3D11Device.CreateTexture1D"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_TEXTURE1D_DESC
    {
        /// <summary>
        /// Texture width (in texels).
        /// The range is from 1 to <see cref="D3D11_REQ_TEXTURE1D_U_DIMENSION"/> (16384).
        /// However, the range is actually constrained by the feature level at which you create the rendering device.
        /// For more information about restrictions, see Remarks.
        /// </summary>
        public UINT Width;

        /// <summary>
        /// The maximum number of mipmap levels in the texture.
        /// See the remarks in <see cref="D3D11_TEX1D_SRV"/>.
        /// Use 1 for a multisampled texture; or 0 to generate a full set of subtextures.
        /// </summary>
        public UINT MipLevels;

        /// <summary>
        /// Number of textures in the array.
        /// The range is from 1 to <see cref="D3D11_REQ_TEXTURE1D_ARRAY_AXIS_DIMENSION"/> (2048).
        /// However, the range is actually constrained by the feature level at which you create the rendering device.
        /// For more information about restrictions, see Remarks.
        /// </summary>
        public UINT ArraySize;

        /// <summary>
        /// Texture format (see <see cref="DXGI_FORMAT"/>).
        /// </summary>
        public DXGI_FORMAT Format;

        /// <summary>
        /// Value that identifies how the texture is to be read from and written to.
        /// The most common value is <see cref="D3D11_USAGE_DEFAULT"/>; see <see cref="D3D11_USAGE"/> for all possible values.
        /// </summary>
        public D3D11_USAGE Usage;

        /// <summary>
        /// Flags (see <see cref="D3D11_BIND_FLAG"/>) for binding to pipeline stages.
        /// The flags can be combined by a bitwise OR.
        /// For a 1D texture, the allowable values are: <see cref="D3D11_BIND_SHADER_RESOURCE"/>,
        /// <see cref="D3D11_BIND_RENDER_TARGET"/> and <see cref="D3D11_BIND_DEPTH_STENCIL"/>.
        /// </summary>
        public D3D11_BIND_FLAG BindFlags;

        /// <summary>
        /// Flags (see <see cref="D3D11_CPU_ACCESS_FLAG"/>) to specify the types of CPU access allowed.
        /// Use 0 if CPU access is not required.
        /// These flags can be combined with a bitwise OR.
        /// </summary>
        public D3D11_CPU_ACCESS_FLAG CPUAccessFlags;

        /// <summary>
        /// Flags (see <see cref="D3D11_RESOURCE_MISC_FLAG"/>) that identify other, less common resource options.
        /// Use 0 if none of these flags apply.
        /// These flags can be combined with a bitwise OR.
        /// </summary>
        public D3D11_RESOURCE_MISC_FLAG MiscFlags;
    }
}
