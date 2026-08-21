namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies which gamma is used for interpolation.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_gamma"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Interpolating in a linear gamma space (<see cref="D2D1_GAMMA_1_0"/>) can avoid changes in perceived brightness
    /// caused by the effect of gamma correction in spaces where the gamma is not 1.0,
    /// such as the default sRGB color space, where the gamma is 2.2.
    /// For an example of the differences between these two blending modes, consider the following illustration,
    /// which shows two gradients, each of which blends from red to blue to green:
    /// </para>
    /// <para>
    /// The first gradient is interpolated linearly in the space of the render target (sRGB in this case),
    /// and one can see the dark bands between each color.
    /// The second gradient uses a gamma-correct linear interpolation,
    /// and thus does not exhibit the same variations in brightness.
    /// </para>
    /// </remarks>
    public enum D2D1_GAMMA : uint
    {
        /// <summary>
        /// Interpolation is performed in the standard RGB (sRGB) gamma.
        /// </summary>
        D2D1_GAMMA_2_2 = 0,

        /// <summary>
        /// Interpolation is performed in the linear-gamma color space.
        /// </summary>
        D2D1_GAMMA_1_0 = 1,

        /// <summary>
        /// 
        /// </summary>
        D2D1_GAMMA_FORCE_DWORD = 0xffffffff
    }
}
