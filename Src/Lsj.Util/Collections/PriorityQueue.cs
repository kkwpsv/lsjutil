using System;

namespace Lsj.Util.Collections
{
    /// <summary>
    /// Priority Queue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private T[] data;
        private int maxSize = 7;
        private int nextLayerCount = 8;

        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Collections.PriorityQueue{T}"/> class.
        /// </summary>
        public PriorityQueue() => this.data = new T[maxSize];

        /// <summary>
        /// Count
        /// </summary>
        public int Count { get; private set; } = 0;

        /// <summary>
        /// Dequeue
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            else
            {
                var result = data[0];

                Count--;
                var temp = data[Count];
                var currentIndex = 0;
                while (currentIndex < Count)
                {
                    var rightIndex = (currentIndex + 1) << 1;
                    if (rightIndex < Count && this.data[rightIndex].CompareTo(temp) > 0)
                    {
                        if (this.data[rightIndex - 1].CompareTo(this.data[rightIndex]) > 0)
                        {
                            this.data[currentIndex] = this.data[rightIndex - 1];
                            currentIndex = rightIndex - 1;
                        }
                        else
                        {
                            this.data[currentIndex] = this.data[rightIndex];
                            currentIndex = rightIndex;
                        }
                    }
                    else if (rightIndex - 1 < Count && (this.data[rightIndex - 1].CompareTo(temp) > 0))
                    {
                        this.data[currentIndex] = this.data[rightIndex - 1];
                        currentIndex = rightIndex - 1;
                    }
                    else
                    {
                        break;
                    }
                }
                this.data[currentIndex] = temp;
                return result;
            }
        }

        /// <summary>
        /// Enqueue
        /// </summary>
        /// <param name="value"></param>
        public void Enqueue(T value)
        {
            if (Count == maxSize)
            {
                maxSize += nextLayerCount;
                nextLayerCount *= 2;
                var newBuffer = new T[maxSize];
                Array.Copy(this.data, 0, newBuffer, 0, Count);
                this.data = newBuffer;
            }
            var currentIndex = Count;
            while (currentIndex != 0)
            {
                var topIndex = (currentIndex - 1) >> 1;
                if (this.data[topIndex].CompareTo(value) < 0)
                {
                    this.data[currentIndex] = this.data[topIndex];
                    currentIndex = topIndex;
                }
                else
                {
                    break;
                }
            }
            this.data[currentIndex] = value;
            Count++;
        }
    }
}
