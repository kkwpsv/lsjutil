using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the red, green, blue, and alpha components of a color.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/Direct2D/d2d1-color-f"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// <see cref="D2D1_COLOR_F"/> is a typedef for <see cref="D2D_COLOR_F"/>,
    /// which is itself a typedef for <see cref="D3DCOLORVALUE"/>.
    /// For information about the members provided by <see cref="D2D1_COLOR_F"/>, see <see cref="D3DCOLORVALUE"/>.
    /// </para>
    /// <para>
    /// The <c>ColorF</c> class provides a set of predefined colors and helper functions for defining colors.
    /// For more information, see the <c>ColorF</c> reference.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D2D1_COLOR_F
    {
        /// <summary>
        /// Floating-point value that specifies the red component of a color.
        /// This value generally is in the range from 0.0 through 1.0.
        /// A value of 0.0 indicates the complete absence of the red component, while a value of 1.0 indicates that red is fully present.
        /// </summary>
        public float r;

        /// <summary>
        /// Floating-point value that specifies the green component of a color.
        /// This value generally is in the range from 0.0 through 1.0.
        /// A value of 0.0 indicates the complete absence of the green component, while a value of 1.0 indicates that green is fully present.
        /// </summary>
        public float g;

        /// <summary>
        /// Floating-point value that specifies the blue component of a color.
        /// This value generally is in the range from 0.0 through 1.0.
        /// A value of 0.0 indicates the complete absence of the blue component, while a value of 1.0 indicates that blue is fully present.
        /// </summary>
        public float b;

        /// <summary>
        /// Floating-point value that specifies the alpha component of a color.
        /// This value generally is in the range from 0.0 through 1.0.
        /// A value of 0.0 indicates fully transparent, while a value of 1.0 indicates fully opaque.
        /// </summary>
        public float a;
    }
}
