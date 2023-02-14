using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// The <see cref="VARIANT_BOOL"/> type specifies Boolean values.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-oaut/7b39eb24-9d39-498a-bcd8-75c38e5823d0"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 2)]
    public struct VARIANT_BOOL
    {
        /// <summary>
        /// TRUE
        /// </summary>
        public static readonly VARIANT_BOOL TRUE = new VARIANT_BOOL { _value = 0xFFFF };

        /// <summary>
        /// FALSE
        /// </summary>
        public static readonly VARIANT_BOOL FALSE = new VARIANT_BOOL { _value = 0x0000 };

        [FieldOffset(0)]
        private int _value;

        /// <inheritdoc/>
        public override string ToString() => ((bool)this).ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator bool(VARIANT_BOOL val) => val._value == TRUE._value ? true : val._value == FALSE._value ? false : throw new InvalidOperationException("Invalid VARIANT_BOOL value");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator VARIANT_BOOL(bool val) => val ? TRUE : FALSE;
    }
}
