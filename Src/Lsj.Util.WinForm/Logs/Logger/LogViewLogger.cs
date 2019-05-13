using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Lsj.Util.IO;
using Lsj.Util.Logs;
using Lsj.Util.Logs.Interfaces;

namespace Lsj.Util.WinForm.Logs.Logger
{
    /// <summary>
    /// LogView Logger
    /// </summary>
    public class LogViewLogger : ILogger
    {
        private readonly object lockobj = new object();
        /// <summary>
        /// LogView
        /// </summary>
        public LogView LogView { get; set; }

        private Color[] LogViewColors { get; } = { Color.White, Color.Gray, Color.Green, Color.Yellow, Color.Red };

        /// <summary>
        /// LogView Debug Color
        /// </summary>
        public Color LogViewDebugColor
        {
            get
            {
                return LogViewColors[(int)LogType.Debug];
            }
            set
            {
                LogViewColors[(int)LogType.Debug] = value;
            }
        }

        /// <summary>
        /// LogView Info Color
        /// </summary>
        public Color LogViewInfoColor
        {
            get
            {
                return LogViewColors[(int)LogType.Info];
            }
            set
            {
                LogViewColors[(int)LogType.Info] = value;
            }
        }

        /// <summary>
        /// LogView Warn Color
        /// </summary>
        public Color LogViewWarnColor
        {
            get
            {
                return LogViewColors[(int)LogType.Warn];
            }
            set
            {
                LogViewColors[(int)LogType.Warn] = value;
            }
        }

        /// <summary>
        /// LogView Error Color
        /// </summary>
        public Color LogViewErrorColor
        {
            get
            {
                return LogViewColors[(int)LogType.Error];
            }
            set
            {
                LogViewColors[(int)LogType.Error] = value;
            }
        }

        /// <summary>
        /// Add Log
        /// </summary>
        /// <param name="str">content</param>
        /// <param name="type">type</param>
        public void Add(string str, LogType type)
        {
            if (this.LogView == null)
            {
                return;
            }
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