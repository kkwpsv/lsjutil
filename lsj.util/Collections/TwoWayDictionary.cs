using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Collections
{
    public class TwoWayDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        SafeDictionary<TKey, TValue> a = new SafeDictionary<TKey, TValue>();
        SafeDictionary<TValue, TKey> b = new SafeDictionary<TValue, TKey>();

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
        public TKey GetKeyByValue(TValue value)
        {
         
            return b[value];
        }
        public TValue GetValueByKey(TKey key)
        {
            if (!a.ContainsKey(key))
                return GetNullValue(key);
            return a[key];
        }

        public void Add(TKey key, TValue value)
        {
            a[key] = value;
            b[value] = key;
        }
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return a.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public bool ContainsKey(TKey key)
        {
            return a.ContainsKey(key);
        }
        public bool ContainsValue(TValue value)
        {
            return b.ContainsKey(value);
        }
        public virtual TValue GetNullValue(TKey key)
        {
            return default(TValue);
        }
        public virtual TKey GetNullKey(TValue value)
        {
            return default(TKey);
        }
    }

}
