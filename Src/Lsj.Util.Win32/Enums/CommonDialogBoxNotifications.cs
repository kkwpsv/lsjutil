using System;
using static Lsj.Util.Win32.Enums.OPENFILENAMEFlags;
using static Lsj.Util.Win32.Enums.WindowMessages;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Common Dialog Box Notifications
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/dlgbox/common-dialog-box-notifications"/>
    /// </para>
    /// </summary>
    public enum CommonDialogBoxNotifications : uint
    {
        /// <summary>
        /// CDN_FIRST
        /// </summary>
        CDN_FIRST = unchecked((uint)(-601)),

        /// <summary>
        /// CDN_LAST
        /// </summary>
        CDN_LAST = unchecked((uint)(-699)),

        /// <summary>
        /// Sent by an Explorer-style Open or Save As dialog box when the user specifies a file name and clicks the OK button.
        /// Your OFNHookProc hook procedure receives this message in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        CDN_FILEOK = CDN_FIRST - 0x0005,

        /// <summary>
        /// Sent by an Explorer-style Open or Save As dialog box when a new folder is opened.
        /// Your OFNHookProc hook procedure receives this message in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        [Obsolete("[Starting with Windows Vista, the Open and Save As common dialog boxes have been superseded by the Common Item Dialog." +
            "We recommended that you use the Common Item Dialog API instead of these dialog boxes from the Common Dialog Box Library.]")]
        CDN_FOLDERCHANGE = CDN_FIRST - 0x0002,

        /// <summary>
        /// Sent by an Explorer-style Open or Save As dialog box when the user clicks the Help button.
        /// Your OFNHookProc hook procedure receives this message in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        [Obsolete("[Starting with Windows Vista, the Open and Save As common dialog boxes have been superseded by the Common Item Dialog." +
            "We recommended that you use the Common Item Dialog API instead of these dialog boxes from the Common Dialog Box Library.]")]
        CDN_HELP = CDN_FIRST - 0x0004,

        /// <summary>
        /// Sent by an Open or Save As dialog box to determine whether the dialog box should display an item in a shell folder's item list.
        /// When the user opens a folder, the dialog box sends a <see cref="CDN_INCLUDEITEM"/> notification for each item in the folder.
        /// The dialog box sends this notification only if the <see cref="OFN_ENABLEINCLUDENOTIFY"/> flag was set when the dialog box was created.
        /// Your OFNHookProc hook procedure receives this message in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        [Obsolete("[Starting with Windows Vista, the Open and Save As common dialog boxes have been superseded by the Common Item Dialog." +
            "We recommended that you use the Common Item Dialog API instead of these dialog boxes from the Common Dialog Box Library.]")]
        CDN_INCLUDEITEM = CDN_FIRST - 0x0007,

        /// <summary>
        /// Sent by an Explorer-style Open or Save As dialog box when the system has finished arranging the controls in the dialog box.
        /// The system moves the standard controls to make room for the controls of the child dialog box.
        /// Your OFNHookProc hook procedure receives this message in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        [Obsolete("[Starting with Windows Vista, the Open and Save As common dialog boxes have been superseded by the Common Item Dialog." +
            "We recommended that you use the Common Item Dialog API instead of these dialog boxes from the Common Dialog Box Library.]")]
        CDN_INITDONE = CDN_FIRST - 0x0000,

        /// <summary>
        /// Sent by an Explorer-style Open or Save As dialog box when the selection changes in the list box
        /// that displays the contents of the currently opened folder or directory.
        /// Your OFNHookProc hook procedure receives this message in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        [Obsolete("[Starting with Windows Vista, the Open and Save As common dialog boxes have been superseded by the Common Item Dialog." +
            "We recommended that you use the Common Item Dialog API instead of these dialog boxes from the Common Dialog Box Library.]")]
        CDN_SELCHANGE = CDN_FIRST - 0x0001,

        /// <summary>
        /// Sent by an Explorer-style Open or Save As dialog box when the user clicks the OK button
        /// and a network sharing violation occurs for the selected file.
        /// Your OFNHookProc hook procedure receives this message in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        [Obsolete("[Starting with Windows Vista, the Open and Save As common dialog boxes have been superseded by the Common Item Dialog." +
            "We recommended that you use the Common Item Dialog API instead of these dialog boxes from the Common Dialog Box Library.]")]
        CDN_SHAREVIOLATION = CDN_FIRST - 0x0003,

        /// <summary>
        /// Sent by an Explorer-style Open or Save As dialog box when the user selects a new file type from the file types combo box.
        /// Your OFNHookProc hook procedure receives this message in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        [Obsolete("[Starting with Windows Vista, the Open and Save As common dialog boxes have been superseded by the Common Item Dialog." +
            "We recommended that you use the Common Item Dialog API instead of these dialog boxes from the Common Dialog Box Library.]")]
        CDN_TYPECHANGE = CDN_FIRST - 0x0006,
    }
}
