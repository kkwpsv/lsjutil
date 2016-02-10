using System.Collections.Generic;

namespace Lsj.Util.Collections
{
    /// <summary>
    /// SafeStringToStringDirectionary
    /// </summary>
    public class SafeStringToStringDirectionary : SafeDictionary<string,string>
    {
        /// <summary>
        /// 
        /// </summary>
        public SafeStringToStringDirectionary() : base()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        public SafeStringToStringDirectionary(Dictionary<string,string> src):base(src)
        {
        }
        
        /// <summary>
         /// NullValue
         /// </summary>
        public sealed override string NullValue => string.Empty;
    }
}
