using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// PSECURE_MEMORY_CACHE_CALLBACK
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/nc-winnt-psecure_memory_cache_callback"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PSECURE_MEMORY_CACHE_CALLBACK
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PsecureMemoryCacheCallback(PSECURE_MEMORY_CACHE_CALLBACK val) => (PsecureMemoryCacheCallback)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(PvectoredExceptionHandler));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PSECURE_MEMORY_CACHE_CALLBACK(PsecureMemoryCacheCallback val) => new PSECURE_MEMORY_CACHE_CALLBACK { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(PSECURE_MEMORY_CACHE_CALLBACK val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator PSECURE_MEMORY_CACHE_CALLBACK(IntPtr val) => new PSECURE_MEMORY_CACHE_CALLBACK { _ptr = val };
    }
}
