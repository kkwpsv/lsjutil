using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Logs
{
    public class LogConfig
    {
        public static LogConfig Default
        {
            get
            {
                return new LogConfig();
            }
        }


        public bool UseConsole { get; set; } = true;

        public ConsoleColor[] ConsoleColors { get; set; } = { ConsoleColor.White, ConsoleColor.Gray, ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Red };


        public bool UseFile { get; set; } = true;
        public string FilePath { get; set; } = "./";


    }
}
