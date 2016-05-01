using System.Collections.Generic;

namespace Lsj.Util.Collections
{
    /// <summary>
    /// 多线程安全字典
    /// </summary>
    /// <typeparam name="TKey">Key Type</typeparam>
    /// <typeparam name="TValue">Value Type</typeparam>
    public class MultiThreadSafeDictionary<TKey, TValue> : SafeDictionary<TKey, TValue>, IEnumerable<KeyValuePair<TKey, TValue>>
    {
        /// <summary>
        /// 初始化一个多线程安全字典类实例
        /// </summary>
        public MultiThreadSafeDictionary() : base(true)
        {
        }
    }
}
