using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Comdlg32;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.CharacterSets;
using static Lsj.Util.Win32.Enums.FontDialogFlags;
using static Lsj.Util.Win32.Enums.FontTypes;
using static Lsj.Util.Win32.Enums.FontWeights;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information that the <see cref="ChooseFont"/> function uses to initialize the Font dialog box.
    /// After the user closes the dialog box, the system returns information about the user's selection in this structure.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commdlg/ns-commdlg-choosefontw"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct CHOOSEFONT
    {
        /// <summary>
        /// The length of the structure, in bytes.
        /// </summary>
        public DWORD lStructSize;

        /// <summary>
        /// A handle to the window that owns the dialog box.
        /// This member can be any valid window handle, or it can be <see cref="NULL"/> if the dialog box has no owner.
        /// </summary>
        public HWND hwndOwner;

        /// <summary>
        /// <para>
        /// This member is ignored by the <see cref="ChooseFont"/> function.
        /// </para>
        /// <para>
        /// Windows Vista and Windows XP/2000:
        /// A handle to the device context or information context of the printer whose fonts will be listed in the dialog box.
        /// This member is used only if the <see cref="Flags"/> member specifies the <see cref="CF_PRINTERFONTS"/> or <see cref="CF_BOTH"/> flag;
        /// otherwise, this member is ignored.
        /// </para>
        /// </summary>
        public HDC hDC;

        /// <summary>
        /// A pointer to a <see cref="LOGFONT"/> structure.
        /// If you set the <see cref="CF_INITTOLOGFONTSTRUCT"/> flag in the <see cref="Flags"/> member and initialize the other members,
        /// the <see cref="ChooseFont"/> function initializes the dialog box with a font that matches the <see cref="LOGFONT"/> members.
        /// If the user clicks the OK button, <see cref="ChooseFont"/> sets the members of the <see cref="LOGFONT"/> structure based on the user's selections.
        /// </summary>
        public nint lpLogFont;

        /// <summary>
        /// The size of the selected font, in units of 1/10 of a point.
        /// The <see cref="ChooseFont"/> function sets this value after the user closes the dialog box.
        /// </summary>
        public INT iPointSize;

        /// <summary>
        /// <para>
        /// A set of bit flags that you can use to initialize the Font dialog box.
        /// When the dialog box returns, it sets these flags to indicate the user input.
        /// This member can be one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="CF_APPLY"/>
        /// </term>
        /// <term>
        /// Causes the dialog box to display the Apply button.
        /// You should provide a hook procedure to process <see cref="WM_COMMAND"/> messages for the Apply button.
        /// The hook procedure can send the <see cref="WM_CHOOSEFONT_GETLOGFONT"/> message to the dialog box
        /// to retrieve the address of the structure that contains the current selections for the font.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CF_ANSIONLY"/>
        /// </term>
        /// <term>
        /// This flag is obsolete.
        /// To limit font selections to all scripts except those that use the OEM or Symbol character sets, use <see cref="CF_SCRIPTSONLY"/>.
        /// To get the original <see cref="CF_ANSIONLY"/> behavior, use <see cref="CF_SELECTSCRIPT"/>
        /// and specify <see cref="ANSI_CHARSET"/> in the <see cref="LOGFONT.lfCharSet"/> member of the <see cref="LOGFONT"/> structure pointed to by <see cref="lpLogFont"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CF_BOTH"/>
        /// </term>
        /// <term>
        /// <para>
        /// This flag is ignored for font enumeration.
        /// </para>
        /// <para>
        /// Windows Vista and Windows XP/2000: Causes the dialog box to list the available printer and screen fonts.
        /// The <see cref="hDC"/> member is a handle to the device context or information context associated with the printer.
        /// This flag is a combination of the <see cref="CF_SCREENFONTS"/> and <see cref="CF_PRINTERFONTS"/> flags.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CF_EFFECTS"/>
        /// </term>
        /// <term>
        /// Causes the dialog box to display the controls that allow the user to specify strikeout, underline, and text color options.
        /// If this flag is set, you can use the <see cref="rgbColors"/> member to specify the initial text color.
        /// You can use the <see cref="LOGFONT.lfStrikeOut"/> and <see cref="LOGFONT.lfUnderline"/> members of the structure
        /// pointed to by <see cref="lpLogFont"/> to specify the initial settings of the strikeout and underline check boxes.
        /// <see cref="ChooseFont"/> can use these members to return the user's selections.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CF_ENABLEHOOK"/>
        /// </term>
        /// <term>
        /// Enables the hook procedure specified in the <see cref="lpfnHook"/> member of this structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CF_ENABLETEMPLATE"/>
        /// </term>
        /// <term>
        /// Indicates that the <see cref="hInstance"/> and <see cref="lpTemplateName"/> members specify a dialog box template to use in place of the default template.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CF_ENABLETEMPLATEHANDLE"/>
        /// </term>
        /// <term>
        /// Indicates that the <see cref="hInstance"/> member identifies a data block that contains a preloaded dialog box template.
        /// The system ignores the <see cref="lpTemplateName"/> member if this flag is specified.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CF_FIXEDPITCHONLY"/>
        /// </term>
        /// <term>
        /// <see cref="ChooseFont"/> should enumerate and allow selection of only fixed-pitch fonts.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CF_FORCEFONTEXIST"/>
        /// </term>
        /// <term>
        /// <see cref="ChooseFont"/> should indicate an error condition if the user attempts to select a font or style that is not listed in the dialog box.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CF_INACTIVEFONTS"/>
        /// </term>
        /// <term>
        /// <para>
        /// <see cref="ChooseFont"/> should additionally display fonts that are set to Hide in Fonts Control Panel.
        /// </para>
        /// <para>
        /// Windows Vista and Windows XP/2000: This flag is not supported until Windows 7.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CF_INITTOLOGFONTSTRUCT"/>
        /// </term>
        /// <term>
        /// <see cref="ChooseFont"/> should use the structure pointed to by the <see cref="lpLogFont"/> member to initialize the dialog box controls.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CF_LIMITSIZE"/>
        /// </term>
        /// <term>
        /// <see cref="ChooseFont"/> should select only font sizes within the range specified by the <see cref="nSizeMin"/> and <see cref="nSizeMax"/> members.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CF_NOOEMFONTS"/>
        /// </term>
        /// <term>
        /// Same as the <see cref="CF_NOVECTORFONTS"/> flag.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CF_NOFACESEL"/>
        /// </term>
        /// <term>
        /// When using a <see cref="LOGFONT"/> structure to initialize the dialog box controls,
        /// use this flag to prevent the dialog box from displaying an initial selection for the font name combo box.
        /// This is useful when there is no single font name that applies to the text selection.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CF_NOSCRIPTSEL"/>
        /// </term>
        /// <term>
        /// Disables the Script combo box.
        /// When this flag is set, the <see cref="LOGFONT.lfCharSet"/> member of the <see cref="LOGFONT"/> structure
        /// is set to <see cref="DEFAULT_CHARSET"/> when <see cref="ChooseFont"/> returns.
        /// This flag is used only to initialize the dialog box.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CF_NOSIMULATIONS"/>
        /// </term>
        /// <term>
        /// <see cref="ChooseFont"/> should not display or allow selection of font simulations.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CF_NOSIZESEL"/>
        /// </term>
        /// <term>
        /// When using a structure to initialize the dialog box controls,
        /// use this flag to prevent the dialog box from displaying an initial selection for the Font Size combo box.
        /// This is useful when there is no single font size that applies to the text selection.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CF_NOSTYLESEL"/>
        /// </term>
        /// <term>
        /// When using a <see cref="LOGFONT"/> structure to initialize the dialog box controls,
        /// use this flag to prevent the dialog box from displaying an initial selection for the Font Style combo box.
        /// This is useful when there is no single font style that applies to the text selection.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CF_NOVECTORFONTS"/>
        /// </term>
        /// <term>
        /// <see cref="ChooseFont"/> should not allow vector font selections.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CF_NOVERTFONTS"/>
        /// </term>
        /// <term>
        /// Causes the Font dialog box to list only horizontally oriented fonts.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CF_PRINTERFONTS"/>
        /// </term>
        /// <term>
        /// <para>
        /// This flag is ignored for font enumeration.
        /// </para>
        /// <para>
        /// Windows Vista and Windows XP/2000:
        /// Causes the dialog box to list only the fonts supported by the printer associated with the device context
        /// or information context identified by the <see cref="hDC"/> member.
        /// It also causes the font type description label to appear at the bottom of the Font dialog box.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CF_SCALABLEONLY"/>
        /// </term>
        /// <term>
        /// Specifies that <see cref="ChooseFont"/> should allow only the selection of scalable fonts.
        /// Scalable fonts include vector fonts, scalable printer fonts, TrueType fonts, and fonts scaled by other technologies.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CF_SCREENFONTS"/>
        /// </term>
        /// <term>
        /// <para>
        /// This flag is ignored for font enumeration.
        /// </para>
        /// <para>
        /// Windows Vista and Windows XP/2000: Causes the dialog box to list only the screen fonts supported by the system.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CF_SCRIPTSONLY"/>
        /// </term>
        /// <term>
        /// <see cref="ChooseFont"/> should allow selection of fonts for all non-OEM and Symbol character sets, as well as the ANSI character set.
        /// This supersedes the <see cref="CF_ANSIONLY"/> value.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CF_SELECTSCRIPT"/>
        /// </term>
        /// <term>
        /// When specified on input, only fonts with the character set identified
        /// in the <see cref="LOGFONT.lfCharSet"/> member of the <see cref="LOGFONT"/> structure are displayed.
        /// The user will not be allowed to change the character set specified in the Scripts combo box.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CF_SHOWHELP"/>
        /// </term>
        /// <term>
        /// Causes the dialog box to display the Help button.
        /// The <see cref="hwndOwner"/> member must specify the window to receive the <see cref="HELPMSGSTRING"/> registered messages
        /// that the dialog box sends when the user clicks the Help button.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CF_TTONLY"/>
        /// </term>
        /// <term>
        /// <see cref="ChooseFont"/> should only enumerate and allow the selection of TrueType fonts.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CF_USESTYLE"/>
        /// </term>
        /// <term>
        /// <para>
        /// The <see cref="lpszStyle"/> member is a pointer to a buffer that contains style data
        /// that <see cref="ChooseFont"/> should use to initialize the Font Style combo box.
        /// When the user closes the dialog box, <see cref="ChooseFont"/> copies style data for the user's selection to this buffer.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// To globalize your application, you should specify the style by using the <see cref="LOGFONT.lfWeight"/>
        /// and <see cref="LOGFONT.lfItalic"/> members of the <see cref="LOGFONT"/> structure pointed to by <see cref="lpLogFont"/>.
        /// The style name may change depending on the system user interface language.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CF_WYSIWYG"/>
        /// </term>
        /// <term>
        /// <para>
        /// Obsolete. <see cref="ChooseFont"/> ignores this flag.
        /// </para>
        /// <para>
        /// Windows Vista and Windows XP/2000:
        /// <see cref="ChooseFont"/> should allow only the selection of fonts available on both the printer and the display.
        /// If this flag is specified, the <see cref="CF_SCREENSHOTS"/> and <see cref="CF_PRINTERFONTS"/>, or <see cref="CF_BOTH"/> flags should also be specified.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public FontDialogFlags Flags;

        /// <summary>
        /// If the <see cref="CF_EFFECTS"/> flag is set, <see cref="rgbColors"/> specifies the initial text color.
        /// When <see cref="ChooseFont"/> returns successfully, this member contains the RGB value of the text color that the user selected.
        /// To create a COLORREF color value, use the <see cref="RGB"/> macro.
        /// </summary>
        public COLORREF rgbColors;

        /// <summary>
        /// Application-defined data that the system passes to the hook procedure identified by the <see cref="lpfnHook"/> member.
        /// When the system sends the <see cref="WM_INITDIALOG"/> message to the hook procedure,
        /// the message's lParam parameter is a pointer to the <see cref="CHOOSEFONT"/> structure specified when the dialog was created.
        /// The hook procedure can use this pointer to get the <see cref="lCustData"/> value.
        /// </summary>
        public LPARAM lCustData;

        /// <summary>
        /// A pointer to a <see cref="LPCFHOOKPROC"/> hook procedure that can process messages intended for the dialog box.
        /// This member is ignored unless the <see cref="CF_ENABLEHOOK"/> flag is set in the <see cref="Flags"/> member.
        /// </summary>
        public LPCFHOOKPROC lpfnHook;

        /// <summary>
        /// The name of the dialog box template resource in the module identified by the <see cref="hInstance"/> member.
        /// This template is substituted for the standard dialog box template.
        /// For numbered dialog box resources, <see cref="lpTemplateName"/> can be a value returned by the <see cref="MAKEINTRESOURCE"/> macro.
        /// This member is ignored unless the <see cref="CF_ENABLETEMPLATE"/> flag is set in the Flags member.
        /// </summary>
        public nint lpTemplateName;

        /// <summary>
        /// If the <see cref="CF_ENABLETEMPLATEHANDLE"/> flag is set in the <see cref="Flags"/> member,
        /// <see cref="hInstance"/> is a handle to a memory object containing a dialog box template.
        /// If the <see cref="CF_ENABLETEMPLATE"/> flag is set, <see cref="hInstance"/> is a handle to a module that contains a dialog box template
        /// named by the <see cref="lpTemplateName"/> member.
        /// If neither <see cref="CF_ENABLETEMPLATEHANDLE"/> nor <see cref="CF_ENABLETEMPLATE"/> is set, this member is ignored.
        /// </summary>
        public HINSTANCE hInstance;

        /// <summary>
        /// The style data.
        /// If the <see cref="CF_USESTYLE"/> flag is specified, <see cref="ChooseFont"/> uses the data in this buffer to initialize the Font Style combo box.
        /// When the user closes the dialog box, <see cref="ChooseFont"/> copies the string in the Font Style combo box into this buffer.
        /// </summary>
        public nint lpszStyle;

        /// <summary>
        /// <para>
        /// The type of the selected font when <see cref="ChooseFont"/> returns.
        /// This member can be one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="BOLD_FONTTYPE"/>
        /// </term>
        /// <term>
        /// The font weight is bold.
        /// This information is duplicated in the <see cref="LOGFONT.lfWeight"/> member of the <see cref="LOGFONT"/> structure and is equivalent to <see cref="FW_BOLD"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="ITALIC_FONTTYPE"/>
        /// </para>
        /// <para>
        /// 0x0200
        /// </para>
        /// </term>
        /// <term>
        /// The italic font attribute is set.
        /// This information is duplicated in the <see cref="LOGFONT.lfItalic"/> member of the <see cref="LOGFONT"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PRINTER_FONTTYPE"/>
        /// </term>
        /// <term>
        /// The font is a printer font.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="REGULAR_FONTTYPE"/>
        /// </term>
        /// <term>
        /// The font weight is normal.
        /// This information is duplicated in the <see cref="LOGFONT.lfWeight"/> member of the <see cref="LOGFONT"/> structure
        /// and is equivalent to <see cref="FW_REGULAR"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SCREEN_FONTTYPE"/>
        /// </para>
        /// <para>
        /// 0x2000
        /// </para>
        /// </term>
        /// <term>
        /// The font is a screen font.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SIMULATED_FONTTYPE"/>
        /// </para>
        /// <para>
        /// 0x8000
        /// </para>
        /// </term>
        /// <term>
        /// The font is simulated by the graphics device interface (GDI).
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public FontTypes nFontType;

        private short __MISSING_ALIGNMENT__;

        /// <summary>
        /// The minimum point size a user can select.
        /// <see cref="ChooseFont"/> recognizes this member only if the <see cref="CF_LIMITSIZE"/> flag is specified.
        /// </summary>
        public INT nSizeMin;

        /// <summary>
        /// The maximum point size a user can select.
        /// <see cref="ChooseFont"/> recognizes this member only if the <see cref="CF_LIMITSIZE"/> flag is specified.
        /// </summary>
        public INT nSizeMax;
    }
}
