using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// AUTHZ_RESOURCE_MANAGER_HANDLE 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AUTHZ_RESOURCE_MANAGER_HANDLE : IPointer
    {
        private IntPtr _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString("X");

        /// <inheritdoc/>
        public IntPtr ToIntPtr() => _value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(AUTHZ_RESOURCE_MANAGER_HANDLE val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator AUTHZ_RESOURCE_MANAGER_HANDLE(IntPtr val) => new AUTHZ_RESOURCE_MANAGER_HANDLE { _value = val };
    }
}
