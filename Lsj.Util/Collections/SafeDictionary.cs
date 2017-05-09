using Lsj.Util.Logs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Lsj.Util.Collections
{
    /// <summary>
    /// Safe dictionary.
    /// </summary>
    public class SafeDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>, IDictionary<TKey, TValue>
    {
        object m_lock = new object();
        Dictionary<TKey, TValue> m_Dictionary;
        bool IsMultiThreadSafety = false;

        /// <summary>
        /// Gets the keys.
        /// </summary>
        /// <value>The keys.</value>
        public ICollection<TKey> Keys => m_Dictionary.Keys;
        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <value>The values.</value>
        public ICollection<TValue> Values => m_Dictionary.Values;
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Collections.SafeDictionary`2"/> class.
        /// </summary>
        public SafeDictionary() : this(false)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Collections.SafeDictionary`2"/> class.
        /// </summary>
        /// <param name="IsMultiThreadSafety">If set to <c>true</c> is multi thread safety.</param>
        public SafeDictionary(bool IsMultiThreadSafety) : this(new Dictionary<TKey, TValue>(), IsMultiThreadSafety)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Collections.SafeDictionary`2"/> class.
        /// </summary>
        /// <param name="src">Source.</param>
        public SafeDictionary(Dictionary<TKey, TValue> src) : this(src, false)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Collections.SafeDictionary`2"/> class.
        /// </summary>
        /// <param name="src">Source.</param>
        /// <param name="IsMultiThreadSafety">If set to <c>true</c> is multi thread safety.</param>
        public SafeDictionary(Dictionary<TKey, TValue> src, bool IsMultiThreadSafety)
        {
            if (src == null)
                throw new ArgumentNullException();
            this.m_Dictionary = src;
            this.IsMultiThreadSafety = IsMultiThreadSafety;
        }
        /// <summary>
        /// Gets the null value.
        /// </summary>
        /// <value>The null value.</value>
        public virtual TValue NullValue
        {
            get
            {
                return default(TValue);
            }
        }
        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        public int Count => this.m_Dictionary.Count;
        /// <summary>
        /// Gets a value indicating whether this <see cref="T:Lsj.Util.Collections.SafeDictionary`2"/> is read only.
        /// </summary>
        /// <value><c>true</c> if is read only; otherwise, <c>false</c>.</value>
        public bool IsReadOnly => false;

        /// <summary>
        /// Gets or sets the <see cref="T:Lsj.Util.Collections.SafeDictionary`2"/> with the specified key.
        /// </summary>
        /// <param name="key">Key.</param>
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
                LogProvider.Default.Debug("Add Same Key : " + key.ToString());
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
        /// <summary>
        /// Clear this instance.
        /// </summary>
        public void Clear()
        {
            Clr();
        }


        /// <summary>
        /// Copies to.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <param name="arrayIndex">Array index.</param>
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {

            ((IDictionary<TKey, TValue>)this.m_Dictionary).CopyTo(array, arrayIndex);
        }




        /// <summary>
        /// Containses the key.
        /// </summary>
        /// <returns><c>true</c>, if key was containsed, <c>false</c> otherwise.</returns>
        /// <param name="key">Key.</param>
        public bool ContainsKey(TKey key)
        {
            return Contain(key);
        }
        /// <summary>
        /// Contains the specified item.
        /// </summary>
        /// <returns>The contains.</returns>
        /// <param name="item">Item.</param>
        public bool Contains(KeyValuePair<TKey, TValue> item) => this.Contain(item.Key) && this[item.Key].Equals(item.Value);
        /// <summary>
        /// Tries the get value.
        /// </summary>
        /// <returns><c>true</c>, if get value was tryed, <c>false</c> otherwise.</returns>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
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
            return m_Dictionary.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /// <summary>
        /// Tos the dictionary.
        /// </summary>
        /// <returns>The dictionary.</returns>
        public Dictionary<TKey, TValue> ToDictionary()
        {
            var x = new Dictionary<TKey, TValue>();
            foreach (var a in this)
            {
                x.Add(a.Key, a.Value);
            }
            return x;
        }


        internal TValue GetWithoutCheck(TKey key) => m_Dictionary[key];


        void Lock()
        {
            if (IsMultiThreadSafety)
            {
                Monitor.Enter(m_lock);
            }
        }
        void Unlock()
        {
            if (IsMultiThreadSafety)
            {
                Monitor.Exit(m_lock);
            }
        }
        void Set(TKey key, TValue value)
        {
            try
            {
                Lock();
                m_Dictionary[key] = value;
            }
            catch (Exception e)
            {
                LogProvider.Default.Error(e);
                throw;
            }
            finally
            {
                Unlock();
            }
        }
        bool Contain(TKey key)
        {
            if (key == null)
            {
                LogProvider.Default.Warn("Check if contain null key");
                return false;
            }
            bool result = false;
            try
            {
                Lock();
                result = m_Dictionary.ContainsKey(key);
            }
            catch (Exception e)
            {
                LogProvider.Default.Error(e);
                throw;
            }
            finally
            {
                Unlock();
            }
            return result;
        }
        void Clr()
        {
            try
            {
                Lock();
                m_Dictionary.Clear();
            }
            catch (Exception e)
            {
                LogProvider.Default.Error(e);
                throw;
            }
            finally
            {
                Unlock();
            }
        }
        void Del(TKey key)
        {
            try
            {
                Lock();
                m_Dictionary.Remove(key);
            }
            catch (Exception e)
            {
                LogProvider.Default.Error(e);
                throw;
            }
            finally
            {
                Unlock();
            }
        }

    }
}
