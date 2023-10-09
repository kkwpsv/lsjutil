using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Specifies the elements in a buffer resource to use in a render-target view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_buffer_rtv"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// A render-target view is a member of a render-target-view description (see <see cref="D3D11_RENDER_TARGET_VIEW_DESC"/>).
    /// Create a render-target view by calling <see cref="ID3D11Device.CreateRenderTargetView"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct D3D11_BUFFER_RTV
    {
        /// <summary>
        /// Number of bytes between the beginning of the buffer and the first element to access.
        /// </summary>
        [FieldOffset(0)]
        public UINT FirstElement;

        /// <summary>
        /// The offset of the first element in the view to access, relative to element 0.
        /// </summary>
        [FieldOffset(0)]
        public UINT ElementOffset;

        /// <summary>
        /// The total number of elements in the view.
        /// </summary>
        [FieldOffset(4)]
        public UINT NumElements;

        /// <summary>
        /// The width of each element (in bytes).
        /// This can be determined from the format stored in the render-target-view description.
        /// </summary>
        [FieldOffset(4)]
        public UINT ElementWidth;
    }
}
