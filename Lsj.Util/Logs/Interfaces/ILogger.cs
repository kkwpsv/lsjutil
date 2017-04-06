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
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="type"></param>
        void Add(string str, eLogType type);
    }
}
