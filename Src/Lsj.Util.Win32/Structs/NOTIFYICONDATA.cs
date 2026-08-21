using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.SystemMetricIndexes;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Shell32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information that the system needs to display notifications in the notification area. Used by <see cref="Shell_NotifyIcon"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shellapi/ns-shellapi-notifyicondataw"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// See Notifications in the Windows User Experience Interaction Guidelines for more information on notification UI and content best practices.
    /// </para>
    /// <para>
    /// If you set the <see cref="NIF_INFO"/> flag in the <see cref="uFlags"/> member,
    /// the balloon-style notification is used.
    /// For more discussion of these notifications, see Balloon tooltips.
    /// </para>
    /// <para>
    /// No more than one balloon notification at a time can be displayed for the taskbar.
    /// If an application attempts to display a notification when one is already being displayed,
    /// the new notification is queued and displayed when the older notification goes away.
    /// In versions of Windows before Windows Vista, the new notification would not appear
    /// until the existing notification has been visible for at least the system minimum timeout length,
    /// regardless of the original notification's <see cref="uTimeout"/> value.
    /// If the user does not appear to be using the computer, the system does not count this time toward the timeout.
    /// </para>
    /// <para>
    /// Several members of this structure are only supported for Windows 2000 and later.
    /// To enable these members, include one of the following lines in your header:
    /// </para>
    /// <code>
    /// // Windows Vista and later:
    /// #define NTDDI_VERSION NTDDI_WIN2K
    /// #define NTDDI_VERSION NTDDI_WINXP
    /// #define NTDDI_VERSION NTDDI_VISTA
    /// 
    /// // Windows XP and earlier:
    /// #define _WIN32_IE 0x0500
    /// </code>
    /// <para>
    /// Note that you must initialize the structure with its size.
    /// If you use the size of the currently defined structure,
    /// the application might not run with earlier versions of Shell32.dll, which expect a smaller structure.
    /// You can run your application against earlier versions of Shell32.dll by defining the appropriate version number (see Shell and Common Controls Versions).
    /// However, this might cause problems if your application also needs to run on more recent systems.
    /// </para>
    /// <para>
    /// You can maintain application compatibility with all Shell32.dll versions
    /// while still using the current header files by setting the size of the <see cref="NOTIFYICONDATA"/> structure appropriately.
    /// Before you initialize the structure, use <c>DllGetVersion</c> to determine which Shell32.dll version is installed on the system
    /// and initialize <see cref="cbSize"/> with one of these values:
    /// </para>
    /// <para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Shell32.dll Version
    /// </term>
    /// <term>
    /// cbSize
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// 6.0.6 or higher (Windows Vista and later)
    /// </term>
    /// <term>
    /// <c>sizeof(NOTIFYICONDATA)</c>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// 6.0 (Windows XP)
    /// </term>
    /// <term>
    /// <see cref="NOTIFYICONDATA_V3_SIZE"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// 5.0 (Windows 2000)
    /// </term>
    /// <term>
    /// <see cref="NOTIFYICONDATA_V2_SIZE"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Versions lower than 5.0
    /// </term>
    /// <term>
    /// <see cref="NOTIFYICONDATA_V1_SIZE"/>
    /// </term>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// Using this value for <see cref="cbSize"/> allows your application to use <see cref="NOTIFYICONDATA"/> in a method compatible with earlier Shell32.dll versions.
    /// </para>
    /// <para>
    /// The following code example shows version checking that can enable an application
    /// that uses the <see cref="guidItem"/> member to run on both Windows Vista and Windows 7.
    /// It provides a Boolean function that returns <see cref="TRUE"/> if the operating system is Windows 7.
    /// Unless this member returns <see cref="TRUE"/>, the <see cref="guidItem"/> member must be set to 0.
    /// </para>
    /// <para>
    /// Note
    /// </para>
    /// <para>
    /// This code is specific to the Windows 7 version number.
    /// It is expected that future versions of Windows and Windows Server will support the <see cref="guidItem"/> member,
    /// and at that time this code must be updated to identify later version numbers as valid as well.
    /// </para>
    /// <code>
    /// BOOL IsWin7OrLater()
    /// {
    ///     // Initialize the OSVERSIONINFOEX structure.
    ///     OSVERSIONINFOEX osvi;
    ///     ZeroMemory(&amp;osvi, sizeof(OSVERSIONINFOEX));
    ///     osvi.dwOSVersionInfoSize = sizeof(OSVERSIONINFOEX);
    ///     osvi.dwMajorVersion = 6;
    ///     osvi.dwMinorVersion = 1;
    /// 
    ///     // Initialize the condition mask.
    ///     DWORDLONG dwlConditionMask = 0;
    ///     VER_SET_CONDITION(dwlConditionMask, VER_MAJORVERSION, VER_GREATER_EQUAL);
    ///     VER_SET_CONDITION(dwlConditionMask, VER_MINORVERSION, VER_GREATER_EQUAL);
    /// 
    ///     // Perform the test.
    ///     return VerifyVersionInfo(&amp;osvi, 
    ///                              VER_MAJORVERSION | VER_MINORVERSION,
    ///                              dwlConditionMask);
    /// }
    /// </code>
    /// <para>
    /// The following code example shows the use of <see cref="LoadIconMetric"/> to load an icon for use with high DPI.
    /// </para>
    /// <code>
    /// // Declare NOTIFYICONDATA details. 
    /// // Error handling is omitted here for brevity. Do not omit it in your code.
    /// 
    /// NOTIFYICONDATA nid = {};
    /// nid.cbSize = sizeof(nid);
    /// nid.hWnd = hWnd;
    /// nid.uFlags = NIF_ICON | NIF_TIP | NIF_GUID;
    /// 
    /// // Note: This is an example GUID only and should not be used.
    /// // Normally, you should use a GUID-generating tool to provide the value to
    /// // assign to guidItem.
    /// static const GUID myGUID = 
    ///     {0x23977b55, 0x10e0, 0x4041, {0xb8, 0x62, 0xb1, 0x95, 0x41, 0x96, 0x36, 0x69}};
    /// nid.guidItem = myGUID;
    /// 
    /// // This text will be shown as the icon's tooltip.
    /// StringCchCopy(nid.szTip, ARRAYSIZE(nid.szTip), L"Test application");
    /// 
    /// // Load the icon for high DPI.
    /// LoadIconMetric(hInst, MAKEINTRESOURCE(IDI_SMALL), LIM_SMALL, &amp;(nid.hIcon));
    /// 
    /// // Show the notification.
    /// Shell_NotifyIcon(NIM_ADD, &amp;nid) ? S_OK : E_FAIL;
    /// </code>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct NOTIFYICONDATA
    {
        /// <summary>
        /// The size of this structure, in bytes.
        /// </summary>
        public DWORD cbSize;

        /// <summary>
        /// A handle to the window that receives notifications associated with an icon in the notification area.
        /// </summary>
        public HWND hWnd;

        /// <summary>
        /// The application-defined identifier of the taskbar icon.
        /// The Shell uses either (<see cref="hWnd"/> plus <see cref="uID"/>) or <see cref="guidItem"/>
        /// to identify which icon to operate on when <see cref="Shell_NotifyIcon"/> is invoked.
        /// You can have multiple icons associated with a single <see cref="hWnd"/> by assigning each a different <see cref="uID"/>.
        /// If <see cref="guidItem"/> is specified, <see cref="uID"/> is ignored.
        /// </summary>
        public UINT uID;

        /// <summary>
        /// <para>
        /// Flags that either indicate which of the other members of the structure contain valid data
        /// or provide additional information to the tooltip as to how it should display.
        /// This member can be a combination of the following values:
        /// </para>
        /// <para>
        /// <see cref="NIF_MESSAGE"/> (0x00000001)
        /// </para>
        /// <para>
        /// 0x00000001.
        /// The <see cref="uCallbackMessage"/> member is valid.
        /// </para>
        /// <para>
        /// <see cref="NIF_ICON"/> (0x00000002)
        /// </para>
        /// <para>
        /// 0x00000002.
        /// The <see cref="hIcon"/> member is valid.
        /// </para>
        /// <para>
        /// <see cref="NIF_TIP"/> (0x00000004)
        /// </para>
        /// <para>
        /// 0x00000004.
        /// The <see cref="szTip"/> member is valid.
        /// </para>
        /// <para>
        /// <see cref="NIF_STATE"/> (0x00000008)
        /// </para>
        /// <para>
        /// 0x00000008.
        /// The <see cref="dwState"/> and <see cref="dwStateMask"/> members are valid.
        /// </para>
        /// <para>
        /// <see cref="NIF_INFO"/> (0x00000010)
        /// </para>
        /// <para>
        /// 0x00000010.
        /// Display a balloon notification.
        /// The <see cref="szInfo"/>, <see cref="szInfoTitle"/>, <see cref="dwInfoFlags"/>, and <see cref="uTimeout"/> members are valid.
        /// Note that <see cref="uTimeout"/> is valid only in Windows 2000 and Windows XP.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// To display the balloon notification, specify <see cref="NIF_INFO"/> and provide text in <see cref="szInfo"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// To remove a balloon notification, specify <see cref="NIF_INFO"/> and provide an empty string through <see cref="szInfo"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// To add a notification area icon without displaying a notification, do not set the NIF_INFO flag.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// <see cref="NIF_GUID"/> (0x00000020)
        /// </para>
        /// <para>
        /// 0x00000020.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Windows 7 and later: The <see cref="guidItem"/> is valid.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Windows Vista and earlier: Reserved.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// <see cref="NIF_REALTIME"/> (0x00000040)
        /// </para>
        /// <para>
        /// 0x00000040.
        /// Windows Vista and later.
        /// If the balloon notification cannot be displayed immediately, discard it.
        /// Use this flag for notifications that represent real-time information which would be meaningless or misleading if displayed at a later time.
        /// For example, a message that states "Your telephone is ringing."
        /// <see cref="NIF_REALTIME"/> is meaningful only when combined with the <see cref="NIF_INFO"/> flag.
        /// </para>
        /// <para>
        /// <see cref="NIF_SHOWTIP"/> (0x00000080)
        /// </para>
        /// <para>
        /// 0x00000080.
        /// Windows Vista and later.
        /// Use the standard tooltip.
        /// Normally, when <see cref="uVersion"/> is set to <see cref="NOTIFYICON_VERSION_4"/>,
        /// the standard tooltip is suppressed and can be replaced by the application-drawn, pop-up UI.
        /// If the application wants to show the standard tooltip with <see cref="NOTIFYICON_VERSION_4"/>,
        /// it can specify <see cref="NIF_SHOWTIP"/> to indicate the standard tooltip should still be shown.
        /// </para>
        /// </summary>
        public UINT uFlags;

        /// <summary>
        /// <para>
        /// An application-defined message identifier.
        /// The system uses this identifier to send notification messages to the window identified in <see cref="hWnd"/>.
        /// These notification messages are sent when a mouse event or hover occurs in the bounding rectangle of the icon,
        /// when the icon is selected or activated with the keyboard, or when those actions occur in the balloon notification.
        /// </para>
        /// <para>
        /// When the <see cref="uVersion"/> member is either 0 or <see cref="NOTIFYICON_VERSION"/>,
        /// the <c>wParam</c> parameter of the message contains the identifier of the taskbar icon in which the event occurred.
        /// This identifier can be 32 bits in length.
        /// The <c>lParam</c> parameter holds the mouse or keyboard message associated with the event.
        /// For example, when the pointer moves over a taskbar icon, <c>lParam</c> is set to <see cref="WM_MOUSEMOVE"/>.
        /// </para>
        /// <para>
        /// When the <see cref="uVersion"/> member is <see cref="NOTIFYICON_VERSION_4"/>,
        /// applications continue to receive notification events in the form of application-defined messages through the <see cref="uCallbackMessage"/> member,
        /// but the interpretation of the <c>lParam</c> and <c>wParam</c> parameters of that message is changed as follows:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <c>LOWORD(lParam)</c> contains notification events,
        /// such as <see cref="NIN_BALLOONSHOW"/>, <see cref="NIN_POPUPOPEN"/>, or <see cref="WM_CONTEXTMENU"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <c>HIWORD(lParam)</c> contains the icon ID.
        /// Icon IDs are restricted to a length of 16 bits.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <c>GET_X_LPARAM(wParam)</c> returns the X anchor coordinate for notification events
        /// <see cref="NIN_POPUPOPEN"/>, <see cref="NIN_SELECT"/>, <see cref="NIN_KEYSELECT"/>,
        /// and all mouse messages between <see cref="WM_MOUSEFIRST"/> and <see cref="WM_MOUSELAST"/>.
        /// If any of those messages are generated by the keyboard, <c>wParam</c> is set to the upper-left corner of the target icon.
        /// For all other messages, <c>wParam</c> is undefined.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <c>GET_Y_LPARAM(wParam)</c> returns the Y anchor coordinate for notification events and messages as defined for the X anchor.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public UINT uCallbackMessage;

        /// <summary>
        /// <para>
        /// A handle to the icon to be added, modified, or deleted. Windows XP and later support icons of up to 32 BPP.
        /// </para>
        /// <para>
        /// If only a 16x16 pixel icon is provided, it is scaled to a larger size in a system set to a high dpi value.
        /// This can lead to an unattractive result.
        /// It is recommended that you provide both a 16x16 pixel icon and a 32x32 icon in your resource file.
        /// Use <see cref="LoadIconMetric"/> to ensure that the correct icon is loaded and scaled appropriately. See Remarks for a code example.
        /// </para>
        /// </summary>
        public HICON hIcon;

        /// <summary>
        /// <para>
        /// A null-terminated string that specifies the text for a standard tooltip.
        /// It can have a maximum of 64 characters, including the terminating null character.
        /// </para>
        /// <para>
        /// For Windows 2000 and later, <see cref="szTip"/> can have a maximum of 128 characters, including the terminating null character.
        /// </para>
        /// </summary>
        public ByValStringStructForSize128 szTip;

        /// <summary>
        /// <para>
        /// Windows 2000 and later.
        /// The state of the icon.
        /// One or both of the following values:
        /// </para>
        /// <para>
        /// <see cref="NIS_HIDDEN"/> (0x00000001)
        /// </para>
        /// <para>
        /// 0x00000001.
        /// The icon is hidden.
        /// </para>
        /// <para>
        /// <see cref="NIS_SHAREDICON"/> (0x00000002)
        /// </para>
        /// <para>
        /// 0x00000002.
        /// The icon resource is shared between multiple icons.
        /// </para>
        /// </summary>
        public DWORD dwState;

        /// <summary>
        /// Windows 2000 and later.
        /// A value that specifies which bits of the <see cref="dwState"/> member are retrieved or modified.
        /// The possible values are the same as those for <see cref="dwState"/>.
        /// For example, setting this member to <see cref="NIS_HIDDEN"/> causes only the item's hidden state to be modified
        /// while the icon sharing bit is ignored regardless of its value.
        /// </summary>
        public DWORD dwStateMask;

        /// <summary>
        /// Windows 2000 and later.
        /// A null-terminated string that specifies the text to display in a balloon notification.
        /// It can have a maximum of 256 characters, including the terminating null character,
        /// but should be restricted to 200 characters in English to accommodate localization.
        /// To remove the balloon notification from the UI, either delete the icon (with <see cref="NIM_DELETE"/>)
        /// or set the <see cref="NIF_INFO"/> flag in <see cref="uFlags"/> and set <see cref="szInfo"/> to an empty string.
        /// </summary>
        public ByValStringStructForSize256 szInfo;

        private UINT _unionValue;

        /// <summary>
        /// <para>
        /// Windows 2000 and later.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Union with <see cref="uVersion"/>.
        /// The timeout value, in milliseconds, for notification.
        /// The system enforces minimum and maximum timeout values.
        /// Values specified in <see cref="uTimeout"/> that are too large are set to the maximum value.
        /// Values that are too small default to the minimum value.
        /// The system minimum and maximum timeout values are currently set at 10 seconds and 30 seconds, respectively.
        /// See Remarks for further discussion of <see cref="uTimeout"/>.
        /// </para>
        /// </summary>
        [UnscopedRef]
        public ref UINT uTimeout => ref _unionValue;


        /// <summary>
        /// Windows 2000 and later.
        /// Union with <see cref="uTimeout"/> (deprecated as of Windows Vista).
        /// Specifies which version of the Shell notification icon interface should be used.
        /// For more information on the differences in these versions, see <see cref="Shell_NotifyIcon"/>.
        /// This member is employed only when using <see cref="Shell_NotifyIcon"/> to send an <see cref="NIM_SETVERSION"/> message.
        /// </summary>
        [UnscopedRef]
        public ref UINT uVersion => ref _unionValue;

        /// <summary>
        /// Windows 2000 and later.
        /// A null-terminated string that specifies a title for a balloon notification.
        /// This title appears in a larger font immediately above the text.
        /// It can have a maximum of 64 characters, including the terminating null character,
        /// but should be restricted to 48 characters in English to accommodate localization.
        /// </summary>
        public ByValStringStructForSize64 szInfoTitle;


        /// <summary>
        /// <para>
        /// Windows 2000 and later.
        /// Flags that can be set to modify the behavior and appearance of a balloon notification.
        /// The icon is placed to the left of the title.
        /// If the <see cref="szInfoTitle"/> member is zero-length, the icon is not shown.
        /// </para>
        /// <para>
        /// <see cref="NIIF_NONE"/> (0x00000000)
        /// </para>
        /// <para>
        /// 0x00000000.
        /// No icon.
        /// </para>
        /// <para>
        /// <see cref="NIIF_INFO"/> (0x00000001)
        /// </para>
        /// <para>
        /// 0x00000001.
        /// An information icon.
        /// </para>
        /// <para>
        /// <see cref="NIIF_WARNING"/> (0x00000002)
        /// </para>
        /// <para>
        /// 0x00000002.
        /// A warning icon.
        /// </para>
        /// <para>
        /// <see cref="NIIF_ERROR"/> (0x00000003)
        /// </para>
        /// <para>
        /// 0x00000003.
        /// An error icon.
        /// </para>
        /// <para>
        /// <see cref="NIIF_USER"/> (0x00000004)
        /// </para>
        /// <para>
        /// 0x00000004.
        /// Windows XP SP2 and later.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Windows XP: Use the icon identified in <see cref="hIcon"/> as the notification balloon's title icon.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Windows Vista and later: Use the icon identified in <see cref="hBalloonIcon"/> as the notification balloon's title icon.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// <see cref="NIIF_NOSOUND"/> (0x00000010)
        /// </para>
        /// <para>
        /// 0x00000010.
        /// Windows XP and later.
        /// Do not play the associated sound. Applies only to notifications.
        /// </para>
        /// <para>
        /// <see cref="NIIF_LARGE_ICON"/> (0x00000020)
        /// </para>
        /// <para>
        /// 0x00000020.
        /// Windows Vista and later.
        /// The large version of the icon should be used as the notification icon.
        /// This corresponds to the icon with dimensions <see cref="SM_CXICON"/> x <see cref="SM_CYICON"/>.
        /// If this flag is not set, the icon with dimensions <see cref="SM_CXSMICON"/> x <see cref="SM_CYSMICON"/> is used.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This flag can be used with all stock icons.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Applications that use older customized icons (<see cref="NIIF_USER"/> with <see cref="hIcon"/>) must provide
        /// a new <see cref="SM_CXICON"/> x <see cref="SM_CYICON"/> version in the tray icon (<see cref="hIcon"/>).
        /// These icons are scaled down when they are displayed in the System Tray or System Control Area (SCA).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// New customized icons (<see cref="NIIF_USER"/> with <see cref="hBalloonIcon"/>) must supply
        /// an <see cref="SM_CXICON"/> x <see cref="SM_CYICON"/> version in the supplied icon (<see cref="hBalloonIcon"/>).
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// <see cref="NIIF_RESPECT_QUIET_TIME"/> (0x00000080)
        /// </para>
        /// <para>
        /// 0x00000080.
        /// Windows 7 and later.
        /// Do not display the balloon notification if the current user is in "quiet time",
        /// which is the first hour after a new user logs into his or her account for the first time.
        /// During this time, most notifications should not be sent or shown.
        /// This lets a user become accustomed to a new computer system without those distractions.
        /// Quiet time also occurs for each user after an operating system upgrade or clean installation.
        /// A notification sent with this flag during quiet time is not queued; it is simply dismissed unshown.
        /// The application can resend the notification later if it is still valid at that time.
        /// </para>
        /// <para>
        /// Because an application cannot predict when it might encounter quiet time,
        /// we recommended that this flag always be set on all appropriate notifications by any application that means to honor quiet time.
        /// </para>
        /// <para>
        /// During quiet time, certain notifications should still be sent because they are expected by the user as feedback in response to a user action,
        /// for instance when he or she plugs in a USB device or prints a document.
        /// </para>
        /// <para>
        /// If the current user is not in quiet time, this flag has no effect.
        /// </para>
        /// <para>
        /// <see cref="NIIF_ICON_MASK"/> (0x0000000F)
        /// </para>
        /// <para>
        /// 0x0000000F.
        /// Windows XP and later.
        /// Reserved.
        /// </para>
        /// </summary>
        public DWORD dwInfoFlags;

        /// <summary>
        /// <para>
        /// Windows XP and later.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Windows 7 and later:
        /// A registered GUID that identifies the icon.
        /// This value overrides <see cref="uID"/> and is the recommended method of identifying the icon.
        /// The <see cref="NIF_GUID"/> flag must be set in the <see cref="uFlags"/> member.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Windows XP and Windows Vista: Reserved; must be set to 0.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If your application is intended to run on both Windows Vista and Windows 7,
        /// it is imperative that you check the version of Windows and only specify a nonzero <see cref="guidItem"/> if on Windows 7 or later.
        /// </para>
        /// <para>
        /// If you identify the notification icon with a GUID in one call to <see cref="Shell_NotifyIcon"/>,
        /// you must use that same GUID to identify the icon in any subsequent <see cref="Shell_NotifyIcon"/> calls that deal with that same icon.
        /// </para>
        /// <para>
        /// To generate a GUID for use in this member, use a GUID-generating tool such as Guidgen.exe.
        /// </para>
        /// </summary>
        public GUID guidItem;

        /// <summary>
        /// Windows Vista and later. The handle of a customized notification icon provided by the application
        /// that should be used independently of the notification area icon.
        /// If this member is non-NULL and the <see cref="NIIF_USER"/> flag is set in the <see cref="dwInfoFlags"/> member,
        /// this icon is used as the notification icon.
        /// If this member is <see cref="NULL"/>, the legacy behavior is carried out.
        /// </summary>
        public HICON hBalloonIcon;
    }
}
