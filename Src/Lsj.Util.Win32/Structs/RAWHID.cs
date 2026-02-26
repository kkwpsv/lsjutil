using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.WindowMessages;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Describes the format of the raw input from a Human Interface Device (HID).
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-rawhid"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Each <see cref="WM_INPUT"/> can indicate several inputs, but all of the inputs come from the same HID.
    /// The size of the <see cref="bRawData"/> array is <see cref="dwSizeHid"/> * <see cref="dwCount"/>.
    /// </para>
    /// <para>
    /// For more information, see Interpreting HID Reports.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct RAWHID
    {
        /// <summary>
        /// The size, in bytes, of each HID input in <see cref="bRawData"/>.
        /// </summary>
        public DWORD dwSizeHid;

        /// <summary>
        /// The number of HID inputs in <see cref="bRawData"/>.
        /// </summary>
        public DWORD dwCount;

        /// <summary>
        /// The raw input data, as an array of bytes.
        /// </summary>
        public AnySizeArray<BYTE> bRawData;
    }
}
