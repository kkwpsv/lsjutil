using System;

namespace Lsj.Util.Collections
{
    /// <summary>
    /// Queue
    /// </summary>
    public class MyQueue<T>
    {
        private SeqList<T> m_list;

        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Collections.MyQueue{T}"/> class.
        /// </summary>
        public MyQueue()
        {
            this.m_list = new SeqList<T>();
        }

        /// <summary>
        /// Enqueue
        /// </summary>
        /// <param name="value">item</param>
        public void Enqueue(T value)
        {
            m_list.Add(value);
        }

        /// <summary>
        /// Dequeue
        /// </summary>
        public T Dequeue()
        {
            if (m_list.Count == 0)
            {
                throw new InvalidOperationException();
            }
            else
            {
                var value = m_list[0];
                m_list.RemoveAt(0);
                return value;
            }
        }

        /// <summary>
        /// Peek
        /// </summary>
        public T Peek()
        {
            if (m_list.Count == 0)
            {
                throw new InvalidOperationException();
            }
            else
            {
                var value = m_list[0];
                return value;
            }
        }

        /// <summary>
        /// Count
        /// </summary>
        public int Count => m_list.Count;

        /// <summary>
        /// Is Empty
        /// </summary>
        public bool IsEmpty => Count == 0;
    }
}
