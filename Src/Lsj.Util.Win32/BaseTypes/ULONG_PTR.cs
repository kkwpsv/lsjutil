using Lsj.Util.Win32.Extensions;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A <see cref="ULONG_PTR"/> is an unsigned long type used for pointer precision.
    /// It is used when casting a pointer to a long type to perform pointer arithmetic.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/openspecs/windows_protocols/ms-dtyp/21eec394-630d-49ed-8b4a-ab74a1614611"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ULONG_PTR
    {
        private UIntPtr _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator UIntPtr(ULONG_PTR val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ULONG_PTR(UIntPtr val) => new ULONG_PTR { _value = val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(ULONG_PTR val) => val._value.SafeToIntPtr();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ULONG_PTR(IntPtr val) => new ULONG_PTR { _value = val.SafeToUIntPtr() };

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int SafeToInt32() => _value.SafeToInt32();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public uint SafeToUInt32() => _value.SafeToUInt32();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public long SafeToInt64() => _value.SafeToInt64();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ulong SafeToUInt64() => _value.SafeToUInt64();
    }
}
