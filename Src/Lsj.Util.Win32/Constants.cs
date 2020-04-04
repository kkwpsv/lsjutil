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
        /// AccessSystemAcl access type
        /// </summary>
        public const uint ACCESS_SYSTEM_SECURITY = 0x01000000;

        /// <summary>
        /// INFINITE
        /// </summary>
        public const uint INFINITE = 0xFFFFFFFF;

        /// <summary>
        /// MaximumAllowed access type
        /// </summary>
        public const uint MAXIMUM_ALLOWED = 0x02000000;

        /// <summary>
        /// INVALID_HANDLE_VALUE
        /// </summary>
        public readonly static IntPtr INVALID_HANDLE_VALUE = (IntPtr)(-1);

        /// <summary>
        /// NULL
        /// </summary>
        public readonly static IntPtr NULL = IntPtr.Zero;
    }
}
