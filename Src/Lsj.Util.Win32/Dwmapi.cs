using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Enums.SystemParametersInfoParameters;
using static Lsj.Util.Win32.Enums.WindowsMessages;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Dwmapi.dll
    /// </summary>
    public static class Dwmapi
    {
        /// <summary>
        /// <para>
        /// Obtains a value that indicates whether Desktop Window Manager (DWM) composition is enabled.
        /// Applications on machines running Windows 7 or earlier can listen for composition state changes
        /// by handling the <see cref="WM_DWMCOMPOSITIONCHANGED"/> notification.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/dwmapi/nf-dwmapi-dwmiscompositionenabled
        /// </para>
        /// </summary>
        /// <param name="pfEnabled">
        /// A pointer to a value that, when this function returns successfully,
        /// receives <see cref="TRUE"/> if DWM composition is enabled; otherwise, <see cref="FALSE"/>.
        /// Note  As of Windows 8, DWM composition is always enabled.
        /// If an app declares Windows 8 compatibility in their manifest,
        /// this function will receive a value of <see cref="TRUE"/> through <paramref name="pfEnabled"/>.
        /// If no such manifest entry is found, Windows 8 compatibility is not assumed
        /// and this function receives a value of <see cref="FALSE"/> through <paramref name="pfEnabled"/>.
        /// This is done so that older programs that interpret a value of <see cref="TRUE"/> to imply that
        /// high contrast mode is off can continue to make the correct decisions about rendering their images.
        /// (Note that this is a bad practice—you should use the <see cref="SystemParametersInfo"/> function
        /// with the <see cref="SPI_GETHIGHCONTRAST"/> flag to determine the state of high contrast mode.)
        /// For more information, see Supporting High Contrast Themes.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        [DllImport("Dwmapi.dll", CharSet = CharSet.Unicode, EntryPoint = "DwmIsCompositionEnabled", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT DwmIsCompositionEnabled([Out] out BOOL pfEnabled);
    }
}
