using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Enums.RasterCodes;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about an icon or a cursor.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-iconinfo"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ICONINFO
    {
        /// <summary>
        /// Specifies whether this structure defines an icon or a cursor.
        /// A value of <see cref="TRUE"/> specifies an icon; <see cref="FALSE"/> specifies a cursor.
        /// </summary>
        public BOOL fIcon;

        /// <summary>
        /// The x-coordinate of a cursor's hot spot.
        /// If this structure defines an icon, the hot spot is always in the center of the icon, and this member is ignored.
        /// </summary>
        public DWORD xHotspot;

        /// <summary>
        /// The y-coordinate of the cursor's hot spot.
        /// If this structure defines an icon, the hot spot is always in the center of the icon, and this member is ignored.
        /// </summary>
        public DWORD yHotspot;

        /// <summary>
        /// The icon bitmask bitmap.
        /// If this structure defines a black and white icon, this bitmask is formatted
        /// so that the upper half is the icon AND bitmask and the lower half is the icon XOR bitmask.
        /// Under this condition, the height should be an even multiple of two.
        /// If this structure defines a color icon, this mask only defines the AND bitmask of the icon.
        /// </summary>
        public HBITMAP hbmMask;

        /// <summary>
        /// A handle to the icon color bitmap.
        /// This member can be optional if this structure defines a black and white icon.
        /// The AND bitmask of <see cref="hbmMask"/> is applied with the <see cref="SRCAND"/> flag to the destination;
        /// subsequently, the color bitmap is applied (using XOR) to the destination by using the <see cref="SRCINVERT"/> flag.
        /// </summary>
        public HBITMAP hbmColor;
    }
}
