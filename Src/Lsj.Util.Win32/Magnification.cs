using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Magnification.dll
    /// </summary>
    public static class Magnification
    {
        /// <summary>
        /// <para>
        /// Prototype for a callback function that implements a custom transform for image scaling.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/magnification/nc-magnification-magimagescalingcallback"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// The magnification window.
        /// </param>
        /// <param name="srcdata">
        /// The input data.
        /// </param>
        /// <param name="srcheader">
        /// The description of the input format.
        /// </param>
        /// <param name="destdata">
        /// The output data.
        /// </param>
        /// <param name="destheader">
        /// The description of the output format.
        /// </param>
        /// <param name="unclipped">
        /// The coordinates of the scaled version of the source bitmap.
        /// </param>
        /// <param name="clipped">
        /// The coordinates of the window to which the scaled bitmap is clipped.
        /// </param>
        /// <param name="dirty">
        /// The region that needs to be refreshed.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful, or <see cref="FALSE"/> otherwise.
        /// </returns>
        [Obsolete(" The MagImageScalingCallback function is deprecated in Windows 7 and later, and should not be used in new applications." +
            " There is no alternate functionality.")]
        public delegate BOOL MagImageScalingCallback([In] HWND hwnd, [In] IntPtr srcdata, [In] MAGIMAGEHEADER srcheader, [In] IntPtr destdata,
            [In] MAGIMAGEHEADER destheader, [In] RECT unclipped, [In] RECT clipped, [In] HRGN dirty);

        /// <summary>
        /// <para>
        /// Gets the rectangle of the area that is being magnified.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/magnification/nf-magnification-maggetwindowsource"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// The magnification window.
        /// </param>
        /// <param name="pRect">
        /// The rectangle that is being magnified, in desktop coordinates.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful, or <see cref="FALSE"/> otherwise.
        /// </returns>
        [DllImport("Magnification.dll", CharSet = CharSet.Unicode, EntryPoint = "MagGetWindowSource", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL MagGetWindowSource([In] HWND hwnd, [In] in RECT pRect);

        /// <summary>
        /// <para>
        /// Creates and initializes the magnifier run-time objects.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/magnification/nf-magnification-maginitialize"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// Returns <see cref="TRUE"/> if initialization was successful; otherwise <see cref="FALSE"/>.
        /// </returns>
        [DllImport("Magnification.dll", CharSet = CharSet.Unicode, EntryPoint = "MagInitialize", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL MagInitialize();

        /// <summary>
        /// <para>
        /// Sets the callback function for external image filtering and scaling.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/magnification/nf-magnification-magsetimagescalingcallback"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// The handle of the magnification window.
        /// </param>
        /// <param name="callback">
        /// The callback function, or <see langword="null"/> to remove a callback that was previously set.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful, or <see cref="FALSE"/> otherwise.
        /// </returns>
        /// <remarks>
        /// This function requires Windows Display Driver Model (WDDM)-capable video cards.
        /// This function works only when Desktop Window Manager (DWM) is off.
        /// This callback mechanism enables custom image filtering and scaling mechanisms.
        /// Filtering might include bilinear, trilinear, bicubic, and flat.
        /// The mechanism also enables edge detection and enhancement.
        /// The only transform that can be performed within the callback is scaling.
        /// Rotations and skews that may compose the arbitrary transform passed to the <see cref="MagSetWindowTransform"/> function are performed after the callback function returns.
        /// The specified function is called by the magnification engine for all rasterized Windows Graphics Device Interface (GDI) bitmaps before they are composited.
        /// After the callback function returns, the bitmap in video memory can have one of the following size states:
        /// Unscaled. The returned bitmap is the same size as the bitmap passed by the caller.
        /// The magnification engine does the scaling by the transform specified in the <see cref="MagSetWindowTransform"/> function.
        /// Scaled. The returned bitmap is scaled by the transform specified in <see cref="MagSetWindowTransform"/>.
        /// If no callback is registered, the magnification engine scales bitmaps by the transform specified in <see cref="MagSetWindowTransform"/>.
        /// Windows Presentation Foundation (WPF) bitmaps can be scaled automatically using flat, bilinear, bicubic filtering and consequently do not use this callback mechanism.
        /// </remarks>
        [Obsolete("The MagSetImageScalingCallback function is deprecated in Windows 7 and later, and should not be used in new applications." +
            " There is no alternate functionality.")]
        [DllImport("Magnification.dll", CharSet = CharSet.Unicode, EntryPoint = "MagSetImageScalingCallback", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL MagSetImageScalingCallback([In] HWND hwnd, [In] MagImageScalingCallback callback);

        /// <summary>
        /// <para>
        /// Sets the transformation matrix for a magnifier control.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/magnification/nf-magnification-magsetwindowtransform"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// The magnification window.
        /// </param>
        /// <param name="pTransform">
        /// A transformation matrix.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful, or <see cref="FALSE"/> otherwise.
        /// </returns>
        /// <remarks>
        /// The transformation matrix specifies the magnification factor that the magnifier control applies to the contents of the source rectangle.
        /// </remarks>
        [DllImport("Magnification.dll", CharSet = CharSet.Unicode, EntryPoint = "MagSetWindowTransform", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL MagSetWindowTransform([In] HWND hwnd, [In] in MAGTRANSFORM pTransform);

        /// <summary>
        /// <para>
        /// Destroys the magnifier run-time objects.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/magnification/nf-magnification-maguninitialize"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful, or <see cref="FALSE"/> otherwise.
        /// </returns>
        [DllImport("Magnification.dll", CharSet = CharSet.Unicode, EntryPoint = "MagUninitialize", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL MagUninitialize();
    }
}
