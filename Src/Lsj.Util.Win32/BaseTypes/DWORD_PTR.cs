using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A <see cref="DWORD_PTR"/> is an unsigned long type used for pointer precision.
    /// It is used when casting a pointer to an unsigned long type to perform pointer arithmetic.
    /// <see cref="DWORD_PTR"/> is also commonly used for general 32-bit parameters that have been extended to 64 bits in 64-bit Windows.
    /// For more information, see <see cref="ULONG_PTR"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-dtyp/262627d8-3418-4627-9218-4ffe110850b2"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DWORD_PTR
    {
        private nuint _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator nuint(DWORD_PTR val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator DWORD_PTR(nuint val) => new DWORD_PTR { _value = val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator nint(DWORD_PTR val) => (nint)val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator DWORD_PTR(nint val) => new DWORD_PTR { _value = (nuint)val };
    }
}
