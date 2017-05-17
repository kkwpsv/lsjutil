using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if NETCOREAPP1_1
namespace Lsj.Util.Core.Collections
#else
namespace Lsj.Util.Collections
#endif
{
    /// <summary>
    /// My queue.
    /// </summary>
    public class MyQueue<T>
    {
        SeqList<T> m_list;
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Collections.MyQueue`1"/> class.
        /// </summary>
        public MyQueue()
        {
            this.m_list = new SeqList<T>();
        }
        /// <summary>
        /// Enqueue the specified value.
        /// </summary>
        /// <returns>The enqueue.</returns>
        /// <param name="value">Value.</param>
        public void Enqueue(T value)
        {
            m_list.Add(value);
        }
        /// <summary>
        /// Dequeue this instance.
        /// </summary>
        /// <returns>The dequeue.</returns>
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
        /// Peek this instance.
        /// </summary>
        /// <returns>The peek.</returns>
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
    }
}
