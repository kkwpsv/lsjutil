using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="AXISINFO"/> structure contains information about an axis of a multiple master font.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/ns-wingdi-axisinfow"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="AXISINFO"/> structure contains the name of an axis in a multiple master font
    /// and also the minimum and maximum possible values for the axis.
    /// The length of the name is <see cref="MM_MAX_AXES_NAMELEN"/>, which equals 16.
    /// An application queries these values before setting its desired values in the <see cref="DESIGNVECTOR"/> array.
    /// The PostScript Open Type Font does not support multiple master functionality.
    /// For the ANSI version of this structure, <see cref="axAxisName"/> must be an array of bytes.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct AXISINFO
    {
        /// <summary>
        /// The minimum value for this axis.
        /// </summary>
        public LONG axMinValue;

        /// <summary>
        /// The maximum value for this axis.
        /// </summary>
        public LONG axMaxValue;

        /// <summary>
        /// The name of the axis, specified as an array of characters.
        /// </summary>
        public ByValStringStructForSize16 axAxisName;
    }
}
