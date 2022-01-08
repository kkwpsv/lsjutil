using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// CALTYPE
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct CALTYPE
    {
        [FieldOffset(0)]
        private int _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator int(CALTYPE val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator CALTYPE(int val) => new CALTYPE { _value = val };
    }
}
