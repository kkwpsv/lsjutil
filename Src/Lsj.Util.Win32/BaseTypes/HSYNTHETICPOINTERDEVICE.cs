using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// HSYNTHETICPOINTERDEVICE
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HSYNTHETICPOINTERDEVICE : IPointer
    {
        private nint _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <inheritdoc/>
        public IntPtr ToIntPtr() => _value;

        /// <inheritdoc/>
        public nint ToNint() => _value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator nint(HSYNTHETICPOINTERDEVICE val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator HSYNTHETICPOINTERDEVICE(nint val) => new HSYNTHETICPOINTERDEVICE { _value = val };
    }
}
