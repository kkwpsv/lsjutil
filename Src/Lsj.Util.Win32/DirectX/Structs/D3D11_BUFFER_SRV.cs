using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Specifies the elements in a buffer resource to use in a shader-resource view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_buffer_srv"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="D3D11_BUFFER_SRV"/> structure is a member of the <see cref="D3D11_SHADER_RESOURCE_VIEW_DESC"/> structure,
    /// which represents a shader-resource view description.
    /// You can create a shader-resource view by calling the <see cref="ID3D11Device.CreateShaderResourceView"/> method.
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct D3D11_BUFFER_SRV
    {
        /// <summary>
        /// Index of the first element to access.
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
        /// This can be determined from the format stored in the shader-resource-view description.
        /// </summary>
        [FieldOffset(4)]
        public UINT ElementWidth;
    }
}
