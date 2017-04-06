using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Lsj.Util.Logs.Interfaces;

namespace Lsj.Util.Logs.Logger
{
    /// <summary>
    /// 
    /// </summary>
    public class ConsoleLogger :ILogger
    {
        ConsoleColor[] ConsoleColors { get; } = { ConsoleColor.White, ConsoleColor.Gray, ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Red };
        /// <summary>
        /// ConsoleDebugColor
        /// </summary>
        public ConsoleColor ConsoleDebugColor
        {
            get
            {
                return ConsoleColors[(int)eLogType.Debug];
            }
            set
            {
                ConsoleColors[(int)eLogType.Debug] = value;
            }
        }
        /// <summary>
        /// ConsoleInfoColor
        /// </summary>
        public ConsoleColor ConsoleInfoColor
        {
            get
            {
                return ConsoleColors[(int)eLogType.Info];
            }
            set
            {
                ConsoleColors[(int)eLogType.Info] = value;
            }
        }
        /// <summary>
        /// ConsoleWarnColor
        /// </summary>
        public ConsoleColor ConsoleWarnColor
        {
            get
            {
                return ConsoleColors[(int)eLogType.Warn];
            }
            set
            {
                ConsoleColors[(int)eLogType.Warn] = value;
            }
        }
        /// <summary>
        /// ConsoleErrorColor
        /// </summary>
        public ConsoleColor ConsoleErrorColor
        {
            get
            {
                return ConsoleColors[(int)eLogType.Error];
            }
            set
            {
                ConsoleColors[(int)eLogType.Error] = value;
            }
        }

        private object lockobj = new object();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="type"></param>
        public void Add(string str, eLogType type)
        {
            Monitor.Enter(lockobj);
            try
            {
                ConsoleColor old = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColors[(int)type];
                Console.WriteLine($@"[{DateTime.Now.ToString()}] {str}");
                Console.ForegroundColor = old;
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
