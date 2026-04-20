using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies how the pipeline interprets geometry or hull shader input primitives.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_primitive_topology_type"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by the <see cref="D3D12_GRAPHICS_PIPELINE_STATE_DESC"/> structure.
    /// </remarks>
    public enum D3D12_PRIMITIVE_TOPOLOGY_TYPE
    {
        /// <summary>
        /// The shader has not been initialized with an input primitive type.
        /// </summary>
        D3D12_PRIMITIVE_TOPOLOGY_TYPE_UNDEFINED = 0,

        /// <summary>
        /// Interpret the input primitive as a point.
        /// </summary>
        D3D12_PRIMITIVE_TOPOLOGY_TYPE_POINT = 1,

        /// <summary>
        /// Interpret the input primitive as a line.
        /// </summary>
        D3D12_PRIMITIVE_TOPOLOGY_TYPE_LINE = 2,

        /// <summary>
        /// Interpret the input primitive as a triangle.
        /// </summary>
        D3D12_PRIMITIVE_TOPOLOGY_TYPE_TRIANGLE = 3,

        /// <summary>
        /// Interpret the input primitive as a control point patch.
        /// </summary>
        D3D12_PRIMITIVE_TOPOLOGY_TYPE_PATCH = 4
    }
}
