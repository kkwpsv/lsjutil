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
        /// Initial a New TwoWayDictionary
        /// </summary>
        public TwoWayDictionary():this(false)
        {
        }
        /// <summary>
        /// Initial a New TwoWayDictionary
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
            return b[value];
        }
        TValue GetValueByKey(TKey key)
        {
            if (!a.ContainsKey(key))
                return GetNullValue(key);
            return a[key];
        }

        public void Add(TKey key, TValue value)
        {
            a[key] = value;
            b[value] = key;
        }
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return a.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public bool ContainsKey(TKey key)
        {
            return a.ContainsKey(key);
        }
        public bool ContainsValue(TValue value)
        {
            return b.ContainsKey(value);
        }
        public virtual TValue GetNullValue(TKey key)
        {
            return default(TValue);
        }
        public virtual TKey GetNullKey(TValue value)
        {
            return default(TKey);
        }
    }

}
