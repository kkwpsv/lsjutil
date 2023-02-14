using System;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="DrawText"/> FormatFlags
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-drawtext"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum DrawTextFormatFlags : uint
    {
        /// <summary>
        /// Justifies the text to the top of the rectangle.
        /// </summary>
        DT_TOP = 0x00000000,

        /// <summary>
        /// Aligns text to the left.
        /// </summary>
        DT_LEFT = 0x00000000,

        /// <summary>
        /// Centers text horizontally in the rectangle.
        /// </summary>
        DT_CENTER = 0x00000001,

        /// <summary>
        /// Aligns text to the right.
        /// </summary>
        DT_RIGHT = 0x00000002,

        /// <summary>
        /// Centers text vertically.
        /// This value is used only with the <see cref="DT_SINGLELINE"/> value.
        /// </summary>
        DT_VCENTER = 0x00000004,

        /// <summary>
        /// Justifies the text to the bottom of the rectangle.
        /// This value is used only with the <see cref="DT_SINGLELINE"/> value.
        /// </summary>
        DT_BOTTOM = 0x00000008,

        /// <summary>
        /// Breaks words. Lines are automatically broken between words if a word would extend past the edge of the rectangle specified by the lpRect parameter.
        /// A carriage return-line feed sequence also breaks the line.
        /// If this is not specified, output is on one line.
        /// </summary>
        DT_WORDBREAK = 0x00000010,

        /// <summary>
        /// Displays text on a single line only.
        /// Carriage returns and line feeds do not break the line.
        /// </summary>
        DT_SINGLELINE = 0x00000020,

        /// <summary>
        /// Expands tab characters.
        /// The default number of characters per tab is eight.
        /// The <see cref="DT_WORD_ELLIPSIS"/>, <see cref="DT_PATH_ELLIPSIS"/>, and <see cref="DT_END_ELLIPSIS"/> values
        /// cannot be used with the <see cref="DT_EXPANDTABS"/> value.
        /// </summary>
        DT_EXPANDTABS = 0x00000040,

        /// <summary>
        /// Sets tab stops. Bits 15-8 (high-order byte of the low-order word) of the uFormat parameter specify the number of characters for each tab.
        /// The default number of characters per tab is eight.
        /// The <see cref="DT_CALCRECT"/>, <see cref="DT_EXTERNALLEADING"/>, <see cref="DT_INTERNAL"/>, <see cref="DT_NOCLIP"/>,
        /// and <see cref="DT_NOPREFIX"/> values cannot be used with the <see cref="DT_TABSTOP"/> value.
        /// </summary>
        DT_TABSTOP = 0x00000080,

        /// <summary>
        /// Draws without clipping.
        /// <see cref="DrawText"/> is somewhat faster when <see cref="DT_NOCLIP"/> is used.
        /// </summary>
        DT_NOCLIP = 0x00000100,

        /// <summary>
        /// Includes the font external leading in line height.
        /// Normally, external leading is not included in the height of a line of text.
        /// </summary>
        DT_EXTERNALLEADING = 0x00000200,

        /// <summary>
        /// Determines the width and height of the rectangle.
        /// If there are multiple lines of text, <see cref="DrawText"/> uses the width of the rectangle pointed to by the lpRect parameter
        /// and extends the base of the rectangle to bound the last line of text.
        /// If the largest word is wider than the rectangle, the width is expanded.
        /// If the text is less than the width of the rectangle, the width is reduced.
        /// If there is only one line of text, <see cref="DrawText"/> modifies the right side of the rectangle so that it bounds the last character in the line.
        /// In either case, DrawText returns the height of the formatted text but does not draw the text.
        /// </summary>
        DT_CALCRECT = 0x00000400,

        /// <summary>
        /// Turns off processing of prefix characters.
        /// Normally, <see cref="DrawText"/> interprets the mnemonic-prefix character &amp; as a directive to underscore the character that follows,
        /// and the mnemonic-prefix characters &amp;&amp; as a directive to print a single &amp;.
        /// By specifying <see cref="DT_NOPREFIX"/>, this processing is turned off.
        /// For example,
        /// Example:
        /// input string: "A&amp;bc&amp;&amp;d"
        /// normal: "Abc&amp;d"
        /// DT_NOPREFIX: "A&amp;bc&amp;&amp;d"
        /// Compare with <see cref="DT_HIDEPREFIX"/> and <see cref="DT_PREFIXONLY"/>.
        /// </summary>
        DT_NOPREFIX = 0x00000800,

        /// <summary>
        /// Uses the system font to calculate text metrics.
        /// </summary>
        DT_INTERNAL = 0x00001000,

        /// <summary>
        /// Duplicates the text-displaying characteristics of a multiline edit control.
        /// Specifically, the average character width is calculated in the same manner as for an edit control,
        /// and the function does not display a partially visible last line.
        /// </summary>
        DT_EDITCONTROL = 0x00002000,

        /// <summary>
        /// For displayed text, replaces characters in the middle of the string with ellipses so that the result fits in the specified rectangle.
        /// If the string contains backslash (\) characters, <see cref="DT_PATH_ELLIPSIS"/> preserves as much as possible of the text after the last backslash.
        /// The string is not modified unless the <see cref="DT_MODIFYSTRING"/> flag is specified.
        /// Compare with <see cref="DT_END_ELLIPSIS"/> and <see cref="DT_WORD_ELLIPSIS"/>.
        /// </summary>
        DT_PATH_ELLIPSIS = 0x00004000,

        /// <summary>
        /// For displayed text, if the end of a string does not fit in the rectangle, it is truncated and ellipses are added.
        /// If a word that is not at the end of the string goes beyond the limits of the rectangle, it is truncated without ellipses.
        /// The string is not modified unless the <see cref="DT_MODIFYSTRING"/> flag is specified.
        /// Compare with <see cref="DT_PATH_ELLIPSIS"/> and <see cref="DT_WORD_ELLIPSIS"/>.
        /// </summary>
        DT_END_ELLIPSIS = 0x00008000,

        /// <summary>
        /// Modifies the specified string to match the displayed text.
        /// This value has no effect unless <see cref="DT_END_ELLIPSIS"/> or <see cref="DT_PATH_ELLIPSIS"/> is specified.
        /// </summary>
        DT_MODIFYSTRING = 0x00010000,

        /// <summary>
        /// Layout in right-to-left reading order for bidirectional text when the font selected into the hdc is a Hebrew or Arabic font.
        /// The default reading order for all text is left-to-right.
        /// </summary>
        DT_RTLREADING = 0x00020000,

        /// <summary>
        /// Truncates any word that does not fit in the rectangle and adds ellipses.
        /// Compare with <see cref="DT_END_ELLIPSIS"/> and <see cref="DT_PATH_ELLIPSIS"/>.
        /// </summary>
        DT_WORD_ELLIPSIS = 0x00040000,

        /// <summary>
        /// Prevents a line break at a DBCS (double-wide character string), so that the line breaking rule is equivalent to SBCS strings.
        /// For example, this can be used in Korean windows, for more readability of icon labels.
        /// This value has no effect unless <see cref="DT_WORDBREAK"/> is specified.
        /// </summary>
        DT_NOFULLWIDTHCHARBREAK = 0x00080000,

        /// <summary>
        /// Ignores the ampersand (&amp;) prefix character in the text.
        /// The letter that follows will not be underlined, but other mnemonic-prefix characters are still processed.
        /// Example:
        /// input string: "A&amp;bc&amp;&amp;d"
        /// normal: "Abc&amp;d"
        /// DT_HIDEPREFIX: "Abc&amp;d"
        /// Compare with <see cref="DT_NOPREFIX"/> and <see cref="DT_PREFIXONLY"/>.
        /// </summary>
        DT_HIDEPREFIX = 0x00100000,

        /// <summary>
        /// Draws only an underline at the position of the character following the ampersand (&amp;) prefix character.
        /// Does not draw any other characters in the string.
        /// For example,
        /// Example:
        /// input string: "A&amp;bc&amp;&amp;d"
        /// normal: "Abc&amp;d"
        /// DT_PREFIXONLY: " _ "
        /// Compare with <see cref="DT_HIDEPREFIX"/> and <see cref="DT_NOPREFIX"/>.
        /// </summary>
        DT_PREFIXONLY = 0x00200000,
    }
}
