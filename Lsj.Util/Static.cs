using System;


namespace Lsj.Util
{
    /// <summary>
    /// Static
    /// </summary>
    public static class Static
    {
#if !NETCOREAPP1_1
        /// <summary>
        /// CurrentPath eg. C:\a\
        /// </summary>
        public static string CurrentPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
#endif

        /// <summary>
        /// Version
        /// </summary>
        public static readonly string Version = "1.0";
    }
}