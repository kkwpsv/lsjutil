using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// A currency number stored as an 8-byte, two's complement integer, scaled by 10,000 to give a fixed-point number
    /// with 15 digits to the left of the decimal point and 4 digits to the right.
    /// This <see cref="IDispatch.GetTypeInfo"/> representation provides a range of 922337203685477.5807 to -922337203685477.5808.
    /// The CURRENCY data type is useful for calculations involving money, or for any fixed-point calculation where accuracy is particularly important.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wtypes/ns-wtypes-cy-r1"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct CY
    {
        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public ULONG Lo;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public LONG Hi;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public LONGLONG int64;
    }
}
