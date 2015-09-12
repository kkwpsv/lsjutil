using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Config
{
    /// <summary>
    /// Ini配置文件读取类
    /// </summary>
    public class Ini
    {
        string path;
        /// <summary>
        /// 用Ini路径初始化一个新实例
        /// <param name="path">Ini路径</param>  
        /// </summary>
        public Ini(string path)
        {
            this.path = path;
        }

        /// <summary>
        /// 写INI文件
        /// </summary>
        /// <param name="Section">Section</param>
        /// <param name="Key">Key</param>
        /// <param name="Value">值</param>
        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.path);
        }

        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(512);
            long i = GetPrivateProfileString(Section, Key, "Null", temp, 512, this.path);
            return temp.ToString();
        }




        [DllImport("kernel32.dll")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32.dll")]
        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
    }
}
