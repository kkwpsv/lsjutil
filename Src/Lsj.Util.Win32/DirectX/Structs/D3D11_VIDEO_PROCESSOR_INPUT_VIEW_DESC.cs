using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a video processor input view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_video_processor_input_view_desc"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_VIDEO_PROCESSOR_INPUT_VIEW_DESC
    {
        /// <summary>
        /// The surface format.
        /// If zero, the driver uses the DXGI format that was used to create the resource.
        /// If you are using feature level 9, the value must be zero.
        /// </summary>
        public UINT FourCC;

        /// <summary>
        /// The resource type of the view, specified as a member of the <see cref="D3D11_VPIV_DIMENSION"/> enumeration.
        /// </summary>
        public D3D11_VPIV_DIMENSION ViewDimension;

        /// <summary>
        /// A <see cref="D3D11_TEX2D_VPIV"/> structure that identifies the texture resource.
        /// </summary>
        public D3D11_TEX2D_VPIV Texture2D;
    }
}
