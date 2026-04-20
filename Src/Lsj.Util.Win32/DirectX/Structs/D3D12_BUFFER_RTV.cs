using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the elements in a buffer resource to use in a render-target view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_buffer_rtv"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Use this structure with a <see cref="D3D12_RENDER_TARGET_VIEW_DESC"/> structure to view the resource as a buffer.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_BUFFER_RTV
    {
        /// <summary>
        /// Number of elements between the beginning of the buffer and the first element to access.
        /// </summary>
        public UINT64 FirstElement;

        /// <summary>
        /// The total number of elements in the view.
        /// </summary>
        public UINT NumElements;
    }
}
