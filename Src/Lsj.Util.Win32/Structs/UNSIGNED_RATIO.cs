using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Defines a data type used by the Desktop Window Manager (DWM) APIs.
    /// It represents a generic ratio and is used for different purposes and units even within a single API.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/ns-dwmapi-unsigned_ratio"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct UNSIGNED_RATIO
    {
        /// <summary>
        /// The ratio numerator.
        /// </summary>
        public UINT32 uiNumerator;

        /// <summary>
        /// The ratio denominator.
        /// </summary>
        public UINT32 uiDenominator;
    }
}
