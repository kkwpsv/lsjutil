using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// HPOWERNOTIFY
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HPOWERNOTIFY : IPointer
    {
        private nint _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <inheritdoc/>
        public IntPtr ToIntPtr() => _value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(HPOWERNOTIFY val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator HPOWERNOTIFY(IntPtr val) => new HPOWERNOTIFY { _value = val };
    }
}
