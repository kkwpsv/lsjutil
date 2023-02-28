using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes color values.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dcolorvalue"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// You can set the members of this structure to values outside the range of 0 through 1 to implement some unusual effects.
    /// Values greater than 1 produce strong lights that tend to wash out a scene.
    /// Negative values produce dark lights that actually remove light from a scene.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3DCOLORVALUE
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
