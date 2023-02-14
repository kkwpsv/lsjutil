using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A LONG64 is a 64-bit signed integer.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-dtyp/7dc8dc9c-9d54-417a-933e-173933f0c329"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct LONG64
    {
        [FieldOffset(0)]
        private long _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator long(LONG64 val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LONG64(long val) => new LONG64 { _value = val };
    }
}
