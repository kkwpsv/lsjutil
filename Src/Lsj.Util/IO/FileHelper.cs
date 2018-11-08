using System.IO;

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
            var file = new FileInfo(path);
            if (!file.Exists)
            {
                return 0;
            }
            else
            {
                return file.Length;
            }
        }

        /// <summary>
        /// Check File Is Exists
        /// </summary>
        /// <param name="file">file</param>
        public static bool IsExistsFile(this string file) => File.Exists(file);
    }
}
