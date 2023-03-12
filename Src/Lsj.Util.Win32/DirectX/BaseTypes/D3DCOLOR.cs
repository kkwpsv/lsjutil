using System.Runtime.InteropServices;
using static System.Net.WebRequestMethods;

namespace Lsj.Util.Win32.DirectX.BaseTypes
{
    /// <summary>
    /// <para>
    /// Defines the fundamental Direct3D color type.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dcolor"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// A four byte value that typically represents the alpha, red, green, and blue components of a color. It can also represent luminance and brightness.
    /// You can set the <see cref="D3DCOLOR"/> type using one of the following macros.
    /// <see cref="D3DCOLOR_ARGB"/>, <see cref="D3DCOLOR_AYUV"/>, <see cref="D3DCOLOR_COLORVALUE"/>,
    /// <see cref="D3DCOLOR_RGBA"/>, <see cref="D3DCOLOR_XRGB"/>, <see cref="D3DCOLOR_XYUV"/>
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct D3DCOLOR
    {
        [FieldOffset(0)]
        private uint _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator uint(D3DCOLOR val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator D3DCOLOR(uint val) => new D3DCOLOR { _value = val };

        /// <summary>
        /// <para>
        /// Initializes a color with the supplied alpha, red, green, and blue values.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dcolor-argb"/>
        /// </para>
        /// </summary>
        /// <param name="a">
        /// Alpha component of the color.
        /// This value must be in the range 0 through 255.
        /// </param>
        /// <param name="r">
        /// Red component of the color.
        /// This value must be in the range 0 through 255.
        /// </param>
        /// <param name="g">
        /// Green component of the color.
        /// This value must be in the range 0 through 255.
        /// </param>
        /// <param name="b">
        /// Blue component of the color.
        /// This value must be in the range 0 through 255.
        /// </param>
        /// <returns>
        /// Returns the <see cref="D3DCOLOR"/> value that corresponds to the supplied ARGB values.
        /// </returns>
        public static D3DCOLOR D3DCOLOR_ARGB(byte a, byte r, byte g, byte b) => (D3DCOLOR)(uint)((((a) & 0xff) << 24) | (((r) & 0xff) << 16) | (((g) & 0xff) << 8) | ((b) & 0xff));

        /// <summary>
        /// <para>
        /// Initializes a color using the (a,y,u,v) values.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dcolor-ayuv"/>
        /// </para>
        /// </summary>
        /// <param name="a">
        /// Alpha component of the color.
        /// This value must be in the range 0 through 255.
        /// </param>
        /// <param name="y">
        /// Luminance component of the color.
        /// This value must be in the range 0 through 255.
        /// </param>
        /// <param name="u">
        /// Blue brightness of the color.
        /// This value must be in the range 0 through 255.
        /// </param>
        /// <param name="v">
        /// Red brightness of the color. 
        /// This value must be in the range 0 through 255.
        /// </param>
        /// <returns>
        /// Returns the <see cref="D3DCOLOR"/> value that corresponds to the supplied ARGB values.
        /// </returns>
        /// <remarks>
        /// An RGB color can be reduced to 16 bits per pixel by conversion to luminance and color differences with the following equations:
        /// <code>
        /// y (luminance) = 0.299*red + 0.587*green + 0.114*blue
        /// u = blue - luminance
        /// v = red - luminance
        /// </code>
        /// </remarks>
        public static D3DCOLOR D3DCOLOR_AYUV(byte a, byte y, byte u, byte v) => D3DCOLOR_ARGB(a, y, u, v);

        /// <summary>
        /// <para>
        /// Initializes a color with the supplied red, green, blue, and alpha floating-point values.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dcolor-colorvalue"/>
        /// </para>
        /// </summary>
        /// <param name="r">
        /// Red component of the color.
        /// This value must be a floating-point value in the range 0.0 through 1.0.
        /// </param>
        /// <param name="g">
        /// Green component of the color.
        /// This value must be a floating-point value in the range 0.0 through 1.0.
        /// </param>
        /// <param name="b">
        /// Blue component of the color.
        /// This value must be a floating-point value in the range 0.0 through 1.0.
        /// </param>
        /// <param name="a">
        /// Alpha component of the color.
        /// This value must be a floating-point value in the range 0.0 through 1.0.
        /// </param>
        /// <returns>
        /// Returns the <see cref="D3DCOLOR"/> value that corresponds to the supplied RGBA values.
        /// </returns>
        public static D3DCOLOR D3DCOLOR_COLORVALUE(float r, float g, float b, float a) => D3DCOLOR_RGBA((byte)((r) * 255), (byte)((g) * 255), (byte)((b) * 255), (byte)((a) * 255));

        /// <summary>
        /// <para>
        /// Initializes a color with the supplied red, green, blue, and alpha values.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dcolor-rgba"/>
        /// </para>
        /// </summary>
        /// <param name="r">
        /// Red component of the color.
        /// This value must be in the range 0 through 255.
        /// </param>
        /// <param name="g">
        /// Green component of the color.
        /// This value must be in the range 0 through 255.
        /// </param>
        /// <param name="b">
        /// Blue component of the color.
        /// This value must be in the range 0 through 255.
        /// </param>
        /// <param name="a">
        /// Alpha component of the color.
        /// This value must be in the range 0 through 255.
        /// </param>
        /// <returns>
        /// Returns the <see cref="D3DCOLOR"/> value that corresponds to the supplied RGBA values.
        /// </returns>
        public static D3DCOLOR D3DCOLOR_RGBA(byte r, byte g, byte b, byte a) => D3DCOLOR_ARGB(a, r, g, b);

        /// <summary>
        /// <para>
        /// Initializes a color with the supplied red, green, and blue values.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dcolor-xrgb"/>
        /// </para>
        /// </summary>
        /// <param name="r">
        /// Red component of the color.
        /// This value must be in the range 0 through 255.
        /// </param>
        /// <param name="g">
        /// Green component of the color.
        /// This value must be in the range 0 through 255.
        /// </param>
        /// <param name="b">
        /// Blue component of the color.
        /// This value must be in the range 0 through 255.
        /// </param>
        /// <returns>
        /// Returns the <see cref="D3DCOLOR"/> value that corresponds to the supplied RGB values.
        /// </returns>
        public static D3DCOLOR D3DCOLOR_XRGB(byte r, byte g, byte b) => D3DCOLOR_ARGB(0xff, r, g, b);

        /// <summary>
        /// <para>
        /// Initializes a color with the (y, u, v) values.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dcolor-xyuv"/>
        /// </para>
        /// </summary>
        /// <param name="y">
        /// Luminance component of the color.
        /// This value must be in the range 0 through 255.
        /// </param>
        /// <param name="u">
        /// Blue brightness of the color.
        /// This value must be in the range 0 through 255.
        /// </param>
        /// <param name="v">
        /// Red brightness of the color. 
        /// This value must be in the range 0 through 255.
        /// </param>
        /// <returns>
        /// Returns the <see cref="D3DCOLOR"/> value that corresponds to the supplied (y, u, v) values.
        /// </returns>
        /// <remarks>
        /// An RGB color can be reduced to 16 bits per pixel by conversion to luminance and color differences with the following equations:
        /// <code>
        /// y (luminance) = 0.299*red + 0.587*green + 0.114*blue
        /// u = blue - luminance
        /// v = red - luminance
        /// </code>
        /// </remarks>
        public static D3DCOLOR D3DCOLOR_XYUV(byte y, byte u, byte v) => D3DCOLOR_ARGB(0xff, y, u, v);
    }
}
