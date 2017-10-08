using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Lsj.Util.Collections
{
    /// <summary>
    /// Stack
    /// </summary>
    public class MyStack<T>
    {
        SeqList<T> m_list;
        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Collections.MyStack{T}"/> class.
        /// </summary>
        public MyStack()
        {
            this.m_list = new SeqList<T>();
        }
        /// <summary>
        /// Push
        /// </summary>
        public void Push(T value)
        {
            m_list.Add(value);
        }
        /// <summary>
        /// Pop
        /// </summary>
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
                var last = m_list.Count - 1;
                var value = m_list[last];
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
