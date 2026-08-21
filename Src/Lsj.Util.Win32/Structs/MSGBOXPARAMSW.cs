using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.LANGID;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.MessageBoxFlags;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information used to display a message box.
    /// The <see cref="MessageBoxIndirect"/> function uses this structure.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-msgboxparamsw"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct MSGBOXPARAMS
    {
        /// <summary>
        /// The structure size, in bytes.
        /// </summary>
        public UINT cbSize;

        /// <summary>
        /// A handle to the owner window.
        /// This member can be <see cref="NULL"/>.
        /// </summary>
        public HWND hwndOwner;

        /// <summary>
        /// A handle to the module that contains the icon resource identified by the <see cref="lpszIcon"/> member,
        /// and the string resource identified by the <see cref="lpszText"/> or <see cref="lpszCaption"/> member.
        /// </summary>
        public HINSTANCE hInstance;

        /// <summary>
        /// A null-terminated string, or the identifier of a string resource, that contains the message to be displayed.
        /// </summary>
        public nint lpszText;

        /// <summary>
        /// A null-terminated string, or the identifier of a string resource, that contains the message box title.
        /// If this member is <see cref="NULL"/>, the default title Error is used.
        /// </summary>
        public nint lpszCaption;

        /// <summary>
        /// <para>
        /// The contents and behavior of the dialog box.
        /// This member can be a combination of flags described for the "uType parameter of the <see cref="MessageBoxEx"/> function.
        /// </para>
        /// <para>
        /// In addition, you can specify the <see cref="MB_USERICON"/> flag (0x00000080L)
        /// if you want the message box to display the icon specified by the <see cref="lpszIcon"/> member.
        /// </para>
        /// </summary>
        public MessageBoxFlags dwStyle;

        /// <summary>
        /// <para>
        /// Identifies an icon resource.
        /// This parameter can be either a null-terminated string or an integer resource identifier passed to the <see cref="MAKEINTRESOURCE"/> macro.
        /// </para>
        /// <para>
        /// To load one of the standard system-defined icons, set the <see cref="hInstance"/> member to <see cref="NULL"/>
        /// and set <see cref="lpszIcon"/> to one of the values listed with the <see cref="LoadIcon"/> function.
        /// </para>
        /// <para>
        /// This member is ignored if the <see cref="dwStyle"/> member does not specify the <see cref="MB_USERICON"/> flag.
        /// </para>
        /// </summary>
        public nint lpszIcon;

        /// <summary>
        /// Identifies a help context.
        /// If a help event occurs, this value is specified in the <see cref="HELPINFO"/> structure
        /// that the message box sends to the owner window or callback function.
        /// </summary>
        public DWORD_PTR dwContextHelpId;

        /// <summary>
        /// A pointer to the callback function that processes help events for the message box.
        /// The callback function has the following form:
        /// <code>
        /// VOID CALLBACK MsgBoxCallback(LPHELPINFO lpHelpInfo);
        /// </code>
        /// If this member is <see cref="NULL"/>, then the message box sends <see cref="WM_HELP"/> messages to the owner window when help events occur.
        /// </summary>
        public nint lpfnMsgBoxCallback;

        /// <summary>
        /// <para>
        /// The language in which to display the text contained in the predefined push buttons.
        /// This value must be in the form returned by the <see cref="MAKELANGID"/> macro.
        /// </para>
        /// <para>
        /// For a list of supported language identifiers, see Language Identifiers.
        /// Note that each localized release of Windows typically contains resources only for a limited set of languages.
        /// Thus, for example, the U.S. version offers <see cref="LANG_ENGLISH"/>,
        /// the French version offers <see cref="LANG_FRENCH"/>, the German version offers <see cref="LANG_GERMAN"/>,
        /// and the Japanese version offers <see cref="LANG_JAPANESE"/>.
        /// Each version offers <see cref="LANG_NEUTRAL"/>.
        /// This limits the set of values that can be used with the <see cref="dwLanguageId"/> parameter.
        /// Before specifying a language identifier, you should enumerate the locales that are installed on a system.
        /// </para>
        /// </summary>
        public DWORD dwLanguageId;
    }
}
