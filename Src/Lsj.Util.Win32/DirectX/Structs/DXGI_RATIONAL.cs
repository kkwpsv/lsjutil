using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Represents a rational number.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgicommon/ns-dxgicommon-dxgi_rational?redirectedfrom=MSDN"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is a member of the <see cref="DXGI_MODE_DESC"/> structure.
    /// The <see cref="DXGI_RATIONAL"/> structure operates under the following rules:
    /// 0/0 is legal and will be interpreted as 0/1.
    /// 0/anything is interpreted as zero.
    /// If you are representing a whole number, the denominator should be 1.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DXGI_RATIONAL
    {
        /// <summary>
        /// An unsigned integer value representing the top of the rational number.
        /// </summary>
        public UINT Numerator;

        /// <summary>
        /// An unsigned integer value representing the bottom of the rational number.
        /// </summary>
        public UINT Denominator;
    }
}
