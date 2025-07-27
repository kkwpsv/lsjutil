using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about an icon or a cursor.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-iconinfo"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// For monochrome icons, the <see cref="hbmMask"/> is twice the height of the icon
    /// (with the AND mask on top and the XOR mask on the bottom), and <see cref="hbmColor"/> is <see cref="NULL"/>.
    /// Also, in this case the height should be an even multiple of two.
    /// </para>
    /// <para>
    /// For color icons, the <see cref="hbmMask"/> and <see cref="hbmColor"/> bitmaps are the same size, each of which is the size of the icon.
    /// </para>
    /// <para>
    /// You can use a <see cref="GetObject"/> function to get contents
    /// of <see cref="hbmMask"/> and <see cref="hbmColor"/> in the <see cref="BITMAP"/> structure.
    /// The bitmap bits can be obtained with call to <see cref="GetDIBits"/> on the bitmaps in this structure.
    /// </para>
    /// </remarks>
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
        /// A handle to the icon monochrome mask bitmap.
        /// </summary>
        public HBITMAP hbmMask;

        /// <summary>
        /// A handle to the icon color bitmap.
        /// </summary>
        public HBITMAP hbmColor;
    }
}
