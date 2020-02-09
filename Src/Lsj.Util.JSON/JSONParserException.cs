using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.JSON
{
    /// <summary>
    /// JSONParserException
    /// </summary>
    [Serializable]
    public class JSONParserException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public JSONParserException(string message) : base(message)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public JSONParserException(string message, Exception inner) : base(message, inner)
        {
        }
    }

}
