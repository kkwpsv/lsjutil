using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32
{
    public static partial class User32
    {
        /// <summary>
        /// <para>
        /// Copies the specified accelerator table.
        /// This function is used to obtain the accelerator-table data that corresponds to an accelerator-table handle,
        /// or to determine the size of the accelerator-table data.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-copyacceleratortablew"/>
        /// </para>
        /// </summary>
        /// <param name="hAccelSrc">
        /// A handle to the accelerator table to copy.
        /// </param>
        /// <param name="lpAccelDst">
        /// An array of <see cref="ACCEL"/> structures that receives the accelerator-table information.
        /// </param>
        /// <param name="cAccelEntries">
        /// The number of <see cref="ACCEL"/> structures to copy to the buffer pointed to by the <paramref name="lpAccelDst"/> parameter.
        /// </param>
        /// <returns>
        /// If <paramref name="lpAccelDst"/> is <see langword="null"/>, the return value specifies the number of accelerator-table entries in the original table.
        /// Otherwise, it specifies the number of accelerator-table entries that were copied.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CopyAcceleratorTableW", ExactSpelling = true, SetLastError = true)]
        public static extern int CopyAcceleratorTable([In] HACCEL hAccelSrc, [Out] ACCEL[] lpAccelDst, [In] int cAccelEntries);

        /// <summary>
        /// <para>
        /// Creates an accelerator table.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-createacceleratortablew"/>
        /// </para>
        /// </summary>
        /// <param name="paccel">
        /// An array of <see cref="ACCEL"/> structures that describes the accelerator table.
        /// </param>
        /// <param name="cAccel">
        /// The number of <see cref="ACCEL"/> structures in the array.
        /// This must be within the range 1 to 32767 or the function will fail.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the created accelerator table;
        /// otherwise, it is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Before an application closes, it can use the <see cref="DestroyAcceleratorTable"/> function to destroy any accelerator tables
        /// that it created by using the <see cref="CreateAcceleratorTable"/> function.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateAcceleratorTableW", ExactSpelling = true, SetLastError = true)]
        public static extern HACCEL CreateAcceleratorTable([In] ACCEL[] paccel, [In] int cAccel);

        /// <summary>
        /// <para>
        /// Destroys an accelerator table.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-destroyacceleratortable"/>
        /// </para>
        /// </summary>
        /// <param name="hAccel">
        /// A handle to the accelerator table to be destroyed.
        /// This handle must have been created by a call to the <see cref="CreateAcceleratorTable"/> or <see cref="LoadAccelerators"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// However, if the table has been loaded more than one call to <see cref="LoadAccelerators"/>,
        /// the function will return a nonzero value only when <see cref="DestroyAcceleratorTable"/> has been called an equal number of times.
        /// If the function fails, the return value is zero.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DestroyAcceleratorTable", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DestroyAcceleratorTable([In] HACCEL hAccel);

        /// <summary>
        /// <para>
        /// Loads the specified accelerator table.
        /// </para>
        /// <para>
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-loadacceleratorsw
        /// </para>
        /// </summary>
        /// <param name="hInstance">
        /// A handle to the module whose executable file contains the accelerator table to be loaded.
        /// </param>
        /// <param name="lpTableName">
        /// The name of the accelerator table to be loaded.
        /// Alternatively, this parameter can specify the resource identifier of an accelerator-table resource
        /// in the low-order word and zero in the high-order word.
        /// To create this value, use the <see cref="MAKEINTRESOURCE"/> macro.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the loaded accelerator table.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the accelerator table has not yet been loaded, the function loads it from the specified executable file.
        /// Accelerator tables loaded from resources are freed automatically when the application terminates.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadAcceleratorsW", ExactSpelling = true, SetLastError = true)]
        public static extern HACCEL LoadAccelerators([In] HINSTANCE hInstance, [In] LPCWSTR lpTableName);

        /// <summary>
        /// <para>
        /// Processes accelerator keys for menu commands.
        /// The function translates a <see cref="WM_KEYDOWN"/> or <see cref="WM_SYSKEYDOWN"/> message
        /// to a <see cref="WM_COMMAND"/> or <see cref="WM_SYSCOMMAND"/> message (if there is an entry for the key in the specified accelerator table)
        /// and then sends the <see cref="WM_COMMAND"/> or <see cref="WM_SYSCOMMAND"/> message directly to the specified window procedure.
        /// <see cref="TranslateAccelerator"/> does not return until the window procedure has processed the message.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-translateacceleratorw"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose messages are to be translated.
        /// </param>
        /// <param name="hAccTable">
        /// A handle to the accelerator table.
        /// The accelerator table must have been loaded by a call to the <see cref="LoadAccelerators"/> function
        /// or created by a call to the <see cref="CreateAcceleratorTable"/> function.
        /// </param>
        /// <param name="lpMsg">
        /// A pointer to an <see cref="MSG"/> structure that contains message information retrieved from the calling thread's message queue
        /// using the <see cref="GetMessage"/> or <see cref="PeekMessage"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// To differentiate the message that this function sends from messages sent by menus or controls,
        /// the high-order word of the wParam parameter of the <see cref="WM_COMMAND"/> or <see cref="WM_SYSCOMMAND"/> message contains the value 1.
        /// Accelerator key combinations used to select items from the window menu are translated into <see cref="WM_SYSCOMMAND"/> messages;
        /// all other accelerator key combinations are translated into <see cref="WM_COMMAND"/> messages.
        /// When <see cref="TranslateAccelerator"/> returns a nonzero value and the message is translated,
        /// the application should not use the <see cref="TranslateMessage"/> function to process the message again.
        /// An accelerator need not correspond to a menu command.
        /// If the accelerator command corresponds to a menu item, the application is sent <see cref="WM_INITMENU"/>
        /// and <see cref="WM_INITMENUPOPUP"/> messages, as if the user were trying to display the menu.
        /// However, these messages are not sent if any of the following conditions exist:
        /// The window is disabled.
        /// The accelerator key combination does not correspond to an item on the window menu and the window is minimized.
        /// A mouse capture is in effect. For information about mouse capture, see the <see cref="SetCapture"/> function.
        /// If the specified window is the active window and no window has the keyboard focus (which is generally the case if the window is minimized),
        /// <see cref="TranslateAccelerator"/> translates <see cref="WM_SYSKEYUP"/> and <see cref="WM_SYSKEYDOWN"/> messages
        /// instead of <see cref="WM_KEYUP"/> and <see cref="WM_KEYDOWN"/> messages.
        /// If an accelerator keystroke occurs that corresponds to a menu item when the window that owns the menu is minimized,
        /// <see cref="TranslateAccelerator"/> does not send a <see cref="WM_COMMAND"/> message.
        /// However, if an accelerator keystroke occurs that does not match any of the items in the window's menu or in the window menu,
        /// the function sends a <see cref="WM_COMMAND"/> message, even if the window is minimized.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "TranslateAcceleratorW", ExactSpelling = true, SetLastError = true)]
        public static extern int TranslateAccelerator([In] HWND hWnd, [In] HACCEL hAccTable, [In][Out] ref MSG lpMsg);
    }
}
