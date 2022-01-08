using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// LCTYPE
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct LCTYPE
    {
        [FieldOffset(0)]
        private int _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator int(LCTYPE val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LCTYPE(int val) => new LCTYPE { _value = val };
    }
}
