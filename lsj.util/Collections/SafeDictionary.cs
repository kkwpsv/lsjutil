using Lsj.Util.Logs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Lsj.Util.Collections
{
    /// <summary>
    /// SafeDictionary
    /// </summary>
    /// <typeparam name="TKey">Key Type</typeparam>
    /// <typeparam name="TValue">Value Type</typeparam>
    public class SafeDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>> ,IDictionary<TKey,TValue>
    {
        object m_lock = new object();
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
        /// Initialize a new SafeDictionary Without MultiThreadSafety
        /// </summary>
        public SafeDictionary() : this(false)
        {
        }
        /// <summary>
        /// Inital a new SafeDictionary
        /// </summary>
        /// <param name="IsMultiThreadSafety">Is Muiltthread Safety</param>
        public SafeDictionary(bool IsMultiThreadSafety) : this(new Dictionary<TKey, TValue>(), IsMultiThreadSafety)
        {

        }
        /// <summary>
        /// Inital a new SafeDictionary From a Dictionary
        /// </summary>
        /// <param name="src">Source Dicitionay</param>
        public SafeDictionary(Dictionary<TKey, TValue> src) : this(src, false)
        {
        }
        /// <summary>
        /// Inital a new SafeDictionary From a Dictionary
        /// </summary>
        /// <param name="src">Source Dicitionay</param>
        /// <param name="IsMultiThreadSafety">Is Muiltthread Safety</param>
        public SafeDictionary(Dictionary<TKey, TValue> src, bool IsMultiThreadSafety)
        {
            if (src == null)
                throw new ArgumentNullException();
            this.m_Dictionary = src;
            this.IsMultiThreadSafety = IsMultiThreadSafety;
        }
        /// <summary>
        /// NullValue
        /// </summary>
        /// <returns></returns>
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
        public int Count => this.m_Dictionary.Count;
        /// <summary>
        /// IsReadOnly
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Get Or Set The Value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
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
        /// Add a new KeyValuePair into the Dictionary
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(TKey key, TValue value)
        {
            if (Contain(key))
            {
                LogProvider.Default.Debug("Add Same Key : " + key.ToString());
            }
            Set(key, value);
        }
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="item"></param>
        public void Add(KeyValuePair<TKey, TValue> item) => Add(item.Key, item.Value);
        /// <summary>
        /// Remove a KeyValuePair from the Dictionary
        /// </summary>
        /// <param name="key"></param>
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
        /// Is Contain the Key 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey(TKey key)
        {
            return Contain(key);
        }
        /// <summary>
        /// Get the Enumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return m_Dictionary.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /// <summary>
        /// Get Internal Dictionary
        /// </summary>
        /// <returns></returns>
        public Dictionary<TKey, TValue> GetInternalDictionary() => this.m_Dictionary;
        /// <summary>
        /// To Dictionary
        /// </summary>
        /// <returns></returns>
        public Dictionary<TKey, TValue> ToDictionary() => GetInternalDictionary();




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
        /// <summary>
        /// TryGetValue
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryGetValue(TKey key, out TValue value)
        {
            var flag = Contain(key);
            value = flag ? m_Dictionary[key] : NullValue;
            return flag;
        }


        //Todo
        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// CopyTo
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            ((IDictionary<TKey, TValue>)this.m_Dictionary).CopyTo(array, arrayIndex);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return ((IDictionary<TKey, TValue>)this.m_Dictionary).Contains(item);
        }
    }
}
