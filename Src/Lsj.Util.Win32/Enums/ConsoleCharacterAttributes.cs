﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Console Character Attributes.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/console/char-info-str"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum ConsoleCharacterAttributes : ushort
    {
        /// <summary>
        /// Text color contains blue.
        /// </summary>
        FOREGROUND_BLUE = 0x0001,

        /// <summary>
        /// Text color contains green.
        /// </summary>
        FOREGROUND_GREEN = 0x0002,

        /// <summary>
        /// Text color contains red.
        /// </summary>
        FOREGROUND_RED = 0x0004,

        /// <summary>
        /// Text color is intensified.
        /// </summary>
        FOREGROUND_INTENSITY = 0x0008,

        /// <summary>
        /// Background color contains blue.
        /// </summary>
        BACKGROUND_BLUE = 0x0010,

        /// <summary>
        /// Background color contains green.
        /// </summary>
        BACKGROUND_GREEN = 0x0020,

        /// <summary>
        /// Background color contains red.
        /// </summary>
        BACKGROUND_RED = 0x0040,

        /// <summary>
        /// Background color is intensified.
        /// </summary>
        BACKGROUND_INTENSITY = 0x0080,

        /// <summary>
        /// Leading byte.
        /// </summary>
        COMMON_LVB_LEADING_BYTE = 0x0100,

        /// <summary>
        /// Trailing byte.
        /// </summary>
        COMMON_LVB_TRAILING_BYTE = 0x0200,

        /// <summary>
        /// Top horizontal
        /// </summary>
        COMMON_LVB_GRID_HORIZONTAL = 0x0400,

        /// <summary>
        /// Left vertical.
        /// </summary>
        COMMON_LVB_GRID_LVERTICAL = 0x0800,

        /// <summary>
        /// Right vertical.
        /// </summary>
        COMMON_LVB_GRID_RVERTICAL = 0x1000,

        /// <summary>
        /// Reverse foreground and background attribute.
        /// </summary>
        COMMON_LVB_REVERSE_VIDEO = 0x4000,

        /// <summary>
        /// Underscore.
        /// </summary>
        COMMON_LVB_UNDERSCORE = 0x8000,
    }
}
