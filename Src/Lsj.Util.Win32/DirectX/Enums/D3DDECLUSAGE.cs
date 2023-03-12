using Lsj.Util.Win32.DirectX.Structs;
using static Lsj.Util.Win32.DirectX.Enums.D3DDECLTYPE;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Identifies the intended use of vertex data.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3ddeclusage"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// VVertex data is declared with an array of <see cref="D3DVERTEXELEMENT9"/> structures.
    /// Each element in the array contains a usage type.
    /// For more information about vertex declarations, see Vertex Declaration (Direct3D 9).
    /// </remarks>
    public enum D3DDECLUSAGE : byte
    {
        /// <summary>
        /// Position data ranging from (-1,-1) to (1,1).
        /// Use <see cref="D3DDECLUSAGE_POSITION"/> with a usage index of 0
        /// to specify untransformed position for fixed function vertex processing and the n-patch tessellator.
        /// Use <see cref="D3DDECLUSAGE_POSITION"/> with a usage index of 1 to specify untransformed position
        /// in the fixed function vertex shader for vertex tweening.
        /// </summary>
        D3DDECLUSAGE_POSITION = 0,

        /// <summary>
        /// Blending weight data.
        /// Use <see cref="D3DDECLUSAGE_BLENDWEIGHT"/> with a usage index of 0 to specify the blend weights used in indexed and nonindexed vertex blending.
        /// </summary>
        D3DDECLUSAGE_BLENDWEIGHT = 1,

        /// <summary>
        /// Blending indices data.
        /// Use <see cref="D3DDECLUSAGE_BLENDINDICES"/> with a usage index of 0 to specify matrix indices for indexed paletted skinning.
        /// </summary>
        D3DDECLUSAGE_BLENDINDICES = 2,

        /// <summary>
        /// Vertex normal data.
        /// Use <see cref="D3DDECLUSAGE_NORMAL"/> with a usage index of 0
        /// to specify vertex normals for fixed function vertex processing and the n-patch tessellator.
        /// Use <see cref="D3DDECLUSAGE_NORMAL"/> with a usage index of 1
        /// to specify vertex normals for fixed function vertex processing for vertex tweening.
        /// </summary>
        D3DDECLUSAGE_NORMAL = 3,

        /// <summary>
        /// Point size data.
        /// Use <see cref="D3DDECLUSAGE_PSIZE"/> with a usage index of 0
        /// to specify the point-size attribute used by the setup engine of the rasterizer to expand a point into a quad for the point-sprite functionality.
        /// </summary>
        D3DDECLUSAGE_PSIZE = 4,

        /// <summary>
        /// Texture coordinate data.
        /// Use <see cref="D3DDECLUSAGE_TEXCOORD"/>, n to specify texture coordinates in fixed function vertex processing and in pixel shaders prior to ps_3_0.
        /// These can be used to pass user defined data.
        /// </summary>
        D3DDECLUSAGE_TEXCOORD = 5,

        /// <summary>
        /// Vertex tangent data.
        /// </summary>
        D3DDECLUSAGE_TANGENT = 6,

        /// <summary>
        /// Vertex binormal data.
        /// </summary>
        D3DDECLUSAGE_BINORMAL = 7,

        /// <summary>
        /// Single positive floating point value.
        /// Use <see cref="D3DDECLUSAGE_TESSFACTOR"/> with a usage index of 0
        /// to specify a tessellation factor used in the tessellation unit to control the rate of tessellation.
        /// For more information about the data type, see <see cref="D3DDECLTYPE_FLOAT1"/>.
        /// </summary>
        D3DDECLUSAGE_TESSFACTOR = 8,

        /// <summary>
        /// Vertex data contains transformed position data ranging from (0,0) to (viewport width, viewport height).
        /// Use <see cref="D3DDECLUSAGE_POSITIONT"/> with a usage index of 0 to specify transformed position.
        /// When a declaration containing this is set, the pipeline does not perform vertex processing.
        /// </summary>
        D3DDECLUSAGE_POSITIONT = 9,

        /// <summary>
        /// Vertex data contains diffuse or specular color.
        /// Use <see cref="D3DDECLUSAGE_COLOR"/> with a usage index of 0
        /// to specify the diffuse color in the fixed function vertex shader and pixel shaders prior to ps_3_0.
        /// Use <see cref="D3DDECLUSAGE_COLOR"/> with a usage index of 1
        /// to specify the specular color in the fixed function vertex shader and pixel shaders prior to ps_3_0.
        /// </summary>
        D3DDECLUSAGE_COLOR = 10,

        /// <summary>
        /// Vertex data contains fog data.
        /// Use <see cref="D3DDECLUSAGE_FOG"/> with a usage index of 0 to specify a fog blend value used after pixel shading finishes.
        /// This applies to pixel shaders prior to version ps_3_0.
        /// </summary>
        D3DDECLUSAGE_FOG = 11,

        /// <summary>
        /// Vertex data contains depth data.
        /// </summary>
        D3DDECLUSAGE_DEPTH = 12,

        /// <summary>
        /// Vertex data contains sampler data.
        /// Use <see cref="D3DDECLUSAGE_SAMPLE"/> with a usage index of 0 to specify the displacement value to look up.
        /// It can be used only with D3DDECLUSAGE_LOOKUPPRESAMPLED or D3DDECLUSAGE_LOOKUP.
        /// </summary>
        D3DDECLUSAGE_SAMPLE = 13,
    }
}
