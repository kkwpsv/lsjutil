namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// How the pipeline interprets vertex data that is bound to the input-assembler stage.
    /// These primitive topology values determine how the vertex data is rendered on screen.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d11/d3d11-primitive-topology"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="D3D11_PRIMITIVE_TOPOLOGY"/> enumeration is type defined in the D3D11.h header file
    /// as a <see cref="D3D_PRIMITIVE_TOPOLOGY"/> enumeration, which is fully defined in the D3DCommon.h header file.
    /// </remarks>
    public enum D3D11_PRIMITIVE_TOPOLOGY
    {
        /// <summary>
        /// The IA stage has not been initialized with a primitive topology.
        /// The IA stage will not function properly unless a primitive topology is defined.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_UNDEFINED = 0,

        /// <summary>
        /// Interpret the vertex data as a list of points.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_POINTLIST = 1,

        /// <summary>
        /// Interpret the vertex data as a list of lines.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_LINELIST = 2,

        /// <summary>
        /// Interpret the vertex data as a line strip.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_LINESTRIP = 3,

        /// <summary>
        /// Interpret the vertex data as a list of triangles.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST = 4,

        /// <summary>
        /// Interpret the vertex data as a triangle strip.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP = 5,

        /// <summary>
        /// Interpret the vertex data as list of lines with adjacency data.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_LINELIST_ADJ = 10,

        /// <summary>
        /// Interpret the vertex data as line strip with adjacency data.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_LINESTRIP_ADJ = 11,

        /// <summary>
        /// Interpret the vertex data as list of triangles with adjacency data.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST_ADJ = 12,

        /// <summary>
        /// Interpret the vertex data as triangle strip with adjacency data.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP_ADJ = 13,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_1_CONTROL_POINT_PATCHLIST = 33,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_2_CONTROL_POINT_PATCHLIST = 34,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_3_CONTROL_POINT_PATCHLIST = 35,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_4_CONTROL_POINT_PATCHLIST = 36,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_5_CONTROL_POINT_PATCHLIST = 37,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_6_CONTROL_POINT_PATCHLIST = 38,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_7_CONTROL_POINT_PATCHLIST = 39,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_8_CONTROL_POINT_PATCHLIST = 40,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_9_CONTROL_POINT_PATCHLIST = 41,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_10_CONTROL_POINT_PATCHLIST = 42,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_11_CONTROL_POINT_PATCHLIST = 43,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_12_CONTROL_POINT_PATCHLIST = 44,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_13_CONTROL_POINT_PATCHLIST = 45,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_14_CONTROL_POINT_PATCHLIST = 46,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_15_CONTROL_POINT_PATCHLIST = 47,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_16_CONTROL_POINT_PATCHLIST = 48,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_17_CONTROL_POINT_PATCHLIST = 49,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_18_CONTROL_POINT_PATCHLIST = 50,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_19_CONTROL_POINT_PATCHLIST = 51,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_20_CONTROL_POINT_PATCHLIST = 52,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_21_CONTROL_POINT_PATCHLIST = 53,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_22_CONTROL_POINT_PATCHLIST = 54,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_23_CONTROL_POINT_PATCHLIST = 55,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_24_CONTROL_POINT_PATCHLIST = 56,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_25_CONTROL_POINT_PATCHLIST = 57,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_26_CONTROL_POINT_PATCHLIST = 58,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_27_CONTROL_POINT_PATCHLIST = 59,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_28_CONTROL_POINT_PATCHLIST = 60,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_29_CONTROL_POINT_PATCHLIST = 61,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_30_CONTROL_POINT_PATCHLIST = 62,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_31_CONTROL_POINT_PATCHLIST = 63,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        D3D11_PRIMITIVE_TOPOLOGY_32_CONTROL_POINT_PATCHLIST = 64,
    }
}
