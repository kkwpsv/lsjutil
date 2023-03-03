using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.ImmAssociateContextExFlags;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Imm32.dll
    /// </summary>
    public static class Imm32
    {
        /// <summary>
        /// <para>
        /// Associates the specified input context with the specified window.
        /// By default, the operating system associates the default input context with each window as it is created.
        /// Note
        /// To specify a type of association, the application should use the <see cref="ImmAssociateContextEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immassociatecontext"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1"></param>
        /// <param name="unnamedParam2"></param>
        /// <returns>
        /// Returns the handle to the input context previously associated with the window.
        /// </returns>
        /// <remarks>
        /// When associating an input context with a window, an application must remove the association before destroying the input context.
        /// One way to do this is to save the handle and reassociate it to the default input context with the window.
        /// </remarks>
        [DllImport("Imm32.dll", CharSet = CharSet.Unicode, EntryPoint = "ImmAssociateContext", ExactSpelling = true, SetLastError = true)]
        public static extern HIMC ImmAssociateContext([In] HWND unnamedParam1, [In] HIMC unnamedParam2);

        /// <summary>
        /// <para>
        /// Changes the association between the input method context and the specified window or its children.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immassociatecontextex"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// Handle to the window to associate with the input context.
        /// </param>
        /// <param name="hIMC">
        /// Handle to the input method context.
        /// </param>
        /// <param name="unnamedParam3">
        /// Flags specifying the type of association between the window and the input method context.
        /// This parameter can have one of the following values.
        /// <see cref="IACE_CHILDREN"/>:
        /// Associate the input method context to the child windows of the specified window only.
        /// <see cref="IACE_DEFAULT"/>:
        /// Restore the default input method context of the window.
        /// <see cref="IACE_IGNORENOCONTEXT"/>:
        /// Do not associate the input method context with windows that are not associated with any input method context.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful or <see cref="FALSE"/> otherwise.
        /// </returns>
        /// <remarks>
        /// If the application calls this function with <see cref="IACE_CHILDREN"/>,
        /// the operating system associates the specified input method context with child windows of the window indicated by <paramref name="hWnd"/>.
        /// It associates the input method context only with child windows of the thread that creates <paramref name="hWnd"/>.
        /// Any child window that is created after this function has been called will not be affected.
        /// Instead, the default input method context will be associated with it.
        /// If the application calls this function with <see cref="IACE_DEFAULT"/>,
        /// the operating system restores the default input method context for the window.
        /// In this case, the <paramref name="hIMC"/> parameter is ignored.
        /// </remarks>
        [DllImport("Imm32.dll", CharSet = CharSet.Unicode, EntryPoint = "ImmAssociateContextEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ImmAssociateContextEx([In] HWND hWnd, [In] HIMC hIMC, [In] ImmAssociateContextExFlags unnamedParam3);

        /// <summary>
        /// <para>
        /// Creates a new input context, allocating memory for the context and initializing it.
        /// An application calls this function to prepare its own input context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immcreatecontext"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// Returns the handle to the new input context if successful, or <see cref="NULL"/> otherwise.
        /// </returns>
        [DllImport("Imm32.dll", CharSet = CharSet.Unicode, EntryPoint = "ImmCreateContext", ExactSpelling = true, SetLastError = true)]
        public static extern HIMC ImmCreateContext();

        /// <summary>
        /// <para>
        /// Releases the input context and frees associated memory.
        /// </para>
        /// <para>
        /// From <see href="https://learn.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immdestroycontext"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1"></param>
        /// <returns>
        /// Returns a nonzero value if successful, or 0 otherwise.
        /// </returns>
        /// <remarks>
        /// Any application that creates an input context by using the <see cref="ImmCreateContext"/> function
        /// must call this function to free the context before it terminates.
        /// However, before calling <see cref="ImmDestroyContext"/>, the application must remove the input context
        /// from any association with windows in the thread by using the <see cref="ImmAssociateContext"/> function.
        /// </remarks>
        [DllImport("Imm32.dll", CharSet = CharSet.Unicode, EntryPoint = "ImmDestroyContext", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ImmDestroyContext([In] HIMC unnamedParam1);

        /// <summary>
        /// <para>
        /// Disables the IME for a thread or for all threads in a process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immdisableime"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1"></param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful or <see cref="FALSE"/> otherwise.
        /// </returns>
        /// <remarks>
        /// The application must call this function before the first top-level window in the thread receives the <see cref="WM_CREATE"/> message.
        /// Thus, the application must call this function in one of the following places:
        /// Any time before calling <see cref="CreateWindow"/> to create the first top-level window
        /// In the <see cref="WM_NCCREATE"/> handler for first top-level window
        /// </remarks>
        [DllImport("Imm32.dll", CharSet = CharSet.Unicode, EntryPoint = "ImmDisableIME", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ImmDisableIME([In] DWORD unnamedParam1);

        /// <summary>
        /// <para>
        /// Retrieves information about the composition window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immgetcompositionwindow"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1"></param>
        /// <param name="lpCompForm">
        /// Pointer to a <see cref="COMPOSITIONFORM"/> structure in which the function retrieves information about the composition window.
        /// </param>
        /// <returns>
        /// Returns a nonzero value if successful, or 0 otherwise.
        /// </returns>
        [DllImport("Imm32.dll", CharSet = CharSet.Unicode, EntryPoint = "ImmGetCompositionWindow", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ImmGetCompositionWindow([In] HIMC unnamedParam1, [Out] out COMPOSITIONFORM lpCompForm);

        /// <summary>
        /// <para>
        /// Returns the input context associated with the specified window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immgetcontext"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1"></param>
        /// <returns>
        /// Returns the handle to the input context.
        /// </returns>
        /// <remarks>
        /// An application should routinely use this function to retrieve the current input context
        /// before attempting to access information in the context.
        /// The application must call <see cref="ImmReleaseContext"/> when it is finished with the input context.
        /// </remarks>
        [DllImport("Imm32.dll", CharSet = CharSet.Unicode, EntryPoint = "ImmGetContext", ExactSpelling = true, SetLastError = true)]
        public static extern HIMC ImmGetContext([In] HWND unnamedParam1);

        /// <summary>
        /// <para>
        /// Retrieves the default window handle to the IME class.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immgetdefaultimewnd"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1"></param>
        /// <returns>
        /// Returns the default window handle to the IME class if successful, or <see cref="NULL"/> otherwise.
        /// </returns>
        /// <remarks>
        /// The operating system creates a default IME window for every thread.
        /// The window is created based on the IME class.
        /// The application can send the <see cref="WM_IME_CONTROL"/> message to this window.
        /// </remarks>
        [DllImport("Imm32.dll", CharSet = CharSet.Unicode, EntryPoint = "ImmGetDefaultIMEWnd", ExactSpelling = true, SetLastError = true)]
        public static extern HWND ImmGetDefaultIMEWnd([In] HWND unnamedParam1);

        /// <summary>
        /// <para>
        /// Determines whether the IME is open or closed.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immgetopenstatus"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1"></param>
        /// <returns>
        /// Returns a nonzero value if the IME is open, or 0 otherwise.
        /// </returns>
        [DllImport("Imm32.dll", CharSet = CharSet.Unicode, EntryPoint = "ImmGetOpenStatus", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ImmGetOpenStatus([In] HIMC unnamedParam1);

        /// <summary>
        /// <para>
        /// Returns the input context associated with the specified window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immgetcontext"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1"></param>
        /// <param name="unnamedParam2"></param>
        /// <returns>
        /// Returns a nonzero value if successful, or 0 otherwise.
        /// </returns>
        [DllImport("Imm32.dll", CharSet = CharSet.Unicode, EntryPoint = "ImmReleaseContext", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ImmReleaseContext([In] HWND unnamedParam1, [In] HIMC unnamedParam2);

        /// <summary>
        /// <para>
        /// Sets the position of the composition window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immsetcompositionwindow"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1"></param>
        /// <param name="lpCompForm">
        /// Pointer to a <see cref="COMPOSITIONFORM"/> structure that contains the new position
        /// and other related information about the composition window.
        /// </param>
        /// <returns>
        /// Returns a nonzero value if successful, or 0 otherwise.
        /// </returns>
        /// <remarks>
        /// This function causes an <see cref="IMN_SETCOMPOSITIONWINDOW"/> command to be sent to the application.
        /// </remarks>
        [DllImport("Imm32.dll", CharSet = CharSet.Unicode, EntryPoint = "ImmSetCompositionWindow", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ImmSetCompositionWindow([In] HIMC unnamedParam1, [In] in COMPOSITIONFORM lpCompForm);

        /// <summary>
        /// <para>
        /// Opens or closes the IME.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immgetcontext"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1"></param>
        /// <param name="unnamedParam2"></param>
        /// <returns>
        /// Returns a nonzero value if successful, or 0 otherwise.
        /// </returns>
        /// <remarks>
        ///This function causes an <see cref="IMN_SETOPENSTATUS"/> command to be sent to the application.
        /// </remarks>
        [DllImport("Imm32.dll", CharSet = CharSet.Unicode, EntryPoint = "ImmSetOpenStatus", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ImmSetOpenStatus([In] HIMC unnamedParam1, [In] BOOL unnamedParam2);
    }
}
