using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
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
