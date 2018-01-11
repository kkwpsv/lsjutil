using Lsj.Util.Threading;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;


namespace Lsj.Util.Collections
{
    /// <summary>
    /// Multi thread safe List
    /// </summary>
    public class MultiThreadSafeList<T> : DisposableClass, IDisposable, IList<T>
    {
        List<T> m_list;
        ReadWriteLock m_lock = new ReadWriteLock();
        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Collections.MultiThreadSafeList{T}"/> class.
        /// </summary>
        public MultiThreadSafeList()
        {
            m_list = new List<T>();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Collections.MultiThreadSafeList{T}"/> class.
        /// </summary>
        /// <param name="src">source</param>
        public MultiThreadSafeList(List<T> src)
        {
            m_list = src;
        }
        /// <summary>
        /// Get or Set the item at the specified index
        /// </summary>
        /// <param name="index">index</param>
        public T this[int index]
        {
            get
            {
                using (m_lock.EnterRead())
                {
                    return m_list[index];
                }
            }
            set
            {
                using (m_lock.EnterWrite())
                {
                    m_list[index] = value;
                }
            }
        }

        /// <summary>
        /// Count
        /// </summary>
        /// <value>The count.</value>
        public int Count
        {
            get
            {
                using (m_lock.EnterRead())
                {
                    return m_list.Count;
                }
            }
        }
        /// <summary>
        /// Is Readonly
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Add a item
        /// </summary>
        /// <param name="item">item</param>
        public void Add(T item)
        {
            using (m_lock.EnterWrite())
            {
                m_list.Add(item);
            }
        }
        /// <summary>
        /// Clear the list
        /// </summary>
        public void Clear()
        {
            using (m_lock.EnterWrite())
            {
                m_list.Clear();
            }
        }
        /// <summary>
        /// If contain the specified item
        /// </summary>
        /// <param name="item">item</param>
        public bool Contains(T item)
        {
            using (m_lock.EnterRead())
            {
                return m_list.Contains(item);
            }

        }
        /// <summary>
        /// Copy to
        /// </summary>
        /// <param name="array">Destination Array</param>
        /// <param name="arrayIndex">Destination Array Index</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            using (m_lock.EnterRead())
            {
                m_list.CopyTo(array, arrayIndex);
            }
        }
        /// <summary>
        /// Get the enumerator
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            using (m_lock.EnterRead())
            {
                foreach (var i in m_list)
                {
                    yield return i;
                }
            }
        }
        /// <summary>
        /// Get the index of the item
        /// </summary>
        /// <param name="item">item</param>
        public int IndexOf(T item)
        {
            using (m_lock.EnterRead())
            {
                return m_list.IndexOf(item);
            }
        }
        /// <summary>
        /// Insert the specified item at specified index
        /// </summary>
        /// <param name="index">index</param>
        /// <param name="item">item</param>
        public void Insert(int index, T item)
        {
            using (m_lock.EnterWrite())
            {
                m_list.Insert(index, item);
            }
        }
        /// <summary>
        /// Remove first of the specified item.
        /// </summary>
        /// <param name="item">item</param>
        public bool Remove(T item)
        {
            using (m_lock.EnterWrite())
            {
                return m_list.Remove(item);
            }
        }
        /// <summary>
        /// Removes at index.
        /// </summary>
        /// <param name="index">Index.</param>
        public void RemoveAt(int index)
        {
            using (m_lock.EnterWrite())
            {
                m_list.RemoveAt(index);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            using (m_lock.EnterRead())
            {
                foreach (var i in m_list)
                {
                    yield return i;
                }
            }
        }


        /// <summary>
        /// Clean Up Managed Resources
        /// </summary>
        protected override void CleanUpManagedResources()
        {
            this.m_lock.Dispose();
            base.CleanUpManagedResources();
        }





    }

}
