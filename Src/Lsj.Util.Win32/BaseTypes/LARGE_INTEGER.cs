﻿using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// Represents a 64-bit signed integer value.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-large_integer~r1"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="LARGE_INTEGER"/> structure is actually a union.
    /// If your compiler has built-in support for 64-bit integers, use the <see cref="QuadPart"/> member to store the 64-bit integer.
    /// Otherwise, use the <see cref="LowPart"/> and <see cref="HighPart"/> members to store the 64-bit integer.
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct LARGE_INTEGER
    {
        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public DWORD LowPart;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(4)]
        public LONG HighPart;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public LONGLONG QuadPart;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator long(LARGE_INTEGER val) => val.QuadPart;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LARGE_INTEGER(long val) => new LARGE_INTEGER { QuadPart = val };
    }
}
