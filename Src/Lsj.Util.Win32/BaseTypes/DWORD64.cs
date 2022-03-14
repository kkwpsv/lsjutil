using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A <see cref="DWORD64"/> is a 64-bit unsigned integer.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/openspecs/windows_protocols/ms-dtyp/3f3bd817-6fdd-4db9-b542-f800f876007d"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct DWORD64
    {
        [FieldOffset(0)]
        private ulong _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ulong(DWORD64 val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator DWORD64(ulong val) => new DWORD64 { _value = val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator long(DWORD64 val) => unchecked((long)val._value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator DWORD64(long val) => new DWORD64 { _value = unchecked((ulong)val) };
    }
}
