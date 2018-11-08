using Lsj.Util.Logs;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Lsj.Util.Collections
{
    /// <summary>
    /// Safe dictionary
    /// </summary>
    public class SafeDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>, IDictionary<TKey, TValue>
    {
        private Dictionary<TKey, TValue> m_Dictionary;

        /// <summary>
        /// Keys
        /// </summary>
        public ICollection<TKey> Keys => m_Dictionary.Keys;

        /// <summary>
        /// Values
        /// </summary>
        public ICollection<TValue> Values => m_Dictionary.Values;

        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Collections.SafeDictionary{TKey, TValue}"/> class.
        /// </summary>
        public SafeDictionary() : this(new Dictionary<TKey, TValue>()) => Static.DoNothing();

        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Collections.SafeDictionary{TKey, TValue}"/> class.
        /// </summary>
        /// <param name="src">Source</param>
        public SafeDictionary(Dictionary<TKey, TValue> src)
        {
            this.m_Dictionary = src ?? throw new ArgumentNullException();
        }

        /// <summary>
        /// NullValue
        /// </summary>
        public virtual TValue NullValue => default;

        /// <summary>
        /// Count
        /// </summary>
        public int Count => m_Dictionary.Count;

        /// <summary>
        /// Is Readonly
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Get or Set the item with specified key
        /// </summary>
        /// <param name="key">Key</param>
        public TValue this[TKey key]
        {
            get
            {
                return Contain(key) ? m_Dictionary[key] : NullValue;
            }
            set
            {
                Set(key, value);
            }
        }

        /// <summary>
        /// Add the specified key and value.
        /// </summary>
        /// <returns>The add.</returns>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        public void Add(TKey key, TValue value)
        {
            if (Contain(key))
            {
                LogProvider.Default.Warn("Add Same Key : " + key.ToString());
            }
            Set(key, value);
        }

        /// <summary>
        /// Add the specified item.
        /// </summary>
        /// <returns>The add.</returns>
        /// <param name="item">Item.</param>
        public void Add(KeyValuePair<TKey, TValue> item) => Add(item.Key, item.Value);

        /// <summary>
        /// Remove the specified key.
        /// </summary>
        /// <returns>The remove.</returns>
        /// <param name="key">Key.</param>
        public bool Remove(TKey key)
        {
            if (Contain(key))
            {
                Del(key);
                return true;
            }
            else
            {
                LogProvider.Default.Debug("The Key doesn't Exist : " + key.ToString());
                return false;
            }
        }

        /// <summary>
        /// Remove the specified item.
        /// </summary>
        /// <returns>The remove.</returns>
        /// <param name="item">Item.</param>
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {

            if (Contains(item))
            {
                Del(item.Key);
                return true;
            }
            else
            {
                LogProvider.Default.Debug("The Key doesn't Exist : " + item.Key.ToString());
                return false;
            }
        }

        /// <summary>
        /// Clear this instance.
        /// </summary>
        public void Clear() => Clr();

        /// <summary>
        /// Copy to
        /// </summary>
        /// <param name="array">Destination Array</param>
        /// <param name="arrayIndex">Destination Array Index</param>
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) => ((IDictionary<TKey, TValue>)this.m_Dictionary).CopyTo(array, arrayIndex);

        /// <summary>
        /// If contain specific key
        /// </summary>
        /// <param name="key">Key</param>
        public bool ContainsKey(TKey key) => Contain(key);

        /// <summary>
        /// If contain specified item.
        /// </summary>
        /// <returns>The contains.</returns>
        /// <param name="item">Item.</param>
        public bool Contains(KeyValuePair<TKey, TValue> item) => this.Contain(item.Key) && this[item.Key].Equals(item.Value);

        /// <summary>
        /// Try to get value
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        public bool TryGetValue(TKey key, out TValue value)
        {
            var flag = Contain(key);
            value = flag ? m_Dictionary[key] : NullValue;
            return flag;
        }

        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (var x in m_Dictionary)
            {
                yield return x;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Convert To Dictionary
        /// </summary>
        public Dictionary<TKey, TValue> ToDictionary()
        {
            var x = new Dictionary<TKey, TValue>();
            foreach (var a in this)
            {
                x.Add(a.Key, a.Value);
            }
            return x;
        }

        /// <summary>
        /// Set
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        protected virtual void Set(TKey key, TValue value) => m_Dictionary[key] = value;

        /// <summary>
        /// Contain
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected virtual bool Contain(TKey key)
        {
            if (key == null)
            {
                LogProvider.Default.Warn("Check if contain null key");
                return false;
            }
            else
            {
                return m_Dictionary.ContainsKey(key);
            }
        }

        /// <summary>
        /// Clear
        /// </summary>
        protected virtual void Clr() => m_Dictionary.Clear();

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="key"></param>
        protected virtual void Del(TKey key) => m_Dictionary.Remove(key);

        internal void DelDirectly(TKey key) => Del(key);
    }
}
