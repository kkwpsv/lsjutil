using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Comdlg32;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.ColorDialogFlags;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information the <see cref="ChooseColor"/> function uses to initialize the Color dialog box.
    /// After the user closes the dialog box, the system returns information about the user's selection in this structure.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commdlg/ns-commdlg-choosecolorw~r1"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct CHOOSECOLOR
    {
        /// <summary>
        /// The length, in bytes, of the structure.
        /// </summary>
        public DWORD lStructSize;

        /// <summary>
        /// A handle to the window that owns the dialog box.
        /// This member can be any valid window handle, or it can be <see cref="NULL"/> if the dialog box has no owner.
        /// </summary>
        public HWND hwndOwner;

        /// <summary>
        /// If the <see cref="CC_ENABLETEMPLATEHANDLE"/> flag is set in the <see cref="Flags"/> member,
        /// <see cref="hInstance"/> is a handle to a memory object containing a dialog box template.
        /// If the <see cref="CC_ENABLETEMPLATE"/> flag is set, hInstance is a handle to a module
        /// that contains a dialog box template named by the <see cref="lpTemplateName"/> member.
        /// If neither <see cref="CC_ENABLETEMPLATEHANDLE"/> nor <see cref="CC_ENABLETEMPLATE"/> is set, this member is ignored.
        /// </summary>
        public HWND hInstance;

        /// <summary>
        /// If the <see cref="CC_RGBINIT"/> flag is set, <see cref="rgbResult"/> specifies the color initially selected when the dialog box is created.
        /// If the specified color value is not among the available colors, the system selects the nearest solid color available.
        /// If <see cref="rgbResult"/> is zero or <see cref="CC_RGBINIT"/> is not set, the initially selected color is black.
        /// If the user clicks the OK button, <see cref="rgbResult"/> specifies the user's color selection.
        /// To create a <see cref="COLORREF"/> color value, use the RGB macro.
        /// </summary>
        public COLORREF rgbResult;

        /// <summary>
        /// A pointer to an array of 16 values that contain red, green, blue (RGB) values for the custom color boxes in the dialog box.
        /// If the user modifies these colors, the system updates the array with the new RGB values.
        /// To preserve new custom colors between calls to the <see cref="ChooseColor"/> function, you should allocate static memory for the array.
        /// To create a <see cref="COLORREF"/> color value, use the <see cref="RGB"/> macro.
        /// </summary>
        public IntPtr lpCustColors;

        /// <summary>
        /// <para>
        /// A set of bit flags that you can use to initialize the Color dialog box.
        /// When the dialog box returns, it sets these flags to indicate the user's input.
        /// This member can be a combination of the following flags.
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
        /// <see cref="CC_ANYCOLOR"/>
        /// </term>
        /// <term>
        /// Causes the dialog box to display all available colors in the set of basic colors.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CC_ENABLEHOOK"/>
        /// </term>
        /// <term>
        /// Enables the hook procedure specified in the <see cref="lpfnHook"/> member of this structure.
        /// This flag is used only to initialize the dialog box.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CC_ENABLETEMPLATE"/>
        /// </term>
        /// <term>
        /// The <see cref="hInstance"/> and <see cref="lpTemplateName"/> members specify a dialog box template to use in place of the default template.
        /// This flag is used only to initialize the dialog box.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CC_ENABLETEMPLATEHANDLE"/>
        /// </term>
        /// <term>
        /// The <see cref="hInstance"/> member identifies a data block that contains a preloaded dialog box template.
        /// The system ignores the <see cref="lpTemplateName"/> member if this flag is specified. This flag is used only to initialize the dialog box.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CC_FULLOPEN"/>
        /// </term>
        /// <term>
        /// Causes the dialog box to display the additional controls that allow the user to create custom colors.
        /// If this flag is not set, the user must click the Define Custom Color button to display the custom color controls.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CC_PREVENTFULLOPEN"/>
        /// </term>
        /// <term>
        /// Disables the Define Custom Color button.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CC_RGBINIT"/>
        /// </term>
        /// <term>
        /// Causes the dialog box to use the color specified in the <see cref="rgbResult"/> member as the initial color selection.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CC_SHOWHELP"/>
        /// </term>
        /// <term>
        /// Causes the dialog box to display the Help button.
        /// The <see cref="hwndOwner"/> member must specify the window to receive the <see cref="HELPMSGSTRING"/> registered messages
        /// that the dialog box sends when the user clicks the Help button.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CC_SOLIDCOLOR"/>
        /// </term>
        /// <term>
        /// Causes the dialog box to display only solid colors in the set of basic colors.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public ColorDialogFlags Flags;

        /// <summary>
        /// Application-defined data that the system passes to the hook procedure identified by the <see cref="lpfnHook"/> member.
        /// When the system sends the <see cref="WM_INITDIALOG"/> message to the hook procedure,
        /// the message's lParam parameter is a pointer to the <see cref="CHOOSECOLOR"/> structure specified when the dialog was created.
        /// The hook procedure can use this pointer to get the <see cref="lCustData"/> value.
        /// </summary>
        public LPARAM lCustData;

        /// <summary>
        /// A pointer to a CCHookProc hook procedure that can process messages intended for the dialog box.
        /// This member is ignored unless the <see cref="CC_ENABLEHOOK"/> flag is set in the <see cref="Flags"/> member.
        /// </summary>
        public LPCCHOOKPROC lpfnHook;

        /// <summary>
        /// The name of the dialog box template resource in the module identified by the <see cref="hInstance"/> member.
        /// This template is substituted for the standard dialog box template.
        /// For numbered dialog box resources, <see cref="lpTemplateName"/> can be a value returned by the <see cref="MAKEINTRESOURCE"/> macro.
        /// This member is ignored unless the <see cref="CC_ENABLETEMPLATE"/> flag is set in the <see cref="Flags"/> member.
        /// </summary>
        public IntPtr lpTemplateName;

        /// <summary>
        /// 
        /// </summary>
        public IntPtr lpEditInfo;
    }
}
