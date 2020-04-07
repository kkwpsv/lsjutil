using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using System.Text;
using static Lsj.Util.Win32.Comdlg32;
using static Lsj.Util.Win32.Enums.CHOOSEFONTFlags;
using static Lsj.Util.Win32.Enums.WindowsMessages;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information that the <see cref="ChooseFont"/> function uses to initialize the Font dialog box.
    /// After the user closes the dialog box, the system returns information about the user's selection in this structure.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/commdlg/ns-commdlg-choosefontw
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct CHOOSEFONT
    {
        /// <summary>
        /// The length of the structure, in bytes.
        /// </summary>
        public uint lStructSize;

        /// <summary>
        /// A handle to the window that owns the dialog box.
        /// This member can be any valid window handle, or it can be <see cref="IntPtr.Zero"/> if the dialog box has no owner.
        /// </summary>
        public IntPtr hwndOwner;

        /// <summary>
        /// This member is ignored by the <see cref="ChooseFont"/> function.
        /// Windows Vista and Windows XP/2000:
        /// A handle to the device context or information context of the printer whose fonts will be listed in the dialog box.
        /// This member is used only if the <see cref="Flags"/> member specifies the <see cref="CF_PRINTERFONTS"/> or <see cref="CF_BOTH"/> flag;
        /// otherwise, this member is ignored.
        /// </summary>
        public IntPtr hDC;

        /// <summary>
        /// A pointer to a <see cref="LOGFONT"/> structure.
        /// If you set the <see cref="CF_INITTOLOGFONTSTRUCT"/> flag in the <see cref="Flags"/> member and initialize the other members,
        /// the <see cref="ChooseFont"/> function initializes the dialog box with a font that matches the <see cref="LOGFONT"/> members.
        /// If the user clicks the OK button, <see cref="ChooseFont"/> sets the members of the <see cref="LOGFONT"/> structure based on the user's selections.
        /// </summary>
        public IntPtr lpLogFont;

        /// <summary>
        /// The size of the selected font, in units of 1/10 of a point.
        /// The <see cref="ChooseFont"/> function sets this value after the user closes the dialog box.
        /// </summary>
        public int iPointSize;

        /// <summary>
        /// A set of bit flags that you can use to initialize the Font dialog box.
        /// When the dialog box returns, it sets these flags to indicate the user input.
        /// This member can be one or more of the following values.
        /// <see cref="CF_APPLY"/>, <see cref="CF_ANSIONLY"/>, <see cref="CF_BOTH"/>, <see cref="CF_EFFECTS"/>, <see cref="CF_ENABLEHOOK"/>,
        /// <see cref="CF_ENABLETEMPLATE"/>, <see cref="CF_ENABLETEMPLATEHANDLE"/>, <see cref="CF_FIXEDPITCHONLY"/>,
        /// <see cref="CF_FORCEFONTEXIST"/>, <see cref="CF_INACTIVEFONTS"/>, <see cref="CF_INITTOLOGFONTSTRUCT"/>, <see cref="CF_LIMITSIZE"/>,
        /// <see cref="CF_NOOEMFONTS"/>, <see cref="CF_NOFACESEL"/>, <see cref="CF_NOSCRIPTSEL"/>, <see cref="CF_NOSIMULATIONS"/>,
        /// <see cref="CF_NOSIZESEL"/>, <see cref="CF_NOSTYLESEL"/>, <see cref="CF_NOVECTORFONTS"/>, <see cref="CF_NOVERTFONTS"/>,
        /// <see cref="CF_PRINTERFONTS"/>, <see cref="CF_SCALABLEONLY"/>, <see cref="CF_SCREENFONTS"/>, <see cref="CF_SCRIPTSONLY"/>,
        /// <see cref="CF_SELECTSCRIPT"/>, <see cref="CF_SHOWHELP"/>, <see cref="CF_TTONLY"/>, <see cref="CF_USESTYLE"/>,
        /// <see cref="CF_WYSIWYG"/>
        /// </summary>
        public CHOOSEFONTFlags Flags;

        /// <summary>
        /// If the <see cref="CF_EFFECTS"/> flag is set, <see cref="rgbColors"/> specifies the initial text color.
        /// When <see cref="ChooseFont"/> returns successfully, this member contains the RGB value of the text color that the user selected.
        /// To create a COLORREF color value, use the <see cref="RGB"/> macro.
        /// </summary>
        public uint rgbColors;

        /// <summary>
        /// Application-defined data that the system passes to the hook procedure identified by the <see cref="lpfnHook"/> member.
        /// When the system sends the <see cref="WM_INITDIALOG"/> message to the hook procedure,
        /// the message's lParam parameter is a pointer to the <see cref="CHOOSEFONT"/> structure specified when the dialog was created.
        /// The hook procedure can use this pointer to get the <see cref="lCustData"/> value.
        /// </summary>
        public IntPtr lCustData;

        /// <summary>
        /// A pointer to a <see cref="CFHookProc"/> hook procedure that can process messages intended for the dialog box.
        /// This member is ignored unless the <see cref="CF_ENABLEHOOK"/> flag is set in the <see cref="Flags"/> member.
        /// </summary>
        public IntPtr lpfnHook;

        /// <summary>
        /// The name of the dialog box template resource in the module identified by the <see cref="hInstance"/> member.
        /// This template is substituted for the standard dialog box template.
        /// For numbered dialog box resources, <see cref="lpTemplateName"/> can be a value returned by the <see cref="MAKEINTRESOURCE"/> macro.
        /// This member is ignored unless the <see cref="CF_ENABLETEMPLATE"/> flag is set in the Flags member.
        /// </summary>
        public IntPtr lpTemplateName;

        /// <summary>
        /// If the <see cref="CF_ENABLETEMPLATEHANDLE"/> flag is set in the <see cref="Flags"/> member,
        /// <see cref="hInstance"/> is a handle to a memory object containing a dialog box template.
        /// If the <see cref="CF_ENABLETEMPLATE"/> flag is set, <see cref="hInstance"/> is a handle to a module that contains a dialog box template
        /// named by the <see cref="lpTemplateName"/> member.
        /// If neither <see cref="CF_ENABLETEMPLATEHANDLE"/> nor <see cref="CF_ENABLETEMPLATE"/> is set, this member is ignored.
        /// </summary>
        public IntPtr hInstance;

        /// <summary>
        /// The style data.
        /// If the <see cref="CF_USESTYLE"/> flag is specified, <see cref="ChooseFont"/> uses the data in this buffer to initialize the Font Style combo box.
        /// When the user closes the dialog box, <see cref="ChooseFont"/> copies the string in the Font Style combo box into this buffer.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public StringBuilder lpszStyle;

        /// <summary>
        /// The type of the selected font when <see cref="ChooseFont"/> returns.
        /// This member can be one or more of the following values.
        /// </summary>
        public FontType nFontType;

        private short __MISSING_ALIGNMENT__;

        /// <summary>
        /// The minimum point size a user can select.
        /// <see cref="ChooseFont"/> recognizes this member only if the <see cref="CF_LIMITSIZE"/> flag is specified.
        /// </summary>
        public int nSizeMin;

        /// <summary>
        /// The maximum point size a user can select.
        /// <see cref="ChooseFont"/> recognizes this member only if the <see cref="CF_LIMITSIZE"/> flag is specified.
        /// </summary>
        public int nSizeMax;
    }
}
