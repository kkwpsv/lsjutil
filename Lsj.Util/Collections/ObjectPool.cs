using System;
using System.Collections.Generic;


namespace Lsj.Util.Collections
{

    /// <summary>
    /// Object Pool
    /// </summary>
    public class ObjectPool<T> where T : class
    {
        private Func<T> m_createMethod;
        private MyQueue<T> m_items = new MyQueue<T>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Collections.ObjectPool{T}"/> class.
        /// </summary>
        /// <param name="createMethod">Create Method</param>
        public ObjectPool(Func<T> createMethod)
        {
            m_createMethod = createMethod;
        }

        /// <summary>
        /// Dequeue
        /// </summary>
        public T Dequeue()
        {
            lock (m_items)
            {
                if (m_items.Count > 0)
                    return m_items.Dequeue();
            }

            return m_createMethod();
        }

        /// <summary>
        /// Enqueue
        /// </summary>
        public void Enqueue(T value)
        {
            lock (m_items)
                m_items.Enqueue(value);
        }
    }
}