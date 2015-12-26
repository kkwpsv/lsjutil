using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lsj.Util.Collections
{
    public class MultiThreadSafeDictionary<TKey, TValue> : SafeDictionary<TKey, TValue>, IEnumerable<KeyValuePair<TKey, TValue>>
    {
        public MultiThreadSafeDictionary() : base(true)
        {
        }
    }
}
