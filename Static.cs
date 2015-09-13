using System;

namespace Lsj.Util
{
    /// <summary>
    /// Static
    /// </summary>
    public static class Static
    {

        /// <summary>
        /// CurrentPath eg. C:\a\
        /// </summary>
        public static string CurrentPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }


        public static readonly string Version = "1.0";
    }
}