using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// OLECHAR
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 2, CharSet = CharSet.Unicode)]
    public struct OLECHAR
    {
        [FieldOffset(0)]
        private char _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator char(OLECHAR val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator OLECHAR(char val) => new OLECHAR { _value = val };
    }
}
