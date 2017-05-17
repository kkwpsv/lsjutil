using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

#if NETCOREAPP1_1
namespace Lsj.Util.Core.Collections
#else
namespace Lsj.Util.Collections
#endif
{
    /// <summary>
    /// Multi thread safe list.
    /// </summary>
    public class MultiThreadSafeList<T> : IList<T>
    {
        List<T> m_list;
        object m_lock = new object();
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Collections.MultiThreadSafeList`1"/> class.
        /// </summary>
        public MultiThreadSafeList()
        {
            m_list = new List<T>();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Collections.MultiThreadSafeList`1"/> class.
        /// </summary>
        /// <param name="src">Source.</param>
        public MultiThreadSafeList(List<T> src)
        {
            m_list = src;
        }
        /// <summary>
        /// Gets or sets the <see cref="T:Lsj.Util.Collections.MultiThreadSafeList`1"/> at the specified index.
        /// </summary>
        /// <param name="index">Index.</param>
        public T this[int index]
        {
            get
            {
                return m_list[index];
            }

            set
            {
                try
                {
                    Lock();
                    m_list[index] = value;
                }
                catch (Exception e)
                {
                    Logs.LogProvider.Default.Error(e);
                    throw;
                }
                finally
                {
                    Unlock();
                }
            }
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        public int Count
        {
            get
            {
                return m_list.Count;
            }
        }
        /// <summary>
        /// Gets a value indicating whether this <see cref="T:Lsj.Util.Collections.MultiThreadSafeList`1"/> is read only.
        /// </summary>
        /// <value><c>true</c> if is read only; otherwise, <c>false</c>.</value>
        public bool IsReadOnly => false;

        /// <summary>
        /// Add the specified item.
        /// </summary>
        /// <returns>The add.</returns>
        /// <param name="item">Item.</param>
        public void Add(T item)
        {
            try
            {
                Lock();
                m_list.Add(item);
            }
            catch (Exception e)
            {
                Logs.LogProvider.Default.Error(e);
                throw;
            }
            finally
            {
                Unlock();
            }
        }
        /// <summary>
        /// Clear this instance.
        /// </summary>
        public void Clear()
        {
            try
            {
                Lock();
                m_list.Clear();
            }
            catch (Exception e)
            {
                Logs.LogProvider.Default.Error(e);
                throw;
            }
            finally
            {
                Unlock();
            }
        }
        /// <summary>
        /// Contains the specified item.
        /// </summary>
        /// <returns>The contains.</returns>
        /// <param name="item">Item.</param>
        public bool Contains(T item)
        {
            return m_list.Contains(item);
        }
        /// <summary>
        /// Copies to.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <param name="arrayIndex">Array index.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            m_list.CopyTo(array, arrayIndex);
        }
        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return m_list.GetEnumerator();
        }
        /// <summary>
        /// Indexs the of.
        /// </summary>
        /// <returns>The of.</returns>
        /// <param name="item">Item.</param>
        public int IndexOf(T item)
        {
            return m_list.IndexOf(item);
        }
        /// <summary>
        /// Insert the specified index and item.
        /// </summary>
        /// <returns>The insert.</returns>
        /// <param name="index">Index.</param>
        /// <param name="item">Item.</param>
        public void Insert(int index, T item)
        {
            try
            {
                Lock();
                m_list.Insert(index, item);
            }
            catch (Exception e)
            {
                Logs.LogProvider.Default.Error(e);
                throw;
            }
            finally
            {
                Unlock();
            }
        }

        /// <summary>
        /// Remove the specified item.
        /// </summary>
        /// <returns>The remove.</returns>
        /// <param name="item">Item.</param>
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
                Logs.LogProvider.Default.Error(e);
                throw;
            }
            finally
            {
                Unlock();
            }
            return result;
        }
        /// <summary>
        /// Removes at index.
        /// </summary>
        /// <param name="index">Index.</param>
        public void RemoveAt(int index)
        {
            try
            {
                Lock();
                m_list.RemoveAt(index);
            }
            catch (Exception e)
            {
                Logs.LogProvider.Default.Error(e);
                throw;
            }
            finally
            {
                Unlock();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return m_list.GetEnumerator();
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
