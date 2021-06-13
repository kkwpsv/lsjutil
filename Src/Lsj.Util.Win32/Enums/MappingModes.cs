namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Mapping Modes
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/gdi/mapping-modes-and-translations"/>
    /// </para>
    /// </summary>
    public enum MappingModes
    {
        /// <summary>
        /// Each unit in page space is mapped to one pixel; that is, no scaling is performed at all.
        /// When no translation is in effect (this is the default),
        /// page space in the <see cref="MM_TEXT"/> mapping mode is equivalent to physical device space.
        /// The value of x increases from left to right.
        /// The value of y increases from top to bottom.
        /// </summary>
        MM_TEXT = 1,

        /// <summary>
        /// Each unit in page space is mapped to 0.1 millimeter in device space.
        /// The value of x increases from left to right.
        /// The value of y increases from bottom to top.
        /// </summary>
        MM_LOMETRIC = 2,

        /// <summary>
        /// Each unit in page space is mapped to 0.01 millimeter in device space.
        /// The value of x increases from left to right.
        /// The value of y increases from bottom to top.
        /// </summary>
        MM_HIMETRIC = 3,

        /// <summary>
        /// Each unit in page space is mapped to 0.01 inch in device space.
        /// The value of x increases from left to right.
        /// The value of y increases from bottom to top.
        /// </summary>
        MM_LOENGLISH = 4,

        /// <summary>
        /// Each unit in page space is mapped to 0.001 inch in device space.
        /// The value of x increases from left to right.
        /// The value of y increases from bottom to top.
        /// </summary>
        MM_HIENGLISH = 5,

        /// <summary>
        /// Each unit in page space is mapped to one twentieth of a printer's point (1/1440 inch).
        /// The value of x increases from left to right.
        /// The value of y increases from bottom to top.
        /// </summary>
        MM_TWIPS = 6,

        /// <summary>
        /// Each unit in page space is mapped to an application-defined unit in device space.
        /// The axes are always equally scaled.
        /// The orientation of the axes may be specified by the application.
        /// </summary>
        MM_ISOTROPIC = 7,

        /// <summary>
        /// ach unit in page space is mapped to an application-specified unit in device space.
        /// The axis may or may not be equally scaled (for example, a circle drawn in world space may appear to be an ellipse
        /// when depicted on a given device).
        /// The orientation of the axis is also specified by the application.
        /// </summary>
        MM_ANISOTROPIC = 8,
    }
}
