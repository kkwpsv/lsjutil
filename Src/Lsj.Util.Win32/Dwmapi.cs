using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Enums.DWMWINDOWATTRIBUTE;
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
        /// Retrieves the current value of a specified Desktop Window Manager (DWM) attribute applied to a window.
        /// For programming guidance, and code examples, see Controlling non-client region rendering.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/dwmapi/nf-dwmapi-dwmgetwindowattribute
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// The handle to the window from which the attribute value is to be retrieved.
        /// </param>
        /// <param name="dwAttribute">
        /// A flag describing which value to retrieve, specified as a value of the <see cref="DWMWINDOWATTRIBUTE"/> enumeration.
        /// This parameter specifies which attribute to retrieve, and the <paramref name="pvAttribute"/> parameter
        /// points to an object into which the attribute value is retrieved.
        /// </param>
        /// <param name="pvAttribute">
        /// A pointer to a value which, when this function returns successfully, receives the current value of the attribute.
        /// The type of the retrieved value depends on the value of the <paramref name="dwAttribute"/> parameter.
        /// The <see cref="DWMWINDOWATTRIBUTE"/> enumeration topic indicates, in the row for each flag,
        /// what type of value you should pass a pointer to in the <paramref name="pvAttribute"/> parameter.
        /// </param>
        /// <param name="cbAttribute">
        /// The size, in bytes, of the attribute value being received via the <paramref name="pvAttribute"/> parameter.
        /// The type of the retrieved value, and therefore its size in bytes, depends on the value of the <paramref name="dwAttribute"/> parameter.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        [DllImport("Dwmapi.dll", CharSet = CharSet.Unicode, EntryPoint = "DwmGetWindowAttribute", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT DwmGetWindowAttribute([In] HWND hwnd, [In] DWMWINDOWATTRIBUTE dwAttribute,
            [In] PVOID pvAttribute, [In] DWORD cbAttribute);

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

        /// <summary>
        /// <para>
        /// Sets the value of Desktop Window Manager (DWM) non-client rendering attributes for a window.
        /// For programming guidance, and code examples, see Controlling non-client region rendering.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/dwmapi/nf-dwmapi-dwmsetwindowattribute
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// The handle to the window for which the attribute value is to be set.
        /// </param>
        /// <param name="dwAttribute">
        /// A flag describing which value to set, specified as a value of the <see cref="DWMWINDOWATTRIBUTE"/> enumeration.
        /// This parameter specifies which attribute to set, and the <paramref name="pvAttribute"/> parameter
        /// points to an object containing the attribute value.
        /// </param>
        /// <param name="pvAttribute">
        /// A pointer to an object containing the attribute value to set.
        /// The type of the value set depends on the value of the <paramref name="dwAttribute"/> parameter.
        /// The <see cref="DWMWINDOWATTRIBUTE"/> enumeration topic indicates, in the row for each flag,
        /// what type of value you should pass a pointer to in the <paramref name="pvAttribute"/> parameter.
        /// </param>
        /// <param name="cbAttribute">
        /// The size, in bytes, of the attribute value being set via the <paramref name="pvAttribute"/> parameter.
        /// The type of the value set, and therefore its size in bytes, depends on the value of the <paramref name="dwAttribute"/> parameter.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// If Desktop Composition has been disabled (Windows 7 and earlier), then this function returns <see cref="DWM_E_COMPOSITIONDISABLED"/>.
        /// </returns>
        /// <remarks>
        /// It's not valid to call this function with the <paramref name="dwAttribute"/> parameter set to <see cref="DWMWA_NCRENDERING_ENABLED"/>.
        /// To enable or disable non-client rendering, you should use the <see cref="DWMWA_NCRENDERING_POLICY"/> attribute, and set the desired value.
        /// For more info, and a code example, see Controlling non-client region rendering.
        /// </remarks>
        [DllImport("Dwmapi.dll", CharSet = CharSet.Unicode, EntryPoint = "DwmSetWindowAttribute", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT DwmSetWindowAttribute([In] HWND hwnd, [In] DWMWINDOWATTRIBUTE dwAttribute,
            [In] LPCVOID pvAttribute, [In] DWORD cbAttribute);
    }
}
