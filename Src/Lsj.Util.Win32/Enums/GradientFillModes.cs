using static Lsj.Util.Win32.Msimg32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="GradientFill"/> Modes
    /// </summary>
    public enum GradientFillModes : uint
    {
        /// <summary>
        /// GRADIENT_FILL_RECT_H
        /// </summary>
        GRADIENT_FILL_RECT_H = 0,

        /// <summary>
        /// GRADIENT_FILL_RECT_V
        /// </summary>
        GRADIENT_FILL_RECT_V = 1,

        /// <summary>
        /// GRADIENT_FILL_TRIANGLE
        /// </summary>
        GRADIENT_FILL_TRIANGLE = 2,
    }
}
