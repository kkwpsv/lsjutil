using System;
using System.Collections.Generic;


namespace Lsj.Util.Collections
{

    /// <summary>
    /// Object pool.
    /// </summary>
    public class ObjectPool<T> where T : class
    {
        private readonly Func<T> m_createMethod;
        private readonly Queue<T> m_items = new Queue<T>();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Collections.ObjectPool`1"/> class.
        /// </summary>
        /// <param name="createHandler">Create handler.</param>
        public ObjectPool(Func<T> createHandler)
        {
            m_createMethod = createHandler;
        }

        /// <summary>
        /// Dequeue this instance.
        /// </summary>
        /// <returns>The dequeue.</returns>
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
        /// Enqueue the specified value.
        /// </summary>
        /// <returns>The enqueue.</returns>
        /// <param name="value">Value.</param>
        public void Enqueue(T value)
        {
            lock (m_items)
                m_items.Enqueue(value);
        }
    }
}