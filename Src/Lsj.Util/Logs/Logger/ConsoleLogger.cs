using System;
using System.Threading;
using Lsj.Util.Logs.Interfaces;

namespace Lsj.Util.Logs.Logger

{
    /// <summary>
    /// Console Logger
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        private ConsoleColor[] ConsoleColors { get; } = { ConsoleColor.White, ConsoleColor.Gray, ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Red };
        private readonly object lockobj = new object();

        /// <summary>
        /// Console Debug Color
        /// </summary>
        public ConsoleColor ConsoleDebugColor
        {
            get
            {
                return ConsoleColors[(int)LogType.Debug];
            }
            set
            {
                ConsoleColors[(int)LogType.Debug] = value;
            }
        }

        /// <summary>
        /// Console Info Color
        /// </summary>
        public ConsoleColor ConsoleInfoColor
        {
            get
            {
                return ConsoleColors[(int)LogType.Info];
            }
            set
            {
                ConsoleColors[(int)LogType.Info] = value;
            }
        }

        /// <summary>
        /// Console Warn Color
        /// </summary>
        public ConsoleColor ConsoleWarnColor
        {
            get
            {
                return ConsoleColors[(int)LogType.Warn];
            }
            set
            {
                ConsoleColors[(int)LogType.Warn] = value;
            }
        }

        /// <summary>
        /// Console Error Color
        /// </summary>
        public ConsoleColor ConsoleErrorColor
        {
            get
            {
                return ConsoleColors[(int)LogType.Error];
            }
            set
            {
                ConsoleColors[(int)LogType.Error] = value;
            }
        }

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
                var old = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColors[(int)type];
                Console.WriteLine($@"[{DateTime.Now.ToString()}] {str}");
                Console.ForegroundColor = old;
            }
            finally
            {
                Monitor.Exit(lockobj);
            }
        }
    }
}
