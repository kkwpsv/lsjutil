using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Flags used by the <see cref="DWM_THUMBNAIL_PROPERTIES"/> structure to indicate which of its members contain valid information.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/dwm/dwm-tnp-constants"/>
    /// </para>
    /// </summary>
    public enum DWM_TNP
    {
        /// <summary>
        /// A value for the <see cref="DWM_THUMBNAIL_PROPERTIES.rcDestination"/> member has been specified.
        /// </summary>
        DWM_TNP_RECTDESTINATION = 0x00000001,

        /// <summary>
        /// A value for the <see cref="DWM_THUMBNAIL_PROPERTIES.rcSource"/> member has been specified.
        /// </summary>
        DWM_TNP_RECTSOURCE = 0x00000002,

        /// <summary>
        /// A value for the <see cref="DWM_THUMBNAIL_PROPERTIES.opacity"/> member has been specified.
        /// </summary>
        DWM_TNP_OPACITY = 0x00000004,

        /// <summary>
        /// A value for the <see cref="DWM_THUMBNAIL_PROPERTIES.fVisible"/> member has been specified.
        /// </summary>
        DWM_TNP_VISIBLE = 0x00000008,

        /// <summary>
        /// A value for the <see cref="DWM_THUMBNAIL_PROPERTIES.fSourceClientAreaOnly"/> member has been specified.
        /// </summary>
        DWM_TNP_SOURCECLIENTAREAONLY = 0x00000010,
    }
}
