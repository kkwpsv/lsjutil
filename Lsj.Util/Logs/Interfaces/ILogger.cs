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
        /// Add the specified str and type.
        /// </summary>
        /// <returns>The add.</returns>
        /// <param name="str">String.</param>
        /// <param name="type">Type.</param>
        void Add(string str, eLogType type);
    }
}
