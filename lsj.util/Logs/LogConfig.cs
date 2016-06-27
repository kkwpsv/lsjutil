using Lsj.Util.Logs.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        #region Console
        /// <summary>
        /// IsUseConsole
        /// </summary>
        public bool UseConsole { get; set; } = false;
        /// <summary>
        /// ConsoleColors
        /// </summary>
        public ConsoleColor[] ConsoleColors { get; } = { ConsoleColor.White, ConsoleColor.Gray, ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Red };
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
        #endregion

        #region File
        /// <summary>
        /// IsUseFile
        /// </summary>
        public bool UseFile { get; set; } = false;
        /// <summary>
        /// FilePath
        /// </summary>
        public string FilePath { get; set; } = "./";
        #endregion

        #region LogView
        /// <summary>
        /// UseLogView
        /// </summary>
        public bool UseLogView { get; set; } = false;
        /// <summary>
        /// LogView
        /// </summary>
        public LogView LogView { get; set; } = null;
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

        #endregion

        #region MessageBox
        /// <summary>
        /// IsUseFile
        /// </summary>
        public bool UseMessageBox { get; set; } = false;
        #endregion 


    }
}
