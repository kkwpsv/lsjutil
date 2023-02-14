using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// Represents a 64-bit unsigned integer value.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-ularge_integer~r1"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="ULARGE_INTEGER"/> structure is actually a union.
    /// If your compiler has built-in support for 64-bit integers, use the <see cref="QuadPart"/> member to store the 64-bit integer.
    /// Otherwise, use the <see cref="LowPart"/> and <see cref="HighPart"/> members to store the 64-bit integer.
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct ULARGE_INTEGER
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
        public DWORD HighPart;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public ULONGLONG QuadPart;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ulong(ULARGE_INTEGER val) => val.QuadPart;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ULARGE_INTEGER(ulong val) => new ULARGE_INTEGER { QuadPart = val };
    }
}
