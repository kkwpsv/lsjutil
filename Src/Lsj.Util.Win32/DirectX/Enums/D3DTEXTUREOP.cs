using Lsj.Util.Win32.DirectX.ComInterfaces;
using static Lsj.Util.Win32.DirectX.Enums.D3DTA;
using static Lsj.Util.Win32.DirectX.Enums.D3DTEXTURESTAGESTATETYPE;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines per-stage texture-blending operations.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dtextureop"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The members of this type are used when setting color or alpha operations
    /// by using the <see cref="D3DTSS_COLOROP"/> or <see cref="D3DTSS_ALPHAOP"/> values with the <see cref="IDirect3DDevice9.SetTextureStageState"/> method.
    /// In the above formulas, SRGBA is the RGBA color produced by a texture operation, and Arg1, Arg2, and Arg3 represent the complete RGBA color of the texture arguments.
    /// Individual components of an argument are shown with subscripts.
    /// For example, the alpha component for argument 1 would be shown as Arg1A.
    /// </remarks>
    public enum D3DTEXTUREOP
    {
        /// <summary>
        /// Disables output from this texture stage and all stages with a higher index.
        /// To disable texture mapping, set this as the color operation for the first texture stage (stage 0).
        /// Alpha operations cannot be disabled when color operations are enabled.
        /// Setting the alpha operation to <see cref="D3DTOP_DISABLE"/> when color blending is enabled causes undefined behavior.
        /// </summary>
        D3DTOP_DISABLE = 1,

        /// <summary>
        /// Use this texture stage's first color or alpha argument, unmodified, as the output.
        /// This operation affects the color argument when used with the <see cref="D3DTSS_COLOROP"/> texture-stage state,
        /// and the alpha argument when used with <see cref="D3DTSS_ALPHAOP"/>.
        /// equation of this argument (s(rgba) = arg1)
        /// </summary>
        D3DTOP_SELECTARG1 = 2,

        /// <summary>
        /// Use this texture stage's second color or alpha argument, unmodified, as the output.
        /// This operation affects the color argument when used with the <see cref="D3DTSS_COLOROP"/> texture stage state,
        /// and the alpha argument when used with <see cref="D3DTSS_ALPHAOP"/>.
        /// equation of this argument (s(rgba) = arg2)
        /// </summary>
        D3DTOP_SELECTARG2 = 3,

        /// <summary>
        /// Multiply the components of the arguments.
        /// equation of the modulate operation (s(rgba) = arg1 x arg 2)
        /// </summary>
        D3DTOP_MODULATE = 4,

        /// <summary>
        /// Multiply the components of the arguments, and shift the products to the left 1 bit (effectively multiplying them by 2) for brightening.
        /// equation of the modulate2x operation (s(rgba) = (arg1 x arg 2) then shift left 1)
        /// </summary>
        D3DTOP_MODULATE2X = 5,

        /// <summary>
        /// Multiply the components of the arguments, and shift the products to the left 2 bits (effectively multiplying them by 4) for brightening.
        /// equation of the modulate4x operation (s(rgba) = (arg1 x arg 2) then shift left 2)
        /// </summary>
        D3DTOP_MODULATE4X = 6,

        /// <summary>
        /// Add the components of the arguments.
        /// equation of the add operation (s(rgba) = arg1 + arg 2)
        /// </summary>
        D3DTOP_ADD = 7,

        /// <summary>
        /// Add the components of the arguments with a - 0.5 bias, making the effective range of values from - 0.5 through 0.5.
        /// equation of the add signed operation (s(rgba) = arg1 + arg 2 – 0.5)
        /// </summary>
        D3DTOP_ADDSIGNED = 8,

        /// <summary>
        /// Add the components of the arguments with a - 0.5 bias, and shift the products to the left 1 bit.
        /// equation of the add signed 2x operation ((s(rgba) = arg1 + arg 2 - 0.5) then shift left 1)
        /// </summary>
        D3DTOP_ADDSIGNED2X = 9,

        /// <summary>
        /// Subtract the components of the second argument from those of the first argument.
        /// equation of the subtract operation (s(rgba) = arg1 - arg 2)
        /// </summary>
        D3DTOP_SUBTRACT = 10,

        /// <summary>
        /// Add the first and second arguments; then subtract their product from the sum.
        /// equation of the add smooth operation (s(rgba) = arg1 + arg 2 x (1 - arg1))
        /// </summary>
        D3DTOP_ADDSMOOTH = 11,

        /// <summary>
        /// Linearly blend this texture stage, using the interpolated alpha from each vertex.
        /// equation of the blend diffuse alpha operation (s(rgba) = arg1 x alpha + arg 2 x (1 - alpha))
        /// </summary>
        D3DTOP_BLENDDIFFUSEALPHA = 12,

        /// <summary>
        /// Linearly blend this texture stage, using the alpha from this stage's texture.
        /// quation of the blend texture alpha operation (s(rgba) = arg1 x alpha + arg 2 x (1 - alpha))
        /// </summary>
        D3DTOP_BLENDTEXTUREALPHA = 13,

        /// <summary>
        /// Linearly blend this texture stage, using a scalar alpha set with the D3DRS_TEXTUREFACTOR render state.
        /// equation of the blend factor alpha operation (s(rgba) = arg1 x alpha + arg 2 x (1 - alpha))
        /// </summary>
        D3DTOP_BLENDFACTORALPHA = 14,

        /// <summary>
        /// Linearly blend a texture stage that uses a premultiplied alpha.
        /// equation of the blend texture alpha pm operation (s(rgba) = arg1 + arg 2 x (1 - alpha))
        /// </summary>
        D3DTOP_BLENDTEXTUREALPHAPM = 15,

        /// <summary>
        /// Linearly blend this texture stage, using the alpha taken from the previous texture stage.
        /// equation of the blend current alpha operation (s(rgba) = arg1 x alpha + arg2 x (1 - alpha))
        /// </summary>
        D3DTOP_BLENDCURRENTALPHA = 16,

        /// <summary>
        /// <see cref="D3DTOP_PREMODULATE"/> is set in stage n.
        /// The output of stage n is arg1.
        /// Additionally, if there is a texture in stage n + 1, any <see cref="D3DTA_CURRENT"/> in stage n + 1 is premultiplied by texture in stage n + 1.
        /// </summary>
        D3DTOP_PREMODULATE = 17,

        /// <summary>
        /// Modulate the color of the second argument, using the alpha of the first argument; then add the result to argument one.
        /// This operation is supported only for color operations (<see cref="D3DTSS_COLOROP"/>).
        /// equation of the add color modulate alpha operation (s(rgba) = arg1(rgb) + arg1(a) x arg2(rgb))
        /// </summary>
        D3DTOP_MODULATEALPHA_ADDCOLOR = 18,

        /// <summary>
        /// Modulate the arguments; then add the alpha of the first argument.
        /// This operation is supported only for color operations (<see cref="D3DTSS_COLOROP"/>).
        /// equation of the add alpha modulate color operation (s(rgba) = arg1(rgb) x arg2(rgb) + arg1(a))
        /// </summary>
        D3DTOP_MODULATECOLOR_ADDALPHA = 19,

        /// <summary>
        /// Similar to <see cref="D3DTOP_MODULATEALPHA_ADDCOLOR"/>, but use the inverse of the alpha of the first argument.
        /// This operation is supported only for color operations (<see cref="D3DTSS_COLOROP"/>).
        /// equation of the add color modulate inverse alpha operation (s(rgba) = (1 - arg1(a)) x arg2(rgb) + arg1(rgb))
        /// </summary>
        D3DTOP_MODULATEINVALPHA_ADDCOLOR = 20,

        /// <summary>
        /// Similar to <see cref="D3DTOP_MODULATECOLOR_ADDALPHA"/>, but use the inverse of the color of the first argument.
        /// This operation is supported only for color operations (<see cref="D3DTSS_COLOROP"/>).
        /// equation of the add alpha modulate inverse color operation (s(rgba) = (1 - arg1(rgb)) x arg2(rgb) + arg1(a))
        /// </summary>
        D3DTOP_MODULATEINVCOLOR_ADDALPHA = 21,

        /// <summary>
        /// Perform per-pixel bump mapping, using the environment map in the next texture stage, without luminance.
        /// This operation is supported only for color operations (<see cref="D3DTSS_COLOROP"/>).
        /// </summary>
        D3DTOP_BUMPENVMAP = 22,

        /// <summary>
        /// Perform per-pixel bump mapping, using the environment map in the next texture stage, with luminance.
        /// This operation is supported only for color operations (<see cref="D3DTSS_COLOROP"/>).
        /// </summary>
        D3DTOP_BUMPENVMAPLUMINANCE = 23,

        /// <summary>
        /// Modulate the components of each argument as signed components, add their products;
        /// then replicate the sum to all color channels, including alpha.
        /// This operation is supported for color and alpha operations.
        /// equation of the dot product 3 operation (s(rgba) = arg1(r) x arg2(r) + arg1(g) x arg2(g) + arg1(b) x arg2(b))
        /// In DirectX 6 and DirectX 7, multitexture operations the above inputs are all shifted down by half (y = x - 0.5) before use to simulate signed data,
        /// and the scalar result is automatically clamped to positive values and replicated to all three output channels.
        /// Also, note that as a color operation this does not updated the alpha it just updates the RGB components.
        /// However, in DirectX 8.1 shaders you can specify that the output be routed to the .rgb or the .a components or both (the default).
        /// You can also specify a separate scalar operation on the alpha channel.
        /// </summary>
        D3DTOP_DOTPRODUCT3 = 24,

        /// <summary>
        /// Performs a multiply-accumulate operation.
        /// It takes the last two arguments, multiplies them together, and adds them to the remaining input/source argument, and places that into the result.
        /// SRGBA = Arg1 + Arg2 * Arg3
        /// </summary>
        D3DTOP_MULTIPLYADD = 25,

        /// <summary>
        /// Linearly interpolates between the second and third source arguments by a proportion specified in the first source argument.
        /// SRGBA = (Arg1) * Arg2 + (1 - Arg1) * Arg3.
        /// </summary>
        D3DTOP_LERP = 26,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// This value is not used.
        /// </summary>
        D3DTOP_FORCE_DWORD = 0x7fffffff,
    }
}
