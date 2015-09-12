using System;

namespace Lsj.Util
{
    /// <summary>
    /// 静态方法类
    /// </summary>
    public static class Static
    {

        /// <summary>
        /// 获取程序的基目录 eg. C:\a\
        /// </summary>
        public static string CurrentPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }


        public static string Version = "1.0";
    }
}
