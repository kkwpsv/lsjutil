using Lsj.Util.Logs;
using Lsj.Util.Threading;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Lsj.Util.Collections
{
    /// <summary>
    /// Multi thread safe dictionary
    /// </summary>
    public class MultiThreadSafeDictionary<TKey, TValue> : DisposableClass, IDisposable, IEnumerable<KeyValuePair<TKey, TValue>>, IDictionary<TKey, TValue> where TKey : notnull
    {
        private ReadWriteLock _lock = new ReadWriteLock();
        private SafeDictionary<TKey, TValue> _dictionary;

        /// <summary>
        /// Keys
        /// </summary>
        public ICollection<TKey> Keys => _dictionary.Keys;

        /// <summary>
        /// Values
        /// </summary>
        public ICollection<TValue> Values => _dictionary.Values;

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
            _dictionary = new SafeDictionary<TKey, TValue>(src);
        }

        /// <summary>
        /// Count
        /// </summary>
        public int Count
        {
            get
            {
                using (_lock.EnterRead())
                {
                    return this._dictionary.Count;
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
                using (_lock.EnterRead())
                {
                    return _dictionary[key];
                }
            }
            set
            {
                using (_lock.EnterWrite())
                {
                    _dictionary[key] = value;
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
            using (_lock.EnterWrite())
            {
                _dictionary.Add(key, value);
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
            using (var x = _lock.EnterUpgradeableRead())
            {
                if (_dictionary.ContainsKey(key))
                {
                    x.Upgrade();
                    _dictionary.DelDirectly(key);
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
            using (var x = _lock.EnterUpgradeableRead())
            {
                if (_dictionary.Contains(item))
                {
                    x.Upgrade();
                    _dictionary.DelDirectly(item.Key);
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
            using (_lock.EnterWrite())
            {
                _dictionary.Clear();
            }
        }

        /// <summary>
        /// Copy to
        /// </summary>
        /// <param name="array">Destination Array</param>
        /// <param name="arrayIndex">Destination Array Index</param>
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            using (_lock.EnterRead())
            {
                _dictionary.CopyTo(array, arrayIndex);
            }
        }

        /// <summary>
        /// If contain specific key
        /// </summary>
        /// <param name="key">Key</param>
        public bool ContainsKey(TKey key)
        {
            using (_lock.EnterRead())
            {
                return _dictionary.ContainsKey(key);
            }
        }

        /// <summary>
        /// If contain specified item.
        /// </summary>
        /// <returns>The contains.</returns>
        /// <param name="item">Item.</param>
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            using (_lock.EnterRead())
            {
                return _dictionary.Contains(item);
            }
        }

        /// <summary>
        /// Try to get value
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        public bool TryGetValue(TKey key, out TValue value)
        {
            using (_lock.EnterRead())
            {
                return _dictionary.TryGetValue(key, out value);
            }
        }

        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            using (_lock.EnterRead())
            {
                return _dictionary.GetEnumerator();
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
            using (_lock.EnterRead())
            {
                return _dictionary.ToDictionary();
            }

        }
    }
}
