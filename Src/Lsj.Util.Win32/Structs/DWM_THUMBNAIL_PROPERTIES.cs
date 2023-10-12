using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Dwmapi;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Specifies Desktop Window Manager (DWM) thumbnail properties.
    /// Used by the <see cref="DwmUpdateThumbnailProperties"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/ns-dwmapi-dwm_thumbnail_properties"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DWM_THUMBNAIL_PROPERTIES
    {
        /// <summary>
        /// A bitwise combination of DWM thumbnail constant values that indicates which members of this structure are set.
        /// </summary>
        public DWM_TNP dwFlags;

        /// <summary>
        /// The area in the destination window where the thumbnail will be rendered.
        /// </summary>
        public RECT rcDestination;

        /// <summary>
        /// The region of the source window to use as the thumbnail.
        /// By default, the entire window is used as the thumbnail.
        /// </summary>
        public RECT rcSource;

        /// <summary>
        /// The opacity with which to render the thumbnail.
        /// 0 is fully transparent while 255 is fully opaque.
        /// The default value is 255.
        /// </summary>
        public BYTE opacity;

        /// <summary>
        /// <see cref="TRUE"/> to make the thumbnail visible; otherwise, <see cref="FALSE"/>.
        /// The default is <see cref="FALSE"/>.
        /// </summary>
        public BOOL fVisible;

        /// <summary>
        /// <see cref="TRUE"/> to use only the thumbnail source's client area; otherwise, <see cref="FALSE"/>.
        /// The default is <see cref="FALSE"/>.
        /// </summary>
        public BOOL fSourceClientAreaOnly;
    }
}
