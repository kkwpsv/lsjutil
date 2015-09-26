using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Log
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
        public ConsoleColor ConsoleDebugColor { get; set; } = ConsoleColor.Gray;
        public ConsoleColor ConsoleInfoColor { get; set; } = ConsoleColor.Green;
        public ConsoleColor ConsoleWarnColor { get; set; } = ConsoleColor.Yellow;
        public ConsoleColor ConsoleErrorColor { get; set; } = ConsoleColor.Red;





        public bool UseFile { get; set; } = true;
        public string FilePath { get; set; } = "/";


    }
}
