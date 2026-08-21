using System;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies whether text snapping is suppressed or clipping to the layout rectangle is enabled.
    /// This enumeration allows a bitwise combination of its member values.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_draw_text_options"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum D2D1_DRAW_TEXT_OPTIONS : uint
    {
        /// <summary>
        /// Text is not vertically snapped to pixel boundaries.
        /// This setting is recommended for text that is being animated.
        /// </summary>
        D2D1_DRAW_TEXT_OPTIONS_NO_SNAP = 0x00000001,

        /// <summary>
        /// Text is clipped to the layout rectangle.
        /// </summary>
        D2D1_DRAW_TEXT_OPTIONS_CLIP = 0x00000002,

        /// <summary>
        /// In Windows 8.1 and later, text is rendered using color versions of glyphs, if defined by the font.
        /// </summary>
        D2D1_DRAW_TEXT_OPTIONS_ENABLE_COLOR_FONT = 0x00000004,

        /// <summary>
        /// Bitmap origins of color glyph bitmaps are not snapped.
        /// </summary>
        D2D1_DRAW_TEXT_OPTIONS_DISABLE_COLOR_BITMAP_SNAPPING = 0x00000008,

        /// <summary>
        /// Text is vertically snapped to pixel boundaries and is not clipped to the layout rectangle.
        /// </summary>
        D2D1_DRAW_TEXT_OPTIONS_NONE = 0x00000000,

        /// <summary>
        /// 
        /// </summary>
        D2D1_DRAW_TEXT_OPTIONS_FORCE_DWORD = 0xffffffff
    }
}
