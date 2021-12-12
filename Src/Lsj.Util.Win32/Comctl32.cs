using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.INITCOMMONCONTROLSFlags;
using static Lsj.Util.Win32.Enums.PROPSHEETHEADERFlags;
using static Lsj.Util.Win32.Enums.PROPSHEETPAGEFlags;

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
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/prsht/nc-prsht-pfnpropsheetcallback"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1">
        /// Handle to the property sheet.
        /// This parameter is typically called hWnd.
        /// </param>
        /// <param name="unnamedParam2">
        /// Message being received. This parameter is typically called uMsg.
        /// This parameter is one of the following values.
        /// <see cref="PSCB_INITIALIZED"/>:
        /// Indicates that the property sheet is being initialized.
        /// The lParam (unnamedParam3) value is zero for this message.
        /// <see cref="PSCB_PRECREATE"/>:
        /// Indicates that the property sheet is about to be created.
        /// The hWnd (unnamedParam1) parameter is <see cref="NULL"/>, and the lParam (unnamedParam3) parameter is the address of a dialog template in memory.
        /// This template is in the form of a <see cref="DLGTEMPLATE"/> or <see cref="DLGTEMPLATEEX"/> structure followed by one or more <see cref="DLGITEMTEMPLATE"/> structures.
        /// This message is not applicable if you are using the Aero wizard style (<see cref="PSH_AEROWIZARD"/>).
        /// <see cref="PSCB_BUTTONPRESSED"/>:
        /// Version 6.0 and later.
        /// Indicates the user pressed a button in the property sheet dialog box.
        /// To enable this, specify <see cref="PSH_USECALLBACK"/> in <see cref="PROPSHEETHEADER.dwFlags"/>
        /// and specify the name of this callback function in <see cref="PROPSHEETHEADER.pfnCallback"/>.
        /// The lParam (Arg3) value is one of the following.
        /// Note that only <see cref="PSBTN_CANCEL"/> is valid when you are using the Aero wizard style (<see cref="PSH_AEROWIZARD"/>).
        /// Button pressed	lParam value
        /// OK	PSBTN_OK
        /// Cancel	PSBTN_CANCEL
        /// Apply	PSBTN_APPLYNOW
        /// Close	PSBTN_FINISH
        /// Note that Comctl32.dll versions 6 and later are not redistributable.
        /// To use these versions of Comctl32.dll, specify the particular version in a manifest.
        /// For more information on manifests, see Enabling Visual Styles.
        /// </param>
        /// <param name="unnamedParam3">
        /// Additional information about the message.
        /// This parameter is typically called lParam.
        /// The meaning of this value depends on the uMsg (unnamedParam2) parameter:
        /// If uMsg is <see cref="PSCB_INITIALIZED"/> or <see cref="PSCB_BUTTONPRESSED"/>, the value of this parameter is zero.
        /// If uMsg is <see cref="PSCB_PRECREATE"/>, then this parameter will be a pointer to
        /// either a <see cref="DLGTEMPLATE"/> or <see cref="DLGTEMPLATEEX"/> structure describing the property sheet dialog box.
        /// Test the signature of the structure to determine the type.
        /// If signature is equal to 0xFFFF then the structure is an extended dialog template, otherwise the structure is a standard dialog template.
        /// </param>
        /// <returns>
        /// Returns zero.
        /// </returns>
        /// <remarks>
        /// To enable a PropSheetProc callback function, use the <see cref="PROPSHEETHEADER"/> structure
        /// when you call the <see cref="PropertySheet"/> function to create the property sheet.
        /// Use the <see cref="PROPSHEETHEADER.pfnCallback"/> member to specify an address of the callback function,
        /// and set the <see cref="PSP_USECALLBACK"/> flag in the <see cref="PROPSHEETHEADER.dwFlags"/> member.
        /// PropSheetProc is a placeholder for the application-defined function name.
        /// The <see cref="PFNPROPSHEETCALLBACK"/> type is the address of a PropSheetProc callback function.
        /// </remarks>
        public delegate int Pfnpropsheetcallback([In] HWND unnamedParam1, [In] UINT unnamedParam2, [In] LPARAM unnamedParam3);

        /// <summary>
        /// <para>
        /// Creates a new page for a property sheet.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/prsht/nf-prsht-createpropertysheetpagew"/>
        /// </para>
        /// </summary>
        /// <param name="constPropSheetPagePointer">
        /// Pointer to a <see cref="PROPSHEETPAGE"/> structure that defines a page to be included in a property sheet.
        /// </param>
        /// <returns>
        /// Returns the handle to the new property page if successful, or <see cref="NULL"/> otherwise.
        /// </returns>
        /// <remarks>
        /// Note  Before common controls version 7.0, this function did not support visual styles.
        /// An application uses the PropertySheet function to create a property sheet that includes the new page.
        /// If you are not using the Aero wizard style (<see cref="PSH_AEROWIZARD"/>),
        /// the application can use the <see cref="PSM_ADDPAGE"/> message to add the new page to an existing property sheet.
        /// Windows 95: The system can support a maximum of 16,364 window handles.
        /// </remarks>
        [DllImport("Comctl32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreatePropertySheetPageW", ExactSpelling = true, SetLastError = true)]
        public static extern HPROPSHEETPAGE CreatePropertySheetPage([In] in PROPSHEETPAGE constPropSheetPagePointer);

        /// <summary>
        /// <para>
        /// Destroys a property sheet page.
        /// An application must call this function for pages that have not been passed to the <see cref="PropertySheet"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/prsht/nf-prsht-destroypropertysheetpage"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1">
        /// Handle to the property sheet page to delete.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful, or <see cref="FALSE"/> otherwise.
        /// </returns>
        [DllImport("Comctl32.dll", CharSet = CharSet.Unicode, EntryPoint = "DestroyPropertySheetPage", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DestroyPropertySheetPage([In] HPROPSHEETPAGE unnamedParam1);

        /// <summary>
        /// <para>
        /// Gets the language currently in use by the common controls for a particular process.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/nf-commctrl-getmuilanguage"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// Returns the language identifier of the language an application
        /// has specified for the common controls by calling <see cref="InitMUILanguage"/>.
        /// <see cref="GetMUILanguage"/> returns the value for the process from which it is called.
        /// If <see cref="InitMUILanguage"/> has not been called or was not called from the same process,
        /// <see cref="GetMUILanguage"/> returns the language-neutral <see cref="LANGID"/>,
        /// <code>MAKELANGID(LANG_NEUTRAL, SUBLANG_NEUTRAL)</code>.
        /// </returns>
        /// <remarks>
        /// See Internationalization for Windows Applications for further discussion of localization.
        /// </remarks>
        [DllImport("Comctl32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMUILanguage", ExactSpelling = true, SetLastError = true)]
        public static extern LANGID GetMUILanguage();

        /// <summary>
        /// <para>
        /// Ensures that the common control DLL (Comctl32.dll) is loaded, and registers specific common control classes from the DLL.
        /// An application must call this function before creating a common control.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/nf-commctrl-initcommoncontrolsex"/>
        /// </para>
        /// </summary>
        /// <param name="picce">
        /// A pointer to an <see cref="INITCOMMONCONTROLSEX"/> structure that contains information specifying which control classes will be registered.
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
        [DllImport("Comctl32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitCommonControlsEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL InitCommonControlsEx([In] in INITCOMMONCONTROLSEX picce);

        /// <summary>
        /// <para>
        /// Enables an application to specify a language to be used with the common controls that is different from the system language.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/nf-commctrl-initmuilanguage"/>
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
        [DllImport("Comctl32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitMUILanguage", ExactSpelling = true, SetLastError = true)]
        public static extern void InitMUILanguage([In] LANGID uiLang);
    }
}
