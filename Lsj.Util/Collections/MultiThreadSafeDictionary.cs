using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Lsj.Util.Logs;
using Lsj.Util.Threading;

namespace Lsj.Util.Collections
{
    /// <summary>
    /// Multi thread safe dictionary
    /// </summary>
    public class MultiThreadSafeDictionary<TKey, TValue> : DisposableClass, IDisposable, IEnumerable<KeyValuePair<TKey, TValue>>, IDictionary<TKey, TValue>
    {
        ReadWriteLock m_lock = new ReadWriteLock();
        SafeDictionary<TKey, TValue> m_Dictionary;

        /// <summary>
        /// Keys
        /// </summary>
        public ICollection<TKey> Keys => m_Dictionary.Keys;
        /// <summary>
        /// Values
        /// </summary>
        public ICollection<TValue> Values => m_Dictionary.Values;


        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Collections.MultiThreadSafeDictionary{TKey, TValue}"/> class.
        /// </summary>
        public MultiThreadSafeDictionary() : this(new Dictionary<TKey, TValue>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Collections.MultiThreadSafeDictionary{TKey, TValue}"/> class.
        /// </summary>
        public MultiThreadSafeDictionary(Dictionary<TKey, TValue> src)
        {
            this.m_Dictionary = new SafeDictionary<TKey, TValue>(src);
        }

        /// <summary>
        /// Count
        /// </summary>
        public int Count
        {
            get
            {
                using (m_lock.EnterRead())
                {
                    return this.m_Dictionary.Count;
                }
            }
        }
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
                using (m_lock.EnterRead())
                {
                    return m_Dictionary[key];
                }
            }
            set
            {
                using (m_lock.EnterWrite())
                {
                    m_Dictionary[key] = value;
                }
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
            using (m_lock.EnterWrite())
            {
                m_Dictionary.Add(key, value);
            }
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
            using (var x = m_lock.EnterUpgradeableRead())
            {
                if (m_Dictionary.ContainsKey(key))
                {
                    x.Upgrade();
                    m_Dictionary.DelInternal(key);
                    return true;
                }
                else
                {
                    LogProvider.Default.Debug("The Key doesn't Exist : " + key.ToString());
                    return false;
                }
            }
        }
        /// <summary>
        /// Remove the specified item.
        /// </summary>
        /// <returns>The remove.</returns>
        /// <param name="item">Item.</param>
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            using (var x = m_lock.EnterUpgradeableRead())
            {
                if (m_Dictionary.Contains(item))
                {
                    x.Upgrade();
                    m_Dictionary.DelInternal(item.Key);
                    return true;
                }
                else
                {
                    LogProvider.Default.Debug("The Key doesn't Exist : " + item.Key.ToString());
                    return false;
                }
            }
        }
        /// <summary>
        /// Clear this instance.
        /// </summary>
        public void Clear()
        {
            using (m_lock.EnterWrite())
            {
                m_Dictionary.Clear();
            }
        }
        /// <summary>
        /// Copy to
        /// </summary>
        /// <param name="array">Destination Array</param>
        /// <param name="arrayIndex">Destination Array Index</param>
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            using (m_lock.EnterRead())
            {
                m_Dictionary.CopyTo(array, arrayIndex);
            }
        }
        /// <summary>
        /// If contain specific key
        /// </summary>
        /// <param name="key">Key</param>
        public bool ContainsKey(TKey key)
        {
            using (m_lock.EnterRead())
            {
                return m_Dictionary.ContainsKey(key);
            }
        }
        /// <summary>
        /// If contain specified item.
        /// </summary>
        /// <returns>The contains.</returns>
        /// <param name="item">Item.</param>
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            using (m_lock.EnterRead())
            {
                return m_Dictionary.Contains(item);
            }
        }

        /// <summary>
        /// Try to get value
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        public bool TryGetValue(TKey key, out TValue value)
        {
            using (m_lock.EnterRead())
            {
                return m_Dictionary.TryGetValue(key, out value);
            }
        }



        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            using (m_lock.EnterRead())
            {
                return m_Dictionary.GetEnumerator();
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Convert To Dictionary
        /// </summary>
        public Dictionary<TKey, TValue> ToDictionary()
        {
            using (m_lock.EnterRead())
            {
                return m_Dictionary.ToDictionary();
            }

        }
    }
}
