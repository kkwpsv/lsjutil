using System;
using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Enums.CharacterSets;
using static Lsj.Util.Win32.Comdlg32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="CHOOSEFONT"/> Flags
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commdlg/ns-commdlg-choosefontw"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum CHOOSEFONTFlags : uint
    {
        /// <summary>
        /// Causes the dialog box to display the Apply button.
        /// You should provide a hook procedure to process <see cref="WM_COMMAND"/> messages for the Apply button.
        /// The hook procedure can send the <see cref="WM_CHOOSEFONT_GETLOGFONT"/> message to the dialog box to retrieve
        /// the address of the structure that contains the current selections for the font.
        /// </summary>
        CF_APPLY = 0x00000200,

        /// <summary>
        /// This flag is obsolete.
        /// To limit font selections to all scripts except those that use the OEM or Symbol character sets, use <see cref="CF_SCRIPTSONLY"/>.
        /// To get the original <see cref="CF_ANSIONLY"/> behavior, use <see cref="CF_SELECTSCRIPT"/> and
        /// specify <see cref="ANSI_CHARSET"/> in the <see cref="LOGFONT.lfCharSet"/> member
        /// of the <see cref="LOGFONT"/> structure pointed to by <see cref="CHOOSEFONT.lpLogFont"/>.
        /// </summary>
        [Obsolete]
        CF_ANSIONLY = 0x00000400,

        /// <summary>
        /// This flag is ignored for font enumeration.
        /// Windows Vista and Windows XP/2000:  Causes the dialog box to list the available printer and screen fonts.
        /// The <see cref="CHOOSEFONT.hDC"/> member is a handle to the device context or information context associated with the printer.
        /// This flag is a combination of the <see cref="CF_SCREENFONTS"/> and <see cref="CF_PRINTERFONTS"/> flags.
        /// </summary>
        CF_BOTH = 0x00000003,

        /// <summary>
        /// Causes the dialog box to display the controls that allow the user to specify strikeout, underline, and text color options.
        /// If this flag is set, you can use the <see cref="CHOOSEFONT.rgbColors"/> member to specify the initial text color.
        /// You can use the <see cref="LOGFONT.lfStrikeOut"/> and <see cref="LOGFONT.lfUnderline"/> members of the structure pointed to
        /// by <see cref="CHOOSEFONT.lpLogFont"/> to specify the initial settings of the strikeout and underline check boxes.
        /// <see cref="ChooseFont"/> can use these members to return the user's selections.
        /// </summary>
        CF_EFFECTS = 0x00000100,

        /// <summary>
        /// Enables the hook procedure specified in the <see cref="CHOOSEFONT.lpfnHook"/> member of this structure.
        /// </summary>
        CF_ENABLEHOOK = 0x00000008,

        /// <summary>
        /// Indicates that the <see cref="CHOOSEFONT.hInstance"/> and <see cref="CHOOSEFONT.lpTemplateName"/> members specify a dialog box template
        /// to use in place of the default template.
        /// </summary>
        CF_ENABLETEMPLATE = 0x00000010,

        /// <summary>
        /// Indicates that the <see cref="CHOOSEFONT.hInstance"/> member identifies a data block that contains a preloaded dialog box template.
        /// The system ignores the <see cref="CHOOSEFONT.lpTemplateName"/> member if this flag is specified.
        /// </summary>
        CF_ENABLETEMPLATEHANDLE = 0x00000020,

        /// <summary>
        /// <see cref="ChooseFont"/> should enumerate and allow selection of only fixed-pitch fonts.
        /// </summary>
        CF_FIXEDPITCHONLY = 0x00004000,

        /// <summary>
        /// <see cref="ChooseFont"/> should indicate an error condition if the user attempts to select a font or style that is not listed in the dialog box.
        /// </summary>
        CF_FORCEFONTEXIST = 0x00010000,

        /// <summary>
        /// <see cref="ChooseFont"/> should additionally display fonts that are set to Hide in Fonts Control Panel.
        /// Windows Vista and Windows XP/2000:  This flag is not supported until Windows 7.
        /// </summary>
        CF_INACTIVEFONTS = 0x02000000,

        /// <summary>
        /// <see cref="ChooseFont"/> should use the structure pointed to
        /// by the <see cref="CHOOSEFONT.lpLogFont"/> member to initialize the dialog box controls.
        /// </summary>
        CF_INITTOLOGFONTSTRUCT = 0x00000040,

        /// <summary>
        /// <see cref="ChooseFont"/> should select only font sizes within the range specified by the <see cref="CHOOSEFONT.nSizeMin"/>
        /// and <see cref="CHOOSEFONT.nSizeMax"/> members.
        /// </summary>
        CF_LIMITSIZE = 0x00002000,

        /// <summary>
        /// Same as the <see cref="CF_NOVECTORFONTS"/> flag.
        /// </summary>
        CF_NOOEMFONTS = 0x00000800,

        /// <summary>
        /// When using a <see cref="LOGFONT"/> structure to initialize the dialog box controls,
        /// use this flag to prevent the dialog box from displaying an initial selection for the font name combo box.
        /// This is useful when there is no single font name that applies to the text selection.
        /// </summary>
        CF_NOFACESEL = 0x00080000,

        /// <summary>
        /// Disables the Script combo box.
        /// When this flag is set, the <see cref="LOGFONT.lfCharSet"/> member of the <see cref="LOGFONT"/> structure
        /// is set to <see cref="DEFAULT_CHARSET"/> when <see cref="ChooseFont"/> returns.
        /// This flag is used only to initialize the dialog box.
        /// </summary>
        CF_NOSCRIPTSEL = 0x00800000,

        /// <summary>
        /// <see cref="ChooseFont"/> should not display or allow selection of font simulations.
        /// </summary>
        CF_NOSIMULATIONS = 0x00001000,

        /// <summary>
        /// When using a structure to initialize the dialog box controls,
        /// use this flag to prevent the dialog box from displaying an initial selection for the Font Size combo box.
        /// This is useful when there is no single font size that applies to the text selection.
        /// </summary>
        CF_NOSIZESEL = 0x00200000,

        /// <summary>
        /// When using a <see cref="LOGFONT"/> structure to initialize the dialog box controls,
        /// use this flag to prevent the dialog box from displaying an initial selection for the Font Style combo box.
        /// This is useful when there is no single font style that applies to the text selection.
        /// </summary>
        CF_NOSTYLESEL = 0x00100000,

        /// <summary>
        /// <see cref="ChooseFont"/> should not allow vector font selections.
        /// </summary>
        CF_NOVECTORFONTS = 0x00000800,

        /// <summary>
        /// Causes the Font dialog box to list only horizontally oriented fonts.
        /// </summary>
        CF_NOVERTFONTS = 0x01000000,

        /// <summary>
        /// This flag is ignored for font enumeration.
        /// Windows Vista and Windows XP/2000:
        /// Causes the dialog box to list only the fonts supported by the printer associated with the device context or information context
        /// identified by the <see cref="CHOOSEFONT.hDC"/> member.
        /// It also causes the font type description label to appear at the bottom of the Font dialog box.
        /// </summary>
        CF_PRINTERFONTS = 0x00000002,

        /// <summary>
        /// Specifies that <see cref="ChooseFont"/> should allow only the selection of scalable fonts.
        /// Scalable fonts include vector fonts, scalable printer fonts, TrueType fonts, and fonts scaled by other technologies.
        /// </summary>
        CF_SCALABLEONLY = 0x00020000,

        /// <summary>
        /// This flag is ignored for font enumeration.
        /// Windows Vista and Windows XP/2000:  Causes the dialog box to list only the screen fonts supported by the system.
        /// </summary>
        CF_SCREENFONTS = 0x00000001,

        /// <summary>
        /// ChooseFont should allow selection of fonts for all non-OEM and Symbol character sets, as well as the ANSI character set.
        /// This supersedes the <see cref="CF_ANSIONLY"/> value.
        /// </summary>
        CF_SCRIPTSONLY = 0x00000400,

        /// <summary>
        /// When specified on input, only fonts with the character set identified in the <see cref="LOGFONT.lfCharSet"/> member
        /// of the <see cref="LOGFONT"/> structure are displayed.
        /// The user will not be allowed to change the character set specified in the Scripts combo box.
        /// </summary>
        CF_SELECTSCRIPT = 0x00400000,

        /// <summary>
        /// Causes the dialog box to display the Help button.
        /// The <see cref="CHOOSEFONT.hwndOwner"/> member must specify the window to receive the <see cref="HELPMSGSTRING"/> registered messages
        /// that the dialog box sends when the user clicks the Help button.
        /// </summary>
        CF_SHOWHELP = 0x00000004,

        /// <summary>
        /// <see cref="ChooseFont"/> should only enumerate and allow the selection of TrueType fonts.
        /// </summary>
        CF_TTONLY = 0x00040000,

        /// <summary>
        /// The <see cref="CHOOSEFONT.lpszStyle"/> member is a pointer to a buffer that contains style data
        /// that <see cref="ChooseFont"/> should use to initialize the Font Style combo box.
        /// When the user closes the dialog box, ChooseFont copies style data for the user's selection to this buffer.
        /// To globalize your application, you should specify the style by using the <see cref="LOGFONT.lfWeight"/>
        /// and <see cref="LOGFONT.lfItalic"/> members of the <see cref="LOGFONT"/> structure pointed to by <see cref="CHOOSEFONT.lpLogFont"/>.
        /// The style name may change depending on the system user interface language.
        /// </summary>
        CF_USESTYLE = 0x00000080,

        /// <summary>
        /// Obsolete. <see cref="ChooseFont"/> ignores this flag.
        /// Windows Vista and Windows XP/2000:
        /// <see cref="ChooseFont"/> should allow only the selection of fonts available on both the printer and the display.
        /// If this flag is specified, the CF_SCREENSHOTS and <see cref="CF_PRINTERFONTS"/>, or <see cref="CF_BOTH"/> flags
        /// should also be specified.
        /// </summary>
        [Obsolete]
        CF_WYSIWYG = 0x00008000,
    }
}
