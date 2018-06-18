using System;


namespace Lsj.Util
{
    /// <summary>
    /// Static
    /// </summary>
    public static class Static
    {
#if !NETSTANDARD
        /// <summary>
        /// CurrentPath eg. C:\a\
        /// </summary>
        public static string CurrentPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
#endif
    }
}