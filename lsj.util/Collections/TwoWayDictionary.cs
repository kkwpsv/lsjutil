using System.Collections;
using System.Collections.Generic;

namespace Lsj.Util.Collections
{
    /// <summary>
    /// 双向字典
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class TwoWayDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        SafeDictionary<TKey, TValue> a;
        SafeDictionary<TValue, TKey> b;
        /// <summary>
        /// 初始化一个<see cref="TwoWayDictionary{TKey, TValue}"/> 实例
        /// </summary>
        public TwoWayDictionary():this(false)
        {
        }
        /// <summary>
        /// 初始化一个<see cref="TwoWayDictionary{TKey, TValue}"/> 实例
        /// </summary>
        /// <param name="IsMultiThreadSafety">是否多线程安全</param>
        public TwoWayDictionary(bool IsMultiThreadSafety)
        {
            this.a = new SafeDictionary<TKey, TValue>(IsMultiThreadSafety);
            this.b = new SafeDictionary<TValue, TKey>(IsMultiThreadSafety);
        }
        /// <summary>
        /// 获取或者设置值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TValue this[TKey key]
        {
            get
            {
                return GetValueByKey(key);
            }
            set
            {
                Add(key, value);
            }
        }
        /// <summary>
        /// 获取或者设置键
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public TKey this[TValue x]
        {
            get
            {
                return GetKeyByValue(x);
            }
            set
            {
                Add(value, x);
            }
                
        }
        TKey GetKeyByValue(TValue value)
        {
            if (ContainsValue(value))
                return NullKey(value);
            return b[value];
        }
        TValue GetValueByKey(TKey key)
        {
            if (ContainsKey(key))
                return NullValue(key);
            return a[key];
        }


        /// <summary>
        /// 添加一个新的键值对
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(TKey key, TValue value)
        {
            a[key] = value;
            b[value] = key;
        }
        /// <summary>
        /// 返回枚举器
        /// </summary>
        /// <returns></returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return a.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /// <summary>
        /// 是否包含一个值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey(TKey key)
        {
            return a.ContainsKey(key);
        }
        /// <summary>
        /// 是否包含一个键
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ContainsValue(TValue value)
        {
            return b.ContainsKey(value);
        }
        /// <summary>
        /// 空值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected virtual TValue NullValue(TKey key)=> default(TValue);
        /// <summary>
        /// 空键
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected virtual TKey NullKey(TValue value) =>default(TKey);
        
    }

}
