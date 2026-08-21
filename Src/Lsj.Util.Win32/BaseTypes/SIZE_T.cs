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
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/winprog/windows-data-types"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SIZE_T
    {
        private nuint _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator nuint(SIZE_T val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator SIZE_T(nuint val) => new SIZE_T { _value = val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator nint(SIZE_T val) => (nint)val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator SIZE_T(nint val) => new SIZE_T { _value = (nuint)val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator int(SIZE_T val) => val._value.SafeToInt32();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator uint(SIZE_T val) => val._value.SafeToUInt32();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator SIZE_T(int val) => new SIZE_T { _value = (nuint)val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator SIZE_T(long val) => new SIZE_T { _value = (nuint)val };
    }
}
