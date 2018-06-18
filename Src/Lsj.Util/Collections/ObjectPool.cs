using System;
using System.Collections.Concurrent;
using System.Collections.Generic;


namespace Lsj.Util.Collections
{

    /// <summary>
    /// Object Pool
    /// </summary>
    public class ObjectPool<T> where T : class
    {
        private readonly Func<T> createMethod;
        private ConcurrentBag<T> items = new ConcurrentBag<T>();

        /// <summary>
        /// Capacity
        /// </summary>
        public int Capacity
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Collections.ObjectPool{T}"/> class.
        /// </summary>
        /// <param name="createMethod">Create Method</param>
        public ObjectPool(Func<T> createMethod)
        {
            this.createMethod = createMethod;
        }

        /// <summary>
        /// Dequeue
        /// </summary>
        public T Dequeue()
        {
            if (items.TryTake(out T item))
            {
                return item;
            }
            else
            {
                return createMethod();
            }
        }

        /// <summary>
        /// Enqueue
        /// </summary>
        public void Enqueue(T value)
        {
            if (value != null)
            {
                if (items.Count > Capacity)
                {
                    (value as IDisposable)?.Dispose();
                }
                else
                {
                    items.Add(value);
                }
            }
        }
    }
}