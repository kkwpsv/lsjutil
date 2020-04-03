using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32
{
    public partial class User32
    {
        /// <summary>
        /// <para>
        /// The <see cref="ScrollDC"/> function scrolls a rectangle of bits horizontally and vertically.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-scrolldc
        /// </para>
        /// </summary>
        /// <param name="hDC">
        /// Handle to the device context that contains the bits to be scrolled.
        /// </param>
        /// <param name="dx">
        /// Specifies the amount, in device units, of horizontal scrolling.
        /// This parameter must be a negative value to scroll to the left.
        /// </param>
        /// <param name="dy">
        /// Specifies the amount, in device units, of vertical scrolling.
        /// This parameter must be a negative value to scroll up.
        /// </param>
        /// <param name="lprcScroll">
        /// Pointer to a <see cref="RECT"/> structure containing the coordinates of the bits to be scrolled.
        /// The only bits affected by the scroll operation are bits in the intersection of this rectangle
        /// and the rectangle specified by <paramref name="lprcClip"/>.
        /// If <paramref name="lprcScroll"/> is <see langword="null"/>, the entire client area is used.
        /// </param>
        /// <param name="lprcClip">
        /// Pointer to a <see cref="RECT"/> structure containing the coordinates of the clipping rectangle.
        /// The only bits that will be painted are the bits that remain inside this rectangle after the scroll operation has been completed.
        /// If <paramref name="lprcClip"/> is <see langword="null"/>, the entire client area is used.
        /// </param>
        /// <param name="hrgnUpdate">
        /// Handle to the region uncovered by the scrolling process.
        /// <see cref="ScrollDC"/> defines this region; it is not necessarily a rectangle.
        /// </param>
        /// <param name="lprcUpdate">
        /// Pointer to a <see cref="RECT"/> structure that receives the coordinates of the rectangle bounding the scrolling update region.
        /// This is the largest rectangular area that requires repainting.
        /// When the function returns, the values in the structure are in client coordinates, regardless of the mapping mode for the specified device context.
        /// This allows applications to use the update region in a call to the <see cref="InvalidateRgn"/> function, if required.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the <paramref name="lprcUpdate"/> parameter is <see langword="null"/>, the system does not compute the update rectangle.
        /// If both the <paramref name="hrgnUpdate"/> and <paramref name="lprcUpdate"/> parameters are <see langword="null"/>,
        /// the system does not compute the update region.
        /// If <paramref name="hrgnUpdate"/> is not <see langword="null"/>,
        /// the system proceeds as though it contains a valid handle to the region uncovered by the scrolling process (defined by <see cref="ScrollDC"/>).
        /// When you must scroll the entire client area of a window, use the <see cref="ScrollWindowEx"/> function.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ScrollDC", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ScrollDC([In]HDC hDC, [In]int dx, [In]int dy, [In]in RECT lprcScroll, [In]in RECT lprcClip,
            [In]HRGN hrgnUpdate, [Out]out RECT lprcUpdate);

        /// <summary>
        /// <para>
        /// The <see cref="ScrollWindow"/> function scrolls the contents of the specified window's client area.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-scrollwindow
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// Handle to the window where the client area is to be scrolled.
        /// </param>
        /// <param name="XAmount">
        /// Specifies the amount, in device units, of horizontal scrolling.
        /// If the window being scrolled has the <see cref="CS_OWNDC"/> or <see cref="CS_CLASSDC"/> style,
        /// then this parameter uses logical units rather than device units.
        /// This parameter must be a negative value to scroll the content of the window to the left.
        /// </param>
        /// <param name="YAmount">
        /// Specifies the amount, in device units, of vertical scrolling.
        /// If the window being scrolled has the <see cref="CS_OWNDC"/> or <see cref="CS_CLASSDC"/> style,
        /// then this parameter uses logical units rather than device units.
        /// This parameter must be a negative value to scroll the content of the window up.
        /// </param>
        /// <param name="lpRect">
        /// Pointer to the <see cref="RECT"/> structure specifying the portion of the client area to be scrolled.
        /// If this parameter is <see cref="NULL"/>, the entire client area is scrolled.
        /// </param>
        /// <param name="lpClipRect">
        /// Pointer to the <see cref="RECT"/> structure containing the coordinates of the clipping rectangle.
        /// Only device bits within the clipping rectangle are affected.
        /// Bits scrolled from the outside of the rectangle to the inside are painted;
        /// bits scrolled from the inside of the rectangle to the outside are not painted.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the caret is in the window being scrolled, <see cref="ScrollWindow"/> automatically hides the caret
        /// to prevent it from being erased and then restores the caret after the scrolling is finished.
        /// The caret position is adjusted accordingly.
        /// The area uncovered by <see cref="ScrollWindow"/> is not repainted, but it is combined into the window's update region.
        /// The application eventually receives a <see cref="WM_PAINT"/> message notifying it that the region must be repainted.
        /// To repaint the uncovered area at the same time the scrolling is in action,
        /// call the <see cref="UpdateWindow"/> function immediately after calling <see cref="ScrollWindow"/>.
        /// If the <paramref name="lpRect"/> parameter is <see langword="null"/>,
        /// the positions of any child windows in the window are offset
        /// by the amount specified by the <paramref name="XAmount"/> and <paramref name="YAmount"/> parameters;
        /// invalid (unpainted) areas in the window are also offset.
        /// <see cref="ScrollWindow"/> is faster when <paramref name="lpRect"/> is <see langword="null"/>.
        /// If <paramref name="lpRect"/> is not <see langword="null"/>,
        /// the positions of child windows are not changed and invalid areas in the window are not offset.
        /// To prevent updating problems when <paramref name="lpRect"/> is not <see langword="null"/>,
        /// call <see cref="UpdateWindow"/> to repaint the window before calling <see cref="ScrollWindow"/>.
        /// </remarks>
        [Obsolete("The ScrollWindow function is provided for backward compatibility. New applications should use the ScrollWindowEx function.")]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "BeginPaint", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ScrollWindow([In]HWND hWnd, [In]int XAmount, [In]int YAmount, [In]in RECT lpRect, [In]in RECT lpClipRect);

        /// <summary>
        /// <para>
        /// The <see cref="ScrollWindowEx"/> function scrolls the contents of the specified window's client area.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-scrollwindowex
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// Handle to the window where the client area is to be scrolled.
        /// </param>
        /// <param name="dx">
        /// Specifies the amount, in device units, of horizontal scrolling.
        /// This parameter must be a negative value to scroll to the left.
        /// </param>
        /// <param name="dy">
        /// Specifies the amount, in device units, of vertical scrolling.
        /// This parameter must be a negative value to scroll up.
        /// </param>
        /// <param name="prcScroll">
        /// Pointer to a <see cref="RECT"/> structure that specifies the portion of the client area to be scrolled.
        /// If this parameter is <see langword="null"/>, the entire client area is scrolled.
        /// </param>
        /// <param name="prcClip">
        /// Pointer to a <see cref="RECT"/> structure that contains the coordinates of the clipping rectangle.
        /// Only device bits within the clipping rectangle are affected.
        /// Bits scrolled from the outside of the rectangle to the inside are painted;
        /// bits scrolled from the inside of the rectangle to the outside are not painted.
        /// This parameter may be <see langword="null"/>.
        /// </param>
        /// <param name="hrgnUpdate">
        /// Handle to the region that is modified to hold the region invalidated by scrolling.
        /// This parameter may be <see cref="NULL"/>.
        /// </param>
        /// <param name="prcUpdate">
        /// Pointer to a <see cref="RECT"/> structure that receives the boundaries of the rectangle invalidated by scrolling.
        /// This parameter may be <see langword="null"/>.
        /// </param>
        /// <param name="flags">
        /// Specifies flags that control scrolling. This parameter can be a combination of the following values.
        /// <see cref="SW_ERASE"/>, <see cref="SW_INVALIDATE"/>, <see cref="SW_SCROLLCHILDREN"/>, <see cref="SW_SMOOTHSCROLL"/>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="SIMPLEREGION"/> (rectangular invalidated region),
        /// <see cref="COMPLEXREGION"/> (nonrectangular invalidated region; overlapping rectangles), or <see cref="NULLREGION"/> (no invalidated region).
        /// If the function fails, the return value is <see cref="ERROR"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the <see cref="SW_INVALIDATE"/> and <see cref="SW_ERASE"/> flags are not specified,
        /// <see cref="ScrollWindowEx"/> does not invalidate the area that is scrolled from.
        /// If either of these flags is set, <see cref="ScrollWindowEx"/> invalidates this area.
        /// The area is not updated until the application calls the <see cref="UpdateWindow"/> function,
        /// calls the <see cref="RedrawWindow"/> function (specifying the <see cref="RDW_UPDATENOW"/> or <see cref="RDW_ERASENOW"/> flag),
        /// or retrieves the <see cref="WM_PAINT"/> message from the application queue.
        /// If the window has the <see cref="WS_CLIPCHILDREN"/> style, the returned areas specified
        /// by <paramref name="hrgnUpdate"/> and <paramref name="prcUpdate"/> represent the total area of the scrolled window that must be updated,
        /// including any areas in child windows that need updating.
        /// If the <see cref="SW_SCROLLCHILDREN"/> flag is specified, the system does not properly update the screen if part of a child window is scrolled.
        /// The part of the scrolled child window that lies outside the source rectangle is not erased and is not properly redrawn in its new destination.
        /// To move child windows that do not lie completely within the rectangle specified by <paramref name="prcScroll"/>,
        /// use the <see cref="DeferWindowPos"/> function.
        /// The cursor is repositioned if the <see cref="SW_SCROLLCHILDREN"/> flag is set and the caret rectangle intersects the scroll rectangle.
        /// All input and output coordinates (for <paramref name="prcScroll"/>, <paramref name="prcClip"/>, <paramref name="prcUpdate"/>,
        /// and <paramref name="hrgnUpdate"/>) are determined as client coordinates,
        /// regardless of whether the window has the <see cref="CS_OWNDC"/> or <see cref="CS_CLASSDC"/> class style.
        /// Use the <see cref="LPtoDP"/> and <see cref="DPtoLP"/> functions to convert to and from logical coordinates, if necessary.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ScrollWindowEx", ExactSpelling = true, SetLastError = true)]
        public static extern int ScrollWindowEx([In]HWND hWnd, [In]int dx, [In]int dy, [In]in RECT prcScroll, [In]in RECT prcClip,
            [In]HRGN hrgnUpdate, [Out]out RECT prcUpdate, [In]ScrollWindowExFlags flags);
    }
}
