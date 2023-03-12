using Lsj.Util.Win32.DirectX.BaseTypes;
using System;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Flexible Vertex Format Constants, or FVF codes, are used to describe the contents of vertices
    /// interleaved in a single data stream that will be processed by the fixed-function pipeline.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dfvf"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum D3DFVF : uint
    {
        /// <summary>
        /// Vertex format includes a diffuse color component.
        /// </summary>
        D3DFVF_DIFFUSE = 0x040,

        /// <summary>
        /// Vertex format includes a vertex normal vector.
        /// This flag cannot be used with the <see cref="D3DFVF_XYZRHW"/> flag.
        /// </summary>
        D3DFVF_NORMAL = 0x010,

        /// <summary>
        /// Vertex format specified in point size.
        /// This size is expressed in camera space units for vertices that are not transformed and lit,
        /// and in device-space units for transformed and lit vertices.
        /// </summary>
        D3DFVF_PSIZE = 0x020,

        /// <summary>
        /// Vertex format includes a specular color component.
        /// </summary>
        D3DFVF_SPECULAR = 0x080,

        /// <summary>
        /// Vertex format includes the position of an untransformed vertex.
        /// This flag cannot be used with the <see cref="D3DFVF_XYZRHW"/> flag.
        /// </summary>
        D3DFVF_XYZ = 0x002,

        /// <summary>
        /// Vertex format includes the position of a transformed vertex.
        /// This flag cannot be used with the <see cref="D3DFVF_XYZ"/> or <see cref="D3DFVF_NORMAL"/> flags.
        /// </summary>
        D3DFVF_XYZRHW = 0x004,

        /// <summary>
        /// 
        /// </summary>
        D3DFVF_XYZB1 = 0x006,

        /// <summary>
        /// Vertex format contains position data, and a corresponding number of weighting (beta) values to use for multimatrix vertex blending operations.
        /// Currently, Direct3D can blend with up to three weighting values and four blending matrices.
        /// For more information about using blending matrices, see Indexed Vertex Blending (Direct3D 9).
        /// </summary>
        D3DFVF_XYZB2 = 0x008,

        /// <summary>
        /// Vertex format contains position data, and a corresponding number of weighting (beta) values to use for multimatrix vertex blending operations.
        /// Currently, Direct3D can blend with up to three weighting values and four blending matrices.
        /// For more information about using blending matrices, see Indexed Vertex Blending (Direct3D 9).
        /// </summary>
        D3DFVF_XYZB3 = 0x00a,

        /// <summary>
        /// Vertex format contains position data, and a corresponding number of weighting (beta) values to use for multimatrix vertex blending operations.
        /// Currently, Direct3D can blend with up to three weighting values and four blending matrices.
        /// For more information about using blending matrices, see Indexed Vertex Blending (Direct3D 9).
        /// </summary>
        D3DFVF_XYZB4 = 0x00c,

        /// <summary>
        /// Vertex format contains position data, and a corresponding number of weighting (beta) values to use for multimatrix vertex blending operations.
        /// Currently, Direct3D can blend with up to three weighting values and four blending matrices.
        /// For more information about using blending matrices, see Indexed Vertex Blending (Direct3D 9).
        /// </summary>
        D3DFVF_XYZB5 = 0x00e,

        /// <summary>
        /// Vertex format contains transformed and clipped (x, y, z, w) data.
        /// ProcessVertices does not invoke the clipper, instead outputting data in clip coordinates.
        /// This constant is designed for, and can only be used with, the programmable vertex pipeline.
        /// </summary>
        D3DFVF_XYZW = 0x4002,

        /// <summary>
        /// Number of texture coordinate sets for this vertex.
        /// The actual values for these flags are not sequential.
        /// </summary>
        D3DFVF_TEX0 = 0x000,

        /// <summary>
        /// Number of texture coordinate sets for this vertex.
        /// The actual values for these flags are not sequential.
        /// </summary>
        D3DFVF_TEX1 = 0x100,

        /// <summary>
        /// Number of texture coordinate sets for this vertex.
        /// The actual values for these flags are not sequential.
        /// </summary>
        D3DFVF_TEX2 = 0x200,

        /// <summary>
        /// Number of texture coordinate sets for this vertex.
        /// The actual values for these flags are not sequential.
        /// </summary>
        D3DFVF_TEX3 = 0x300,

        /// <summary>
        /// Number of texture coordinate sets for this vertex.
        /// The actual values for these flags are not sequential.
        /// </summary>
        D3DFVF_TEX4 = 0x400,

        /// <summary>
        /// Number of texture coordinate sets for this vertex.
        /// The actual values for these flags are not sequential.
        /// </summary>
        D3DFVF_TEX5 = 0x500,

        /// <summary>
        /// Number of texture coordinate sets for this vertex.
        /// The actual values for these flags are not sequential.
        /// </summary>
        D3DFVF_TEX6 = 0x600,

        /// <summary>
        /// Number of texture coordinate sets for this vertex.
        /// The actual values for these flags are not sequential.
        /// </summary>
        D3DFVF_TEX7 = 0x700,

        /// <summary>
        /// Number of texture coordinate sets for this vertex.
        /// The actual values for these flags are not sequential.
        /// </summary>
        D3DFVF_TEX8 = 0x800,

        /// <summary>
        /// Mask for position bits.
        /// </summary>
        D3DFVF_POSITION_MASK = 0x400E,

        /// <summary>
        /// Mask values for reserved bits in the FVF.
        /// Do not use.
        /// </summary>
        D3DFVF_RESERVED0 = 0x001,

        /// <summary>
        /// Mask values for reserved bits in the FVF.
        /// Do not use.
        /// </summary>
        D3DFVF_RESERVED2 = 0x6000,

        /// <summary>
        /// Mask value for texture flag bits.
        /// </summary>
        D3DFVF_TEXCOUNT_MASK = 0xf00,

        /// <summary>
        /// The last beta field in the vertex position data will be of type <see cref="D3DCOLOR"/>.
        /// The data in the beta fields are used with matrix palette skinning to specify matrix indices.
        /// </summary>
        D3DFVF_LASTBETA_D3DCOLOR = 0x8000,

        /// <summary>
        /// The last beta field in the vertex position data will be of type UBYTE4.
        /// The data in the beta fields are used with matrix palette skinning to specify matrix indices.
        /// </summary>
        D3DFVF_LASTBETA_UBYTE4 = 0x1000,

        /// <summary>
        /// The number of bits by which to shift an integer value that identifies the number of texture coordinates for a vertex.
        /// This value might be used as shown below.
        /// </summary>
        D3DFVF_TEXCOUNT_SHIFT = 8,
    }
}
