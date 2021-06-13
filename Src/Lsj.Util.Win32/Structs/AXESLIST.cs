using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="AXESLIST"/> structure contains information on all the axes of a multiple master font.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/ns-wingdi-axeslistw"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The PostScript Open Type Font does not support multiple master functionality.
    /// The information on the axes of a multiple master font are specified by the <see cref="AXISINFO"/> structures.
    /// The <see cref="axlNumAxes"/> member specifies the actual size of <see cref="axlAxisInfo"/>,
    /// while <see cref="MM_MAX_NUMAXES"/>, which equals 16, is the maximum allowed size of <see cref="axlAxisInfo"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct AXESLIST
    {
        /// <summary>
        /// STAMP_AXESLIST
        /// </summary>
        public const uint STAMP_AXESLIST = (0x8000000 + 'a' + ('l' << 8));

        /// <summary>
        /// Reserved. Must be <see cref="STAMP_AXESLIST"/>.
        /// </summary>
        public DWORD axlReserved;

        /// <summary>
        /// Number of axes for a specified multiple master font.
        /// </summary>
        public DWORD axlNumAxes;

        /// <summary>
        /// An array of <see cref="AXISINFO"/> structures.
        /// Each <see cref="AXISINFO"/> structure contains information on an axis of a specified multiple master font.
        /// This corresponds to the dvValues array in the <see cref="DESIGNVECTOR"/> structure.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = MM_MAX_NUMAXES)]
        public AXISINFO[] axlAxisInfo;
    }
}
