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
        /// GetLength
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static long GetLength(string path)
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
    }
}
