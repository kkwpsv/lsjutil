using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.LONG;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.ButtonControlMessages;
using static Lsj.Util.Win32.Enums.ButtonStates;
using static Lsj.Util.Win32.Enums.ButtonStyles;
using static Lsj.Util.Win32.Enums.ClassStyles;
using static Lsj.Util.Win32.Enums.EnableScrollBarFlags;
using static Lsj.Util.Win32.Enums.RedrawWindowFlags;
using static Lsj.Util.Win32.Enums.RegionFlags;
using static Lsj.Util.Win32.Enums.ScrollBarCommands;
using static Lsj.Util.Win32.Enums.ScrollBarConstants;
using static Lsj.Util.Win32.Enums.ScrollBarMessages;
using static Lsj.Util.Win32.Enums.SCROLLINFOFlags;
using static Lsj.Util.Win32.Enums.ScrollWindowExFlags;
using static Lsj.Util.Win32.Enums.WindowsMessages;
using static Lsj.Util.Win32.Enums.WindowStyles;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32
{
    public partial class User32
    {
        /// <summary>
        /// <para>
        /// Changes the check state of a button control.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-checkdlgbutton"/>
        /// </para>
        /// </summary>
        /// <param name="hDlg">
        /// A handle to the dialog box that contains the button.
        /// </param>
        /// <param name="nIDButton">
        /// The identifier of the button to modify.
        /// </param>
        /// <param name="uCheck">
        /// The check state of the button.
        /// This parameter can be one of the following values.
        /// <see cref="BST_CHECKED"/>: 
        /// Sets the button state to checked.
        /// <see cref="BST_INDETERMINATE"/>:
        /// Sets the button state to grayed, indicating an indeterminate state.
        /// Use this value only if the button has the <see cref="BS_3STATE"/> or <see cref="BS_AUTO3STATE"/> style.
        /// <see cref="BST_UNCHECKED"/>:
        /// Sets the button state to cleared
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="CheckDlgButton"/> function sends a <see cref="BM_SETCHECK"/> message to the specified button control in the specified dialog box.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CheckDlgButton", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CheckDlgButton([In] HWND hDlg, [In] int nIDButton, [In] ButtonStates uCheck);

        /// <summary>
        /// <para>
        /// Adds a check mark to (checks) a specified radio button in a group and removes a check mark from (clears) all other radio buttons in the group.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-checkradiobutton"/>
        /// </para>
        /// </summary>
        /// <param name="hDlg">
        /// A handle to the dialog box that contains the radio button.
        /// </param>
        /// <param name="nIDFirstButton">
        /// The identifier of the first radio button in the group.
        /// </param>
        /// <param name="nIDLastButton">
        /// The identifier of the last radio button in the group.
        /// </param>
        /// <param name="nIDCheckButton">
        /// The identifier of the radio button to select.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="CheckRadioButton"/> function sends a <see cref="BM_SETCHECK"/> message to each of the radio buttons in the indicated group.
        /// The <paramref name="nIDFirstButton"/> and <paramref name="nIDLastButton"/> parameters
        /// specify a range of button identifiers (normally the resource IDs of the buttons).
        /// The position of buttons in the tab order is irrelevant; if a button forms part of a group,
        /// but has an ID outside the specified range,it is not affected by this call.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CheckRadioButton", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CheckRadioButton([In] HWND hDlg, [In] int nIDFirstButton, [In] int nIDLastButton, [In] int nIDCheckButton);

        /// <summary>
        /// <para>
        /// The <see cref="EnableScrollBar"/> function enables or disables one or both scroll bar arrows.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-enablescrollbar"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// Handle to a window or a scroll bar control, depending on the value of the <paramref name="wSBflags"/> parameter.
        /// </param>
        /// <param name="wSBflags">
        /// Specifies the scroll bar type.
        /// This parameter can be one of the following values.
        /// <see cref="SB_BOTH"/>:
        /// Enables or disables the arrows on the horizontal and vertical scroll bars associated with the specified window.
        /// The <paramref name="hWnd"/> parameter must be the handle to the window.
        /// <see cref="SB_CTL"/>:
        /// Indicates that the scroll bar is a scroll bar control.
        /// The <paramref name="hWnd"/> must be the handle to the scroll bar control.
        /// <see cref="SB_HORZ"/>:
        /// Enables or disables the arrows on the horizontal scroll bar associated with the specified window.
        /// The <paramref name="hWnd"/> parameter must be the handle to the window.
        /// <see cref="SB_VERT"/>:
        /// Enables or disables the arrows on the vertical scroll bar associated with the specified window.
        /// The <paramref name="hWnd"/> parameter must be the handle to the window.
        /// </param>
        /// <param name="wArrows">
        /// Specifies whether the scroll bar arrows are enabled or disabled and indicates which arrows are enabled or disabled.
        /// This parameter can be one of the following values.
        /// <see cref="ESB_DISABLE_BOTH"/>, <see cref="ESB_DISABLE_DOWN"/>, <see cref="ESB_DISABLE_LEFT"/>, <see cref="ESB_DISABLE_LTUP"/>,
        /// <see cref="ESB_DISABLE_RIGHT"/>, <see cref="ESB_DISABLE_RTDN"/>, <see cref="ESB_DISABLE_UP"/>, <see cref="ESB_ENABLE_BOTH"/>
        /// </param>
        /// <returns>
        /// If the arrows are enabled or disabled as specified, the return value is <see cref="TRUE"/>.
        /// If the arrows are already in the requested state or an error occurs, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnableScrollBar", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnableScrollBar([In] HWND hWnd, [In] ScrollBarConstants wSBflags, [In] EnableScrollBarFlags wArrows);

        /// <summary>
        /// <para>
        /// The GetScrollInfo function retrieves the parameters of a scroll bar, including the minimum and maximum scrolling positions,
        /// the page size, and the position of the scroll box (thumb).
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getscrollinfo"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// Handle to a scroll bar control or a window with a standard scroll bar, depending on the value of the <paramref name="nBar"/> parameter.
        /// </param>
        /// <param name="nBar">
        /// Specifies the type of scroll bar for which to retrieve parameters. This parameter can be one of the following values.
        /// <see cref="SB_CTL"/>:
        /// Retrieves the parameters for a scroll bar control.
        /// The <paramref name="hwnd"/> parameter must be the handle to the scroll bar control.
        /// <see cref="SB_HORZ"/>:
        /// Retrieves the parameters for the window's standard horizontal scroll bar.
        /// <see cref="SB_VERT"/>:
        /// Retrieves the parameters for the window's standard vertical scroll bar.
        /// </param>
        /// <param name="lpsi">
        /// Pointer to a <see cref="SCROLLINFO"/> structure.
        /// Before calling <see cref="GetScrollInfo"/>, set the <see cref="SCROLLINFO.cbSize"/> member to <code>sizeof(SCROLLINFO)</code>,
        /// and set the <see cref="SCROLLINFO.fMask"/> member to specify the scroll bar parameters to retrieve.
        /// Before returning, the function copies the specified parameters to the appropriate members of the structure.
        /// The <see cref="SCROLLINFO.fMask"/> member can be one or more of the following values.
        /// <see cref="SIF_PAGE"/>:
        /// Copies the scroll page to the <see cref="SCROLLINFO.nPage"/> member
        /// of the <see cref="SCROLLINFO"/> structure pointed to by <paramref name="lpsi"/>.
        /// <see cref="SIF_POS"/>:
        /// Copies the scroll position to the <see cref="SCROLLINFO.nPos"/> member
        /// of the <see cref="SCROLLINFO"/> structure pointed to by <paramref name="lpsi"/>.
        /// <see cref="SIF_RANGE"/>:
        /// Copies the scroll range to the <see cref="SCROLLINFO.nMin"/> and <see cref="SCROLLINFO.nMax"/> members
        /// of the <see cref="SCROLLINFO"/> structure pointed to by <paramref name="lpsi"/>.
        /// <see cref="SIF_TRACKPOS"/>:
        /// Copies the current scroll box tracking position to the <see cref="SCROLLINFO.nTrackPos"/> member
        /// of the <see cref="SCROLLINFO"/> structure pointed to by <paramref name="lpsi"/>.
        /// </param>
        /// <returns>
        /// If the function retrieved any values, the return value is <see cref="TRUE"/>.
        /// If the function does not retrieve any values, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="GetScrollInfo"/> function enables applications to use 32-bit scroll positions.
        /// Although the messages that indicate scroll bar position, <see cref="WM_HSCROLL"/> and <see cref="WM_VSCROLL"/>,
        /// provide only 16 bits of position data, the functions <see cref="SetScrollInfo"/> and <see cref="GetScrollInfo"/>
        /// provide 32 bits of scroll bar position data.
        /// Thus, an application can call <see cref="GetScrollInfo"/> while processing
        /// either the <see cref="WM_HSCROLL"/> or <see cref="WM_VSCROLL"/> messages to obtain 32-bit scroll bar position data.
        /// To get the 32-bit position of the scroll box (thumb) during a <see cref="SB_THUMBTRACK"/> request code
        /// in a <see cref="WM_HSCROLL"/> or <see cref="WM_VSCROLL"/> message, call <see cref="GetScrollInfo"/> with the <see cref="SIF_TRACKPOS"/> value
        /// in the <see cref="SCROLLINFO.fMask"/> member of the <see cref="SCROLLINFO"/> structure.
        /// The function returns the tracking position of the scroll box
        /// in the <see cref="SCROLLINFO.nTrackPos"/> member of the <see cref="SCROLLINFO"/> structure.
        /// This allows you to get the position of the scroll box as the user moves it.
        /// The following sample code illustrates the technique.
        /// <code>
        /// SCROLLINFO si;
        /// case WM_HSCROLL:
        /// switch(LOWORD(wparam)) {
        ///     case SB_THUMBTRACK:
        ///     // Initialize SCROLLINFO structure
        ///     ZeroMemory(&amp;si, sizeof(si));
        ///     si.cbSize = sizeof(si);
        ///     si.fMask = SIF_TRACKPOS;
        ///     // Call GetScrollInfo to get current tracking 
        ///     //    position in si.nTrackPos
        ///     
        ///     if (!GetScrollInfo(hwnd, SB_HORZ, &amp;si) )
        ///     return 1; // GetScrollInfo failed
        ///     break;
        ///     .
        ///     .
        ///     .
        /// }
        /// </code>
        /// If the <paramref name="nBar"/> parameter is <see cref="SB_CTL"/> and the window specified
        /// by the <paramref name="hwnd"/> parameter is not a system scroll bar control,
        /// the system sends the <see cref="SBM_GETSCROLLINFO"/> message to the window to obtain scroll bar information.
        /// This allows <see cref="GetScrollInfo"/> to operate on a custom control that mimics a scroll bar.
        /// If the window does not handle the <see cref="SBM_GETSCROLLINFO"/> message, the <see cref="GetScrollInfo"/> function fails.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetScrollInfo", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetScrollInfo([In] HWND hwnd, [In] ScrollBarConstants nBar, [In][Out] ref SCROLLINFO lpsi);

        /// <summary>
        /// <para>
        /// The <see cref="GetScrollPos"/> function retrieves the current position of the scroll box (thumb) in the specified scroll bar.
        /// The current position is a relative value that depends on the current scrolling range.
        /// For example, if the scrolling range is 0 through 100 and the scroll box is in the middle of the bar, the current position is 50.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getscrollpos"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// Handle to a scroll bar control or a window with a standard scroll bar, depending on the value of the nBar parameter.
        /// </param>
        /// <param name="nBar">
        /// Specifies the scroll bar to be examined. This parameter can be one of the following values.
        /// <see cref="SB_CTL"/>:
        /// Retrieves the position of the scroll box in a scroll bar control.
        /// The <paramref name="hWnd"/> parameter must be the handle to the scroll bar control.
        /// <see cref="SB_HORZ"/>:
        /// Retrieves the position of the scroll box in a window's standard horizontal scroll bar.
        /// <see cref="SB_VERT"/>:
        /// Retrieves the position of the scroll box in a window's standard vertical scroll bar.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the current position of the scroll box.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The GetScrollPos function enables applications to use 32-bit scroll positions.
        /// Although the messages that indicate scroll bar position, <see cref="WM_HSCROLL"/> and <see cref="WM_VSCROLL"/>,
        /// are limited to 16 bits of position data, the functions <see cref="SetScrollPos"/>, <see cref="SetScrollRange"/>,
        /// <see cref="GetScrollPos"/>, and <see cref="GetScrollRange"/> support 32-bit scroll bar position data.
        /// Thus, an application can call <see cref="GetScrollPos"/> while processing either the <see cref="WM_HSCROLL"/> or <see cref="WM_VSCROLL"/> messages
        /// to obtain 32-bit scroll bar position data.
        /// To get the 32-bit position of the scroll box (thumb) during a <see cref="SB_THUMBTRACK"/> request code
        /// in a <see cref="WM_HSCROLL"/> or <see cref="WM_VSCROLL"/> message, use the <see cref="GetScrollInfo"/> function.
        /// If the <paramref name="nBar"/> parameter is <see cref="SB_CTL"/> and the window specified
        /// by the <paramref name="hWnd"/> parameter is not a system scroll bar control,
        /// the system sends the <see cref="SBM_GETPOS"/> message to the window to obtain scroll bar information.
        /// This allows <see cref="GetScrollPos"/> to operate on a custom control that mimics a scroll bar.
        /// If the window does not handle the <see cref="SBM_GETPOS"/> message, the <see cref="GetScrollPos"/> function fails.
        /// </remarks>
        [Obsolete("The GetScrollPos function is provided for backward compatibility. New applications should use the GetScrollInfo function.")]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetScrollPos", ExactSpelling = true, SetLastError = true)]
        public static extern int GetScrollPos([In] HWND hWnd, [In] ScrollBarConstants nBar);

        /// <summary>
        /// <para>
        /// The <see cref="GetScrollRange"/> function retrieves the current minimum and maximum scroll box (thumb) positions for the specified scroll bar.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getscrollrange"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// Handle to a scroll bar control or a window with a standard scroll bar, depending on the value of the <paramref name="nBar"/> parameter.
        /// </param>
        /// <param name="nBar">
        /// Specifies the scroll bar from which the positions are retrieved. This parameter can be one of the following values.
        /// <see cref="SB_CTL"/>:
        /// Retrieves the positions of a scroll bar control.
        /// The <paramref name="hWnd"/> parameter must be the handle to the scroll bar control.
        /// <see cref="SB_HORZ"/>:
        /// Retrieves the positions of the window's standard horizontal scroll bar.
        /// <see cref="SB_VERT"/>:
        /// Retrieves the positions of the window's standard vertical scroll bar.
        /// </param>
        /// <param name="lpMinPos">
        /// Pointer to the integer variable that receives the minimum position.
        /// </param>
        /// <param name="lpMaxPos">
        /// Pointer to the integer variable that receives the maximum position.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the specified window does not have standard scroll bars or is not a scroll bar control,
        /// the <see cref="GetScrollRange"/> function copies zero to the <paramref name="lpMinPos"/> and <paramref name="lpMaxPos"/> parameters.
        /// The default range for a standard scroll bar is 0 through 100. The default range for a scroll bar control is empty (both values are zero).
        /// The messages that indicate scroll bar position, <see cref="WM_HSCROLL"/> and <see cref="WM_VSCROLL"/>, are limited to 16 bits of position data.
        /// However, because <see cref="SetScrollInfo"/>, <see cref="SetScrollPos"/>, <see cref="SetScrollRange"/>, <see cref="GetScrollInfo"/>,
        /// <see cref="GetScrollPos"/>, and <see cref="GetScrollRange"/> support 32-bit scroll bar position data,
        /// there is a way to circumvent the 16-bit barrier of the <see cref="WM_HSCROLL"/> and <see cref="WM_VSCROLL"/> messages.
        /// See the <see cref="GetScrollInfo"/> function for a description of the technique.
        /// If the <paramref name="nBar"/> parameter is <see cref="SB_CTL"/> and the window specified by the <paramref name="hWnd"/> parameter
        /// is not a system scroll bar control, the system sends the <see cref="SBM_GETRANGE"/> message to the window to obtain scroll bar information.
        /// This allows <see cref="GetScrollRange"/> to operate on a custom control that mimics a scroll bar.
        /// If the window does not handle the <see cref="SBM_GETRANGE"/> message, the <see cref="GetScrollRange"/> function fails.
        /// </remarks>
        [Obsolete("The GetScrollRange function is provided for compatibility only. New applications should use the GetScrollInfo function.")]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetScrollRange", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetScrollRange([In] HWND hWnd, [In] ScrollBarConstants nBar, [Out] out INT lpMinPos, [Out] out INT lpMaxPos);

        /// <summary>
        /// <para>
        /// The <see cref="IsDlgButtonChecked"/> function determines whether a button control is checked
        /// or whether a three-state button control is checked, unchecked, or indeterminate.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-isdlgbuttonchecked"/>
        /// </para>
        /// </summary>
        /// <param name="hDlg">
        /// A handle to the dialog box that contains the button control.
        /// </param>
        /// <param name="nIDButton">
        /// The identifier of the button control.
        /// </param>
        /// <returns>
        /// The return value from a button created with the <see cref="BS_AUTOCHECKBOX"/>, <see cref="BS_AUTORADIOBUTTON"/>, <see cref="BS_AUTO3STATE"/>,
        /// <see cref="BS_CHECKBOX"/>, <see cref="BS_RADIOBUTTON"/>, or <see cref="BS_3STATE"/> styles can be one of the values in the following table.
        /// If the button has any other style, the return value is zero.
        /// <see cref="BST_CHECKED"/>:
        /// The button is checked.
        /// <see cref="BST_INDETERMINATE"/>:
        /// The button is in an indeterminate state (applies only if the button has the <see cref="BS_3STATE"/> or <see cref="BS_AUTO3STATE"/> style).
        /// <see cref="BST_UNCHECKED"/>:
        /// The button is not checked.
        /// </returns>
        /// <remarks>
        /// The <see cref="IsDlgButtonChecked"/> function sends a <see cref="BM_GETCHECK"/> message to the specified button control.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsDlgButtonChecked", ExactSpelling = true, SetLastError = true)]
        public static extern UINT IsDlgButtonChecked([In] HWND hDlg, [In] int nIDButton);

        /// <summary>
        /// <para>
        /// The <see cref="ScrollDC"/> function scrolls a rectangle of bits horizontally and vertically.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-scrolldc"/>
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
        public static extern BOOL ScrollDC([In] HDC hDC, [In] int dx, [In] int dy, [In] in RECT lprcScroll, [In] in RECT lprcClip,
            [In] HRGN hrgnUpdate, [Out] out RECT lprcUpdate);

        /// <summary>
        /// <para>
        /// The <see cref="ScrollWindow"/> function scrolls the contents of the specified window's client area.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-scrollwindow"/>
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
        public static extern BOOL ScrollWindow([In] HWND hWnd, [In] int XAmount, [In] int YAmount, [In] in RECT lpRect, [In] in RECT lpClipRect);

        /// <summary>
        /// <para>
        /// The <see cref="ScrollWindowEx"/> function scrolls the contents of the specified window's client area.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-scrollwindowex"/>
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
        public static extern RegionFlags ScrollWindowEx([In] HWND hWnd, [In] int dx, [In] int dy, [In] in RECT prcScroll, [In] in RECT prcClip,
            [In] HRGN hrgnUpdate, [Out] out RECT prcUpdate, [In] ScrollWindowExFlags flags);

        /// <summary>
        /// <para>
        /// The <see cref="SetScrollInfo"/> function sets the parameters of a scroll bar,
        /// including the minimum and maximum scrolling positions, the page size, and the position of the scroll box (thumb).
        /// The function also redraws the scroll bar, if requested.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setscrollinfo"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// Handle to a scroll bar control or a window with a standard scroll bar, depending on the value of the fnBar parameter.
        /// </param>
        /// <param name="nBar">
        /// Specifies the type of scroll bar for which to set parameters. This parameter can be one of the following values.
        /// <see cref="SB_CTL"/>:
        /// Sets the parameters of a scroll bar control. The <paramref name="hwnd"/> parameter must be the handle to the scroll bar control.
        /// <see cref="SB_HORZ"/>:
        /// Sets the parameters of the window's standard horizontal scroll bar.
        /// <see cref="SB_VERT"/>:
        /// Sets the parameters of the window's standard vertical scroll bar.
        /// </param>
        /// <param name="lpsi">
        /// Pointer to a <see cref="SCROLLINFO"/> structure.
        /// Before calling <see cref="SetScrollInfo"/>, set the <see cref="SCROLLINFO.cbSize"/> member of the structure to <code>sizeof(SCROLLINFO)</code>,
        /// set the <see cref="SCROLLINFO.fMask"/> member to indicate the parameters to set, and specify the new parameter values in the appropriate members.
        /// The <see cref="SCROLLINFO.fMask"/> member can be one or more of the following values.
        /// <see cref="SIF_DISABLENOSCROLL"/>:
        /// Disables the scroll bar instead of removing it, if the scroll bar's new parameters make the scroll bar unnecessary.
        /// <see cref="SIF_PAGE"/>:
        /// Sets the scroll page to the value specified in the <see cref="SCROLLINFO.nPage"/> member
        /// of the <see cref="SCROLLINFO"/> structure pointed to by <paramref name="lpsi"/>.
        /// <see cref="SIF_POS"/>:
        /// Sets the scroll position to the value specified in the <see cref="SCROLLINFO.nPos"/> member
        /// of the <see cref="SCROLLINFO"/> structure pointed to by <paramref name="lpsi"/>.
        /// <see cref="SIF_RANGE"/>:
        /// Sets the scroll range to the value specified in the <see cref="SCROLLINFO.nMin"/> and <see cref="SCROLLINFO.nMax"/> members
        /// of the <see cref="SCROLLINFO"/> structure pointed to by <paramref name="lpsi"/>.
        /// </param>
        /// <param name="redraw">
        /// Specifies whether the scroll bar is redrawn to reflect the changes to the scroll bar.
        /// If this parameter is <see cref="TRUE"/>, the scroll bar is redrawn, otherwise, it is not redrawn.
        /// </param>
        /// <returns>
        /// The return value is the current position of the scroll box.
        /// </returns>
        /// <remarks>
        /// The <see cref="SetScrollInfo"/> function performs range checking on the values specified
        /// by the <see cref="SCROLLINFO.nPage"/> and <see cref="SCROLLINFO.nPos"/> members of the <see cref="SCROLLINFO"/> structure.
        /// The <see cref="SCROLLINFO.nPage"/> member must specify a value from 0 to <see cref="SCROLLINFO.nMax"/> - <see cref="SCROLLINFO.nMin"/> +1.
        /// The <see cref="SCROLLINFO.nPos"/> member must specify a value between <see cref="SCROLLINFO.nMin"/>
        /// and <see cref="SCROLLINFO.nMax"/> - max( <see cref="SCROLLINFO.nPage"/>– 1, 0).
        /// If either value is beyond its range, the function sets it to a value that is just within the range.
        /// If the <paramref name="nBar"/> parameter is <see cref="SB_CTL"/> and the window specified
        /// by the <paramref name="hwnd"/> parameter is not a system scroll bar control,
        /// the system sends the <see cref="SBM_SETSCROLLINFO"/> message to the window to set scroll bar information
        /// (The system can optimize the message to <see cref="SBM_SETPOS"/> or <see cref="SBM_SETRANGE"/> if the request is solely for the position or range).
        /// This allows <see cref="SetScrollInfo"/> to operate on a custom control that mimics a scroll bar.
        /// If the window does not handle <see cref="SBM_SETSCROLLINFO"/> (or the optimized <see cref="SBM_SETPOS"/> message
        /// or <see cref="SBM_SETRANGE"/> message), then the <see cref="SetScrollInfo"/> function fails.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ScrollWindowEx", ExactSpelling = true, SetLastError = true)]
        public static extern int SetScrollInfo([In] HWND hwnd, [In] ScrollBarConstants nBar, [In] in SCROLLINFO lpsi, [In] BOOL redraw);

        /// <summary>
        /// <para>
        /// The SetScrollPos function sets the position of the scroll box (thumb) in the specified scroll bar and,
        /// if requested, redraws the scroll bar to reflect the new position of the scroll box.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setscrollpos"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// Handle to a scroll bar control or a window with a standard scroll bar, depending on the value of the nBar parameter.
        /// </param>
        /// <param name="nBar">
        /// Specifies the scroll bar to be set. This parameter can be one of the following values.
        /// <see cref="SB_CTL"/>:
        /// Sets the position of the scroll box in a scroll bar control.
        /// The <paramref name="hWnd"/> parameter must be the handle to the scroll bar control.
        /// <see cref="SB_HORZ"/>:
        /// Sets the position of the scroll box in a window's standard horizontal scroll bar.
        /// <see cref="SB_VERT"/>:
        /// Sets the position of the scroll box in a window's standard vertical scroll bar.
        /// </param>
        /// <param name="nPos">
        /// Specifies the new position of the scroll box.
        /// The position must be within the scrolling range.
        /// For more information about the scrolling range, see the <see cref="SetScrollRange"/> function.
        /// </param>
        /// <param name="bRedraw">
        /// Specifies whether the scroll bar is redrawn to reflect the new scroll box position.
        /// If this parameter is <see cref="TRUE"/>, the scroll bar is redrawn.
        /// If it is <see cref="FALSE"/>, the scroll bar is not redrawn.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the previous position of the scroll box.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the scroll bar is redrawn by a subsequent call to another function,
        /// setting the <paramref name="bRedraw"/> parameter to <see cref="FALSE"/> is useful.
        /// Because the messages that indicate scroll bar position, <see cref="WM_HSCROLL"/> and <see cref="WM_VSCROLL"/>,
        /// are limited to 16 bits of position data, applications that rely solely on those messages
        /// for position data have a practical maximum value of 65,535 for the <see cref="SetScrollPos"/> function's <paramref name="nPos"/> parameter.
        /// However, because the <see cref="SetScrollInfo"/>, <see cref="SetScrollPos"/>, <see cref="SetScrollRange"/>,
        /// <see cref="GetScrollInfo"/>, <see cref="GetScrollPos"/>, and <see cref="GetScrollRange"/> functions support 32-bit scroll bar position data,
        /// there is a way to circumvent the 16-bit barrier of the <see cref="WM_HSCROLL"/> and <see cref="WM_VSCROLL"/> messages.
        /// See GetScrollInfo for a description of the technique.
        /// If the <paramref name="nBar"/> parameter is <see cref="SB_CTL"/> and the window specified
        /// by the <paramref name="hWnd"/> parameter is not a system scroll bar control,
        /// the system sends the <see cref="SBM_SETPOS"/> message to the window to set scroll bar information.
        /// This allows <see cref="SetScrollPos"/> to operate on a custom control that mimics a scroll bar.
        /// If the window does not handle the <see cref="SBM_SETPOS"/> message, the <see cref="SetScrollPos"/> function fails.
        /// </remarks>
        [Obsolete("The SetScrollPos function is provided for backward compatibility. New applications should use the SetScrollInfo function.")]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetScrollPos", ExactSpelling = true, SetLastError = true)]
        public static extern int SetScrollPos([In] HWND hWnd, [In] int nBar, [In] int nPos, [In] BOOL bRedraw);

        /// <summary>
        /// <para>
        /// The <see cref="SetScrollRange"/> function sets the minimum and maximum scroll box positions for the specified scroll bar.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setscrollrange"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// Handle to a scroll bar control or a window with a standard scroll bar, depending on the value of the <paramref name="nBar"/> parameter.
        /// </param>
        /// <param name="nBar">
        /// Specifies the scroll bar to be set. This parameter can be one of the following values.
        /// <see cref="SB_CTL"/>:
        /// Sets the range of a scroll bar control. The <paramref name="hWnd"/> parameter must be the handle to the scroll bar control.
        /// <see cref="SB_HORZ"/>:
        /// Sets the range of a window's standard horizontal scroll bar.
        /// <see cref="SB_VERT"/>:
        /// Sets the range of a window's standard vertical scroll bar.
        /// </param>
        /// <param name="nMinPos">
        /// Specifies the minimum scrolling position.
        /// </param>
        /// <param name="nMaxPos">
        /// Specifies the maximum scrolling position.
        /// </param>
        /// <param name="bRedraw">
        /// Specifies whether the scroll bar should be redrawn to reflect the change.
        /// If this parameter is <see cref="TRUE"/>, the scroll bar is redrawn.
        /// If it is <see cref="FALSE"/>, the scroll bar is not redrawn.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// You can use <see cref="SetScrollRange"/> to hide the scroll bar by setting <paramref name="nMinPos"/>
        /// and <paramref name="nMaxPos"/> to the same value.
        /// An application should not call the <see cref="SetScrollRange"/> function to hide a scroll bar while processing a scroll bar message.
        /// New applications should use the <see cref="ShowScrollBar"/> function to hide the scroll bar.
        /// If the call to <see cref="SetScrollRange"/> immediately follows a call to the <see cref="SetScrollPos"/> function,
        /// the <paramref name="bRedraw"/> parameter in <see cref="SetScrollPos"/> must be zero to prevent the scroll bar from being drawn twice.
        /// The default range for a standard scroll bar is 0 through 100.
        /// The default range for a scroll bar control is empty (both the <paramref name="nMinPos"/> and <paramref name="nMaxPos"/> parameter values are zero).
        /// The difference between the values specified by the <paramref name="nMinPos"/> and <paramref name="nMaxPos"/> parameters
        /// must not be greater than the value of <see cref="MAXLONG"/>.
        /// Because the messages that indicate scroll bar position, <see cref="WM_HSCROLL"/> and <see cref="WM_VSCROLL"/>,
        /// are limited to 16 bits of position data, applications that rely solely on those messages for position data
        /// have a practical maximum value of 65,535 for the <see cref="SetScrollRange"/> function's <paramref name="nMaxPos"/> parameter.
        /// However, because the <see cref="SetScrollInfo"/>, <see cref="SetScrollPos"/>, <see cref="SetScrollRange"/>, <see cref="GetScrollInfo"/>,
        /// <see cref="GetScrollPos"/>, and <see cref="GetScrollRange"/> functions support 32-bit scroll bar position data,
        /// there is a way to circumvent the 16-bit barrier of the <see cref="WM_HSCROLL"/> and <see cref="WM_VSCROLL"/> messages.
        /// See <see cref="GetScrollInfo"/> for a description of the technique.
        /// If the <paramref name="nBar"/> parameter is <see cref="SB_CTL"/> and the window specified
        /// by the <paramref name="hWnd"/> parameter is not a system scroll bar control,
        /// the system sends the <see cref="SBM_SETRANGE"/> message to the window to set scroll bar information.
        /// This allows <see cref="SetScrollRange"/> to operate on a custom control that mimics a scroll bar.
        /// If the window does not handle the <see cref="SBM_SETRANGE"/> message, the <see cref="SetScrollRange"/> function fails.
        /// </remarks>
        [Obsolete("The SetScrollRange function is provided for backward compatibility. New applications should use the SetScrollInfo function.")]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetScrollRange", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetScrollRange([In] HWND hWnd, [In] int nBar, [In] int nMinPos, [In] int nMaxPos, [In] BOOL bRedraw);

        /// <summary>
        /// <para>
        /// The <see cref="ShowScrollBar"/> function shows or hides the specified scroll bar.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-showscrollbar"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// Handle to a scroll bar control or a window with a standard scroll bar, depending on the value of the <paramref name="wBar"/> parameter.
        /// </param>
        /// <param name="wBar">
        /// Specifies the scroll bar(s) to be shown or hidden. This parameter can be one of the following values.
        /// <see cref="SB_BOTH"/>:
        /// Shows or hides a window's standard horizontal and vertical scroll bars.
        /// <see cref="SB_CTL"/>:
        /// Shows or hides a scroll bar control.
        /// The <paramref name="hWnd"/> parameter must be the handle to the scroll bar control.
        /// <see cref="SB_HORZ"/>:
        /// Shows or hides a window's standard horizontal scroll bars.
        /// <see cref="SB_VERT"/>:
        /// Shows or hides a window's standard vertical scroll bar.
        /// </param>
        /// <param name="bShow">
        /// Specifies whether the scroll bar is shown or hidden.
        /// If this parameter is <see cref="TRUE"/>, the scroll bar is shown; otherwise, it is hidden.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// You should not call this function to hide a scroll bar while processing a scroll bar message.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShowScrollBar", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ShowScrollBar([In] HWND hWnd, [In] int wBar, [In] BOOL bShow);
    }
}
