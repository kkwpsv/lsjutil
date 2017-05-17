using System.Collections;
using System.Collections.Generic;

#if NETCOREAPP1_1
namespace Lsj.Util.Core.Collections
#else
namespace Lsj.Util.Collections
#endif
{
    /// <summary>
    /// Two way dictionary.
    /// </summary>
    public class TwoWayDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        SafeDictionary<TKey, TValue> a;
        SafeDictionary<TValue, TKey> b;
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Collections.TwoWayDictionary`2"/> class.
        /// </summary>
        public TwoWayDictionary() : this(false)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Collections.TwoWayDictionary`2"/> class.
        /// </summary>
        /// <param name="IsMultiThreadSafety">If set to <c>true</c> is multi thread safety.</param>
        public TwoWayDictionary(bool IsMultiThreadSafety)
        {
            this.a = new SafeDictionary<TKey, TValue>(IsMultiThreadSafety);
            this.b = new SafeDictionary<TValue, TKey>(IsMultiThreadSafety);
        }
        /// <summary>
        /// Gets or sets the <see cref="T:Lsj.Util.Collections.TwoWayDictionary`2"/> with the specified key.
        /// </summary>
        /// <param name="key">Key.</param>
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
        /// Gets or sets the <see cref="T:Lsj.Util.Collections.TwoWayDictionary`2"/> with the specified x.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
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
        /// Add the specified key and value.
        /// </summary>
        /// <returns>The add.</returns>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        public void Add(TKey key, TValue value)
        {
            a[key] = value;
            b[value] = key;
        }
        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return a.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /// <summary>
        /// Containses the key.
        /// </summary>
        /// <returns><c>true</c>, if key was containsed, <c>false</c> otherwise.</returns>
        /// <param name="key">Key.</param>
        public bool ContainsKey(TKey key)
        {
            return a.ContainsKey(key);
        }
        /// <summary>
        /// Containses the value.
        /// </summary>
        /// <returns><c>true</c>, if value was containsed, <c>false</c> otherwise.</returns>
        /// <param name="value">Value.</param>
        public bool ContainsValue(TValue value)
        {
            return b.ContainsKey(value);
        }
        /// <summary>
        /// Nulls the value.
        /// </summary>
        /// <returns>The value.</returns>
        /// <param name="key">Key.</param>
        protected virtual TValue NullValue(TKey key) => default(TValue);
        /// <summary>
        /// Nulls the key.
        /// </summary>
        /// <returns>The key.</returns>
        /// <param name="value">Value.</param>
        protected virtual TKey NullKey(TValue value) => default(TKey);

    }

}
