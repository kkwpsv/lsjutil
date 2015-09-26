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
        }
        private static Log m_default;



        private object @lock;

        private LogConfig m_config;
        public Log(LogConfig config)
        {
            this.m_config = config;
        }

        public void Debug(string str)
        {
            Monitor.Enter(@lock);
            try
            {
                if (m_config.UseConsole)
                {
                    ConsoleColor old = Console.ForegroundColor;
                    Console.ForegroundColor = m_config.ConsoleDebugColor;
                    Console.WriteLine(str);
                    Console.ForegroundColor = old;
                }
                if (m_config.UseFile)
                {
                    if (m_config.FilePath.PathIsExists())
                    {
                        var name = m_config.FilePath + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                        File.AppendAllText(name, "[Debug]"+DateTime.Now.ToString()+str+"\n");
                    }
                }
            }
            catch(Exception e)
            {
                WinForm.Notice(e.ToString());
                throw e;
            }
            finally
            {
                Monitor.Exit(@lock);
            }
        }
        public void Info(string str)
        {
            Monitor.Enter(@lock);
            try
            {
                if (m_config.UseConsole)
                {
                    ConsoleColor old = Console.ForegroundColor;
                    Console.ForegroundColor = m_config.ConsoleInfoColor;
                    Console.WriteLine(str);
                    Console.ForegroundColor = old;
                }
                if (m_config.UseFile)
                {
                    if (m_config.FilePath.PathIsExists())
                    {
                        var name = m_config.FilePath + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                        File.AppendAllText(name, "[Info]" + DateTime.Now.ToString() + str + "\n");
                    }
                }
            }
            catch (Exception e)
            {
                WinForm.Notice(e.ToString());
                throw e;
            }
            finally
            {
                Monitor.Exit(@lock);
            }
        }
        public void Warn(string str)
        {
            Monitor.Enter(@lock);
            try
            {
                if (m_config.UseConsole)
                {
                    ConsoleColor old = Console.ForegroundColor;
                    Console.ForegroundColor = m_config.ConsoleWarnColor;
                    Console.WriteLine(str);
                    Console.ForegroundColor = old;
                }
                if (m_config.UseFile)
                {
                    if (m_config.FilePath.PathIsExists())
                    {
                        var name = m_config.FilePath + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                        File.AppendAllText(name, "[Warn]" + DateTime.Now.ToString() + str + "\n");
                    }
                }
            }
            catch (Exception e)
            {
                WinForm.Notice(e.ToString());
                throw e;
            }
            finally
            {
                Monitor.Exit(@lock);
            }
        }
        public void Error(string str)
        {
            Monitor.Enter(@lock);
            try
            {
                if (m_config.UseConsole)
                {
                    ConsoleColor old = Console.ForegroundColor;
                    Console.ForegroundColor = m_config.ConsoleErrorColor;
                    Console.WriteLine(str);
                    Console.ForegroundColor = old;
                }
                if (m_config.UseFile)
                {
                    if (m_config.FilePath.PathIsExists())
                    {
                        var name = m_config.FilePath + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                        File.AppendAllText(name, "[Error]" + DateTime.Now.ToString() + str + "\n");
                    }
                }
            }
            catch (Exception e)
            {
                WinForm.Notice(e.ToString());
                throw e;
            }
            finally
            {
                Monitor.Exit(@lock);
            }
        }
    }
}
