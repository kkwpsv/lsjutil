using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;


namespace Lsj.Util.IO
{
    /// <summary>
    /// Directory Helper
    /// </summary>
    public static class DirectoryHelper
    {
        /// <summary>
        /// Get All Files including child directory
        /// </summary>
        /// <param name="path">path</param>
        /// <param name="filter">filter</param>
        public static List<FileInfo> GetAllFiles(DirectoryInfo path, string filter)
        {
            var result = new List<FileInfo>();
            if (path.Exists)
            {
                result.AddRange(path.GetFiles(filter));
                DirectoryInfo[] directories = path.GetDirectories();
                for (int i = 0; i < directories.Length; i++)
                {
                    DirectoryInfo subdir = directories[i];
                    result.AddRange(GetAllFiles(subdir, filter));
                }
            }
            return result;
        }
        /// <summary>
        /// Check Path Is Exists
        /// </summary>
        /// <param name="path">path</param>
        public static bool IsExistsPath(this string path)
        {
            return Directory.Exists(path);
        }

    }
}