using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Specifies data for initializing a subresource.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_subresource_data"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is used in calls to create buffers (<see cref="ID3D11Device.CreateBuffer"/>)
    /// and textures (<see cref="ID3D11Device.CreateTexture1D"/>, <see cref="ID3D11Device.CreateTexture2D"/>, and <see cref="ID3D11Device.CreateTexture3D"/>).
    /// If the resource you create does not require a system-memory pitch or a system-memory-slice pitch,
    /// you can use those members to pass size information, which might help you when you debug a problem with creating a resource.
    /// A subresource is a single mipmap-level surface.
    /// You can pass an array of subresources to one of the preceding methods to create the resource.
    /// A subresource can be 1D, 2D, or 3D.
    /// How you set the members of <see cref="D3D11_SUBRESOURCE_DATA"/> depend on whether the subresource is 1D, 2D, or 3D.
    /// The x, y, and d values are 0-based indices and BytesPerPixel depends on the pixel format.
    /// For mipmapped 3D surfaces, the number of depth slices in each level is half the number of the previous level (minimum 1)
    /// and rounded down if dividing by two results in a non-whole number.
    /// Note
    /// An application must not rely on <see cref="SysMemPitch"/> being exactly equal to the number of texels in a line times the size of a texel.
    /// In some cases, SysMemPitch will include padding to skip past additional data in a line.
    /// This could be padding for alignment or the texture could be a subsection of a larger texture.
    /// For example, the <see cref="D3D11_SUBRESOURCE_DATA"/> structure could represent a 32 by 32 subsection of a 128 by 128 texture.
    /// The value for <see cref="SysMemSlicePitch"/> will reflect any padding included in <see cref="SysMemPitch"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_SUBRESOURCE_DATA
    {
        /// <summary>
        /// Pointer to the initialization data.
        /// </summary>
        public IntPtr pSysMem;

        /// <summary>
        /// The distance (in bytes) from the beginning of one line of a texture to the next line.
        /// System-memory pitch is used only for 2D and 3D texture data as it is has no meaning for the other resource types.
        /// Specify the distance from the first pixel of one 2D slice of a 3D texture to the first pixel of the next 2D slice
        /// in that texture in the <see cref="SysMemSlicePitch"/> member.
        /// </summary>
        public UINT SysMemPitch;

        /// <summary>
        /// The distance (in bytes) from the beginning of one depth level to the next.
        /// System-memory-slice pitch is only used for 3D texture data as it has no meaning for the other resource types.
        /// </summary>
        public UINT SysMemSlicePitch;
    }
}
