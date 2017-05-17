using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if NETCOREAPP1_1
namespace Lsj.Util.Core.Collections
#else
namespace Lsj.Util.Collections
#endif

{
    /// <summary>
    /// Double link list.
    /// </summary>
    public class DoubleLinkList<T> :DoubleLinkListNode<T>, IList<T>
    {
        /// <summary>
        /// Double link list enumerator.
        /// </summary>
        public class DoubleLinkListEnumerator :IEnumerator<T>, IEnumerator
        {
            DoubleLinkList<T> linklist;
            DoubleLinkListNode<T> current;
            int last;
            internal DoubleLinkListEnumerator(DoubleLinkList<T> linklist)
            {
                this.linklist = linklist;
                this.last = linklist.Count - 1;
            }
            /// <summary>
            /// Releases all resource used by the <see cref="T:Lsj.Util.Collections.DoubleLinkList`1.DoubleLinkListEnumerator"/> object.
            /// </summary>
            /// <remarks>Call <see cref="Dispose"/> when you are finished using the
            /// <see cref="T:Lsj.Util.Collections.DoubleLinkList`1.DoubleLinkListEnumerator"/>. The <see cref="Dispose"/> method
            /// leaves the <see cref="T:Lsj.Util.Collections.DoubleLinkList`1.DoubleLinkListEnumerator"/> in an unusable state.
            /// After calling <see cref="Dispose"/>, you must release all references to the
            /// <see cref="T:Lsj.Util.Collections.DoubleLinkList`1.DoubleLinkListEnumerator"/> so the garbage collector can
            /// reclaim the memory that the <see cref="T:Lsj.Util.Collections.DoubleLinkList`1.DoubleLinkListEnumerator"/> was occupying.</remarks>
            public void Dispose()
            {

            }
            /// <summary>
            /// Moves the next.
            /// </summary>
            /// <returns><c>true</c>, if next was moved, <c>false</c> otherwise.</returns>
            public bool MoveNext()
            {
                if (current == null)
                {
                    current = linklist;
                    return true;
                }
                else
                {
                    if (current.Next != null)
                    {
                        current = current.Next;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            /// <summary>
            /// Reset this instance.
            /// </summary>
            public void Reset()
            {
                current = null;
            }

            T IEnumerator<T>.Current
            {
                get
                {
                    return current.Value;
                }
            }
            Object IEnumerator.Current
            {
                get
                {
                    return current.Value;
                }
            }



        }
        private DoubleLinkListNode<T> child;
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Collections.DoubleLinkList`1"/> class.
        /// </summary>
        public DoubleLinkList()
        {
            this.child = null;
        }
        /// <summary>
        /// Gets or sets the <see cref="T:Lsj.Util.Collections.DoubleLinkList`1"/> at the specified index.
        /// </summary>
        /// <param name="index">Index.</param>
        public T this[int index]
        {
            get
            {
                if (this.child != null)
                {
                    int i = 0;
                    var current = this.child;
                    while (i != index)
                    {
                        if (current.Next != null)
                        {
                            current = current.Next;
                            i++;
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                    }
                    return current.Value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            set
            {
                if (this.child != null)
                {
                    int i = 0;
                    var current = this.child;
                    while (i != index)
                    {
                        if (current.Next != null)
                        {
                            current = current.Next;
                            i++;
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                    }
                    current.Value = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        public int Count
        {
            get
            {
                int result = 0;
                if (child != null)
                {
                    result++;
                    var current = this.child;
                    while (current.Next != null)
                    {
                        result++;
                        current = current.Next;
                    }
                }
                return result;
            }
        }
        /// <summary>
        /// Gets a value indicating whether this <see cref="T:Lsj.Util.Collections.DoubleLinkList`1"/> is read only.
        /// </summary>
        /// <value><c>true</c> if is read only; otherwise, <c>false</c>.</value>
        public bool IsReadOnly => false;
        /// <summary>
        /// Add the specified item.
        /// </summary>
        /// <returns>The add.</returns>
        /// <param name="item">Item.</param>
        public void Add(T item)
        {
            if (this.child != null)
            {
                var current = this.child;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = new DoubleLinkListNode<T>(this)
                {
                    Value = item,
                    Prev = current
                };
            }
            else
            {
                this.child = new DoubleLinkListNode<T>(this)
                {
                    Value = item,
                    Prev = this
                };
            }
        }
        /// <summary>
        /// Clear this instance.
        /// </summary>
        public void Clear()
        {
            this.child = null;
        }
        /// <summary>
        /// Contains the specified item.
        /// </summary>
        /// <returns>The contains.</returns>
        /// <param name="item">Item.</param>
        public bool Contains(T item)
        {
            if (this.child != null)
            {
                var current = this.child;
                while (current != null)
                {
                    if (current.Value.Equals(item))
                    {
                        return true;
                    }
                    current = current.Next;
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Copies to.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <param name="arrayIndex">Array index.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            var index = arrayIndex;
            var length = array.Length;
            var current = this.child;
            while (current != null)
            {
                if (index > length)
                {
                    throw new ArgumentOutOfRangeException();
                }
                array[index] = current.Value;
                current = current.Next;
                index++;
            }

        }
        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator<T> GetEnumerator() => new DoubleLinkListEnumerator(this);
        /// <summary>
        /// Get the index of the item.
        /// </summary>
        /// <returns>The index</returns>
        /// <param name="item">Item.</param>
        public int IndexOf(T item)
        {
            var i = 0;
            if (this.child != null)
            {
                var current = this.child;
                while (current != null)
                {
                    if (current.Value.Equals(item))
                    {
                        return i;
                    }
                    current = current.Next;
                    i++;
                }
                return -1;
            }
            else
            {
                return -1;
            }
        }
        /// <summary>
        /// Insert the specified item.
        /// </summary>
        /// <param name="index">Index.</param>
        /// <param name="item">Item.</param>
        public void Insert(int index, T item)
        {
            var i = 0;
            if (index == 0)
            {
                this.child = new DoubleLinkListNode<T>(this)
                {
                    Value = item,
                    Next = this.child
                };
                if (this.child.Next != null)
                {
                    this.child.Next.Prev = this.child;
                }
            }
            if (this.child != null)
            {
                var current = this.child;
                while (current != null)
                {
                    if (index - 1 == i)
                    {
                        var next = current.Next;
                        current.Next = new DoubleLinkListNode<T>(this)
                        {
                            Value = item,
                            Next = next,
                            Prev = current
                        };

                        return;
                    }
                    current = current.Next;
                    i++;
                }
            }
            throw new ArgumentOutOfRangeException();
        }
        /// <summary>
        /// Remove first of the specified item.
        /// </summary>
        /// <returns>is remove.</returns>
        /// <param name="item">Item.</param>
        public bool Remove(T item)
        {
            if (this.child != null)
            {
                if (this.child.Value.Equals(item))
                {
                    this.child = this.child.Next;
                    this.child.Prev = this;
                    return true;
                }
                var current = this.child.Next;
                while (current != null)
                {
                    if (current.Value.Equals(item))
                    {
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
                        return true;
                    }
                    current = current.Next;
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Removes the item at specified index.
        /// </summary>
        /// <param name="index">Index.</param>
        public void RemoveAt(int index)
        {
            var i = 0;
            if (this.child != null)
            {
                if (index == 0)
                {
                    this.child = this.child.Next;
                    if (this.child != null)
                    {
                        this.child.Prev = this;
                    }
                }
                var current = this.child;
                while (current != null)
                {
                    if (index - 1 == i)
                    {
                        current.Next = current.Next.Next;
                        current.Next.Prev = current;
                        return;
                    }
                    current = current.Next;
                    i++;
                }
            }
            throw new ArgumentOutOfRangeException();
        }

        IEnumerator IEnumerable.GetEnumerator() => new DoubleLinkListEnumerator(this);
    }
    /// <summary>
    /// Double link list node.
    /// </summary>
    public class DoubleLinkListNode<T>
    {
        internal DoubleLinkListNode()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Collections.DoubleLinkListNode`1"/> class.
        /// </summary>
        /// <param name="list">List.</param>
        public DoubleLinkListNode(DoubleLinkList<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException();
            }
            this.List = list;
        }
        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <value>The list.</value>
        public DoubleLinkList<T> List
        {
            get;
            private set;
        }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public T Value
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the next node.
        /// </summary>
        /// <value>The next.</value>
        public DoubleLinkListNode<T> Next
        {
            get;
            internal set;
        }
        /// <summary>
        /// Gets or sets the previous node.
        /// </summary>
        /// <value>The previous.</value>
        public DoubleLinkListNode<T> Prev
        {
            get;
            internal set;
        }



    }
}
