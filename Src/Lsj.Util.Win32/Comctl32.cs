using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

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
