using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A <see cref="DOUBLE"/> is an 8-byte, double-precision, floating-point number that represents a double-precision,
    /// 64-bit [IEEE754] value with the approximate range: +/–5.0 x 10-324 through +/–1.7 x 10308.
    /// The <see cref="DOUBLE"/> type can also represent not a number (NAN); positive and negative infinity; or positive and negative 0.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/openspecs/windows_protocols/ms-dtyp/40beeef3-303a-40de-895c-11379fc42c15
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct DOUBLE
    {
        [FieldOffset(0)]
        private double _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator double(DOUBLE val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator DOUBLE(double val) => new DOUBLE { _value = val };
    }
}
