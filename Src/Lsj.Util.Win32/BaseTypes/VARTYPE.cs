using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// VARTYPE
    [StructLayout(LayoutKind.Explicit, Size = 2)]
    public struct VARTYPE
    {
        [FieldOffset(0)]
        private ushort _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ushort(VARTYPE val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator VARTYPE(ushort val) => new VARTYPE { _value = val };
    }
}
