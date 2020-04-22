using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// MMRESULT
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct MMRESULT
    {
        /// <summary>
        /// TIMERR_BASE
        /// </summary>
        public static readonly MMRESULT TIMERR_BASE = new MMRESULT { _value = 96 };

        /// <summary>
        /// TIMERR_NOCANDO
        /// </summary>
        public static readonly MMRESULT TIMERR_NOCANDO = new MMRESULT { _value = TIMERR_BASE + 1 };

        /// <summary>
        /// TIMERR_NOERROR
        /// </summary>
        public static readonly MMRESULT TIMERR_NOERROR = new MMRESULT();

        [FieldOffset(0)]
        private uint _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator uint(MMRESULT val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator MMRESULT(uint val) => new MMRESULT { _value = val };
    }
}
