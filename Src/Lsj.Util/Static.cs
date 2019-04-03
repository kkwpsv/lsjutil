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
        /// Just Do Nothing (To make code shorter sometimes)
        /// </summary>
        public static void DoNothing()
        {
        }

        /// <summary>
        /// Version
        /// </summary>
        public static Version Version => typeof(Static).Assembly.GetName().Version;
    }
}