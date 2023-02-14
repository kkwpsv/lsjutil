﻿namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="FamilyFont"/> Enumeration specifies the font family.
    /// Font families describe the look of a font in a general way.
    /// They are intended for specifying fonts when the exact typeface desired is not available.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-wmf/9a632766-1f1c-4e2b-b1a4-f5b1a45f99ad"/>
    /// </para>
    /// </summary>
    public enum FamilyFont
    {
        /// <summary>
        ///  The default font is specified, which is implementation-dependent.
        /// </summary>
        FF_DONTCARE = 0x00,

        /// <summary>
        /// Fonts with variable stroke widths, which are proportional to the actual widths of the glyphs, and which have serifs.
        /// "MS Serif" is an example.
        /// </summary>
        FF_ROMAN = 0x01,

        /// <summary>
        /// Fonts with variable stroke widths, which are proportional to the actual widths of the glyphs, and which do not have serifs.
        /// "MS Sans Serif" is an example.
        /// </summary>
        FF_SWISS = 0x02,

        /// <summary>
        /// Fonts with constant stroke width, with or without serifs.
        /// Fixed-width fonts are usually modern. "Pica", "Elite", and "Courier New" are examples.
        /// </summary>
        FF_MODERN = 0x03,

        /// <summary>
        /// Fonts designed to look like handwriting. "Script" and "Cursive" are examples.
        /// </summary>
        FF_SCRIPT = 0x04,

        /// <summary>
        /// Novelty fonts. "Old English" is an example.
        /// </summary>
        FF_DECORATIVE = 0x05
    }
}
