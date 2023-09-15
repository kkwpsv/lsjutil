using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="DISPLAYCONFIG_SOURCE_MODE"/> structure represents a point or an offset in a two-dimensional space.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-displayconfig_source_mode"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The arrangement of source surfaces on the desktop is controlled by the position member,
    /// which specifies the position in desktop coordinates of the upper-left corner of the source surface.
    /// The source surface that is positioned at (0, 0) is considered the primary.
    /// GDI has strict rules about how the source surfaces can be arranged in the desktop space.
    /// For example, there cannot be any gaps between source surfaces, and there can be no overlaps.
    /// The <see cref="SetDisplayConfig"/> function attempts to rearrange source surfaces in order to enforce these layout rules.
    /// The caller must make every effort to lay out the source surfaces correctly
    /// because GDI rearranges the sources in an undefined manner to enforce the layout rules.
    /// The resultant layout may not be what the caller wanted to achieve.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DISPLAYCONFIG_SOURCE_MODE
    {
        /// <summary>
        /// The width in pixels of the source mode.
        /// </summary>
        public UINT32 width;

        /// <summary>
        /// The height in pixels of the source mode.
        /// </summary>
        public UINT32 height;

        /// <summary>
        /// A value from the <see cref="DISPLAYCONFIG_PIXELFORMAT"/> enumeration that specifies the pixel format of the source mode.
        /// </summary>
        public DISPLAYCONFIG_PIXELFORMAT pixelFormat;

        /// <summary>
        /// A <see cref="POINTL"/> structure that specifies the position in the desktop coordinate space of the upper-left corner of this source surface.
        /// The source surface that is located at (0, 0) is always the primary source surface.
        /// </summary>
        public POINTL position;
    }
}
