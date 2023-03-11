using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Authz;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// PFN_AUTHZ_FREE_DYNAMIC_GROUPS
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PFN_AUTHZ_FREE_DYNAMIC_GROUPS
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator AuthzFreeGroupsCallback(PFN_AUTHZ_FREE_DYNAMIC_GROUPS val) => (AuthzFreeGroupsCallback)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(AuthzFreeGroupsCallback));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PFN_AUTHZ_FREE_DYNAMIC_GROUPS(AuthzFreeGroupsCallback val) => new PFN_AUTHZ_FREE_DYNAMIC_GROUPS { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(PFN_AUTHZ_FREE_DYNAMIC_GROUPS val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator PFN_AUTHZ_FREE_DYNAMIC_GROUPS(IntPtr val) => new PFN_AUTHZ_FREE_DYNAMIC_GROUPS { _ptr = val };
    }
}
