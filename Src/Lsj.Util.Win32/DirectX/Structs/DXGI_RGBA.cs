using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Represents a color value with alpha, which is used for transparency.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3ddxgi/dxgi-rgba"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// You can set the members of this structure to values outside the range of 0 through 1 to implement some unusual effects.
    /// Values greater than 1 produce strong lights that tend to wash out a scene.
    /// Negative values produce dark lights that actually remove light from a scene.
    /// </para>
    /// <para>
    /// The DXGItype.h header type-defines <see cref="DXGI_RGBA"/> as an alias of <see cref="D3DCOLORVALUE"/>, as follows:
    /// </para>
    /// <code>
    /// typedef D3DCOLORVALUE DXGI_RGBA;
    /// </code>
    /// <para>
    /// You can use <see cref="DXGI_RGBA"/> with <see cref="IDXGISwapChain1.SetBackgroundColor"/>,
    /// <see cref="IDXGISwapChain1.GetBackgroundColor"/>, and <see cref="DXGI_ALPHA_MODE"/>.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DXGI_RGBA
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
