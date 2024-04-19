using System;
using System.IO;
using System.Threading;
using Lsj.Util.IO;
using Lsj.Util.Logs.Interfaces;

namespace Lsj.Util.Logs.Logger
{
    /// <summary>
    /// File Logger
    /// </summary>
    public class FileLogger : ILogger
    {
        private readonly object lockobj = new object();

        /// <summary>
        /// FilePath (auto append yyyy-MM-dd.log suffix)
        /// </summary>
        public string FilePath { get; set; } = "./";

        /// <summary>
        /// Add Log
        /// </summary>
        /// <param name="str">content</param>
        /// <param name="type">type</param>
        public void Add(string str, LogType type)
        {
            Monitor.Enter(lockobj);
            try
            {
                var folder = Path.GetDirectoryName(FilePath);
                Directory.CreateDirectory(folder!);

                var name = FilePath + DateTime.Now.ToString("yyyy-MM-dd");
                var num = 0;

                while (FileHelper.GetFileLength(name + (num == 0 ? "" : $"-{num}") + ".log") > 100 * 1024 * 1024)//100k
                {
                    num++;
                }
                name = name + (num == 0 ? "" : $"-{num}") + ".log";
                File.AppendAllText(name, $"[{type.ToString()}] {DateTime.Now.ToString()} \n{str}\n");
            }
            catch
            {
            }
            finally
            {
                Monitor.Exit(lockobj);
            }
        }
    }
}
