using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Represents a 64-bit signed integer value.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-large_integer~r1
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
        public uint LowPart;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(4)]
        public uint HighPart;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public ulong QuadPart;
    }
}
