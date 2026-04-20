using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the type of the indirect parameter.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_indirect_argument_type"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by the <see cref="D3D12_INDIRECT_ARGUMENT_DESC"/> structure.
    /// </remarks>
    public enum D3D12_INDIRECT_ARGUMENT_TYPE
    {
        /// <summary>
        /// Indicates the type is a Draw call.
        /// </summary>
        D3D12_INDIRECT_ARGUMENT_TYPE_DRAW = 0,

        /// <summary>
        /// Indicates the type is a DrawIndexed call.
        /// </summary>
        D3D12_INDIRECT_ARGUMENT_TYPE_DRAW_INDEXED = (D3D12_INDIRECT_ARGUMENT_TYPE_DRAW + 1),

        /// <summary>
        /// Indicates the type is a Dispatch call.
        /// </summary>
        D3D12_INDIRECT_ARGUMENT_TYPE_DISPATCH = (D3D12_INDIRECT_ARGUMENT_TYPE_DRAW_INDEXED + 1),

        /// <summary>
        /// Indicates the type is a vertex buffer view.
        /// </summary>
        D3D12_INDIRECT_ARGUMENT_TYPE_VERTEX_BUFFER_VIEW = (D3D12_INDIRECT_ARGUMENT_TYPE_DISPATCH + 1),

        /// <summary>
        /// Indicates the type is an index buffer view.
        /// </summary>
        D3D12_INDIRECT_ARGUMENT_TYPE_INDEX_BUFFER_VIEW = (D3D12_INDIRECT_ARGUMENT_TYPE_VERTEX_BUFFER_VIEW + 1),

        /// <summary>
        /// Indicates the type is a constant.
        /// </summary>
        D3D12_INDIRECT_ARGUMENT_TYPE_CONSTANT = (D3D12_INDIRECT_ARGUMENT_TYPE_INDEX_BUFFER_VIEW + 1),

        /// <summary>
        /// Indicates the type is a constant buffer view (CBV).
        /// </summary>
        D3D12_INDIRECT_ARGUMENT_TYPE_CONSTANT_BUFFER_VIEW = (D3D12_INDIRECT_ARGUMENT_TYPE_CONSTANT + 1),

        /// <summary>
        /// Indicates the type is a shader resource view (SRV).
        /// </summary>
        D3D12_INDIRECT_ARGUMENT_TYPE_SHADER_RESOURCE_VIEW = (D3D12_INDIRECT_ARGUMENT_TYPE_CONSTANT_BUFFER_VIEW + 1),

        /// <summary>
        /// Indicates the type is an unordered access view (UAV).
        /// </summary>
        D3D12_INDIRECT_ARGUMENT_TYPE_UNORDERED_ACCESS_VIEW = (D3D12_INDIRECT_ARGUMENT_TYPE_SHADER_RESOURCE_VIEW + 1),

        /// <summary>
        /// 
        /// </summary>
        D3D12_INDIRECT_ARGUMENT_TYPE_DISPATCH_RAYS = (D3D12_INDIRECT_ARGUMENT_TYPE_UNORDERED_ACCESS_VIEW + 1),

        /// <summary>
        /// 
        /// </summary>
        D3D12_INDIRECT_ARGUMENT_TYPE_DISPATCH_MESH = (D3D12_INDIRECT_ARGUMENT_TYPE_DISPATCH_RAYS + 1),

        /// <summary>
        /// 
        /// </summary>
        D3D12_INDIRECT_ARGUMENT_TYPE_INCREMENTING_CONSTANT = (D3D12_INDIRECT_ARGUMENT_TYPE_DISPATCH_MESH + 1)
    }
}
