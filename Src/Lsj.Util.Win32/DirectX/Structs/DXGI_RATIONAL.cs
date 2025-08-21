using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Represents a rational number.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgicommon/ns-dxgicommon-dxgi_rational"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This structure is a member of the <see cref="DXGI_MODE_DESC"/> structure.
    /// </para>
    /// <para>
    /// The <see cref="DXGI_RATIONAL"/> structure operates under the following rules:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// 0/0 is legal and will be interpreted as 0/1.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// 0/anything is interpreted as zero.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// If you are representing a whole number, the denominator should be 1.
    /// </description>
    /// </item>
    /// </list>
    /// </para>
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
