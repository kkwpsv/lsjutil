using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a rectangular high-order patch.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3drectpatch-info"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The following diagram identifies the parameters that specify a rectangle patch.
    /// Each of the vertices in the vertex buffer is shown as a black dot.
    /// In this case, the vertex buffer has 20 vertices in it, 16 of which are in the rectangle patch.
    /// The stride is the number of vertices in the width of the vertex buffer, in this case five.
    /// The x offset to the first vertex is called the StartIndexVertexWidth and is in this case 1.
    /// The y offset to the first patch vertex is called the StartIndexVertexHeight and is in this case 0.
    /// To render a stream of individual rectangular patches (non-mosaic), you should interpret your geometry as a long narrow (1 x N) rectangular patch.
    /// The <see cref="D3DRECTPATCH_INFO"/> structure for such a strip (cubic Bézier) would be set up in the following manner.
    /// <code>
    /// D3DRECTPATCH_INFO RectInfo;
    /// 
    /// RectInfo.Width = 4;
    /// RectInfo.Height = 4;
    /// RectInfo.Stride = 4;
    /// RectInfo.Basis = D3DBASIS_BEZIER;
    /// RectInfo.Order = D3DORDER_CUBIC;
    /// RectInfo.StartVertexOffsetWidth = 0;
    /// RectInfo.StartVertexOffsetHeight = 4*i;  // The variable i is the index of the 
    ///                                          //   patch you want to render.
    /// </code>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3DRECTPATCH_INFO
    {
        /// <summary>
        /// Starting vertex offset width, in number of vertices.
        /// </summary>
        public UINT StartVertexOffsetWidth;

        /// <summary>
        /// Starting vertex offset height, in number of vertices.
        /// </summary>
        public UINT StartVertexOffsetHeight;

        /// <summary>
        /// Width of each vertex, in number of vertices.
        /// </summary>
        public UINT Width;

        /// <summary>
        /// Height of each vertex, in number of vertices.
        /// </summary>
        public UINT Height;

        /// <summary>
        /// Width of the imaginary two-dimensional vertex array, which occupies the same space as the vertex buffer.
        /// For an example, see the diagram below.
        /// </summary>
        public UINT Stride;

        /// <summary>
        /// Member of the <see cref="D3DBASISTYPE"/> enumerated type, defining the basis type for the rectangular high-order patch.
        /// Value                               Order supported             Width and height
        /// <see cref="D3DBASIS_BEZIER"/>       Linear, cubic, and quintic  Width = height = (DWORD)order + 1
        /// <see cref="D3DBASIS_BSPLINE"/>      Linear, cubic, and quintic  Width = height > (DWORD)order
        /// <see cref="D3DBASIS_INTERPOLATE"/>  Cubic                       Width = height > (DWORD) order
        /// </summary>
        public D3DBASISTYPE Basis;

        /// <summary>
        /// Member of the <see cref="D3DDEGREETYPE"/> enumerated type, defining the degree for the rectangular patch.
        /// </summary>
        public D3DDEGREETYPE Degree;
    }
}
