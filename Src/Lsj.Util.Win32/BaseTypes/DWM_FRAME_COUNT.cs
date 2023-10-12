using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// DWM_FRAME_COUNT
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct DWM_FRAME_COUNT
    {
        [FieldOffset(0)]
        private ulong _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ulong(DWM_FRAME_COUNT val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator DWM_FRAME_COUNT(ulong val) => new DWM_FRAME_COUNT { _value = val };
    }
}
