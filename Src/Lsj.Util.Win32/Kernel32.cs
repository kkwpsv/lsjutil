using Lsj.Util.IL;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.LCID;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.EnumSystemCodePagesFlags;
using static Lsj.Util.Win32.Enums.GetDateFormatFlags;
using static Lsj.Util.Win32.Enums.GetTimeFormatFlags;
using static Lsj.Util.Win32.Enums.LoadLibraryExFlags;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
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
        /// NUMA_NO_PREFERRED_NODE
        /// </summary>
        public const uint NUMA_NO_PREFERRED_NODE = 0xffffffff;

        /// <summary>
        /// <para>
        /// An application-defined callback function that processes enumerated code page information
        /// provided by the <see cref="EnumSystemCodePages"/> function.
        /// The <see cref="CODEPAGE_ENUMPROC"/> type defines a pointer to this callback function.
        /// EnumCodePagesProc is a placeholder for the application-defined function name.
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
        /// An EnumCodePagesProc function can carry out any desired task.
        /// The application registers this function by passing its address to the <see cref="EnumSystemCodePages"/> function.
        /// When an application is using this function to determine an appropriate code page for saving data, it should use Unicode when possible.
        /// Other code pages are not as portable as Unicode between vendors or operating systems,
        /// due to different implementations of the associated standards.
        /// </remarks>
        public delegate BOOL Codepageenumproc([In] LPWSTR lpCodePageString);


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
        /// If the function succeeds, it returns <see cref="TRUE"/>.
        /// Otherwise, it returns <see cref="FALSE"/>.
        /// This function sets errors that can be retrieved by calling <see cref="GetLastError"/>.
        /// For an example, see Retrieving the Last-Error Code.
        /// For a complete list of error codes, see System Error Codes.
        /// </returns>
        /// <remarks>
        /// The <paramref name="lpCookie"/> parameter is later passed to <see cref="DeactivateActCtx"/>,
        /// which verifies the pairing of calls to <see cref="ActivateActCtx"/> and <see cref="DeactivateActCtx"/>
        /// and ensures that the appropriate activation context is being deactivated.
        /// This is done because the deactivation of activation contexts must occur in the reverse order of activation.
        /// The activation of activation contexts can be understood as pushing an activation context onto a stack of activation contexts.
        /// The activation context you activate through this function redirects any binding to DLLs, window classes,
        /// COM servers, type libraries, and mutexes for any side-by-side APIs you call.
        /// The top item of an activation context stack is the active, default-activation context of the current thread.
        /// If a null activation context handle is pushed onto the stack, thereby activating it,
        /// the default settings in the original manifest override all activation contexts that are lower on the stack.
        /// </remarks>
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
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// A long time ago, all PC computers shared a common 8254 programable interval timer chip for the generation of primitive sounds.
        /// The <see cref="Beep"/> function was written specifically to emit a beep on that piece of hardware.
        /// On these older systems, muting and volume controls have no effect on <see cref="Beep"/>; you would still hear the tone.
        /// To silence the tone, you used the following commands:
        /// net stop beep
        /// sc config beep start= disabled
        /// Since then, sound cards have become standard equipment on almost all PC computers.
        /// As sound cards became more common, manufacturers began to remove the old timer chip from computers.
        /// The chips were also excluded from the design of server computers.
        /// The result is that <see cref="Beep"/> did not work on all computers without the chip.
        /// This was okay because most developers had moved on to calling the <see cref="MessageBeep"/> function
        /// that uses whatever is the default sound device instead of the 8254 chip.
        /// Eventually because of the lack of hardware to communicate with,
        /// support for <see cref="Beep"/> was dropped in Windows Vista and Windows XP 64-Bit Edition.
        /// In Windows 7, <see cref="Beep"/> was rewritten to pass the beep to the default sound device for the session.
        /// This is normally the sound card, except when run under Terminal Services, in which case the beep is rendered on the client.
        /// </remarks>
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
        /// If the function succeeds, it returns a handle to the returned activation context.
        /// Otherwise, it returns <see cref="INVALID_HANDLE_VALUE"/>.
        /// This function sets errors that can be retrieved by calling <see cref="GetLastError"/>.
        /// For an example, see Retrieving the Last-Error Code.
        /// For a complete list of error codes, see System Error Codes.
        /// </returns>
        /// <remarks>
        /// Set any undefined bits in <see cref="ACTCTX.dwFlags"/> of <see cref="ACTCTX"/> to 0.
        /// If any undefined bits are not set to 0, the call to <see cref="CreateActCtx"/> that creates the activation context fails and returns an invalid parameter error code.
        /// The handle returned from <see cref="CreateActCtx"/> is passed in a call to <see cref="ActivateActCtx"/> to activate the context for the current thread.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateActCtxW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE CreateActCtx([In][Out] ref ACTCTX pActCtx);

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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DecodePointer", ExactSpelling = true, SetLastError = true)]
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DecodeSystemPointer", ExactSpelling = true, SetLastError = true)]
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
        /// Encoding globally available pointers helps protect them from being exploited.
        /// The <see cref="EncodePointer"/> function obfuscates the pointer value with a secret so that it cannot be predicted by an external agent.
        /// The secret used by <see cref="EncodePointer"/> is different for each process.
        /// A pointer must be decoded before it can be used.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "EncodePointer", ExactSpelling = true, SetLastError = true)]
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
        /// Encoding globally available pointers helps protect them from being exploited.
        /// The <see cref="EncodeSystemPointer"/> function obfuscates the pointer value with a secret so that it cannot be predicted by an external agent.
        /// The secret used by EncodeSystemPointer is the same for each process on a given computer, and is known to all the processes on that computer.
        /// A pointer must be decoded before it can be used.
        /// Using <see cref="EncodeSystemPointer"/>/<see cref="DecodeSystemPointer"/> is faster than using <see cref="EncodePointer"/>/<see cref="DecodePointer"/>,
        /// but the encoded system pointers are more vulnerable to attack because the value can be predicted on a per-machine basis.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "EncodeSystemPointer", ExactSpelling = true, SetLastError = true)]
        public static extern PVOID EncodeSystemPointer([In] PVOID Ptr);

        /// <summary>
        /// <para>
        /// Enumerates the code pages that are either installed on or supported by an operating system.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnls/nf-winnls-enumsystemcodepagesw"/>
        /// </para>
        /// </summary>
        /// <param name="lpCodePageEnumProc">
        /// Pointer to an application-defined callback function.
        /// The <see cref="EnumSystemCodePages"/> function enumerates code pages by making repeated calls to this callback function.
        /// For more information, see <see cref="CODEPAGE_ENUMPROC"/>.
        /// </param>
        /// <param name="dwFlags">
        /// Flag specifying the code pages to enumerate.
        /// This parameter can have one of the following values, which are mutually exclusive.
        /// <see cref="CP_INSTALLED"/>: Enumerate only installed code pages.
        /// <see cref="CP_SUPPORTED"/>: Enumerate all supported code pages.
        /// </param>
        /// <returns>
        /// Returns a nonzero value if successful, or 0 otherwise.
        /// To get extended error information, the application can call <see cref="GetLastError"/>,
        /// which can return one of the following error codes:
        /// <see cref="ERROR_BADDB"/>:
        /// The function could not access the data.
        /// This situation should not normally occur, and typically indicates a bad installation, a disk problem, or the like.
        /// <see cref="ERROR_INVALID_FLAGS"/>:
        /// The values supplied for flags were not valid.
        /// <see cref="ERROR_INVALID_PARAMETER"/>:
        /// Any of the parameter values was invalid.
        /// </returns>
        /// <remarks>
        /// This function enumerates the code pages by passing code page identifiers, one at a time,
        /// to the specified application-defined callback function.
        /// This process continues until all installed or supported code page identifiers have been passed to the callback function,
        /// or the callback function returns <see cref="FALSE"/>.
        /// When an application is using this function to determine an appropriate code page for saving data, it should use Unicode when possible.
        /// Other code pages are not as portable as Unicode between vendors or operating systems,
        /// due to different implementations of the associated standards.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumSystemCodePagesW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnumSystemCodePages([In] CODEPAGE_ENUMPROC lpCodePageEnumProc, [In] EnumSystemCodePagesFlags dwFlags);

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
        /// Formats a date as a date string for a locale specified by the locale identifier.
        /// The function formats either a specified date or the local system date.
        /// Note
        /// For interoperability reasons, the application should prefer the <see cref="GetDateFormatEx"/> function to <see cref="GetDateFormat"/>
        /// because Microsoft is migrating toward the use of locale names instead of locale identifiers for new locales.
        /// Any application that will be run only on Windows Vista and later should use <see cref="GetDateFormatEx"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/datetimeapi/nf-datetimeapi-getdateformatw"/>
        /// </para>
        /// </summary>
        /// <param name="Locale">
        /// Locale identifier that specifies the locale this function formats the date string for.
        /// You can use the <see cref="MAKELCID"/> macro to create a locale identifier or use one of the following predefined values.
        /// <see cref="LOCALE_CUSTOM_DEFAULT"/>, <see cref="LOCALE_CUSTOM_UI_DEFAULT"/>, <see cref="LOCALE_CUSTOM_UNSPECIFIED"/>,
        /// <see cref="LOCALE_INVARIANT"/>, <see cref="LOCALE_SYSTEM_DEFAULT"/>, <see cref="LOCALE_USER_DEFAULT"/>
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
        /// Pointer to a format picture string that is used to form the date.
        /// Possible values for the format picture string are defined in Day, Month, Year, and Era Format Pictures.
        /// The function uses the specified locale only for information not specified in the format picture string,
        /// for example, the day and month names for the locale.
        /// The application can set this parameter to <see cref="NULL"/> to format the string according to the date format for the specified locale.
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
        /// Returns the number of characters written to the <paramref name="lpDateStr"/> buffer if successful.
        /// If the cchDate parameter is set to 0, the function returns the number of characters required to hold the formatted date string,
        /// including the terminating null character.
        /// The function returns 0 if it does not succeed.
        /// To get extended error information, the application can call <see cref="GetLastError"/>,
        /// which can return one of the following error codes:
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>. A supplied buffer size was not large enough, or it was incorrectly set to NULL
        /// <see cref="ERROR_INVALID_FLAGS"/>. The values supplied for flags were not valid.
        /// <see cref="ERROR_INVALID_PARAMETER"/>. Any of the parameter values was invalid.
        /// </returns>
        /// <remarks>
        /// Note
        /// This API is being updated to support the May 2019 Japanese era change.
        /// If your application supports the Japanese calendar, you should validate that it properly handles the new era.
        /// See Prepare your application for the Japanese era change for more information.
        /// See Remarks for <see cref="GetDateFormatEx"/>.
        /// When the ANSI version of this function is used with a Unicode-only locale identifier,
        /// the function can succeed because the operating system uses the system code page.
        /// However, characters that are undefined in the system code page appear in the string as a question mark ("?").
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDateFormatW", ExactSpelling = true, SetLastError = true)]
        public static extern int GetDateFormat([In] LCID Locale, [In] GetDateFormatFlags dwFlags, [In] in SYSTEMTIME lpDate,
            [In] LPCWSTR lpFormat, [In] LPWSTR lpDateStr, [In] int cchDate);

        /// <summary>
        /// <para>
        /// Formats a date as a date string for a locale specified by name.
        /// The function formats either a specified date or the local system date.
        /// Note
        /// The application should call this function in preference to GetDateFormat if designed to run only on Windows Vista and later.
        /// Note
        /// This function can format data that changes between releases, for example, due to a custom locale.
        /// If your application must persist or transmit data, see Using Persistent Locale Data.
        /// </para>
        /// </summary>
        /// <param name="Locale">
        /// Pointer to a locale name, or one of the following predefined values.
        /// <see cref="LOCALE_NAME_INVARIANT"/>, <see cref="LOCALE_NAME_SYSTEM_DEFAULT"/>, <see cref="LOCALE_NAME_USER_DEFAULT"/>
        /// </param>
        /// <param name="dwFlags">
        /// Flags specifying various function options that can be set if <paramref name="lpFormat"/> is set to <see cref="NULL"/>.
        /// The application can specify a combination of the following values and <see cref="LOCALE_USE_CP_ACP"/> or <see cref="LOCALE_NOUSEROVERRIDE"/>.
        /// Caution
        /// Use of <see cref="LOCALE_NOUSEROVERRIDE"/> is strongly discouraged as it disables user preferences.
        /// If the application does not specify <see cref="DATE_YEARMONTH"/>, <see cref="DATE_MONTHDAY"/>,
        /// <see cref="DATE_SHORTDATE"/>, or <see cref="DATE_LONGDATE"/>, and <paramref name="lpFormat"/> is set to <see cref="NULL"/>,
        /// <see cref="DATE_SHORTDATE"/> is the default.
        /// </param>
        /// <param name="lpDate">
        /// Pointer to a <see cref="SYSTEMTIME"/> structure that contains the date information to format.
        /// The application can set this parameter to <see cref="NullRef{SYSTEMTIME}"/> if the function is to use the current local system date.
        /// </param>
        /// <param name="lpFormat">
        /// Pointer to a format picture string that is used to form the date.
        /// Possible values for the format picture string are defined in Day, Month, Year, and Era Format Pictures.
        /// For example, to get the date string "Wed, Aug 31 94", the application uses the picture string "ddd',' MMM dd yy".
        /// The function uses the specified locale only for information not specified in the format picture string,
        /// for example, the day and month names for the locale.
        /// The application can set this parameter to NULL to format the string according to the date format for the specified locale.
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
        /// Returns the number of characters written to the <paramref name="lpDateStr"/> buffer if successful.
        /// If the <paramref name="cchDate"/> parameter is set to 0,
        /// the function returns the number of characters required to hold the formatted date string, including the terminating null character.
        /// This function returns 0 if it does not succeed.
        /// To get extended error information, the application can call <see cref="GetLastError"/>,
        /// which can return one of the following error codes:
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>. A supplied buffer size was not large enough, or it was incorrectly set to NULL.
        /// <see cref="ERROR_INVALID_FLAGS"/>. The values supplied for flags were not valid.
        /// <see cref="ERROR_INVALID_PARAMETER"/>. Any of the parameter values was invalid.
        /// </returns>
        /// <remarks>
        /// This API is being updated to support the May 2019 Japanese era change.
        /// If your application supports the Japanese calendar, you should validate that it properly handles the new era.
        /// See Prepare your application for the Japanese era change for more information.
        /// The earliest date supported by this function is January 1, 1601.
        /// The day name, abbreviated day name, month name, and abbreviated month name are all localized based on the locale identifier.
        /// The date values in the structure indicated by <paramref name="lpDate"/> must be valid.
        /// The function checks each of the date values: year, month, day, and day of week.
        /// If the day of the week is incorrect, the function uses the correct value, and returns no error.
        /// If any of the other date values are outside the correct range, the function fails, and sets the last error to <see cref="ERROR_INVALID_PARAMETER"/>.
        /// The function ignores the time members of the <see cref="SYSTEMTIME"/> structure indicated by <paramref name="lpDate"/>.
        /// These include <see cref="SYSTEMTIME.wHour"/>, <see cref="SYSTEMTIME.wMinute"/>,
        /// <see cref="SYSTEMTIME.wSecond"/>, and <see cref="SYSTEMTIME.wMilliseconds"/>.
        /// If the <paramref name="lpFormat"/> parameter contains a bad format string,
        /// the function returns no errors, but just forms the best possible date string.
        /// For example, the only year pictures that are valid are L"yyyy" and L"yy", where the "L" indicates a Unicode (16-bit characters) string.
        /// If L"y" is passed in, the function assumes L"yy". If L"yyy" is passed in, the function assumes L"yyyy".
        /// If more than four date (L"dddd") or four month (L"MMMM") pictures are passed in, the function defaults to L"dddd" or L"MMMM".
        /// The application should enclose any text that should remain in its exact form in the date string within single quotation marks in the date format picture.
        /// The single quotation mark can also be used as an escape character to allow the single quotation mark itself to be displayed in the date string.
        /// However, the escape sequence must be enclosed within two single quotation marks.
        /// For example, to display the date as "May '93", the format string is: L"MMMM ''''yy".
        /// The first and last single quotation marks are the enclosing quotation marks.
        /// The second and third single quotation marks are the escape sequence to allow the single quotation mark to be displayed before the century.
        /// When the date picture contains both a numeric form of the day (either d or dd) and the full month name (MMMM),
        /// the genitive form of the month name is retrieved in the date string.
        /// To obtain the default short and long date format without performing any actual formatting,
        /// the application should use <see cref="GetLocaleInfoEx"/> with the <see cref="LOCALE_SSHORTDATE"/> or <see cref="LOCALE_SLONGDATE"/> constant.
        /// To get the date format for an alternate calendar, the application uses <see cref="GetLocaleInfoEx"/> with the <see cref="LOCALE_IOPTIONALCALENDAR"/> constant.
        /// To get the date format for a particular calendar, the application uses <see cref="GetCalendarInfoEx"/>, passing the appropriate Calendar Identifier.
        /// It can call <see cref="EnumCalendarInfoEx"/> or <see cref="EnumDateFormatsEx"/> to retrieve date formats for a particular calendar.
        /// This function can retrieve data from custom locales.
        /// Data is not guaranteed to be the same from computer to computer or between runs of an application.
        /// If your application must persist or transmit data, see Using Persistent Locale Data.
        /// The <see cref="DATE_LONGDATE"/> format includes two kinds of date patterns:
        /// patterns that include the day of the week and patterns that do not include the day of the week.
        /// For example, "Tuesday, October 18, 2016" or "October 18, 2016".
        /// If your application needs to ensure that dates use one of these kinds of patterns and not the other kind,
        /// your application should perform the following actions:
        /// Call the <see cref="EnumDateFormatsExEx"/> function to get all of the date formats for the <see cref="DATE_LONGDATE"/> format.
        /// Look for the first date format passed to the callback function that you specified for <see cref="EnumDateFormatsExEx"/>
        /// that matches your requested calendar identifier and has a date format string that matches the requirements of your application.
        /// For example, look for the first date format that includes "dddd" if your application requires that
        /// the date include the full name of the day of the week, or look for the first date format that includes neither "ddd" nor "dddd"
        /// if your application requires that the date includes nether the abbreviated name nor the full name of the day of the week.
        /// Call the <see cref="GetDateFormatEx"/> function with the <paramref name="lpFormat"/> parameter set to the date format string
        /// that you identified as the appropriate format in the callback function.
        /// If the presence or absence of the day of the week in the long date format does not matter to your application,
        /// your application can call <see cref="GetDateFormatEx"/> directly without first enumerating all of the long date formats by calling <see cref="EnumDateFormatsExEx"/>.
        /// Beginning in Windows 8:
        /// If your app passes language tags to this function from the Windows.Globalization namespace,
        /// it must first convert the tags by calling ResolveLocaleName.
        /// Beginning in Windows 8:
        /// <see cref="GetDateFormatEx"/> is declared in Datetimeapi.h. Before Windows 8, it was declared in Winnls.h.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDateFormatEx", ExactSpelling = true, SetLastError = true)]
        public static extern int GetDateFormatEx([In] LCID Locale, [In] GetDateFormatFlags dwFlags, [In] in SYSTEMTIME lpDate,
            [In] LPCWSTR lpFormat, [In] LPWSTR lpDateStr, [In] int cchDate, [In] LPCWSTR lpCalendar);

        /// <summary>
        /// <para>
        /// Retrieves the address of an exported function or variable from the specified dynamic-link library (DLL).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/libloaderapi/nf-libloaderapi-getprocaddress"/>
        /// </para>
        /// </summary>
        /// <param name="hModule">
        /// A handle to the DLL module that contains the function or variable.
        /// The <see cref="LoadLibrary"/>, <see cref="LoadLibraryEx"/>, <see cref="LoadPackagedLibrary"/>,
        /// or <see cref="GetModuleHandle"/> function returns this handle.
        /// The <see cref="GetProcAddress"/> function does not retrieve addresses from modules
        /// that were loaded using the <see cref="LOAD_LIBRARY_AS_DATAFILE"/> flag.
        /// For more information, see <see cref="LoadLibraryEx"/>.
        /// </param>
        /// <param name="lpProcName">
        /// The function or variable name, or the function's ordinal value.
        /// If this parameter is an ordinal value, it must be in the low-order word; the high-order word must be zero.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the address of the exported function or variable.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The spelling and case of a function name pointed to by <paramref name="lpProcName"/> must be identical to that
        /// in the EXPORTS statement of the source DLL's module-definition (.def) file.
        /// The exported names of functions may differ from the names you use when calling these functions in your code.
        /// This difference is hidden by macros used in the SDK header files.
        /// For more information, see Conventions for Function Prototypes.
        /// The <paramref name="lpProcName"/> parameter can identify the DLL function by specifying an ordinal value
        /// associated with the function in the EXPORTS statement.
        /// <see cref="GetProcAddress"/> verifies that the specified ordinal is in the range 1 through the highest ordinal value exported in the .def file.
        /// The function then uses the ordinal as an index to read the function's address from a function table.
        /// If the .def file does not number the functions consecutively from 1 to N (where N is the number of exported functions),
        /// an error can occur where <see cref="GetProcAddress"/> returns an invalid, non-NULL address,
        /// even though there is no function with the specified ordinal.
        /// If the function might not exist in the DLL module—for example, if the function is available only on Windows Vista
        /// but the application might be running on Windows XP—specify the function by name rather than by ordinal value
        /// and design your application to handle the case when the function is not available, as shown in the following code fragment.
        /// <code>
        /// typedef void (WINAPI *PGNSI)(LPSYSTEM_INFO);
        /// // Call GetNativeSystemInfo if supported or GetSystemInfo otherwise.
        /// PGNSI pGNSI;
        /// SYSTEM_INFO si;
        /// ZeroMemory(&amp;si, sizeof(SYSTEM_INFO));
        /// pGNSI = (PGNSI) GetProcAddress(GetModuleHandle(TEXT("kernel32.dll")), "GetNativeSystemInfo");
        /// if(NULL != pGNSI)
        /// {
        ///     pGNSI(&amp;si);
        /// }
        /// else 
        /// {
        ///     GetSystemInfo(&amp;si);
        /// }
        /// </code>
        /// For the complete example that contains this code fragment, see Getting the System Version.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetProcAddress", ExactSpelling = true, SetLastError = true, ThrowOnUnmappableChar = true)]
        public static extern FARPROC GetProcAddress([In] HMODULE hModule, [MarshalAs(UnmanagedType.LPStr)][In] string lpProcName);

        /// <summary>
        /// <para>
        /// Formats time as a time string for a locale specified by identifier.
        /// The function formats either a specified time or the local system time.
        /// Note
        /// For interoperability reasons, the application should prefer the <see cref="GetTimeFormatEx"/> function to <see cref="GetTimeFormat"/>
        /// because Microsoft is migrating toward the use of locale names instead of locale identifiers for new locales.
        /// Any application that will be run only on Windows Vista and later should use <see cref="GetTimeFormatEx"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/datetimeapi/nf-datetimeapi-gettimeformatw"/>
        /// </para>
        /// </summary>
        /// <param name="Locale">
        /// Locale identifier that specifies the locale.
        /// You can use the <see cref="MAKELCID"/> macro to create a locale identifier or use one of the following predefined values.
        /// <see cref="LOCALE_CUSTOM_DEFAULT"/>, <see cref="LOCALE_CUSTOM_UI_DEFAULT"/>, <see cref="LOCALE_CUSTOM_UNSPECIFIED"/>,
        /// <see cref="LOCALE_INVARIANT"/>,  <see cref="LOCALE_SYSTEM_DEFAULT"/>, <see cref="LOCALE_USER_DEFAULT"/>
        /// </param>
        /// <param name="dwFlags">
        /// Flags specifying time format options.
        /// For detailed definitions see the <paramref name="dwFlags"/> parameter of <see cref="GetTimeFormatEx"/>.
        /// </param>
        /// <param name="lpTime">
        /// Pointer to a <see cref="SYSTEMTIME"/> structure that contains the time information to format.
        /// The application can set this parameter to <see cref="NullRef{SYSTEMTIME}"/> if the function is to use the current local system time.
        /// </param>
        /// <param name="lpFormat">
        /// Pointer to a format picture to use to format the time string.
        /// If the application sets this parameter to <see cref="NULL"/>, the function formats the string according to the time format of the specified locale.
        /// If the application does not set the parameter to <see cref="NULL"/>, the function uses the locale only for information not specified
        /// in the format picture string, for example, the locale-specific time markers.
        /// For information about the format picture string, see the Remarks section.
        /// </param>
        /// <param name="lpTimeStr">
        /// Pointer to a buffer in which this function retrieves the formatted time string.
        /// </param>
        /// <param name="cchTime">
        /// Size, in TCHAR values, for the time string buffer indicated by <paramref name="lpTimeStr"/>.
        /// Alternatively, the application can set this parameter to 0.
        /// In this case, the function returns the required size for the time string buffer,
        /// and does not use the <paramref name="lpTimeStr"/> parameter.
        /// </param>
        /// <returns>
        /// Returns the number of TCHAR values retrieved in the buffer indicated by <paramref name="lpTimeStr"/>.
        /// If the <paramref name="cchTime"/> parameter is set to 0, the function returns the size of the buffer required
        /// to hold the formatted time string, including a terminating null character.
        /// This function returns 0 if it does not succeed.
        /// To get extended error information, the application can call <see cref="GetLastError"/>,
        /// which can return one of the following error codes:
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>. A supplied buffer size was not large enough, or it was incorrectly set to <see cref="NULL"/>.
        /// <see cref="ERROR_INVALID_FLAGS"/>. The values supplied for flags were not valid.
        /// <see cref="ERROR_INVALID_PARAMETER"/>. Any of the parameter values was invalid.
        /// <see cref="ERROR_OUTOFMEMORY"/>. Not enough storage was available to complete this operation.
        /// </returns>
        /// <remarks>
        /// See Remarks for <see cref="GetTimeFormatEx"/>.
        /// When the ANSI version of this function is used with a Unicode-only locale identifier,
        /// the function can succeed because the operating system uses the system code page.
        /// However, characters that are undefined in the system code page appear in the string as a question mark (?).
        /// Starting with Windows 8:
        /// GetTimeFormat is declared in Datetimeapi.h. Before Windows 8, it was declared in Winnls.h.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTimeFormatW", ExactSpelling = true, SetLastError = true)]
        public static extern int GetTimeFormat([In] LCID Locale, [In] GetTimeFormatFlags dwFlags, [In] in SYSTEMTIME lpTime, [In] LPCWSTR lpFormat,
            [In] LPWSTR lpTimeStr, [In] int cchTime);

        /// <summary>
        /// <para>
        /// Formats time as a time string for a locale specified by name.
        /// The function formats either a specified time or the local system time.
        /// Note
        /// The application should call this function in preference to GetTimeFormat if designed to run only on Windows Vista and later.
        /// Note
        /// This function can format data that changes between releases, for example, due to a custom locale.
        /// If your application must persist or transmit data, see Using Persistent Locale Data.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/datetimeapi/nf-datetimeapi-gettimeformatex"/>
        /// </para>
        /// </summary>
        /// <param name="lpLocaleName">
        /// Pointer to a locale name, or one of the following predefined values.
        /// <see cref="LOCALE_NAME_INVARIANT"/>, <see cref="LOCALE_NAME_SYSTEM_DEFAULT"/>, <see cref="LOCALE_NAME_USER_DEFAULT"/>
        /// </param>
        /// <param name="dwFlags">
        /// Flags specifying time format options.
        /// The application can specify a combination of the following values and <see cref="LOCALE_USE_CP_ACP"/> or <see cref="LOCALE_NOUSEROVERRIDE"/>.
        /// Caution
        /// Use of <see cref="LOCALE_NOUSEROVERRIDE"/> is strongly discouraged as it disables user preferences.
        /// <see cref="TIME_NOMINUTESORSECONDS"/>, <see cref="TIME_NOSECONDS"/>, <see cref="TIME_NOTIMEMARKER"/>, <see cref="TIME_FORCE24HOURFORMAT"/>
        /// </param>
        /// <param name="lpTime">
        /// Pointer to a <see cref="SYSTEMTIME"/> structure that contains the time information to format.
        /// The application can set this parameter to <see cref="NullRef{SYSTEMTIME}"/> if the function is to use the current local system time.
        /// </param>
        /// <param name="lpFormat">
        /// Pointer to a format picture to use to format the time string.
        /// If the application sets this parameter to <see cref="NULL"/>, the function formats the string according to the time format of the specified locale.
        /// If the application does not set the parameter to <see cref="NULL"/>, the function uses the locale only
        /// for information not specified in the format picture string, for example, the locale-specific time markers.
        /// For information about the format picture string, see the Remarks section.
        /// </param>
        /// <param name="lpTimeStr">
        /// Pointer to a buffer in which this function retrieves the formatted time string.
        /// </param>
        /// <param name="cchTime">
        /// Size, in characters, for the time string buffer indicated by <paramref name="lpTimeStr"/>.
        /// Alternatively, the application can set this parameter to 0.
        /// In this case, the function returns the required size for the time string buffer, and does not use the <paramref name="lpTimeStr"/> parameter.
        /// </param>
        /// <returns>
        /// Returns the number of TCHAR values retrieved in the buffer indicated by <paramref name="lpTimeStr"/>.
        /// If the <paramref name="cchTime"/> parameter is set to 0, the function returns the size of the buffer required
        /// to hold the formatted time string, including a terminating null character.
        /// This function returns 0 if it does not succeed.
        /// To get extended error information, the application can call <see cref="GetLastError"/>,
        /// which can return one of the following error codes:
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>. A supplied buffer size was not large enough, or it was incorrectly set to <see cref="NULL"/>.
        /// <see cref="ERROR_INVALID_FLAGS"/>. The values supplied for flags were not valid.
        /// <see cref="ERROR_INVALID_PARAMETER"/>. Any of the parameter values was invalid.
        /// <see cref="ERROR_OUTOFMEMORY"/>. Not enough storage was available to complete this operation.
        /// </returns>
        /// <remarks>
        /// If a time marker exists and the <see cref="TIME_NOTIMEMARKER"/> flag is not set,
        /// the function localizes the time marker based on the specified locale identifier.
        /// Examples of time markers are "AM" and "PM" for English (United States).
        /// The time values in the structure indicated by lpTime must be valid.
        /// The function checks each of the time values to determine that it is within the appropriate range of values.
        /// If any of the time values are outside the correct range, the function fails, and sets the last error to <see cref="ERROR_INVALID_PARAMETER"/>.
        /// The function ignores the date members of the <see cref="SYSTEMTIME"/> structure.
        /// These include: <see cref="SYSTEMTIME.wYear"/>, <see cref="SYSTEMTIME.wMonth"/>,
        /// <see cref="SYSTEMTIME.wDayOfWeek"/>, and <see cref="SYSTEMTIME.wDay"/>.
        /// If <see cref="TIME_NOMINUTESORSECONDS"/> or <see cref="TIME_NOSECONDS"/> is specified,
        /// the function removes the separators preceding the minutes and/or seconds members.
        /// If <see cref="TIME_NOTIMEMARKER"/> is specified, the function removes the separators preceding and following the time marker.
        /// If <see cref="TIME_FORCE24HOURFORMAT"/> is specified, the function displays any existing time marker,
        /// unless the <see cref="TIME_NOTIMEMARKER"/> flag is also set.
        /// The function does not include milliseconds as part of the formatted time string.
        /// The function returns no errors for a bad format string, but just forms the best possible time string.
        /// If more than two hour, minute, second, or time marker format pictures are passed in, the function defaults to two.
        /// For example, the only time marker pictures that are valid are "t" and "tt". If "ttt" is passed in, the function assumes "tt".
        /// To obtain the time format without performing any actual formatting,
        /// the application should use the <see cref="GetLocaleInfoEx"/> function, specifying <see cref="LOCALE_STIMEFORMAT"/>.
        /// The application can use the following elements to construct a format picture string.
        /// If spaces are used to separate the elements in the format string, these spaces appear in the same location in the output string.
        /// The letters must be in uppercase or lowercase as shown, for example, "ss", not "SS".
        /// Characters in the format string that are enclosed in single quotation marks appear in the same location and unchanged in the output string.
        /// Picture	Meaning
        /// h       Hours with no leading zero for single-digit hours; 12-hour clock
        /// hh	    Hours with leading zero for single-digit hours; 12-hour clock
        /// H	    Hours with no leading zero for single-digit hours; 24-hour clock
        /// HH	    Hours with leading zero for single-digit hours; 24-hour clock
        /// m	    Minutes with no leading zero for single-digit minutes
        /// mm	    Minutes with leading zero for single-digit minutes
        /// s	    Seconds with no leading zero for single-digit seconds
        /// ss	    Seconds with leading zero for single-digit seconds
        /// t	    One character time marker string, such as A or P
        /// tt	    Multi-character time marker string, such as AM or PM
        /// For example, to get the time string
        /// "11:29:40 PM"
        /// the application should use the picture string
        /// "hh':'mm':'ss tt"
        /// This function can retrieve data from custom locales.
        /// Data is not guaranteed to be the same from computer to computer or between runs of an application.
        /// If your application must persist or transmit data, see Using Persistent Locale Data.
        /// Beginning in Windows 8:
        /// If your app passes language tags to this function from the Windows.Globalization namespace,
        /// it must first convert the tags by calling ResolveLocaleName.
        /// Beginning in Windows 8:
        /// <see cref="GetTimeFormatEx"/> is declared in Datetimeapi.h. Before Windows 8, it was declared in Winnls.h.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTimeFormatEx", ExactSpelling = true, SetLastError = true)]
        public static extern int GetTimeFormatEx([In] LPCWSTR lpLocaleName, [In] GetTimeFormatFlags dwFlags, [In] in SYSTEMTIME lpTime, [In] LPCWSTR lpFormat,
            [In] LPWSTR lpTimeStr, [In] int cchTime);

        /// <summary>
        /// <para>
        /// Determines whether the calling process has read access to the memory at the specified address.
        /// Important
        /// This function is obsolete and should not be used. Despite its name,
        /// it does not guarantee that the pointer is valid or that the memory pointed to is safe to use.
        /// For more information, see Remarks on this page.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-isbadcodeptr"/>
        /// </para>
        /// </summary>
        /// <param name="lpfn">
        /// A pointer to a memory address.
        /// </param>
        /// <returns>
        /// If the calling process has read access to the specified memory, the return value is <see cref="FALSE"/>.
        /// If the calling process does not have read access to the specified memory, the return value is <see cref="TRUE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If the application is compiled as a debugging version, and the process does not have read access to the specified memory location,
        /// the function causes an assertion and breaks into the debugger.
        /// Leaving the debugger, the function continues as usual, and returns a <see cref="FALSE"/> value.
        /// This behavior is by design, as a debugging aid.
        /// </returns>
        /// <remarks>
        /// In a preemptive multitasking environment, it is possible for some other thread to change the process's access to the memory being tested.
        /// Even when the function indicates that the process has read access to the specified memory,
        /// you should use structured exception handling when attempting to access the memory.
        /// Use of structured exception handling enables the system to notify the process if an access violation exception occurs,
        /// giving the process an opportunity to handle the exception.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsBadCodePtr", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsBadCodePtr([In] FARPROC lpfn);

        /// <summary>
        /// <para>
        /// Verifies that the calling process has read access to the specified range of memory.
        /// Important This function is obsolete and should not be used.
        /// Despite its name, it does not guarantee that the pointer is valid or that the memory pointed to is safe to use.
        /// For more information, see Remarks on this page.
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
        /// If this parameter is zero, the return value is <see cref="BOOL.FALSE"/>.
        /// </param>
        /// <returns>
        /// If the calling process has read access to all bytes in the specified memory range, the return value is <see cref="BOOL.FALSE"/>.
        /// If the calling process does not have read access to all bytes in the specified memory range, the return value is <see cref="BOOL.TRUE"/>.
        /// If the application is compiled as a debugging version, and the process does not have read access to all bytes in the specified memory range,
        /// the function causes an assertion and breaks into the debugger.
        /// Leaving the debugger, the function continues as usual, and returns a <see cref="BOOL.TRUE"/> value.
        /// This behavior is by design, as a debugging aid.
        /// </returns>
        /// <remarks>
        /// This function is typically used when working with pointers returned from third-party libraries,
        /// where you cannot determine the memory management behavior in the third-party DLL.
        /// Threads in a process are expected to cooperate in such a way that one will not free memory that the other needs.
        /// Use of this function does not negate the need to do this.
        /// If this is not done, the application may fail in an unpredictable manner.
        /// Dereferencing potentially invalid pointers can disable stack expansion in other threads.
        /// A thread exhausting its stack, when stack expansion has been disabled, results in the immediate termination of the parent process,
        /// with no pop-up error window or diagnostic information.
        /// If the calling process has read access to some, but not all, of the bytes in the specified memory range,
        /// the return value is <see cref="BOOL.TRUE"/>.
        /// In a preemptive multitasking environment, it is possible for some other thread to change the process's access to the memory being tested.
        /// Even when the function indicates that the process has read access to the specified memory,
        /// you should use structured exception handling when attempting to access the memory.
        /// Use of structured exception handling enables the system to notify the process if an access violation exception occurs,
        /// giving the process an opportunity to handle the exception.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsBadReadPtr", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsBadReadPtr([In] IntPtr lp, [In] UINT_PTR ucb);

        /// <summary>
        /// <para>
        /// Verifies that the calling process has read access to the specified range of memory.
        /// Important
        /// This function is obsolete and should not be used. Despite its name,
        /// it does not guarantee that the pointer is valid or that the memory pointed to is safe to use.
        /// For more information, see Remarks on this page.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-isbadstringptrw"/>
        /// </para>
        /// </summary>
        /// <param name="lpsz">
        /// A pointer to a null-terminated string, either Unicode or ASCII.
        /// </param>
        /// <param name="ucchMax">
        /// The maximum size of the string, in TCHARs.
        /// The function checks for read access in all characters up to the string's terminating null character or
        /// up to the number of characters specified by this parameter, whichever is smaller.
        /// If this parameter is zero, the return value is <see cref="BOOL.FALSE"/>.
        /// </param>
        /// <returns>
        /// If the calling process has read access to all characters up to the string's terminating null character
        /// or up to the number of characters specified by <paramref name="ucchMax"/>, the return value is <see cref="BOOL.FALSE"/>.
        /// If the calling process does not have read access to all characters up to the string's terminating null character
        /// or up to the number of characters specified by <paramref name="ucchMax"/>, the return value is <see cref="BOOL.TRUE"/>.
        /// If the application is compiled as a debugging version, and the process does not have read access to the entire memory range specified,
        /// the function causes an assertion and breaks into the debugger.
        /// Leaving the debugger, the function continues as usual, and returns a <see cref="BOOL.FALSE"/> value This behavior is by design,
        /// as a debugging aid.
        /// </returns>
        /// <remarks>
        /// This function is typically used when working with pointers returned from third-party libraries,
        /// where you cannot determine the memory management behavior in the third-party DLL.
        /// Threads in a process are expected to cooperate in such a way that one will not free memory that the other needs.
        /// Use of this function does not negate the need to do this.
        /// If this is not done, the application may fail in an unpredictable manner.
        /// Dereferencing potentially invalid pointers can disable stack expansion in other threads.
        /// A thread exhausting its stack, when stack expansion has been disabled, results in the immediate termination of the parent process,
        /// with no pop-up error window or diagnostic information.
        /// If the calling process has read access to some, but not all, of the specified memory range, the return value is <see cref="BOOL.FALSE"/>.
        /// In a preemptive multitasking environment, it is possible for some other thread to change the process's access to the memory being tested.
        /// Even when the function indicates that the process has read access to the specified memory,
        /// you should use structured exception handling when attempting to access the memory.
        /// Use of structured exception handling enables the system to notify the process if an access violation exception occurs,
        /// giving the process an opportunity to handle the exception.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsBadStringPtrW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsBadStringPtr([In] IntPtr lpsz, UINT_PTR ucchMax);

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
        /// If the calling process has write access to all bytes in the specified memory range, the return value is <see cref="BOOL.FALSE"/>.
        /// If the calling process does not have write access to all bytes in the specified memory range, the return value is <see cref="BOOL.TRUE"/>.
        /// If the application is run under a debugger and the process does not have write access to all bytes in the specified memory range,
        /// the function causes a first chance STATUS_ACCESS_VIOLATION exception.
        /// The debugger can be configured to break for this condition.
        /// After resuming process execution in the debugger, the function continues as usual and returns a <see cref="BOOL.TRUE"/> value.
        /// This behavior is by design and serves as a debugging aid.
        /// </returns>
        /// <remarks>
        /// This function is typically used when working with pointers returned from third-party libraries,
        /// where you cannot determine the memory management behavior in the third-party DLL.
        /// Threads in a process are expected to cooperate in such a way that one will not free memory that the other needs.
        /// Use of this function does not negate the need to do this. If this is not done, the application may fail in an unpredictable manner.
        /// Dereferencing potentially invalid pointers can disable stack expansion in other threads. A thread exhausting its stack,
        /// when stack expansion has been disabled, results in the immediate termination of the parent process,
        /// with no pop-up error window or diagnostic information.
        /// If the calling process has write access to some, but not all, of the bytes in the specified memory range,
        /// the return value is <see cref="BOOL.TRUE"/>.
        /// In a preemptive multitasking environment, it is possible for some other thread to change the process's access to the memory being tested.
        /// Even when the function indicates that the process has write access to the specified memory,
        /// you should use structured exception handling when attempting to access the memory.
        /// Use of structured exception handling enables the system to notify the process if an access violation exception occurs,
        /// giving the process an opportunity to handle the exception.
        /// <see cref="IsBadWritePtr"/> is not multithread safe. To use it properly on a pointer shared by multiple threads,
        /// call it inside a critical region of code that allows only one thread to access the memory being checked.
        /// Use operating system–level objects such as critical sections or mutexes or the interlocked functions to create the critical region of code.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsBadWritePtr", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsBadWritePtr([In] LPVOID lp, [In] UINT_PTR ucb);

        /// <summary>
        /// MakeProcInstance
        /// </summary>
        /// <param name="lpProc"></param>
        /// <param name="hInstance"></param>
        /// <returns></returns>
        [Obsolete]
        public static FARPROC MakeProcInstance(FARPROC lpProc, HINSTANCE hInstance) => lpProc;

        /// <summary>
        /// <para>
        /// Multiplies two 32-bit values and then divides the 64-bit result by a third 32-bit value. The final result is rounded to the nearest integer.
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
        /// If the function succeeds, the return value is the result of the multiplication and division, rounded to the nearest integer.
        /// If the result is a positive half integer (ends in .5), it is rounded up.
        /// If the result is a negative half integer, it is rounded down.
        /// If either an overflow occurred or nDenominator was 0, the return value is -1.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "MulDiv", ExactSpelling = true, SetLastError = true)]
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
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// On systems that run Windows XP or later, the function will always succeed and will thus never return zero.
        /// </returns>
        /// <remarks>
        /// For more info about this function and its usage, see Acquiring high-resolution time stamps.
        /// </remarks>
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
        /// If the installed hardware supports a high-resolution performance counter, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// On systems that run Windows XP or later, the function will always succeed and will thus never return zero.
        /// </returns>
        /// <remarks>
        /// For more info about this function and its usage, see Acquiring high-resolution time stamps.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "QueryPerformanceFrequency", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL QueryPerformanceFrequency([Out] out LARGE_INTEGER lpFrequency);

        /// <summary>
        /// <para>
        /// Runs the specified application.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-winexec"/>
        /// </para>
        /// </summary>
        /// <param name="lpCmdLine">
        /// The command line (file name plus optional parameters) for the application to be executed.
        /// If the name of the executable file in the <paramref name="lpCmdLine"/> parameter does not contain a directory path,
        /// the system searches for the executable file in this sequence:
        /// The directory from which the application loaded.
        /// The current directory.
        /// The Windows system directory. The <see cref="GetSystemDirectory"/> function retrieves the path of this directory.
        /// The Windows directory. The <see cref="GetWindowsDirectory"/> function retrieves the path of this directory.
        /// The directories listed in the PATH environment variable.
        /// </param>
        /// <param name="uCmdShow">
        /// The display options.
        /// For a list of the acceptable values, see the description of the nCmdShow parameter of the <see cref="ShowWindow"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is greater than 31.
        /// If the function fails, the return value is one of the following error values.
        /// 0: The system is out of memory or resources.
        /// <see cref="ERROR_BAD_FORMAT"/>: The .exe file is invalid.
        /// <see cref="ERROR_FILE_NOT_FOUND"/>: The specified file was not found.
        /// <see cref="ERROR_PATH_NOT_FOUND"/>: The specified path was not found.
        /// </returns>
        /// <remarks>
        /// The <see cref="WinExec"/> function returns when the started process calls the <see cref="GetMessage"/> function or a time-out limit is reached.
        /// To avoid waiting for the time out delay, call the <see cref="GetMessage"/> function as soon as possible
        /// in any process started by a call to <see cref="WinExec"/>.
        /// Security Remarks
        /// The executable name is treated as the first white space-delimited string in <paramref name="lpCmdLine"/>.
        /// If the executable or path name has a space in it, there is a risk that a different executable could be run
        /// because of the way the function parses spaces. The following example is dangerous because the function will attempt to run "Program.exe",
        /// if it exists, instead of "MyApp.exe".
        /// <code>
        /// WinExec("C:\\Program Files\\MyApp", ...)
        /// </code>
        /// If a malicious user were to create an application called "Program.exe" on a system,
        /// any program that incorrectly calls <see cref="WinExec"/> using the Program Files directory will run this application
        /// instead of the intended application.
        /// To avoid this problem, use <see cref="CreateProcess"/> rather than <see cref="WinExec"/>.
        /// However, if you must use <see cref="WinExec"/> for legacy reasons, make sure the application name is enclosed in quotation marks
        /// as shown in the example below.
        /// <code>
        /// WinExec("\"C:\\Program Files\\MyApp.exe\" -L -S", ...)
        /// </code>
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit Windows. Applications should use the CreateProcess function.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WinExec", ExactSpelling = true, SetLastError = true)]
        public static extern UINT WinExec([MarshalAs(UnmanagedType.LPWStr)][In] string lpCmdLine, [In] ShowWindowCommands uCmdShow);

        /// <summary>
        /// <para>
        /// Fills a block of memory with zeros.
        /// To avoid any undesired effects of optimizing compilers, use the <see cref="SecureZeroMemory"/> function.
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
        /// Many programming languages include syntax for initializing complex variables to zero.
        /// There can be differences between the results of these operations and the <see cref="ZeroMemory"/> function.
        /// Use <see cref="ZeroMemory"/> to clear a block of memory in any programming language.
        /// This macro is defined as the RtlZeroMemory macro. For more information, see WinBase.h and WinNT.h.
        /// </remarks>
        public static unsafe void ZeroMemory([In] PVOID Destination, [In] SIZE_T Length) => Unsafe.InitBlock(Destination, 0, (uint)(IntPtr)Length);
    }
}
