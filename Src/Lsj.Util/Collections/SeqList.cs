using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Lsj.Util.Collections
{
    /// <summary>
    /// Sequence List
    /// </summary>
    public class SeqList<T> : IList<T>
    {
        /// <summary>
        /// Sequence List
        /// </summary>
        public struct SeqListEnumerator : IEnumerator<T>, IEnumerator
        {
            SeqList<T> seqlist;
            int position;
            internal SeqListEnumerator(SeqList<T> seqlist)
            {
                this.seqlist = seqlist;
                this.position = -1;
            }
            /// <summary>
            /// Dispose
            /// </summary>
            public void Dispose()
            {

            }
            /// <summary>
            /// Move to the next
            /// </summary>
            public bool MoveNext()
            {
                if (position < seqlist.last)
                {
                    position++;
                    return true;
                }
                return false;
            }
            /// <summary>
            /// Reset
            /// </summary>
            public void Reset()
            {
                position = -1;
            }

            T IEnumerator<T>.Current
            {
                get
                {
                    return seqlist.elem[position];
                }
            }
            Object IEnumerator.Current
            {
                get
                {
                    return seqlist.elem[position];
                }
            }



        }



        T[] elem;
        int last;
        int maxsize = 10;
        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Collections.SeqList{T}"/> class.
        /// </summary>
        public SeqList()
        {
            this.elem = new T[maxsize];
            last = -1;
        }
        /// <summary>
        /// Add a item
        /// </summary>
        /// <param name="item">item</param>
        public void Add(T item)
        {
            ChekIfNeedEnlargeAndDoEnlarge();
            elem[++last] = item;
        }
        /// <summary>
        /// Clear
        /// </summary>
        public void Clear()
        {
            last = -1;
        }
        /// <summary>
        /// If contain the specified item
        /// </summary>
        /// <param name="item">item</param>
        public bool Contains(T item)
        {
            for (int i = 0; i <= last; i++)
            {
                if (elem[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Copy to
        /// </summary>
        /// <param name="array">Destination Array</param>
        /// <param name="arrayIndex">Destination Array index</param>
        public void CopyTo(T[] array, int arrayIndex) => Buffer.BlockCopy(elem, 0, array, arrayIndex, last + 1);
        /// <summary>
        /// Count
        /// </summary>
        public int Count => last + 1;
        /// <summary>
        /// Is Readonly
        /// </summary>
        public bool IsReadOnly => false;
        /// <summary>
        /// Remove first of the specified item.
        /// </summary>
        /// <param name="item">item</param>
        public bool Remove(T item)
        {
            for (int i = 0; i <= last; i++)
            {
                if (elem[i].Equals(item))
                {
                    Buffer.BlockCopy(elem, i + 1, elem, i, last - i);
                    last--;
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Get the index of the item
        /// </summary>
        /// <param name="item">item</param>
        public int IndexOf(T item)
        {
            for (int i = 0; i <= last; i++)
            {
                if (elem[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// Insert the specified item at specified index
        /// </summary>
        /// <param name="index">index</param>
        /// <param name="item">item</param>
        public void Insert(int index, T item)
        {
            if (index == last + 1)
            {
                Add(item);
                return;
            }
            if (index < 0 || index > last)
            {
                throw new ArgumentOutOfRangeException();
            }
            ChekIfNeedEnlargeAndDoEnlarge();
            Buffer.BlockCopy(elem, index, elem, index + 1, last - index + 1);
            elem[index] = item;
            last++;
        }
        /// <summary>
        /// Removes the item at specified index.
        /// </summary>
        /// <param name="index">index</param>
        public void RemoveAt(int index)
        {
            if (index < 0 || index > last)
            {
                throw new ArgumentOutOfRangeException();
            }

            for (index = index + 1; index <= last; index++)
            {
                elem[index - 1] = elem[index];
            }
            last--;
        }
        /// <summary>
        /// Get or Set the item at the specified index
        /// </summary>
        /// <param name="index">Index.</param>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index > last)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return elem[index];
            }
            set
            {
                if (index < 0 || index > last)
                {
                    throw new ArgumentOutOfRangeException();
                }
                elem[index] = value;
            }

        }



        /// <summary>
        /// Gets the enumerator
        /// </summary>
        public IEnumerator<T> GetEnumerator() => new SeqListEnumerator(this);

        IEnumerator IEnumerable.GetEnumerator() => new SeqListEnumerator(this);

        /// <summary>
        /// Trim Excess
        /// </summary>
        public void TrimExcess()
        {
            var newelem = new T[last + 1];
            Buffer.BlockCopy(elem, 0, newelem, 0, last + 1);
            maxsize = last + 1;
            this.elem = newelem;
        }


        private void ChekIfNeedEnlargeAndDoEnlarge()
        {
            if (this.last + 1 == maxsize)
            {
                Enlarge();
            }
        }
        private void Enlarge()
        {
            T[] newelem;
            if (maxsize == int.MaxValue)
            {
                throw new OutOfMemoryException();
            }
            else if (maxsize <= int.MaxValue / 2)
            {
                newelem = new T[2 * maxsize];
                maxsize *= 2;
            }
            else
            {
                newelem = new T[int.MaxValue];
                maxsize = int.MaxValue;
            }
            Buffer.BlockCopy(elem, 0, newelem, 0, last + 1);
            this.elem = newelem;
        }



    }
}
