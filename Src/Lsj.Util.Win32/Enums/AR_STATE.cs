using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Indicates the state of screen auto-rotation for the system.
    /// For example, whether auto-rotation is supported, and whether it is enabled by the user.
    /// This enum is a bitwise OR of one or more of the following values.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ne-winuser-ar_state"/>
    /// </para>
    /// </summary>
    public enum AR_STATE
    {
        /// <summary>
        /// Auto-rotation is enabled by the user.
        /// </summary>
        AR_ENABLED = 0x0,

        /// <summary>
        /// Auto-rotation is disabled by the user.
        /// </summary>
        AR_DISABLED = 0x1,

        /// <summary>
        /// Auto-rotation is currently suppressed by one or more process auto-rotation preferences.
        /// </summary>
        AR_SUPPRESSED = 0x2,

        /// <summary>
        /// The session is remote, and auto-rotation is temporarily disabled as a result.
        /// </summary>
        AR_REMOTESESSION = 0x4,

        /// <summary>
        /// The system has multiple monitors attached, and auto-rotation is temporarily disabled as a result.
        /// </summary>
        AR_MULTIMON = 0x8,

        /// <summary>
        /// The system does not have an auto-rotation sensor.
        /// </summary>
        AR_NOSENSOR = 0x10,

        /// <summary>
        /// Auto-rotation is not supported with the current system configuration.
        /// </summary>
        AR_NOT_SUPPORTED = 0x20,

        /// <summary>
        /// The device is docked, and auto-rotation is temporarily disabled as a result.
        /// </summary>
        AR_DOCKED = 0x40,

        /// <summary>
        /// The device is in laptop mode, and auto-rotation is temporarily disabled as a result.
        /// </summary>
        AR_LAPTOP = 0x80
    }
}
