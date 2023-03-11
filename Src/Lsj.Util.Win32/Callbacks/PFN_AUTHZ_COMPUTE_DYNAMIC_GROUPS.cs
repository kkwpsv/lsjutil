using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Authz;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// PFN_AUTHZ_COMPUTE_DYNAMIC_GROUPS
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PFN_AUTHZ_COMPUTE_DYNAMIC_GROUPS
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator AuthzComputeGroupsCallback(PFN_AUTHZ_COMPUTE_DYNAMIC_GROUPS val) => (AuthzComputeGroupsCallback)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(AuthzComputeGroupsCallback));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PFN_AUTHZ_COMPUTE_DYNAMIC_GROUPS(AuthzComputeGroupsCallback val) => new PFN_AUTHZ_COMPUTE_DYNAMIC_GROUPS { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(PFN_AUTHZ_COMPUTE_DYNAMIC_GROUPS val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator PFN_AUTHZ_COMPUTE_DYNAMIC_GROUPS(IntPtr val) => new PFN_AUTHZ_COMPUTE_DYNAMIC_GROUPS { _ptr = val };
    }
}
