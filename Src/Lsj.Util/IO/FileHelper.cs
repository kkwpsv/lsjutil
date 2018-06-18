using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace Lsj.Util.IO
{
    /// <summary>
    /// FileHelper
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// GetFileLength
        /// </summary>
        /// <param name="path"></param>
        public static long GetFileLength(this string path)
        {
            var a = new FileInfo(path);
            if (!a.Exists)
            {
                return 0;
            }
            else
            {
                return a.Length;
            }
        }
        /// <summary>
        /// Check File Is Exists
        /// </summary>
        /// <param name="file">file</param>
        public static bool IsExistsFile(this string file)
        {
            return File.Exists(file);
        }
    }
}
