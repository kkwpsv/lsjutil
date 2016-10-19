using System.Collections.Generic;

namespace Lsj.Util.Collections
{
    /// <summary>
    /// 安全<see cref="string"/> 字典
    /// </summary>
    public class SafeStringToStringDirectionary : SafeDictionary<string,string>
    {
        /// <summary>
        /// 初始化一个<see cref="SafeStringToStringDirectionary"/>实例
        /// </summary>
        public SafeStringToStringDirectionary() : base()
        {
        }
        /// <summary>
        /// 初始化一个<see cref="SafeStringToStringDirectionary"/>实例
        /// </summary>
        /// <param name="src">源<see cref="Dictionary{TKey, TValue}"/> </param>
        public SafeStringToStringDirectionary(Dictionary<string,string> src):base(src)
        {
        }
        
        /// <summary>
         /// 空值
         /// </summary>
        public sealed override string NullValue => string.Empty;
    }
}
