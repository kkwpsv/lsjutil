using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_VPOV_DIMENSION;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a video processor output view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_video_processor_output_view_desc"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct D3D11_VIDEO_PROCESSOR_OUTPUT_VIEW_DESC
    {
        /// <summary>
        /// The resource type of the view, specified as a member of the <see cref="D3D11_VPOV_DIMENSION"/> enumeration.
        /// </summary>
        [FieldOffset(0)]
        public D3D11_VPOV_DIMENSION ViewDimension;

        /// <summary>
        /// <para>
        /// A <see cref="D3D11_TEX2D_VPOV"/> structure that identifies the texture resource for the output view.
        /// </para>
        /// <para>
        /// Use this member of the union when <see cref="ViewDimension"/> equals <see cref="D3D11_VPOV_DIMENSION_TEXTURE2D"/>.
        /// </para>
        /// </summary>
        [FieldOffset(4)]
        public D3D11_TEX2D_VPOV Texture2D;

        /// <summary>
        /// <para>
        /// A <see cref="D3D11_TEX2D_ARRAY_VPOV"/> structure that identifies the texture array for the output view.
        /// </para>
        /// <para>
        /// Use this member of the union when <see cref="ViewDimension"/> equals <see cref="D3D11_VPOV_DIMENSION_TEXTURE2DARRAY"/>.
        /// </para>
        /// </summary>
        [FieldOffset(4)]
        public D3D11_TEX2D_ARRAY_VPOV Texture2DArray;
    }
}
