using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Authz;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// PFN_AUTHZ_DYNAMIC_ACCESS_CHECK
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PFN_AUTHZ_DYNAMIC_ACCESS_CHECK
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator AuthzAccessCheckCallback(PFN_AUTHZ_DYNAMIC_ACCESS_CHECK val) => (AuthzAccessCheckCallback)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(AuthzAccessCheckCallback));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PFN_AUTHZ_DYNAMIC_ACCESS_CHECK(AuthzAccessCheckCallback val) => new PFN_AUTHZ_DYNAMIC_ACCESS_CHECK { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(PFN_AUTHZ_DYNAMIC_ACCESS_CHECK val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator PFN_AUTHZ_DYNAMIC_ACCESS_CHECK(IntPtr val) => new PFN_AUTHZ_DYNAMIC_ACCESS_CHECK { _ptr = val };
    }
}
