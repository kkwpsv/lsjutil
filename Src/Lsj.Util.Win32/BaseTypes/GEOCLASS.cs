using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// GEOCLASS
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct GEOCLASS
    {
        /// <summary>
        /// GEOCLASS_NATION
        /// </summary>
        public static readonly GEOCLASS GEOCLASS_NATION = 16;

        [FieldOffset(0)]
        private int _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator int(GEOCLASS val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator GEOCLASS(int val) => new GEOCLASS { _value = val };
    }
}
