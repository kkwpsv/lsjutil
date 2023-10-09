namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// RGB or alpha blending operation.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_blend_op"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The runtime implements RGB blending and alpha blending separately.
    /// Therefore, blend state requires separate blend operations for RGB data and alpha data.
    /// These blend operations are specified in a blend description.
    /// The two sources —source 1 and source 2— are shown in the blending block diagram.
    /// Blend state is used by the output-merger stage to determine how to blend together two RGB pixel values and two alpha values.
    /// The two RGB pixel values and two alpha values are the RGB pixel value and alpha value
    /// that the pixel shader outputs and the RGB pixel value and alpha value already in the output render target.
    /// The blend option controls the data source that the blending stage uses to modulate values for the pixel shader, render target, or both.
    /// The blend operation controls how the blending stage mathematically combines these modulated values.
    /// </remarks>
    public enum D3D11_BLEND_OP
    {
        /// <summary>
        /// Add source 1 and source 2.
        /// </summary>
        D3D11_BLEND_OP_ADD = 1,

        /// <summary>
        /// Subtract source 1 from source 2.
        /// </summary>
        D3D11_BLEND_OP_SUBTRACT = 2,

        /// <summary>
        /// Subtract source 2 from source 1.
        /// </summary>
        D3D11_BLEND_OP_REV_SUBTRACT = 3,

        /// <summary>
        /// Find the minimum of source 1 and source 2.
        /// </summary>
        D3D11_BLEND_OP_MIN = 4,

        /// <summary>
        /// Find the maximum of source 1 and source 2.
        /// </summary>
        D3D11_BLEND_OP_MAX = 5,
    }
}
