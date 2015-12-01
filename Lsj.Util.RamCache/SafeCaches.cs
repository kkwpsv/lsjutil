using Lsj.Util.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.RamCache
{
    public class SafeCaches<TKey,TValue> where TValue : class
    {
        SafeDictionary<TKey,TValue> caches = new SafeDictionary<TKey ,TValue>();
        public TValue this[TKey key]
        {
           get
            {
                return caches.ContainsKey(key) ? caches.GetWithoutCheck(key) : null;
            }
            set
            {
                caches[key] = value;
            }
        }
    }
}
