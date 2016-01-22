using System;
using System.Collections.Generic;
using System.Threading;

namespace Lsj.Util.Collections
{
    /// <summary>
    /// MultiThreadSafeList
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MultiThreadSafeList<T>
    {
        List<T> m_list;
        object m_lock = new object();
        /// <summary>
        /// Inital a new MultiThreadSafeList()
        /// </summary>
        public MultiThreadSafeList():this(new List<T>())
        {
        }
        /// <summary>
        /// Inital a new MultiThreadSafeList()
        /// </summary>
        public MultiThreadSafeList(List<T> src)
        {
            m_list = src;
        }
        /// <summary>
        /// Count
        /// </summary>
        public int Count
        {
            get
            {
                return m_list.Count;
            }
        }
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            try
            {
                Lock();
                m_list.Add(item);
            }
            catch (Exception e)
            {
                Logs.Log.Default.Error(e);
                throw;
            }
            finally
            {
                Unlock();
            }
        }
        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="item"></param>
        public bool Remove(T item)
        {
            var result = false;
            try
            {
                Lock();
                result = m_list.Remove(item);             
            }
            catch (Exception e)
            {
                Logs.Log.Default.Error(e);
                throw;
            }
            finally
            {
                Unlock();             
            }
            return result;
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
