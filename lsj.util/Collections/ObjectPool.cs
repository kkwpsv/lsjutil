using System;
using System.Collections.Generic;

namespace Lsj.Util.Collections
{

    /// <summary>
    /// ObjectPool
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObjectPool<T> where T : class
    {
        private readonly CreateHandler<T> _createMethod;
        private readonly Queue<T> _items = new Queue<T>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectPool{T}"/> class.
        /// </summary>
        /// <param name="createHandler">How large buffers to allocate.</param>
        public ObjectPool(CreateHandler<T> createHandler)
        {
            _createMethod = createHandler;
        }

        /// <summary>
        /// Get an object.
        /// </summary>
        /// <returns>Created object.</returns>
        /// <remarks>Will create one if queue is empty.</remarks>
        public T Dequeue()
        {
            lock (_items)
            {
                if (_items.Count > 0)
                    return _items.Dequeue();
            }

            return _createMethod();
        }

        /// <summary>
        /// Enqueues the specified buffer.
        /// </summary>
        /// <param name="value">Object to enqueue.</param>
        /// <exception cref="ArgumentOutOfRangeException">Buffer is is less than the minimum requirement.</exception>
        public void Enqueue(T value)
        {
            lock (_items)
                _items.Enqueue(value);
        }
    }

    /// <summary>
    /// Used to create new objects.
    /// </summary>
    /// <typeparam name="T">Type of objects to create.</typeparam>
    /// <returns>Newly created object.</returns>
    /// <seealso cref="ObjectPool{T}"/>.
    public delegate T CreateHandler<T>() where T : class;
}