using Lsj.Util.Win32.Attributes;
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
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
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
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Imm32.dll", CharSet = CharSet.Unicode, EntryPoint = "ImmAssociateContext", ExactSpelling = true)]
        public static extern HIMC ImmAssociateContext([In] HWND unnamedParam1, [In] HIMC unnamedParam2);

        /// <summary>
        /// <para>
        /// Changes the association between the input method context and the specified window or its children.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immassociatecontextex"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1">
        /// Handle to the window to associate with the input context.
        /// </param>
        /// <param name="unnamedParam2">
        /// Handle to the input method context.
        /// </param>
        /// <param name="unnamedParam3">
        /// <para>
        /// Flags specifying the type of association between the window and the input method context.
        /// This parameter can have one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="IACE_CHILDREN"/>
        /// </term>
        /// <term>
        /// Associate the input method context to the child windows of the specified window only.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="IACE_DEFAULT"/>
        /// </term>
        /// <term>
        /// Restore the default input method context of the window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="IACE_IGNORENOCONTEXT"/>
        /// </term>
        /// <term>
        /// Do not associate the input method context with windows that are not associated with any input method context.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful or <see cref="FALSE"/> otherwise.
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the application calls this function with <see cref="IACE_CHILDREN"/>,
        /// the operating system associates the specified input method context with child windows of the window indicated by <paramref name="unnamedParam1"/>.
        /// It associates the input method context only with child windows of the thread that creates <paramref name="unnamedParam1"/>.
        /// Any child window that is created after this function has been called will not be affected.
        /// Instead, the default input method context will be associated with it.
        /// </para>
        /// <para>
        /// If the application calls this function with <see cref="IACE_DEFAULT"/>,
        /// the operating system restores the default input method context for the window.
        /// In this case, the <paramref name="unnamedParam2"/> parameter is ignored.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Imm32.dll", CharSet = CharSet.Unicode, EntryPoint = "ImmAssociateContextEx", ExactSpelling = true)]
        public static extern BOOL ImmAssociateContextEx([In] HWND unnamedParam1, [In] HIMC unnamedParam2, [In] ImmAssociateContextExFlags unnamedParam3);

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
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Imm32.dll", CharSet = CharSet.Unicode, EntryPoint = "ImmCreateContext", ExactSpelling = true)]
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
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Imm32.dll", CharSet = CharSet.Unicode, EntryPoint = "ImmDestroyContext", ExactSpelling = true)]
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
        /// <para>
        /// The application must call this function before the first top-level window in the thread receives the <see cref="WM_CREATE"/> message.
        /// Thus, the application must call this function in one of the following places:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Any time before calling <see cref="CreateWindow"/> to create the first top-level window
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// In the <see cref="WM_NCCREATE"/> handler for first top-level window
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Imm32.dll", CharSet = CharSet.Unicode, EntryPoint = "ImmDisableIME", ExactSpelling = true)]
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
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Imm32.dll", CharSet = CharSet.Unicode, EntryPoint = "ImmGetCompositionWindow", ExactSpelling = true)]
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
        /// <para>
        /// An application should routinely use this function to retrieve the current input context
        /// before attempting to access information in the context.
        /// </para>
        /// <para>
        /// The application must call <see cref="ImmReleaseContext"/> when it is finished with the input context.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Imm32.dll", CharSet = CharSet.Unicode, EntryPoint = "ImmGetContext", ExactSpelling = true)]
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
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Imm32.dll", CharSet = CharSet.Unicode, EntryPoint = "ImmGetDefaultIMEWnd", ExactSpelling = true)]
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
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Imm32.dll", CharSet = CharSet.Unicode, EntryPoint = "ImmGetOpenStatus", ExactSpelling = true)]
        public static extern BOOL ImmGetOpenStatus([In] HIMC unnamedParam1);

        /// <summary>
        /// <para>
        /// Releases the input context and unlocks the memory associated in the input context.
        /// An application must call this function for each call to the <see cref="ImmGetContext"/> function.
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
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Imm32.dll", CharSet = CharSet.Unicode, EntryPoint = "ImmReleaseContext", ExactSpelling = true)]
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
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Imm32.dll", CharSet = CharSet.Unicode, EntryPoint = "ImmSetCompositionWindow", ExactSpelling = true)]
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
        /// This function causes an <see cref="IMN_SETOPENSTATUS"/> command to be sent to the application.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Imm32.dll", CharSet = CharSet.Unicode, EntryPoint = "ImmSetOpenStatus", ExactSpelling = true)]
        public static extern BOOL ImmSetOpenStatus([In] HIMC unnamedParam1, [In] BOOL unnamedParam2);
    }
}
