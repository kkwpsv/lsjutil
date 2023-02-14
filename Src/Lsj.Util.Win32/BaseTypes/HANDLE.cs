using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A Handle to an object
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-dtyp/929187f0-f25c-4b05-9497-16b066d8a912"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HANDLE : IPointer
    {
        private IntPtr _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString("X");

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is IPointer p && p.ToIntPtr() == _value || obj is IntPtr ptr && ptr == _value;

        /// <inheritdoc/>
        public override int GetHashCode() => _value.GetHashCode();

        /// <inheritdoc/>
        public IntPtr ToIntPtr() => _value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(HANDLE a, IntPtr b) => a._value == b;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(HANDLE a, IntPtr b) => a._value != b;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(HANDLE val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator HANDLE(IntPtr val) => new HANDLE { _value = val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator HANDLE(int val) => new HANDLE { _value = (IntPtr)val };
    }
}
