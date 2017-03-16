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

        /// <summary>
        /// Version
        /// </summary>
        public static readonly string Version = "2.0";
    }
}