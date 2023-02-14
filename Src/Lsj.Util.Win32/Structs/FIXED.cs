using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="FIXED"/> structure contains the integral and fractional parts of a fixed-point real number.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-fixed"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="FIXED"/> structure is used to describe the elements of the <see cref="MAT2"/> structure.
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode, Size = 4)]
    public struct FIXED
    {
        /// <summary>
        /// The fractional part of the number.
        /// </summary>
        [FieldOffset(0)]
        public WORD fract;

        /// <summary>
        /// The integer part of the number.
        /// </summary>
        [FieldOffset(2)]
        public short value;
    }
}
