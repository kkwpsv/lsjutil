using System;
using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3DRENDERSTATETYPE;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines flags used to control the number or matrices that the system applies when performing multimatrix vertex blending.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dvertexblendflags"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Members of this type are used with the <see cref="D3DRS_VERTEXBLEND"/> render state.
    /// </para>
    /// <para>
    /// Geometry blending (multimatrix vertex blending) requires
    /// that your application use a vertex format that has blending (beta) weights for each vertex.
    /// </para>
    /// </remarks>
    [Flags]
    public enum D3DVERTEXBLENDFLAGS : uint
    {
        /// <summary>
        /// Disable vertex blending; apply only the world matrix set by the <see cref="D3DTS_WORLDMATRIX"/> macro,
        /// where the index value for the transformation state is 0.
        /// </summary>
        D3DVBF_DISABLE = 0,

        /// <summary>
        /// Enable vertex blending between the two matrices set by the <see cref="D3DTS_WORLDMATRIX"/> macro,
        /// where the index value for the transformation states are 0 and 1.
        /// </summary>
        D3DVBF_1WEIGHTS = 1,

        /// <summary>
        /// Enable vertex blending between the three matrices set by the <see cref="D3DTS_WORLDMATRIX"/> macro,
        /// where the index value for the transformation states are 0, 1, and 2.
        /// </summary>
        D3DVBF_2WEIGHTS = 2,

        /// <summary>
        /// Enable vertex blending between the four matrices set by the <see cref="D3DTS_WORLDMATRIX"/> macro,
        /// where the index value for the transformation states are 0, 1, 2, and 3.
        /// </summary>
        D3DVBF_3WEIGHTS = 3,

        /// <summary>
        /// Vertex blending is done by using the value assigned to <see cref="D3DRS_TWEENFACTOR"/>.
        /// </summary>
        D3DVBF_TWEENING = 255,

        /// <summary>
        /// Use a single matrix with a weight of 1.0.
        /// </summary>
        D3DVBF_0WEIGHTS = 256
    }
}
