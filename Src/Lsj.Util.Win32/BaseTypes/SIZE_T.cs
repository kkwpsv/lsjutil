using Lsj.Util.Win32.Extensions;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// The maximum number of bytes to which a pointer can point.
    /// Use for a count that must span the full range of a pointer.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/winprog/windows-data-types
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SIZE_T
    {
        private UIntPtr _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator UIntPtr(SIZE_T val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator SIZE_T(UIntPtr val) => new SIZE_T { _value = val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(SIZE_T val) => val._value.SafeToIntPtr();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator SIZE_T(IntPtr val) => new SIZE_T { _value = val.SafeToUIntPtr() };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator int(SIZE_T val) => val._value.SafeToInt32();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator SIZE_T(int val) => new SIZE_T { _value = (UIntPtr)unchecked((uint)val) };
    }
}
