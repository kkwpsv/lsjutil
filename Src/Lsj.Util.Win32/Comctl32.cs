using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.InitCommonControlsFlags;
using static Lsj.Util.Win32.Enums.PropSheetHeaderFlags;
using static Lsj.Util.Win32.Enums.PropSheetPageFlags;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Comctl32.dll
    /// </summary>
    public static class Comctl32
    {
        /// <summary>
        /// <para>
        /// An application-defined callback function that the system calls when the property sheet is being created and initialized.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/prsht/nc-prsht-pfnpropsheetcallback"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1">
        /// Handle to the property sheet.
        /// This parameter is typically called hWnd.
        /// </param>
        /// <param name="unnamedParam2">
        /// <para>
        /// Message being received. This parameter is typically called <see cref="uMsg"/>.
        /// </para>
        /// <para>
        /// This parameter is one of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="PSCB_INITIALIZED"/> (1)
        /// </term>
        /// <term>
        /// Indicates that the property sheet is being initialized.
        /// The lParam (<paramref name="unnamedParam3"/>) value is zero for this message.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// PSCB_PRECREATE (2)
        /// </term>
        /// <term>
        /// Indicates that the property sheet is about to be created.
        /// The hWnd (<paramref name="unnamedParam1"/>) parameter is <see cref="NULL"/>,
        /// and the lParam (<paramref name="unnamedParam3"/>) parameter is the address of a dialog template in memory.
        /// This template is in the form of a <see cref="DLGTEMPLATE"/> or <see cref="DLGTEMPLATEEX"/> structure
        /// followed by one or more <see cref="DLGITEMTEMPLATE"/> structures.
        /// This message is not applicable if you are using the Aero wizard style (<see cref="PSH_AEROWIZARD"/>).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// PSCB_BUTTONPRESSED (3)
        /// </term>
        /// <term>
        /// <para>
        /// Version 6.0 and later.
        /// Indicates the user pressed a button in the property sheet dialog box.
        /// To enable this, specify <see cref="PSH_USECALLBACK"/> in <see cref="PROPSHEETHEADER.dwFlags"/>
        /// and specify the name of this callback function in <see cref="PROPSHEETHEADER.pfnCallback"/>.
        /// The lParam (<paramref name="unnamedParam3"/>) value is one of the following.
        /// Note that only <see cref="PSBTN_CANCEL"/> is valid when you are using the Aero wizard style (<see cref="PSH_AEROWIZARD"/>).
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Button pressed
        /// </term>
        /// <term>
        /// lParam value
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// OK
        /// </term>
        /// <term>
        /// <see cref="PSBTN_OK"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Cancel
        /// </term>
        /// <term>
        /// <see cref="PSBTN_CANCEL"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Apply
        /// </term>
        /// <term>
        /// <see cref="PSBTN_APPLYNOW"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Close
        /// </term>
        /// <term>
        /// <see cref="PSBTN_FINISH"/>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Note that Comctl32.dll versions 6 and later are not redistributable.
        /// To use these versions of Comctl32.dll, specify the particular version in a manifest.
        /// For more information on manifests, see Enabling Visual Styles.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="unnamedParam3">
        /// <para>
        /// Additional information about the message. This parameter is typically called lParam.
        /// </para>
        /// <para>
        /// The meaning of this value depends on the uMsg (<paramref name="unnamedParam2"/>) parameter:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// If uMsg is <see cref="PSCB_INITIALIZED"/> or <see cref="PSCB_BUTTONPRESSED"/>, the value of this parameter is zero.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// If uMsg is <see cref="PSCB_PRECREATE"/>, then this parameter will be a pointer
        /// to either a <see cref="DLGTEMPLATE"/> or <see cref="DLGTEMPLATEEX"/> structure describing the property sheet dialog box.
        /// Test the signature of the structure to determine the type.
        /// If signature is equal to 0xFFFF then the structure is an extended dialog template,
        /// otherwise the structure is a standard dialog template.
        /// The following example demonstrates how to do this.
        /// </para>
        /// <code>
        /// if (uMsg == PSCB_PRECREATE) 
        /// {
        ///      if (lParam)
        ///      {
        ///           DLGTEMPLATE *pDlgTemplate;
        ///           DLGTEMPLATEEX *pDlgTemplateEx;
        /// 
        ///           pDlgTemplateEx = (DLGTEMPLATEEX *)lParam;  
        ///           if (pDlgTemplateEx-&gt;signature == 0xFFFF)
        ///           {
        ///                // pDlgTemplateEx points to an extended  
        ///                // dialog template structure.
        ///           }
        ///           else
        ///           {
        ///                // This is a standard dialog template
        ///                //  structure.
        ///                pDlgTemplate = (DLGTEMPLATE *)lParam;
        ///           }
        ///      }    
        /// }
        /// </code>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// Returns zero.
        /// </returns>
        /// <remarks>
        /// <para>
        /// To enable a PropSheetProc callback function,
        /// use the <see cref="PROPSHEETHEADER"/> structure when you call the <see cref="PropertySheet"/> function to create the property sheet.
        /// Use the <see cref="PROPSHEETHEADER.pfnCallback"/> member to specify an address of the callback function,
        /// and set the <see cref="PSP_USECALLBACK"/> flag in the <see cref="PROPSHEETHEADER.dwFlags"/> member.
        /// </para>
        /// <para>
        /// PropSheetProc is a placeholder for the application-defined function name.
        /// The <see cref="PFNPROPSHEETCALLBACK"/> type is the address of a PropSheetProc callback function.
        /// </para>
        /// </remarks>
        public delegate int Pfnpropsheetcallback([In] HWND unnamedParam1, [In] UINT unnamedParam2, [In] LPARAM unnamedParam3);


        /// <summary>
        /// <para>
        /// Creates a new page for a property sheet.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/prsht/nf-prsht-createpropertysheetpagew"/>
        /// </para>
        /// </summary>
        /// <param name="constPropSheetPagePointer">
        /// Pointer to a <see cref="PROPSHEETPAGE"/> structure that defines a page to be included in a property sheet.
        /// </param>
        /// <returns>
        /// Returns the handle to the new property page if successful, or <see cref="NULL"/> otherwise.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Before common controls version 7.0, this function did not support visual styles.
        /// An application uses the <see cref="PropertySheet"/> function to create a property sheet that includes the new page.
        /// If you are not using the Aero wizard style (<see cref="PSH_AEROWIZARD"/>),
        /// the application can use the <see cref="PSM_ADDPAGE"/> message to add the new page to an existing property sheet.
        /// </para>
        /// <para>
        /// Windows 95: The system can support a maximum of 16,364 window handles.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Comctl32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreatePropertySheetPageW", ExactSpelling = true)]
        public static extern HPROPSHEETPAGE CreatePropertySheetPage([In] in PROPSHEETPAGE constPropSheetPagePointer);

        /// <summary>
        /// <para>
        /// Destroys a property sheet page.
        /// An application must call this function for pages
        /// that have not been passed to the <see cref="PropertySheet"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/prsht/nf-prsht-destroypropertysheetpage"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1">
        /// Handle to the property sheet page to delete.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful, or <see cref="FALSE"/> otherwise.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Comctl32.dll", CharSet = CharSet.Unicode, EntryPoint = "DestroyPropertySheetPage", ExactSpelling = true)]
        public static extern BOOL DestroyPropertySheetPage([In] HPROPSHEETPAGE unnamedParam1);

        /// <summary>
        /// <para>
        /// Gets the language currently in use by the common controls for a particular process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commctrl/nf-commctrl-getmuilanguage"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// Returns the language identifier of the language an application
        /// has specified for the common controls by calling <see cref="InitMUILanguage"/>.
        /// <see cref="GetMUILanguage"/> returns the value for the process from which it is called.
        /// If <see cref="InitMUILanguage"/> has not been called or was not called from the same process,
        /// <see cref="GetMUILanguage"/> returns the language-neutral <see cref="LANGID"/>,
        /// <c>MAKELANGID(LANG_NEUTRAL, SUBLANG_NEUTRAL)</c>.
        /// </returns>
        /// <remarks>
        /// See Internationalization for Windows Applications for further discussion of localization.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Comctl32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMUILanguage", ExactSpelling = true)]
        public static extern LANGID GetMUILanguage();

        /// <summary>
        /// <para>
        /// Ensures that the common control DLL (Comctl32.dll) is loaded,
        /// and registers specific common control classes from the DLL.
        /// An application must call this function before creating a common control.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commctrl/nf-commctrl-initcommoncontrolsex"/>
        /// </para>
        /// </summary>
        /// <param name="picce">
        /// A pointer to an <see cref="INITCOMMONCONTROLSEX"/> structure
        /// that contains information specifying which control classes will be registered.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful, or <see cref="FALSE"/> otherwise.
        /// </returns>
        /// <remarks>
        /// The effect of each call to <see cref="InitCommonControlsEx"/> is cumulative.
        /// For example, if <see cref="InitCommonControlsEx"/> is called with the <see cref="ICC_UPDOWN_CLASS"/> flag,
        /// then is later called with the <see cref="ICC_HOTKEY_CLASS"/> flag,
        /// the result is that both the up-down and hot key common control classes are registered and available to the application.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Comctl32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitCommonControlsEx", ExactSpelling = true)]
        public static extern BOOL InitCommonControlsEx([In] in INITCOMMONCONTROLSEX picce);

        /// <summary>
        /// <para>
        /// Enables an application to specify a language
        /// to be used with the common controls that is different from the system language.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commctrl/nf-commctrl-initmuilanguage"/>
        /// </para>
        /// </summary>
        /// <param name="uiLang">
        /// The language identifier of the language to be used by the common controls.
        /// </param>
        /// <remarks>
        /// This function enables an application to override the system language setting,
        /// and specify a different language for the common controls.
        /// The selected language only applies to the process that <see cref="InitMUILanguage"/> is called from.
        /// See Internationalization for Windows Applications for further discussion of localization.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Comctl32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitMUILanguage", ExactSpelling = true)]
        public static extern void InitMUILanguage([In] LANGID uiLang);
    }
}
