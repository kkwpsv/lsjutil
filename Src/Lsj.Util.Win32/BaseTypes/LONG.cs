﻿using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A <see cref="LONG"/> is a 32-bit signed integer, in twos-complement format (range: –2147483648 through 2147483647 decimal).
    /// The first bit (Most Significant Bit (MSB)) is the signing bit.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-dtyp/29d44d70-382f-4998-9d76-8a1fe93e445c"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct LONG
    {
        /// <summary>
        /// <para>
        /// Creates a <see cref="LONG"/> value by concatenating the specified values.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms632660(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="a">
        /// The low-order word of the new value.
        /// </param>
        /// <param name="b">
        /// The high-order word of the new value.
        /// </param>
        /// <returns>
        /// The return value is a <see cref="LONG"/> value.
        /// </returns>
        public static LONG MAKELONG(WORD a, WORD b) => a | ((DWORD)(b << 16));

        /// <summary>
        /// MAXLONG
        /// </summary>
        public static LONG MAXLONG = 0x7fffffff;

        [FieldOffset(0)]
        private int _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator int(LONG val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LONG(int val) => new LONG { _value = val };
    }
}
