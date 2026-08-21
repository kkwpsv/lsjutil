using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// AUTHZ_ACCESS_CHECK_RESULTS_HANDLE
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AUTHZ_ACCESS_CHECK_RESULTS_HANDLE : IPointer
    {
        private nint _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString("X");

        /// <inheritdoc/>
        public override bool Equals(object? obj) => obj is IPointer p && p.ToNint() == _value || obj is nint ptr && ptr == _value;

        /// <inheritdoc/>
        public override int GetHashCode() => _value.GetHashCode();

        /// <inheritdoc/>
        public IntPtr ToIntPtr() => _value;

        /// <inheritdoc/>
        public nint ToNint() => _value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator nint(AUTHZ_ACCESS_CHECK_RESULTS_HANDLE val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator AUTHZ_ACCESS_CHECK_RESULTS_HANDLE(nint val) => new AUTHZ_ACCESS_CHECK_RESULTS_HANDLE { _value = val };
    }
}
