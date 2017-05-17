using System;
using System.Collections.Generic;

#if NETCOREAPP1_1
using Lsj.Util.Core.Logs.Interfaces;
#else
using Lsj.Util.Logs.Interfaces;
#endif


#if NETCOREAPP1_1
namespace Lsj.Util.Core.Logs
#else
namespace Lsj.Util.Logs
#endif
{
    /// <summary>
    /// Log provider.
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
                    m_default = new LogProvider();
                }
                return m_default;
            }
            set
            {
                m_default = value;
            }
        }
        private static LogProvider m_default;
        /// <summary>
        /// Gets the loggers.
        /// </summary>
        /// <value>The loggers.</value>
        public List<ILogger> Loggers
        {
            get;
        } = new List<ILogger>();

        /// <summary>
        /// Initialize a new Log
        /// </summary>
        public LogProvider()
        {
        }

        /// <summary>
        /// Gets or sets the log level.
        /// </summary>
        /// <value>The log level.</value>
        public eLogType LogLevel
        {
            get;
            set;
        } = eLogType.None;
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="str"></param>
        /// <param name="type"></param>
        public void Add(string str, eLogType type)
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
        /// Add
        /// </summary>
        /// <param name="str"></param>
        /// <param name="e"></param>
        /// <param name="type"></param>
        public void Add(string str, Exception e, eLogType type) => Add(str + "\n" + e.ToString(), type);

        /// <summary>
        /// Debug
        /// </summary>
        /// <param name="str"></param>
        public void Debug(string str) => Add(str, eLogType.Debug);
        /// <summary>
        /// Debug
        /// </summary>
        /// <param name="o"></param>
        public void Debug(object o) => Debug(o.ToString());
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
        public void Error(string str, Exception e) => Add(str, e, eLogType.Error);
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
