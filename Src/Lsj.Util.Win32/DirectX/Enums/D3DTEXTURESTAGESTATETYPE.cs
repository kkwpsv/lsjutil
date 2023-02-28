using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Texture stage states define multi-blender texture operations.
    /// Some sampler states set up vertex processing, and some set up pixel processing.
    /// Texture stage states can be saved and restored using stateblocks (see State Blocks Save and Restore State (Direct3D 9)).
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dtexturestagestatetype"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Members of this enumerated type are used with the <see cref="IDirect3DDevice9.GetTextureStageState"/>
    /// and <see cref="IDirect3DDevice9.SetTextureStageState"/> methods to retrieve and set texture state values.
    /// The valid range of values for the <see cref="D3DTSS_BUMPENVMAT00"/>, <see cref="D3DTSS_BUMPENVMAT01"/>, <see cref="D3DTSS_BUMPENVMAT10"/>,
    /// and <see cref="D3DTSS_BUMPENVMAT11"/> bump-mapping matrix coefficients is greater than or equal to -8.0 and less than 8.0.
    /// This range, expressed in mathematical notation is (-8.0,8.0).
    /// </remarks>
    public enum D3DTEXTURESTAGESTATETYPE
    {
        /// <summary>
        /// Texture-stage state is a texture color blending operation identified by one member of the <see cref="D3DTEXTUREOP"/> enumerated type.
        /// The default value for the first texture stage (stage 0) is <see cref="D3DTOP_MODULATE"/>;
        /// for all other stages the default is <see cref="D3DTOP_DISABLE"/>.
        /// </summary>
        D3DTSS_COLOROP = 1,

        /// <summary>
        /// Texture-stage state is the first color argument for the stage, identified by one of the <see cref="D3DTA"/>.
        /// The default argument is <see cref="D3DTA_TEXTURE"/>.
        /// Specify <see cref="D3DTA_TEMP"/> to select a temporary register color for read or write.
        /// <see cref="D3DTA_TEMP"/> is supported if the <see cref="D3DPMISCCAPS_TSSARGTEMP"/> device capability is present.
        /// The default value for the register is (0.0, 0.0, 0.0, 0.0).
        /// </summary>
        D3DTSS_COLORARG1 = 2,

        /// <summary>
        /// Texture-stage state is the second color argument for the stage, identified by <see cref="D3DTA"/>.
        /// The default argument is <see cref="D3DTA_CURRENT"/>.
        /// Specify <see cref="D3DTA_TEMP"/> to select a temporary register color for read or write.
        /// <see cref="D3DTA_TEMP"/> is supported if the <see cref="D3DPMISCCAPS_TSSARGTEMP"/> device capability is present.
        /// The default value for the register is (0.0, 0.0, 0.0, 0.0)
        /// </summary>
        D3DTSS_COLORARG2 = 3,

        /// <summary>
        /// Texture-stage state is a texture alpha blending operation identified by one member of the <see cref="D3DTEXTUREOP"/> enumerated type.
        /// The default value for the first texture stage (stage 0) is <see cref="D3DTOP_SELECTARG1"/>,
        /// and for all other stages the default is <see cref="D3DTOP_DISABLE"/>.
        /// </summary>
        D3DTSS_ALPHAOP = 4,

        /// <summary>
        /// Texture-stage state is the first alpha argument for the stage, identified by by <see cref="D3DTA"/>.
        /// The default argument is <see cref="D3DTA_TEXTURE"/>.
        /// If no texture is set for this stage, the default argument is <see cref="D3DTA_DIFFUSE"/>.
        /// Specify <see cref="D3DTA_TEMP"/> to select a temporary register color for read or write.
        /// <see cref="D3DTA_TEMP"/> is supported if the <see cref="D3DPMISCCAPS_TSSARGTEMP"/> device capability is present.
        /// The default value for the register is (0.0, 0.0, 0.0, 0.0).
        /// </summary>
        D3DTSS_ALPHAARG1 = 5,

        /// <summary>
        /// Texture-stage state is the second alpha argument for the stage, identified by by <see cref="D3DTA"/>.
        /// The default argument is <see cref="D3DTA_CURRENT"/>.
        /// Specify <see cref="D3DTA_TEMP"/> to select a temporary register color for read or write.
        /// <see cref="D3DTA_TEMP"/> is supported if the <see cref="D3DPMISCCAPS_TSSARGTEMP"/> device capability is present.
        /// The default value for the register is (0.0, 0.0, 0.0, 0.0).
        /// </summary>
        D3DTSS_ALPHAARG2 = 6,

        /// <summary>
        /// Texture-stage state is a floating-point value for the [0][0] coefficient in a bump-mapping matrix.
        /// The default value is 0.0.
        /// </summary>
        D3DTSS_BUMPENVMAT00 = 7,

        /// <summary>
        /// Texture-stage state is a floating-point value for the [0][1] coefficient in a bump-mapping matrix.
        /// The default value is 0.0.
        /// </summary>
        D3DTSS_BUMPENVMAT01 = 8,

        /// <summary>
        /// Texture-stage state is a floating-point value for the [1][0] coefficient in a bump-mapping matrix.
        /// The default value is 0.0.
        /// </summary>
        D3DTSS_BUMPENVMAT10 = 9,

        /// <summary>
        /// Texture-stage state is a floating-point value for the [1][1] coefficient in a bump-mapping matrix.
        /// The default value is 0.0.
        /// </summary>
        D3DTSS_BUMPENVMAT11 = 10,

        /// <summary>
        /// Index of the texture coordinate set to use with this texture stage.
        /// You can specify up to eight sets of texture coordinates per vertex.
        /// If a vertex does not include a set of texture coordinates at the specified index, the system defaults to the u and v coordinates (0,0).
        /// When rendering using vertex shaders, each stage's texture coordinate index must be set to its default value.
        /// The default index for each stage is equal to the stage index.
        /// Set this state to the zero-based index of the coordinate set for each vertex that this texture stage uses.
        /// Additionally, applications can include, as logical OR with the index being set,
        /// one of the constants to request that Direct3D automatically generate the input texture coordinates for a texture transformation.
        /// For a list of all the constants, see <see cref="D3DTSS_TCI"/>.
        /// With the exception of <see cref="D3DTSS_TCI_PASSTHRU"/>, which resolves to zero,
        /// if any of the following values is included with the index being set, the system uses the index strictly to determine texture wrapping mode.
        /// These flags are most useful when performing environment mapping.
        /// </summary>
        D3DTSS_TEXCOORDINDEX = 11,

        /// <summary>
        /// Floating-point scale value for bump-map luminance.
        /// The default value is 0.0.
        /// </summary>
        D3DTSS_BUMPENVLSCALE = 22,

        /// <summary>
        /// Floating-point offset value for bump-map luminance.
        /// The default value is 0.0.
        /// </summary>
        D3DTSS_BUMPENVLOFFSET = 23,

        /// <summary>
        /// Member of the <see cref="D3DTEXTURETRANSFORMFLAGS"/> enumerated type that controls the transformation of texture coordinates for this texture stage.
        /// The default value is <see cref="D3DTTFF_DISABLE"/>.
        /// </summary>
        D3DTSS_TEXTURETRANSFORMFLAGS = 24,

        /// <summary>
        /// Settings for the third color operand for triadic operations (multiply, add, and linearly interpolate), identified by <see cref="D3DTA"/>.
        /// This setting is supported if the <see cref="D3DTEXOPCAPS_MULTIPLYADD"/> or <see cref="D3DTEXOPCAPS_LERP"/> device capabilities are present.
        /// The default argument is <see cref="D3DTA_CURRENT"/>.
        /// Specify <see cref="D3DTA_TEMP"/> to select a temporary register color for read or write.
        /// <see cref="D3DTA_TEMP"/> is supported if the <see cref="D3DPMISCCAPS_TSSARGTEMP"/> device capability is present.
        /// The default value for the register is (0.0, 0.0, 0.0, 0.0).
        /// </summary>
        D3DTSS_COLORARG0 = 26,

        /// <summary>
        /// Settings for the alpha channel selector operand for triadic operations (multiply, add, and linearly interpolate), identified by <see cref="D3DTA"/>.
        /// This setting is supported if the <see cref="D3DTEXOPCAPS_MULTIPLYADD"/> or <see cref="D3DTEXOPCAPS_LERP"/> device capabilities are present.
        /// The default argument is <see cref="D3DTA_CURRENT"/>.
        /// Specify <see cref="D3DTA_TEMP"/> to select a temporary register color for read or write.
        /// <see cref="D3DTA_TEMP"/> is supported if the <see cref="D3DPMISCCAPS_TSSARGTEMP"/> device capability is present.
        /// The default argument is (0.0, 0.0, 0.0, 0.0).
        /// </summary>
        D3DTSS_ALPHAARG0 = 27,

        /// <summary>
        /// Setting to select destination register for the result of this stage, identified by <see cref="D3DTA"/>.
        /// This value can be set to <see cref="D3DTA_CURRENT"/> (the default value) or to <see cref="D3DTA_TEMP"/>,
        /// which is a single temporary register that can be read into subsequent stages as an input argument.
        /// The final color passed to the fog blender and frame buffer is taken from <see cref="D3DTA_CURRENT"/>,
        /// so the last active texture stage state must be set to write to current.
        /// This setting is supported if the <see cref="D3DPMISCCAPS_TSSARGTEMP"/> device capability is present.
        /// </summary>
        D3DTSS_RESULTARG = 28,

        /// <summary>
        /// Per-stage constant color.
        /// To see if a device supports a per-stage constant color, see the <see cref="D3DPMISCCAPS_PERSTAGECONSTANT"/> constant in <see cref="D3DPMISCCAPS"/>.
        /// <see cref="D3DTSS_CONSTANT"/> is used by <see cref="D3DTA_CONSTANT"/>. See D3DTA.
        /// </summary>
        D3DTSS_CONSTANT = 32,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// This value is not used.
        /// </summary>
        D3DTSS_FORCE_DWORD = 0x7fffffff
    }
}
