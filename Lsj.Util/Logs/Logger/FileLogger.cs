using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

#if NETCOREAPP1_1
using Lsj.Util.Core.Logs.Interfaces;
using Lsj.Util.Core.IO;
#else
using Lsj.Util.Logs.Interfaces;
using Lsj.Util.IO;
#endif


#if NETCOREAPP1_1
namespace Lsj.Util.Core.Logs.Logger
#else
namespace Lsj.Util.Logs.Logger
#endif
{
    /// <summary>
    /// File logger.
    /// </summary>
    public class FileLogger : ILogger
    {
        /// <summary>
        /// FilePath
        /// </summary>
        public string FilePath { get; set; } = "./";


        private readonly object lockobj = new object();
        /// <summary>
        /// Add the specified str and type.
        /// </summary>
        /// <returns>The add.</returns>
        /// <param name="str">String.</param>
        /// <param name="type">Type.</param>
        public void Add(string str, eLogType type)
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

                while (FileHelper.GetLength(name + (num == 0 ? "" : $"-{num}") + ".log") > 100 * 1024 * 1024)//100k
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
