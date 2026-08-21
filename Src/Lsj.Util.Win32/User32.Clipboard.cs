using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.GlobalMemoryFlags;
using static Lsj.Util.Win32.Enums.StandardClipboardFormats;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Enums.WindowStationAccessRights;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32
{
    public partial class User32
    {
        /// <summary>
        /// <para>
        /// Places the given window in the system-maintained clipboard format listener list.
        /// </para>
        /// <para>
        /// body>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-addclipboardformatlistener"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window to be placed in the clipboard format listener list.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful, <see cref="FALSE"/> otherwise.
        /// Call <see cref="GetLastError"/> for additional details.
        /// </returns>
        /// <remarks>
        /// When a window has been added to the clipboard format listener list,
        /// it is posted a <see cref="WM_CLIPBOARDUPDATE"/> message whenever the contents of the clipboard have changed.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "AddClipboardFormatListener", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AddClipboardFormatListener([In] HWND hwnd);

        /// <summary>
        /// <para>
        /// Removes a specified window from the chain of clipboard viewers.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-changeclipboardchain"/>
        /// </para>
        /// </summary>
        /// <param name="hWndRemove">
        /// A handle to the window to be removed from the chain.
        /// The handle must have been passed to the <see cref="SetClipboardViewer"/> function.
        /// </param>
        /// <param name="hWndNewNext">
        /// A handle to the window that follows the <paramref name="hWndRemove"/> window in the clipboard viewer chain.
        /// (This is the handle returned by <see cref="SetClipboardViewer"/>,
        /// unless the sequence was changed in response to a <see cref="WM_CHANGECBCHAIN"/> message.)
        /// </param>
        /// <returns>
        /// The return value indicates the result of passing the <see cref="WM_CHANGECBCHAIN"/> message to the windows in the clipboard viewer chain.
        /// Because a window in the chain typically returns <see cref="FALSE"/> when it processes <see cref="WM_CHANGECBCHAIN"/>,
        /// the return value from <see cref="ChangeClipboardChain"/> is typically <see cref="FALSE"/>.
        /// If there is only one window in the chain, the return value is typically <see cref="TRUE"/>.
        /// </returns>
        /// <remarks>
        /// The window identified by <paramref name="hWndNewNext"/> replaces the <paramref name="hWndRemove"/> window in the chain.
        /// The <see cref="SetClipboardViewer"/> function sends a <see cref="WM_CHANGECBCHAIN"/> message to the first window in the clipboard viewer chain.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ChangeClipboardChain", ExactSpelling = true)]
        public static extern BOOL ChangeClipboardChain([In] HWND hWndRemove, [In] HWND hWndNewNext);

        /// <summary>
        /// <para>
        /// Closes the clipboard.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-closeclipboard"/>
        /// </para>
        /// </summary>
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
        /// When the window has finished examining or changing the clipboard, close the clipboard by calling <see cref="CloseClipboard"/>.
        /// This enables other windows to access the clipboard.
        /// </para>
        /// <para>
        /// Do not place an object on the clipboard after calling <see cref="CloseClipboard"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseClipboard", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CloseClipboard();

        /// <summary>
        /// <para>
        /// Retrieves the number of different data formats currently on the clipboard.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-countclipboardformats"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the number of different data formats currently on the clipboard.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CountClipboardFormats", ExactSpelling = true, SetLastError = true)]
        public static extern int CountClipboardFormats();

        /// <summary>
        /// <para>
        /// Empties the clipboard and frees handles to data in the clipboard.
        /// The function then assigns ownership of the clipboard to the window that currently has the clipboard open.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-emptyclipboard"/>
        /// </para>
        /// </summary>
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
        /// Before calling <see cref="EmptyClipboard"/>, an application must open the clipboard by using the <see cref="OpenClipboard"/> function.
        /// If the application specifies a <see cref="NULL"/> window handle when opening the clipboard,
        /// <see cref="EmptyClipboard"/> succeeds but sets the clipboard owner to <see cref="NULL"/>.
        /// Note that this causes <see cref="SetClipboardData"/> to fail.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EmptyClipboard", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EmptyClipboard();

        /// <summary>
        /// <para>
        /// Enumerates the data formats currently available on the clipboard.
        /// </para>
        /// <para>
        /// Clipboard data formats are stored in an ordered list.
        /// To perform an enumeration of clipboard data formats, you make a series of calls to the <see cref="EnumClipboardFormats"/> function.
        /// For each call, the <paramref name="format"/> parameter specifies an available clipboard format,
        /// and the function returns the next available clipboard format.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-enumclipboardformats"/>
        /// </para>
        /// </summary>
        /// <param name="format">
        /// <para>
        /// A clipboard format that is known to be available.
        /// </para>
        /// <para>
        /// To start an enumeration of clipboard formats, set <paramref name="format"/> to zero.
        /// When <paramref name="format"/> is zero, the function retrieves the first available clipboard format.
        /// For subsequent calls during an enumeration, set <paramref name="format"/> to the result of the previous <see cref="EnumClipboardFormats"/> call.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the clipboard format that follows the specified format, namely the next available clipboard format.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If the clipboard is not open, the function fails.
        /// </para>
        /// <para>
        /// If there are no more clipboard formats to enumerate, the return value is zero.
        /// In this case, the <see cref="GetLastError"/> function returns the value <see cref="ERROR_SUCCESS"/>.
        /// This lets you distinguish between function failure and the end of enumeration.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// You must open the clipboard before enumerating its formats.
        /// Use the <see cref="OpenClipboard"/> function to open the clipboard.
        /// The <see cref="EnumClipboardFormats"/> function fails if the clipboard is not open.
        /// </para>
        /// <para>
        /// The <see cref="EnumClipboardFormats"/> function enumerates formats in the order that they were placed on the clipboard.
        /// If you are copying information to the clipboard,
        /// add clipboard objects in order from the most descriptive clipboard format to the least descriptive clipboard format.
        /// If you are pasting information from the clipboard, retrieve the first clipboard format that you can handle.
        /// That will be the most descriptive clipboard format that you can handle.
        /// </para>
        /// <para>
        /// The system provides automatic type conversions for certain clipboard formats.
        /// In the case of such a format, this function enumerates the specified format, then enumerates the formats to which it can be converted.
        /// For more information, see Standard Clipboard Formats and Synthesized Clipboard Formats.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumClipboardFormats", ExactSpelling = true, SetLastError = true)]
        public static extern StandardClipboardFormats EnumClipboardFormats([In] StandardClipboardFormats format);

        /// <summary>
        /// <para>
        /// Retrieves data from the clipboard in a specified format.
        /// The clipboard must have been opened previously.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getclipboarddata"/>
        /// </para>
        /// </summary>
        /// <param name="uFormat">
        /// A clipboard format. For a description of the standard clipboard formats, see Standard Clipboard Formats.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the handle to a clipboard object in the specified format.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Caution
        /// </para>
        /// <para>
        /// Clipboard data is not trusted. Parse the data carefully before using it in your application.
        /// </para>
        /// <para>
        /// An application can enumerate the available formats in advance by using the <see cref="EnumClipboardFormats"/> function.
        /// </para>
        /// <para>
        /// The clipboard controls the handle that the <see cref="GetClipboardData"/> function returns, not the application.
        /// The application should copy the data immediately.
        /// The application must not free the handle nor leave it locked.
        /// The application must not use the handle after the <see cref="EmptyClipboard"/> or <see cref="CloseClipboard"/> function is called,
        /// or after the <see cref="SetClipboardData"/> function is called with the same clipboard format.
        /// </para>
        /// <para>
        /// The system performs implicit data format conversions between certain clipboard formats
        /// when an application calls the <see cref="GetClipboardData"/> function.
        /// For example, if the <see cref="CF_OEMTEXT"/> format is on the clipboard, a window can retrieve data in the <see cref="CF_TEXT"/> format.
        /// The format on the clipboard is converted to the requested format on demand.
        /// For more information, see Synthesized Clipboard Formats.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetClipboardData", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE GetClipboardData([In] StandardClipboardFormats uFormat);

        /// <summary>
        /// <para>
        /// Retrieves from the clipboard the name of the specified registered format.
        /// The function copies the name to the specified buffer.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getclipboardformatnamew"/>
        /// </para>
        /// </summary>
        /// <param name="format">
        /// The type of format to be retrieved.
        /// This parameter must not specify any of the predefined clipboard formats.
        /// </param>
        /// <param name="lpszFormatName">
        /// The buffer that is to receive the format name.
        /// </param>
        /// <param name="cchMaxCount">
        /// The maximum length, in characters, of the string to be copied to the buffer.
        /// If the name exceeds this limit, it is truncated.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the length, in characters, of the string copied to the buffer.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero, indicating that the requested format does not exist or is predefined.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Security Considerations
        /// </para>
        /// <para>
        /// Using this function incorrectly might compromise the security of your program.
        /// For example, miscalculating the proper size of the <paramref name="lpszFormatName"/> buffer,
        /// especially when the application is used in both ANSI and Unicode versions, can cause a buffer overflow.
        /// Also, note that the string is truncated if it is longer than the <paramref name="cchMaxCount"/> parameter, which can lead to loss of information.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetClipboardFormatNameW", ExactSpelling = true, SetLastError = true)]
        public static extern int GetClipboardFormatName([In] StandardClipboardFormats format, [In] LPWSTR lpszFormatName, [In] int cchMaxCount);

        /// <summary>
        /// <para>
        /// Retrieves the window handle of the current owner of the clipboard.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getclipboardowner"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the handle to the window that owns the clipboard.
        /// </para>
        /// <para>
        /// If the clipboard is not owned, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The clipboard can still contain data even if the clipboard is not currently owned.
        /// </para>
        /// <para>
        /// In general, the clipboard owner is the window that last placed data in clipboard.
        /// The <see cref="EmptyClipboard"/> function assigns clipboard ownership.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetClipboardOwner", ExactSpelling = true, SetLastError = true)]
        public static extern HWND GetClipboardOwner();

        /// <summary>
        /// <para>
        /// Retrieves the clipboard sequence number for the current window station.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getclipboardsequencenumber"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// The return value is the clipboard sequence number.
        /// If you do not have <see cref="WINSTA_ACCESSCLIPBOARD"/> access to the window station, the function returns zero.
        /// </returns>
        /// <remarks>
        /// The system keeps a serial number for the clipboard for each window station.
        /// This number is incremented whenever the contents of the clipboard change or the clipboard is emptied.
        /// You can track this value to determine whether the clipboard contents have changed and optimize creating DataObjects.
        /// If clipboard rendering is delayed, the sequence number is not incremented until the changes are rendered.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetClipboardSequenceNumber", ExactSpelling = true)]
        public static extern DWORD GetClipboardSequenceNumber();

        /// <summary>
        /// <para>
        /// Retrieves the handle to the first window in the clipboard viewer chain.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getclipboardviewer"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the handle to the first window in the clipboard viewer chain.
        /// </para>
        /// <para>
        /// If there is no clipboard viewer, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetClipboardViewer", ExactSpelling = true, SetLastError = true)]
        public static extern HWND GetClipboardViewer();

        /// <summary>
        /// <para>
        /// Retrieves the handle to the window that currently has the clipboard open.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getopenclipboardwindow"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the window that has the clipboard open.
        /// If no window has the clipboard open, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If an application or DLL specifies a <see cref="NULL"/> window handle when calling the <see cref="OpenClipboard"/> function,
        /// the clipboard is opened but is not associated with a window.
        /// In such a case, <see cref="GetOpenClipboardWindow"/> returns <see cref="NULL"/>.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetOpenClipboardWindow", ExactSpelling = true)]
        public static extern HWND GetOpenClipboardWindow();

        /// <summary>
        /// <para>
        /// Retrieves the first available clipboard format in the specified list.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getpriorityclipboardformat"/>
        /// </para>
        /// </summary>
        /// <param name="paFormatPriorityList">
        /// The clipboard formats, in priority order.
        /// For a description of the standard clipboard formats, see Standard Clipboard Formats .
        /// </param>
        /// <param name="cFormats">
        /// The number of entries in the <paramref name="paFormatPriorityList"/> array.
        /// This value must not be greater than the number of entries in the list.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the first clipboard format in the list for which data is available.
        /// If the clipboard is empty, the return value is <see cref="NULL"/>.
        /// If the clipboard contains data, but not in any of the specified formats, the return value is –1.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPriorityClipboardFormat", ExactSpelling = true, SetLastError = true)]
        public static extern int GetPriorityClipboardFormat([In] StandardClipboardFormats[] paFormatPriorityList, [In] int cFormats);

        /// <summary>
        /// <para>
        /// Retrieves the currently supported clipboard formats.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getupdatedclipboardformats"/>
        /// </para>
        /// </summary>
        /// <param name="lpuiFormats">
        /// An array of clipboard formats.
        /// For a description of the standard clipboard formats, see Standard Clipboard Formats.
        /// </param>
        /// <param name="cFormats">
        /// The number of entries in the array pointed to by <paramref name="lpuiFormats"/>.
        /// </param>
        /// <param name="pcFormatsOut">
        /// The actual number of clipboard formats in the array pointed to by <paramref name="lpuiFormats"/>.
        /// </param>
        /// <returns>
        /// The function returns <see cref="TRUE"/> if successful; otherwise, <see cref="FALSE"/>.
        /// Call <see cref="GetLastError"/> for additional details.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetUpdatedClipboardFormats", ExactSpelling = true, SetLastError = true)]
        public static extern int GetUpdatedClipboardFormats([Out] StandardClipboardFormats[] lpuiFormats, [In] UINT cFormats, [Out] UINT pcFormatsOut);

        /// <summary>
        /// <para>
        /// Determines whether the clipboard contains data in the specified format.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-isclipboardformatavailable"/>
        /// </para>
        /// </summary>
        /// <param name="format">
        /// A standard or registered clipboard format.
        /// For a description of the standard clipboard formats, see Standard Clipboard Formats .
        /// </param>
        /// <returns>
        /// <para>
        /// If the clipboard format is available, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the clipboard format is not available, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// Typically, an application that recognizes only one clipboard format would call this function
        /// when processing the <see cref="WM_INITMENU"/> or <see cref="WM_INITMENUPOPUP"/> message.
        /// The application would then enable or disable the Paste menu item, depending on the return value.
        /// Applications that recognize more than one clipboard format should use the <see cref="GetPriorityClipboardFormat"/> function for this purpose.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsClipboardFormatAvailable", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsClipboardFormatAvailable([In] StandardClipboardFormats format);

        /// <summary>
        /// <para>
        /// Opens the clipboard for examination and prevents other applications from modifying the clipboard content.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-openclipboard"/>
        /// </para>
        /// </summary>
        /// <param name="hWndNewOwner">
        /// A handle to the window to be associated with the open clipboard.
        /// If this parameter is <see cref="NULL"/>, the open clipboard is associated with the current task.
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
        /// <see cref="OpenClipboard"/> fails if another window has the clipboard open.
        /// </para>
        /// <para>
        /// An application should call the <see cref="CloseClipboard"/> function after every successful call to <see cref="OpenClipboard"/>.
        /// </para>
        /// <para>
        /// The window identified by the <paramref name="hWndNewOwner"/> parameter does not become the clipboard owner
        /// unless the <see cref="EmptyClipboard"/> function is called.
        /// </para>
        /// <para>
        /// If an application calls <see cref="OpenClipboard"/> with hwnd set to <see cref="NULL"/>,
        /// <see cref="EmptyClipboard"/> sets the clipboard owner to <see cref="NULL"/>; this causes <see cref="SetClipboardData"/> to fail.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "OpenClipboard", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL OpenClipboard([In] HWND hWndNewOwner);

        /// <summary>
        /// <para>
        /// Registers a new clipboard format. This format can then be used as a valid clipboard format.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-registerclipboardformatw"/>
        /// </para>
        /// </summary>
        /// <param name="lpszFormat">
        /// The name of the new format.
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
        /// If a registered format with the specified name already exists,
        /// a new format is not registered and the return value identifies the existing format.
        /// This enables more than one application to copy and paste data using the same registered clipboard format.
        /// Note that the format name comparison is case-insensitive.
        /// </para>
        /// <para>
        /// Registered clipboard formats are identified by values in the range 0xC000 through 0xFFFF.
        /// </para>
        /// <para>
        /// When registered clipboard formats are placed on or retrieved from the clipboard,
        /// they must be in the form of an <see cref="HGLOBAL"/> value.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegisterClipboardFormatW", ExactSpelling = true, SetLastError = true)]
        public static extern UINT RegisterClipboardFormat([In] LPCWSTR lpszFormat);

        /// <summary>
        /// <para>
        /// Removes the given window from the system-maintained clipboard format listener list.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-removeclipboardformatlistener"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window to remove from the clipboard format listener list.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful, <see cref="FALSE"/> otherwise.
        /// Call <see cref="GetLastError"/> for additional details.
        /// </returns>
        /// <remarks>
        /// When a window has been removed from the clipboard format listener list,
        /// it will no longer receive <see cref="WM_CLIPBOARDUPDATE"/> messages.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "RemoveClipboardFormatListener", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL RemoveClipboardFormatListener([In] HWND hwnd);

        /// <summary>
        /// <para>
        /// Places data on the clipboard in a specified clipboard format.
        /// The window must be the current clipboard owner, and the application must have called the <see cref="OpenClipboard"/> function.
        /// (When responding to the <see cref="WM_RENDERFORMAT"/> and <see cref="WM_RENDERALLFORMATS"/> messages,
        /// the clipboard owner must not call <see cref="OpenClipboard"/> before calling <see cref="SetClipboardData"/>.)
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setclipboarddata"/>
        /// </para>
        /// </summary>
        /// <param name="uFormat">
        /// The clipboard format.
        /// This parameter can be a registered format or any of the standard clipboard formats.
        /// For more information, see Standard Clipboard Formats and Registered Clipboard Formats.
        /// </param>
        /// <param name="hMem">
        /// <para>
        /// A handle to the data in the specified format.
        /// This parameter can be <see cref="NULL"/>, indicating that the window provides data in the specified clipboard format
        /// (renders the format) upon request; this is known as delayed rendering.
        /// If a window delays rendering, it must process the <see cref="WM_RENDERFORMAT"/> and <see cref="WM_RENDERALLFORMATS"/> messages.
        /// </para>
        /// <para>
        /// If <see cref="SetClipboardData"/> succeeds, the system owns the object identified by the <paramref name="hMem"/> parameter.
        /// The application may not write to or free the data once ownership has been transferred to the system,
        /// but it can lock and read from the data until the <see cref="CloseClipboard"/> function is called.
        /// (The memory must be unlocked before the Clipboard is closed.)
        /// If the <paramref name="hMem"/> parameter identifies a memory object,
        /// the object must have been allocated using the function with the <see cref="GMEM_MOVEABLE"/> flag.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the handle to the data.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Windows 8: Bitmaps to be shared with Windows Store app apps must be in the <see cref="CF_BITMAP"/> format (device-dependent bitmap).
        /// </para>
        /// <para>
        /// If an application calls <see cref="SetClipboardData"/> in response to <see cref="WM_RENDERFORMAT"/> or <see cref="WM_RENDERALLFORMATS"/>,
        /// the application should not use the handle after <see cref="SetClipboardData"/> has been called.
        /// </para>
        /// <para>
        /// If an application calls <see cref="OpenClipboard"/> with hwnd set to <see cref="NULL"/>,
        /// <see cref="EmptyClipboard"/> sets the clipboard owner to <see cref="NULL"/>; this causes <see cref="SetClipboardData"/> to fail.
        /// </para>
        /// <para>
        /// The system performs implicit data format conversions between certain clipboard formats
        /// when an application calls the <see cref="GetClipboardData"/> function.
        /// For example, if the <see cref="CF_OEMTEXT"/> format is on the clipboard, a window can retrieve data in the <see cref="CF_TEXT"/> format.
        /// The format on the clipboard is converted to the requested format on demand.
        /// For more information, see Synthesized Clipboard Formats.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetClipboardData", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE SetClipboardData([In] StandardClipboardFormats uFormat, [In] HANDLE hMem);

        /// <summary>
        /// <para>
        /// Adds the specified window to the chain of clipboard viewers.
        /// Clipboard viewer windows receive a <see cref="WM_DRAWCLIPBOARD"/> message whenever the content of the clipboard changes.
        /// This function is used for backward compatibility with earlier versions of Windows.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setclipboardviewer"/>
        /// </para>
        /// </summary>
        /// <param name="hWndNewViewer">
        /// A handle to the window to be added to the clipboard chain.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value identifies the next window in the clipboard viewer chain.
        /// If an error occurs or there are no other windows in the clipboard viewer chain, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The windows that are part of the clipboard viewer chain, called clipboard viewer windows,
        /// must process the clipboard messages <see cref="WM_CHANGECBCHAIN"/> and <see cref="WM_DRAWCLIPBOARD"/>.
        /// Each clipboard viewer window calls the <see cref="SendMessage"/> function to pass these messages to the next window in the clipboard viewer chain.
        /// </para>
        /// <para>
        /// A clipboard viewer window must eventually remove itself from the clipboard viewer chain by calling the <see cref="ChangeClipboardChain"/> function
        /// — for example, in response to the <see cref="WM_DESTROY"/> message.
        /// </para>
        /// <para>
        /// The <see cref="SetClipboardViewer"/> function exists to provide backward compatibility with earlier versions of Windows.
        /// The clipboard viewer chain can be broken by an application that fails to handle the clipboard chain messages properly.
        /// New applications should use more robust techniques such as the clipboard sequence number or the registration of a clipboard format listener.
        /// For further details on these alternatives techniques, see Monitoring Clipboard Contents.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetClipboardViewer", ExactSpelling = true, SetLastError = true)]
        public static extern HWND SetClipboardViewer([In] HWND hWndNewViewer);
    }
}
