using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Collections
{
    /// <summary>
    /// 
    /// </summary>
    public class MyStack<T>
    {
        SeqList<T> m_list;
        /// <summary>
        /// 
        /// </summary>
        public MyStack()
        {
            this.m_list = new SeqList<T>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void Push(T value)
        {
            m_list.Add(value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// 
        /// </summary>
        public int Count => m_list.Count;
    }
}
