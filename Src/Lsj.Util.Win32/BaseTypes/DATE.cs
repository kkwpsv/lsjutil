using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// DATE
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct DATE
    {
        [FieldOffset(0)]
        private double _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator double(DATE val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator DATE(double val) => new DATE { _value = val };
    }
}
