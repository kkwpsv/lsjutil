using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Logs
{
    /// <summary>
    /// Log Config
    /// </summary>
    public class LogConfig
    {
        /// <summary>
        /// Default
        /// </summary>
        public static LogConfig Default
        {
            get
            {
                return new LogConfig();
            }
        }

        /// <summary>
        /// IsUseConsole
        /// </summary>
        public bool UseConsole { get; set; } = true;
        /// <summary>
        /// ConsoleColors
        /// </summary>
        public ConsoleColor[] ConsoleColors { get; set; } = { ConsoleColor.White, ConsoleColor.Gray, ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Red };

        /// <summary>
        /// IsUseFile
        /// </summary>
        public bool UseFile { get; set; } = true;
        /// <summary>
        /// FilePath
        /// </summary>
        public string FilePath { get; set; } = "./";


    }
}
