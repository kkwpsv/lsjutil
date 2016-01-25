using System.Collections;
using System.Collections.Generic;

namespace Lsj.Util.Collections
{
    /// <summary>
    /// TwoWayDictionary
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class TwoWayDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        SafeDictionary<TKey, TValue> a;
        SafeDictionary<TValue, TKey> b;
        /// <summary>
        /// Initialize a New TwoWayDictionary
        /// </summary>
        public TwoWayDictionary():this(false)
        {
        }
        /// <summary>
        /// Initialize a New TwoWayDictionary
        /// </summary>
        /// <param name="IsMultiThreadSafety">IsMultiThreadSafety</param>
        public TwoWayDictionary(bool IsMultiThreadSafety)
        {
            this.a = new SafeDictionary<TKey, TValue>(IsMultiThreadSafety);
            this.b = new SafeDictionary<TValue, TKey>(IsMultiThreadSafety);
        }
        /// <summary>
        /// Get Or Set The Value
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
        /// Get Or Set The Key
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
        /// Add a new KeyValuePair into the TwoWayDictionary
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(TKey key, TValue value)
        {
            a[key] = value;
            b[value] = key;
        }
        /// <summary>
        /// GetEnumerator
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
        /// Is Contain the Key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey(TKey key)
        {
            return a.ContainsKey(key);
        }
        /// <summary>
        /// Is Contain the Value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ContainsValue(TValue value)
        {
            return b.ContainsKey(value);
        }
        /// <summary>
        /// NullValue
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected virtual TValue NullValue(TKey key)=> default(TValue);
        /// <summary>
        /// NullKey
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected virtual TKey NullKey(TValue value) =>default(TKey);
        
    }

}
