using Lsj.Util.Logs.Interfaces;
using System;
using System.Collections.Generic;

namespace Lsj.Util.Logs
{
    /// <summary>
    /// Log Provider
    /// </summary>
    public class LogProvider
    {
        /// <summary>
        /// Default
        /// </summary>
        public static LogProvider Default { get; set; } = new LogProvider();

        /// <summary>
        /// Get Loggers
        /// </summary>
        public List<ILogger> Loggers { get; } = new List<ILogger>();

        /// <summary>
        /// Log Level
        /// </summary>
        public LogType LogLevel { get; set; } = LogType.None;

        /// <summary>
        /// Add Log
        /// </summary>
        /// <param name="str">content</param>
        /// <param name="type">type</param>
        public void Add(string str, LogType type)
        {
            if (type >= LogLevel)
            {
                foreach (var logger in Loggers)
                {
                    logger.Add(str, type);
                }
            }
        }

        /// <summary>
        /// Add Log
        /// </summary>
        /// <param name="str">content</param>
        /// <param name="e">exception</param>
        /// <param name="type">type</param>
        public void Add(string str, Exception e, LogType type) => Add(str + Environment.NewLine + e.ToString(), type);

        /// <summary>
        /// Debug
        /// </summary>
        /// <param name="str">content</param>
        public void Debug(string str) => Add(str, LogType.Debug);

        /// <summary>
        /// Debug
        /// </summary>
        /// <param name="o">content</param>
        public void Debug(object o) => Debug(o.ToString());

        /// <summary>
        /// Info
        /// </summary>
        /// <param name="str">content</param>
        public void Info(string str) => Add(str, LogType.Info);

        /// <summary>
        /// Warn
        /// </summary>
        /// <param name="str">content</param>
        public void Warn(string str) => Add(str, LogType.Warn);

        /// <summary>
        /// Error
        /// </summary>
        /// <param name="str">content</param>
        public void Error(string str) => Add(str, LogType.Error);

        /// <summary>
        /// Error
        /// </summary>
        /// <param name="obj">content</param>
        public void Error(object obj) => Add(obj.ToString(), LogType.Error);

        /// <summary>
        /// Debug
        /// </summary>
        /// <param name="e">exception</param>
        public void Debug(Exception e) => Debug(e.ToString());

        /// <summary>
        /// Info
        /// </summary>
        /// <param name="e">exception</param>
        public void Info(Exception e) => Info(e.ToString());

        /// <summary>
        /// Warn
        /// </summary>
        /// <param name="e">exception</param>
        public void Warn(Exception e) => Warn(e.ToString());

        /// <summary>
        /// Error
        /// </summary>
        /// <param name="e">exception</param>
        public void Error(Exception e) => Error(e.ToString());

        /// <summary>
        /// Warn
        /// </summary>
        /// <param name="str">content</param>
        /// <param name="e">exception</param>
        public void Warn(string str, Exception e) => Add(str, e, LogType.Warn);

        /// <summary>
        /// Error
        /// </summary>
        /// <param name="str">content</param>
        /// <param name="e">exception</param>
        public void Error(string str, Exception e) => Add(str, e, LogType.Error);

        /// <summary>
        /// WarnFormat
        /// </summary>
        /// <param name="str">format</param>
        /// <param name="obj">args</param>
        public void WarnFormat(string str, params object[] obj) => Add(string.Format(str, obj), LogType.Warn);

        /// <summary>
        /// ErrorFormat
        /// </summary>
        /// <param name="str">format</param>
        /// <param name="obj">args</param>
        public void ErrorFormat(string str, params object[] obj) => Add(string.Format(str, obj), LogType.Error);

        /// <summary>
        /// InfoFormat
        /// </summary>
        /// <param name="str">format</param>
        /// <param name="obj">args</param>
        public void InfoFormat(string str, params object[] obj) => Add(string.Format(str, obj), LogType.Info);

        /// <summary>
        /// DebugFormat
        /// </summary>
        /// <param name="str">format</param>
        /// <param name="obj">args</param>
        public void DebugFormat(string str, params object[] obj) => Add(string.Format(str, obj), LogType.Debug);
    }
}
