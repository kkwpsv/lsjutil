using System;
using System.Collections;
using System.Collections.Generic;

namespace Lsj.Util.Collections
{
    /// <summary>
    /// Two way dictionary
    /// </summary>
    public class TwoWayDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private SafeDictionary<TKey, TValue> a;
        private SafeDictionary<TValue, TKey> b;

        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Collections.TwoWayDictionary{TKey, TValue}"/> class.
        /// </summary>
        /// <param name="IsMultiThreadSafety">If set to <c>true</c> is multi thread safety.</param>
        public TwoWayDictionary(bool IsMultiThreadSafety)
        {
            this.a = new SafeDictionary<TKey, TValue>();
            this.b = new SafeDictionary<TValue, TKey>();
        }

        /// <summary>
        /// Get or Set the value with specified key
        /// </summary>
        /// <param name="key">Key</param>
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
        /// Get or Set the key with specified value
        /// </summary>
        /// <param name="x">value</param>
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

        private TKey GetKeyByValue(TValue value)
        {
            if (ContainsValue(value))
            {
                return NullKey(value);
            }
            return b[value];
        }

        private TValue GetValueByKey(TKey key)
        {
            if (ContainsKey(key))
            {
                return NullValue(key);
            }

            return a[key];
        }

        /// <summary>
        /// Add the specified key and value.
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        public void Add(TKey key, TValue value)
        {
            if (ContainsValue(value) && !a[key].Equals(value))
            {
                throw new InvalidOperationException("Duplicate value");
            }
            else
            {
                a[key] = value;
                b[value] = key;
            }
        }

        /// <summary>
        /// Gets the enumerator
        /// </summary>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return a.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// If contain specific key
        /// </summary>
        /// <param name="key">Key</param>
        public bool ContainsKey(TKey key)
        {
            return a.ContainsKey(key);
        }

        /// <summary>
        /// If contain specific value
        /// </summary>
        /// <param name="value">Value</param>
        public bool ContainsValue(TValue value)
        {
            return b.ContainsKey(value);
        }

        /// <summary>
        /// NullValue
        /// </summary>
        protected virtual TValue NullValue(TKey key) => default;
        /// <summary>
        /// NullKey
        /// </summary>
        protected virtual TKey NullKey(TValue value) => default;

    }

}
