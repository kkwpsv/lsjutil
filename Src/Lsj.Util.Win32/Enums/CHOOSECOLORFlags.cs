using Lsj.Util.Win32.Structs;
using System;
using static Lsj.Util.Win32.Comdlg32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="CHOOSECOLOR"/> Flags
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/commdlg/ns-commdlg-choosefontw
    /// </para>
    /// </summary>
    [Flags]
    public enum CHOOSECOLORFlags : uint
    {
        /// <summary>
        /// Causes the dialog box to display all available colors in the set of basic colors.
        /// </summary>
        CC_ANYCOLOR = 0x00000100,

        /// <summary>
        /// Enables the hook procedure specified in the <see cref="CHOOSECOLOR.lpfnHook"/> member of this structure.
        /// This flag is used only to initialize the dialog box.
        /// </summary>
        CC_ENABLEHOOK = 0x00000010,

        /// <summary>
        /// The <see cref="CHOOSECOLOR.hInstance"/> and <see cref="CHOOSECOLOR.lpTemplateName"/> members
        /// specify a dialog box template to use in place of the default template.
        /// This flag is used only to initialize the dialog box.
        /// </summary>
        CC_ENABLETEMPLATE = 0x00000020,

        /// <summary>
        /// The <see cref="CHOOSECOLOR.hInstance"/> member identifies a data block that contains a preloaded dialog box template.
        /// The system ignores the <see cref="CHOOSECOLOR.lpTemplateName"/> member if this flag is specified.
        /// This flag is used only to initialize the dialog box.
        /// </summary>
        CC_ENABLETEMPLATEHANDLE = 0x00000040,

        /// <summary>
        /// Causes the dialog box to display the additional controls that allow the user to create custom colors.
        /// If this flag is not set, the user must click the Define Custom Color button to display the custom color controls.
        /// </summary>
        CC_FULLOPEN = 0x00000002,

        /// <summary>
        /// Disables the Define Custom Color button.
        /// </summary>
        CC_PREVENTFULLOPEN = 0x00000004,

        /// <summary>
        /// Causes the dialog box to use the color specified in the <see cref="CHOOSECOLOR.rgbResult"/> member as the initial color selection.
        /// </summary>
        CC_RGBINIT = 0x00000001,

        /// <summary>
        /// Causes the dialog box to display the Help button.
        /// The <see cref="CHOOSECOLOR.hwndOwner"/> member must specify the window to receive the <see cref="HELPMSGSTRING"/> registered messages
        /// that the dialog box sends when the user clicks the Help button.
        /// </summary>
        CC_SHOWHELP = 0x00000008,

        /// <summary>
        /// Causes the dialog box to display only solid colors in the set of basic colors.
        /// </summary>
        CC_SOLIDCOLOR = 0x00000080,
    }
}
