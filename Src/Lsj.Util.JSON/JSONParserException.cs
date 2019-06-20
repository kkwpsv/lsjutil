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
        public JSONParserException(string message) : base(message)
        {
        }

        public JSONParserException(string message, Exception inner) : base(message, inner)
        {
        }
    }

}
