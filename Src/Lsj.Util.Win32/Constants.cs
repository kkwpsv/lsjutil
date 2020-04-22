using Lsj.Util.Win32.Enums;
using System;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Constants
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// ANYSIZE_ARRAY
        /// </summary>
        public const int ANYSIZE_ARRAY = 1;

        /// <summary>
        /// CACHE_FULLY_ASSOCIATIVE
        /// </summary>
        public const byte CACHE_FULLY_ASSOCIATIVE = 0xFF;

        /// <summary>
        /// HOVER_DEFAULT
        /// </summary>
        public const uint HOVER_DEFAULT = 0xFFFFFFFF;

        /// <summary>
        /// MAX_PATH
        /// </summary>
        public const int MAX_PATH = 260;

        /// <summary>
        /// INFINITE
        /// </summary>
        public const uint INFINITE = 0xFFFFFFFF;

        /// <summary>
        /// EXCEPTION_MAXIMUM_PARAMETERS
        /// </summary>
        public const int EXCEPTION_MAXIMUM_PARAMETERS = 15;

        /// <summary>
        /// STILL_ACTIVE
        /// </summary>
        public const uint STILL_ACTIVE = (uint)NTSTATUS.STATUS_PENDING;

        /// <summary>
        /// USER_TIMER_MAXIMUM
        /// </summary>
        public const uint USER_TIMER_MAXIMUM = 0x7FFFFFFF;

        /// <summary>
        /// USER_TIMER_MINIMUM
        /// </summary>
        public const uint USER_TIMER_MINIMUM = 0x0000000A;

        /// <summary>
        /// INVALID_HANDLE_VALUE
        /// </summary>
        public readonly static IntPtr INVALID_HANDLE_VALUE = (IntPtr)(-1);

        /// <summary>
        /// NULL
        /// </summary>
        public readonly static IntPtr NULL = IntPtr.Zero;

        /// <summary>
        /// WHEEL_DELTA
        /// </summary>
        public static int WHEEL_DELTA = 120;
    }
}
