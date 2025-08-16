using System;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="MessageBox"/> flags
    /// </summary>
    [Flags]
    public enum MessageBoxFlags
    {
        /// <summary>
        /// MB_OK
        /// </summary>
        MB_OK = 0x00000000,

        /// <summary>
        /// MB_OKCANCEL
        /// </summary>
        MB_OKCANCEL = 0x00000001,

        /// <summary>
        /// MB_ABORTRETRYIGNORE
        /// </summary>
        MB_ABORTRETRYIGNORE = 0x00000002,

        /// <summary>
        /// MB_YESNOCANCEL
        /// </summary>
        MB_YESNOCANCEL = 0x00000003,

        /// <summary>
        /// MB_YESNO
        /// </summary>
        MB_YESNO = 0x00000004,

        /// <summary>
        /// MB_RETRYCANCEL
        /// </summary>
        MB_RETRYCANCEL = 0x00000005,

        /// <summary>
        /// MB_CANCELTRYCONTINUE
        /// </summary>
        MB_CANCELTRYCONTINUE = 0x00000006,

        /// <summary>
        /// MB_ICONHAND
        /// </summary>
        MB_ICONHAND = 0x00000010,

        /// <summary>
        /// MB_ICONQUESTION
        /// </summary>
        MB_ICONQUESTION = 0x00000020,

        /// <summary>
        /// MB_ICONEXCLAMATION
        /// </summary>
        MB_ICONEXCLAMATION = 0x00000030,

        /// <summary>
        /// MB_ICONASTERISK
        /// </summary>
        MB_ICONASTERISK = 0x00000040,

        /// <summary>
        /// MB_USERICON
        /// </summary>
        MB_USERICON = 0x00000080,

        /// <summary>
        /// MB_ICONWARNING
        /// </summary>
        MB_ICONWARNING = MB_ICONEXCLAMATION,

        /// <summary>
        /// MB_ICONERROR
        /// </summary>
        MB_ICONERROR = MB_ICONHAND,

        /// <summary>
        /// MB_ICONINFORMATION
        /// </summary>
        MB_ICONINFORMATION = MB_ICONASTERISK,

        /// <summary>
        /// MB_ICONSTOP
        /// </summary>
        MB_ICONSTOP = MB_ICONHAND,

        /// <summary>
        /// MB_DEFBUTTON1
        /// </summary>
        MB_DEFBUTTON1 = 0x00000000,

        /// <summary>
        /// MB_DEFBUTTON2
        /// </summary>
        MB_DEFBUTTON2 = 0x00000100,

        /// <summary>
        /// MB_DEFBUTTON3
        /// </summary>
        MB_DEFBUTTON3 = 0x00000200,

        /// <summary>
        /// MB_DEFBUTTON4
        /// </summary>
        MB_DEFBUTTON4 = 0x00000300,

        /// <summary>
        /// MB_APPLMODAL
        /// </summary>
        MB_APPLMODAL = 0x00000000,

        /// <summary>
        /// MB_SYSTEMMODAL
        /// </summary>
        MB_SYSTEMMODAL = 0x00001000,

        /// <summary>
        /// MB_TASKMODAL
        /// </summary>
        MB_TASKMODAL = 0x00002000,

        /// <summary>
        /// MB_HELP
        /// </summary>
        MB_HELP = 0x00004000,

        /// <summary>
        /// MB_NOFOCUS
        /// </summary>
        MB_NOFOCUS = 0x00008000,

        /// <summary>
        /// MB_SETFOREGROUND
        /// </summary>
        MB_SETFOREGROUND = 0x00010000,

        /// <summary>
        /// MB_DEFAULT_DESKTOP_ONLY
        /// </summary>
        MB_DEFAULT_DESKTOP_ONLY = 0x00020000,

        /// <summary>
        /// MB_TOPMOST
        /// </summary>
        MB_TOPMOST = 0x00040000,

        /// <summary>
        /// MB_RIGHT
        /// </summary>
        MB_RIGHT = 0x00080000,

        /// <summary>
        /// MB_RTLREADING
        /// </summary>
        MB_RTLREADING = 0x00100000,

        /// <summary>
        /// MB_SERVICE_NOTIFICATION
        /// </summary>
        MB_SERVICE_NOTIFICATION = 0x00200000,

        /// <summary>
        /// MB_SERVICE_NOTIFICATION_NT3X
        /// </summary>
        MB_SERVICE_NOTIFICATION_NT3X = 0x00040000,

        /// <summary>
        /// MB_TYPEMASK
        /// </summary>
        MB_TYPEMASK = 0x0000000F,

        /// <summary>
        /// MB_ICONMASK
        /// </summary>
        MB_ICONMASK = 0x000000F0,

        /// <summary>
        /// MB_DEFMASK
        /// </summary>
        MB_DEFMASK = 0x00000F00,

        /// <summary>
        /// MB_MODEMASK
        /// </summary>
        MB_MODEMASK = 0x00003000,

        /// <summary>
        /// MB_MISCMASK
        /// </summary>
        MB_MISCMASK = 0x0000C000,
    }
}
