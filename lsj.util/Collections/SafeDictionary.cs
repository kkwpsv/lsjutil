using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Lsj.Util.Collections
{
    public class SafeDictionary<TKey,TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        object m_lock = new object();
        Dictionary<TKey, TValue> m_Dictionary;
        bool IsMultiThreadSafety = false;
        public Dictionary<TKey,TValue>.KeyCollection Keys => m_Dictionary.Keys;
        public Dictionary<TKey, TValue>.ValueCollection Values => m_Dictionary.Values;

        public SafeDictionary():this(false)
        {
        }
        public SafeDictionary(bool IsMultiThreadSafety)
        {
            this.m_Dictionary = new Dictionary<TKey, TValue>();
            this.IsMultiThreadSafety = IsMultiThreadSafety;
        }

        public TValue this[TKey key]
        {
            get
            {
                return Contain(key) ? m_Dictionary[key] : GetNullValue(key);
            }
            set
            {
                Set(key, value);
            }
        }
        public void Add(TKey key, TValue value)
        {
            if (Contain(key))
            {
                Log.Log.Default.Debug("Add Same Key" + key.ToString());
            }
            Set(key, value);
        }
        public TValue GetWithoutCheck(TKey key) => m_Dictionary[key];
        public void Remove(TKey key)
        {
            if (Contain(key))
            {
                Del(key);
            }
        }
        public virtual TValue GetNullValue(TKey key)
        {
            return default(TValue);
        }
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return m_Dictionary.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public bool ContainsKey(TKey key)
        {
            return Contain(key);
        }
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
        void Set(TKey key,TValue value)
        {            
            try
            {
                Lock();
                m_Dictionary[key] = value;
            }
            catch (Exception e)
            {
                Log.Log.Default.Error(e);
            }
            finally
            {
                Unlock();
            }
        }
        bool Contain(TKey key)
        {
            bool result = false;
            try
            {
                Lock();
                result = m_Dictionary.ContainsKey(key);
            }
            catch (Exception e)
            {
                Log.Log.Default.Error(e);
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
                Log.Log.Default.Error(e);
            }
            finally
            {
                Unlock();
            }
        }
    }
}
