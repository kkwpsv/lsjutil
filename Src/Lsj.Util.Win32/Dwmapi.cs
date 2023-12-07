using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Enums.DWMWINDOWATTRIBUTE;
using static Lsj.Util.Win32.Enums.SystemParametersInfoParameters;
using static Lsj.Util.Win32.Enums.WindowMessages;
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
        /// Default window procedure for Desktop Window Manager (DWM) hit testing within the non-client area.
        /// You also need to ensure that <see cref="DwmDefWindowProc"/> is called for the <see cref="WM_NCMOUSELEAVE"/> message.
        /// If <see cref="DwmDefWindowProc"/> is not called for the <see cref="WM_NCMOUSELEAVE"/> message,
        /// DWM does not remove the highlighting from the Maximize, Minimize, and Close buttons when the cursor leaves the window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/nf-dwmapi-dwmdefwindowproc"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window procedure that received the message.
        /// </param>
        /// <param name="msg">
        /// The message.
        /// </param>
        /// <param name="wParam">
        /// Specifies additional message information.
        /// The content of this parameter depends on the value of the <paramref name="msg"/> parameter.
        /// </param>
        /// <param name="lParam">
        /// Specifies additional message information.
        /// The content of this parameter depends on the value of the <paramref name="msg"/> parameter.
        /// </param>
        /// <param name="plResult">
        /// A pointer to an <see cref="LRESULT"/> value that, when this method returns successfully, receives the result of the hit test.
        /// </param>
        /// <returns>
        /// <see cref="TRUE"/> if <see cref="DwmDefWindowProc"/> handled the message; otherwise, <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// When creating custom frames that include the standard caption buttons,
        /// <see cref="WM_NCHITTEST"/> and other non-client hit test messages should first be passed to the <see cref="DwmDefWindowProc"/> function.
        /// This enables the DWM to provide hit testing for the captions buttons.
        /// If <see cref="DwmDefWindowProc"/> does not handle the non-client hit test messages,
        /// further processing of these messages might be necessary.
        /// </remarks>
        [DllImport("Dwmapi.dll", CharSet = CharSet.Unicode, EntryPoint = "DwmDefWindowProc", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DwmDefWindowProc([In] HWND hWnd, [In] UINT msg, [In] WPARAM wParam, [In] LPARAM lParam, [Out] out LRESULT plResult);

        /// <summary>
        /// <para>
        /// Enables the blur effect on a specified window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/nf-dwmapi-dwmenableblurbehindwindow"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// The handle to the window on which the blur-behind data is applied.
        /// </param>
        /// <param name="pBlurBehind">
        /// A pointer to a <see cref="DWM_BLURBEHIND"/> structure that provides blur-behind data.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="S_OK"/> error code.
        /// </returns>
        /// <remarks>
        /// Note
        /// Beginning with Windows 8, calling this function doesn't result in the blur effect, due to a style change in the way windows are rendered.
        /// Enable blur by setting the <see cref="DWM_BLURBEHIND.fEnable"/> member of the <see cref="DWM_BLURBEHIND"/> structure to <see cref="TRUE"/>.
        /// This results in subsequent compositions of the window blurring the content behind it.
        /// This function should be called immediately before a <see cref="BeginPaint"/> call to ensure prompt application of the effect.
        /// The alpha values in the window are honored, and the rendering atop the blur will use these alpha values.
        /// It's your application's responsibility to ensure that the alpha values of all pixels in the window are correct.
        /// Some Windows Graphics Device Interface (GDI) operations don't preserve alpha values,
        /// so you should take care when presenting child windows because the alpha values they contribute are unpredictable.
        /// The region specified within the <see cref="DWM_BLURBEHIND"/> structure is owned by you as the caller.
        /// It's the caller's responsibility to free the region, and you can do so as soon as the function call is completed.
        /// This function can be called only on top-level windows.
        /// An error occurs when this function is called on other window types.
        /// This function must be called whenever Desktop Window Manager (DWM) composition is toggled.
        /// Handle the <see cref="WM_DWMCOMPOSITIONCHANGED"/> message for composition change notification.
        /// </remarks>
        [DllImport("Dwmapi.dll", CharSet = CharSet.Unicode, EntryPoint = "DwmEnableBlurBehindWindow", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT DwmEnableBlurBehindWindow([In] HWND hWnd, [In] in DWM_BLURBEHIND pBlurBehind);

        /// <summary>
        /// <para>
        /// Notifies the Desktop Window Manager (DWM) to opt in to or out of Multimedia Class Schedule Service (MMCSS) scheduling
        /// while the calling process is alive.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/nf-dwmapi-dwmenablemmcss"/>
        /// </para>
        /// </summary>
        /// <param name="fEnableMMCSS">
        /// <see cref="TRUE"/> to instruct DWM to participate in MMCSS scheduling;
        /// <see cref="FALSE"/> to opt out or end participation in MMCSS scheduling.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// DWM will be scheduled by the MMCSS as long as any process that called <see cref="DwmEnableMMCSS"/> to enable MMCSS is active
        /// and has not previously called <see cref="DwmEnableMMCSS"/> to disable MMCSS.
        /// </remarks>
        [DllImport("Dwmapi.dll", CharSet = CharSet.Unicode, EntryPoint = "DwmEnableMMCSS", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT DwmEnableMMCSS([In] BOOL fEnableMMCSS);

        /// <summary>
        /// <para>
        /// Extends the window frame into the client area.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/nf-dwmapi-dwmextendframeintoclientarea"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// The handle to the window in which the frame will be extended into the client area.
        /// </param>
        /// <param name="pMarInset">
        /// A pointer to a <see cref="MARGINS"/> structure that describes the margins to use when extending the frame into the client area.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// This function must be called whenever Desktop Window Manager (DWM) composition is toggled.
        /// Handle the <see cref="WM_DWMCOMPOSITIONCHANGED"/> message for composition change notification.
        /// Use negative margin values to create the "sheet of glass" effect where the client area is rendered as a solid surface with no window border.
        /// </remarks>
        [DllImport("Dwmapi.dll", CharSet = CharSet.Unicode, EntryPoint = "DwmExtendFrameIntoClientArea", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT DwmExtendFrameIntoClientArea([In] HWND hWnd, [In] in MARGINS pMarInset);

        /// <summary>
        /// <para>
        /// Issues a flush call that blocks the caller until the next present,
        /// when all of the Microsoft DirectX surface updates that are currently outstanding have been made.
        /// This compensates for very complex scenes or calling processes with very low priority.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/nf-dwmapi-dwmflush"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an HRESULT error code.
        /// </returns>
        /// <remarks>
        /// <see cref="DwmFlush"/> waits for any queued DirectX changes that were queued
        /// by the calling application to be drawn to the screen before returning.
        /// It does not flush the entire session rendering batch.
        /// </remarks>
        [DllImport("Dwmapi.dll", CharSet = CharSet.Unicode, EntryPoint = "DwmFlush", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT DwmFlush();

        /// <summary>
        /// <para>
        /// Retrieves the current color used for Desktop Window Manager (DWM) glass composition.
        /// This value is based on the current color scheme and can be modified by the user.
        /// Applications can listen for color changes by handling the <see cref="WM_DWMCOLORIZATIONCOLORCHANGED"/> notification.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/nf-dwmapi-dwmgetcolorizationcolor"/>
        /// </para>
        /// </summary>
        /// <param name="pcrColorization">
        /// A pointer to a value that, when this function returns successfully, receives the current color used for glass composition.
        /// The color format of the value is 0xAARRGGBB.
        /// </param>
        /// <param name="pfOpaqueBlend">
        /// A pointer to a value that, when this function returns successfully, indicates whether the color is an opaque blend.
        /// <see cref="TRUE"/> if the color is an opaque blend; otherwise, <see cref="FALSE"/>.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// The value pointed to by <paramref name="pcrColorization"/> is in an 0xAARRGGBB format.
        /// Many Microsoft Win32 APIs, such as <see cref="COLORREF"/>, use a 0x00BBGGRR format.
        /// Be careful to assure that the intended colors are used.
        /// </remarks>
        [DllImport("Dwmapi.dll", CharSet = CharSet.Unicode, EntryPoint = "DwmGetColorizationColor", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT DwmGetColorizationColor([Out] out DWORD pcrColorization, [Out] out BOOL pfOpaqueBlend);

        /// <summary>
        /// <para>
        /// Retrieves the current composition timing information for a specified window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/nf-dwmapi-dwmgetcompositiontiminginfo"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// The handle to the window for which the composition timing information should be retrieved.
        /// Starting with Windows 8.1, this parameter must be set to <see cref="NULL"/>.
        /// If this parameter is not set to <see cref="NULL"/>, <see cref="DwmGetCompositionTimingInfo"/> returns <see cref="E_INVALIDARG"/>.
        /// </param>
        /// <param name="pTimingInfo">
        /// A pointer to a <see cref="DWM_TIMING_INFO"/> structure that,
        /// when this function returns successfully, receives the current composition timing information for the window.
        /// The <see cref="DWM_TIMING_INFO.cbSize"/> member of this structure must be set before this function is called.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        [DllImport("Dwmapi.dll", CharSet = CharSet.Unicode, EntryPoint = "DwmGetCompositionTimingInfo", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT DwmGetCompositionTimingInfo([In] HWND hwnd, [In][Out] ref DWM_TIMING_INFO pTimingInfo);

        /// <summary>
        /// <para>
        /// Retrieves transport attributes.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/nf-dwmapi-dwmgettransportattributes"/>
        /// </para>
        /// </summary>
        /// <param name="pfIsRemoting">
        /// A pointer to a <see cref="BOOL"/> value that indicates whether the transport supports remoting.
        /// <see cref="TRUE"/> if the transport supports remoting; otherwise, <see cref="FALSE"/>.
        /// </param>
        /// <param name="pfIsConnected">
        /// A pointer to a <see cref="BOOL"/> value that indicates whether the transport is connected.
        /// <see cref="TRUE"/> if the transport is connected; otherwise, <see cref="FALSE"/>.
        /// </param>
        /// <param name="pDwGeneration">
        /// A pointer to a <see cref="DWORD"/> that receives a generation value for the transport.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        [DllImport("Dwmapi.dll", CharSet = CharSet.Unicode, EntryPoint = "DwmGetTransportAttributes", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT DwmGetTransportAttributes([Out] out BOOL pfIsRemoting, [Out] out BOOL pfIsConnected, [Out] out DWORD pDwGeneration);

        /// <summary>
        /// <para>
        /// Retrieves the current value of a specified Desktop Window Manager (DWM) attribute applied to a window.
        /// For programming guidance, and code examples, see Controlling non-client region rendering.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/nf-dwmapi-dwmgetwindowattribute"/>
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
        /// Called by an application to indicate that all previously provided iconic bitmaps from a window,
        /// both thumbnails and peek representations, should be refreshed.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/nf-dwmapi-dwminvalidateiconicbitmaps"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window or tab whose bitmaps are being invalidated through this call.
        /// This window must belong to the calling process.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// Calling this function causes the Desktop Window Manager (DWM) to invalidate its current bitmaps for the window
        /// and request new bitmaps from the window when they are next needed.
        /// <see cref="DwmInvalidateIconicBitmaps"/> should not be called frequently.
        /// Doing so can lead to poor performance as new bitmaps are created and retrieved.
        /// </remarks>
        [DllImport("Dwmapi.dll", CharSet = CharSet.Unicode, EntryPoint = "DwmInvalidateIconicBitmaps", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT DwmInvalidateIconicBitmaps([In] HWND hwnd);

        /// <summary>
        /// <para>
        /// Obtains a value that indicates whether Desktop Window Manager (DWM) composition is enabled.
        /// Applications on machines running Windows 7 or earlier can listen for composition state changes
        /// by handling the <see cref="WM_DWMCOMPOSITIONCHANGED"/> notification.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/nf-dwmapi-dwmiscompositionenabled"/>
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
        /// Retrieves the source size of the Desktop Window Manager (DWM) thumbnail.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/nf-dwmapi-dwmquerythumbnailsourcesize"/>
        /// </para>
        /// </summary>
        /// <param name="hThumbnail">
        /// A handle to the thumbnail to retrieve the source window size from.
        /// </param>
        /// <param name="pSize">
        /// A pointer to a <see cref="SIZE"/> structure that, when this function returns successfully, receives the size of the source thumbnail.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        [DllImport("Dwmapi.dll", CharSet = CharSet.Unicode, EntryPoint = "DwmQueryThumbnailSourceSize", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT DwmQueryThumbnailSourceSize([In] HTHUMBNAIL hThumbnail, [Out] out SIZE pSize);

        /// <summary>
        /// <para>
        /// Creates a Desktop Window Manager (DWM) thumbnail relationship between the destination and source windows.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/nf-dwmapi-dwmregisterthumbnail"/>
        /// </para>
        /// </summary>
        /// <param name="hwndDestination">
        /// The handle to the window that will use the DWM thumbnail.
        /// Setting the destination window handle to anything other than a top-level window type will result in a return value of <see cref="E_INVALIDARG"/>.
        /// </param>
        /// <param name="hwndSource">
        /// The handle to the window to use as the thumbnail source.
        /// Setting the source window handle to anything other than a top-level window type will result in a return value of <see cref="E_INVALIDARG"/>.
        /// </param>
        /// <param name="phThumbnailId">
        /// A pointer to a handle that, when this function returns successfully, represents the registration of the DWM thumbnail.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// Registering a DWM thumbnail relationship will not modify desktop composition;
        /// for information about thumbnail positioning, see the documentation for the <see cref="DwmUpdateThumbnailProperties"/> function.
        /// The window designated by <paramref name="hwndDestination"/> must either be the desktop window itself
        /// or be owned by the process that is calling <see cref="DwmRegisterThumbnail"/>.
        /// This is required to prevent applications from affecting the content of other applications.
        /// The thumbnail registration handle obtained by this function is not globally unique but is unique to the process.
        /// Call the <see cref="DwmUnregisterThumbnail"/> function to unregister the thumbnail.
        /// This must be done within the process that the relationship was registered in.
        /// </remarks>
        [DllImport("Dwmapi.dll", CharSet = CharSet.Unicode, EntryPoint = "DwmRegisterThumbnail", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT DwmRegisterThumbnail([In] HWND hwndDestination, [In] HWND hwndSource, [Out] out HTHUMBNAIL phThumbnailId);

        /// <summary>
        /// <para>
        /// Notifies Desktop Window Manager (DWM) that a touch contact has been recognized as a gesture,
        /// and that DWM should draw feedback for that gesture.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/nf-dwmapi-dwmrendergesture"/>
        /// </para>
        /// </summary>
        /// <param name="gt">
        /// </param>
        /// <param name="cContacts">
        /// The number of contact points.
        /// </param>
        /// <param name="pdwPointerID">
        /// The pointer ID.
        /// </param>
        /// <param name="pPoints">
        /// The points.
        /// </param>
        /// <returns></returns>
        [DllImport("Dwmapi.dll", CharSet = CharSet.Unicode, EntryPoint = "DwmRenderGesture", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT DwmRenderGesture([In] GESTURE_TYPE gt, [In] UINT cContacts, [In] DWORD[] pdwPointerID, [In] POINT[] pPoints);

        /// <summary>
        /// <para>
        /// Sets a static, iconic bitmap to display a live preview (also known as a Peek preview) of a window or tab.
        /// The taskbar can use this bitmap to show a full-sized preview of a window or tab.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/nf-dwmapi-dwmseticoniclivepreviewbitmap"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window.
        /// This window must belong to the calling process.
        /// </param>
        /// <param name="hbmp">
        /// A handle to the bitmap to represent the window that <paramref name="hwnd"/> specifies.
        /// </param>
        /// <param name="pptClient">
        /// The offset of a tab window's client region (the content area inside the client window frame) from the host window's frame.
        /// This offset enables the tab window's contents to be drawn correctly in a live preview when it is drawn without its frame.
        /// </param>
        /// <param name="dwSITFlags">
        /// The display options for the live preview.
        /// This parameter can be 0 or the following value.
        /// <see cref="DWM_SIT_DISPLAYFRAME"/> (0x00000001)
        /// 0x00000001. Displays a frame around the provided bitmap.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if the function succeeds, or an error value otherwise.
        /// Note that because this bitmap is not cached, if the window is not being previewed when an application calls this function,
        /// the function returns a success code but the bitmap is discarded and not used.
        /// </returns>
        /// <remarks>
        /// A live preview (also known as a Peek preview) of a window appears when a user moves the mouse pointer over the window's thumbnail in the taskbar
        /// or gives the thumbnail focus in the ALT+TAB window.
        /// This view is a full-sized view of the window and can be a snapshot or an iconic representation.
        /// A window typically calls the <see cref="DwmSetIconicLivePreviewBitmap"/> function in response to a <see cref="WM_DWMSENDICONICLIVEPREVIEWBITMAP"/> message.
        /// The returned bitmap must not be larger than the client area of the window or frame and must have 32-bit color depth.
        /// The Desktop Window Manager (DWM) uses a copy of the bitmap,
        /// but the caller retains ownership of the original bitmap and is responsible for freeing the resources that it uses when it is no longer needed.
        /// The DWM does not keep its copy of the bitmap when the DWM stops displaying the live preview representation.
        /// </remarks>
        [DllImport("Dwmapi.dll", CharSet = CharSet.Unicode, EntryPoint = "DwmSetIconicLivePreviewBitmap", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT DwmSetIconicLivePreviewBitmap([In] HWND hwnd, [In] HBITMAP hbmp, [In] in POINT pptClient, [In] DWORD dwSITFlags);

        /// <summary>
        /// <para>
        /// Sets a static, iconic bitmap on a window or tab to use as a thumbnail representation.
        /// The taskbar can use this bitmap as a thumbnail switch target for the window or tab.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/nf-dwmapi-dwmseticonicthumbnail"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window or tab.
        /// This window must belong to the calling process.
        /// </param>
        /// <param name="hbmp">
        /// A handle to the bitmap to represent the window that <paramref name="hwnd"/> specifies.
        /// </param>
        /// <param name="dwSITFlags">
        /// The display options for the thumbnail.
        /// One of the following values:
        /// 0 (0x00000000)
        /// No frame is displayed around the provided thumbnail.
        /// <see cref="DWM_SIT_DISPLAYFRAME"/> (0x00000001)
        /// Displays a frame around the provided thumbnail.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// An application typically calls the <see cref="DwmSetIconicThumbnail"/> function
        /// after it receives a <see cref="WM_DWMSENDICONICTHUMBNAIL"/> message for its window.
        /// The thumbnail should not exceed the maximum x-coordinate and y-coordinate that are specified in that message.
        /// The thumbnail must also have a 32-bit color depth.
        /// The application calls <see cref="DwmInvalidateIconicBitmaps"/> to indicate to the Desktop Window Manager (DWM)
        /// that the iconic thumbnail and live preview bitmaps are out-of-date and should be refreshed.
        /// The DWM then requests new versions from the window when they are needed.
        /// However, if the DWM bitmap cache is full, DWM will not request updated versions.
        /// The DWM uses a copy of the bitmap, but the application can release this copy at any time because of memory constraints.
        /// If the copy is released, the window is not notified,
        /// but it might receive a subsequent <see cref="WM_DWMSENDICONICTHUMBNAIL"/> request when its thumbnail is needed again.
        /// The caller retains ownership of the original bitmap and is responsible for freeing the resources that it uses when it is no longer needed.
        /// </remarks>
        [DllImport("Dwmapi.dll", CharSet = CharSet.Unicode, EntryPoint = "DwmSetIconicThumbnail", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT DwmSetIconicThumbnail([In] HWND hwnd, [In] HBITMAP hbmp, [In] DWORD dwSITFlags);

        /// <summary>
        /// <para>
        /// Sets the value of Desktop Window Manager (DWM) non-client rendering attributes for a window.
        /// For programming guidance, and code examples, see Controlling non-client region rendering.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/nf-dwmapi-dwmsetwindowattribute"/>
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

        /// <summary>
        /// <para>
        /// Called by an app or framework to specify the visual feedback type to draw in response to a particular touch or pen contact.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/nf-dwmapi-dwmshowcontact"/>
        /// </para>
        /// </summary>
        /// <param name="dwPointerID">
        /// The pointer ID of the contact. 
        /// Each touch or pen contact is given a unique ID when it is detected.
        /// </param>
        /// <param name="eShowContact"></param>
        /// <returns>
        /// If <paramref name="dwPointerID"/> does not match that of a contact currently present on the screen,
        /// this function returns <see cref="E_INVALIDARG"/>; otherwise, it returns <see cref="S_OK"/>.
        /// </returns>
        /// <remarks>
        /// It is safe to call this function on the UI thread.
        /// </remarks>
        [DllImport("Dwmapi.dll", CharSet = CharSet.Unicode, EntryPoint = "DwmShowContact", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT DwmShowContact([In] DWORD dwPointerID, [In] DWM_SHOWCONTACT eShowContact);

        /// <summary>
        /// <para>
        /// Enables the graphical feedback of touch and drag interactions to the user.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/nf-dwmapi-dwmtethercontact"/>
        /// </para>
        /// </summary>
        /// <param name="dwPointerID">
        /// The pointer ID.
        /// </param>
        /// <param name="fEnable">
        /// Indicates whether the contact is enabled.
        /// </param>
        /// <param name="ptTether">
        /// The tether.
        /// </param>
        /// <returns></returns>
        [DllImport("Dwmapi.dll", CharSet = CharSet.Unicode, EntryPoint = "DwmTetherContact", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT DwmTetherContact([In] DWORD dwPointerID, [In] BOOL fEnable, [In] POINT ptTether);

        /// <summary>
        /// <para>
        /// Coordinates the animations of tool windows with the Desktop Window Manager (DWM).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/nf-dwmapi-dwmtransitionownedwindow"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// Handle to the window.
        /// </param>
        /// <param name="target"></param>
        /// <returns></returns>
        [DllImport("Dwmapi.dll", CharSet = CharSet.Unicode, EntryPoint = "DwmTransitionOwnedWindow", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT DwmTransitionOwnedWindow([In] HWND hwnd, [In] DWMTRANSITION_OWNEDWINDOW_TARGET target);

        /// <summary>
        /// <para>
        /// Removes a Desktop Window Manager (DWM) thumbnail relationship created by the <see cref="DwmRegisterThumbnail"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/nf-dwmapi-dwmunregisterthumbnail"/>
        /// </para>
        /// </summary>
        /// <param name="hThumbnailId">
        /// The handle to the thumbnail relationship to be removed.
        /// Null or non-existent handles will result in a return value of <see cref="E_INVALIDARG"/>.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// Unregistering DWM thumbnail relationships must be done within the process that registered the relationships.
        /// </remarks>
        [DllImport("Dwmapi.dll", CharSet = CharSet.Unicode, EntryPoint = "DwmUnregisterThumbnail", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT DwmUnregisterThumbnail([In] HTHUMBNAIL hThumbnailId);

        /// <summary>
        /// <para>
        /// Updates the properties for a Desktop Window Manager (DWM) thumbnail.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/nf-dwmapi-dwmupdatethumbnailproperties"/>
        /// </para>
        /// </summary>
        /// <param name="hThumbnailId">
        /// The handle to the DWM thumbnail to be updated.
        /// Null or invalid thumbnails, as well as thumbnails owned by other processes will result in a return value of <see cref="E_INVALIDARG"/>.
        /// </param>
        /// <param name="ptnProperties">
        /// A pointer to a <see cref="DWM_THUMBNAIL_PROPERTIES"/> structure that contains the new thumbnail properties.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// Thumbnail relationships created by the <see cref="DwmRegisterThumbnail"/> function
        /// will not be rendered to the destination window until this function is called.
        /// Subsequent calls will update the thumbnail according to the provided properties.
        /// </remarks>
        [DllImport("Dwmapi.dll", CharSet = CharSet.Unicode, EntryPoint = "DwmUpdateThumbnailProperties", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT DwmUpdateThumbnailProperties([In] HTHUMBNAIL hThumbnailId,[In]in DWM_THUMBNAIL_PROPERTIES ptnProperties);
    }
}
