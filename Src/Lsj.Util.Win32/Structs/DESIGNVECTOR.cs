using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="DESIGNVECTOR"/> structure is used by an application to specify values for the axes of a multiple master font.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/ns-wingdi-designvector"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The dvNumAxes member determines the actual size of dvValues, and thus, of <see cref="DESIGNVECTOR"/>.
    /// The constant <see cref="MM_MAX_NUMAXES"/>, which is 16, specifies the maximum allowed size of the dvValues array.
    /// The PostScript Open Type Font does not support multiple master functionality.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DESIGNVECTOR
    {
        /// <summary>
        /// STAMP_DESIGNVECTOR
        /// </summary>
        public const uint STAMP_DESIGNVECTOR = (0x8000000 + 'd' + ('v' << 8));

        /// <summary>
        /// Reserved. Must be <see cref="STAMP_DESIGNVECTOR"/>.
        /// </summary>
        public DWORD dvReserved;

        /// <summary>
        /// Number of values in the dvValues array.
        /// </summary>
        public DWORD dvNumAxes;

        /// <summary>
        /// An array specifying the values of the axes of a multiple master OpenType font.
        /// This array corresponds to the <see cref="AXESLIST.axlAxisInfo"/> array in the <see cref="AXESLIST"/> structure.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = MM_MAX_NUMAXES)]
        public LONG[] dvValues;
    }
}
