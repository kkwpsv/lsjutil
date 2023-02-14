using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Comdlg32;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.FINDREPLACEFlags;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information that the <see cref="FindText"/> and <see cref="ReplaceText"/> functions use to initialize the Find and Replace dialog boxes.
    /// The <see cref="FINDMSGSTRING"/> registered message uses this structure to pass the user's search or replacement input
    /// to the owner window of a Find or Replace dialog box.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commdlg/ns-commdlg-findreplacew"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct FINDREPLACE
    {
        /// <summary>
        /// The length, in bytes, of the structure.
        /// </summary>
        public DWORD lStructSize;

        /// <summary>
        /// A handle to the window that owns the dialog box.
        /// The window procedure of the specified window receives <see cref="FINDMSGSTRING"/> messages from the dialog box.
        /// This member can be any valid window handle, but it must not be <see cref="NULL"/>.
        /// </summary>
        public HWND hwndOwner;

        /// <summary>
        /// If the <see cref="FR_ENABLETEMPLATEHANDLE"/> flag is set in the <see cref="Flags"/>,
        /// <see cref="hInstance"/> is a handle to a memory object containing a dialog box template.
        /// If the <see cref="FR_ENABLETEMPLATE"/> flag is set, hInstance is a handle to a module
        /// that contains a dialog box template named by the <see cref="lpTemplateName"/> member.
        /// If neither flag is set, this member is ignored.
        /// </summary>
        public HINSTANCE hInstance;

        /// <summary>
        /// A set of bit flags that you can use to initialize the dialog box.
        /// The dialog box sets these flags when it sends the <see cref="FINDMSGSTRING"/> registered message to indicate the user's input.
        /// This member can be one or more of the following values.
        /// <see cref="FR_DIALOGTERM"/>
        /// </summary>
        public FINDREPLACEFlags Flags;

        /// <summary>
        /// The search string that the user typed in the Find What edit control.
        /// You must dynamically allocate the buffer or use a global or static array so it does not go out of scope before the dialog box closes.
        /// The buffer should be at least 80 characters long.
        /// If the buffer contains a string when you initialize the dialog box, the string is displayed in the Find What edit control.
        /// If a <see cref="FINDMSGSTRING"/> message specifies the <see cref="FR_FINDNEXT"/> flag,
        /// <see cref="lpstrFindWhat"/> contains the string to search for.
        /// The <see cref="FR_DOWN"/>, <see cref="FR_WHOLEWORD"/>, and <see cref="FR_MATCHCASE"/> flags indicate the direction and type of search.
        /// If a <see cref="FINDMSGSTRING"/> message specifies the <see cref="FR_REPLACE"/> or <see cref="FR_REPLACE"/> flags,
        /// <see cref="lpstrFindWhat"/> contains the string to be replaced.
        /// </summary>
        public IntPtr lpstrFindWhat;

        /// <summary>
        /// The replacement string that the user typed in the Replace With edit control.
        /// You must dynamically allocate the buffer or use a global or static array so it does not go out of scope before the dialog box closes.
        /// If the buffer contains a string when you initialize the dialog box, the string is displayed in the Replace With edit control.
        /// If a <see cref="FINDMSGSTRING"/> message specifies the <see cref="FR_REPLACE"/> or <see cref="FR_REPLACEALL"/> flags,
        /// <see cref="lpstrReplaceWith"/> contains the replacement string.
        /// The <see cref="FindText"/> function ignores this member.
        /// </summary>
        public IntPtr lpstrReplaceWith;

        /// <summary>
        /// The length, in bytes, of the buffer pointed to by the <see cref="lpstrFindWhat"/> member.
        /// </summary>
        public WORD wFindWhatLen;

        /// <summary>
        /// The length, in bytes, of the buffer pointed to by the <see cref="lpstrReplaceWith"/> member.
        /// </summary>
        public WORD wReplaceWithLen;

        /// <summary>
        /// Application-defined data that the system passes to the hook procedure identified by the <see cref="lpfnHook"/> member.
        /// When the system sends the <see cref="WM_INITDIALOG"/> message to the hook procedure,
        /// the message's lParam parameter is a pointer to the <see cref="FINDREPLACE"/> structure specified when the dialog was created.
        /// The hook procedure can use this pointer to get the <see cref="lCustData"/> value.
        /// </summary>
        public LPARAM lCustData;

        /// <summary>
        /// A pointer to an <see cref="LPFRHOOKPROC"/> hook procedure that can process messages intended for the dialog box.
        /// This member is ignored unless the <see cref="FR_ENABLEHOOK"/> flag is set in the <see cref="Flags"/> member.
        /// If the hook procedure returns <see cref="FALSE"/> in response to the <see cref="WM_INITDIALOG"/> message,
        /// the hook procedure must display the dialog box or else the dialog box will not be shown.
        /// To do this, first perform any other paint operations, and then call the <see cref="ShowWindow"/> and <see cref="UpdateWindow"/> functions.
        /// </summary>
        public LPFRHOOKPROC lpfnHook;

        /// <summary>
        /// The name of the dialog box template resource in the module identified by the <see cref="hInstance"/> member.
        /// This template is substituted for the standard dialog box template.
        /// For numbered dialog box resources, this can be a value returned by the <see cref="MAKEINTRESOURCE"/> macro.
        /// This member is ignored unless the <see cref="FR_ENABLETEMPLATE"/> flag is set in the <see cref="Flags"/> member.
        /// </summary>
        public IntPtr lpTemplateName;
    }
}
