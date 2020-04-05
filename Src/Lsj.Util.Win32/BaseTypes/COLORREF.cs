using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// The <see cref="COLORREF"/> value is used to specify an RGB color.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/gdi/colorref
    /// </para>
    /// </summary>
    /// <remarks>
    /// When specifying an explicit RGB color, the <see cref="COLORREF"/> value has the following hexadecimal form: 0x00bbggrr
    /// The low-order byte contains a value for the relative intensity of red; the second byte contains a value for green;
    /// and the third byte contains a value for blue.
    /// The high-order byte must be zero.
    /// The maximum value for a single byte is 0xFF.
    /// To create a <see cref="COLORREF"/> color value, use the <see cref="RGB"/> macro.
    /// To extract the individual values for the red, green, and blue components of a color value,
    /// use the <see cref="GetRValue"/>, <see cref="GetGValue"/>, and <see cref="GetBValue"/> macros, respectively.
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct COLORREF
    {
        /// <summary>
        /// CLR_INVALID
        /// </summary>
        public static readonly COLORREF CLR_INVALID = new COLORREF { _value = 0xFFFFFFFF };

        [FieldOffset(0)]
        private uint _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator uint(COLORREF val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator COLORREF(uint val) => new COLORREF { _value = val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator int(COLORREF val) => unchecked((int)val._value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator COLORREF(int val) => new COLORREF { _value = unchecked((uint)val) };
    }
}
