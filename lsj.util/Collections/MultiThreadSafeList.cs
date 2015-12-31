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
        public int Count
        {
            get
            {
                try
                {
                    Lock();
                    return m_list.Count;
                }
                catch(Exception e)
                {
                    Log.Log.Default.Error(e);
                    return -1;
                }
                finally
                {
                    Unlock();
                }
            }
        }
        public void Add(T item)
        {
            try
            {
                Lock();
                m_list.Add(item);
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
        public void Remove(T item)
        {
            try
            {
                Lock();
                m_list.Remove(item);
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
