using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// TP_VERSION
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct TP_VERSION
    {

        [FieldOffset(0)]
        private uint _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator uint(TP_VERSION val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator TP_VERSION(uint val) => new TP_VERSION { _value = val };
    }
}
