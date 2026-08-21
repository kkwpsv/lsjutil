using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// SERVICE_STATUS_HANDLE
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SERVICE_STATUS_HANDLE : IPointer
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
        public static implicit operator HANDLE(SERVICE_STATUS_HANDLE val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator SERVICE_STATUS_HANDLE(HANDLE val) => new SERVICE_STATUS_HANDLE { _value = val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator nint(SERVICE_STATUS_HANDLE val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator SERVICE_STATUS_HANDLE(nint val) => new SERVICE_STATUS_HANDLE { _value = val };
    }
}
