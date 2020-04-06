namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Window Hook Types
    /// </summary>
    public enum WindowHookTypes
    {
        /// <summary>
        /// WH_MIN
        /// </summary>
        WH_MIN = (-1),

        /// <summary>
        /// WH_MSGFILTER
        /// </summary>
        WH_MSGFILTER = (-1),

        /// <summary>
        /// WH_JOURNALRECORD
        /// </summary>
        WH_JOURNALRECORD = 0,

        /// <summary>
        /// WH_JOURNALPLAYBACK
        /// </summary>
        WH_JOURNALPLAYBACK = 1,

        /// <summary>
        /// WH_KEYBOARD
        /// </summary>
        WH_KEYBOARD = 2,

        /// <summary>
        /// WH_GETMESSAGE
        /// </summary>
        WH_GETMESSAGE = 3,

        /// <summary>
        /// WH_CALLWNDPROC
        /// </summary>
        WH_CALLWNDPROC = 4,

        /// <summary>
        /// WH_CBT
        /// </summary>
        WH_CBT = 5,

        /// <summary>
        /// WH_SYSMSGFILTER
        /// </summary>
        WH_SYSMSGFILTER = 6,

        /// <summary>
        /// WH_MOUSE
        /// </summary>
        WH_MOUSE = 7,

        /// <summary>
        /// WH_HARDWARE
        /// </summary>
        WH_HARDWARE = 8,

        /// <summary>
        /// WH_DEBUG
        /// </summary>
        WH_DEBUG = 9,

        /// <summary>
        /// WH_SHELL
        /// </summary>
        WH_SHELL = 10,

        /// <summary>
        /// WH_FOREGROUNDIDLE
        /// </summary>
        WH_FOREGROUNDIDLE = 11,

        /// <summary>
        /// WH_CALLWNDPROCRET
        /// </summary>
        WH_CALLWNDPROCRET = 12,

        /// <summary>
        /// WH_KEYBOARD_LL
        /// </summary>
        WH_KEYBOARD_LL = 13,

        /// <summary>
        /// WH_MOUSE_LL
        /// </summary>
        WH_MOUSE_LL = 14,

        /// <summary>
        /// WH_MAX
        /// </summary>
        WH_MAX = 14,

        /// <summary>
        /// WH_MINHOOK
        /// </summary>
        WH_MINHOOK =       WH_MIN,

        /// <summary>
        /// WH_MAXHOOK
        /// </summary>
        WH_MAXHOOK =      WH_MAX,
    }
}
