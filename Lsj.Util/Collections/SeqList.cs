using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Lsj.Util.Collections
{
    /// <summary>
    /// Seq list.
    /// </summary>
    public class SeqList<T> : IList<T>
    {
        /// <summary>
        /// Seq list enumerator.
        /// </summary>
        public class SeqListEnumerator : IEnumerator<T>, IEnumerator
        {
            SeqList<T> seqlist;
            int position;
            internal SeqListEnumerator(SeqList<T> seqlist)
            {
                this.seqlist = seqlist;
                this.position = -1;
            }
            /// <summary>
            /// Releases all resource used by the <see cref="T:Lsj.Util.Collections.SeqList`1.SeqListEnumerator"/> object.
            /// </summary>
            /// <remarks>Call <see cref="Dispose"/> when you are finished using the
            /// <see cref="T:Lsj.Util.Collections.SeqList`1.SeqListEnumerator"/>. The <see cref="Dispose"/> method
            /// leaves the <see cref="T:Lsj.Util.Collections.SeqList`1.SeqListEnumerator"/> in an unusable state. After
            /// calling <see cref="Dispose"/>, you must release all references to the
            /// <see cref="T:Lsj.Util.Collections.SeqList`1.SeqListEnumerator"/> so the garbage collector can reclaim
            /// the memory that the <see cref="T:Lsj.Util.Collections.SeqList`1.SeqListEnumerator"/> was occupying.</remarks>
            public void Dispose()
            {

            }
            /// <summary>
            /// Moves the next.
            /// </summary>
            /// <returns><c>true</c>, if next was moved, <c>false</c> otherwise.</returns>
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
            /// Reset this instance.
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
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Collections.SeqList`1"/> class.
        /// </summary>
        public SeqList()
        {
            this.elem = new T[maxsize];
            last = -1;
        }
        /// <summary>
        /// Add the specified value.
        /// </summary>
        /// <returns>The add.</returns>
        /// <param name="value">Value.</param>
        public void Add(T value)
        {
            ChekIfNeedEnlargeAndDoEnlarge();
            elem[++last] = value;
        }
        /// <summary>
        /// Clear this instance.
        /// </summary>
        public void Clear()
        {
            this.elem = new T[maxsize];
            last = -1;
        }
        /// <summary>
        /// Contains the specified value.
        /// </summary>
        /// <returns>The contains.</returns>
        /// <param name="value">Value.</param>
        public bool Contains(T value)
        {
            for (int i = 0; i <= last; i++)
            {
                if (elem[i].Equals(value))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Copies to.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="offset">Offset.</param>
        public void CopyTo(T[] value, int offset) => Buffer.BlockCopy(elem, 0, value, offset, last + 1);
        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        public int Count => last + 1;
        /// <summary>
        /// Gets a value indicating whether this <see cref="T:Lsj.Util.Collections.SeqList`1"/> is read only.
        /// </summary>
        /// <value><c>true</c> if is read only; otherwise, <c>false</c>.</value>
        public bool IsReadOnly => false;
        /// <summary>
        /// Remove the specified value.
        /// </summary>
        /// <returns>The remove.</returns>
        /// <param name="value">Value.</param>
        public bool Remove(T value)
        {
            for (int i = 0; i <= last; i++)
            {
                if (elem[i].Equals(value))
                {
                    Buffer.BlockCopy(elem, i + 1, elem, i, last - i);
                    last--;
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Indexs the of.
        /// </summary>
        /// <returns>The of.</returns>
        /// <param name="value">Value.</param>
        public int IndexOf(T value)
        {
            for (int i = 0; i <= last; i++)
            {
                if (elem[i].Equals(value))
                {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// Insert the specified index and value.
        /// </summary>
        /// <returns>The insert.</returns>
        /// <param name="index">Index.</param>
        /// <param name="value">Value.</param>
        public void Insert(int index, T value)
        {
            if (index == last + 1)
            {
                Add(value);
                return;
            }
            if (index < 0 || index > last)
            {
                throw new ArgumentOutOfRangeException();
            }
            ChekIfNeedEnlargeAndDoEnlarge();
            Buffer.BlockCopy(elem, index, elem, index + 1, last - index + 1);
            elem[index] = value;
            last++;
        }
        /// <summary>
        /// Removes at i.
        /// </summary>
        /// <param name="i">The index.</param>
        public void RemoveAt(int i)
        {
            if (i < 0 || i > last)
            {
                throw new ArgumentOutOfRangeException();
            }

            for (i = i + 1; i <= last; i++)
            {
                elem[i - 1] = elem[i];
            }
            last--;
        }
        /// <summary>
        /// Gets or sets the <see cref="T:Lsj.Util.Collections.SeqList`1"/> at the specified index.
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
        /// Gets the enumerator.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator<T> GetEnumerator() => new SeqListEnumerator(this);

        IEnumerator IEnumerable.GetEnumerator() => new SeqListEnumerator(this);

        /// <summary>
        /// Trims the excess.
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
