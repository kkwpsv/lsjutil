using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="DISPLAYCONFIG_DESKTOP_IMAGE_INFO"/> structure contains information about the image displayed on the desktop.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-displayconfig_desktop_image_info"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DISPLAYCONFIG_DESKTOP_IMAGE_INFO
    {
        /// <summary>
        /// A <see cref="POINTL"/> structure that specifies the size of the VidPn source surface that is being displayed on the monitor.
        /// </summary>
        public POINTL PathSourceSize;

        /// <summary>
        /// A <see cref="RECTL"/> structure that defines where the desktop image will be positioned within path source.
        /// Region must be completely inside the bounds of the path source size.
        /// </summary>
        public RECTL DesktopImageRegion;

        /// <summary>
        /// A <see cref="RECTL"/> structure that defines which part of the desktop image for this clone group will be displayed on this path.
        /// This currently must be set to the desktop size.
        /// </summary>
        public RECTL DesktopImageClip;
    }
}
