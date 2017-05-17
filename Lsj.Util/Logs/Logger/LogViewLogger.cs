#if !NETCOREAPP1_1
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
    /// Log view logger.
    /// </summary>
    public class LogViewLogger : ILogger
    {
        /// <summary>
        /// LogView
        /// </summary>
        public LogView LogView { get; set; } = new LogView();
        /// <summary>
        /// LogViewColors
        /// </summary>
        public Color[] LogViewColors { get; } = { Color.White, Color.Gray, Color.Green, Color.Yellow, Color.Red };
        /// <summary>
        /// LogViewDebugColor
        /// </summary>
        public Color LogViewDebugColor
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
        /// LogViewInfoColor
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
        /// LogViewWarnColor
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
        /// LogViewErrorColor
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
#endif