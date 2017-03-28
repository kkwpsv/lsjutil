using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Collections
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyQueue<T>
    {
        SeqList<T> m_list;
        /// <summary>
        /// 
        /// </summary>
        public MyQueue()
        {
            this.m_list = new SeqList<T>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void Enqueue(T value)
        {
            m_list.Add(value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
                var value = m_list[0];
                return value;
            }
        }
    }
}
