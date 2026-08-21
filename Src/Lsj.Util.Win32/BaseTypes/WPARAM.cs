using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A message parameter.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/winprog/windows-data-types"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct WPARAM
    {
        [FieldOffset(0)]
        private nuint _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator nuint(WPARAM val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator WPARAM(nuint val) => new WPARAM { _value = val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator nint(WPARAM val) => (nint)val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator WPARAM(nint val) => new WPARAM { _value = (nuint)val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator WPARAM(int val) => new WPARAM { _value = (nuint)val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator uint(WPARAM val) => (uint)val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator int(WPARAM val) => (int)val._value;
    }
}
