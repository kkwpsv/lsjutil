using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// AUTHZ_CLIENT_CONTEXT_HANDLE
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AUTHZ_CLIENT_CONTEXT_HANDLE : IPointer
    {
        private IntPtr _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString("X");

        /// <inheritdoc/>
        public override bool Equals(object? obj) => obj is IPointer p && p.ToIntPtr() == _value || obj is IntPtr ptr && ptr == _value;

        /// <inheritdoc/>
        public override int GetHashCode() => _value.GetHashCode();

        /// <inheritdoc/>
        public IntPtr ToIntPtr() => _value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(AUTHZ_CLIENT_CONTEXT_HANDLE val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator AUTHZ_CLIENT_CONTEXT_HANDLE(IntPtr val) => new AUTHZ_CLIENT_CONTEXT_HANDLE { _value = val };
    }
}
