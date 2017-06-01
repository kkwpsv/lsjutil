using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Lsj.Util.Collections
{
    /// <summary>
    /// My stack.
    /// </summary>
    public class MyStack<T>
    {
        SeqList<T> m_list;
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Collections.MyStack`1"/> class.
        /// </summary>
        public MyStack()
        {
            this.m_list = new SeqList<T>();
        }
        /// <summary>
        /// Push the specified value.
        /// </summary>
        /// <returns>The push.</returns>
        /// <param name="value">Value.</param>
        public void Push(T value)
        {
            m_list.Add(value);
        }
        /// <summary>
        /// Pop this instance.
        /// </summary>
        /// <returns>The pop.</returns>
        public T Pop()
        {
            if (m_list.Count == 0)
            {
                throw new InvalidOperationException();
            }
            else
            {
                var last = m_list.Count - 1;
                var value = m_list[last];
                m_list.RemoveAt(last);
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
                var last = m_list.Count - 1;
                var value = m_list[last];
                return value;
            }
        }
        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        public int Count => m_list.Count;

        /// <summary>
        /// Is Empty
        /// </summary>
        public bool IsEmpty => Count == 0;
    }
}
