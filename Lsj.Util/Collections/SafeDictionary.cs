using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Lsj.Util.Logs;
using Lsj.Util.Threading;

namespace Lsj.Util.Collections
{
    /// <summary>
    /// Safe dictionary
    /// </summary>
    public class SafeDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>, IDictionary<TKey, TValue>
    {
        ReadWriteLock m_lock = new ReadWriteLock();
        Dictionary<TKey, TValue> m_Dictionary;
        bool IsMultiThreadSafety = false;

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
        public SafeDictionary() : this(false)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Collections.SafeDictionary{TKey, TValue}"/> class.
        /// </summary>
        /// <param name="IsMultiThreadSafety">If multithread safe</param>
        public SafeDictionary(bool IsMultiThreadSafety) : this(new Dictionary<TKey, TValue>(), IsMultiThreadSafety)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Collections.SafeDictionary{TKey, TValue}"/> class.
        /// </summary>
        /// <param name="src">Source</param>
        public SafeDictionary(Dictionary<TKey, TValue> src) : this(src, false)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Collections.SafeDictionary{TKey, TValue}"/> class.
        /// </summary>
        /// <param name="src">Source</param>
        /// <param name="IsMultiThreadSafety">If multithread safe</param>
        public SafeDictionary(Dictionary<TKey, TValue> src, bool IsMultiThreadSafety)
        {
            this.m_Dictionary = src ?? throw new ArgumentNullException();
            this.IsMultiThreadSafety = IsMultiThreadSafety;
        }
        /// <summary>
        /// NullValue
        /// </summary>
        public virtual TValue NullValue
        {
            get
            {
                return default(TValue);
            }
        }
        /// <summary>
        /// Count
        /// </summary>
        public int Count
        {
            get
            {
                if (IsMultiThreadSafety)
                {
                    using (m_lock.EnterRead())
                    {
                        return this.m_Dictionary.Count;
                    }
                }
                else
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
                if (IsMultiThreadSafety)
                {
                    using (m_lock.EnterRead())
                    {
                        return Contain(key) ? m_Dictionary[key] : NullValue;
                    }
                }
                else
                {
                    return Contain(key) ? m_Dictionary[key] : NullValue;
                }
            }
            set
            {
                if (IsMultiThreadSafety)
                {
                    using (m_lock.EnterWrite())
                    {
                        Set(key, value);
                    }
                }
                else
                {
                    Set(key, value);
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
            if (IsMultiThreadSafety)
            {
                using (m_lock.EnterWrite())
                {
                    if (Contain(key))
                    {
                        LogProvider.Default.Warn("Add Same Key : " + key.ToString());
                    }
                    Set(key, value);
                }
            }
            else
            {
                if (Contain(key))
                {
                    LogProvider.Default.Warn("Add Same Key : " + key.ToString());
                }
                Set(key, value);
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
            if (IsMultiThreadSafety)
            {
                using (var x = m_lock.EnterUpgradeableRead())
                {
                    if (Contain(key))
                    {
                        x.Upgrade();
                        Del(key);
                        return true;
                    }
                    else
                    {
                        LogProvider.Default.Debug("The Key doesn't Exist : " + key.ToString());
                        return false;
                    }
                }
            }
            else
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
        }
        /// <summary>
        /// Remove the specified item.
        /// </summary>
        /// <returns>The remove.</returns>
        /// <param name="item">Item.</param>
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            if (IsMultiThreadSafety)
            {
                using (var x = m_lock.EnterUpgradeableRead())
                {
                    if (Contain(item.Key) && this[item.Key].Equals(item.Value))
                    {
                        x.Upgrade();
                        Del(item.Key);
                        return true;
                    }
                    else
                    {
                        LogProvider.Default.Debug("The Key doesn't Exist : " + item.Key.ToString());
                        return false;
                    }
                }
            }
            else
            {
                if (Contain(item.Key) && this[item.Key].Equals(item.Value))
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
        }
        /// <summary>
        /// Clear this instance.
        /// </summary>
        public void Clear()
        {
            if (IsMultiThreadSafety)
            {
                using (m_lock.EnterWrite())
                {
                    Clr();
                }
            }
            else
            {
                Clr();
            }
        }


        /// <summary>
        /// Copy to
        /// </summary>
        /// <param name="array">Destination Array</param>
        /// <param name="arrayIndex">Destination Array Index</param>
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (IsMultiThreadSafety)
            {
                using (m_lock.EnterRead())
                {
                    ((IDictionary<TKey, TValue>)this.m_Dictionary).CopyTo(array, arrayIndex);
                }
            }
            else
            {
                ((IDictionary<TKey, TValue>)this.m_Dictionary).CopyTo(array, arrayIndex);
            }
        }




        /// <summary>
        /// If contain specific key
        /// </summary>
        /// <param name="key">Key</param>
        public bool ContainsKey(TKey key)
        {
            if (IsMultiThreadSafety)
            {
                using (m_lock.EnterRead())
                {
                    return Contain(key);
                }
            }
            else
            {
                return Contain(key);
            }
        }
        /// <summary>
        /// If contain specified item.
        /// </summary>
        /// <returns>The contains.</returns>
        /// <param name="item">Item.</param>
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            if (IsMultiThreadSafety)
            {
                using (m_lock.EnterRead())
                {
                    return this.Contain(item.Key) && this[item.Key].Equals(item.Value);
                }
            }
            else
            {
                return this.Contain(item.Key) && this[item.Key].Equals(item.Value);
            }
        }

        /// <summary>
        /// Try to get value
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        public bool TryGetValue(TKey key, out TValue value)
        {
            if (IsMultiThreadSafety)
            {
                using (m_lock.EnterRead())
                {
                    var flag = Contain(key);
                    value = flag ? m_Dictionary[key] : NullValue;
                    return flag;
                }
            }
            else
            {
                var flag = Contain(key);
                value = flag ? m_Dictionary[key] : NullValue;
                return flag;
            }
        }


        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            if (IsMultiThreadSafety)
            {
                using (m_lock.EnterRead())
                {
                    foreach (var x in m_Dictionary)
                    {
                        yield return x;
                    }
                }
            }
            else
            {
                foreach (var x in m_Dictionary)
                {
                    yield return x;
                }
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
            if (IsMultiThreadSafety)
            {
                using (m_lock.EnterRead())
                {
                    var x = new Dictionary<TKey, TValue>();
                    foreach (var a in this)
                    {
                        x.Add(a.Key, a.Value);
                    }
                    return x;
                }
            }
            else
            {
                var x = new Dictionary<TKey, TValue>();
                foreach (var a in this)
                {
                    x.Add(a.Key, a.Value);
                }
                return x;
            }

        }

        void Set(TKey key, TValue value)
        {
            m_Dictionary[key] = value;
        }
        bool Contain(TKey key)
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
        void Clr()
        {
            m_Dictionary.Clear();
        }
        void Del(TKey key)
        {
            m_Dictionary.Remove(key);
        }

    }
}
