using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Button Control Messages
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/controls/bumper-button-control-reference-messages
    /// </para>
    /// </summary>
    public enum ButtonControlMessages
    {
        /// <summary>
        /// BCM_FIRST
        /// </summary>
        BCM_FIRST = 0x1600,

        /// <summary>
        /// Gets the size of the button that best fits its text and image, if an image list is present.
        /// You can send this message explicitly or use the <see cref="Button_GetIdealSize"/> macro.
        /// </summary>
        BCM_GETIDEALSIZE = BCM_FIRST + 0x0001,

        /// <summary>
        /// Gets the <see cref="BUTTON_IMAGELIST"/> structure that describes the image list assigned to a button control.
        /// You can send this message explicitly or use the <see cref="Button_GetImageList"/> macro.
        /// </summary>
        BCM_GETIMAGELIST = BCM_FIRST + 0x0003,

        /// <summary>
        /// Gets the text of the note associated with a command link button.
        /// You can send this message explicitly or use the <see cref="Button_GetNote"/> macro.
        /// </summary>
        BCM_GETNOTE = BCM_FIRST + 0x000A,

        /// <summary>
        /// Gets the length of the note text that may be displayed in the description for a command link button.
        /// Send this message explicitly or by using the <see cref="Button_GetNoteLength"/> macro.
        /// </summary>
        BCM_GETNOTELENGTH = BCM_FIRST + 0x000B,

        /// <summary>
        /// Gets information for a split button control.
        /// Send this message explicitly or by using the <see cref="Button_GetSplitInfo"/> macro.
        /// </summary>
        BCM_GETSPLITINFO = BCM_FIRST + 0x0008,

        /// <summary>
        /// Gets the margins used to draw text in a button control.
        /// You can send this message explicitly or use the <see cref="Button_GetTextMargin"/> macro.
        /// </summary>
        BCM_GETTEXTMARGIN = BCM_FIRST + 0x0005,

        /// <summary>
        /// Sets the drop down state for a button with style <see cref="TBSTYLE_DROPDOWN"/>.
        /// Send this message explicitly or by using the <see cref="Button_SetDropDownState"/> macro.
        /// </summary>
        BCM_SETDROPDOWNSTATE = BCM_FIRST + 0x0006,

        /// <summary>
        /// Assigns an image list to a button control.
        /// You can send this message explicitly or use the <see cref="Button_SetImageList"/> macro.
        /// </summary>
        BCM_SETIMAGELIST = BCM_FIRST + 0x0002,

        /// <summary>
        /// Sets the text of the note associated with a command link button.
        /// You can send this message explicitly or use the <see cref="Button_SetNote"/> macro.
        /// </summary>
        BCM_SETNOTE = BCM_FIRST + 0x0009,

        /// <summary>
        /// Sets the elevation required state for a specified button or command link to display an elevated icon.
        /// Send this message explicitly or by using the <see cref="Button_SetElevationRequiredState"/> macro.
        /// </summary>
        BCM_SETSHIELD = BCM_FIRST + 0x000C,

        /// <summary>
        /// Sets information for a split button control.
        /// Send this message explicitly or by using the <see cref="Button_SetSplitInfo"/> macro.
        /// </summary>
        BCM_SETSPLITINFO = BCM_FIRST + 0x0007,

        /// <summary>
        /// The <see cref="BCM_SETTEXTMARGIN"/> message sets the margins for drawing text in a button control.
        /// </summary>
        BCM_SETTEXTMARGIN = BCM_FIRST + 0x0004,

        /// <summary>
        /// Simulates the user clicking a button.
        /// This message causes the button to receive the <see cref="WindowsMessages.WM_LBUTTONDOWN"/>
        /// and <see cref="WindowsMessages.WM_LBUTTONUP"/> messages,
        /// and the button's parent window to receive a <see cref="ButtonControlNotifications.BN_CLICKED"/> notification code.
        /// </summary>
        BM_CLICK = 0x00F5,

        /// <summary>
        /// Gets the check state of a radio button or check box.
        /// You can send this message explicitly or use the <see cref="Button_GetCheck"/> macro.
        /// </summary>
        BM_GETCHECK = 0x00F0,

        /// <summary>
        /// Retrieves a handle to the image (icon or bitmap) associated with the button.
        /// </summary>
        BM_GETIMAGE = 0x00F6,

        /// <summary>
        /// Retrieves the state of a button or check box.
        /// You can send this message explicitly or use the <see cref="Button_GetState"/> macro.
        /// </summary>
        BM_GETSTATE = 0x00F2,

        /// <summary>
        /// Sets the check state of a radio button or check box.
        /// You can send this message explicitly or by using the <see cref="Button_SetCheck"/> macro.
        /// </summary>
        BM_SETCHECK = 0x00F1,

        /// <summary>
        /// Sets a flag on a radio button that controls the generation of <see cref="ButtonControlNotifications.BN_CLICKED"/> messages when the button receives focus.
        /// </summary>
        BM_SETDONTCLICK = 0x00F8,

        /// <summary>
        /// Associates a new image (icon or bitmap) with the button.
        /// </summary>
        BM_SETIMAGE = 0x00F7,

        /// <summary>
        /// Sets the highlight state of a button.
        /// The highlight state indicates whether the button is highlighted as if the user had pushed it.
        /// You can send this message explicitly or use the <see cref="Button_SetState"/> macro.
        /// </summary>
        BM_SETSTATE = 0x00F3,

        /// <summary>
        /// Sets the style of a button.
        /// You can send this message explicitly or use the Button_SetStyle macro.
        /// </summary>
        BM_SETSTYLE = 0x00F4,
    }
}
