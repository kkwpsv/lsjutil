using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.D3DBASISTYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3DDEGREETYPE;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a triangular high-order patch.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dtripatch-info"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// For example, the following diagram identifies the vertex order and segment numbers for a cubic Bézier triangle patch.
    /// The vertex order determines the segment numbers used by <see cref="IDirect3DDevice9.DrawTriPatch"/>.
    /// The offset is the number of bytes to the first triangle patch vertex in the vertex buffer.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3DTRIPATCH_INFO
    {
        /// <summary>
        /// Starting vertex offset, in number of vertices.
        /// </summary>
        public UINT StartVertexOffset;

        /// <summary>
        /// Number of vertices.
        /// </summary>
        public UINT NumVertices;

        /// <summary>
        /// Member of the <see cref="D3DBASISTYPE"/> enumerated type, which defines the basis type for the triangular high-order patch.
        /// The only valid value for this member is <see cref="D3DBASIS_BEZIER"/>.
        /// </summary>
        public D3DBASISTYPE Basis;

        /// <summary>
        /// Member of the <see cref="D3DDEGREETYPE"/> enumerated type, defining the degree type for the triangular high-order patch.
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Number of vertices
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="D3DDEGREE_CUBIC"/>
        /// </term>
        /// <term>
        /// 10
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DDEGREE_LINEAR"/>
        /// </term>
        /// <term>
        /// 3
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DDEGREE_QUADRATIC"/>
        /// </term>
        /// <term>
        /// N/A
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DDEGREE_QUINTIC"/>
        /// </term>
        /// <term>
        /// 21
        /// </term>
        /// </item>
        /// </list>
        /// N/A - Not available. Not supported.
        /// </summary>
        public D3DDEGREETYPE Degree;
    }
}
