using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Lsj.Util.IO;
using System.IO;

namespace Lsj.Util.Logs
{
    /// <summary>
    /// Log
    /// </summary>
    public class LogProvider
    {
        /// <summary>
        /// Default
        /// </summary>
        public static LogProvider Default
        {
            get
            {
                if (m_default == null)
                {
                    m_default = new LogProvider(LogConfig.Default);
                }
                return m_default;
            }
            set
            {
                m_default = value;
            }
        }
        private static LogProvider m_default;



        private object @lock = new object();

        private LogConfig m_config;
        /// <summary>
        /// Initial a new Log
        /// </summary>
        /// <param name="config"></param>
        public LogProvider(LogConfig config)
        {
            this.m_config = config;
        }
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="str"></param>
        /// <param name="type"></param>
        public void Add(string str, eLogType type)
        {
            Monitor.Enter(@lock);
            try
            {
                if (m_config.UseConsole)
                {
                    ConsoleColor old = Console.ForegroundColor;
                    Console.ForegroundColor = m_config.ConsoleColors[(int)type];                   
                    Console.WriteLine($@"[{DateTime.Now.ToString()}] {str}");
                    Console.ResetColor();
                }
                if (m_config.UseFile)
                {
                    if (!m_config.FilePath.IsExistsPath())
                    {
                        Directory.CreateDirectory(m_config.FilePath);
                    }
                    var name = m_config.FilePath + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
                    File.AppendAllText(name, 
$@"[{type.ToString()}] {DateTime.Now.ToString()} 
{str}
");
                }
            }
            catch (Exception e)
            {
                WinForm.Notice(e.ToString());
            }
            finally
            {
                Monitor.Exit(@lock);
            }
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="str"></param>
        /// <param name="e"></param>
        /// <param name="type"></param>
        public void Add(string str, Exception e, eLogType type) => Add(str + "\n" + e.ToString(),type);

        /// <summary>
        /// Debug
        /// </summary>
        /// <param name="str"></param>
        public void Debug(string str)=>Add(str, eLogType.Debug);
        /// <summary>
        /// Info
        /// </summary>
        /// <param name="str"></param>
        public void Info(string str) => Add(str, eLogType.Info);
        /// <summary>
        /// Warn
        /// </summary>
        /// <param name="str"></param>
        public void Warn(string str) => Add(str, eLogType.Warn);
        /// <summary>
        /// Error
        /// </summary>
        /// <param name="str"></param>
        public void Error(string str) => Add(str, eLogType.Error);
        /// <summary>
        /// Error
        /// </summary>
        /// <param name="obj"></param>
        public void Error(object obj) => Add(obj.ToString(), eLogType.Error);
        /// <summary>
        /// Debug
        /// </summary>
        /// <param name="e"></param>
        public void Debug(Exception e) => Debug(e.ToString());
        /// <summary>
        /// Info
        /// </summary>
        /// <param name="e"></param>
        public void Info(Exception e) => Info(e.ToString());
        /// <summary>
        /// Warn
        /// </summary>
        /// <param name="e"></param>
        public void Warn(Exception e) => Warn(e.ToString());
        /// <summary>
        /// Error
        /// </summary>
        /// <param name="e"></param>
        public void Error(Exception e) => Error(e.ToString());
        /// <summary>
        /// Warn
        /// </summary>
        /// <param name="str"></param>
        /// <param name="e"></param>
        public void Warn(string str, Exception e) => Add(str, e, eLogType.Warn);
        /// <summary>
        /// Error
        /// </summary>
        /// <param name="str"></param>
        /// <param name="e"></param>
        public void Error(string str,Exception e) => Add(str,e,eLogType.Error);
        /// <summary>
        /// WarnFormat
        /// </summary>
        /// <param name="str"></param>
        /// <param name="obj"></param>
        public void WarnFormat(string str, params object[] obj) => Add(string.Format(str, obj), eLogType.Warn);
        /// <summary>
        /// ErrorFormat
        /// </summary>
        /// <param name="str"></param>
        /// <param name="obj"></param>
        public void ErrorFormat(string str, params object[] obj) => Add(string.Format(str, obj), eLogType.Error);
        /// <summary>
        /// InfoFormat
        /// </summary>
        /// <param name="str"></param>
        /// <param name="obj"></param>
        public void InfoFormat(string str, params object[] obj) => Add(string.Format(str, obj), eLogType.Info);
        /// <summary>
        /// DebugFormat
        /// </summary>
        /// <param name="str"></param>
        /// <param name="obj"></param>
        public void DebugFormat(string str, params object[] obj) => Add(string.Format(str, obj), eLogType.Debug);


    }
}
