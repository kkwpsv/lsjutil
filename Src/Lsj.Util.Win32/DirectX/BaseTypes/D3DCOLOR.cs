using System.Runtime.InteropServices;

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
    }
}
