using Lsj.Util.IL;
using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.LCID;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.GetDateFormatFlags;
using static Lsj.Util.Win32.Enums.NTSTATUS;
using static Lsj.Util.Win32.Enums.PrivilegeConstants;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Shell32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Kernel32.dll
    /// </summary>
    public static partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// An application-defined callback function that processes enumerated code page information
        /// provided by the <see cref="EnumSystemCodePages"/> function.
        /// The <see cref="CODEPAGE_ENUMPROC"/> type defines a pointer to this callback function.
        /// <see cref="EnumCodePagesProc"/> is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/dd317809(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="lpCodePageString">
        /// Pointer to a buffer containing a null-terminated code page identifier string.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> to continue enumeration or <see cref="FALSE"/> otherwise.
        /// </returns>
        /// <remarks>
        /// <para>
        /// An <see cref="EnumCodePagesProc"/> function can carry out any desired task.
        /// The application registers this function by passing its address to the <see cref="EnumSystemCodePages"/> function.
        /// </para>
        /// <para>
        /// When an application is using this function to determine an appropriate code page for saving data, it should use Unicode when possible.
        /// Other code pages are not as portable as Unicode between vendors or operating systems,
        /// due to different implementations of the associated standards.
        /// </para>
        /// </remarks>
        public delegate BOOL EnumCodePagesProc([In] LPWSTR lpCodePageString);


        /// <summary>
        /// <para>
        /// The <see cref="ActivateActCtx"/> function activates the specified activation context.
        /// It does this by pushing the specified activation context to the top of the activation stack.
        /// The specified activation context is thus associated with the current thread and any appropriate side-by-side API functions.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-activateactctx"/>
        /// </para>
        /// </summary>
        /// <param name="hActCtx">
        /// Handle to an <see cref="ACTCTX"/> structure that contains information on the activation context that is to be made active.
        /// </param>
        /// <param name="lpCookie">
        /// Pointer to a <see cref="ULONG_PTR"/> that functions as a cookie, uniquely identifying a specific, activated activation context.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, it returns <see cref="TRUE"/>. Otherwise, it returns <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// This function sets errors that can be retrieved by calling <see cref="GetLastError"/>.
        /// For an example, see Retrieving the Last-Error Code.
        /// For a complete list of error codes, see System Error Codes.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <paramref name="lpCookie"/> parameter is later passed to <see cref="DeactivateActCtx"/>,
        /// which verifies the pairing of calls to <see cref="ActivateActCtx"/> and <see cref="DeactivateActCtx"/>
        /// and ensures that the appropriate activation context is being deactivated.
        /// This is done because the deactivation of activation contexts must occur in the reverse order of activation.
        /// </para>
        /// <para>
        /// The activation of activation contexts can be understood as pushing an activation context onto a stack of activation contexts.
        /// The activation context you activate through this function redirects any binding to DLLs,
        /// window classes, COM servers, type libraries, and mutexes for any side-by-side APIs you call.
        /// </para>
        /// <para>
        /// The top item of an activation context stack is the active, default-activation context of the current thread.
        /// If a null activation context handle is pushed onto the stack, thereby activating it,
        /// the default settings in the original manifest override all activation contexts that are lower on the stack.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ActivateActCtx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ActivateActCtx([In] HANDLE hActCtx, [Out] out ULONG_PTR lpCookie);

        /// <summary>
        /// <para>
        /// Generates simple tones on the speaker.
        /// The function is synchronous; it performs an alertable wait and does not return control to its caller until the sound finishes.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/utilapiset/nf-utilapiset-beep"/>
        /// </para>
        /// </summary>
        /// <param name="dwFreq">
        /// The frequency of the sound, in hertz. This parameter must be in the range 37 through 32,767 (0x25 through 0x7FFF).
        /// </param>
        /// <param name="dwDuration">
        /// The duration of the sound, in milliseconds.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// A long time ago, all PC computers shared a common 8254 programmable interval timer chip for the generation of primitive sounds.
        /// The <see cref="Beep"/> function was written specifically to emit a beep on that piece of hardware.
        /// </para>
        /// <para>
        /// On these older systems, muting and volume controls have no effect on <see cref="Beep"/>; you would still hear the tone.
        /// To silence the tone, you used the following commands:
        /// </para>
        /// <para>
        /// net stop beep
        /// </para>
        /// <para>
        /// sc config beep start= disabled
        /// </para>
        /// <para>
        /// Since then, sound cards have become standard equipment on almost all PC computers.
        /// As sound cards became more common, manufacturers began to remove the old timer chip from computers.
        /// The chips were also excluded from the design of server computers.
        /// The result is that <see cref="Beep"/> did not work on all computers without the chip.
        /// This was okay because most developers had moved on to calling the <see cref="MessageBeep"/> function
        /// that uses whatever is the default sound device instead of the 8254 chip.
        /// </para>
        /// <para>
        /// Eventually because of the lack of hardware to communicate with,
        /// support for playing sound from the motherboard speaker was dropped in Windows Vista and Windows XP 64-Bit Edition.
        /// </para>
        /// <para>
        /// In Windows 7, <see cref="Beep"/> was rewritten to pass the beep to the default sound device for the session.
        /// This is normally the sound card, except when run under Terminal Services, in which case the beep is rendered on the client.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "Beep", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL Beep([In] DWORD dwFreq, [In] DWORD dwDuration);

        /// <summary>
        /// <para>
        /// The <see cref="CreateActCtx"/> function creates an activation context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-createactctxw"/>
        /// </para>
        /// </summary>
        /// <param name="pActCtx">
        /// Pointer to an <see cref="ACTCTX"/> structure that contains information about the activation context to be created.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, it returns a handle to the returned activation context.
        /// Otherwise, it returns <see cref="INVALID_HANDLE_VALUE"/>.
        /// </para>
        /// <para>
        /// This function sets errors that can be retrieved by calling <see cref="GetLastError"/>.
        /// For an example, see Retrieving the Last-Error Code. For a complete list of error codes, see System Error Codes.
        /// </para>
        /// </returns>
        /// <remarks>
        /// Set any undefined bits in <see cref="ACTCTX.dwFlags"/> of <see cref="ACTCTX"/> to 0.
        /// If any undefined bits are not set to 0, the call to <see cref="CreateActCtx"/> that creates the activation context fails and returns an invalid parameter error code.
        /// The handle returned from <see cref="CreateActCtx"/> is passed in a call to <see cref="ActivateActCtx"/> to activate the context for the current thread.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateActCtxW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE CreateActCtx([In][Out] ref ACTCTX pActCtx);

        /// <summary>
        /// <para>
        /// The <see cref="DeactivateActCtx"/> function deactivates the activation context corresponding to the specified cookie.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-deactivateactctx"/>
        /// </para>
        /// </summary>
        /// <param name="dwFlags">
        /// <para>
        /// Flags that indicate how the deactivation is to occur.
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
        /// 0
        /// </term>
        /// <term>
        /// <para>
        /// If this value is set and the cookie specified in the <paramref name="ulCookie"/> parameter is in the top frame of the activation stack,
        /// the activation context is popped from the stack and thereby deactivated.
        /// </para>
        /// <para>
        /// If this value is set and the cookie specified in the <paramref name="ulCookie"/> parameter is not in the top frame of the activation stack,
        /// this function searches down the stack for the cookie.
        /// </para>
        /// <para>
        /// If the cookie is found, a <see cref="STATUS_SXS_EARLY_DEACTIVATION"/> exception is thrown.
        /// </para>
        /// <para>
        /// If the cookie is not found, a <see cref="STATUS_SXS_INVALID_DEACTIVATION"/> exception is thrown.
        /// </para>
        /// <para>
        /// This value should be specified in most cases.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DEACTIVATE_ACTCTX_FLAG_FORCE_EARLY_DEACTIVATION"/>
        /// </term>
        /// <term>
        /// <para>
        /// If this value is set and the cookie specified in the <paramref name="ulCookie"/> parameter is in the top frame of the activation stack,
        /// the function returns an <see cref="ERROR_INVALID_PARAMETER"/> error code.
        /// Call <see cref="GetLastError"/> to obtain this code.
        /// </para>
        /// <para>
        /// If this value is set and the cookie is not on the activation stack, a <see cref="STATUS_SXS_INVALID_DEACTIVATION"/> exception will be thrown.
        /// </para>
        /// <para>
        /// If this value is set and the cookie is in a lower frame of the activation stack,
        /// all of the frames down to and including the frame the cookie is in is popped from the stack.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="ulCookie">
        /// The <see cref="ULONG_PTR"/> that was passed into the call to <see cref="ActivateActCtx"/>.
        /// This value is used as a cookie to identify a specific activated activation context.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, it returns <see cref="TRUE"/>. Otherwise, it returns <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// This function sets errors that can be retrieved by calling <see cref="GetLastError"/>.
        /// For an example, see Retrieving the Last-Error Code.
        /// For a complete list of error codes, see System Error Codes.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The deactivation of activation contexts must occur in the reverse order of activation.
        /// It can be understood as popping an activation context from a stack.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeactivateActCtx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DeactivateActCtx([In] DWORD dwFlags, [In] ULONG_PTR ulCookie);

        /// <summary>
        /// <para>
        /// Decodes a pointer that was previously encoded with <see cref="EncodePointer"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/bb432242(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="Ptr">
        /// The pointer to be decoded.
        /// </param>
        /// <returns>
        /// The function returns the decoded pointer.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP, Note = "Windows XP with SP2")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DecodePointer", ExactSpelling = true)]
        public static extern PVOID DecodePointer([In] PVOID Ptr);

        /// <summary>
        /// <para>
        /// Decodes a pointer that was previously encoded with <see cref="EncodeSystemPointer"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/bb432243(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="Ptr">
        /// The pointer to be decoded.
        /// </param>
        /// <returns>
        /// The function returns the decoded pointer.
        /// </returns>
        /// <remarks>
        /// Using <see cref="EncodeSystemPointer"/>/<see cref="DecodeSystemPointer"/> is faster than using <see cref="EncodePointer"/>/<see cref="DecodePointer"/>,
        /// but the encoded system pointers are more vulnerable to attack because the value can be predicted on a per-machine basis.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP, Note = "Windows XP with SP2")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DecodeSystemPointer", ExactSpelling = true)]
        public static extern PVOID DecodeSystemPointer([In] PVOID Ptr);

        /// <summary>
        /// <para>
        /// Encodes the specified pointer.
        /// Encoded pointers can be used to provide another layer of protection for pointer values.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/bb432254(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="Ptr">
        /// The pointer to be encoded.
        /// </param>
        /// <returns>
        /// The function returns the encoded pointer.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Encoding globally available pointers helps protect them from being exploited.
        /// The <see cref="EncodePointer"/> function obfuscates the pointer value with a secret so that it cannot be predicted by an external agent.
        /// The secret used by <see cref="EncodePointer"/> is different for each process.
        /// </para>
        /// <para>
        /// A pointer must be decoded before it can be used.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP, Note = "Windows XP with SP2")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "EncodePointer", ExactSpelling = true)]
        public static extern PVOID EncodePointer([In] PVOID Ptr);

        /// <summary>
        /// <para>
        /// Encodes the specified pointer with a system-specific value.
        /// Encoded pointers can be used to provide another layer of protection for pointer values.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/bb432255(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="Ptr">
        /// The system pointer to be encoded.
        /// </param>
        /// <returns>
        /// The function returns the encoded pointer.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Encoding globally available pointers helps protect them from being exploited.
        /// The <see cref="EncodeSystemPointer"/> function obfuscates the pointer value with a secret so that it cannot be predicted by an external agent.
        /// The secret used by <see cref="EncodeSystemPointer"/> is the same for each process on a given computer, and is known to all the processes on that computer.
        /// </para>
        /// <para>
        /// A pointer must be decoded before it can be used.
        /// </para>
        /// <para>
        /// Using <see cref="EncodeSystemPointer"/>/<see cref="DecodeSystemPointer"/> is faster than using <see cref="EncodePointer"/>/<see cref="DecodePointer"/>,
        /// but the encoded system pointers are more vulnerable to attack because the value can be predicted on a per-machine basis.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP, Note = "Windows XP with SP2")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "EncodeSystemPointer", ExactSpelling = true)]
        public static extern PVOID EncodeSystemPointer([In] PVOID Ptr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpProc"></param>
        [Obsolete]
        public static void FreeProcInstance(FARPROC lpProc)
        {
        }

        /// <summary>
        /// <para>
        /// Determines whether a file is an executable (.exe) file, and if so, which subsystem runs the executable file.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getbinarytypew"/>
        /// </para>
        /// </summary>
        /// <param name="lpApplicationName">
        /// <para>
        /// The full path of the file whose executable type is to be determined.
        /// </para>
        /// <para>
        /// By default, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, prepend "\\?\" to the path.
        /// For more information, see Naming Files, Paths, and Namespaces.
        /// </para>
        /// <para>
        ///  Tip
        /// </para>
        /// <para>
        /// Starting with Windows 10, Version 1607, you can opt-in to remove the <see cref="MAX_PATH"/> limitation without prepending "\\?\".
        /// See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </para>
        /// </param>
        /// <param name="lpBinaryType">
        /// <para>
        /// A pointer to a variable to receive information about the executable type of the file specified by <paramref name="lpApplicationName"/>.
        /// The following constants are defined.
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
        /// <para>
        /// <see cref="SCS_32BIT_BINARY"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// A 32-bit Windows-based application
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SCS_64BIT_BINARY"/>
        /// </para>
        /// <para>
        /// 6
        /// </para>
        /// </term>
        /// <term>
        /// A 64-bit Windows-based application.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SCS_DOS_BINARY"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// An MS-DOS – based application
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SCS_OS216_BINARY"/>
        /// </para>
        /// <para>
        /// 5
        /// </para>
        /// </term>
        /// <term>
        /// A 16-bit OS/2-based application
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SCS_PIF_BINARY"/>
        /// </para>
        /// <para>
        /// 3
        /// </para>
        /// </term>
        /// <term>
        /// A PIF file that executes an MS-DOS – based application
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SCS_POSIX_BINARY"/>
        /// </para>
        /// <para>
        /// 4
        /// </para>
        /// </term>
        /// <term>
        /// A POSIX – based application
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SCS_WOW_BINARY"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// A 16-bit Windows-based application
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the file is executable, the return value is nonzero.
        /// The function sets the variable pointed to by <paramref name="lpBinaryType"/> to indicate the file's executable type.
        /// </para>
        /// <para>
        /// If the file is not executable, or if the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If the file is a DLL, the last error code is <see cref="ERROR_BAD_EXE_FORMAT"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// As an alternative, you can obtain the same information by calling the <see cref="SHGetFileInfo"/> function,
        /// passing the <see cref="SHGFI_EXETYPE"/> flag in the <c>uFlags</c> parameter.
        /// </para>
        /// <para>
        /// Symbolic link behavior—If the path points to a symbolic link, the target file is used.
        /// </para>
        /// <para>
        /// In Windows 8 and Windows Server 2012, this function is supported by the following technologies.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Technology
        /// </term>
        /// <term>
        /// Supported
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Server Message Block (SMB) 3.0 protocol
        /// </term>
        /// <term>
        /// Yes
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// SMB 3.0 Transparent Failover (TFO)
        /// </term>
        /// <term>
        /// Yes
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// SMB 3.0 with Scale-out File Shares (SO)
        /// </term>
        /// <term>
        /// Yes
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Cluster Shared Volume File System (CsvFS)
        /// </term>
        /// <term>
        /// Yes
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Resilient File System (ReFS)
        /// </term>
        /// <term>
        /// Yes
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetBinaryTypeW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetBinaryType([In] LPCWSTR lpApplicationName, [Out] out DWORD lpBinaryType);

        /// <summary>
        /// <para>
        /// Formats a number string as a currency string for a locale specified by identifier.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// For interoperability reasons, the application should prefer the <see cref="GetCurrencyFormatEx"/> function to <see cref="GetCurrencyFormat"/>
        /// because Microsoft is migrating toward the use of locale names instead of locale identifiers for new locales.
        /// Any application that runs only on Windows Vista and later should use <see cref="GetCurrencyFormatEx"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnls/nf-winnls-getcurrencyformatw"/>
        /// </para>
        /// </summary>
        /// <param name="Locale">
        /// <para>
        /// Locale identifier that specifies the locale for which this function formats the currency string.
        /// You can use the <see cref="MAKELCID"/> macro to create a locale identifier or use one of the following predefined values.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="LOCALE_CUSTOM_DEFAULT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LOCALE_CUSTOM_UI_DEFAULT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LOCALE_CUSTOM_UNSPECIFIED"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LOCALE_INVARIANT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LOCALE_SYSTEM_DEFAULT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LOCALE_USER_DEFAULT"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="dwFlags">
        /// <para>
        /// Flags controlling currency format.
        /// The application must set this parameter to 0 if <paramref name="lpFormat"/> is not set to <see cref="NullRef{CURRENCYFMT}"/>.
        /// In this case, the function formats the string using user overrides to the default currency format for the locale.
        /// If <paramref name="lpFormat"/> is set to <see cref="NullRef{CURRENCYFMT}"/>,
        /// the application can specify <see cref="LOCALE_NOUSEROVERRIDE"/> to format the string
        /// using the system default currency format for the specified locale.
        /// </para>
        /// <para>
        /// Caution
        /// </para>
        /// <para>
        /// Use of <see cref="LOCALE_NOUSEROVERRIDE"/> is strongly discouraged as it disables user preferences.
        /// </para>
        /// </param>
        /// <param name="lpValue">
        /// For details, see the lpValue parameter of <see cref="GetCurrencyFormatEx"/>.
        /// </param>
        /// <param name="lpFormat">
        /// Pointer to a <see cref="CURRENCYFMT"/> structure that contains currency formatting information.
        /// All members of the structure must contain appropriate values.
        /// The application can set this parameter to <see cref="NULL"/> if function is to use the currency format of the specified locale.
        /// If this parameter is not set to <see cref="NULL"/>,
        /// the function uses the specified locale only for formatting information not specified in the <see cref="CURRENCYFMT"/> structure,
        /// for example, the string value for the negative sign used by the locale.
        /// </param>
        /// <param name="lpCurrencyStr">
        /// Pointer to a buffer in which this function retrieves the formatted currency string.
        /// </param>
        /// <param name="cchCurrency">
        /// Size, in characters, of the <paramref name="lpCurrencyStr"/> buffer.
        /// The application sets this parameter to 0 if the function is to return the size of the buffer required to hold the formatted currency string.
        /// In this case, the <paramref name="lpCurrencyStr"/> parameter is not used.
        /// </param>
        /// <returns>
        /// <para>
        /// Returns the number of characters retrieved in the buffer indicated by <paramref name="lpCurrencyStr"/> if successful.
        /// If the <paramref name="cchCurrency"/> parameter is set to 0,
        /// the function returns the size of the buffer required to hold the formatted currency string, including a terminating null character.
        /// </para>
        /// <para>
        /// The function returns 0 if it does not succeed.
        /// To get extended error information, the application can call <see cref="GetLastError"/>,
        /// which can return one of the following error codes:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>.
        /// A supplied buffer size was not large enough, or it was incorrectly set to <see cref="NULL"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ERROR_INVALID_FLAGS"/>. The values supplied for flags were not valid.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ERROR_INVALID_PARAMETER"/>. Any of the parameter values was invalid.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function can retrieve data from custom locales.
        /// Data is not guaranteed to be the same from computer to computer or between runs of an application.
        /// If your application must persist or transmit data, see Using Persistent Locale Data.
        /// </para>
        /// <para>
        /// When the ANSI version of this function is used with a Unicode-only locale identifier,
        /// the call can succeed because the operating system uses the system code page.
        /// However, characters that are undefined in the system code page appear in the string as a question mark (?).
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCurrencyFormatW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetCurrencyFormat([In] LCID Locale, [In] DWORD dwFlags, [In] LPCWSTR lpValue,
            [In] in CURRENCYFMT lpFormat, [In] LPWSTR lpCurrencyStr, [In] int cchCurrency);

        /// <summary>
        /// <para>
        /// Formats a date as a date string for a locale specified by the locale identifier.
        /// The function formats either a specified date or the local system date.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/datetimeapi/nf-datetimeapi-getdateformatw"/>
        /// </para>
        /// </summary>
        /// <param name="Locale">
        /// <para>
        /// Locale identifier that specifies the locale this function formats the date string for.
        /// You can use the <see cref="MAKELCID"/> macro to create a locale identifier or use one of the following predefined values.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="LOCALE_CUSTOM_DEFAULT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LOCALE_CUSTOM_UI_DEFAULT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LOCALE_CUSTOM_UNSPECIFIED"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LOCALE_INVARIANT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LOCALE_SYSTEM_DEFAULT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LOCALE_USER_DEFAULT"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="dwFlags">
        /// Flags specifying date format options.
        /// For detailed definitions, see the dwFlags parameter of <see cref="GetDateFormatEx"/>.
        /// </param>
        /// <param name="lpDate">
        /// Pointer to a <see cref="SYSTEMTIME"/> structure that contains the date information to format.
        /// The application sets this parameter to <see cref="NullRef{SYSTEMTIME}"/> if the function is to use the current local system date.
        /// </param>
        /// <param name="lpFormat">
        /// <para>
        /// Pointer to a format picture string that is used to form the date.
        /// Possible values for the format picture string are defined in Day, Month, Year, and Era Format Pictures.
        /// </para>
        /// <para>
        /// The function uses the specified locale only for information not specified in the format picture string,
        /// for example, the day and month names for the locale.
        /// The application can set this parameter to <see cref="NULL"/> to format the string according to the date format for the specified locale.
        /// </para>
        /// </param>
        /// <param name="lpDateStr">
        /// Pointer to a buffer in which this function retrieves the formatted date string.
        /// </param>
        /// <param name="cchDate">
        /// Size, in characters, of the <paramref name="lpDateStr"/> buffer.
        /// The application can set this parameter to 0 to return the buffer size required to hold the formatted date string.
        /// In this case, the buffer indicated by <paramref name="lpDateStr"/> is not used.
        /// </param>
        /// <returns>
        /// <para>
        /// Returns the number of characters written to the <paramref name="lpDateStr"/> buffer if successful.
        /// If the <paramref name="cchDate"/> parameter is set to 0, the function returns the number of characters
        /// required to hold the formatted date string, including the terminating null character.
        /// </para>
        /// <para>
        /// The function returns 0 if it does not succeed.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>.
        /// A supplied buffer size was not large enough, or it was incorrectly set to <see cref="NULL"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ERROR_INVALID_FLAGS"/>. The values supplied for flags were not valid.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ERROR_INVALID_PARAMETER"/>. Any of the parameter values was invalid.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API is being updated to support the May 2019 Japanese era change.
        /// If your application supports the Japanese calendar, you should validate that it properly handles the new era.
        /// See Prepare your application for the Japanese era change for more information.
        /// See Remarks for <see cref="GetDateFormatEx"/>.
        /// </para>
        /// <para>
        /// When the ANSI version of this function is used with a Unicode-only locale identifier,
        /// the function can succeed because the operating system uses the system code page.
        /// However, characters that are undefined in the system code page appear in the string as a question mark ("?").
        /// </para>
        /// <para>
        /// Starting with Windows 8: <see cref="GetDateFormat"/> is declared in Datetimeapi.h. Before Windows 8, it was declared in Winnls.h.
        /// </para>
        /// </remarks>
        [Obsolete("For interoperability reasons, the application should prefer the GetDateFormatEx function to GetDateFormat " +
            "because Microsoft is migrating toward the use of locale names instead of locale identifiers for new locales. " +
            "Any application that will be run only on Windows Vista and later should use GetDateFormatEx.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDateFormatW", ExactSpelling = true, SetLastError = true)]
        public static extern int GetDateFormat([In] LCID Locale, [In] GetDateFormatFlags dwFlags, [In] in SYSTEMTIME lpDate,
            [In] LPCWSTR lpFormat, [In] LPWSTR lpDateStr, [In] int cchDate);

        /// <summary>
        /// <para>
        /// Formats a date as a date string for a locale specified by name.
        /// The function formats either a specified date or the local system date.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// The application should call this function in preference to <see cref="GetDateFormat"/> if designed to run only on Windows Vista and later.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This function can format data that changes between releases, for example, due to a custom locale.
        /// If your application must persist or transmit data, see Using Persistent Locale Data.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/datetimeapi/nf-datetimeapi-getdateformatex"/>
        /// </para>
        /// </summary>
        /// <param name="Locale">
        /// <para>
        /// Pointer to a locale name, or one of the following predefined values.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="LOCALE_NAME_INVARIANT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LOCALE_NAME_SYSTEM_DEFAULT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LOCALE_NAME_USER_DEFAULT"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="dwFlags">
        /// <para>
        /// Flags specifying various function options that can be set if <paramref name="lpFormat"/> is set to <see cref="NULL"/>.
        /// The application can specify a combination of the following values and <see cref="LOCALE_USE_CP_ACP"/> or <see cref="LOCALE_NOUSEROVERRIDE"/>.
        /// </para>
        /// <para>
        /// Caution
        /// </para>
        /// <para>
        /// Use of <see cref="LOCALE_NOUSEROVERRIDE"/> is strongly discouraged as it disables user preferences. 
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
        /// <see cref="DATE_AUTOLAYOUT"/>
        /// </term>
        /// <term>
        /// Windows 7 and later: Detect the need for right-to-left and left-to-right reading layout using the locale and calendar information, and add marks accordingly.
        /// This value cannot be used with <see cref="DATE_LTRREADING"/> or <see cref="DATE_RTLREADING"/>.
        /// <see cref="DATE_AUTOLAYOUT"/> is preferred over <see cref="DATE_LTRREADING"/> and <see cref="DATE_RTLREADING"/>
        /// because it uses the locales and calendars to determine the correct addition of marks.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DATE_LONGDATE"/>
        /// </term>
        /// <term>
        /// Use the long date format.
        /// This value cannot be used with <see cref="DATE_MONTHDAY"/>, <see cref="DATE_SHORTDATE"/>, or <see cref="DATE_YEARMONTH"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DATE_LTRREADING"/>
        /// </term>
        /// <term>
        /// Add marks for left-to-right reading layout.
        /// This value cannot be used with <see cref="DATE_RTLREADING"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DATE_RTLREADING"/>
        /// </term>
        /// <term>
        /// Add marks for right-to-left reading layout.
        /// This value cannot be used with <see cref="DATE_LTRREADING"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DATE_SHORTDATE"/>
        /// </term>
        /// <term>
        /// Use the short date format. This is the default.
        /// This value cannot be used with <see cref="DATE_MONTHDAY"/>, <see cref="DATE_LONGDATE"/>, or <see cref="DATE_YEARMONTH"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DATE_USE_ALT_CALENDAR"/>
        /// </term>
        /// <term>
        /// Use the alternate calendar, if one exists, to format the date string.
        /// If this flag is set, the function uses the default format for that alternate calendar, rather than using any user overrides.
        /// The user overrides will be used only in the event that there is no default format for the specified alternate calendar.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DATE_YEARMONTH"/>
        /// </term>
        /// <term>
        /// Windows Vista: Use the year/month format.
        /// This value cannot be used with <see cref="DATE_MONTHDAY"/>, <see cref="DATE_SHORTDATE"/>, or <see cref="DATE_LONGDATE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DATE_MONTHDAY"/>
        /// </term>
        /// <term>
        /// Windows 10: Use the combination of month and day formats appropriate for the specified locale.
        /// This value cannot be used with <see cref="DATE_YEARMONTH"/>, <see cref="DATE_SHORTDATE"/>, or <see cref="DATE_LONGDATE"/>.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If the application does not specify <see cref="DATE_YEARMONTH"/>, <see cref="DATE_MONTHDAY"/>, <see cref="DATE_SHORTDATE"/>,
        /// or <see cref="DATE_LONGDATE"/>, and <paramref name="lpFormat"/> is set to <see cref="NULL"/>, <see cref="DATE_SHORTDATE"/> is the default.
        /// </para>
        /// </param>
        /// <param name="lpDate">
        /// Pointer to a <see cref="SYSTEMTIME"/> structure that contains the date information to format.
        /// The application can set this parameter to <see cref="NullRef{SYSTEMTIME}"/> if the function is to use the current local system date.
        /// </param>
        /// <param name="lpFormat">
        /// <para>
        /// Pointer to a format picture string that is used to form the date.
        /// Possible values for the format picture string are defined in Day, Month, Year, and Era Format Pictures.
        /// </para>
        /// <para>
        /// For example, to get the date string "Wed, Aug 31 94", the application uses the picture string "ddd',' MMM dd yy".
        /// </para>
        /// <para>
        /// The function uses the specified locale only for information not specified in the format picture string,
        /// for example, the day and month names for the locale.
        /// The application can set this parameter to <see cref="NULL"/> to format the string according to the date format for the specified locale.
        /// </para>
        /// </param>
        /// <param name="lpDateStr">
        /// Pointer to a buffer in which this function retrieves the formatted date string.
        /// </param>
        /// <param name="cchDate">
        /// Size, in characters, of the <paramref name="lpDateStr"/> buffer.
        /// The application can set this parameter to 0 to return the buffer size required to hold the formatted date string.
        /// In this case, the buffer indicated by <paramref name="lpDateStr"/> is not used.
        /// </param>
        /// <param name="lpCalendar">
        /// Reserved; must set to <see cref="NULL"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// Returns the number of characters written to the <paramref name="lpDateStr"/> buffer if successful.
        /// If the <paramref name="cchDate"/> parameter is set to 0, the function returns the number of characters
        /// required to hold the formatted date string, including the terminating null character.
        /// </para>
        /// <para>
        /// This function returns 0 if it does not succeed. 
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>.
        /// A supplied buffer size was not large enough, or it was incorrectly set to <see cref="NULL"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ERROR_INVALID_FLAGS"/>.
        /// The values supplied for flags were not valid.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ERROR_INVALID_PARAMETER"/>.
        /// Any of the parameter values was invalid.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API is being updated to support the May 2019 Japanese era change.
        /// If your application supports the Japanese calendar, you should validate that it properly handles the new era.
        /// See Prepare your application for the Japanese era change for more information.
        /// </para>
        /// <para>
        /// The earliest date supported by this function is January 1, 1601.
        /// </para>
        /// <para>
        /// The day name, abbreviated day name, month name, and abbreviated month name are all localized based on the locale identifier.
        /// </para>
        /// <para>
        /// The date values in the structure indicated by <paramref name="lpDate"/> must be valid.
        /// The function checks each of the date values: year, month, day, and day of week.
        /// If the day of the week is incorrect, the function uses the correct value, and returns no error.
        /// If any of the other date values are outside the correct range,
        /// the function fails, and sets the last error to <see cref="ERROR_INVALID_PARAMETER"/>.
        /// </para>
        /// <para>
        /// The function ignores the time members of the <see cref="SYSTEMTIME"/> structure indicated by <paramref name="lpDate"/>.
        /// These include <see cref="SYSTEMTIME.wHour"/>, <see cref="SYSTEMTIME.wMinute"/>,
        /// <see cref="SYSTEMTIME.wSecond"/>, and <see cref="SYSTEMTIME.wMilliseconds"/>.
        /// </para>
        /// <para>
        /// If the <paramref name="lpFormat"/> parameter contains a bad format string,
        /// the function returns no errors, but just forms the best possible date string.
        /// For example, the only year pictures that are valid are L"yyyy" and L"yy", where the "L" indicates a Unicode (16-bit characters) string.
        /// If L"y" is passed in, the function assumes L"yy". If L"yyy" is passed in, the function assumes L"yyyy".
        /// If more than four date (L"dddd") or four month (L"MMMM") pictures are passed in, the function defaults to L"dddd" or L"MMMM".
        /// </para>
        /// <para>
        /// The application should enclose any text that should remain in its exact form in the date string within single quotation marks in the date format picture.
        /// The single quotation mark can also be used as an escape character to allow the single quotation mark itself to be displayed in the date string.
        /// However, the escape sequence must be enclosed within two single quotation marks.
        /// For example, to display the date as "May '93", the format string is: L"MMMM ''''yy".
        /// The first and last single quotation marks are the enclosing quotation marks.
        /// The second and third single quotation marks are the escape sequence to allow the single quotation mark to be displayed before the century.
        /// </para>
        /// <para>
        /// When the date picture contains both a numeric form of the day (either d or dd) and the full month name (MMMM),
        /// the genitive form of the month name is retrieved in the date string.
        /// </para>
        /// <para>
        /// To obtain the default short and long date format without performing any actual formatting,
        /// the application should use <see cref="GetLocaleInfoEx"/> with the <see cref="LOCALE_SSHORTDATE"/> or <see cref="LOCALE_SLONGDATE"/> constant.
        /// To get the date format for an alternate calendar,
        /// the application uses <see cref="GetLocaleInfoEx"/> with the <see cref="LOCALE_IOPTIONALCALENDAR"/> constant.
        /// To get the date format for a particular calendar,
        /// the application uses <see cref="GetCalendarInfoEx"/>, passing the appropriate Calendar Identifier.
        /// It can call <see cref="EnumCalendarInfoEx"/> or <see cref="EnumDateFormatsEx"/> to retrieve date formats for a particular calendar.
        /// </para>
        /// <para>
        /// This function can retrieve data from custom locales.
        /// Data is not guaranteed to be the same from computer to computer or between runs of an application.
        /// If your application must persist or transmit data, see Using Persistent Locale Data.
        /// </para>
        /// <para>
        /// The DATE_LONGDATE format includes two kinds of date patterns:
        /// patterns that include the day of the week and patterns that do not include the day of the week.
        /// For example, "Tuesday, October 18, 2016" or "October 18, 2016".
        /// If your application needs to ensure that dates use one of these kinds of patterns and not the other kind,
        /// your application should perform the following actions:
        /// </para>
        /// <para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// Call the <see cref="EnumDateFormatsExEx"/> function to get all of the date formats for the <see cref="DATE_LONGDATE"/> format.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Look for the first date format passed to the callback function that you specified for <see cref="EnumDateFormatsExEx"/>
        /// that matches your requested calendar identifier and has a date format string that matches the requirements of your application.
        /// For example, look for the first date format that includes "dddd"
        /// if your application requires that the date include the full name of the day of the week,
        /// or look for the first date format that includes neither "ddd" nor "dddd"
        /// if your application requires that the date includes nether the abbreviated name nor the full name of the day of the week.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Call the <see cref="GetDateFormatEx"/> function with the <paramref name="lpFormat"/> parameter
        /// set to the date format string that you identified as the appropriate format in the callback function.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If the presence or absence of the day of the week in the long date format does not matter to your application,
        /// your application can call <see cref="GetDateFormatEx"/> directly
        /// without first enumerating all of the long date formats by calling <see cref="EnumDateFormatsExEx"/>.
        /// </para>
        /// <para>
        /// Beginning in Windows 8: If your app passes language tags to this function from the Windows.Globalization namespace,
        /// it must first convert the tags by calling <see cref="ResolveLocaleName"/>.
        /// </para>
        /// <para>
        /// Beginning in Windows 8: <see cref="GetDateFormatEx"/> is declared in Datetimeapi.h. Before Windows 8, it was declared in Winnls.h.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDateFormatEx", ExactSpelling = true, SetLastError = true)]
        public static extern int GetDateFormatEx([In] LCID Locale, [In] GetDateFormatFlags dwFlags, [In] in SYSTEMTIME lpDate,
            [In] LPCWSTR lpFormat, [In] LPWSTR lpDateStr, [In] int cchDate, [In] LPCWSTR lpCalendar);

        /// <summary>
        /// <para>
        /// Formats a number string as a number string customized for a locale specified by identifier.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// For interoperability reasons, the application should prefer the <see cref="GetNumberFormatEx"/> function to <see cref="GetNumberFormat"/>
        /// because Microsoft is migrating toward the use of locale names instead of locale identifiers for new locales.
        /// Any application that runs only on Windows Vista and later should use <see cref="GetNumberFormatEx"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnls/nf-winnls-getnumberformatw"/>
        /// </para>
        /// </summary>
        /// <param name="Locale">
        /// <para>
        /// Locale identifier that specifies the locale.
        /// You can use the <see cref="MAKELCID"/> macro to create a locale identifier or use one of the following predefined values.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="LOCALE_CUSTOM_DEFAULT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LOCALE_CUSTOM_UI_DEFAULT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LOCALE_CUSTOM_UNSPECIFIED"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LOCALE_INVARIANT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LOCALE_SYSTEM_DEFAULT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LOCALE_USER_DEFAULT"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="dwFlags">
        /// <para>
        /// Flags controlling the operation of the function.
        /// The application must set this parameter to 0 if <paramref name="lpFormat"/> is not set to <see cref="NullRef{NUMBERFMT}"/>.
        /// In this case, the function formats the string using user overrides to the default number format for the locale.
        /// If <paramref name="lpFormat"/> is set to <see cref="NullRef{NUMBERFMT}"/>,
        /// the application can specify <see cref="LOCALE_NOUSEROVERRIDE"/>
        /// to format the string using the system default number format for the specified locale.
        /// </para>
        /// <para>
        /// Caution
        /// </para>
        /// <para>
        /// Use of <see cref="LOCALE_NOUSEROVERRIDE"/> is strongly discouraged as it disables user preferences.
        /// </para>
        /// </param>
        /// <param name="lpValue">
        /// <para>
        /// Pointer to a null-terminated string containing the number string to format.
        /// This string can only contain the following characters. All other characters are invalid.
        /// The function returns an error if the string indicated by <paramref name="lpValue"/> deviates from these rules.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Characters "0" through "9".
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// One decimal point (dot) if the number is a floating-point value.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A minus sign in the first character position if the number is a negative value.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpFormat">
        /// Pointer to a <see cref="NUMBERFMT"/> structure that contains number formatting information, with all members set to appropriate values.
        /// If the application does not set this parameter to <see cref="NullRef{NUMBERFMT}"/>, the function uses the locale formatting information.
        /// </param>
        /// <param name="lpNumberStr">
        /// Pointer to a buffer in which this function retrieves the formatted number string.
        /// </param>
        /// <param name="cchNumber">
        /// Size, in <c>TCHAR</c> values, for the number string buffer indicated by <paramref name="lpNumberStr"/>.
        /// Alternatively, the application can set this parameter to 0.
        /// In this case, the function returns the required size for the number string buffer,
        /// and does not use the <paramref name="lpNumberStr"/> parameter.
        /// </param>
        /// <returns>
        /// <para>
        /// Returns the number of <c>TCHAR</c> values retrieved in the buffer indicated by <paramref name="lpNumberStr"/> if successful.
        /// If the <paramref name="cchNumber"/> parameter is set to 0,
        /// the function returns the number of characters required to hold the formatted number string,
        /// including a terminating null character.
        /// </para>
        /// <para>
        /// The function returns 0 if it does not succeed.
        /// To get extended error information, the application can call <see cref="GetLastError"/>,
        /// which can return one of the following error codes:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>.
        /// A supplied buffer size was not large enough, or it was incorrectly set to <see cref="NULL"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ERROR_INVALID_FLAGS"/>.
        /// The values supplied for flags were not valid.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ERROR_INVALID_PARAMETER"/>.
        /// Any of the parameter values was invalid.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ERROR_OUTOFMEMORY"/>.
        /// Not enough storage was available to complete this operation.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function can retrieve data from custom locales.
        /// Data is not guaranteed to be the same from computer to computer or between runs of an application.
        /// If your application must persist or transmit data, see Using Persistent Locale Data.
        /// </para>
        /// <para>
        /// When the ANSI version of this function is used with a Unicode-only locale identifier,
        /// the function can succeed because the operating system uses the system code page.
        /// However, characters that are undefined in the system code page appear in the string as a question mark (?).
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetNumberFormatW", ExactSpelling = true, SetLastError = true)]
        public static extern int GetNumberFormat([In] LCID Locale, [In] DWORD dwFlags, [In] LPCWSTR lpValue,
            [In] in NUMBERFMT lpFormat, [In] LPWSTR lpNumberStr, [In] int cchNumber);

        /// <summary>
        /// <para>
        /// Retrieves the power status of the system.
        /// The status indicates whether the system is running on AC or DC power,
        /// whether the battery is currently charging, how much battery life remains, and if battery saver is on or off.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getsystempowerstatus"/>
        /// </para>
        /// </summary>
        /// <param name="lpSystemPowerStatus">
        /// A pointer to a <see cref="SYSTEM_POWER_STATUS"/> structure that receives status information.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSystemPowerStatus", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetSystemPowerStatus([Out] out SYSTEM_POWER_STATUS lpSystemPowerStatus);

        /// <summary>
        /// <para>
        /// Determines whether the calling process has read access to the memory at the specified address.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-isbadcodeptr"/>
        /// </para>
        /// </summary>
        /// <param name="lpfn">
        /// A pointer to a memory address.
        /// </param>
        /// <returns>
        /// <para>
        /// If the calling process has read access to the specified memory, the return value is zero.
        /// </para>
        /// <para>
        /// If the calling process does not have read access to the specified memory, the return value is nonzero. 
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// If the application is compiled as a debugging version, and the process does not have read access to the specified memory location, 
        /// the function causes an assertion and breaks into the debugger. 
        /// Leaving the debugger, the function continues as usual, and returns a nonzero value. 
        /// This behavior is by design, as a debugging aid.
        /// </para>
        /// </returns>
        /// <remarks>
        /// In a preemptive multitasking environment, it is possible for some other thread to change the process's access to the memory being tested.
        /// Even when the function indicates that the process has read access to the specified memory,
        /// you should use structured exception handling when attempting to access the memory.
        /// Use of structured exception handling enables the system to notify the process if an access violation exception occurs,
        /// giving the process an opportunity to handle the exception.
        /// </remarks>
        [Obsolete("This function is obsolete and should not be used. " +
            "Despite its name, it does not guarantee that the pointer is valid or that the memory pointed to is safe to use. " +
            "For more information, see Remarks on this page.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsBadCodePtr", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsBadCodePtr([In] FARPROC lpfn);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lp"></param>
        /// <param name="ucb"></param>
        /// <returns></returns>
        [Obsolete]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsBadHugeReadPtr", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsBadHugeReadPtr([In] IntPtr lp, [In] UINT_PTR ucb);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lp"></param>
        /// <param name="ucb"></param>
        /// <returns></returns>
        [Obsolete]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsBadHugeWritePtr", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsBadHugeWritePtr([In] IntPtr lp, [In] UINT_PTR ucb);

        /// <summary>
        /// <para>
        /// Verifies that the calling process has read access to the specified range of memory.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-isbadreadptr"/>
        /// </para>
        /// </summary>
        /// <param name="lp">
        /// A pointer to the first byte of the memory block.
        /// </param>
        /// <param name="ucb">
        /// The size of the memory block, in bytes.
        /// If this parameter is zero, the return value is zero.
        /// </param>
        /// <returns>
        /// <para>
        /// If the calling process has read access to all bytes in the specified memory range, the return value is zero.
        /// </para>
        /// <para>
        /// If the calling process does not have read access to all bytes in the specified memory range, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the application is compiled as a debugging version, and the process does not have read access to all bytes in the specified memory range,
        /// the function causes an assertion and breaks into the debugger.
        /// Leaving the debugger, the function continues as usual, and returns a nonzero value.
        /// This behavior is by design, as a debugging aid.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function is typically used when working with pointers returned from third-party libraries,
        /// where you cannot determine the memory management behavior in the third-party DLL.
        /// </para>
        /// <para>
        /// Threads in a process are expected to cooperate in such a way that one will not free memory that the other needs.
        /// Use of this function does not negate the need to do this.
        /// If this is not done, the application may fail in an unpredictable manner.
        /// </para>
        /// <para>
        /// Dereferencing potentially invalid pointers can disable stack expansion in other threads.
        /// A thread exhausting its stack, when stack expansion has been disabled,
        /// results in the immediate termination of the parent process, with no pop-up error window or diagnostic information.
        /// </para>
        /// <para>
        /// If the calling process has read access to some, but not all, of the bytes in the specified memory range, the return value is nonzero.
        /// </para>
        /// <para>
        /// In a preemptive multitasking environment, it is possible for some other thread to change the process's access to the memory being tested.
        /// Even when the function indicates that the process has read access to the specified memory,
        /// you should use structured exception handling when attempting to access the memory.
        /// Use of structured exception handling enables the system to notify the process
        /// if an access violation exception occurs, giving the process an opportunity to handle the exception.
        /// </para>
        /// </remarks>
        [Obsolete("This function is obsolete and should not be used. " +
            "Despite its name, it does not guarantee that the pointer is valid or that the memory pointed to is safe to use. " +
            "For more information, see Remarks on this page.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsBadReadPtr", ExactSpelling = true)]
        public static extern BOOL IsBadReadPtr([In] IntPtr lp, [In] UINT_PTR ucb);

        /// <summary>
        /// <para>
        /// Verifies that the calling process has read access to the specified range of memory.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-isbadstringptrw"/>
        /// </para>
        /// </summary>
        /// <param name="lpsz">
        /// A pointer to a null-terminated string, either Unicode or ASCII.
        /// </param>
        /// <param name="ucchMax">
        /// The maximum size of the string, in TCHARs.
        /// The function checks for read access in all characters up to the string's terminating null character
        /// or up to the number of characters specified by this parameter, whichever is smaller.
        /// If this parameter is zero, the return value is zero.
        /// </param>
        /// <returns>
        /// <para>
        /// If the calling process has read access to all characters up to the string's terminating null character
        /// or up to the number of characters specified by <paramref name="ucchMax"/>, the return value is zero.
        /// </para>
        /// <para>
        /// If the calling process does not have read access to all characters up to the string's terminating null character
        /// or up to the number of characters specified by <paramref name="ucchMax"/>, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the application is compiled as a debugging version, and the process does not have read access to the entire memory range specified,
        /// the function causes an assertion and breaks into the debugger.
        /// Leaving the debugger, the function continues as usual, and returns a nonzero value This behavior is by design, as a debugging aid.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function is typically used when working with pointers returned from third-party libraries,
        /// where you cannot determine the memory management behavior in the third-party DLL.
        /// </para>
        /// <para>
        /// Threads in a process are expected to cooperate in such a way that one will not free memory that the other needs.
        /// Use of this function does not negate the need to do this.
        /// If this is not done, the application may fail in an unpredictable manner.
        /// </para>
        /// <para>
        /// Dereferencing potentially invalid pointers can disable stack expansion in other threads.
        /// A thread exhausting its stack, when stack expansion has been disabled,
        /// results in the immediate termination of the parent process, with no pop-up error window or diagnostic information.
        /// </para>
        /// <para>
        /// If the calling process has read access to some, but not all, of the specified memory range, the return value is nonzero.
        /// </para>
        /// <para>
        /// In a preemptive multitasking environment, it is possible for some other thread to change the process's access to the memory being tested.
        /// Even when the function indicates that the process has read access to the specified memory,
        /// you should use structured exception handling when attempting to access the memory.
        /// Use of structured exception handling enables the system to notify the process if an access violation exception occurs,
        /// giving the process an opportunity to handle the exception.
        /// </para>
        /// </remarks>
        [Obsolete("This function is obsolete and should not be used. " +
            "Despite its name, it does not guarantee that the pointer is valid or that the memory pointed to is safe to use. " +
            "For more information, see Remarks on this page.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsBadStringPtrW", ExactSpelling = true)]
        public static extern BOOL IsBadStringPtr([In] LPCWSTR lpsz, UINT_PTR ucchMax);

        /// <summary>
        /// <para>
        /// Verifies that the calling process has write access to the specified range of memory.
        /// Important This function is obsolete and should not be used. Despite its name,
        /// it does not guarantee that the pointer is valid or that the memory pointed to is safe to use.
        /// For more information, see Remarks on this page.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-isbadwriteptr"/>
        /// </para>
        /// </summary>
        /// <param name="lp">
        /// A pointer to the first byte of the memory block.
        /// </param>
        /// <param name="ucb">
        /// The size of the memory block, in bytes. If this parameter is zero, the return value is <see cref="BOOL.FALSE"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// If the calling process has write access to all bytes in the specified memory range, the return value is zero.
        /// </para>
        /// <para>
        /// If the calling process does not have write access to all bytes in the specified memory range, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the application is run under a debugger and the process does not have write access to all bytes in the specified memory range,
        /// the function causes a first chance <see cref="STATUS_ACCESS_VIOLATION"/> exception.
        /// The debugger can be configured to break for this condition.
        /// After resuming process execution in the debugger, the function continues as usual and returns a nonzero value.
        /// This behavior is by design and serves as a debugging aid.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function is typically used when working with pointers returned from third-party libraries,
        /// where you cannot determine the memory management behavior in the third-party DLL.
        /// </para>
        /// <para>
        /// Threads in a process are expected to cooperate in such a way that one will not free memory that the other needs.
        /// Use of this function does not negate the need to do this.
        /// If this is not done, the application may fail in an unpredictable manner.
        /// </para>
        /// <para>
        /// Dereferencing potentially invalid pointers can disable stack expansion in other threads.
        /// A thread exhausting its stack, when stack expansion has been disabled,
        /// results in the immediate termination of the parent process, with no pop-up error window or diagnostic information.
        /// </para>
        /// <para>
        /// If the calling process has write access to some, but not all, of the bytes in the specified memory range, the return value is nonzero.
        /// </para>
        /// <para>
        /// In a preemptive multitasking environment, it is possible for some other thread to change the process's access to the memory being tested.
        /// Even when the function indicates that the process has write access to the specified memory,
        /// you should use structured exception handling when attempting to access the memory.
        /// Use of structured exception handling enables the system to notify the process
        /// if an access violation exception occurs, giving the process an opportunity to handle the exception.
        /// </para>
        /// <para>
        /// <see cref="IsBadWritePtr"/> is not multithread safe.
        /// To use it properly on a pointer shared by multiple threads,
        /// call it inside a critical region of code that allows only one thread to access the memory being checked.
        /// Use operating system–level objects such as critical sections or mutexes or the interlocked functions to create the critical region of code.
        /// </para>
        /// </remarks>
        [Obsolete("This function is obsolete and should not be used. " +
            "Despite its name, it does not guarantee that the pointer is valid or that the memory pointed to is safe to use. " +
            "For more information, see Remarks on this page.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsBadWritePtr", ExactSpelling = true)]
        public static extern BOOL IsBadWritePtr([In] LPVOID lp, [In] UINT_PTR ucb);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpProc"></param>
        /// <param name="hInstance"></param>
        /// <returns></returns>
        [Obsolete]
        public static FARPROC MakeProcInstance(FARPROC lpProc, HINSTANCE hInstance) => lpProc;

        /// <summary>
        /// <para>
        /// Multiplies two 32-bit values and then divides the 64-bit result by a third 32-bit value.
        /// The final result is rounded to the nearest integer.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-muldiv"/>
        /// </para>
        /// </summary>
        /// <param name="nNumber">
        /// The multiplicand.
        /// </param>
        /// <param name="nNumerator">
        /// The multiplier.
        /// </param>
        /// <param name="nDenominator">
        /// The number by which the result of the multiplication operation is to be divided.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the result of the multiplication and division, rounded to the nearest integer.
        /// If the result is a positive half integer (ends in .5), it is rounded up.
        /// If the result is a negative half integer, it is rounded down.
        /// </para>
        /// <para>
        /// If either an overflow occurred or <paramref name="nDenominator"/> was 0, the return value is -1.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "MulDiv", ExactSpelling = true)]
        public static extern int MulDiv([In] int nNumber, [In] int nNumerator, [In] int nDenominator);

        /// <summary>
        /// <para>
        /// Retrieves the current value of the performance counter, which is a high resolution (&lt;1us) time stamp
        /// that can be used for time-interval measurements.
        /// </para>
        /// <para>
        /// https://learn.microsoft.com/en-us/windows/win32/api/profileapi/nf-profileapi-queryperformancecounter
        /// </para>
        /// </summary>
        /// <param name="lpPerformanceCount">
        /// A pointer to a variable that receives the current performance-counter value, in counts.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// On systems that run Windows XP or later, the function will always succeed and will thus never return zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// For more info about this function and its usage, see Acquiring high-resolution time stamps.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "QueryPerformanceCounter", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL QueryPerformanceCounter([Out] out LARGE_INTEGER lpPerformanceCount);

        /// <summary>
        /// <para>
        /// Retrieves the frequency of the performance counter.
        /// The frequency of the performance counter is fixed at system boot and is consistent across all processors.
        /// Therefore, the frequency need only be queried upon application initialization, and the result can be cached.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/profileapi/nf-profileapi-queryperformancefrequency"/>
        /// </para>
        /// </summary>
        /// <param name="lpFrequency">
        /// A pointer to a variable that receives the current performance-counter frequency, in counts per second.
        /// If the installed hardware doesn't support a high-resolution performance counter, this parameter can be zero
        /// (this will not occur on systems that run Windows XP or later).
        /// </param>
        /// <returns>
        /// <para>
        /// If the installed hardware supports a high-resolution performance counter, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// On systems that run Windows XP or later, the function will always succeed and will thus never return zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// For more info about this function and its usage, see Acquiring high-resolution time stamps.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "QueryPerformanceFrequency", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL QueryPerformanceFrequency([Out] out LARGE_INTEGER lpFrequency);

        /// <summary>
        /// <para>
        /// Initiates an unwind of procedure call frames.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/nf-winnt-rtlunwind"/>
        /// </para>
        /// </summary>
        /// <param name="TargetFrame">
        /// A pointer to the call frame that is the target of the unwind.
        /// If this parameter is <see cref="NULL"/>, the function performs an exit unwind.
        /// </param>
        /// <param name="TargetIp">
        /// The continuation address of the unwind.
        /// This parameter is ignored if <paramref name="TargetFrame"/> is <see cref="NULL"/>.
        /// </param>
        /// <param name="ExceptionRecord">
        /// A pointer to an <see cref="EXCEPTION_RECORD"/> structure.
        /// </param>
        /// <param name="ReturnValue">
        /// A value to be placed in the integer function return register before continuing execution.
        /// </param>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "RtlUnwind", ExactSpelling = true, SetLastError = true)]
        public static extern void RtlUnwind([In] PVOID TargetFrame, [In] PVOID TargetIp, [In] in EXCEPTION_RECORD ExceptionRecord, [In] PVOID ReturnValue);

        /// <summary>
        /// <para>
        /// Suspends the system by shutting power down.
        /// Depending on the <paramref name="fForce"/> parameter,
        /// the function either suspends operation immediately or requests permission from all applications and device drivers before doing so.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-setsystempowerstate"/>
        /// </para>
        /// </summary>
        /// <param name="fSuspend">
        /// If this parameter is <see cref="TRUE"/>, the system is suspended.
        /// If the parameter is <see cref="FALSE"/>, the system hibernates.
        /// </param>
        /// <param name="fForce">
        /// This parameter has no effect.
        /// </param>
        /// <returns>
        /// <para>
        /// If power has been suspended and subsequently restored, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the system was not suspended, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The calling process must have the <see cref="SE_SHUTDOWN_NAME"/> privilege.
        /// To enable the <see cref="SE_SHUTDOWN_NAME"/> privilege, use the <see cref="AdjustTokenPrivileges"/> function.
        /// For more information, see Changing Privileges in a Token.
        /// </para>
        /// <para>
        /// If any application or driver denies permission to suspend operation,
        /// the function broadcasts a <see cref="PBT_APMQUERYSUSPENDFAILED"/> event to each application and driver.
        /// If power is suspended, this function returns only after system operation is resumed
        /// and related <see cref="WM_POWERBROADCAST"/> messages have been broadcast to all applications and drivers.
        /// </para>
        /// <para>
        /// This function is similar to the <see cref="SetSuspendState"/> function.
        /// </para>
        /// </remarks>
        [Obsolete("SetSystemPowerState is available for use in the operating systems specified in the Requirements section. " +
            "It may be altered or unavailable in subsequent versions. " +
            "Applications written for Windows Vista and later should use SetSuspendState instead.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetSystemPowerState", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetSystemPowerState([In] BOOL fSuspend, [In] BOOL fForce);

        /// <summary>
        /// <para>
        /// Sets the label of a file system volume.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-setvolumelabelw"/>
        /// </para>
        /// </summary>
        /// <param name="lpRootPathName">
        /// A pointer to a string that contains the volume's drive letter (for example, X:)
        /// or the path of a mounted folder that is associated with the volume (for example, Y:\MountX).
        /// The string must end with a trailing backslash ('').
        /// If this parameter is <see cref="NULL"/>, the root of the current directory is used.
        /// </param>
        /// <param name="lpVolumeName">
        /// A pointer to a string that contains the new label for the volume.
        /// If this parameter is <see cref="NULL"/>,
        /// the function deletes any existing label from the specified volume and does not assign a new label.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The maximum volume label length is 32 characters.
        /// </para>
        /// <para>
        /// FAT filesystems:
        /// The maximum volume label length is 11 characters.
        /// </para>
        /// <para>
        /// A label is a user-friendly name that a user assigns to a volume to make it easier to recognize.
        /// A volume can have a label, a drive letter, both, or neither.
        /// For more information, see Naming a Volume.
        /// </para>
        /// <para>
        /// In Windows 8 and Windows Server 2012, this function is supported by the following technologies.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Technology
        /// </term>
        /// <term>
        /// Supported
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Server Message Block (SMB) 3.0 protocol
        /// </term>
        /// <term>
        /// No
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// SMB 3.0 Transparent Failover (TFO)
        /// </term>
        /// <term>
        /// No
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// SMB 3.0 with Scale-out File Shares (SO)
        /// </term>
        /// <term>
        /// No
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Cluster Shared Volume File System (CsvFS)
        /// </term>
        /// <term>
        /// Yes
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Resilient File System (ReFS)
        /// </term>
        /// <term>
        /// Yes
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// SMB does not support volume management functions.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetVolumeLabelW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetVolumeLabel([In] LPCWSTR lpRootPathName, [In] LPCWSTR lpVolumeName);

        /// <summary>
        /// <para>
        /// Runs the specified application.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-winexec"/>
        /// </para>
        /// </summary>
        /// <param name="lpCmdLine">
        /// <para>
        /// The command line (file name plus optional parameters) for the application to be executed.
        /// If the name of the executable file in the <paramref name="lpCmdLine"/> parameter does not contain a directory path,
        /// the system searches for the executable file in this sequence:
        /// </para>
        /// <para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// The directory from which the application loaded.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The current directory.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The Windows system directory. The <see cref="GetSystemDirectory"/> function retrieves the path of this directory.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The Windows directory. The <see cref="GetWindowsDirectory"/> function retrieves the path of this directory.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The directories listed in the PATH environment variable.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="uCmdShow">
        /// The display options.
        /// For a list of the acceptable values, see the description of the nCmdShow parameter of the <see cref="ShowWindow"/> function.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is greater than 31.
        /// </para>
        /// <para>
        /// If the function fails, the return value is one of the following error values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code/value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0
        /// </term>
        /// <term>
        /// The system is out of memory or resources.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_BAD_FORMAT"/>
        /// </term>
        /// <term>
        /// The .exe file is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_FILE_NOT_FOUND"/>
        /// </term>
        /// <term>
        /// The specified file was not found.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_PATH_NOT_FOUND"/>
        /// </term>
        /// <term>
        /// The specified path was not found.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="WinExec"/> function returns when the started process calls the <see cref="GetMessage"/> function or a time-out limit is reached.
        /// To avoid waiting for the time out delay, call the <see cref="GetMessage"/> function
        /// as soon as possible in any process started by a call to <see cref="WinExec"/>.
        /// </para>
        /// <para>
        /// Security Remarks
        /// </para>
        /// <para>
        /// The executable name is treated as the first white space-delimited string in <paramref name="lpCmdLine"/>.
        /// If the executable or path name has a space in it, there is a risk that a different executable could be run because of the way the function parses spaces.
        /// The following example is dangerous because the function will attempt to run "Program.exe", if it exists, instead of "MyApp.exe".
        /// </para>
        /// <code>
        /// WinExec("C:\\Program Files\\MyApp", ...)
        /// </code>
        /// <para>
        /// If a malicious user were to create an application called "Program.exe" on a system,
        /// any program that incorrectly calls <see cref="WinExec"/> using the Program Files directory will run this application instead of the intended application.
        /// </para>
        /// <para>
        /// To avoid this problem, use <see cref="CreateProcess"/> rather than <see cref="WinExec"/>.
        /// However, if you must use <see cref="WinExec"/> for legacy reasons,
        /// make sure the application name is enclosed in quotation marks as shown in the example below.
        /// </para>
        /// <code>
        /// WinExec("\"C:\\Program Files\\MyApp.exe\" -L -S", ...)
        /// </code>
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit Windows. Applications should use the CreateProcess function.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WinExec", ExactSpelling = true)]
        public static extern UINT WinExec([In] LPCSTR lpCmdLine, [In] ShowWindowCommands uCmdShow);

        /// <summary>
        /// Retrieves the session identifier of the console session. 
        /// The console session is the session that is currently attached to the physical console. 
        /// Note that it is not necessary that Remote Desktop Services be running for this function to succeed.
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-wtsgetactiveconsolesessionid"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// The session identifier of the session that is attached to the physical console. 
        /// If there is no session attached to the physical console, (for example, 
        /// if the physical console session is in the process of being attached or detached), this function returns 0xFFFFFFFF.
        /// </returns>
        /// <remarks>
        /// The session identifier returned by this function is the identifier of the current physical console session. 
        /// To monitor the state of the current physical console session, use the<see cref="WTSRegisterSessionNotification"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("Kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WTSGetActiveConsoleSessionId", ExactSpelling = true)]
        public static extern DWORD WTSGetActiveConsoleSessionId();

        /// <summary>
        /// <para>
        /// Fills a block of memory with zeros.
        /// </para>
        /// <para>
        /// To avoid any undesired effects of optimizing compilers, use the <see cref="SecureZeroMemory"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/aa366920(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="Destination">
        /// A pointer to the starting address of the block of memory to fill with zeros.
        /// </param>
        /// <param name="Length">
        /// The size of the block of memory to fill with zeros, in bytes.
        /// </param>
        /// <remarks>
        /// <para>
        /// Many programming languages include syntax for initializing complex variables to zero.
        /// There can be differences between the results of these operations and the <see cref="ZeroMemory"/> function.
        /// Use <see cref="ZeroMemory"/> to clear a block of memory in any programming language.
        /// </para>
        /// <para>
        /// This macro is defined as the RtlZeroMemory macro.
        /// For more information, see WinBase.h and WinNT.h.
        /// </para>
        /// </remarks>
        public static unsafe void ZeroMemory([In] PVOID Destination, [In] SIZE_T Length) => Unsafe.InitBlock(Destination, 0, (uint)(IntPtr)Length);
    }
}
