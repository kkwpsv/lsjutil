using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Extensions;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using System.Text;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Macros
{
    /// <summary>
    /// <para>
    /// Button Control Macros
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/controls/bumper-button-control-reference-macros
    /// </para>
    /// </summary>
    public static class ButtonControlMacros
    {
        /// <summary>
        /// Enables or disables a button.
        /// </summary>
        /// <param name="hwndCtl">A handle to the button control.</param>
        /// <param name="fEnable"><see langword="true"/> to enable the button, or <see langword="false"/> to disable it.</param>
        /// <returns></returns>
        public static bool Button_Enable(IntPtr hwndCtl, bool fEnable) => EnableWindow(hwndCtl, fEnable);

        /// <summary>
        /// Gets the check state of a radio button or check box.
        /// You can use this macro or send the <see cref="ButtonControlMessages.BM_GETCHECK"/> message explicitly.
        /// </summary>
        /// <param name="hwndCtl"></param>
        /// <returns></returns>
        /// <remarks>If the button has a style other than those listed, the return value is zero.</remarks>
        public static ButtonStates Button_GetCheck(IntPtr hwndCtl) =>
            (ButtonStates)SendMessage(hwndCtl, (WindowsMessages)ButtonControlMessages.BM_GETCHECK, UIntPtr.Zero, IntPtr.Zero).SafeToInt32();

        /// <summary>
        /// Gets the size of the button that best fits the text and image, if an image list is present.
        /// You can use this macro or send the <see cref="ButtonControlMessages.BCM_GETIDEALSIZE"/> message explicitly.
        /// </summary>
        /// <param name="hwnd">A handle to the button control.</param>
        /// <param name="psize">
        /// A pointer to a SIZE structure that receives the desired size of the button including the text and image list if present.
        /// </param>
        /// <returns>
        /// This macro is most applicable to PushButtons.
        /// When sent to a PushButton, the macro retrieves the bounding rectangle required to display the button's text.
        /// And, if the PushButton has an image list, the bounding rectangle is also sized to include the button's image.
        /// When sent to a button of any other type, the size of the control's window rectangle is retrieved.
        /// To use this macro, you must provide a manifest specifying Comclt32.dll version 6.0.
        /// For more information on manifests, see Enabling Visual Styles.
        /// </returns>
        public static bool Button_GetIdealSize(IntPtr hwnd, out SIZE psize)
        {
            psize = new SIZE();
            var lparam = Marshal.AllocHGlobal(MarshalExtensions.SizeOf<SIZE>());
            var result = SendMessage(hwnd, (WindowsMessages)ButtonControlMessages.BCM_GETIDEALSIZE, UIntPtr.Zero, lparam);
            Marshal.PtrToStructure(lparam, psize);
            Marshal.FreeHGlobal(lparam);
            return result != IntPtr.Zero;
        }

        /// <summary>
        /// Gets the <see cref="BUTTON_IMAGELIST"/> structure that describes the image list that is set for a button control.
        /// You can use this macro or send the <see cref="ButtonControlMessages.BCM_GETIMAGELIST"/> message explicitly.
        /// </summary>
        /// <param name="hwnd">A handle to the button control.</param>
        /// <param name="pbuttonImagelist">A pointer to a <see cref="BUTTON_IMAGELIST"/> structure that contains image list information.</param>
        /// <returns></returns>
        /// <remarks>
        /// To use this macro, you must provide a manifest specifying Comclt32.dll version 6.0.
        /// For more information on manifests, see Enabling Visual Styles.
        /// </remarks>
        public static bool Button_GetImageList(IntPtr hwnd, out BUTTON_IMAGELIST pbuttonImagelist)
        {
            pbuttonImagelist = new BUTTON_IMAGELIST();
            var lparam = Marshal.AllocHGlobal(MarshalExtensions.SizeOf<BUTTON_IMAGELIST>());
            var result = SendMessage(hwnd, (WindowsMessages)ButtonControlMessages.BCM_GETIMAGELIST, UIntPtr.Zero, lparam);
            Marshal.PtrToStructure(lparam, pbuttonImagelist);
            Marshal.FreeHGlobal(lparam);
            return result != IntPtr.Zero;
        }

        /// <summary>
        /// Gets the text of the note associated with a command link button.
        /// You can use this macro or send the <see cref="ButtonControlMessages.BCM_GETNOTE"/> message explicitly.
        /// </summary>
        /// <param name="hwnd">A handle to the button control.</param>
        /// <param name="psz">A pointer to a null-terminated, Unicode string that contains the note.</param>
        /// <param name="pcc">A pointer to the length of the note, in characters.</param>
        /// <remarks>
        /// This macro works only with the <see cref="ButtonStyles.BS_COMMANDLINK"/> and <see cref="ButtonStyles.BS_DEFCOMMANDLINK"/> button styles.
        /// </remarks>
        /// <returns></returns>
        public static bool Button_GetNote(IntPtr hwnd, out string psz, int pcc)
        {
            var lparam = Marshal.AllocHGlobal(pcc * 2);
            var result = SendMessage(hwnd, (WindowsMessages)ButtonControlMessages.BCM_GETNOTE, (UIntPtr)pcc, lparam);
            psz = Marshal.PtrToStringUni(lparam);
            Marshal.FreeHGlobal(lparam);
            return result != IntPtr.Zero;
        }

        /// <summary>
        /// Gets the length of the note text that may be displayed in the description for a command link.
        /// Use this macro or send the BCM_GETNOTELENGTH message explicitly.
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        /// <remarks>
        /// Beginning with comctl32 DLL version 6.01, command link buttons may have a note.
        /// For information on DLL versions, see Common Control Versions.
        /// The <see cref="Button_GetNoteLength"/> macro works only with the <see cref="ButtonStyles.BS_COMMANDLINK"/>
        /// and <see cref="ButtonStyles.BS_DEFCOMMANDLINK"/> button styles.
        /// </remarks>
        public static IntPtr Button_GetNoteLength(IntPtr hwnd) =>
            SendMessage(hwnd, (WindowsMessages)ButtonControlMessages.BCM_GETNOTELENGTH, UIntPtr.Zero, IntPtr.Zero);

        /// <summary>
        /// Gets information for a specified split button control.
        /// Use this macro or send the <see cref="ButtonControlMessages.BCM_GETSPLITINFO"/> message explicitly.
        /// </summary>
        /// <param name="hwnd">A handle to the button control.</param>
        /// <param name="pInfo">
        /// A pointer to a <see cref="BUTTON_SPLITINFO"/> structure to receive information on the button specified by hwnd.
        /// The calling application is responsible for allocating the memory for the structure.
        /// Set the mask member of this structure to determine what information to receive.
        /// </param>
        /// <returns>
        /// Use this macro only with the <see cref="ButtonStyles.BS_SPLITBUTTON"/> and <see cref="ButtonStyles.BS_DEFSPLITBUTTON"/> button styles.
        /// </returns>
        public static bool Button_GetSplitInfo(IntPtr hwnd, out BUTTON_SPLITINFO pInfo)
        {
            pInfo = new BUTTON_SPLITINFO();
            var lparam = Marshal.AllocHGlobal(MarshalExtensions.SizeOf<BUTTON_SPLITINFO>());
            var result = SendMessage(hwnd, (WindowsMessages)ButtonControlMessages.BCM_GETSPLITINFO, UIntPtr.Zero, lparam);
            Marshal.PtrToStructure(lparam, pInfo);
            Marshal.FreeHGlobal(lparam);
            return result != IntPtr.Zero;
        }

        /// <summary>
        /// Retrieves the state of a button or check box.
        /// You can use this macro or send the <see cref="ButtonControlMessages.BM_GETSTATE"/> message explicitly.
        /// </summary>
        /// <param name="hwndCtl">A handle to the button control.</param>
        /// <returns></returns>
        public static int Button_GetState(IntPtr hwndCtl) =>
            SendMessage(hwndCtl, (WindowsMessages)ButtonControlMessages.BM_GETSTATE, UIntPtr.Zero, IntPtr.Zero).SafeToInt32();


        /// <summary>
        /// Gets the text of a button.
        /// </summary>
        /// <param name="hwndCtl">A handle to the button control.</param>
        /// <param name="lpch">Pointer to the buffer that will receive the text.</param>
        /// <param name="cchMax">The maximum number of characters to copy to the buffer, including the NULL terminator.</param>
        /// <returns></returns>
        /// <remarks>
        /// The macro expands to a call to <see cref="GetWindowText"/>.
        /// </remarks>
        public static int Button_GetText(IntPtr hwndCtl, StringBuilder lpch, int cchMax) => GetWindowText(hwndCtl, lpch, cchMax);

        /// <summary>
        /// Gets the margins used to draw text in a button control.
        /// You can use this macro or send the <see cref="ButtonControlMessages.BCM_GETTEXTMARGIN"/> message explicitly.
        /// </summary>
        /// <param name="hwnd">A handle to the button control.</param>
        /// <param name="pInfo">
        /// A pointer to a <see cref="RECT"/> structure that specifies the margins to use for drawing text in a button control.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// Note  To use this macro, you must provide a manifest specifying Comclt32.dll version 6.0.
        /// For more information on manifests, see Enabling Visual Styles.
        /// </remarks>
        public static bool Button_GetTextMargin(IntPtr hwnd, out SIZE pInfo)
        {
            pInfo = new SIZE();
            var lparam = Marshal.AllocHGlobal(MarshalExtensions.SizeOf<SIZE>());
            var result = SendMessage(hwnd, (WindowsMessages)ButtonControlMessages.BCM_GETTEXTMARGIN, UIntPtr.Zero, lparam);
            Marshal.PtrToStructure(lparam, pInfo);
            Marshal.FreeHGlobal(lparam);
            return result != IntPtr.Zero;
        }

        /// <summary>
        /// Sets the check state of a radio button or check box.
        /// You can use this macro or send the <see cref="ButtonControlMessages.BM_SETCHECK"/> message explicitly.
        /// </summary>
        /// <param name="hwndCtl"> A handle to the button control.</param>
        /// <param name="check">
        /// The check state. This parameter can be one of the following values.
        /// <see cref="ButtonStates.BST_CHECKED"/>, <see cref="ButtonStates.BST_INDETERMINATE"/> and <see cref="ButtonStates.BST_UNCHECKED"/>.
        /// </param>
        public static void Button_SetCheck(IntPtr hwndCtl, ButtonStates check) =>
            SendMessage(hwndCtl, (WindowsMessages)ButtonControlMessages.BM_SETCHECK, (UIntPtr)check, IntPtr.Zero);

        /// <summary>
        /// Sets the drop down state for a specified button with style of <see cref="ButtonStyles.BS_SPLITBUTTON"/>.
        /// Use this macro or send the <see cref="ButtonControlMessages.BCM_SETDROPDOWNSTATE"/> message explicitly.
        /// </summary>
        /// <param name="hwnd">A handle to the button control.</param>
        /// <param name="fDropDown">
        /// <see langword="true"/> for state of <see cref="ButtonStates.BST_DROPDOWNPUSHED"/>, or <see langword="false"/> otherwise.
        /// </param>
        /// <returns></returns>
        public static bool Button_SetDropDownState(IntPtr hwnd, bool fDropDown) =>
            SendMessage(hwnd, (WindowsMessages)ButtonControlMessages.BCM_SETDROPDOWNSTATE, (UIntPtr)(fDropDown ? 1 : 0), IntPtr.Zero) != IntPtr.Zero;

        /// <summary>
        /// Sets the elevation required state for a specified button or command link to display an elevated icon.
        /// Use this macro or send the <see cref="ButtonControlMessages.BCM_SETSHIELD"/> message explicitly.
        /// </summary>
        /// <param name="hwnd">A handle to the button control.</param>
        /// <param name="fRequired">
        /// <see langword="true"/> to draw an elevated icon, or <see langword="false"/> otherwise.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// An application must use comctl32.dll version 6 to gain this functionality.
        /// </remarks>
        public static IntPtr Button_SetElevationRequiredState(IntPtr hwnd, bool fRequired) =>
            SendMessage((hwnd), (WindowsMessages)ButtonControlMessages.BCM_SETSHIELD, UIntPtr.Zero, (IntPtr)(fRequired ? 1 : 0));

        /// <summary>
        /// Assigns an image list to a button control.
        /// You can use this macro or send the <see cref="ButtonControlMessages.BCM_SETIMAGELIST"/> message explicitly.
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the button control.
        /// </param>
        /// <param name="pbuttonImagelist">
        /// A pointer to a <see cref="BUTTON_IMAGELIST"/> structure that contains the image list information to set.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// To use this macro, you must provide a manifest specifying Comclt32.dll version 6.0.
        /// For more information on manifests, see Enabling Visual Styles.
        /// </remarks>
        public static bool Button_SetImageList(IntPtr hwnd, BUTTON_IMAGELIST pbuttonImagelist)
        {
            var lparam = MarshalExtensions.StructureToPtr(pbuttonImagelist);
            var result = SendMessage(hwnd, (WindowsMessages)ButtonControlMessages.BCM_SETIMAGELIST, UIntPtr.Zero, lparam);
            Marshal.FreeHGlobal(lparam);
            return result != IntPtr.Zero;
        }

        /// <summary>
        /// Sets the text of the note associated with a specified command link button.
        /// You can use this macro or send the <see cref="ButtonControlMessages.BCM_SETNOTE"/> message explicitly.
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the button control.
        /// </param>
        /// <param name="psz">
        /// A pointer to a null-terminated WCHAR string that contains the note.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// Beginning with comctl32 DLL version 6.01, command link buttons may have a note.
        /// This macro works only with the <see cref="ButtonStyles.BS_COMMANDLINK"/> and <see cref="ButtonStyles.BS_DEFCOMMANDLINK"/> button styles.
        /// </remarks>
        public static bool Button_SetNote(IntPtr hwnd, string psz)
        {
            var lparam = Marshal.StringToHGlobalUni(psz);
            var result = SendMessage(hwnd, (WindowsMessages)ButtonControlMessages.BCM_SETNOTE, UIntPtr.Zero, lparam);
            Marshal.FreeHGlobal(lparam);
            return result != IntPtr.Zero;
        }

        /// <summary>
        /// Sets information for a specified split button control.
        /// Use this macro or send the <see cref="ButtonControlMessages.BCM_SETSPLITINFO"/> message explicitly.
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the button control.
        /// </param>
        /// <param name="pInfo">
        /// A pointer to a <see cref="BUTTON_SPLITINFO"/> structure.
        /// The calling application is responsible for allocating the memory for this structure and initializing it.
        /// Set the <see cref="BUTTON_SPLITINFO.mask"/> member of this structure to determine what information to set for the button specified by hwnd.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// Use this macro only with the <see cref="ButtonStyles.BS_SPLITBUTTON"/> and <see cref="ButtonStyles.BS_DEFSPLITBUTTON"/> button styles.
        /// </remarks>
        public static bool Button_SetSplitInfo(IntPtr hwnd, BUTTON_SPLITINFO pInfo)
        {
            var lparam = MarshalExtensions.StructureToPtr(pInfo);
            var result = SendMessage(hwnd, (WindowsMessages)ButtonControlMessages.BCM_SETSPLITINFO, UIntPtr.Zero, lparam);
            Marshal.FreeHGlobal(lparam);
            return result != IntPtr.Zero;
        }

        /// <summary>
        /// Sets the highlight state of a button.
        /// The highlight state indicates whether the button is highlighted as if the user had pushed it.
        /// You can use this macro or send the <see cref="ButtonControlMessages.BM_SETSTATE"/> message explicitly.
        /// </summary>
        /// <param name="hwndCtl">
        /// A handle to the button control.
        /// </param>
        /// <param name="state">
        /// <see langword="true"/> to highlight the button; otherwise <see langword="false"/>.
        /// </param>
        /// <returns></returns>
        public static uint Button_SetState(IntPtr hwndCtl, bool state) =>
             SendMessage(hwndCtl, (WindowsMessages)ButtonControlMessages.BM_SETSTATE, (UIntPtr)(state ? 1 : 0), IntPtr.Zero).SafeToUInt32();

        /// <summary>
        /// Sets the style of a button.
        /// You can use this macro or send the <see cref="ButtonControlMessages.BM_SETSTYLE"/> message explicitly.
        /// </summary>
        /// <param name="hwndCtl">
        /// A handle to the button control.
        /// </param>
        /// <param name="style">
        /// The button style. This parameter can be a combination of button styles. For a table of button styles, see Button Styles.
        /// </param>
        /// <param name="fRedraw">
        /// <see langword="true"/> to redraw the button; otherwise <see langword="false"/>.
        /// </param>
        public static void Button_SetStyle(IntPtr hwndCtl, ButtonStyles style, bool fRedraw) =>
            SendMessage(hwndCtl, (WindowsMessages)ButtonControlMessages.BM_SETSTYLE, (UIntPtr)(uint)style, (IntPtr)(fRedraw ? 1 : 0));

        /// <summary>
        /// Sets the text of a button.
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the button control.
        /// </param>
        /// <param name="lpsz">
        /// A pointer to a null-terminated string to be used as the button text.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// The macro expands to a call to <see cref="SetWindowText"/>.
        /// </remarks>
        public static bool Button_SetText(IntPtr hwnd, string lpsz) => SetWindowText(hwnd, lpsz);

        /// <summary>
        /// Sets the margins for drawing text in a button control.
        /// You can use this macro or send the <see cref="ButtonControlMessages.BCM_SETTEXTMARGIN"/> message explicitly.
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the button control.
        /// </param>
        /// <param name="pmargin">
        /// A pointer to a <see cref="RECT"/> structure that specifies the margins to set for drawing text in a button control.
        /// </param>
        /// <returns>
        /// To use this macro, you must provide a manifest specifying Comclt32.dll version 6.0.
        /// For more information on manifests, see Enabling Visual Styles.
        /// </returns>
        public static bool Button_SetTextMargin(IntPtr hwnd, SIZE pmargin)
        {
            var lparam = MarshalExtensions.StructureToPtr(pmargin);
            var result = SendMessage(hwnd, (WindowsMessages)ButtonControlMessages.BCM_SETTEXTMARGIN, UIntPtr.Zero, lparam);
            Marshal.FreeHGlobal(lparam);
            return result != IntPtr.Zero;
        }
    }
}
