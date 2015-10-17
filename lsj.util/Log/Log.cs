using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Lsj.Util.IO;
using System.IO;

namespace Lsj.Util.Log
{
    public class Log
    {
        public static Log Default
        {
            get
            {
                if (m_default == null)
                {
                    m_default = new Log(LogConfig.Default);
                }
                return m_default;
            }
            set
            {
                m_default = value;
            }
        }
        private static Log m_default;



        private object @lock = new object();

        private LogConfig m_config;
        public Log(LogConfig config)
        {
            this.m_config = config;
        }
        public void Add(string str, eLogType type)
        {
            Monitor.Enter(@lock);
            try
            {
                if (m_config.UseConsole)
                {
                    ConsoleColor old = Console.ForegroundColor;
                    Console.ForegroundColor = m_config.ConsoleColors[(int)type];                   
                    Console.WriteLine(str);
                    Console.ForegroundColor = old;
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
                throw;
            }
            finally
            {
                Monitor.Exit(@lock);
            }
        }
        public void Debug(string str)=>Add(str, eLogType.Debug);
        public void Info(string str) => Add(str, eLogType.Info);
        public void Warn(string str) => Add(str, eLogType.Warn);
        public void Error(string str) => Add(str, eLogType.Error);


        public void Debug(Exception e) => Debug(e.ToString());
        public void Info(Exception e) => Info(e.ToString());
        public void Warn(Exception e) => Warn(e.ToString());
        public void Error(Exception e) => Error(e.ToString());
    }
}
