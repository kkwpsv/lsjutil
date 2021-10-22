using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// WLAN_SIGNAL_QUALITY
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct WLAN_SIGNAL_QUALITY
    {
        [FieldOffset(0)]
        private uint _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator uint(WLAN_SIGNAL_QUALITY val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator WLAN_SIGNAL_QUALITY(uint val) => new WLAN_SIGNAL_QUALITY { _value = val };
    }
}
