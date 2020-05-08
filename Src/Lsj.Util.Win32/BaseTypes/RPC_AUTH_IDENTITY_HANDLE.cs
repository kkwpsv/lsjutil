using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// RPC_AUTH_IDENTITY_HANDLE
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RPC_AUTH_IDENTITY_HANDLE
    {
        private IntPtr _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString("X");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(RPC_AUTH_IDENTITY_HANDLE val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator RPC_AUTH_IDENTITY_HANDLE(IntPtr val) => new RPC_AUTH_IDENTITY_HANDLE { _value = val };
    }
}
