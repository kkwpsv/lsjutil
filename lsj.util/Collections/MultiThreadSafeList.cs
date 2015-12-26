using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lsj.Util.Collections
{
    public class MultiThreadSafeList<T>
    {
        List<T> m_list;
        object m_lock = new object();
        public MultiThreadSafeList()
        {
            m_list = new List<T>();
        }
        void Lock()
        {
            Monitor.Enter(m_lock);
        }
        void Unlock()
        {
            Monitor.Exit(m_lock);
        }

    }
}
