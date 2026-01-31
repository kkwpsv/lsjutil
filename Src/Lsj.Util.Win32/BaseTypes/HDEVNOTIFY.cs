using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// HDEVNOTIFY
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HDEVNOTIFY : IPointer
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
        public static implicit operator IntPtr(HDEVNOTIFY val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator HDEVNOTIFY(IntPtr val) => new HDEVNOTIFY { _value = val };
    }
}
