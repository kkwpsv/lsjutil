using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Lsj.Util.IO;
using Lsj.Util.Logs.Interfaces;

namespace Lsj.Util.Logs.Logger
{
    /// <summary>
    /// 
    /// </summary>
    public class LogViewLogger :ILogger
    {
        /// <summary>
        /// LogView
        /// </summary>
        public LogView LogView { get; } = new LogView();
        /// <summary>
        /// ConsoleColors
        /// </summary>
        public Color[] LogViewColors { get; } = { Color.White, Color.Gray, Color.Green, Color.Yellow, Color.Red };
        /// <summary>
        /// ConsoleDebugColor
        /// </summary>
        public Color LogViewColor
        {
            get
            {
                return LogViewColors[(int)eLogType.Debug];
            }
            set
            {
                LogViewColors[(int)eLogType.Debug] = value;
            }
        }
        /// <summary>
        /// ConsoleInfoColor
        /// </summary>
        public Color LogViewInfoColor
        {
            get
            {
                return LogViewColors[(int)eLogType.Info];
            }
            set
            {
                LogViewColors[(int)eLogType.Info] = value;
            }
        }
        /// <summary>
        /// ConsoleWarnColor
        /// </summary>
        public Color LogViewWarnColor
        {
            get
            {
                return LogViewColors[(int)eLogType.Warn];
            }
            set
            {
                LogViewColors[(int)eLogType.Warn] = value;
            }
        }
        /// <summary>
        /// ConsoleErrorColor
        /// </summary>
        public Color LogViewErrorColor
        {
            get
            {
                return LogViewColors[(int)eLogType.Error];
            }
            set
            {
                LogViewColors[(int)eLogType.Error] = value;
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
                LogView.Select(LogView.TextLength, 1);  //WTF!!!!!!!
                LogView.SelectionColor = LogViewColors[(int)type];
                LogView.IsNewAdd = true;
                LogView.AppendLine($@"[{DateTime.Now.ToString()}] {str}");
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
