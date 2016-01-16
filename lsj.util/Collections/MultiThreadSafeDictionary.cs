using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lsj.Util.Collections
{
    /// <summary>
    /// MultiThreadSafeDictionary
    /// </summary>
    /// <typeparam name="TKey">Key Type</typeparam>
    /// <typeparam name="TValue">Value Type</typeparam>
    public class MultiThreadSafeDictionary<TKey, TValue> : SafeDictionary<TKey, TValue>, IEnumerable<KeyValuePair<TKey, TValue>>
    {
        /// <summary>
        /// Inital a new MultiThreadSafeDictionary
        /// </summary>
        public MultiThreadSafeDictionary() : base(true)
        {
        }
    }
}
