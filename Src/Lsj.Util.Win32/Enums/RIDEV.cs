using System;
using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="RAWINPUTDEVICE"/> Flags
    /// </summary>
    [Flags]
    public enum RIDEV
    {
        /// <summary>
        /// RIDEV_REMOVE
        /// </summary>
        RIDEV_REMOVE = 0x00000001,

        /// <summary>
        /// RIDEV_EXCLUDE
        /// </summary>
        RIDEV_EXCLUDE = 0x00000010,

        /// <summary>
        /// RIDEV_PAGEONLY
        /// </summary>
        RIDEV_PAGEONLY = 0x00000020,

        /// <summary>
        /// RIDEV_NOLEGACY
        /// </summary>
        RIDEV_NOLEGACY = 0x00000030,

        /// <summary>
        /// RIDEV_INPUTSINK
        /// </summary>
        RIDEV_INPUTSINK = 0x00000100,

        /// <summary>
        /// RIDEV_CAPTUREMOUSE
        /// </summary>
        RIDEV_CAPTUREMOUSE = 0x00000200,

        /// <summary>
        /// RIDEV_NOHOTKEYS
        /// </summary>
        RIDEV_NOHOTKEYS = 0x00000200,

        /// <summary>
        /// RIDEV_APPKEYS
        /// </summary>
        RIDEV_APPKEYS = 0x00000400,

        /// <summary>
        /// RIDEV_EXINPUTSINK
        /// </summary>
        RIDEV_EXINPUTSINK = 0x00001000,

        /// <summary>
        /// RIDEV_DEVNOTIFY
        /// </summary>
        RIDEV_DEVNOTIFY = 0x00002000,
    }
}
