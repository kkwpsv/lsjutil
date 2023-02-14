using static Lsj.Util.Win32.Enums.ComboBoxControlMessages;
using static Lsj.Util.Win32.Enums.ComboBoxExMessages;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// ComboBoxEx Styles
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/controls/comboboxex-control-extended-styles"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// You set and retrieve the combobox extended styles by using <see cref="CBEM_SETEXTENDEDSTYLE"/> and <see cref="CBEM_GETEXTENDEDSTYLE"/> messages.
    /// </remarks>
    public enum ComboBoxExStyles : uint
    {
        /// <summary>
        /// BSTR searches in the list will be case sensitive.
        /// This includes searches as a result of text being typed in the edit box and the <see cref="CB_FINDSTRINGEXACT"/> message.
        /// </summary>
        CBES_EX_CASESENSITIVE = 0x00000010,

        /// <summary>
        /// The edit box and the dropdown list will not display item images.
        /// </summary>
        CBES_EX_NOEDITIMAGE = 0x00000001,

        /// <summary>
        /// The edit box and the dropdown list will not display item images.
        /// </summary>
        CBES_EX_NOEDITIMAGEINDENT = 0x00000002,

        /// <summary>
        /// Allows the ComboBoxEx control to be vertically sized smaller than its contained combo box control.
        /// If the ComboBoxEx is sized smaller than the combo box, the combo box will be clipped.
        /// </summary>
        CBES_EX_NOSIZELIMIT = 0x00000008,

        /// <summary>
        /// Windows NT only.
        /// The edit box will use the slash (/), backslash (\), and period (.) characters as word delimiters.
        /// This makes keyboard shortcuts for word-by-word cursor movement effective in path names and URLs.
        /// </summary>
        CBES_EX_PATHWORDBREAKPROC = 0x00000004,

        /// <summary>
        /// Windows Vista and later.
        /// Causes items in the drop-down list and the edit box (when the edit box is read only) to be truncated
        /// with an ellipsis ("...") rather than just clipped by the edge of the control.
        /// This is useful when the control needs to be set to a fixed width, yet the entries in the list may be long.
        /// </summary>
        CBES_EX_TEXTENDELLIPSIS = 0x00000020,
    }
}
