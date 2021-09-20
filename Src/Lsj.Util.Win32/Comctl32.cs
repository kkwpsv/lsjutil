using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.INITCOMMONCONTROLSFlags;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Comctl32.dll
    /// </summary>
    public static class Comctl32
    {
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
