using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Lsj.Util.Logs.Interfaces
{
    /// <summary>
    /// Logger
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Add Log
        /// </summary>
        /// <param name="str">content</param>
        /// <param name="type">type</param>
        void Add(string str, LogType type);
    }
}
