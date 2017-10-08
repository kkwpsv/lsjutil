using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Lsj.Util.Logs.Interfaces;
using Lsj.Util.IO;




namespace Lsj.Util.Logs.Logger
{
    /// <summary>
    /// File Logger
    /// </summary>
    public class FileLogger : ILogger
    {
        /// <summary>
        /// FilePath
        /// </summary>
        public string FilePath { get; set; } = "./";


        private readonly object lockobj = new object();
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
                if (!FilePath.IsExistsPath())
                {
                    Directory.CreateDirectory(FilePath);
                }
                var name = FilePath + DateTime.Now.ToString("yyyy-MM-dd");
                var num = 0;

                while (FileHelper.GetFileLength(name + (num == 0 ? "" : $"-{num}") + ".log") > 100 * 1024 * 1024)//100k
                {
                    num++;
                }
                name = name + (num == 0 ? "" : $"-{num}") + ".log";
                File.AppendAllText(name,
$@"[{type.ToString()}] {DateTime.Now.ToString()} 
{str}
");
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
