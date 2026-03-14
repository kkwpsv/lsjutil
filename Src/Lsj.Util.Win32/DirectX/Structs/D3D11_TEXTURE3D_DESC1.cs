using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.DirectX.D3D11;
using static Lsj.Util.Win32.DirectX.Enums.D3D_FEATURE_LEVEL;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_TEXTURE_LAYOUT;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_USAGE;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a 3D texture.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/ns-d3d11_3-d3d11_texture3d_desc1"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This structure is used in a call to <see cref="ID3D11Device3.CreateTexture3D1"/>.
    /// </para>
    /// <para>
    /// In addition to this structure, you can also use the CD3D11_TEXTURE3D_DESC1 derived structure,
    /// which is defined in D3D11_3.h and behaves like an inherited class, to help create a texture description.
    /// </para>
    /// <para>
    /// The device restricts the size of subsampled, block compressed,
    /// and bit format resources to be multiples of sizes specific to each format.
    /// </para>
    /// <para>
    /// The texture size range is determined by the feature level
    /// at which you create the device and not the Microsoft Direct3D interface version.
    /// For example, if you use Microsoft Direct3D 10 hardware at feature level 10 (<see cref="D3D_FEATURE_LEVEL_10_0"/>)
    /// and call <see cref="D3D11CreateDevice"/> to create an <see cref="ID3D11Device"/>,
    /// you must constrain the maximum texture size to <see cref="D3D10_REQ_TEXTURE3D_U_V_OR_W_DIMENSION"/> (2048)
    /// when you create your 3D texture.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_TEXTURE3D_DESC1
    {
        /// <summary>
        /// Texture width (in texels).
        /// The range is from 1 to <see cref="D3D11_REQ_TEXTURE3D_U_V_OR_W_DIMENSION"/> (2048).
        /// However, the range is actually constrained by the feature level at which you create the rendering device.
        /// For more information about restrictions, see Remarks.
        /// </summary>
        public UINT Width;

        /// <summary>
        /// Texture height (in texels).
        /// The range is from 1 to <see cref="D3D11_REQ_TEXTURE3D_U_V_OR_W_DIMENSION"/> (2048).
        /// However, the range is actually constrained by the feature level at which you create the rendering device.
        /// For more information about restrictions, see Remarks.
        /// </summary>
        public UINT Height;

        /// <summary>
        /// Texture depth (in texels).
        /// The range is from 1 to <see cref="D3D11_REQ_TEXTURE3D_U_V_OR_W_DIMENSION"/> (2048).
        /// However, the range is actually constrained by the feature level at which you create the rendering device.
        /// For more information about restrictions, see Remarks.
        /// </summary>
        public UINT Depth;

        /// <summary>
        /// The maximum number of mipmap levels in the texture.
        /// See the remarks in <see cref="D3D11_TEX1D_SRV"/>.
        /// Use 1 for a multisampled texture; or 0 to generate a full set of subtextures.
        /// </summary>
        public UINT MipLevels;

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

        /// <summary>
        /// <para>
        /// A <see cref="D3D11_TEXTURE_LAYOUT"/>-typed value that identifies the layout of the texture.
        /// </para>
        /// <para>
        /// The <see cref="TextureLayout"/> parameter selects both the actual layout of the texture in memory
        /// and the layout visible to the application while the texture is mapped.
        /// These flags may not be requested without CPU access also requested.
        /// </para>
        /// <para>
        /// It is illegal to set CPU access flags on default textures
        /// without also setting Layout to a value other than <see cref="D3D11_TEXTURE_LAYOUT_UNDEFINED"/>.
        /// </para>
        /// <para>
        /// <see cref="D3D11_TEXTURE_LAYOUT_ROW_MAJOR"/> may not be used with 3D textures.
        /// <see cref="D3D11_TEXTURE_LAYOUT_64K_STANDARD_SWIZZLE"/> may not be used with 3D textures that have mipmaps.
        /// </para>
        /// </summary>
        public D3D11_TEXTURE_LAYOUT TextureLayout;
    }
}
