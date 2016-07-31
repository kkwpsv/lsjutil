using System;
using System.Collections.Generic;

namespace Lsj.Util.Collections
{

    /// <summary>
    /// 对象池
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks>基于队列</remarks>
    public class ObjectPool<T> where T : class
    {
        private readonly Func<T> m_createMethod;
        private readonly Queue<T> m_items = new Queue<T>();

        /// <summary>
        /// 初始化一个<see cref="ObjectPool{T}"/>实例
        /// </summary>
        /// <param name="createHandler">创建方法</param>
        public ObjectPool(Func<T> createHandler)
        {
            m_createMethod = createHandler;
        }

        /// <summary>
        /// 取得一个对象
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
        /// 存入一个对象
        /// </summary>
        /// <param name="value">存入的对象</param>
        public void Enqueue(T value)
        {
            lock (m_items)
                m_items.Enqueue(value);
        }
    }
}