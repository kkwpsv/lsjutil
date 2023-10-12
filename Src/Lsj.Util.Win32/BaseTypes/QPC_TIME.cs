using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// QPC_TIME
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct QPC_TIME
    {
        [FieldOffset(0)]
        private ulong _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ulong(QPC_TIME val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator QPC_TIME(ulong val) => new QPC_TIME { _value = val };
    }
}
