using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A message parameter.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/winprog/windows-data-types
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct WPARAM
    {
        [FieldOffset(0)]
        private UIntPtr _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator UIntPtr(WPARAM val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator WPARAM(UIntPtr val) => new WPARAM { _value = val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator WPARAM(int val) => new WPARAM { _value = unchecked((UIntPtr)(uint)val) };
    }
}
