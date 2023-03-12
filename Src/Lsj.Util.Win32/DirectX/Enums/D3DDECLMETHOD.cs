using Lsj.Util.Win32.DirectX.Structs;
using static Lsj.Util.Win32.DirectX.Enums.D3DDECLTYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3DDECLUSAGE;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines the vertex declaration method which is a predefined operation performed by the tessellator
    /// (or any procedural geometry routine on the vertex data during tessellation).
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3ddeclmethod"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The tessellator looks at the method to determine what data to calculate from the vertex data during tessellation.
    /// Mesh data should use the default value. Patches can use any of the other implemented types.
    /// Vertex data is declared with an array of <see cref="D3DVERTEXELEMENT9"/> structures.
    /// Each element in the array contains a vertex declaration method.
    /// In addition to using <see cref="D3DDECLMETHOD_DEFAULT"/>,
    /// a normal mesh can use <see cref="D3DDECLMETHOD_LOOKUP"/> and <see cref="D3DDECLMETHOD_LOOKUPPRESAMPLED"/> methods when N-patches are enabled.
    /// </remarks>
    public enum D3DDECLMETHOD : byte
    {
        /// <summary>
        /// Default value. The tessellator copies the vertex data (spline data for patches) as is, with no additional calculations.
        /// When the tessellator is used, this element is interpolated.
        /// Otherwise vertex data is copied into the input register.
        /// The input and output type can be any value, but are always the same type.
        /// </summary>
        D3DDECLMETHOD_DEFAULT = 0,

        /// <summary>
        /// Computes the tangent at a point on the rectangle or triangle patch in the U direction.
        /// The input type can be one of the following:
        /// <see cref="D3DDECLTYPE_D3DCOLOR"/>, <see cref="D3DDECLTYPE_FLOAT3"/>, <see cref="D3DDECLTYPE_FLOAT4"/>,
        /// <see cref="D3DDECLTYPE_SHORT4"/>, <see cref="D3DDECLTYPE_UBYTE4"/>
        /// The output type is always <see cref="D3DDECLTYPE_FLOAT3"/>.
        /// </summary>
        D3DDECLMETHOD_PARTIALU = 1,

        /// <summary>
        /// Computes the tangent at a point on the rectangle or triangle patch in the V direction.
        /// The input type can be one of the following:
        /// <see cref="D3DDECLTYPE_D3DCOLOR"/>, <see cref="D3DDECLTYPE_FLOAT3"/>, <see cref="D3DDECLTYPE_FLOAT4"/>,
        /// <see cref="D3DDECLTYPE_SHORT4"/>, <see cref="D3DDECLTYPE_UBYTE4"/>
        /// The output type is always <see cref="D3DDECLTYPE_FLOAT3"/>.
        /// </summary>
        D3DDECLMETHOD_PARTIALV = 2,

        /// <summary>
        /// Computes the normal at a point on the rectangle or triangle patch by taking the cross product of two tangents.
        /// The input type can be one of the following:
        /// <see cref="D3DDECLTYPE_D3DCOLOR"/>, <see cref="D3DDECLTYPE_FLOAT3"/>, <see cref="D3DDECLTYPE_FLOAT4"/>,
        /// <see cref="D3DDECLTYPE_SHORT4"/>, <see cref="D3DDECLTYPE_UBYTE4"/>
        /// The output type is always <see cref="D3DDECLTYPE_FLOAT3"/>.
        /// </summary>
        D3DDECLMETHOD_CROSSUV = 3,

        /// <summary>
        /// Copy out the U, V values at a point on the rectangle or triangle patch.
        /// This results in a 2D float.
        /// The input type must be set to <see cref="D3DDECLTYPE_UNUSED"/>.
        /// The output data type is always <see cref="D3DDECLTYPE_FLOAT2"/>.
        /// The input stream and offset are also unused (but must be set to 0).
        /// </summary>
        D3DDECLMETHOD_UV = 4,

        /// <summary>
        /// Look up a displacement map. The input type can be one of the following:
        /// <see cref="D3DDECLTYPE_FLOAT2"/>, <see cref="D3DDECLTYPE_FLOAT3"/>, <see cref="D3DDECLTYPE_FLOAT4"/>
        /// Only the .x and .y components are used for the texture map lookup.
        /// The output type is always <see cref="D3DDECLTYPE_FLOAT1"/>.
        /// The device must support displacement mapping.
        /// For more information about displacement mapping, see Displacement Mapping (Direct3D 9).
        /// This constant is supported only by the programmable pipeline on N-patch data, if N-patches are enabled.
        /// </summary>
        D3DDECLMETHOD_LOOKUP = 5,

        /// <summary>
        /// Look up a presampled displacement map.
        /// The input type must be set to <see cref="D3DDECLTYPE_UNUSED"/>; the stream index and the stream offset must be set to 0.
        /// The output type for this operation is always <see cref="D3DDECLTYPE_FLOAT1"/>.
        /// The device must support displacement mapping.
        /// For more information about displacement mapping, see Displacement Mapping (Direct3D 9).
        /// This constant is supported only by the programmable pipeline on N-patch data, if N-patches are enabled.
        /// This method can be used only with <see cref="D3DDECLUSAGE_SAMPLE"/>.
        /// </summary>
        D3DDECLMETHOD_LOOKUPPRESAMPLED = 6
    }
}
