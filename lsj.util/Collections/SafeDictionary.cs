using System;
using System.Collections;
using System.Collections.Generic;

namespace Lsj.Util.Collections
{
    public class SafeDictionary<TKey,TValue> :IEnumerable<TValue>
    {
        Dictionary<TKey, TValue> m_Dictionary;
        public SafeDictionary()
        {
            this.m_Dictionary = new Dictionary<TKey, TValue>();
        }
        public TValue this[TKey key]
        {
            get
            {
                return m_Dictionary.ContainsKey(key) ? m_Dictionary[key] : GetNullValue(key);
            }
            set
            {
                m_Dictionary[key] = value;
            }
        }
        public void Add(TKey key, TValue value)
        {
            if (ContainsKey(key))
            {
                Log.Log.Default.Debug("Add Same Key" + key.ToString());
            }
            this[key] = value;
        }
        public virtual TValue GetNullValue(TKey key)
        {
            return default(TValue);
        }
        public IEnumerator<TValue> GetEnumerator()
        {
            return m_Dictionary.Values.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public bool ContainsKey(TKey key)
        {
            return m_Dictionary.ContainsKey(key);
        }
    }
}
