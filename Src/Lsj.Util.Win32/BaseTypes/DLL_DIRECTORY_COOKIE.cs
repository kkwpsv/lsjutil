using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// DLL_DIRECTORY_COOKIE
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DLL_DIRECTORY_COOKIE
    {
        private IntPtr _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString("X");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(DLL_DIRECTORY_COOKIE val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator DLL_DIRECTORY_COOKIE(IntPtr val) => new DLL_DIRECTORY_COOKIE { _value = val };
    }
}
