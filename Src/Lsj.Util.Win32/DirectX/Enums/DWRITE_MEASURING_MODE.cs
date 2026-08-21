namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Indicates the measuring method used for text layout.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dcommon/ne-dcommon-dwrite_measuring_mode"/>
    /// </para>
    /// </summary>
    public enum DWRITE_MEASURING_MODE
    {
        /// <summary>
        /// Specifies that text is measured using glyph ideal metrics whose values are independent to the current display resolution.
        /// </summary>
        DWRITE_MEASURING_MODE_NATURAL,

        /// <summary>
        /// Specifies that text is measured using glyph display-compatible metrics whose values tuned for the current display resolution.
        /// </summary>
        DWRITE_MEASURING_MODE_GDI_CLASSIC,

        /// <summary>
        /// Specifies that text is measured using the same glyph display metrics
        /// as text measured by GDI using a font created with <see cref="CLEARTYPE_NATURAL_QUALITY"/>.
        /// </summary>
        DWRITE_MEASURING_MODE_GDI_NATURAL
    }
}
