using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the context in which a query occurs.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/ne-d3d11_3-d3d11_context_type"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by the following:
    /// <see cref="D3D11_QUERY_DESC1"/> structure
    /// A CD3D11_QUERY_DESC1 constructor.
    /// <see cref="ID3D11DeviceContext3.Flush1"/> method
    /// </remarks>
    public enum D3D11_CONTEXT_TYPE
    {
        /// <summary>
        /// The query can occur in all contexts.
        /// </summary>
        D3D11_CONTEXT_TYPE_ALL = 0,

        /// <summary>
        /// The query occurs in the context of a 3D command queue.
        /// </summary>
        D3D11_CONTEXT_TYPE_3D = 1,

        /// <summary>
        /// The query occurs in the context of a 3D compute queue.
        /// </summary>
        D3D11_CONTEXT_TYPE_COMPUTE = 2,

        /// <summary>
        /// The query occurs in the context of a 3D copy queue.
        /// </summary>
        D3D11_CONTEXT_TYPE_COPY = 3,

        /// <summary>
        /// The query occurs in the context of video.
        /// </summary>
        D3D11_CONTEXT_TYPE_VIDEO = 4,
    }
}
