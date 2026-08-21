using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// HMETAFILEPICT
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HMETAFILEPICT : IPointer
    {
        private HANDLE _value;

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
        public static implicit operator nint(HMETAFILEPICT val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator HMETAFILEPICT(nint val) => new HMETAFILEPICT { _value = val };
    }
}
